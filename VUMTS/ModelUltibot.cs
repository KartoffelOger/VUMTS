using System;
using System.IO.Ports;
using System.Text;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VUMTS
{
    public class ModelUltibot : IModel
    {
        private SerialPort _serialPort;
        private IView view;
        private IController controller;
        private int distance;

        IView IModel.View { set => view = value; }
        IController IModel.Controller { set => controller = value; }

        void IModel.startContinuousDistanceMeasurement()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }
        }

        public ModelUltibot()
        {
            _serialPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = _serialPort.ReadExisting();

                if (message.Contains("J"))
                    message = message.Split('J')[1];
                if (message.Contains("\n"))
                    message = message.Split('\r')[0];
                if (message != "")
                {
                    distance = Convert.ToInt32(message);
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        void IModel.stopContinuousDistanceMeasurement()
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        int IModel.getDistance()
        {
            return distance;
        }

    }
}
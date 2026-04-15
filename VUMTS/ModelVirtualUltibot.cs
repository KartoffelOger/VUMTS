using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUMTS
{
    public class ModelVirtualUltibot : IModel
    {
        private IView view;
        private IController controller;

        private int distance;
        private Random randomisierer = new Random();

        IView IModel.View
        {
            set { view = value; }
        }
        IController IModel.Controller
        {
            set { controller = value; }
        }

        int IModel.getDistance()
        {
            distance = randomisierer.Next(3, 196);
            return distance;
        }

        void IModel.stopContinuousDistanceMeasurement()
        {

        }

        void IModel.startContinuousDistanceMeasurement()
        {

        }

    }
}

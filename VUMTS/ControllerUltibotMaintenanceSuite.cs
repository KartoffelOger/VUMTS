using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUMTS
{
    public class ControllerUltibotMaintenanceSuite:IController
    {
        private IView view;
        private IModel model;
        private volatile bool cycleActive = false;

        IView IController.View
        {
            get { return view; }
            set { view = value; }
        }
        IModel IController.Model
        {
            get { return model; }
            set { model = value; }
        }

        public async Task cycleStart()
        {
            if (cycleActive) { return; }
            
            cycleActive = true;

            model.startContinuousDistanceMeasurement();
            while (cycleActive == true)
            {
                view.anzeigen(model.getDistance());
                await Task.Delay(500);
            }
        }

        public void cycleStop()
        {
            model.stopContinuousDistanceMeasurement();
            cycleActive = false;
        }
    }
}

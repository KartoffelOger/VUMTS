using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VUMTS
{
    public interface IModel
    {
        IView View {
            set;
        }
        IController Controller
        {
            set;
        }

        void startContinuousDistanceMeasurement();
        void stopContinuousDistanceMeasurement();
        int getDistance();
    }
}

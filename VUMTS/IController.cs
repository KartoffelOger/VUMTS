using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUMTS
{
    public interface IController
    {
        IView View
        {
            get;
            set;
        }
        IModel Model
        {
            get;
            set;
        }

        Task cycleStart();
        void cycleStop();
    }
}

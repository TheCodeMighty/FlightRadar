using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRadar
{
    public interface IFlightUpdate
    {
        public FlightGUI ConvertToFlightGUI();
    }
}

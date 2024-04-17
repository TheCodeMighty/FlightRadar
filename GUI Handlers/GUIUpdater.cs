using FlightTrackerGUI;
using OOD_Project1.Entities;

namespace OOD_Project1
{
    public static class GUIUpdater
    {
        public static List<FlightGUI> InitializeFlights()
        {
            List<FlightGUI> flights = new List<FlightGUI>();
            DateTime currentTime = DateTime.Now;

            foreach (var flight in EntityStorage.GetInstance().Flights)
            {
                if (currentTime < flight.LandingTime || currentTime > flight.TakeoffTime)
                {
                    FlightToFlightGUIAdapter adapter = new FlightToFlightGUIAdapter(flight, EntityStorage.GetInstance());
                    FlightGUI flightGUI = adapter.ConvertToFlightGUI();
                    if (flightGUI != null)
                    {
                        flights.Add(flightGUI);
                    }
                }
            }

            return flights;
        }
        public static void GUIUpdate()
        {
            System.Timers.Timer guiUpdateTimer = new System.Timers.Timer(1000);
            FlightsGUIData flightsGUIData = new FlightsGUIData(InitializeFlights());

            guiUpdateTimer.Elapsed += (sender, e) =>
            {
                List<FlightGUI> updatedFlights = new List<FlightGUI>();
                foreach (var flight in EntityStorage.GetInstance().Flights)
                {
                    FlightToFlightGUIAdapter adapter = new FlightToFlightGUIAdapter(flight, EntityStorage.GetInstance());
                    FlightGUI uodatedFlightGUI = adapter.ConvertToFlightGUI();
                    if (uodatedFlightGUI != null)
                    {
                        updatedFlights.Add(uodatedFlightGUI);
                    }
                }
                FlightsGUIData updatedFlightsGUIData = new FlightsGUIData(updatedFlights);
                Runner.UpdateGUI(updatedFlightsGUIData);
            };
            guiUpdateTimer.AutoReset = true;
            guiUpdateTimer.Enabled = true;
        }
    }
}

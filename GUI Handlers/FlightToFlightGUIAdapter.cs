using OOD_Project1.Entities;

namespace OOD_Project1
{
    public class FlightToFlightGUIAdapter : IFlightUpdate
    {
        private Flight flight;
        private EntityStorage storage;

        public FlightToFlightGUIAdapter(Flight flight, EntityStorage storage)
        {
            this.flight = flight;
            this.storage = storage;
        }

        public FlightGUI ConvertToFlightGUI()
        {
            DateTime takeoffTime = flight.TakeoffTime;
            DateTime landingTime = flight.LandingTime;
            DateTime currentTime = DateTime.Now;

            // Check if the the flight is still in progress
            if (takeoffTime <= currentTime && currentTime <= landingTime)
            {
                var origin = storage.Airports.FirstOrDefault(a => a.ID == flight.OriginID);
                var destination = storage.Airports.FirstOrDefault(a => a.ID == flight.TargetID);

                // Check for overnight flights
                if (landingTime < takeoffTime)
                {
                    landingTime = landingTime.AddDays(1);
                }

                double progress = (currentTime - takeoffTime).TotalSeconds / (landingTime - takeoffTime).TotalSeconds;

                var latitude = origin.Latitude + (destination.Latitude - origin.Latitude) * progress;
                var longitude = origin.Longitude + (destination.Longitude - origin.Longitude) * progress;

                double rotation = Math.Atan2(destination.Longitude - origin.Longitude, destination.Latitude - origin.Latitude);

                var flightGUI = new FlightGUI
                {
                    ID = flight.ID,
                    WorldPosition = new WorldPosition { Latitude = latitude, Longitude = longitude },
                    MapCoordRotation = rotation
                };

                return flightGUI;
            }

            return new FlightGUI();
        }
    }
}

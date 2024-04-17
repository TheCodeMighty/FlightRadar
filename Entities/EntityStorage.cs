namespace OOD_Project1.Entities
{
    public class EntityStorage
    {
        public List<Airport> Airports { get; set; }
        public List<Flight> Flights { get; set; }
        public List<PassengerPlane> PassengerPlanes { get; set; }
        public List<CargoPlane> CargoPlanes { get; set; }
        public List<Cargo> Cargos { get; set; }
        public List<Crew> Crews { get; set; }     
        public List<Passenger> Passengers { get; set; }

        private static EntityStorage storage;
        public static EntityStorage GetInstance()
        {
            if (storage == null)
            {
                return storage = new EntityStorage();
            }
            return storage;
        }

        private EntityStorage()
        {
            Airports = new List<Airport>();
            Cargos = new List<Cargo>();
            CargoPlanes = new List<CargoPlane>();
            Crews = new List<Crew>();
            Flights = new List<Flight>();
            Passengers = new List<Passenger>();
            PassengerPlanes = new List<PassengerPlane>();
        }
    }
}
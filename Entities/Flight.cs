namespace FlightRadar
{
    public class Flight : BaseEntity
    {
        public ulong OriginID { get; set; }
        public ulong TargetID { get; set; }
        public DateTime TakeoffTime { get; set; }
        public DateTime LandingTime { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float AMSL { get; set; }
        public ulong PlaneID { get; set; }
        public ulong[] CrewIDs { get; set; }
        public ulong[] LoadIDs { get; set; }

        public Flight(string identifier, ulong id, ulong originID, ulong targetID, DateTime takeoffTime, DateTime landingTime, float longitude, float latitude, float amsl, ulong planeID, ulong[] crewIDs, ulong[] loadIDs) : base(identifier, id)
        {
            OriginID = originID;
            TargetID = targetID;
            TakeoffTime = takeoffTime;
            LandingTime = landingTime;
            Longitude = longitude;
            Latitude = latitude;
            AMSL = amsl;
            PlaneID = planeID;
            CrewIDs = crewIDs;
            LoadIDs = loadIDs;
        }
    }
}
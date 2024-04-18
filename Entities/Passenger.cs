namespace FlightRadar
{
    public class Passenger : BaseEntity
    {
        public string Name { get; set; }
        public ulong Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public ulong Miles { get; set; }

        public Passenger(string identifier, ulong id, string name, ulong age, string phone, string email, string _class, ulong miles) : base(identifier, id)
        {
            Name = name;
            Age = age; 
            Phone = phone;
            Email = email;
            Class = _class;
            Miles = miles;
        }
    }
}

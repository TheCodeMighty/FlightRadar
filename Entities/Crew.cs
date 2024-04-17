namespace OOD_Project1
{
    public class Crew : BaseEntity
    {
        public string Name { get; set; }
        public ulong Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ushort Practice { get; set; }
        public string Role { get; set; }

        public Crew(string identifier, ulong id, string name, ulong age, string phone, string email, ushort practice, string role) : base(identifier, id)
        {
            Name = name;
            Age = age;
            Phone = phone;
            Email = email;
            Practice = practice;
            Role = role;
        }
    }
}

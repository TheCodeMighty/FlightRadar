using System.Globalization;

namespace FlightRadar
{
    public class Newspaper : INewsProviderVisitor
    {
        public string Name { get; set; }

        public string Visit(Airport airport)
        {
            // Get first 2 chars of CountryISO because C# doesn't support alpha3 codes
            string countryISO = airport.CountryISO.Substring(0, 2);

            RegionInfo countryName = new RegionInfo(countryISO);

            return $"{Name} - a report from the {airport.Name}, {countryName.EnglishName}.";
        }

        public string Visit(CargoPlane cargoPlane)
        {
            return $"{Name} - An interview with the crew of {cargoPlane.Serial}.";
        }

        public string Visit(PassengerPlane passengerPlane)
        {
            return $"{Name} - Breaking news! {passengerPlane.Model} aircraft loses EASA fails certification after inspection of {passengerPlane.Serial}.";
        }
    }
}

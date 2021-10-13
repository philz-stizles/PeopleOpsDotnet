namespace PeopleOps.Domain.Entities
{
    public class Location: EntityBase
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

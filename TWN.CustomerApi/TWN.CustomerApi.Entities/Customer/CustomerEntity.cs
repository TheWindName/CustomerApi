namespace TWN.CustomerApi.Entities.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public int CountryId { get; set; }
        public string LastAccess { get; set; }
    }
}

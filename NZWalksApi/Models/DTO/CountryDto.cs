

//This is for versioning
namespace NZWalksApi.Models.DTO
{
    public class CountryDtoV1
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }
    }

    public class CountryDtoV2
    {
        public Guid Id { get; set; }

        public string CountryName { get; set; }

        public string Region { get; set; }
    }
}

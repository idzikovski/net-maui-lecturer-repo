
namespace RealEstate.Api.Models
{
    public class Estate
    {
        public long Id { get; set; }

        public string? EstateName { get; set; }

        public string? ContactPersonName { get; set; }

        public string? ContactPersonPhone { get; set; }

        public string? ContactPersonEmail { get; set; }

        public string? Address { get; set; }

        public int RoomNumber { get; set; }

        public int BathroomNumber { get; set; }

        public int Area { get; set; }

        public int Price { get; set; }

        public string? Photo { get; set; }

        public List<string>? Photos { get; set; }
    }
}

using Newtonsoft.Json;

namespace RealEstate.Models
{
    public class EstateDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("estateName")]
        public string EstateName { get; set; }

        [JsonProperty("contactPersonName")]
        public string ContactPersonName { get; set; }

        [JsonProperty("contactPersonPhone")]
        public string ContactPersonPhone { get; set; }

        [JsonProperty("contactPersonEmail")]
        public string ContactPersonEmail { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("roomNumber")]
        public int RoomNumber { get; set; }

        [JsonProperty("bathroomNumber")]
        public int BathroomNumber { get; set; }

        [JsonProperty("area")]
        public int Area { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("photos")]
        public List<string> Photos { get; set; }
    }
}

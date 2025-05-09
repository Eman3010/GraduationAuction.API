using System.Text.Json.Serialization;

namespace raduationAuction.API.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public Auction Auction { get; set; }


        public int? categoryId { get; set; }
        public Category category { get; set; }

    }
}

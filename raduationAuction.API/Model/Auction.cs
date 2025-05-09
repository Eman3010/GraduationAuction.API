using System.Text.Json.Serialization;

namespace raduationAuction.API.Model
{
    public class Auction
    {
        public int AuctionID { get; set; }

        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Status { get; set; }= null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string pictureURL { get; set; } = null!;

       
        [JsonIgnore]
        public int itemid { get; set; }
        public Item item { get; set; }

        public ICollection<Bidding> biddings { get; set; } = new HashSet<Bidding>();
    }
}

namespace raduationAuction.API.Model
{
    public class Bidding
    {
        public int BiddingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }



        public int Auctionid { get; set; }
        public Auction auction { get; set; }

       
    }
}

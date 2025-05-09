namespace GraduationAuction.API.Dtos
{
    public class AuctionDto
    {
        public int AuctionID { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }
        public string pictureURL { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string CategoryName { get; set; }

        public int itemid { get; set; }
        public int UserId { get; set; }   
     
    }
}

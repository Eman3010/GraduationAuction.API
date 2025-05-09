using Microsoft.AspNetCore.Identity;

namespace raduationAuction.API.Model
{
    public class User 
    {
       public int UserID { get; set; }  
        public string Name { get; set; } = null!;
        

       


      //public ICollection<Auction> Auctions { get; set; } = new HashSet<Auction>();


     // public ICollection<Bidding>  biddings { get; set; } = new HashSet<Bidding>();

    }
}

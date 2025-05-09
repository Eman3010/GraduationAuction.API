using System.Text.Json.Serialization;

namespace raduationAuction.API.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;

     
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }

}


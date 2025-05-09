using GraduationAuction.API.Dtos;
using raduationAuction.API.Model;
using System.Threading.Tasks;

namespace GraduationAuction.API.Services
{
    public interface IAuctionServices
    {
        Task<Auction> AddAuctionAsync(AuctionDto auctionDto);
    }
}

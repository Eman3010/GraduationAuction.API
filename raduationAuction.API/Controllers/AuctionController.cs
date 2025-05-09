using GraduationAuction.API.Dtos;
using GraduationAuction.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraduationAuction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController: ControllerBase
    {
        private readonly IAuctionServices _auctionServices;

        public AuctionController(IAuctionServices auctionService)
        {
            _auctionServices = auctionService;
        }


        [HttpPost]
        public async Task<IActionResult> AddAuction( AuctionDto auctionDto)
        {
        
            var auction = await _auctionServices.AddAuctionAsync(auctionDto);

            return CreatedAtAction(nameof(AddAuction), new { id = auction.AuctionID }, auction);
        }
    }
}


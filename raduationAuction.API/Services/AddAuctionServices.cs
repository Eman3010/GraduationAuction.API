using GraduationAuction.API.Dtos;
using GraduationAuction.API.Repositories;
using raduationAuction.API.Model;
using raduationAuction.API.Repositories;

namespace GraduationAuction.API.Services
{
    public class AddAuctionServices : IAuctionServices
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddAuctionServices(IAuctionRepository auctionRepository, IItemRepository itemRepository,ICategoryRepository categoryRepository)
        {
            _auctionRepository = auctionRepository;
            _itemRepository = itemRepository;
            _categoryRepository= categoryRepository;
        }

        public async Task<Auction> AddAuctionAsync(AuctionDto auctionDto)
        {

            var category = await _categoryRepository.GetByNameAsync(auctionDto.CategoryName);
            if (category == null)
            {
                category = new Category()
                {
                    CategoryName = auctionDto.CategoryName
                };

                await _categoryRepository.AddAsync(category);
                await _categoryRepository.SaveAsync();
            }
           

            var item = await _itemRepository.GetByIdAsync(auctionDto.itemid);


            if (item == null)
            {

                item = new Item()
                {
                    Name = auctionDto.Name,
                    Description = auctionDto.Description,
                    categoryId = category.CategoryID
                };

                await _itemRepository.AddAsync(item);
                await _itemRepository.SaveAsync();
            }
                var itemId = item.ItemID;

            var Status = calculateauctionstatus(auctionDto.StartDate, auctionDto.EndDate);
            var auction = new Auction()
                {
                    AuctionID = auctionDto.AuctionID,
                    StartingPrice = auctionDto.StartingPrice,
                    CurrentPrice = auctionDto.StartingPrice,
                    Status = Status,
                    StartDate = auctionDto.StartDate,
                    EndDate = auctionDto.EndDate,
                   // userid = auctionDto.UserId,
                    itemid = itemId,
                    pictureURL = auctionDto.pictureURL

                };

                await _auctionRepository.AddAsync(auction);
                await _auctionRepository.SaveAsync();

                return auction;
            }

        public string calculateauctionstatus(DateTime StartDate, DateTime EndDate)
        {
            var currentDate = DateTime.Now;

            if (currentDate >= StartDate && currentDate <= EndDate)
            {
                return "open";
            }
            else
            {
                return "closed";
            }
        }
    }
    }



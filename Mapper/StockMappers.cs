using API.DTO.Stock;
using API.Models;

namespace API.Mapper
{
    public static class StockMappers
    {
        public static StockDTO ToStockDTO(this Stock stockModel)
        {
            return new StockDTO 
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                comments = stockModel.Comments.Select(x => x.ToCommentDTO()).ToList(),
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDTO stockDTO)
        {
            return new Stock{
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purchase = stockDTO.Purchase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap
            };
        }
    }
}
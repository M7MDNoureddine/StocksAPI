using firstapi.dtos.StocksDtos;
using firstapi.Models;

namespace firstapi.Mappers
{
    public static class StockMapper
    {
        // a function to transfer stock object into another object to present.
        public static StockDTO ToStockDTO(this Stock stock) // "this" keyword allows this function to be an extension of the class Stock.
        {
            return new StockDTO
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }
        // a function to transfer input (JSON) into stock to put in the database. 
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDTO stockDTO)
        {
            return new Stock
            {
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


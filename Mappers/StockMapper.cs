using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstapi.dtos.StocksDtos;
using firstapi.Models;

namespace firstapi.Mappers
{
    public static class  StockMapper
    {
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
    }
}
using firstapi.Data;
using firstapi.Mappers;
using Microsoft.AspNetCore.Mvc;
using firstapi.dtos.StocksDtos;

namespace firstapi.Models.Controllers
{
    [Route("api/[controller]")] //
    //[Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ApplicationDBContext context; // for security and stuff cause im cool
        public StocksController(ApplicationDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = context.Stocks.ToList()
                .Select(s => s.ToStockDTO());
            if (stocks == null || !stocks.Any())
            {
                return NotFound(stocks); // Check if this is being triggered
            }
            return Ok(stocks);

        }

        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id)
        {
            var stock = context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            var stock = stockDTO.ToStockFromCreateDTO();
            context.Stocks.Add(stock);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetByID), new { id = stock.Id }, stock.ToStockDTO());
            // nameof(GetByID) is used instead of "GetByID" in case of a rename.
            // the first parameter is to identify the IActionResult method that could be used to retrieve the info. creating the location header of the Created: 201 response.
            // second parameter is to pass the info needed to the method (if any) which will be displayed in the location header also.
            // the third parameter is the body of the Created: 201 response. 

        }

        //[HttpPut]
        //[Route("{id}")]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO updateDTO)
        {
            // pull the stock from db using its id
            var stockModel = context.Stocks.FirstOrDefault(x => x.Id == id);

            // check if null
            if (stockModel == null)
            {
                return NotFound();
            }

            //update stock from data received in body
            stockModel.Symbol = updateDTO.Symbol;
            stockModel.CompanyName = updateDTO.CompanyName;
            stockModel.Purchase = updateDTO.Purchase;
            stockModel.LastDiv = updateDTO.LastDiv;
            stockModel.Industry = updateDTO.Industry;
            stockModel.MarketCap = updateDTO.MarketCap;

            // save changes to the db
            context.SaveChanges();

            // retrun statement
            return Ok(stockModel.ToStockDTO());

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = context.Stocks.FirstOrDefault(x => x.Id == id);
            context.Stocks.Remove(stockModel);
            context.SaveChanges();

            return NoContent();

        }

    }
}

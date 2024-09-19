using firstapi.Data;
using firstapi.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        public IActionResult Create([FromBody] CreateStockRequestDTO  stockDTO)
        {
            var stock = stockDTO.ToStockFromCreateDTO();
            context.Stocks.Add(stock);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetByID), new { id = stock.Id }, stock.ToStockDTO());

        }
    }
}

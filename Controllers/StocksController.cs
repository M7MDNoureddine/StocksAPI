using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstapi.Data;
using firstapi.Mappers;
using Microsoft.AspNetCore.Mvc;

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
            var stocks = context.Stocks.ToList();
            if (stocks == null || !stocks.Any())
            {
                return NotFound(stocks); // Check if this is being triggered
            }
            return Ok(stocks);

    }
        
        [HttpGet("{id}")]
        public IActionResult getbyid([FromRoute]int id)
        { 
            var stock = context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());

        }
    }
}

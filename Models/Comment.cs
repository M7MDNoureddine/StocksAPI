//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace firstapi.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        //foreign key  
        public int? StockId { get; set; }
        
        //Navigation property (relation)
        public Stock? Stock { get; set; }
    }
}

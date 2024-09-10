using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstapi.Models;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Data
{
    public class ApplicationDBContext : DbContext  
    {
       public ApplicationDBContext(DbContextOptions dbContextOptions) 
       : base(dbContextOptions) //passing the value to the DbContext constructor
       {
         
       } 

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

    }
}
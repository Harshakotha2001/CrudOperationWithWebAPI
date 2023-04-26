using CrudOpp.Model;
using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

namespace CrudOpp.Data
{
    public class CrudAPIDbContext : DbContext
    {
       
        public CrudAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Crud> Cruds { get; set; }
        
    }
}

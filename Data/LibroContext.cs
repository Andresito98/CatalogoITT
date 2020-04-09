using CatalogoITT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoITT.Data
{
    public class LibroContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        { }
    }
}

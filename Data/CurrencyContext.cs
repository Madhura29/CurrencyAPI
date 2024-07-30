using System;
using CurrencyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyAPI.Data
{
    public class CurrencyContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<Currency> Currencies { get; set; }
    }
}

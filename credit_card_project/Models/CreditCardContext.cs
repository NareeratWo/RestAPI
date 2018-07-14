using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace credit_card_project.Models
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options)
            : base(options)
        {
        }       

        public DbSet<CreditCardItem> CreditCardItem { get; set; }


    }
}
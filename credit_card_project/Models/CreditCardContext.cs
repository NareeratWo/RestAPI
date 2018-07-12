using Microsoft.EntityFrameworkCore;

namespace credit_card_project.Models
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options)
            : base(options)
        {
        }

        public DbSet<CreditCardItem> CreditCardItems { get; set; }
    }
}
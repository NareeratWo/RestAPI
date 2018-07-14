using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace credit_card_project.Models
{
    public static class CreditCardData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CreditCardContext(
                serviceProvider.GetRequiredService<DbContextOptions<CreditCardContext>>()))
            {
                // Look for any movies.
                if (context.CreditCardItems.Any())
                {
                    return;   // DB has been seeded
                }

                //context.CreditCardItems.AddRange(
                //    new CreditCardItem
                //    {
                //        card_no = 40000000000001,
                //        expire_date = DateTime.Parse("1989-2-12"),
                //    }
                //);
                //context.SaveChanges();
            }
        }
    }
}
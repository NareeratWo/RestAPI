using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace credit_card_project.Models
{
    public class CreditCardItem
    {
        public long Id { get; set; }
		public long cardNo { get; set; }
        public string expiryDate { get; set; }
		public string cardType { get; set; }

        // public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var context = new CreditCardContext(serviceProvider.GetRequiredService<DbContextOptions<CreditCardContext>>()))
        //        {}
                
       // }/
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Data.SqlClient;


namespace credit_card_project.Models
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options)
            : base(options)
        {
        }       

        public DbSet<CreditCardItem> CreditCardItem { get; set; }

        public bool checkCreditCardOnDB(){
            var connectionString = "Server=tcp:localhost,1433; Initial Catalog=CreditCard;User Id=sa;Password=P@ssw0rd;";
			using (SqlConnection connection = new SqlConnection (connectionString)) {
			var command = new SqlCommand("SELECT TOP 100 CARD_NO, EXPIRE_DATE, CARD_TYPE FROM dbo.CreditCardItem;", connection);
				connection.Open();
				using (var reader = command.ExecuteReader())
				{
						while (reader.Read())
						{
								Console.WriteLine($"{reader[0]}:{reader[1]} ${reader[2]}");
                                return true;
						}

						reader.Close ();
				}
				
				connection.Close ();
            }
            return false;
        }

    }
}
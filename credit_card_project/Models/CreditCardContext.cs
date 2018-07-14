using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;


namespace credit_card_project.Models
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options)
            : base(options)
        {
        }       

        public DbSet<CreditCardItem> CreditCardItem { get; set; }

        public bool checkCreditCardOnDB(CreditCardItem item){
            var connectionString = "Server=tcp:localhost,1433; Initial Catalog=CreditCard;User Id=sa;Password=P@ssw0rd;";
			using (SqlConnection connection = new SqlConnection (connectionString)) {
			    var command = new SqlCommand("dbo.SP_CHECK_CREDIT_CARD", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Card_NO", SqlDbType.VarChar).Value = item.CARD_NO;
                command.Parameters.Add("@expire_date", SqlDbType.VarChar).Value = item.EXPIRE_DATE;
                command.Parameters.Add("@card_type", SqlDbType.VarChar).Value = item.CARD_TYPE;
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
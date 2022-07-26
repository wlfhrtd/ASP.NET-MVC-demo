using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Mvc.ViewComponents
{
    public class LookupListViewComponent : ViewComponent
    {
        private readonly string connectionString;

        public List<SelectListItem> Ls;


        public LookupListViewComponent(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Ciliberti");
            Ls = new();
        }


        public IViewComponentResult Invoke()
        {
            using (SqlConnection connection = new(connectionString))
            {
                string sql = "SELECT GenreName, GenreLookUpId FROM [dbo].[GenreLookUp]";
                using (SqlCommand command = new(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Ls.Add(
                                new SelectListItem
                                {
                                    Text = dr["GenreName"].ToString(),
                                    Value = dr["GenreLookUpId"].ToString(),
                                });
                        }
                    }
                }
            }

            return View(Ls);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Mvc.Models;


namespace Mvc.ViewComponents
{
    public class TagCloudViewComponent : ViewComponent
    {
        private readonly string connectionString;


        public TagCloudViewComponent(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Ciliberti");
        }


        public IViewComponentResult Invoke()
        {
            DataTable dt = new();
            using (SqlConnection connection = new(connectionString))
            {
                string sql = @"SELECT GenreName, GenreId
                               FROM [dbo].[Song]
                               JOIN [dbo].[GenreLookUp] ON Song.GenreId=GenreLookUp.GenreLookUpId";

                using (SqlCommand command = new(sql, connection))
                {
                    SqlDataAdapter da = new(command);
                    da.Fill(dt);
                }
            }

            var grouped = dt
                .AsEnumerable()
                .GroupBy(s => s.Field<string>("GenreName"))
                .Select(genre => new { Name = genre.Key, Count = genre.Count() });

            TagCloud model = new();
            foreach (var item in grouped)
            {
                TagCloudItem tci = new()
                {
                    DisplayText = item.Name,
                    Url = string.Concat("/Genres/", item.Name),
                    Weight = item.Count,
                };

                model.AddItem(tci);
            }

            return View(model);
        }
    }
}

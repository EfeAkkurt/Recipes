using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using var connection = new SqlConnection("");

            // dapper ile RecipesTable tablosundaki verileri �a��r�yoruz recipe t�r�nde bir listeye d�n��t�r�yoruz
            var recipe = connection.Query<Recipe>("SELECT * FROM RecipesTable").ToList();

            // gelen veriler Viewe gidiyor recipe olarak ve html olarak i�leyece�iz
            return View(recipe);
        }

        // g�nderi detaylar�n� g�stermek i�in kullan�lan GET metodu
        [HttpGet]
        public IActionResult Detail(int id)
        {
            using var connection = new SqlConnection("");

            var recipe = connection.QuerySingleOrDefault<Recipe>("SELECT * FROM RecipesTable WHERE Id = @id", new { id });

            // Modeli View'e g�nderiyoruz
            return View(recipe);
        }
    }
}

using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            using var connection = new SqlConnection("");

            // RecipesTable tablosundaki verileri çektik
            // Veriler recipes türünde listeleniyor  .
            var recipes = connection.Query<Recipe>("SELECT * FROM RecipesTable").ToList();

            // gelen veriler veriler Indexe gidiyor  """""""burada görüntülenecek"""""
            return View(recipes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Yeni bir yazı eklemek için form sayfasını çıkardık
            // Sadece GET isteğiyle çalışır ve boş bir form görünümü açar
            return View();
        }

        [HttpPost]
        public IActionResult Add(Recipe model)
        {
            using var connection = new SqlConnection("");
            connection.Execute("INSERT INTO RecipesTable (RecipeName, Ingredients, Preparation, ImageUrl) VALUES (@RecipeName, @Ingredients, @Preparation, @ImageUrl)", model);

            ViewData["SuccessMsg"] = "Yeni yazı eklendi.";
            return View();
        }

        public IActionResult Delete(int id)
        {
            using var connection = new SqlConnection("");

            // RecipesTable tablosunda """"""""Id'si eşsleşen kaydı siliyoruz"""""""""""""""
            connection.Execute("DELETE FROM RecipesTable WHERE Id = @id", new { id });

            // RedirectToAction yani işlem olduktan sorna diğer safaya yani yönlendirdiğin sayfaya burada Index bu tabi
            // oraya yönlendiriyor direk 
            return RedirectToAction("Index");
        }
    }

}

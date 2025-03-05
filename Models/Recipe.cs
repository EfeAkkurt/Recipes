using Microsoft.AspNetCore.Mvc;

namespace Recipes.Models
{
    public class Recipe : Controller
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string ImageUrl { get; set; }
    }
}

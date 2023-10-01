using api.DAL.Enumerables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        [Route("categories")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public IActionResult GetAllProductCategories()
        {
            IEnumerable<ProductCategory> productCategories = Enum.GetValues<ProductCategory>();
            IList<string> categories = new List<string>();
            foreach(ProductCategory category in productCategories)
            {
                categories.Add(category.GetDisplayName());
            }

            string categoriesToJson = JsonSerializer.Serialize(categories);
            return Ok(categoriesToJson);
        }
    }
}

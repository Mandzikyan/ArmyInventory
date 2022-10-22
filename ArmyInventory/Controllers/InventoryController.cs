using ArmyInventory.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ArmyInventory.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryControler : ControllerBase
    {

        private readonly InventoryRepository _inventoryRepository;

        public InventoryControler()
        {

            _inventoryRepository = new InventoryRepository();

        }

        [HttpGet()]

        public IActionResult GetCategory()
        {
            var method = _inventoryRepository.GetCategory();
            if (method == null)
            {
                return BadRequest();
            }
            return Ok(method);
        }

        [HttpGet("CategoryItems")]

        public IActionResult CategoryItems(string CategoryName)
        {
            var method = _inventoryRepository.GetItemsOfCategory(CategoryName);
            if (method == null)
            {
                return BadRequest();
            }
            return Ok(method);
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategoryAsync(string Categoryname)
        {

            var method = _inventoryRepository.AddCategoryAsync(Categoryname);
            if (method == null)
            {
                return BadRequest();
            }
            return Ok(method);
        }

        [HttpPost("AddItem")]
        public IActionResult AddItemAsync(
            string Barcode,
            int Distance,
            decimal Weight,
            int Capacity,
            decimal Price,
            string Name,
            int Quantity,
            string CategoryName)
        {

            var method = _inventoryRepository.AddItemAsync(
             Barcode,
             Distance,
             Weight,
             Capacity,
             Price,
             Name,
             Quantity,
             CategoryName);

            if (method == null)
            {
                return BadRequest();
            }
            return Ok(method);
        }

        [HttpDelete("RemoveItem")]

        public IActionResult RemoveItem(string Name, string CategoryName)
        {
            var method = _inventoryRepository.RemoveItemAsync(Name, CategoryName);

            if (method == null)
            {
                return BadRequest();
            }
            return Ok(method);
        }

    }
}

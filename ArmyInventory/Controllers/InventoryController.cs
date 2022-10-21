using ArmyInventory.Services;
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
            return Ok(_inventoryRepository.GetCategory());
        }

        [HttpGet("CategoryItems")]

        public IActionResult CategoryItems(string CategoryName)
        {
            return Ok(_inventoryRepository.GetItemsOfCategory(CategoryName));
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategoryAsync(string Categoryname)
        {
            return Ok(_inventoryRepository.AddCategoryAsync(Categoryname));
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
            return Ok(_inventoryRepository.AddItemAsync(
             Barcode,
             Distance,
             Weight,
             Capacity,
             Price,
             Name,
             Quantity,
             CategoryName));
        }

        [HttpDelete("RemoveItem")]

        public IActionResult RemoveItem(string Name, string CategoryName)
        {
            return Ok(_inventoryRepository.RemoveItemAsync(Name, CategoryName));
        }

    }
}

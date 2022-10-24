using ArmyInventory.Services;
using Data.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var method = _inventoryRepository.GetCategories();
            if (method == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Route("CategoryItems")]
        public IActionResult CategoryItems(string CategoryItems)
        {
            var method = _inventoryRepository.GetItemsOfCategory(CategoryItems);
            if (method == null)
            {
                return BadRequest();
            }

            return Ok(method);
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(string Categoryname)
        {
            var method = await _inventoryRepository.AddCategoryAsync(Categoryname);
            if (method.IsFailed)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Route("AddItem")]

        public async Task<IActionResult> AddItem([FromBody] Description Desc)
        {

            var method = await _inventoryRepository.AddItemAsync(
             Desc);

            if (method.IsFailed)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("RemoveItem")]
        public async Task<IActionResult> RemoveItem(string Name, string CategoryName)
        {
            var method = await _inventoryRepository.RemoveItemAsync(Name, CategoryName);

            if (method.IsFailed)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}

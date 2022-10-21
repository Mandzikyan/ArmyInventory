using Data.Dbcontext;
using Data.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyInventory.Services

{

    public class InventoryRepository
    {
        private readonly InventoryContext _context;


        public InventoryRepository()
        {

            _context = new InventoryContext();
        }


        public IEnumerable<Category> GetCategory()
        {
            return _context.Categories.ToList<Category>();
        }
        public async Task<Result> AddCategoryAsync(string NewCategoryName)
        {
            if (NewCategoryName == null)
            {
                return Result.Fail("");
            }

            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Categoryname == NewCategoryName);

            try
            {
                if (item == null)
                {
                    var t = new Category()
                    {
                        Categoryname = NewCategoryName.ToLower()

                    };
                    await _context.Categories.AddAsync(t);
                    await _context.SaveChangesAsync();
                    return Result.Ok();
                }
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

        }

        public async Task<Result> AddItemAsync(
            string Barcode,
            int Distance,
            decimal Weight,
            int Capacity,
            decimal Price,
            string Name,
            int Quantity,
            string CategoryName)
        {
            if (CategoryName == null || Barcode == null || Name == null || Quantity == 0 || Weight == 0)
            {
                return Result.Fail("");
            }

            var item = await _context.Descriptions.FirstOrDefaultAsync(x => x.Categoryname == CategoryName && x.Name == Name);

            try
            {
                if (item == null)
                {
                    var t = new Description()
                    {
                        Barcode = Barcode.ToLower(),
                        Distance = Distance,
                        Weight = Weight,
                        Capacity = Capacity,
                        Name = Name.ToLower(),
                        Quantity = Quantity,
                        Price = Price,
                        Categoryname = CategoryName.ToLower()
                    };
                    await _context.Descriptions.AddAsync(t);
                    await _context.SaveChangesAsync();
                    return Result.Ok();
                }
                item.Quantity += Quantity; 
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

        }

        public async Task<Result> RemoveItemAsync(
            string Name,
            string CategoryName)
        {

            if (CategoryName == null || Name == null)
            {
                return Result.Fail("");
            }

            var item = await _context.Descriptions.FirstOrDefaultAsync(x => x.Categoryname == CategoryName && x.Name == Name);
            try
            {
                if (item == null)
                {
                    return Result.Ok();
                }
                _context.Descriptions.Remove(item);
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result<Description>> GetItemsOfCategory(string CategoryName)
        {

            if (CategoryName == null)
            {
                return Result.Fail("");
            }

            var item = await _context.Descriptions.FirstOrDefaultAsync(x => x.Categoryname == CategoryName);
            try
            {
                if (item == null)
                {
                    return Result.Ok();
                }
                return Result.Ok<Description>(item);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

    }
}

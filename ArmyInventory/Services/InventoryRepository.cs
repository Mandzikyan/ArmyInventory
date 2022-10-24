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

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
        
        public IEnumerable<Description> GetItemsOfCategory(string CategoryName)
        {
            var r = _context.Descriptions.Where(x => x.Categoryname == CategoryName);


            return r;
        }

        public async Task<Result> AddCategoryAsync(string NewCategoryName)
        {
            if (NewCategoryName == null)
            {
                return Result.Fail("");
            }

            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Categoryname == NewCategoryName.ToLower());

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
            Description desc)
        {
            if (desc.Categoryname == null || desc.Barcode == null || desc.Name == null || desc.Quantity == 0 || desc.Weight == 0)
            {
                return Result.Fail("");
            }

            var item = await _context.Descriptions.FirstOrDefaultAsync(x => x.Categoryname == desc.Categoryname.ToLower() && x.Name == desc.Name.ToLower());

            try
            {
                if (item == null)
                {
                    
                    await _context.Descriptions.AddAsync(desc);
                    await _context.SaveChangesAsync();
                    return Result.Ok();
                }
                 
                item.Quantity += desc.Quantity; 
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
    }
}

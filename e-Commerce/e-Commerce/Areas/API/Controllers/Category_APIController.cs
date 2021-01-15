using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_Commerce.Data;
using e_Commerce.Models;

namespace e_Commerce.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Category_APIController : ControllerBase
    {
        private readonly DPContext _context;

        public Category_APIController(DPContext context)
        {
            _context = context;
        }
        [HttpPut("{id}")]
        public async Task<string> PutCategoryModel(int id)
        {
            var categoryModel = await _context.Categories.FindAsync(id);
            if (id != categoryModel.CategoryID)
            {
                return "0";
            }

            _context.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                if(categoryModel.Status==true)
                {
                    categoryModel.Status = false;
                }
                else
                {
                    categoryModel.Status = true;
                }    
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
                {
                    return "0";
                }
                else
                {
                    throw;
                }
            }

            return "{\"id\":"+id+",\"stt\":\""+categoryModel.Status +"\"}";
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategoryModel(int id)
        {
            var categoryModel = await _context.Categories.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();

            return categoryModel;
        }

        private bool CategoryModelExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}

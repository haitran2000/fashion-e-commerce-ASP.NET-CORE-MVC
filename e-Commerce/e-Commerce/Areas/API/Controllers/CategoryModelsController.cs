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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryModelsController : ControllerBase
    {
        private readonly DPContext _context;

        public CategoryModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/CategoryModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/CategoryModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryModel(int id)
        {
            var categoryModel = await _context.Categories.FindAsync(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return categoryModel;
        }

        // PUT: api/CategoryModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryModel(int id, CategoryModel categoryModel)
        {
            if (id != categoryModel.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CategoryModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> PostCategoryModel(CategoryModel categoryModel)
        {
            _context.Categories.Add(categoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryModel", new { id = categoryModel.CategoryID }, categoryModel);
        }

        // DELETE: api/CategoryModels/5
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

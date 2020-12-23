using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Ecommerce.Helper;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly DPContext _context;

        public SliderController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Slider
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Admin/Slider/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderModel = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderID == id);
            if (sliderModel == null)
            {
                return NotFound();
            }

            return View(sliderModel);
        }

        // GET: Admin/Slider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SliderID,Name,Picture,Title,Content,Type,Status")] SliderModel sliderModel, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sliderModel);
                //Image.UploadPicture(sliderModel.SliderID, sliderModel.Picture, ful);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/slider", sliderModel.SliderID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                sliderModel.Picture = sliderModel.SliderID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                _context.Add(sliderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderModel);
        }

        // GET: Admin/Slider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderModel = await _context.Sliders.FindAsync(id);
            if (sliderModel == null)
            {
                return NotFound();
            }
            return View(sliderModel);
        }

        // POST: Admin/Slider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderID,Name,Picture,Title,Content,Type,Status")] SliderModel sliderModel, IFormFile ful)
        {
            if (id != sliderModel.SliderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(sliderModel);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/slider", sliderModel.SliderID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    sliderModel.Picture = sliderModel.SliderID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                    _context.Update(sliderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderModelExists(sliderModel.SliderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sliderModel);
        }

        // GET: Admin/Slider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderModel = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderID == id);
            if (sliderModel == null)
            {
                return NotFound();
            }

            return View(sliderModel);
        }

        // POST: Admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sliderModel = await _context.Sliders.FindAsync(id);
            _context.Sliders.Remove(sliderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderModelExists(int id)
        {
            return _context.Sliders.Any(e => e.SliderID == id);
        }
    }
}

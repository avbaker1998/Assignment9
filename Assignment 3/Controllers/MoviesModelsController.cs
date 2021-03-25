using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Models;

namespace Assignment_3.Controllers
{
    public class MoviesModelsController : Controller
    {
        private readonly MovieDBContext _context;

        public MoviesModelsController(MovieDBContext context)
        {
            _context = context;
        }

        // GET: MoviesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: MoviesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }

        // GET: MoviesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoviesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,Category,Title,Year,Director,Rating,Edited,Lent,Notes")] MoviesModel moviesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moviesModel);
        }

        // GET: MoviesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies.FindAsync(id);
            if (moviesModel == null)
            {
                return NotFound();
            }
            return View(moviesModel);
        }

        // POST: MoviesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,Category,Title,Year,Director,Rating,Edited,Lent,Notes")] MoviesModel moviesModel)
        {
            if (id != moviesModel.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesModelExists(moviesModel.MovieID))
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
            return View(moviesModel);
        }

        // GET: MoviesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }

        // POST: MoviesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesModel = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(moviesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesModelExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}

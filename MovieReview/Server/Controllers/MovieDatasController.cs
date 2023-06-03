using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieReview.Server.Data;
using MovieReview.Server.Model;

namespace MovieReview.Server.Controllers
{
    public class MovieDatasController : Controller
    {
        private readonly MovieReviewServerContext _context;

        public MovieDatasController(MovieReviewServerContext context)
        {
            _context = context;
        }

        // GET: MovieDatas
        public async Task<IActionResult> Index()
        {
              return _context.MovieData != null ? 
                          View(await _context.MovieData.ToListAsync()) :
                          Problem("Entity set 'MovieReviewServerContext.MovieData'  is null.");
        }

        // GET: MovieDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MovieData == null)
            {
                return NotFound();
            }

            var movieData = await _context.MovieData
                .FirstOrDefaultAsync(m => m.MovieName == id);
            if (movieData == null)
            {
                return NotFound();
            }

            return View(movieData);
        }

        // GET: MovieDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieName,MovieDescription,MovieRating")] MovieData movieData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieData);
        }

        // GET: MovieDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MovieData == null)
            {
                return NotFound();
            }

            var movieData = await _context.MovieData.FindAsync(id);
            if (movieData == null)
            {
                return NotFound();
            }
            return View(movieData);
        }

        // POST: MovieDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MovieName,MovieDescription,MovieRating")] MovieData movieData)
        {
            if (id != movieData.MovieName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDataExists(movieData.MovieName))
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
            return View(movieData);
        }

        // GET: MovieDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MovieData == null)
            {
                return NotFound();
            }

            var movieData = await _context.MovieData
                .FirstOrDefaultAsync(m => m.MovieName == id);
            if (movieData == null)
            {
                return NotFound();
            }

            return View(movieData);
        }

        // POST: MovieDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MovieData == null)
            {
                return Problem("Entity set 'MovieReviewServerContext.MovieData'  is null.");
            }
            var movieData = await _context.MovieData.FindAsync(id);
            if (movieData != null)
            {
                _context.MovieData.Remove(movieData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDataExists(string id)
        {
          return (_context.MovieData?.Any(e => e.MovieName == id)).GetValueOrDefault();
        }
    }
}

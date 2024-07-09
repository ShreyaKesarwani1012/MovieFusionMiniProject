using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieFusion.Models;

namespace MovieFusion.Controllers
{
    public class MovieListsController : Controller
    {
        private readonly MovieFusionContext _context;

        public MovieListsController(MovieFusionContext context)
        {
            _context = context;
        }

        // GET: MovieLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieLists.ToListAsync());
        }

        // GET: MovieLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieList = await _context.MovieLists
                .FirstOrDefaultAsync(m => m.MId == id);
            if (movieList == null)
            {
                return NotFound();
            }

            return View(movieList);
        }

        // GET: MovieLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MId,Mname,Genre,Duration,Mpic")] MovieList movieList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieList);
        }

        // GET: MovieLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieList = await _context.MovieLists.FindAsync(id);
            if (movieList == null)
            {
                return NotFound();
            }
            return View(movieList);
        }

        // POST: MovieLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MId,Mname,Genre,Duration,Mpic")] MovieList movieList)
        {
            if (id != movieList.MId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieListExists(movieList.MId))
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
            return View(movieList);
        }

        // GET: MovieLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieList = await _context.MovieLists
                .FirstOrDefaultAsync(m => m.MId == id);
            if (movieList == null)
            {
                return NotFound();
            }

            return View(movieList);
        }

        // POST: MovieLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieList = await _context.MovieLists.FindAsync(id);
            if (movieList != null)
            {
                _context.MovieLists.Remove(movieList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieListExists(int id)
        {
            return _context.MovieLists.Any(e => e.MId == id);
        }
    }
}

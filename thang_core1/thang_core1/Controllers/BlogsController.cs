using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thang_core1.Data;

namespace thang_core1.Models
{
    public class BlogsController : Controller
    {
        /// <summary>
        /// readonly _context
        /// </summary>
        private readonly thang_core1Context _context;

        /// <summary>
        /// database 
        /// </summary>
        /// <param name="context"></param>
        public BlogsController(thang_core1Context context)
        {
            _context = context;
        }

        /// <summary>
        /// get list blogs
        /// </summary>
        /// <returns></returns>
        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blog.ToListAsync());
       
        }

        /// <summary>
        /// find blog
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<IActionResult> Search(string searchString)
        {
            var blogs = from m in _context.Blog select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                blogs = blogs.Where(s => s.tin.Contains(searchString));
            }
            return View(await blogs.ToListAsync());
        }

        /// <summary>
        /// property of blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        /// <summary>
        /// create a view of blog
        /// </summary>
        /// <returns></returns>
        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// create a blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tin,loai,trangThai,viTri,motangan,chitiet,ngayPublic")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        /// <summary>
        /// create a view of edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        /// <summary>
        /// edit blog
        /// </summary>
        /// <param name="button"></param>
        /// <param name="id"></param>
        /// <param name="blog"></param>
        /// <returns></returns>
        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string button,int? id, [Bind("id,tin,loai,trangThai,viTri,motangan,chitiet,ngayPublic")] Blog blog)
        {
            if (id != blog.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.id))
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
            ModelState.Clear();
            return View(blog);
        }

        /// <summary>
        /// create a view delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        /// <summary>
        /// confirm delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var blog = await _context.Blog.FindAsync(id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// return true false by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool BlogExists(int? id)
        {
            return _context.Blog.Any(e => e.id == id);
        }
    }
}

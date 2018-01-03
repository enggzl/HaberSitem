using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HaberSitem.Core.Data;
using HaberSitem.Core.Model;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using HaberSitem.Admin.Models;
using Microsoft.AspNetCore.Http;


namespace HaberSitem.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
       

            public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginViewmodel login)
        {
            if (ModelState.IsValid)
            {
                login.Password = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(login.Password)));
                var user = _context.Users.FirstOrDefaultAsync(u => u.Email == login.UserName && u.Password == login.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", login.UserName);
                    return RedirectToAction("Index", "Users");
                }
                ModelState.AddModelError("Result", "Gçersiz kullanıcı adı ve sifre");

            }
            return View(login);
        }
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            User n = new User();
            
            n.CretaeDate = DateTime.Now;

            n.CreatedBy = User.Identity.Name;

            n.UpdateDate = DateTime.Now;

            n.UpdatedBy = User.Identity.Name;
           
            return View(n);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,ConfirmPassword,CretaeDate,CreatedBy,UpdateDate,UpdatedBy")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CretaeDate = DateTime.Now;
                user.CreatedBy = User.Identity.Name;
                user.UpdateDate = DateTime.Now;
                user.UpdatedBy = User.Identity.Name;
              

                user.Password = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,ConfirmPassword,CretaeDate,CreatedBy,UpdateDate,UpdatedBy")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.UpdateDate = DateTime.Now;
                    user.UpdatedBy = User.Identity.Name;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class MainController : Controller
    {
        
        // GET: Main
        private ApplicationDbContext _context;
        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Main/Details/5
        public ActionResult Details(int id ,Character character)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            Character character = new Character();
            return View(character);
        }

        // POST: Main/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Character character)
        {
            try
            {
                _context.Characters.Add(character);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View(character);
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id, Character character)
        {
            List<string> names = new List<string>() { "Superman", "Batman", "Spiderman", "Wolverine", };
            var namesFourCharactersOrLess = names.Where(n => n.Length <= 4).ToList();

            var superHeroInDb = _context.Characters.Where(s => s.Id == id).FirstOrDefault();

            Character superhero = null;
            foreach (Character  s in _context.Characters)
            {
                if (s.Id ==id)
                {
                    return View(superhero);
                }
            }

            return View(superhero);
        }

        // POST: Main/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
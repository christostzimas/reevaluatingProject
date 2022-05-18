﻿using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuizzesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Quiz> objQuizList = _db.quizzes;
            return View(objQuizList);
        }





        //CREATE SECTION

        //GET
        public IActionResult Create()
        {
            ViewBag.Subject = _db.subjects.ToList();
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Quiz obj)
        {

            if (ModelState.IsValid)
            {
                _db.quizzes.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Quiz created succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }






        //EDIT SECTION

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var quizFromDb = _db.quizzes.Find(id);

            if (quizFromDb == null)
            {
                return NotFound();
            }
            ViewBag.Subject = _db.subjects.ToList();
            return View(quizFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Quiz obj)
        {

            if (ModelState.IsValid)
            {
                _db.quizzes.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Quiz updated succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }






        //DELETE SECTION

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var quizFromDb = _db.quizzes.Find(id);

            if (quizFromDb == null)
            {
                return NotFound();
            }

            return View(quizFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.quizzes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.quizzes.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Quiz deleted succesfully";
            return RedirectToAction("Index");

        }

        //GET: Quizzes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.quizzes == null)
            {
                return NotFound();
            }

            var quiz = await _db.quizzes
                .FirstOrDefaultAsync(m => m.id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }
    }
}

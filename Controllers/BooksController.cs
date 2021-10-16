﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {

        public IActionResult Random()
        {
            var firstBook = new Book() { Name = "English dictionary" };
            // to use this in view we should import model book there
            ViewBag.Book = firstBook;

            return View();
        }
        // int nullable it does not need any value
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }
            // it saves with chains of symbols on screen
            // in app we have deafult define root 
            return Content($"pageIndex={pageIndex}&sortBy{sortBy}");
        }

        [Route("books/released/{year:regex(^\\d{{4}}$)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}

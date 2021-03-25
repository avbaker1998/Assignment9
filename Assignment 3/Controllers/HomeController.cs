using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }



        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }


        //when the user goes to the page for the first time, thats a get
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }


        //if the use clicks a button then its a post
        [HttpPost]
        public IActionResult Movies(MoviesModel moviesEntered)
        {
            tempStorage.AddMovie(moviesEntered);
            //Debug.WriteLine(moviesEntered.Title);
            return View("Confirmation", moviesEntered);
        }



        public IActionResult ListedMovies()
        {
            return View(tempStorage.Movies);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FillmyHub.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using FillmyHub.Controllers;
using System.Text.Json.Serialization;
using Microsoft.Win32;
using FillmyHub.Data;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;


namespace FillmyHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly UserDbContext db;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger, UserDbContext db)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            this.db = db;
        }



        public async Task<IActionResult> Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwNzAzMmU2YjA4NDMzNmRlMWQ1MTVhMmJhMTEyYmFkOCIsInN1YiI6IjY0ZDNlNDcwZGQ5MjZhMDFlOTg3YmQ1NSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.nf3OISp0W87cprwZXdkN-4hgY0-dHR7k4w6o_TokVbI");
                HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/trending/movie/day");
                _logger.LogWarning(response.ToString());
                string? responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                   model.TrendingMovies = JsonConvert.DeserializeObject(responseBody);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    // Pass movie details to ViewBag

                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve movie details.");
                }
            }
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwNzAzMmU2YjA4NDMzNmRlMWQ1MTVhMmJhMTEyYmFkOCIsInN1YiI6IjY0ZDNlNDcwZGQ5MjZhMDFlOTg3YmQ1NSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.nf3OISp0W87cprwZXdkN-4hgY0-dHR7k4w6o_TokVbI");
                HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/popular?language=en-US&page=1");
                _logger.LogWarning(response.ToString());
                string? responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                   model.PopularMovies = JsonConvert.DeserializeObject(responseBody);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    // Pass movie details to ViewBag

                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve movie details.");
                }
            }
            
            return View(model);
        }

		public async Task<IActionResult> MovieList()
		{
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwNzAzMmU2YjA4NDMzNmRlMWQ1MTVhMmJhMTEyYmFkOCIsInN1YiI6IjY0ZDNlNDcwZGQ5MjZhMDFlOTg3YmQ1NSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.nf3OISp0W87cprwZXdkN-4hgY0-dHR7k4w6o_TokVbI");
                HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/popular?language=en-US&page=1");
                _logger.LogWarning(response.ToString());
                string? responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    dynamic popularMovie = JsonConvert.DeserializeObject(responseBody);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    // Pass movie details to ViewBag
                    return View(popularMovie);

                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve movie details.");
                }
            }
		}
        public IActionResult Watchlist()
		{
			return View();
		}

        public async Task<IActionResult> Movie(int id)
        {
            //string apiKey = "73b27bfeb96b523c9a9f0eeabaa2b90";
            string baseUrl = "https://api.themoviedb.org/3";
            string endpoint = $"/movie/{id}";

            string url = $"{baseUrl}{endpoint}?language=en-US";

            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwNzAzMmU2YjA4NDMzNmRlMWQ1MTVhMmJhMTEyYmFkOCIsInN1YiI6IjY0ZDNlNDcwZGQ5MjZhMDFlOTg3YmQ1NSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.nf3OISp0W87cprwZXdkN-4hgY0-dHR7k4w6o_TokVbI");
                 HttpResponseMessage response = await client.GetAsync($"https://api.themoviedb.org/3/movie/{id}?language=en-US");
                _logger.LogWarning(response.ToString());
                string? responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    
                        // Deserialize the JSON data
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        MovieViewModel movieDetails = JsonConvert.DeserializeObject<MovieViewModel>(responseBody);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                        ViewBag.MovieDetails = movieDetails; // Pass movie details to ViewBag
                    return View();
                    
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve movie details.");
                }
            }
        }

        
        public async Task<IActionResult> Search(string q)
        {
            //string apiKey = "73b27bfeb96b523c9a9f0eeabaa2b90";
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwNzAzMmU2YjA4NDMzNmRlMWQ1MTVhMmJhMTEyYmFkOCIsInN1YiI6IjY0ZDNlNDcwZGQ5MjZhMDFlOTg3YmQ1NSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.nf3OISp0W87cprwZXdkN-4hgY0-dHR7k4w6o_TokVbI");
                 HttpResponseMessage response = await client.GetAsync($"https://api.themoviedb.org/3/search/movie?query={q}&include_adult=false&language=en-US&page=1");
                _logger.LogWarning(response.ToString());
                string? responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    dynamic movieList = JsonConvert.DeserializeObject(responseBody);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    // Pass movie details to ViewBag
                    return View(movieList);

                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve movie details.");
                }
            }
        }

        [HttpGet]
        public IActionResult Login()
		{
			return View();
		}
        public IActionResult Signup()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User user)
        {
            if (db.Viewer.Any(x => x.name == user.name))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                db.Viewer.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
        }
            [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {

        
            
                var checkLogin = db.Viewer.Where(x => x.email.Equals(user.email) && x.password.Equals(user.password)).Select(x => new { x.Id, x.name }).FirstOrDefault();
                if (checkLogin != null)
                {
                    HttpContext.Session.SetString("Id",user.Id.ToString());
                    HttpContext.Session.SetString("name",user.email.ToString());
                    TempData["Message"] = "Welcome," + checkLogin.name.ToString();
                    

                    return RedirectToAction("Index", "Home");
                }

                else
                {

                    ViewBag.Notification = "Enter Wrong Email or Password";
                }
            

            return View();

        }




        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
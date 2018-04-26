using System;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace WeatherApp.ClientMVC.Controllers
{
    public class MakeAPostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>("User");
            
            return View(new MakeAPostViewModel(user));
        }

        public IActionResult Invalid(string message)
        {
            ViewData["Message"] = message;
            return View();
        }

         // Check if user is logged in if so then cont. Home/Landing page. 
        [HttpGet]
        public IActionResult Registered()
        {
            bool userfound = true;
                try
                {
                    var user = HttpContext.Session.Get<User>("User");
                    var chk2= user.Email;
                }
                catch (System.NullReferenceException)
                {
                    userfound = false;
                }
                if (userfound)
                {
                    
                    return RedirectToAction("Index", "Landing");
                }else{

                    return RedirectToAction(nameof(Invalid),new{ message = "Please log in"});
                }
            
        
            // return View(new MakeAPostViewModel());
        
        }

        // Check if user is logged in if so then cont. New Post page. 
        [HttpGet]
        public IActionResult Registered1()
        {
            bool userfound = true;
                try
                {
                    var user = HttpContext.Session.Get<User>("User");
                    var chk2= user.Email;
                }
                catch (System.NullReferenceException)
                {
                    userfound = false;
                }
                if (userfound)
                {
                    
                    return RedirectToAction("Index", "MakeAPost");
                }
                else{

                        return RedirectToAction(nameof(Invalid),new{ message = "Please log in"});
                    }        
        }

        // Check if user is logged in if so then cont. New Post page. 
        [HttpGet]
        public IActionResult Registered2()
        {
            bool userfound = true;
                try
                {
                    var user = HttpContext.Session.Get<User>("User");
                    var chk2= user.Email;
                }
                catch (System.NullReferenceException)
                {
                    userfound = false;
                }
                if (userfound)
                {
                    
                    return RedirectToAction("Index", "Feed");
                }
                else{

                        return RedirectToAction(nameof(Invalid),new{ message = "Please log in"});
                    }        
        }


        [HttpPost]
        public ActionResult Index(MakeAPostViewModel model, IFormFile file)
        {
            var user = HttpContext.Session.Get<User>("User");
            // user = GetValidUserForNewlyRegistered(user); //Get user with userID for newly registered users
            var currentWeather = HttpContext.Session.Get<RootObject>("CurrentWeather");

            // <---save image to root folder--->
            // check if file is selected
            if (file == null || file.Length == 0) return Content("File not selected.");

            // get path
            string imageName = GetUniqueFileName(file.FileName);
            string currentDirectory = Directory.GetCurrentDirectory();
            string path_to_Images = currentDirectory + "\\wwwroot\\UserFiles\\Images\\" + imageName;

            Console.WriteLine(path_to_Images);
            //Good up to here

            Console.WriteLine("File Stream is failing?");
            //copy file to target
            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {
                // save filename to NewPost.ImageFile
                Console.WriteLine(path_to_Images);
                model.NewPost.ImageFile = imageName;
                file.CopyTo(stream);
                // <---end save image--->
            }

            //Good past here
            ViewData["FilePath"] = "faker";

            //Add Post
            Console.WriteLine("Make a post right now");
            var post = PostHandler.AddPost(user, currentWeather, model.NewPost.ImageFile, model.NewPost.BlogPost).GetAwaiter().GetResult();

            if (post != null)
            {
                Console.WriteLine("Post went through");
            }
            else
            {
                Console.WriteLine("Problem with post");
            }

            //Put to database here
            return RedirectToAction("Index", "Landing");
        }

        public User GetValidUserForNewlyRegistered(User user)
        {
            //If user has just registered get their userID
            if (user.UserID == 0)
            {
                var users = UserHandler.GetAllUsersFromLibSvcAsync().GetAwaiter().GetResult();
                foreach (var u in users)
                {
                    if (u.Email.Equals(user.Email))
                    {
                        user = u;
                        break;
                    }
                }
            }
            return user;
        }

        // codes below this line are required for image saving
        private readonly IHostingEnvironment _environment;

        // Constructor
        public MakeAPostController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
        }
        // generate a guid to append to file name
        private string GetUniqueFileName(string fileName)
        {
            Console.WriteLine("Generating unique file name...");
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }

}
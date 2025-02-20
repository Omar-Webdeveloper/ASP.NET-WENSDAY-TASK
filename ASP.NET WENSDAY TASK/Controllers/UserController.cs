using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ASP.NET_WENSDAY_TASK.Controllers
{

    public class UserController : Controller
    {
        public const string SessionFirst_UserName = "_UserFirstName";
        public const string SessionSecnod_UserName = "_UserSecnodName";
        public const string SessionUserEmail = "_UserEmail";
        public const string SessionUserPassword = "_UserPassword";
        public const string SessionUserRepeatPassword = "_UserRepeatPassword";
        //[HttpPost]
        public IActionResult Rigster()
        {

            //string firstname = Request.Form["name_1"];

            //string lastname = Request.Form["name_2"];

            //string email = Request.Form["user_email"];

            //string password = Request.Form["user_password"];

            //string repeatpassword = Request.Form["user_repeat_password"];

            ////Storing Data into Session using SetString  method
            //HttpContext.Session.SetString(SessionFirst_UserName, firstname);
            //HttpContext.Session.SetString(SessionSecnod_UserName, lastname);
            //HttpContext.Session.SetString(SessionUserEmail, email);
            //HttpContext.Session.SetString(SessionUserPassword, password);
            //HttpContext.Session.SetString(SessionUserRepeatPassword, repeatpassword);


            //    return RedirectToAction("Login", "User");

            return View();

        }
        [HttpPost]
        public IActionResult TheRegisterProsses()
        {
            //HttpContext.Session.SetString("username", username);
            //HttpContext.Session.SetString("email", email);
            //HttpContext.Session.SetString("password", password);
            //HttpContext.Session.SetString("rpassword", rpassword);


            string V_firstname = Request.Form["firstname"];

            string V_lastname = Request.Form["lastname"];

            string V_email = Request.Form["email"];

            string V_password = Request.Form["password"];

            string V_repeatpassword = Request.Form["repeatpassword"];

            //Storing Data into Session using SetString  method
            HttpContext.Session.SetString(SessionFirst_UserName, V_firstname);
            HttpContext.Session.SetString(SessionSecnod_UserName, V_lastname);
            HttpContext.Session.SetString(SessionUserEmail, V_email);
            HttpContext.Session.SetString(SessionUserPassword, V_password);
            HttpContext.Session.SetString(SessionUserRepeatPassword, V_repeatpassword);



            if (V_password != V_repeatpassword)
            {
                TempData["msg"] = "Password and Confirm Password must be same";
                return RedirectToAction("Register");
            }

            return RedirectToAction("Login", "User");




        }

        //[HttpPost]
        //public IActionResult RegisterProsses(string username, string email, string password, string rpassword)
        //{
        //    HttpContext.Session.SetString("username", username);
        //    HttpContext.Session.SetString("email", email);
        //    HttpContext.Session.SetString("password", password);
        //    HttpContext.Session.SetString("rpassword", rpassword);

        //    if (password != rpassword)
        //    {
        //        TempData["msg"] = "Password and Confirm Password must be same";
        //        return RedirectToAction("Register");
        //    }

        //    return RedirectToAction("Login");




        //}

        public IActionResult Login()
        {
            //string? UserName = HttpContext.Session.GetString(SessionUserEmail);
            //string? UserId = HttpContext.Session.GetString(SessionUserPassword);
            //if (UserName == "omar@gmail.com" && UserId == "123")
            //{
            //    return RedirectToAction("Index", "Home");

            //}
            return View();

        }
        [HttpPost]
        public IActionResult TheLoginProsses()
        {
                    //public IActionResult TheLoginProsses(string email, string password)

            //string sessionEmail = HttpContext.Session.GetString("email");
            //string sessionPassword = HttpContext.Session.GetString("password");
            //if (email == sessionEmail && password == sessionPassword)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    TempData["msg"] = "Invalid Email or Password";
            //    return RedirectToAction("Login");
            //}
            string V_email = Request.Form["email"];

            string V_password = Request.Form["password"];

            string? UserName = HttpContext.Session.GetString(SessionUserEmail);
            string? UserId = HttpContext.Session.GetString(SessionUserPassword);
            if (V_email == UserName && V_password == UserId)
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Login");
        }

        public IActionResult Profile()
        {
            string? UserFirstName = HttpContext.Session.GetString(SessionFirst_UserName);
            string? UserSecondName = HttpContext.Session.GetString(SessionSecnod_UserName);
            string? UserEmail = HttpContext.Session.GetString(SessionUserEmail);
          

            ViewData["UserFirstName"] = UserFirstName;
            ViewData["UserSecondName"] = UserSecondName;
            ViewData["UserEmail"] = UserEmail;
            return View();
            //string name = HttpContext.Session.GetString("username");
            //string email = HttpContext.Session.GetString("email");
            //string password = HttpContext.Session.GetString("password");

            //ViewData["name"] = name;
            //ViewData["email"] = email;
            //ViewData["password"] = password;
            //return View();
        }
    }
}

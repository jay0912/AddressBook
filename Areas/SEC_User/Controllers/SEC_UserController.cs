using AddressBook_Multi.Areas.SEC_User.Models;
using AddressBook_Multi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddressBook_Multi.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[Controller]/[action]")]
    public class SEC_UserController : Controller
    {
        public IActionResult Index()
        {
            return View("login");
        }

        [HttpPost]

        public IActionResult Login(SEC_UserModel modelSEC_User)
        {

            string error = null;

            if (modelSEC_User.UserName == null)
            {
                error += "User Name is Required";
            }
            if (modelSEC_User.Password == null)
            {
                error += "<br/>Password is Required";
            }

            if (error != null)
            {   
                TempData["Error"] = error;
                RedirectToAction("login");
            }
            else
            {
                SEC_DAL dalSEC = new SEC_DAL();
                DataTable dt = dalSEC.PR_SEC_User_SelectByUserNamePassword(modelSEC_User.UserName, modelSEC_User.Password);
                if(dt.Rows.Count > 0)
                {

                    foreach(DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("CreationDate", dr["CreationDate"].ToString());
                        HttpContext.Session.SetString("ModificationDate", dr["ModificationDate"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is inviald!";
                    return RedirectToAction("login");
                }

                if(HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null )
                {
                    return RedirectToAction("Index", "Home");
                }



            }

            return RedirectToAction("login");
        } 

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "SEC_User");
        }

    }
}

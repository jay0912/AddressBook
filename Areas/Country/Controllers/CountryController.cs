using AddressBook_Multi.DAL;
using AddressBook_Multi.BAL;
using AddressBook_Multi.Areas.Country.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;



namespace AddressBook_Multi.Areas.Country.Controllers
{
    [CheckAccess]
    [Area("Country")]
    [Route("Country/[Controller]/[action]")]
    public class CountryController : Controller
    {

        
        public CountryController()
        {
            
        }

        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult Index()
        {
          
            DataTable dt = dalLOC.Country_SelectAll();
            return View("CountryList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            
            if (Convert.ToBoolean(dalLOC.Country_Delete(CountryID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CountryID)
        {

            #region Record Select by Pk
            if (CountryID != null)
            {
                
                
                CountryModel modelCountry = dalLOC.CountrySelectByPk( (int)CountryID);
                
                return View("CountryAddEdit", modelCountry);
                
                

            }
            #endregion
            return View("CountryAddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(CountryModel modelCountry)
        {


            
            if (ModelState.IsValid)
            {
                if (modelCountry.CountryID == null)
                {
                    if (Convert.ToBoolean(dalLOC.CountryInsert(modelCountry)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.CountryUpdate(modelCountry)))
                        return RedirectToAction("Index");
                }
            }
            //return View("StateAddEdit");
            return RedirectToAction("Add");
            //return RedirectToAction("Index");
        }
        #endregion

    }
}

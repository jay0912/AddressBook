using AddressBook_Multi.Areas.Country.Models;
using AddressBook_Multi.Areas.State.Models;
using AddressBook_Multi.DAL;
using AddressBook_Multi.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_Multi.Areas.State.Controllers
{
    [CheckAccess]
    [Area("State")]
    [Route("State/[Controller]/[action]")]
    public class StateController : Controller
    {
        

        public StateController()
        {
            
        }

        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.State_SelectAll();
            return View("StateList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StateID)
        {
            if (Convert.ToBoolean(dalLOC.State_Delete(StateID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? StateID)
        {

            #region DropDown

            StateModel modelState = new StateModel();

            DataTable dt1 = dalLOC.Country_SelectByDropdownList();

            List<CountryDropDown> countrydropdown = new List<CountryDropDown>();

            foreach (DataRow dr in dt1.Rows)
            {
                CountryDropDown dropdown = new CountryDropDown();
                dropdown.CountryID = Convert.ToInt32(dr["CountryID"]);
                dropdown.CountryName = dr["CountryName"].ToString();
                countrydropdown.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown;
            #endregion 


            #region Record Select by Pk
            if (StateID != null)
            {
                
                DataTable dt = dalLOC.State_SelectByPK(StateID);

                if (dt.Rows.Count > 0)
                {
                    StateModel model = new StateModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        model.StateID = Convert.ToInt32(dr["StateID"]);
                        model.StateName = dr["StateName"].ToString();
                        model.StateCode = dr["StateCode"].ToString();
                        //model.PhotoPath = dr["PhotoPath"].ToString();
                        model.CountryID = Convert.ToInt32(dr["CountryID"]);
                        modelState.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelState.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                    }
                    return View("StateAddEdit", model);
                }
                #endregion

            }
            return View("StateAddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(StateModel modelState)
        {

            //insert and update
            
            if (ModelState.IsValid)
            {
                if (modelState.StateID == null)
                {
                    if (Convert.ToBoolean(dalLOC.StateInsert(modelState)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.StateUpdate(modelState)))
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

using AddressBook_Multi.Areas.ContactCategory.Models;
using AddressBook_Multi.BAL;
using AddressBook_Multi.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_Multi.Areas.ContactCategory.Controllers
{
    [CheckAccess]
    [Area("ContactCategory")]
    [Route("ContactCategory/[Controller]/[action]")]
    public class ContactCategoryController : Controller
    {
        

        public ContactCategoryController()
        {
            
        }

        CON_DAL dalCON = new CON_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalCON.ContactCategory_SelectAll();
            return View("ContactCategoryList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CategoryID)
        {
            if (Convert.ToBoolean(dalCON.ContactCategory_Delete( CategoryID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CategoryID)
        {

            #region Record Select by Pk
            if (CategoryID != null)
            {
                DataTable dt = dalCON.ContactCategory_SelectByPK(CategoryID);

                if (dt.Rows.Count > 0)
                {
                    ContactCategoryModel modelContactCategory = new ContactCategoryModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        modelContactCategory.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        modelContactCategory.CategoryName = dr["CategoryName"].ToString();
                        modelContactCategory.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelContactCategory.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                    }
                    return View("ContactCategoryAddEdit", modelContactCategory);
                }
                #endregion

            }
            return View("ContactCategoryAddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(ContactCategoryModel modelContactCategory)
        {

            
            if (ModelState.IsValid)
            {
                if (modelContactCategory.CategoryID == null)
                {

                    if (Convert.ToBoolean(dalCON.ContactCategoryInsert( modelContactCategory)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalCON.ContactCategoryUpdate( modelContactCategory)))
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

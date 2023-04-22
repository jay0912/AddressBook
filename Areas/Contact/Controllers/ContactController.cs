using AddressBook_Multi.Areas.City.Models;
using AddressBook_Multi.Areas.Contact.Models;
using AddressBook_Multi.Areas.ContactCategory.Models;
using AddressBook_Multi.Areas.Country.Models;
using AddressBook_Multi.Areas.State.Models;
using AddressBook_Multi.BAL;
using AddressBook_Multi.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_Multi.Areas.Contact.Controllers
{
    [CheckAccess]
    [Area("Contact")]
    [Route("Contact/[Controller]/[action]")]
    public class ContactController : Controller
    {
        private IConfiguration Configuration;

        public ContactController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        CON_DAL dalCON = new CON_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalCON.Contact_SelectAll();
            return View("ContactList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ContactID)
        {
            if (Convert.ToBoolean(dalCON.Contact_Delete(ContactID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? ContactID)
        {
            ContactModel modelContact = new ContactModel();

            #region DropDown

            #region CategoryDD

            
            DataTable dt4 = dalCON.Category_SelectByDropdownList();

            List<ContactCategoryDropDown> contactcategorydropdown = new List<ContactCategoryDropDown>();

            foreach (DataRow dr in dt4.Rows)
            {
                ContactCategoryDropDown dropdown = new ContactCategoryDropDown();
                dropdown.CategoryID = (int)dr["CategoryID"];
                dropdown.CategoryName = (string)dr["CategoryName"];
                contactcategorydropdown.Add(dropdown);
            }
            ViewBag.ContactCategoryList = contactcategorydropdown;
            #endregion

            #region CityDD
            
            List<CityDropDown> citydropdown = new List<CityDropDown>();

            ViewBag.CityList = citydropdown;
            #endregion

            #region StateDD
           
            List<StateDropDown> statedropdown = new List<StateDropDown>();

            ViewBag.StateList = statedropdown;
            #endregion

            #region CountryDD
            DataTable dt1 = dalCON.Country_SelectByDropdownList();

            List<CountryDropDown> countrydropdown = new List<CountryDropDown>();

            foreach (DataRow dr in dt1.Rows)
            {
                CountryDropDown dropdown = new CountryDropDown();
                dropdown.CountryID = (int)dr["CountryID"];
                dropdown.CountryName = (string)dr["CountryName"];
                countrydropdown.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown;
            #endregion

            #endregion

            #region Record Select by Pk
            if (ContactID != null)
            {
                
                DataTable dt = dalCON.Contact_SelectByPK(ContactID);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        DropDownByCountry(Convert.ToInt32(dr["CountryID"]));
                        DropDownByState(Convert.ToInt32(dr["StateID"]));
                        modelContact.ContactID = Convert.ToInt32(dr["ContactID"]);
                        modelContact.Name = dr["Name"].ToString();
                        modelContact.Mobile = dr["Mobile"].ToString();
                        modelContact.Address = dr["Address"].ToString();
                        modelContact.Email = dr["Email"].ToString();
                        modelContact.PhotoPath = dr["PhotoPath"].ToString();
                        modelContact.CountryID = Convert.ToInt32(dr["CountryID"]);
                        modelContact.StateID = Convert.ToInt32(dr["StateID"]);
                        modelContact.CityID = Convert.ToInt32(dr["CityID"]);
                        modelContact.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        modelContact.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelContact.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                    }
                    return View("ContactAddEdit", modelContact);
                }
                #endregion

            }
            return View("ContactAddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(ContactModel modelContact)
        {

            if (modelContact.File != null)
            {
                string FilePath = "wwwroot\\photopath";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, modelContact.File.FileName);
                modelContact.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelContact.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelContact.File.CopyTo(stream);
                }
            }

            
            if (ModelState.IsValid)
            {
                if (modelContact.ContactID == null)
                {
                    if (Convert.ToBoolean(dalCON.ContactInsert( modelContact)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalCON.ContactUpdate( modelContact)))
                        return RedirectToAction("Index");
                }
            }
            //return View("StateAddEdit");
            return RedirectToAction("Add");
            //return RedirectToAction("Index");
        }
        #endregion

        #region DropDownByCountry
        public IActionResult DropDownByCountry(int? CountryID)
        {

            string str = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_State_SelectDropDownByCountryID";
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);
            conn.Close();

            List<StateDropDown> list = new List<StateDropDown>();

            foreach (DataRow dr in dt.Rows)
            {
                StateDropDown dropdown = new StateDropDown();
                dropdown.StateID = Convert.ToInt32(dr["StateID"]);
                dropdown.StateName = dr["StateName"].ToString();
                list.Add(dropdown);
            }
            ViewBag.StateList = list;
            var vModel = list;
            return Json(vModel);
        }
        #endregion

        #region DropDownByState
        public IActionResult DropDownByState(int? StateID)
        {
            string str = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_SelectDropDownByStateID";
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);
            conn.Close();

            List<CityDropDown> list = new List<CityDropDown>();

            foreach (DataRow dr in dt.Rows)
            {
                CityDropDown dropdown = new CityDropDown();
                dropdown.CityID = Convert.ToInt32(dr["CityID"]);
                dropdown.CityName = dr["CityName"].ToString();
                list.Add(dropdown);
            }
            ViewBag.CityList = list;
            var vModel = list;
            return Json(vModel);
        }
        #endregion

        #region Filter

        public IActionResult Filter(string CountryName, string StateName, string CityName)
        {
            string str = Configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_CON_Contact_Filter";
            if (CountryName == null)
                cmd.Parameters.AddWithValue("@CountryName", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
            if (StateName == null)
                cmd.Parameters.AddWithValue("@StateName", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@StateName", StateName);
            if (CityName == null)
                cmd.Parameters.AddWithValue("@CityName", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CityName", CityName);
            SqlDataReader SDR = cmd.ExecuteReader();
            dt.Load(SDR);
            conn.Close();
            return View("ContactList", dt);
        }

        #endregion



    }
}

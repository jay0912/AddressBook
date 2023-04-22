using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using AddressBook_Multi.Areas.Contact.Models;
using AddressBook_Multi.Areas.ContactCategory.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AddressBook_Multi.BAL;

namespace AddressBook_Multi.DAL
{
    public class CON_DALBase : DALHelper
    {

        #region ContactCategory

        #region ContactCategory_SelectAll
        public DataTable ContactCategory_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ContactCategory_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ContactCategory_Delete
        public bool? ContactCategory_Delete( int CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ContactCategory_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ContactCategory_Insert
        public bool? ContactCategoryInsert(ContactCategoryModel modelContactCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ContactCategory_Insert");

                sqlDB.AddInParameter(dbCMD, "CategoryName", SqlDbType.NVarChar, modelContactCategory.CategoryName);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd "));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd "));
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ContactCategory_Update
        public bool? ContactCategoryUpdate(ContactCategoryModel modelContactCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ContactCategory_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, modelContactCategory.CategoryID);
                sqlDB.AddInParameter(dbCMD, "CategoryName", SqlDbType.NVarChar, modelContactCategory.CategoryName);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd "));
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ContactCategory_SelectByPK
        public DataTable ContactCategory_SelectByPK( int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ContactCategory_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, CategoryID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion


        #region Contact

        #region Contact_SelectAll
        public DataTable Contact_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Contact_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Contact_Delete
        public bool? Contact_Delete( int ContactID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Contact_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "ContactID", SqlDbType.Int, ContactID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Contact_SelectByPK
        public DataTable Contact_SelectByPK( int? ContactID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Contact_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ContactID", SqlDbType.Int, ContactID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Contact_Insert
        public bool? ContactInsert( ContactModel modelContact)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Contact_Insert");

                sqlDB.AddInParameter(dbCMD, "Name", SqlDbType.NVarChar, modelContact.Name);
                sqlDB.AddInParameter(dbCMD, "Mobile", SqlDbType.NVarChar, modelContact.Mobile);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelContact.Address);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelContact.Email);
                sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.NVarChar, modelContact.PhotoPath);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelContact.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelContact.StateID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, modelContact.CityID);
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, modelContact.CategoryID);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd "));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Contact_Update
        public bool? ContactUpdate( ContactModel modelContact)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Contact_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "ContactID", SqlDbType.Int, modelContact.ContactID);
                sqlDB.AddInParameter(dbCMD, "Name", SqlDbType.NVarChar, modelContact.Name);
                sqlDB.AddInParameter(dbCMD, "Mobile", SqlDbType.NVarChar, modelContact.Mobile);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelContact.Address);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelContact.Email);
                sqlDB.AddInParameter(dbCMD, "PhotoPath", SqlDbType.NVarChar, modelContact.PhotoPath);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelContact.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelContact.StateID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, modelContact.CityID);
                sqlDB.AddInParameter(dbCMD, "CategoryID", SqlDbType.Int, modelContact.CategoryID);
                //sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd "));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Country_SelectbyDropdown
        public DataTable Country_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectForDropDown");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Category_SelectbyDropdown
        public DataTable Category_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ContactCategory_SelectForDropDown");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #endregion

    }
}

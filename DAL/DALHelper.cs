using System.Data;
using System.Reflection;

namespace AddressBook_Multi.DAL
{
    public class DALHelper
    {
        #region DataBase Connection String

        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");

        #endregion
    }
}

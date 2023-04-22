namespace AddressBook_Multi.BAL
{
    public class CV
    {
        private static IHttpContextAccessor _httpContextAccessor;


        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();   
        }

        public static string? UserName()
        {
            string? UserName = null;

            //if(_httpContextAccessor.HttpContext != null)
            //{
                if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
                {
                    UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
                }
           // }

            return UserName;
        }

        public static string? UserID()
        {
            string? UserID = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = _httpContextAccessor.HttpContext.Session.GetString("UserID").ToString();
            }

            return UserID;
        }

        //public static string? Password()
        //{
        //    string? Password = null;

        //    if (_httpContextAccessor.HttpContext.Session.GetString("Password") != null)
        //    {
        //        Password = _httpContextAccessor.HttpContext.Session.GetString("Password").ToString();
        //    }

        //    return Password;
        //}

    }
}

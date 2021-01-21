using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenWeb.PersonalClass
{
    public class Estructuras
    {
        public class _urls
        {
            public String urlBase { get; set; } = "http://201.236.221.195:8080/api/"; // http://192.200.101.17:8080/api/"; //"http://201.236.221.195:8080/api/";
            public String Auth_Login { get { return urlBase + "Account/Login"; } } //OK
            public String Auth_AccountCreate { get { return urlBase + "Account/create"; } }
            public String Auth_SentEmail { get { return urlBase + "sentemail"; } } //ok
            public String Auth_ForgotPass { get { return urlBase + "forgotPassword"; } } //ok
            public String Change_Pass { get { return urlBase + "changePassword"; } } //ok
            public String Menu_Permission { get { return urlBase + "permission"; } } //OK

            public String User_getUsers { get { return urlBase + "users/getUsers"; } } //OK
            public String User_UpdateState { get { return urlBase + "users/updateState"; } }
            public String User_getUsersbyUsername { get { return urlBase + "users/getUsersbyUsername"; } } //OK



        }

        public class _userLogueado
        {
            //public LoginRequest user { get; set; }
            //public List<MenuRequest> permissionuser { get; set; }
        }

    }
}

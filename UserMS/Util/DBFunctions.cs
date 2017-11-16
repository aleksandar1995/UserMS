using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using.System.Configuration;

namespace UserMS.Util
{
    public class DBFunctions
    {
        public static string ConnectionString 
        {
            get
            {
                return ConfigurationManager.ConnectionString["URIS_IIM_DBConnection"].ConnectionString;
            }
        }

    }
}
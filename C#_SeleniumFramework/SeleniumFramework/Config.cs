using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public class Config
    {
        public static string baseUrl = "https://projectplanappweb-stage.azurewebsites.net/";
        public static string browser = "chrome";
        public static int implicitWaitTime = 30;
        public static int explicitWaitTime = 15;
    }
}

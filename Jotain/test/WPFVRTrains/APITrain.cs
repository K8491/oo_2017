using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    class API
    {
        public static string GetJsonFromLiikenneVirasto(string filter)
        {
            try
            {
                string url = "";
                url = @"http://rata.digitraffic.fi/api/v1/live-trains?station=" + filter;
                using (WebClient wc = new WebClient()) //selaintoiminnot
                {
                    string json = wc.DownloadString(url); // lataa urlista stringin
                    return json;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

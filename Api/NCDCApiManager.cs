using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace NCDCLib.Api
{
    public class NCDCApiManager
    {
        //https://www.ncdc.noaa.gov/cdo-web/api/v2/locations?locationcategoryid=CITY&sortfield=name&limit=1000

        public string BaseUrl { get; set; } = @"https://www.ncdc.noaa.gov/cdo-web/api/v2";
        public string Token { get; set; }

        public NCDCApiManager(string token)
        {
            Token = token;
        }

        public async Task<string> GetStringAsync(string requestString)
        {
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("token", Token);
                return await client.GetStringAsync(requestString);
			}
        }
    }
}

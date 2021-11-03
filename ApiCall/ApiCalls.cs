using ApiManagers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiManagers.ApiCall
{
    public class ApiCalls
    {
        public HttpClient httpClient = new HttpClient();
        private readonly Uri uri;
        private readonly Uri uriPost;

        public ApiCalls()
        {
            uri = new Uri("https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers");
            uriPost = new Uri("https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/submit");
        }

        public async Task<List<Manager>> ReadData()
        {
            try
            {
                var response = await httpClient.GetAsync(uri);

                var data =  await response.Content.ReadAsStringAsync();

                return Deserialize(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> ReadAndProcessData()
        {
            List<Manager> mgrList= new List<Manager>();

            List<string> mgrListUpdated = new List<string>();

            try
            {
                mgrList = await ReadData();

                foreach(Manager manager in mgrList)
                {
                    if (!manager.Jurisdiction.All(Char.IsDigit))
                    {
                        mgrListUpdated.Add(manager.Jurisdiction + " - " + manager.LastName + " " + manager.firstName);
                    }
                    
                }

                mgrListUpdated.Sort();

                return mgrListUpdated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> PostData(SubmitRequest submitRequest)
        {
            try
            {
                var response = await httpClient.PostAsync(uriPost, new StringContent(Serialize(submitRequest), Encoding.UTF8, "application/json" ));

                var data = await response.Content.ReadAsStringAsync();

                string res = DeserializePost(data);

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Manager> Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<List<Manager>>(data);
        }

        public string DeserializePost(string data)
        {
            return Convert.ToString( JsonConvert.DeserializeObject(data));
        }

        public string Serialize(object jsondata)
        {
            return JsonConvert.SerializeObject(jsondata);
        }
    }
}

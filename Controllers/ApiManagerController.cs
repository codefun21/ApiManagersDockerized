using Microsoft.AspNetCore.Mvc;
using ApiManagers.ApiCall;
using System;
using System.Threading.Tasks;
using ApiManagers.Model;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ApiManagers.Controllers
{
    [ApiController]
    public class ApiManagerController : ControllerBase
    {
        private ApiCalls apiCall;
        
        public ApiManagerController()
        {
            apiCall = new ApiCalls();   
        }

        [HttpGet]
        [Route ("api/supervisors")]
        public async Task<List<string>> Get()
        {
            List<string> error = new List<string>();

            try
            {
                if (ModelState.IsValid)
                {
                   var response = await apiCall.ReadAndProcessData();

                    foreach(string res in response)
                    {
                        Debug.WriteLine(res);
                    }
                    
                    return response;

                }
                else
                {
                    error.Add("Error Occured. Please try again");
                    return error;
                }
            }
            catch
            {
                error.Add("Error Occured. Please try again");
                return error;
            }
        }

        [HttpPost]
        [Route("api/submit")]
        public async Task<string> Post(SubmitRequest submitRequest)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                    var response = await apiCall.PostData(submitRequest);

                    string obj = Convert.ToString(response);

                    Debug.WriteLine(JsonConvert.SerializeObject(submitRequest));
                      Debug.WriteLine(obj);
                    // Console.WriteLine(submitRequest);
                    // Console.WriteLine(obj);

                    return obj;
                }
                else
                {
                    return "Error Occured. Please try again";
                }
            }
            catch
            {
                return "Error Occured. Please try again";
            }
        }
    }
}

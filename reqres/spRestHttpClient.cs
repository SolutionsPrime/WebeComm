using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Newtonsoft.Json;

namespace reqres
{
    public enum httpClientVerbs
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE
    }

    public class spRestHttpClient
    {
        HttpClient restHttpClient { get; set; }
        public string baseAddress { get; set; }
        public string partAddress { get; set; }
        public httpClientVerbs httpClientMethod { get; set; }
        public string resObjStr { get; set; }
        public string resStatusCode { get; set; }
        public object postObject { get; set; }

        public spRestHttpClient()
        {
            
        }

        #region public methods
        public void runAsyncGet()
        {
            getRequest().Wait();
        }
        public void runAsyncPost()
        {
            postRequest().Wait();
        }
        public void runAsyncPut()
        {
            putRequest().Wait();
        }
        public void runAsyncDelete()
        {
            deleteRequest().Wait();
        }
        #endregion

        #region private methods
        private async Task getRequest()
        {           
            if(baseAddress == "")
            {
                throw new Exception("Base address is not Set");
            }
            if(partAddress == "")
            {
                throw new Exception("part address is not Set");
            }

            if (httpClientMethod.ToString().Equals("GET"))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("Requested Method is = "+ httpClientMethod.ToString() + "and it is for GET");
                    HttpResponseMessage response = await httpClient.GetAsync(partAddress);
                    object obj = new object();
                    if (response.IsSuccessStatusCode)
                    {
                        obj = await response.Content.ReadAsAsync<dynamic>();
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = obj.ToString();
                    }
                    else
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = obj.ToString();
                        throw new Exception("IsSuccessStatusCode failed " + response.ToString());
                    }
                }
            }
            else
            {
                throw new Exception("This is for Get Method. Use Get method to resolve this exception");
            }
            
        }

        private async Task postRequest()
        {
            if (baseAddress == "")
            {
                throw new Exception("Base address is not Set");
            }
            if (partAddress == "")
            {
                throw new Exception("part address is not Set");
            }

            if (httpClientMethod.ToString().Equals("POST"))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("Requested Method is = " + httpClientMethod.ToString() + "and it is for POST");
                    HttpResponseMessage response;
                    response = await httpClient.PostAsJsonAsync(partAddress, postObject);
                    if (response.IsSuccessStatusCode)
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = response.ToString();                        
                    }
                    else
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = response.ToString();
                        throw new Exception("IsSuccessStatusCode failed " + response.ToString());
                    }                    
                }
            }
            else
            {
                throw new Exception("This is for POST method. Use Post method to resolve this exception");
            }
        }

        private async Task putRequest()
        {
            if (baseAddress == "")
            {
                throw new Exception("Base address is not Set");
            }
            if (partAddress == "")
            {
                throw new Exception("part address is not Set");
            }

            if (httpClientMethod.ToString().Equals("PUT"))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("Requested Method is = " + httpClientMethod.ToString() + "and it is for PUT");
                    HttpResponseMessage response;
                    response = await httpClient.PutAsJsonAsync(partAddress, postObject);
                    if (response.IsSuccessStatusCode)
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = response.ToString();
                    }
                    else
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = response.ToString();
                        throw new Exception("IsSuccessStatusCode failed " + response.ToString());
                    }
                }
            }
            else
            {
                throw new Exception("This is for PUT method. Use PUT method to resolve this exception");
            }
        }

        private async Task deleteRequest()
        {
            if (baseAddress == "")
            {
                throw new Exception("Base address is not Set");
            }
            if (partAddress == "")
            {
                throw new Exception("part address is not Set");
            }

            if (httpClientMethod.ToString().Equals("DELETE"))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseAddress);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("Requested Method is = " + httpClientMethod.ToString() + "and it is for DELETE");
                    HttpResponseMessage response;
                    response = await httpClient.DeleteAsync(partAddress);                    
                    if (response.IsSuccessStatusCode)
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = response.ToString();
                    }
                    else
                    {
                        resStatusCode = response.StatusCode.ToString();
                        resObjStr = response.ToString();
                        throw new Exception("IsSuccessStatusCode failed " + response.ToString());
                    }
                }
            }
            else
            {
                throw new Exception("This is for DELETE method. Use DELETE method to resolve this exception");
            }
        }

        #endregion
    }
}

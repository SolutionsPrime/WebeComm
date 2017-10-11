using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;

namespace reqres
{
    public enum httpVerbs
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE
    }
    public class spRestClient
    {
        public string endPoint { get; set; }
        public httpVerbs httpMethod { get; set; }

        public spRestClient()
        {
                     
        }
        public spRestClient(string pEndPoint, httpVerbs phttpMethod)
        {
            endPoint = pEndPoint;
            httpMethod = phttpMethod;
        }
        public spRestClient(string pEndPoint, httpVerbs phttpMethod, string jsonContent)
        {
            endPoint = pEndPoint;
            httpMethod = phttpMethod;
        }

        public string makeRequest()
        {
            try
            {
                if (endPoint == "" || endPoint == null)
                {
                    System.Console.WriteLine("No URL or endpint provided");
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception("No URL or endpint provided");
            }


            string strResponseValue = string.Empty;

           

            switch (httpMethod.ToString())
            {
                case "GET":
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(endPoint);
                    req.Method = httpMethod.ToString();
                    using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                    {
                        if (res.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception("Error Code = " + res.StatusCode);
                        }

                        using (Stream resStream = res.GetResponseStream())
                        {
                            if (resStream != null)
                            {
                                using (StreamReader reader = new StreamReader(resStream))
                                {
                                    strResponseValue = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    break;
                case "POST":
                   
                        break;
                case "PUT":
                    break;
                case "PATCH":
                    break;
                default:
                    break;
            }       

            return strResponseValue;
        }
    }
}

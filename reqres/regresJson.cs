using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace reqres
{
    
    [TestClass]
    public class regresJson
    {
        public regresJson(){}
        public bool testResult { get; set; }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        #region get requests
        //[TestMethod]
        //public void getUserList()
        //{
        //    spRestClient sRC = new spRestClient("https://reqres.in/api/users", httpVerbs.GET);
        //    string jStr = (sRC.makeRequest());
        //    var jUserlist = JsonConvert.DeserializeObject<UsersList>(jStr);
        //    Console.WriteLine(jUserlist.data[0].avatar.ToString());
        //    Console.WriteLine(jStr);            
        //}

        [TestMethod]
        public void TC_UserPage2()
        {
            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "users?page=2";
            sphc.httpClientMethod = httpClientVerbs.GET;
            sphc.resObjStr = "";
            sphc.runAsyncGet();
            
            //Console.WriteLine(sphc.resObjStr);
            UsersList juserlist = JsonConvert.DeserializeObject<UsersList>(sphc.resObjStr);

            UsersList expectedUserList = new UsersList();
            expectedUserList.page = 2;
            expectedUserList.per_page = 3;
            expectedUserList.total = 12;
            expectedUserList.total_pages = 4;

            UserDetails expectedUserDetails = new UserDetails();
            expectedUserDetails.first_name = "Eve";
            expectedUserDetails.last_name = "Holt";
            expectedUserDetails.avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/marcoramires/128.jpg";
            expectedUserDetails.id = 2;

            
            
            try
            {
                Assert.AreEqual(juserlist.data[0].avatar, expectedUserDetails.avatar);
                testResult = true;
                Console.WriteLine("");
                Console.WriteLine("test passed for step 1");
                Console.WriteLine("avatar = Expected Value = " + expectedUserDetails.avatar + " & Actual Value  = " + juserlist.data[0].avatar);
                Console.WriteLine("");
            }
            catch
            {
                testResult = false;
                Console.WriteLine("");
                Console.WriteLine("test Failed for step 1");
                Console.WriteLine("avatar = Expected Value = " + expectedUserDetails.avatar + " & Actual Value  = " + juserlist.data[0].avatar);
                Console.WriteLine("");
            }
            try
            {
                Assert.AreEqual(juserlist.page.ToString(),expectedUserList.page.ToString());
                testResult = true;
                Console.WriteLine("");
                Console.WriteLine("Page = Expected Value = " + expectedUserList.page.ToString() + " & Actual Value  = " + juserlist.page.ToString());
                Console.WriteLine("test passed for step 2");
                Console.WriteLine("");
            }
            catch
            {
                testResult = false;
                Console.WriteLine("");
                Console.WriteLine("Page = Expected Value = " + expectedUserList.page.ToString() + " & Actual Value  = " + juserlist.page.ToString());
                Console.WriteLine("test Failed for step 2");
                Console.WriteLine("");
            }

            if(!testResult)
            {
                throw new AssertFailedException();
            }
        }

        [TestMethod]
        public void TC_User2()
        {
            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "users/2";            
            sphc.httpClientMethod = httpClientVerbs.GET;
            sphc.resObjStr = "";
            sphc.runAsyncGet();

            //Console.WriteLine(sphc.resObjStr);

            UserRecord ur = JsonConvert.DeserializeObject<UserRecord>(sphc.resObjStr);
            // Console.WriteLine(ur.data.last_name);
           
            UserDetails expectedUserDetails = new UserDetails();
            expectedUserDetails.first_name = "Janet";
            expectedUserDetails.last_name = "Weaver";
            expectedUserDetails.avatar = "https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg";
            expectedUserDetails.id = 2;

            try
            {
                Assert.AreEqual(ur.data.avatar, expectedUserDetails.avatar);
                testResult = true;
                Console.WriteLine("");
                Console.WriteLine("test passed for step 1");
                Console.WriteLine("avatar = Expected Value = " + expectedUserDetails.avatar + " & Actual Value  = " + ur.data.avatar);
                Console.WriteLine("");
            }
            catch
            {
                testResult = false;
                Console.WriteLine("");
                Console.WriteLine("test Failed for step 1");
                Console.WriteLine("avatar = Expected Value = " + expectedUserDetails.avatar + " & Actual Value  = " + ur.data.avatar);
                Console.WriteLine("");
            }
            try
            {
                Assert.AreEqual(ur.data.first_name.ToString(), expectedUserDetails.first_name.ToString());
                testResult = true;
                Console.WriteLine("");
                Console.WriteLine("Page = Expected Value = " + expectedUserDetails.first_name.ToString() + " & Actual Value  = " + ur.data.first_name.ToString());
                Console.WriteLine("test passed for step 2");
                Console.WriteLine("");
            }
            catch
            {
                testResult = false;
                Console.WriteLine("");
                Console.WriteLine("Page = Expected Value = " + expectedUserDetails.first_name.ToString() + " & Actual Value  = " + ur.data.first_name.ToString());
                Console.WriteLine("test Failed for step 2");
                Console.WriteLine("");
            }

            if (!testResult)
            {
                throw new AssertFailedException();
            }
        }

        [TestMethod]
        public void TC_UserNotFound()
        {
            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "users/23";
            sphc.httpClientMethod = httpClientVerbs.GET;
            sphc.resObjStr = "";
            try
            {
                sphc.runAsyncGet();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (sphc.resStatusCode == "NotFound")
            {
                Console.WriteLine("TC_UserNotFound test case result = passed");
            }      
            else
            {
                Console.WriteLine("TC_UserNotFound test case result = Failed");
                throw new AssertFailedException();
            }
        }
        #endregion

        #region post requests
        [TestMethod]
        public void postRegisterDetails()
        {
            RegisterDetails uRD = new RegisterDetails();
            uRD.email = "abi@abi";
            uRD.password = "justfun";

            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "register";
            sphc.httpClientMethod = httpClientVerbs.POST;
            sphc.resObjStr = "";
            sphc.postObject = uRD;
            try
            {
                sphc.runAsyncPost();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (sphc.resStatusCode == "Created")
            {
                Console.WriteLine("RegisterDetails Test Passed");
            }
            else
            {
                throw new Exception("RegisterDetails Test Failed");
            }
            

        }

        [TestMethod]
        public void postRegisterDetailsFail()
        {
            RegisterDetails uRD = new RegisterDetails();
            uRD.email = "abi@abi";            

            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "register";
            sphc.httpClientMethod = httpClientVerbs.POST;
            sphc.resObjStr = "";
            sphc.postObject = uRD;
            try
            {
                sphc.runAsyncPost();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (sphc.resStatusCode == "BadRequest")
            {
                Console.WriteLine("RegisterDetailsFail Test Passed");
            }
            else
            {
                throw new Exception("RegisterDetailsFail Test Failed");
            }


        }

        [TestMethod]
        public void postLoginDetails()
        {
            RegisterDetails uRD = new RegisterDetails();
            uRD.email = "abi@abi";
            uRD.password = "justfun09";

            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "login";
            sphc.httpClientMethod = httpClientVerbs.POST;
            sphc.resObjStr = "";
            sphc.postObject = uRD;
            try
            {
                sphc.runAsyncPost();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (sphc.resStatusCode == "OK")
            {
                Console.WriteLine("LoginDetails Test Passed");
                Console.Write(sphc.resObjStr.ToString());
            }
            else
            {
                Console.Write(sphc.resObjStr.ToString());
                throw new Exception("LoginDetails Test Failed");
            }


        }

        #endregion


        #region put and delete methods
        [TestMethod]
        public void putJobDetails()
        {
            JobDetails jd = new JobDetails();
            jd.name = "Neo";
            jd.job = "Matrix Zoin Hero";

            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "users/2";
            sphc.httpClientMethod = httpClientVerbs.PUT;
            sphc.resObjStr = "";
            sphc.postObject = jd;
            try
            {
                sphc.runAsyncPut();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (sphc.resStatusCode == "OK")
            {
                Console.WriteLine("JobDetails Test Passed");
                Console.Write(sphc.resObjStr.ToString());
            }
            else
            {
                Console.Write(sphc.resObjStr.ToString());
                throw new Exception("JobDetails Test Failed");
            }


        }

        [TestMethod]
        public void deleteUser()
        {   
            spRestHttpClient sphc = new spRestHttpClient();
            sphc.baseAddress = "https://reqres.in/api/";
            sphc.partAddress = "users/2";
            sphc.httpClientMethod = httpClientVerbs.DELETE;
            sphc.resObjStr = "";            
            try
            {
                sphc.runAsyncDelete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (sphc.resStatusCode == "NoContent")
            {
                Console.WriteLine("deleteUser Test Passed");
                Console.Write(sphc.resObjStr.ToString());
            }
            else
            {
                Console.Write(sphc.resObjStr.ToString());
                throw new Exception("deleteUser Test Failed");
            }


        }

        #endregion
    }
}

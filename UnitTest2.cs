// https://www.youtube.com/playlist?list=PLlsKgYi2Lw73ox9LF5VfYMrA1eo9e7rIq 

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp_MSTest.Model;

namespace RestSharp_MSTest
{
    
    [TestClass]
    public class UnitTest2
    {
        private string getUrl = "http://localhost:3000/posts/1";
        [TestMethod]
        public void TestGetUsingRestSharp()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("Accept","application/json");
            IRestResponse restResponse = restClient.Get(restRequest);
            Console.WriteLine("Rest Response : " + restResponse);
            Console.WriteLine("Is Successfull : " + restResponse.IsSuccessful);
            Console.WriteLine("Status Code : " + restResponse.StatusCode);
            Console.WriteLine("Status Int Code : " + (int)restResponse.StatusCode);
            Console.WriteLine("Response  Status : " + restResponse.ResponseStatus);
            Console.WriteLine("Error message : " + restResponse.ErrorMessage);
            Console.WriteLine("Error exception : " + restResponse.ErrorException);
            
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Content : " + restClient.Get(restRequest).Content);
            }
            else
            {
                Console.WriteLine("Response failed");
            }
        }

        [TestMethod]
        public void TestGetwithJSON_Deserialize()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse <List<Posts>> restResponse = restClient.Get<List<Posts>>(restRequest);
           
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Size of list : " + restResponse.Data.Count);
                Console.WriteLine("Data : " + restResponse.Data);
                Console.WriteLine("Content : " + restResponse.Content);
            }
            else
            {
                Console.WriteLine("Response failed");
                Console.WriteLine("Error message : " + restResponse.ErrorMessage);
                Console.WriteLine("Error exception : " + restResponse.ErrorException);
            }

        }
    }
}

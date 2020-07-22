using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp_MSTest.Model;

namespace RestSharp_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RestGet()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            Console.WriteLine("Request: " + request);

            var content = client.Execute(request).Content;
            Console.WriteLine("Content: " + content);

            var response = client.Execute(request);
            Console.WriteLine("Response: " + response.Content);

            var deserializer = new JsonDeserializer();
            var output  = deserializer.Deserialize<Dictionary<string, string>>(response);
            Console.WriteLine("Output: " + output);

            var result = output["author"];
            Console.WriteLine("Author: " + result);
            Assert.AreEqual("George BB",result);
        }

        [TestMethod]
        public void RestPost()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}/profile", Method.POST);
           // request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new { name = "raj"});

            request.AddUrlSegment("postid", 1);
            var response = client.Execute(request);
            //Console.WriteLine("Response: " + response.Content);

            var deserializer = new JsonDeserializer();
            var output = deserializer.Deserialize<Dictionary<string, string>>(response);
            //Console.WriteLine("Output: " + output);
            var result = output["name"];
            Assert.AreEqual("raj", result);

        }

        [TestMethod]
        public void PostWithtypeClass()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts", Method.POST);

            request.AddJsonBody(new Posts() { id = "13", author = "aj", title = "ajtitle" });

            var response = client.Execute(request);

            var deserializer = new JsonDeserializer();
            var output = deserializer.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];
            Assert.AreEqual("aj", result);
        }
    }
}

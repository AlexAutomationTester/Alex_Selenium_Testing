using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace Inspired_Automation_Testing_Task1
{
    [TestClass]
    public class Endpoint_Testing
    {
        string url = "https://jsonplaceholder.typicode.com/users";

        [Priority(1)]
        [TestMethod]
        public void TestMethod1_POST()
        {
            string jsonData = "{\"userid\":\"1001\",\"body\":\"This is a POST Request\",\"title\":\"Alexandros Kritikopoulos\"}";

            IRestClient restClient = new RestClient();
            IRestRequest request = new RestRequest()
            {
                Resource = url
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonData);
            IRestResponse response = restClient.Post(request);
            Assert.AreEqual(201, (int)response.StatusCode);
            Console.WriteLine(response.Content);
        }

        [Priority(2)]
        [TestMethod]
        public void TestMethod2_GET()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(url);
            restRequest.AddParameter("id", "1");
            IRestResponse restResponse = restClient.Get(restRequest);
            Assert.IsTrue(restResponse.StatusCode.Equals(HttpStatusCode.OK));

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code " + restResponse.StatusCode);
                Console.WriteLine("Response Content " + restResponse.Content);
            }
        }

        [Priority(3)]
        [TestMethod]
        public void TestMethod3_GET_10()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(url);
            string[] id = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            foreach (string i in id)
            {
                restRequest.AddParameter("id", i);
            }
            IRestResponse restResponse = restClient.Get(restRequest);
            Assert.IsTrue(restResponse.StatusCode.Equals(HttpStatusCode.OK));

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code " + restResponse.StatusCode);
                Console.WriteLine("Response Content " + restResponse.Content);
            }
        }

        //Using Json and Response Count to validate that only 1 user is returned
        [Priority(4)]
        [TestMethod]
        public void TestMethod2_GET_Json()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(url);
            restRequest.AddParameter("id", "1");
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<JsonContent>> restResponse = restClient.Get<List<JsonContent>>(restRequest);
            Assert.IsTrue(restResponse.StatusCode.Equals(HttpStatusCode.OK));

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code " + restResponse.StatusCode);
                Console.WriteLine("Response Count " + restResponse.Data.Count);
                Console.WriteLine("Response Content " + restResponse.Content);
            }
        }

        //Using Json and Response Count to Validate that 10 users are returned
        [Priority(5)]
        [TestMethod]
        public void TestMethod3_GET10_Json()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(url);
            restRequest.AddParameter("id", "1");
            restRequest.AddParameter("id", "2");
            restRequest.AddParameter("id", "3");
            restRequest.AddParameter("id", "4");
            restRequest.AddParameter("id", "5");
            restRequest.AddParameter("id", "6");
            restRequest.AddParameter("id", "7");
            restRequest.AddParameter("id", "8");
            restRequest.AddParameter("id", "9");
            restRequest.AddParameter("id", "10");
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<JsonContent>> restResponse = restClient.Get<List<JsonContent>>(restRequest);
            Assert.IsTrue(restResponse.StatusCode.Equals(HttpStatusCode.OK));

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code " + restResponse.StatusCode);
                Console.WriteLine("Response Count " + restResponse.Data.Count);
                Console.WriteLine("Response Content " + restResponse.Content);
            }
        }
    }
}

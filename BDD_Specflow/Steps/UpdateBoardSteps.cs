using _01ProjectStructure.Consts;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using System.Text.Json.Nodes;

namespace _111ProjectStructure.Steps
{
    [Binding]
    public class UpdateBoardSteps
    {
        private static IRestClient _client = new RestClient("https://api.trello.com");
        private RestRequest request;
        private RestResponse response;
        private RestRequest RequestWithAuth() =>
            RequestWithoutAuth().AddOrUpdateParameters(UrlParamValues.AuthQueryParams);
        private RestRequest RequestWithoutAuth() =>
            new RestRequest();

        [Given("name to be changed to {}")]
        public void GivenNameToBeChangedTo(string newName)
        {
            var updatedName = newName + DateTime.Now.ToLongTimeString();
        }

        [Given("request with auth")]
        public void GivenRequestWithAuth()
        {
            request = RequestWithAuth();
        }

        [Given("query params")]
        public void GivenQueryParamsWithNameAndValue(Table table)
        {
            foreach (var row in table.Rows)
            {
                request.AddUrlSegment(row[0], row[1]);
            }
            
        }

        [Given("JSON body")]
        public void GivenJSONBody(Table table)
        {
            Dictionary<string, string> jsonBody = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                jsonBody.Add(row[0], row[1]);
            }
            request.AddJsonBody(jsonBody);
        }

        [When("request is sent to UpdateBoard Endpoint")]
        public void WhenRequestIsSentToUpdateBoardEndpoint()
        {
            request.Method = Method.Put;
            request.Resource = BoardsEndpoints.UpdateBoardUrl;
            response = _client.ExecuteAsync(request).Result;
        }

        [Then("response status code is {}")]
        public void ThenResponseStatusCodeIsOK(HttpStatusCode expected)
        {
            Assert.AreEqual(expected, response.StatusCode);
        }

        [Then("received param {} is {}")]
        public void ThenReceivedParamIs(string paramName, string paramValue)
        {
            var responseContent = JToken.Parse(response.Content);
            Assert.AreEqual(paramValue, responseContent.SelectToken(paramName).ToString());
        }

        [Then("GetBoard endpoint returns {} for param {} for identification {} with value {}")]
        public void ThenGetBoardEndpointReturnsForParamForIdentificationWithValue(string paramValue, string paramName, string id, string idValue)
        {
            request = RequestWithAuth();
            request.Method = Method.Get;
            request.Resource = BoardsEndpoints.GetBoardUrl;
            request.AddUrlSegment(id, idValue);
            response = _client.ExecuteAsync(request).Result;
            var responseContent = JToken.Parse(response.Content);
            Assert.AreEqual(paramValue, responseContent.SelectToken(paramName).ToString());
        }


    }
}

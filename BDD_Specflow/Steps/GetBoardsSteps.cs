using _01ProjectStructure.Consts;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;
using System.Net;
using TechTalk.SpecFlow;

namespace _111ProjectStructure.Steps
{

    [Binding]
    public class GetBoardsSteps
    {
        private static IRestClient _client = new RestClient("https://api.trello.com");

        private RestRequest request;
        private RestResponse response;

        private RestRequest RequestWithAuth() =>
            RequestWithoutAuth().AddOrUpdateParameters(UrlParamValues.AuthQueryParams);

        private RestRequest RequestWithoutAuth() =>
            new RestRequest();


        [Given("a request with authorisation")]
        public void GivenARequestWithAuthorisation()
        {
            request = RequestWithAuth();
        }

        [Given("the request has query params")]
        public void GivenTheRequestHasQueryParams()
        {
           request.AddQueryParameter("fields", "id,name");
        }

        [Given("the request has {} path param with value {}")]
        public void GivenTheRequestHasPathParam(string paramName,string paramValue)
        {
            request.AddUrlSegment(paramName, paramValue);
        }


        [When("request is sent")]
        public void WhenRequestIsSent()
        {
            request.Method = Method.Get;
            request.Resource = BoardsEndpoints.GetAllBoardsUrl;
            response = _client.ExecuteAsync(request).Result;
            //Console.WriteLine(response.Content);
        }

        [When("the request is sent to the GetBoard API")]
        public void WhenRequestIsSentToGetBoard()
        {
            request.Method = Method.Get;
            request.Resource = BoardsEndpoints.GetBoardUrl;
            response = _client.ExecuteAsync(request).Result;
            //Console.WriteLine(response.Content);
        }

        [Then("receieve html status {}")]
        public void ThenReceieveHtmlStatus200(HttpStatusCode expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
        }

        [Then("receive valid json file with {} schema")]
        public void ThenReceiveValidJsonFileWithGetboardsSchema(string paramSchema)
        {
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/"+paramSchema));
            Assert.True(responseContent.IsValid(jsonSchema));
        }


        [Then("check if the response {} is equal to {}")]
        public void CheckIfNameNewBoard(string paramName , string paramValue)
        {
            var responseContent = JToken.Parse(response.Content);
            Assert.AreEqual(paramValue, responseContent.SelectToken(paramName).ToString());
        }
    }
}

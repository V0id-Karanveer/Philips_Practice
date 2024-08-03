using _01ProjectStructure.Consts;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace _111ProjectStructure.Steps
{
    [Binding]
    public class GetBoardValidationSteps
    {
        private static IRestClient _client = new RestClient("https://api.trello.com");
        private RestRequest request;
        private RestResponse response;
        private RestRequest RequestWithAuth() =>
            RequestWithoutAuth().AddOrUpdateParameters(UrlParamValues.AuthQueryParams);
        private RestRequest RequestWithoutAuth() =>
            new RestRequest();

        [Given("request with authorization")]
        public void GivenARequestWithAuth()
        {
            request = RequestWithAuth();
        }

        [Given("a request without authorization")]
        public void GivenARequestWithoutAuth()
        {
            request = RequestWithoutAuth();
        }

        [Given("url segment:")]
        public void URLSegment(Table table)
        {
            foreach (var row in table.Rows)
            {
                request.AddUrlSegment(row[0], row[1]);
            }
        }

        [Given("query params:")]
        public void GivenQueryParams(Table table)
        {
            foreach (var row in table.Rows)
            {
                request.AddOrUpdateParameter(row[0], row[1]);
            }
        }

        [When("a '{}' request is sent to {} endpoint")]
        public void WhenRequestIsSent(Method method, string endpoint)
        {
            request.Method = method;
            request.Resource = endpoint;
            response = _client.ExecuteAsync(request).Result;
        }

        [Then("status code is {}")]
        public void ThenStatusCodeIs(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, response.StatusCode);
        }

        [Then("response has error message {}")]
        public void ResponseHasErrorMessage(string message)
        {
            Assert.AreEqual(message, response.Content);
        }
    }
}

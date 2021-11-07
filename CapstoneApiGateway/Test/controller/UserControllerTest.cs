using GymUserApi;
using GymUserApi.Model;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.controller
{
    [Collection("Auth API")]
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class UserControllerTest
    {
        private readonly HttpClient _client;
        public UserControllerTest(AuthWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        #region positivetests
        [Fact, TestPriority(1)]
        public async Task RegisterUserShouldSuccess()
        {
            User user = new User { UserName = "Mgkelly", Password = "Mgkelly@123", Role="Admin" };

            HttpRequestMessage request = new HttpRequestMessage();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            // The endpoint or route of the controller action.
            var httpResponse = await _client.PostAsync<User>("/api/User/register", user, formatter);

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<bool>(stringResponse);
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.True(response);
        }
        #endregion positivetests
        #region negativetests
        [Fact, TestPriority(2)]
        public async Task RegisterUserShouldFail()
        {
            User user = new User { UserName = "Mgkelly", Password = "Mgkelly@123", Role = "Admin" };

            HttpRequestMessage request = new HttpRequestMessage();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            // The endpoint or route of the controller action.
            var httpResponse = await _client.PostAsync<User>("/api/User/register", user, formatter);

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<string>(stringResponse);
            Assert.Equal(HttpStatusCode.Conflict, httpResponse.StatusCode);
        }
        #endregion neagtivetests
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.controller
{
    [Collection("Auth API")]
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    class ProgramsControllerTest: IClassFixture<ProgramsWebApplicationFactory<FitnessPrograms.Startup>>
    {
        private readonly HttpClient _client, _authclient;
        //public ProgramsControllerTest(ProgramsWebApplicationFactory<FitnessPrograms.Startup> factory, AuthWebApplicationFactory<AuthenticationService.Startup> authFactory)
        //{
        //    //calling Auth API to get JWT
        //    User user = new User { UserId = "Mukesh", Password = "admin123" };
        //    _authclient = authFactory.CreateClient();
        //    HttpRequestMessage request = new HttpRequestMessage();
        //    MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

        //    // The endpoint or route of the controller action.
        //    var httpResponse = _authclient.PostAsync<User>("/api/auth/login", user, formatter);
        //    httpResponse.Wait();
        //    // Deserialize and examine results.
        //    var stringResponse = httpResponse.Result.Content.ReadAsStringAsync();
        //    var response = JsonConvert.DeserializeObject<TokenModel>(stringResponse.Result);

        //    _client = factory.CreateClient();
        //    //Attaching token in request header
        //    _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {response.Token}");
        //}
    }
}

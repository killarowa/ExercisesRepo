//Lection: Selenium basics, time:3:28:01
using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestGitHubApi
{
    public class GitHubTests_Tests
    {

        private RestClient client;
        private RestRequest request;


        [SetUp]
        public void Setup()
        {
            this.client = new RestClient("https://api.github.com");
            string url = "/repos/kamkom84/Nunit-Summator-Solution/issues";

            this.request = new RestRequest(url);
        }

        [Test]
        public async Task Test_Get_Issue()
        {
            var responce = await client.ExecuteAsync(request);

            var issues = JsonSerializer.Deserialize<List<Issue>>(responce.Content);

            foreach(var issue in issues)
            {
                Assert.IsNotNull(issue.html_url);
                Assert.IsNull(issue.id, "Issue id must not be null");
            }


            Assert.IsNotNull(responce.Content);
            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
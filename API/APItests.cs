using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static System.Configuration.ConfigurationManager;


namespace API
{
    [TestFixture]
    class ApiTests
    {
        private readonly int statusSuccess = 200;
        private readonly int statusCreated = 201;
        private readonly string fileProjectTemplate = "newProjectTemplate.xml";
        HttpClient client;

        [OneTimeSetUp]
        public void InitTest()
        {
            client = new HttpClient();
        }

        public string GetResponseText(Task<HttpResponseMessage> message)
        {
            return message.Result.Content.ReadAsStringAsync().Result;
        }

        public int GetStatusCode(Task<HttpResponseMessage> message)
        {
            return (int)message.Result.StatusCode;
        }

        [Test]
        public void LoginTest()
        {
            var response = client.GetAsync(
                         new Uri($"{AppSettings["url"]}{AppSettings["account"]}?key={AppSettings["key"]}"));
            Console.WriteLine($"{GetStatusCode(response)}\n{GetResponseText(response)}");
            Assert.AreEqual(statusSuccess, GetStatusCode(response));
        }
        [Test]
        public void AddProjTest()
        {
            string template = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}{fileProjectTemplate}");
            string projectName = "prj".GetRandomString(5);
            string identifier = "id".GetRandomString(5);
            string xmlText = string.Format(template, projectName, identifier);
            var content = new StringContent(xmlText, Encoding.UTF8, "application/xml");
            var response = client.PostAsync($"{AppSettings["projectUrl"]}.xml?key={AppSettings["key"]}", content);
            Console.WriteLine($"{projectName}\n{identifier}\n" +
                              $"{GetStatusCode(response)}\n{GetResponseText(response)}");
            Assert.AreEqual(statusCreated, GetStatusCode(response));
        }

        [Test]
        public void GetIssues()
        {
            var response= client.GetAsync(
                new Uri($"{AppSettings["issueUrl"]}.xml?key={AppSettings["key"]}&limit=100"));

            Console.WriteLine($"{GetStatusCode(response)}\n{GetResponseText(response)}");
            Assert.AreEqual(statusSuccess, GetStatusCode(response));
        }
    }
}

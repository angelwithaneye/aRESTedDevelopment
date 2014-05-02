using System;
using System.IO;
using System.Linq;
using ArestedDevelopment.IO;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;
using NUnit.Framework;
using RestSharp;

namespace ArestedDevelopment.Tests
{
    [TestFixture]
    public class TestIO
    {
        [Test]
        public void TestSoemthing()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var type = typeof(IInterpreter);
            var asms = AppDomain.CurrentDomain.GetAssemblies().Where((assembly => assembly.GetTypes().Any(type.IsAssignableFrom)));

        }

        [Test]
        public void ReadFile()
        {
            var fileReader = new FileReader();
            var file = fileReader.LoadSimpleFile(@"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\simple.txt");

        }


        [Test]
        public void ProcessFile()
        {
            //Trust all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            // where we start to read the url from
            var rootStart = "/geoevent/admin";

            var fileReader = new FileReader();
            var file = fileReader.LoadSimpleFile(@"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\simple.txt");

            file.Stubs.ForEach(definition =>
            {
                var parts = definition.StubStatement.Split(' ');

                if (parts.Length < 2)
                    throw new Exception("asdf");

                var methods = parts.Where(s => s.StartsWith("[")).ToList();
                var url = parts.FirstOrDefault(s => !s.StartsWith("["));
                var uri = new Uri(url);

                if (string.IsNullOrEmpty(url))
                    throw new Exception("asdf");

                if (!methods.Any())
                    methods.Add("[GET]"); // default GET maybe???

                methods.ForEach(method =>
                {
                    var methodFixed = method.TrimStart('[').TrimEnd(']').Trim().ToUpper();
                    var urlSegment = uri.AbsolutePath.Replace(rootStart, "").TrimStart('/').TrimEnd('/');
                    
                    if (urlSegment == "")
                        urlSegment = "default";

                    var methodName = methodFixed + urlSegment;
                    var methodDef = new MethodDefinition(methodName, null, null);

                    if (methodFixed == "GET")
                    {
                        methodDef.HTTPMethod = "GET";

                        // lets try to fetch some data!
                        IRestClient client = new RestClient(uri.Scheme + "://" + uri.Authority);
                        client.Authenticator = new HttpBasicAuthenticator("rangeli", "GeoEvent2013#");
                        IRestRequest request = new RestRequest(uri.AbsolutePath);
                        var result = client.Execute(request);

                        var builder = new Builder();
                        var code = builder.Build(result.Content, urlSegment);

                        // save file to project directory

                        // find root class and add to gets

                        var files = Directory.GetFiles(@"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\Gen");
                        var rootFile = files.SingleOrDefault(s => s.EndsWith(urlSegment + ".cs"));

                        methodDef.ReturnType = urlSegment;

                        definition.AddMethod(methodDef);

                        var sampleTest = methodDef.ToString();
                    }

                    if (methodFixed == "POST")
                    {
                        methodDef.HTTPMethod = "POST";
                        methodDef.ReturnType = urlSegment;

                        // if we have a GET use the GET Models, if we had any, for the POST parameters
                        var getmethod = definition.Methods.SingleOrDefault(methodDefinition => methodDefinition.HTTPMethod == "GET");

                        if (getmethod != null)
                        {
                            methodDef.Parameters.Add(getmethod.ReturnType);
                        }

                        definition.AddMethod(methodDef);
                    }

                });
            });
        }


        public void TestJsonFile()
        {
            var fileReader = new FileReader();
            var file = fileReader.LoadSimpleJson(@"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\simple.json");

            //file.Stubs.

        }


    }

  
}

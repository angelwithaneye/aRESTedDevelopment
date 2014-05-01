using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArestedDevelopment.Models
{
    public class SimpleFileInterpreter : IInterpreter
    {
        public bool Load()
        {
            var simpleFile = new SimpleFileInterpreter() { Stubs = new List<IStubDefinition>() };

            using (var sr = File.OpenText(""))
            {
                var s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    simpleFile.Stubs.Add(new StubDefinition(s));
                }
            }

            simpleFile.Stubs.ForEach(definition =>
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

        public List<IStubDefinition> Stubs { get; set; }


        public Func<IResource, bool> CheckResource
        {
            get
            {
                return resource =>
                {
                    if (resource.Type == "simpletext")
                        return true;

                    return false;

                };
            }
        }
    }
}

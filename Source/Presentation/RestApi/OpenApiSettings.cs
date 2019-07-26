using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi
{
    public class OpenApiSettings
    {
        public OpenApiSettings(string name, string title, string version)
        {
            Name = name;
            Title = title;
            Version = version;
        }

        public string Name { get; }

        public string Title { get; }

        public string Version { get; }

        public string GetSwaggerUrl()
        {
            return $"/swagger/{Name}/swagger.json";
        }
    }
}

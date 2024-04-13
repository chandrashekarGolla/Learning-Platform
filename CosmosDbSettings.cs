using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CosmosDbSettings.cs
namespace Models
{
    public class CosmosDbSettings
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseName { get; set; }
        public string CourseContainerName { get; set; }
        public string ChapterContainerName { get; set; }
    }

}



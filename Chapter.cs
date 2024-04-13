using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Chapter.cs
namespace Models
{
    public class Chapter
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string CourseId { get; set; }
        public int Position { get; set; } // For reordering
                                          // Add more properties as needed
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Course
{
    public class Course
    {
        public int Id { get; set; }
       
        public string Icon { get; set; }
        public string Position { get; set; }
        public IEnumerable<CourseTranslation> Translations { get; set; }

    }
}

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace StarTED.Data.Entities
{
    [Table ("ProgramCourses")]
    public class ProgramCourses
    {
        [Key]
        public int ProgramCourseID { get; set; }
        public int ProgramID { get; set; }
        public string CourseID { get; set; }
        public bool Required { get; set; }
        public string Comments { get; set; }
        public int SectionLimit { get; set; }
        public bool Active { get; set; }
    }
}

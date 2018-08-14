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
    [Table ("Programs")]
    public class Programs
    {
        [Key]
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string DiplomaName { get; set; }
        public string SchoolCode { get; set; }
        public decimal Tuition { get; set; }
        public decimal InternationalTuition { get; set; }
    }
}

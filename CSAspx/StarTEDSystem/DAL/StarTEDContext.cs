using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using StarTED.Data.Entities;
#endregion

namespace StarTEDSystem.DAL
{    
        internal class StarTEDContext:DbContext
        {
            public StarTEDContext():base("StarTEDDb")
            {

            }
            //indicate the property in this context class that will connection the sql table to the data definition class 
            public DbSet<Courses> Courses { get; set; }
            public DbSet<Programs> Programs { get; set; }
            public DbSet<ProgramCourses> ProgramCourses { get; set; }    

    }    
}

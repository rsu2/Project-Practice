using StarTED.Data.Entities;
using StarTEDSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarTEDSystem.BLL
{
   public class ProgramCoursesController
    {

        public ProgramCourses ProgramCourse_Find(int programcourseid)
        {
            using (var context = new StarTEDContext())
            {
                return context.ProgramCourses.Find(programcourseid);
            }
        }
        //use for form B and C
        public List<ProgramCourses> ProgramCourses_FindByProgramName(string programname)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<ProgramCourses> results =
                    context.Database.SqlQuery<ProgramCourses>("Programs_FindByProgramName @ProgramName",
                                     new SqlParameter("ProgramName", programname));
                return results.ToList();
            }
        }
        public List<ProgramCourses> ProgramCourses_FindByProgramAndCourse(int programid, string courseid)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<ProgramCourses> results =
                    context.Database.SqlQuery<ProgramCourses>("ProgramCourses_FindByProgramAndCourse @programid, @courseid",
                                     new SqlParameter("programid", programid),
                                     new SqlParameter("courseid", courseid));
                return results.ToList();
            }
        }

        public void AddProgramCourse(ProgramCourses programCourses)
        {
            using (var context = new StarTEDContext())
            {
                context.ProgramCourses.Add(programCourses);
                context.SaveChanges();
            }
        }

        public void RemoveProgramCourse(ProgramCourses programCourses)
        {
            using (var context = new StarTEDContext())
            {
                var id = programCourses.ProgramCourseID;
                var entity = context.ProgramCourses.Where(t => t.ProgramCourseID == id).FirstOrDefault();
                if (entity == null) return;
                context.ProgramCourses.Remove(entity);
                context.SaveChanges();
            }
        }

      
    }
}

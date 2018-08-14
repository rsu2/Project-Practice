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
                //if(programname==null || programname=="")
                //{
                //    return context.ProgramCourses.ToList();
                //}
                //var r = from t1 in context.Programs
                //        where t1.ProgramName == programname
                //        join t2 in context.ProgramCourses on t1.ProgramID equals t2.ProgramID into tt
                //        from t in tt
                //        select t;
                //return r.ToList();
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

        public List<ProgramCourses> ProgramCourses_FindByCourseID(string courseID)
        {
            using (var context = new StarTEDContext())
            {
                if (courseID == null || courseID == "")
                {
                    return context.ProgramCourses.ToList();
                }
                return context.ProgramCourses.Where(t => t.CourseID == courseID).ToList();
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

        public void UpdateProgramCourse(ProgramCourses programCourse)
        {
            using (var context = new StarTEDContext())
            {
                var entity = context.ProgramCourses.Where(t => t.ProgramCourseID == programCourse.ProgramCourseID).FirstOrDefault();
                if (entity == null) return;
                entity.Active = programCourse.Active;
                entity.Comments = programCourse.Comments;
                entity.CourseID = programCourse.CourseID;
                entity.ProgramCourseID = programCourse.ProgramCourseID;
                entity.ProgramID = programCourse.ProgramID;
                entity.Required = programCourse.Required;
                entity.SectionLimit = programCourse.SectionLimit;
                context.SaveChanges();
            }

        }


    }
}

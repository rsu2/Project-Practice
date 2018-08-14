
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using StarTED.Data.Entities;
using StarTEDSystem.DAL;
#endregion
namespace StarTEDSystem.BLL
{
    public class CoursesController
    {
        public List<Courses> Courses_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.Courses.ToList();
            }
        }

        public Courses Courses_GetCourse (string CourseID)
        {
            using (var context = new StarTEDContext())
            {
                return context.Courses.Find(CourseID);
            }
        }
        public List<Courses> Courses_FindByProgram(int programid)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Courses> results =
                    context.Database.SqlQuery<Courses>("Courses_FindByProgram @programid",
                                     new SqlParameter("programid", programid));
                return results.ToList();
            }
        }

        public void AddCourse(Courses course)
        {
            using (var context = new StarTEDContext())
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
        public void RemoveCourse(Courses course)
        {
            using (var context = new StarTEDContext())
            {
                var entity = context.Courses.Where(t => t.CourseID == course.CourseID).FirstOrDefault();
                if (entity == null) return;
                context.Courses.Remove(entity);
                context.SaveChanges();
            }
        }

        public void UpdateCourse(Courses course)
        {
            using (var context = new StarTEDContext())
            {
                var entity= context.Courses.Where(t => t.CourseID == course.CourseID).FirstOrDefault();
                if (entity == null) return;
                entity.CourseName = course.CourseName;
                entity.Credits = course.Credits;
                entity.Description = course.Description;
                entity.Term = course.Term;
                entity.TotalHours = course.TotalHours;
                entity.Tuition = course.Tuition;

                context.SaveChanges();
            }
        }
        //public List<ProgramCourses> ProgramCourses_FindByProgramAndCourse(int programid, string courseid)
        //{
        //    using (var context = new StarTEDContext())
        //    {
        //        IEnumerable<ProgramCourses> results =
        //            context.Database.SqlQuery<ProgramCourses>("Programs_FindByProgramAndCourse @programid, @courseid",
        //                             new SqlParameter("programid", programid),
        //                             new SqlParameter("courseid", courseid));
        //        return results.ToList();
        //    }
        //}    


        //public List<Courses>Courses_FindByPartialName(string partialname)
        //{
        //    using (var context = new StarTEDContext())
        //    {
        //        IEnumerable<Courses> results =
        //            context.Database.SqlQuery<Courses>("Courses_FindByPartialName @PartialName",
        //                            new SqlParameter("PartialName", partialname));
        //        return results.ToList();
        //    }
        //}
    }
}

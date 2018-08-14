
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using StarTED.Data.Entities;
using StarTEDSystem.BLL;
#endregion
namespace WebApp.FormPages
{
    public partial class FormA : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {

                BindProgramList();          

            }
        }
        protected void BindProgramList()
        {
            try
            {
                ProgramsController sysmgr = new ProgramsController();
                List<Programs> info = sysmgr.Programs_List();
                info.Sort((x, y) => x.ProgramName.CompareTo(y.ProgramName));
                ProgramList.DataSource = info;
                ProgramList.DataTextField = nameof(Programs.ProgramName);
                ProgramList.DataValueField = nameof(Programs.ProgramID);
                ProgramList.DataBind();
                ProgramList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected Exception GetInnerException (Exception ex)
        {
            while(ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

      
        protected void FindPrograms_Click(object sender, EventArgs e)
        {
            if (ProgramList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a program to obtain courses.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                ProgramList.DataSource = null;
                ProgramList.DataBind();
               
            }
            else
            {
                try
                {
                    CoursesController sysmgr = new CoursesController();
                    List<Courses> info = sysmgr.Courses_FindByProgram(int.Parse(ProgramList.SelectedValue));
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the program");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.CourseName.CompareTo(y.CourseName));
                        CoursesList.DataSource = info;
                        CoursesList.DataTextField = nameof(Courses.CourseName);
                        CoursesList.DataValueField = nameof(Courses.CourseID);
                        CoursesList.DataBind();
                        CoursesList.Items.Insert(0, "select...");
                       
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            //use the program and course to find programcourse
            //fill individual web controls with the programcourse record

            //test if set info has any records
            //  info.Count() == 0 bad else good
            if (CoursesList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a courses.");
                LoadMessageDisplay(errormsgs, "alert a alert-info");

            }
            //once you have made your call to get your record
            //info[0] is tyhe first record
            // ProgramCourseID.Text = info[0].ProgramCourseId;
            else
            {
                try
                {
                    ProgramCoursesController sysmgr = new ProgramCoursesController();
                    List<ProgramCourses> info = sysmgr.ProgramCourses_FindByProgramAndCourse(int.Parse(ProgramList.SelectedValue), CoursesList.SelectedValue);
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the Program");
                        LoadMessageDisplay(errormsgs, "alert alertt-info");
                        ProgramCoursesGridView.DataSource = null;
                        ProgramCoursesGridView.DataBind();
                    }
                    else
                    {
                        info.Sort((x, y) => x.ProgramCourseID.CompareTo(y.ProgramCourseID));
                        ProgramCoursesGridView.DataSource = info;
                        ProgramCoursesGridView.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }
        }

        protected void ProgramCoursesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = ProgramCoursesGridView.Rows[ProgramCoursesGridView.SelectedIndex];

            //try
            //{
            ProgramCoursesController sysmgr = new ProgramCoursesController();
            ProgramCourses info = sysmgr.ProgramCourse_Find(int.Parse(agvrow.Cells[1].Text));
            updateView(info);


            //}

        }

        private void updateView(ProgramCourses info)
        {
            ProgramsController programsController = new ProgramsController();
            CoursesController coursesController = new CoursesController();
            var programid = info.ProgramID;
            var program = programsController.Programs_FindByProgramID(programid);

            var courseid = info.CourseID;
            var course = coursesController.Courses_GetCourse(courseid);

            lbl_programid.Text = programid.ToString();
            txt_courseid.Text = courseid;
            lbl_programname.Text = program.ProgramName;

            txt_coursename.Text = course.CourseName;
            txt_credit.Text = course.Credits.ToString();
            txt_totalhours.Text = course.TotalHours.ToString();
            txt_classroomtype.Text = course.ClassroomType.ToString();
            txt_term.Text = course.Term.ToString();
            txt_tuition.Text = course.Tuition.ToString();
            txt_description.Text = course.Description;
        }



        protected void btn_add_Click(object sender, EventArgs e)
        {
            var programid = Convert.ToInt32( ProgramList.SelectedValue);
            var course = new Courses()
            {
                CourseID = txt_courseid.Text,
                CourseName = txt_coursename.Text,
                Credits = Convert.ToDecimal(txt_credit.Text),
                TotalHours = Convert.ToInt32(txt_totalhours.Text),
                ClassroomType = Convert.ToInt32(txt_classroomtype.Text),
                Term = Convert.ToInt32(txt_term.Text),
                Tuition = Convert.ToDecimal(txt_tuition.Text),
                Description = txt_description.Text
            };
            CoursesController coursesController = new CoursesController();
            coursesController.AddCourse(course);

            var programCourse = new ProgramCourses();
            programCourse.Active = true;
            programCourse.Comments = "";
            programCourse.CourseID = course.CourseID;
            programCourse.ProgramID = programid;
            programCourse.Required = true;
            ProgramCoursesController programCoursesController = new ProgramCoursesController();
            programCoursesController.AddProgramCourse(programCourse);

            FindPrograms_Click(null, null);
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            var programid = Convert.ToInt32(ProgramList.SelectedValue);
            var courseid = txt_courseid.Text;

            CoursesController coursesController = new CoursesController();
            var course = coursesController.Courses_GetCourse(courseid);
            if (course == null) return;

            course.CourseName = txt_coursename.Text;
            course.Credits = Convert.ToDecimal(txt_credit.Text);
            course.TotalHours = Convert.ToInt32(txt_totalhours.Text);
            course.ClassroomType = Convert.ToInt32(txt_classroomtype.Text);
            course.Term = Convert.ToInt32(txt_term.Text);
            course.Tuition = Convert.ToDecimal(txt_tuition.Text);
            course.Description = txt_description.Text;

            coursesController.UpdateCourse(course);
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            var programid = Convert.ToInt32(ProgramList.SelectedValue);
            var courseid = txt_courseid.Text;
            CoursesController coursesController = new CoursesController();
            var course = coursesController.Courses_GetCourse(courseid);
            if (course == null) return;

            ProgramCoursesController programCoursesController = new ProgramCoursesController();
            var programCourse = programCoursesController.ProgramCourses_FindByProgramAndCourse(programid,courseid).FirstOrDefault();
            if (programCourse == null) return;

            programCoursesController.RemoveProgramCourse(programCourse);
            coursesController.RemoveCourse(course);

            FindPrograms_Click(null, null);
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_courseid.Text = "";
            txt_coursename.Text = "";
            txt_credit.Text = "0";
            txt_totalhours.Text = "0";
            txt_classroomtype.Text = "1";
            txt_term.Text = "1";
            txt_tuition.Text = "0.0";
            txt_description.Text = "";

        }

        //protected void FilterCourses_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(SearchCourseName.Text))
        //    {
        //        errormsgs.Add("Enter the Course name.");
        //        LoadMessageDisplay(errormsgs, "alert alert-warning");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            CoursesController sysmgr = new CoursesController();
        //            List<Courses> info = sysmgr.Courses_FindByPartialName(SearchCourseName.Text);
        //            info.Sort((x, y) => x.CourseName.CompareTo(y.CourseName));
        //            CoursesList.DataSource = info;
        //            CoursesList.DataTextField = nameof(Courses.CourseName);
        //            CoursesList.DataValueField = nameof(Courses.CourseID);
        //            CoursesList.DataBind();
        //            CoursesList.Items.Insert(0, "select ...");
        //            if (info.Count == 0)
        //            {
        //                errormsgs.Add("No products found with supplied product name");
        //                LoadMessageDisplay(errormsgs, "alert alert-warning");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            errormsgs.Add("File Error: " + GetInnerException(ex).Message);
        //            LoadMessageDisplay(errormsgs, "alert alert-warning");
        //        }
        //    }
        //}

        //protected void SearchCourse_Click(object sender, EventArgs e)
        //{
        //    if (CourseList.SelectedIndex == 0)
        //    {
        //        errormsgs.Add("Select a course to fetch.");
        //        LoadMessageDisplay(errormsgs, "alert alert-warning");
        //    }
        //}
    }
}


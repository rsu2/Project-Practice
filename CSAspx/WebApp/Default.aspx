<%@ Page Title="Master Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Ran Su</h1>
        <p class="lead">A04 Program Courses</p>       
    </div>

    <div class="row">
        <div>
            <h2>Form Description</h2>
            <p>
                – Form A :
                  Select program first, than select course form the program.
                  Select the course, than int the display table to select course for Add, Updata, Delete.
            </p>           
        </div>
        <div>
            <h2>Known Bugs</h2>
            <p>
                – Form A:
                  Using store procedures not correct.
            </p>            
        </div>
        <div>
            <h2>Entity Relationship Diagram</h2>
            <p>
                - The ERD diagram (from the lab selection) of your selected scenario.
                
            </p>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/ERD.PNG" width="600"/>
        </div>
        <div >
            <h2>Class Diagrams</h2>
            <p>
                – Class Diagram images of the BLL and Entities, showing the full method/property signatures of each class.
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/ClassData1.PNG" width="600" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/ClassSystemAll.PNG" width="600"/>

            </p>            
        </div>
        <div>
            <h2>Stored Procedures</h2>
            <p>
                – A bulleted list of all the stored procedures used in your project.
                <ul>
                    <li>ProgramCourses_FindByProgramAndCourse </li>
                    <li>ProgramCourses_FindByProgram </li>
                    <li>Courses_FindByPartialName </li>
                </ul>
            </p>            
        </div>
    </div>

</asp:Content>

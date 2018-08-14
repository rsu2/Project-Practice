<%@ Page Title="CRUD - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="WebApp.FormPages.FormA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="page-header">
        <h1>Form A</h1>
    </div>
    
    <div class="row">
        <div class="col-offset-1 col-sm-10 alert alert-info">
            <blockquote style="font-style:italic">
                ProgramCourses - Single item Create/Read/Update/Delete
            </blockquote>
        </div>
    </div>
     <div class="row">
        <asp:DataList ID="Message" runat="server">
          <ItemTemplate>
               <%# Container.DataItem %>
          </ItemTemplate>
        </asp:DataList>
    </div>
    <div class ="col-md-12 bs-grid">
    <fieldset class="form-inline">
        <asp:Label ID="Label1" runat="server" Text="Program:"></asp:Label>
        <asp:DropDownList ID="ProgramList" runat="server">
        </asp:DropDownList>
        <asp:Button ID="FindPrograms" runat="server" Text="Courses?" CausesValidation="false" OnClick="FindPrograms_Click" />                             
        <asp:Label ID="label2" runat="server" Text="Courses:"></asp:Label>
        <asp:DropDownList ID="CoursesList" runat="server"></asp:DropDownList>
        <asp:Button ID="Select" runat="server" Text="Select"  OnClick="Select_Click"/>
        <br />
        <br />

        <asp:GridView ID="ProgramCoursesGridView" runat="server" Width="314px"            
             AutoGenerateColumns ="False"
             CssClass ="table table-hover table-striped" OnSelectedIndexChanged="ProgramCoursesGridView_SelectedIndexChanged" >
        <Columns>       
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>

            <asp:BoundField DataField="ProgramCourseID" HeaderText = "ProgramCourseID" />
            
            <asp:BoundField DataField="ProgramID" HeaderText = "ProgramID" />
            <asp:BoundField DataField="CourseID" HeaderText = "CourseID" />
            <asp:BoundField DataField="Required" HeaderText = "Required" />
            <asp:BoundField DataField="Comments" HeaderText = "Comments" />
            <asp:BoundField DataField="SectionLimit" HeaderText = "SectionLimit" />
            <asp:BoundField DataField="Active" HeaderText = "Active" />
            
        </Columns>                   
        </asp:GridView>
          
     </fieldset>
     </div>
   <div class="row">
        <div class="col-md-12">

            <table style="width:600px;">
                <tr>
                    <td class="key">ProgramID:</td>
                    <td class="value">
                        <asp:Label ID="lbl_programid" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="key">ProgramName:</td>
                    <td class="value">
                        <asp:Label ID="lbl_programname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="key">CourseID:</td>
                    <td class="value">
                        <asp:TextBox ID="txt_courseid" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="key">CourseName:</td>
                    <td class="value">
                        <asp:TextBox ID="txt_coursename" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="key">Credits</td>
                    <td class="value">
                        <asp:TextBox ID="txt_credit" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="key">TotalHours</td>
                    <td class="value">
                        <asp:TextBox ID="txt_totalhours" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="key">ClassroomType:</td>
                    <td class="value">
                        <asp:TextBox ID="txt_classroomtype" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="key">Term</td>
                    <td class="value">
                        <asp:TextBox ID="txt_term" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="key">Tuition</td>
                    <td class="value">
                        <asp:TextBox ID="txt_tuition" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="key">Description</td>
                    <td class="value">
                        <asp:TextBox ID="txt_description" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_Click" />
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" />
                    <asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="btn_delete_Click" />
                    <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" />
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

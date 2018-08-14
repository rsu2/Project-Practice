<%@ Page Title="Query - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormB.aspx.cs" Inherits="WebApp.FormPages.FormB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class ="page-header">
        <h1>Form B</h1>
    </div>
    
    <div class="row">
        <div class="col-offset-1 col-sm-10 alert alert-info">
            <blockquote style="font-style:italic">
                ProgramCourses by Program - Gridview Lookup with Code-Behind
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

</asp:Content>

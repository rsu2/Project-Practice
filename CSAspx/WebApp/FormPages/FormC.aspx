<%@ Page Title="ODS - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormC.aspx.cs" Inherits="WebApp.FormPages.FormC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        .col
        {
            padding-right:20px;
        }
    </style>
    <div class ="page-header">
        <h1>Form C</h1>
    </div>
    
    <div class="row">
        <div class="col-offset-1 col-sm-10 alert alert-info">
            <blockquote style="font-style:italic">
                ProgramCourses by Program - Gridview Lookup with ObjectDataSourse
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
    <div class="row">
        <div>
            <asp:Label ID="Label2" runat="server" Text="CourseID:"></asp:Label>
            <asp:TextBox ID="txt_searchbox" runat="server" Width="356px"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click" />
        </div>
        <asp:GridView ID="dataGrid" runat="server" AutoGenerateColumns="False" DataSourceID="ProjectCoursesObjectSource" AllowPaging="True" CellPadding="15" ForeColor="#333333" GridLines="None" DataKeyNames="ProgramID">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ProgramCourseID" HeaderText="ProgramCourseID" SortExpression="ProgramCourseID" ReadOnly="True" >
                    <HeaderStyle CssClass="col"/>
                </asp:BoundField>
                <asp:BoundField DataField="ProgramID" HeaderText="ProgramID" SortExpression="ProgramID" ReadOnly="True" >
                    <ItemStyle CssClass="hidden"/>
                    <HeaderStyle CssClass="hidden"/>
                </asp:BoundField>
                <asp:TemplateField HeaderText="CourseID">
                    <HeaderStyle CssClass="col" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CourseID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="dropdown" runat="server" SelectedValue='<%# Bind("CourseID") %>' DataSourceID="CoursesDataSource" DataTextField="CourseID" DataValueField="CourseID">
                        </asp:DropDownList>                    
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="Required" HeaderText="Required" SortExpression="Required" >
                    <HeaderStyle CssClass="col"/>
                </asp:CheckBoxField>
                <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" >
                    <HeaderStyle CssClass="col"/>
                </asp:BoundField>
                <asp:BoundField DataField="SectionLimit" HeaderText="SectionLimit" SortExpression="SectionLimit" >
                    <HeaderStyle CssClass="col"/>
                </asp:BoundField>
                <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" >
                    <HeaderStyle CssClass="col"/>
                </asp:CheckBoxField>

                <asp:CommandField CancelText="Cancel" DeleteText="Delete" EditText="Edit" ShowEditButton="True" ShowCancelButton="true" UpdateText="Update" />

            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ProjectCoursesObjectSource" runat="server" SelectMethod="ProgramCourses_FindByCourseID" TypeName="StarTEDSystem.BLL.ProgramCoursesController" DataObjectTypeName="StarTED.Data.Entities.ProgramCourses" UpdateMethod="UpdateProgramCourse">
            <SelectParameters>
                <asp:ControlParameter ControlID="txt_searchbox" Name="courseID" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="CoursesDataSource" runat="server" SelectMethod="Courses_List" TypeName="StarTEDSystem.BLL.CoursesController"></asp:ObjectDataSource>
        
    </div>
</asp:Content>

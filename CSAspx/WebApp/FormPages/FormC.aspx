<%@ Page Title="ODS - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormC.aspx.cs" Inherits="WebApp.FormPages.FormC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>

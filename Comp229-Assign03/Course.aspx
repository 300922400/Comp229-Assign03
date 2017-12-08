<%@ Page Title="Course" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="Comp229_Assign03.Course" %>
<%--display all student enroll course
add or remove students from course--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView id="CourseInfo" runat="server"></asp:DetailsView>
    <asp:GridView ID="StudentList" runat="server" >
    </asp:GridView>
</asp:Content>

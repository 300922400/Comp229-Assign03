<%@ Page Title="Course" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="Comp229_Assign03.Course" %>
<%--display all student enroll course
add or remove students from course--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="Display_Student" runat="server" AutoGenerateColumns="false">
        <Columns>
        </Columns>
    </asp:GridView>

</asp:Content>

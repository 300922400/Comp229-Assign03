<%@ Page Title="Course" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="Comp229_Assign03.Course" %>
<%--display all student enroll course
add or remove students from course--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView id="CourseInfo" runat="server"></asp:DetailsView>
    <asp:GridView ID="StudentList" DataKeyNames="StudentID" runat="server" OnRowDeleting="StudentList_RowDeleting" >
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Remove" />
        </Columns>
    </asp:GridView>
    <h1>PLEASE KINDLY ADD STUDENT HERE:</h1>
    <div>
        <asp:DropDownList ID="studentId" runat="server" DataSourceID="StudentDataSource" DataTextField="LastName" DataValueField="StudentID"></asp:DropDownList>
        <asp:SqlDataSource ID="StudentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Students %>" SelectCommand="SELECT [StudentID], [LastName] FROM [Students] WHERE [StudentID] NOT IN (
SELECT [StudentID] FROM Enrollments WHERE CourseId = @CourseId
)">
            <SelectParameters>
                <asp:QueryStringParameter Name="CourseId" QueryStringField="CourseID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Add_Student" runat="server" Text="ADD" OnClick="AddStudentToCourse_Click" />
    </div>
</asp:Content>

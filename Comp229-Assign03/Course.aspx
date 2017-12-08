<%@ Page Title="Course" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="Comp229_Assign03.Course" %>
<%--display all student enroll course
add or remove students from course--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView id="CourseInfo" runat="server"></asp:DetailsView>
    <asp:GridView ID="StudentList" runat="server" OnSelectedIndexChanged="StudentList_SelectedIndexChanged" >
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Removal" />
        </Columns>
    </asp:GridView>
    <div>
        <table>
            <tr>
                <td>Input StudentID whose need to be added:</td>
                <td>
                    <asp:TextBox ID="AddStudent_Course" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="AddStudentToCourse" runat="server" Text="Button" OnClick="AddStudentToCourse_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Title="Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Comp229_Assign03.Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Student Page </h2>
        <asp:DetailsView runat="server" ID="Student_Detail" AutoGenerateRows="false" DataSourceID="StudentDataSource">
            <Fields>
                <asp:BoundField DataField="StudentID" HeaderText="StudentID" InsertVisible="False" ReadOnly="True" SortExpression="StudentID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstMidName" HeaderText="FirstMidName" SortExpression="FirstMidName" />
                <asp:BoundField DataField="EnrollmentDate" HeaderText="EnrollmentDate" SortExpression="EnrollmentDate" />
            </Fields>
        </asp:DetailsView>

        <asp:SqlDataSource ID="StudentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Students %>" SelectCommand="SELECT * FROM [Students] WHERE ([StudentID] = @StudentID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="StudentID" QueryStringField="studentid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
      <asp:DetailsView  runat="server" ID="Student_Info" AutoGenerateRows="False">
          <Fields>
              <asp:HyperLinkField DataNavigateUrlFields="CourseID" DataNavigateUrlFormatString="Course.aspx?courseid={0}" DataTextField="CourseID" HeaderText="CourseID" Text="CourseID" />
              <asp:BoundField DataField="Title" HeaderText="Course Title" ReadOnly="True" />
              <asp:BoundField DataField="Grade" HeaderText="Grade" ReadOnly="True" />
          </Fields>
      </asp:DetailsView>  
    
    <table runat="server">
        <tr>
            <td>
                <asp:Button ID="Button_Update" runat="server" Text="UPDATE" OnClick="Button_Update_Click" />
            </td>
            <td>
                <asp:Button ID="Button_Delete" runat="server" Text="DELETE" OnClick="Button_Delete_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>

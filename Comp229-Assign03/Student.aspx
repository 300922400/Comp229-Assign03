<%@ Page Title="Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Comp229_Assign03.Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Student Page </h2>
    <p> 
        <asp:GridView ID="Student_Detail" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="StudentID" InsertVisible="False" ReadOnly="True" SortExpression="StudentID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstMidName" HeaderText="FirstMidName" SortExpression="FirstMidName" />
                <asp:BoundField DataField="EnrollmentDate" HeaderText="EnrollmentDate" SortExpression="EnrollmentDate" />
   
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students %>" SelectCommand="SELECT * FROM [Students] WHERE ([StudentID] = @StudentID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="StudentID" QueryStringField="custid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
         <asp:GridView ID="Student_Info" runat="server" AutoGenerateColumns="False" DataKeyNames="Student_Info" DataSourceID="Student_Info">
            <Columns>
                <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                <asp:BoundField DataField="Course" HeaderText="Course" SortExpression="Course" />
                <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
            </Columns>
        </asp:GridView>
    </p>
    
</asp:Content>

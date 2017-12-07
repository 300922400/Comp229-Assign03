<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_Assign03._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID ="StudentList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
            <asp:BoundField DataField="FirstMidName" HeaderText="FirstMidName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="EnrollmentDate" />
            <asp:HyperLinkField DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="Student.aspx?custid={0}" Text="Details" />
        </Columns>
    </asp:GridView>
    <div id="AddStudent" runat="server">
         <table>
             <tr>
                 <td>StudentID</td>
                 <td>
                     <asp:TextBox ID="input_StudentID" runat="server"></asp:TextBox>
                 </td>
             </tr>
              <tr>
                 <td>FirstMidName</td>
                 <td>
                     <asp:TextBox ID="input_FirstMidName" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>LastName</td>
                 <td>
                     <asp:TextBox ID="input_LastName" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>EnrollmentDate</td>
                 <td>
                     <asp:Calendar ID="input_EnrollmentDate" runat="server" OnSelectionChanged="input_EnrollmentDate_SelectionChanged"></asp:Calendar>
                 </td>
             </tr>
             <tr>
                 <td>Enrolment Date of New Student</td>
                 <td>
                     <asp:Label ID="Date_Enroll" runat="server" />
                 </td>

             </tr>
             <tr>
                 <td></td>
                 <td>
                     <asp:Button ID="Input_button" runat="server" Text="ADD" OnClick="Input_button_Click" />
                 </td>
             </tr>
         </table>
    </div>
   <%-- 
    <h1></h1>
    <asp:DataList ID ="StudentList" runat="server">
        <ItemTemplate>
            <table id="studentTable" runat="server">
                <tr>
                    <td>Student ID:</td>
                    <td><strong><a href="viewstudent.aspx?id=<%#Eval("StudentId") %>"><%#Eval("StudentId") %></a></strong></td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td><strong><%#Eval("FirstMidName")%></strong><strong><%#Eval("LastName")%></strong></td>
                </tr>
                <tr>
                    <td>Enrollment Date:</td>
                    <td><strong><%#Eval("EnrollmentDate") %></strong></td>
                </tr>
                
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>
    --%>
</asp:Content>

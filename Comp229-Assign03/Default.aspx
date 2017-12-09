<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_Assign03._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
     <img src="Image/XXsEphhJ.gif" />
    </div>
    <h1>STUDENT LIST</h1>
    <asp:GridView ID ="StudentList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
            <asp:BoundField DataField="FirstMidName" HeaderText="FirstMidName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="EnrollmentDate" DataFormatString="{0:dd-MM-yyyy}" />
            <asp:HyperLinkField DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="Student.aspx?studentid={0}" Text="Details" />
        </Columns>
    </asp:GridView>
    <br />
    <h2>PLEASE KINDLY INPUT THE NEW STUDENT:</h2>
    <div id="AddStudent" runat="server">
         <table>
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
                     <asp:TextBox ID="input_EnrollmentDate" runat="server" TextMode="Date"></asp:TextBox>
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
  
</asp:Content>

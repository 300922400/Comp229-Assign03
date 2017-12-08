<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Comp229_Assign03.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h1>Please update the information here:</h1>
    <table>
           <tr>
                 <td>FirstMidName</td>
                 <td>
                     <asp:TextBox ID="update_FirstMidName" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>LastName</td>
                 <td>
                     <asp:TextBox ID="update_LastName" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>Enrolment Date </td>
                 <td>
                     <asp:TextBox ID="Update_date" runat="server" ></asp:TextBox>
                 </td>

             </tr>
             <tr>
                 <td>Grade</td>
                 <td>
                     <asp:TextBox ID="update_Grade" runat="server"></asp:TextBox>
                 </td>
             </tr>
    
           <tr>
                 <td>Course </td>
                 <td>
                     <asp:TextBox ID="Update_Course" runat="server" ></asp:TextBox>
                 </td>

             </tr>
             <tr>
                 <td></td>
                 <td>
                     <asp:Button ID="Update_button" runat="server" Text="UPDATE" OnClick="Update_button_Click"  />
                 </td>
             </tr>
         </table>
  
    </div>
</asp:Content>

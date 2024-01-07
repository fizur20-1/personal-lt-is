<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="practicalVB._Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


  <div style="background-color:blueviolet; font-size:xx-large; color:white" align="center" >

        Crud Operation in ASP.net VB 
    </div>
    <br />
     <div style="padding:15px">
            
    <table class="w-100">

        <tr>
            <td style="width: 474px">
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            </td>
            
            <td>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>

        <tr>
            <td style="width: 474px">
                <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 474px; height: 21px">
                <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
            </td>
            <td style="height: 21px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        
      <tr>
            <td style="width: 474px">
                <asp:Label ID="Label3" runat="server" Text="BirthDate"></asp:Label>
            </td>
          <td style="height: 21px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
              <ajaxToolkit:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" BehaviorID="TextBox4_CalendarExtender" TargetControlID="TextBox4">
              </ajaxToolkit:CalendarExtender>
            </td>
            
        </tr>


        <tr>
            <td style="height: 21px; width: 474px">
                <asp:Label ID="Label4" runat="server" Text="JoinDate"></asp:Label>
            </td>
            <td style="height: 21px">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" BehaviorID="TextBox5_CalendarExtender" TargetControlID="TextBox5">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 474px">
                <asp:Label ID="Label5" runat="server" Text="Designation"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 474px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Insert" Width="126px" />
          
            </td>
           <td>
                 <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return confirmSave();" Width="126px" Visible="false" />
            </td>

       
        </tr>
    </table>

         <div align="center">
    <hr />
   <asp:GridView ID="GridView1" runat="server" Width="80%" EnableViewState="true" AutoGenerateColumns="False" DataKeyNames="UniqueId">
    <Columns>
        <asp:BoundField DataField="UniqueId" HeaderText="UniqueId" Visible="false" />
        
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="JoinDate" HeaderText="Join Date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <%--<asp:Button ID="btnUpdate" runat="server" CommandName="UpdateRow" Text="Update" />--%>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="UpdateRow" CommandArgument='<%# Eval("UniqueId") %>' Text="Update" />
                    <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("UniqueId") %>' Text="Delete" OnClientClick="return confirmDelete();" />
<%--                    <asp:Button ID="btnSave" runat="server" CommandName="SaveRow" Text="Save" OnClientClick="return confirmSave();" Style="display:block" />--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#9933FF" ForeColor="White" />
    </asp:GridView>
</div>


    </div>


    <script type="text/javascript">
        function confirmDelete() {
            return confirm('Are you sure you want to delete this employee?');
        }
        function confirmSave() {
            return confirm('Are you sure you want to save the changes?');
        }
    </script>


   

</asp:Content>

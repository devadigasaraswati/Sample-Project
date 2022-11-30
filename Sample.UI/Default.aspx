<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Sample.UI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Sample Code
    </h2>    
    <p>
        <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
    </p>
</asp:Content>

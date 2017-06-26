<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="jumbotron strech text-center">
        <span style="font-size: 40pt">You'r Orders</span>
        <div class="payPanel">
            <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
            <div id="OrdersTable" runat="server"></div>
        </div>
    </div>
</asp:Content>


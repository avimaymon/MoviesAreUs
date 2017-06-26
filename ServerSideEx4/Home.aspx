<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">   
    <div class="bgimage strech">
    <div class="container">
        <div class="jumbotron text-center">
            <h1>Welcome to MoviesAreUs!</h1>
            <p>
                Here you can buy movie tickets and a whole lot more!<br />
                Please go ahead an order a ticket now!
            </p>
        </div>
    </div>
        <div class="container">
        <div class="payPanel text-center">
            <h3>Hi amigo!</h3><h4>Please log in</h4>
            <asp:Label id="lbl_txtUserName" AssociatedControlId="txtUserName" Text="Username" runat="server" />
            <asp:TextBox ID="txtUserName" CssClass="bigBorder" runat="server"></asp:TextBox>
            <br />
            <asp:Label id="lbl_txtPassword" AssociatedControlId="txtUserPass" Text="Password" runat="server" />
            <asp:TextBox ID="txtUserPass" CssClass="bigBorder" runat="server"></asp:TextBox>
            <br />
        <asp:Button CssClass="btn btn-primary btn-lg bigBorder" ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" />
        </div></div>
</asp:Content>


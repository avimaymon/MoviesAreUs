<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Buy_A_Ticket.aspx.cs" Inherits="Buy_A_Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid strech">
        <div class="jumbotron jumbotron-fluid movieList">
            <div class="container ">
                <h4 class="display-3">Movie List</h4>
                <div class="list-group" id="movieList" runat="server">
                </div>
            </div> 
        </div>
        <div class="jumbotron jumbotron-fluid seatsPanel">
            <asp:Image ImageUrl="~/graphics/na.jpg" class="poster" ID="posterImg"  runat="server" ></asp:Image>
            <br />
            <b><asp:Label ID="tmpFilmName" runat="server" CssClass="tmpFilmName"></asp:Label></b>
            <fieldset>
            <div>
            <span style="display:inline-block;">Row 1</span>
                <asp:CheckBox Text="1" ID="check0_0" runat="server" />
                <asp:CheckBox Text="2" ID="check0_1" runat="server" />
                <asp:CheckBox Text="3" ID="check0_2" runat="server" />
                <asp:CheckBox Text="4" ID="check0_3" runat="server" />
                <asp:CheckBox Text="5" ID="check0_4" runat="server" />
                <span ><br />Row 2</span>
                <asp:CheckBox Text="1" ID="check1_0" runat="server" />
                <asp:CheckBox Text="2" ID="check1_1" runat="server" />
                <asp:CheckBox Text="3" ID="check1_2" runat="server" />
                <asp:CheckBox Text="4" ID="check1_3" runat="server" />
                <asp:CheckBox Text="5" ID="check1_4" runat="server" />
                <span ><br />Row 3</span>
                <asp:CheckBox Text="1" ID="check2_0" runat="server" />
                <asp:CheckBox Text="2" ID="check2_1" runat="server" />
                <asp:CheckBox Text="3" ID="check2_2" runat="server" />
                <asp:CheckBox Text="4" ID="check2_3" runat="server" />
                <asp:CheckBox Text="5" ID="check2_4" runat="server" />
                <span ><br />Row 4</span>
                <asp:CheckBox Text="1" ID="check3_0" runat="server" />
                <asp:CheckBox Text="2" ID="check3_1" runat="server" />
                <asp:CheckBox Text="3" ID="check3_2" runat="server" />
                <asp:CheckBox Text="4" ID="check3_3" runat="server" />
                <asp:CheckBox Text="5" ID="check3_4" runat="server" />
                <span><br />Row 5</span>
                <asp:CheckBox Text="1" ID="check4_0" runat="server" />
                <asp:CheckBox Text="2" ID="check4_1" runat="server" />
                <asp:CheckBox Text="3" ID="check4_2" runat="server" />
                <asp:CheckBox Text="4" ID="check4_3" runat="server" />
                <asp:CheckBox Text="5" ID="check4_4" runat="server" />
            </div>
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
        </fieldset>
        </div>
    </div>
</asp:Content>


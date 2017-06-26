<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="jumbotron strech text-center">
        <span style="font-size: 40pt;">Pay For Your Tickets</span>
        <div class="payPanel">
            <div id="lblTransactionInfo" runat="server"></div>
            <div id="lblSnacksInfo" runat="server"></div>
            Select Card Type:
                        <asp:DropDownList ID="DD_CardType" runat="server" Enabled="false">
                            <asp:ListItem>VISA</asp:ListItem>
                            <asp:ListItem>MASTERCARD</asp:ListItem>
                            <asp:ListItem>AMERICAN EXPRESS</asp:ListItem>
                            <asp:ListItem>DEBIT CARD</asp:ListItem>
                        </asp:DropDownList>
            <br />
            Credit Card Number: 
                        <br />
            <asp:TextBox id="TxtCardNumber" runat="server" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator3" 
                            runat="server"   
                            ControlToValidate="TxtCardNumber" Display="Dynamic">
                <span style="color:red;">Card number required</span>
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="RegularExpressionValidator6" 
                            runat="server" ControlToValidate="TxtCardNumber"  Display="Dynamic"
							ValidationExpression="[0-9]{6}">
                 <span style="color:red;">Invalid Card number</span>
            </asp:RegularExpressionValidator>
            <br />
            Phone Number:
                        <br />
            <asp:TextBox ID="txtPhoneNumber" runat="server" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1"  
                            runat="server" Width="12px"   Display="Dynamic"
                            ControlToValidate="txtPhoneNumber"><span style="color:red;">Phone number required</span></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="RegularExpressionValidator7" runat="server" ControlToValidate="txtPhoneNumber" 
                             Display="Dynamic"
							ValidationExpression="0[1-9][0-9]{7}" >
                <span style="color:red;">Invalid Card number</span>
            </asp:RegularExpressionValidator>
            <br />
            Coupon?
                        <br />
            <asp:RadioButton ID="RB_Coupon_No" Enabled="false" runat="server" GroupName="Coupon" Text="No" Checked="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RB_Coupon_Yes" Enabled="false" runat="server" GroupName="Coupon" Text="Yes" />
            <br />
            Snacks:
                        <br />
                <asp:Table ID="Table1"
                    runat="server"
                    Font-Size="X-Large"
                    Width="550"
                    Font-Names="Palatino"
                    BorderColor="Thistle"
                    BorderWidth="2"
                    CellPadding="5"
                    CellSpacing="5"
                    HorizontalAlign= "Center">
                    <asp:TableHeaderRow
                        runat="server"
                        ForeColor="Snow"
                        BackColor="Silver"
                        Font-Bold="true" >
                        <asp:TableCell>Product</asp:TableCell>
                        <asp:TableCell>Quantity</asp:TableCell>
                        <asp:TableCell>Size</asp:TableCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow
                        ID="TableRow1"
                        runat="server"
                        ForeColor="Black" BackColor="MintCream">
                        <asp:TableCell>Popcorn</asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="Quantity1" runat="server" Enabled="false"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Change">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="Size1" runat="server" Enabled="false"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Change">
                            <asp:ListItem>Small</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Big</asp:ListItem>
                            <asp:ListItem>Hugh</asp:ListItem>
                        </asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow
                        ID="TableRow2"
                        runat="server"
                        ForeColor="Black" BackColor="PaleTurquoise">
                        <asp:TableCell>Nachos</asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="Quantity2" runat="server" Enabled="false" 
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Change">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="Size2" runat="server" Enabled="false"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Change">
                            <asp:ListItem>Small</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Big</asp:ListItem>
                            <asp:ListItem>Hugh</asp:ListItem>
                        </asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow
                        ID="TableRow3"
                        runat="server"
                        ForeColor="Black" BackColor="MintCream">
                        <asp:TableCell>Drinks</asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="Quantity3" runat="server" Enabled="false"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Change">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:DropDownList ID="Size3" runat="server" Enabled="false"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Change">
                            <asp:ListItem>Small</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Big</asp:ListItem>
                            <asp:ListItem>Hugh</asp:ListItem>
                        </asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableFooterRow
                        runat="server"
                        HorizontalAlign= "Center">
                        <asp:TableCell
                            ColumnSpan="3"
                            HorizontalAlign="Center"
                            Font-Italic="true" ForeColor="Snow" BackColor="SlateBlue">
                    Enjoy!
                        </asp:TableCell>
                    </asp:TableFooterRow>
                </asp:Table>
            <div>
                <asp:Button CssClass="btn btn-lg btn-success" ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click" />
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="Въвеждане на танков отбор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="Tank_Platoons.Input" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %>.</h3>
    <p>Име на отбор:&nbsp;
        <asp:TextBox ID="inptname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; ID:
        <asp:TextBox ID="inptid" runat="server" Width="31px"></asp:TextBox>
    </p>
    <p>Националност на отбора;&nbsp;
        <asp:TextBox ID="inptnation" runat="server"></asp:TextBox>
    </p>
    <p>Рейтинг:&nbsp;
        <asp:TextBox ID="inptrating" runat="server"></asp:TextBox>
&nbsp; Процент победи на отбора:
        <asp:TextBox ID="inptwr8" runat="server" Width="31px"></asp:TextBox>
    </p>
    <p>Трофеи:</p>
    <p>Място:&nbsp;
        <asp:TextBox ID="inptTropheyPlace" runat="server" Width="16px"></asp:TextBox>
&nbsp; Година:&nbsp;
        <asp:TextBox ID="inptTropheyYear" runat="server" Width="55px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Лига:&nbsp;
        <asp:TextBox ID="inptLeagueName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Държава на лигата:&nbsp;
        <asp:TextBox ID="inptLeagueCountry" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Лига ID:
        <asp:TextBox ID="inptLeagueID" runat="server" Width="31px"></asp:TextBox>
    </p>
    <p>Тип:&nbsp;
        <asp:TextBox ID="inptLeagueType" runat="server"></asp:TextBox>
&nbsp; ID:&nbsp;
        <asp:TextBox ID="inptTropheyID" runat="server" Width="31px"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>Членове на отбора:</p>
    <p>Име:&nbsp;
        <asp:TextBox ID="inptMemberName" runat="server"></asp:TextBox>
&nbsp; Фамилия:&nbsp;
        <asp:TextBox ID="inptMemberLastName" runat="server"></asp:TextBox>
&nbsp; Пол:&nbsp;
        <asp:TextBox ID="inptMemberGender" runat="server" Width="64px"></asp:TextBox>
&nbsp; ID:&nbsp;
        <asp:TextBox ID="inptMemberID" runat="server" Width="21px"></asp:TextBox>
&nbsp; Позиция в отбора:&nbsp;
        <asp:TextBox ID="inptMemberPlatPos" runat="server"></asp:TextBox>
    </p>
    <p>Стратегическа позиция:&nbsp;
        <asp:TextBox ID="inptMemberStratPos" runat="server" Width="121px"></asp:TextBox>
&nbsp; Години:
        <asp:TextBox ID="inptMemberAge" runat="server" Width="20px"></asp:TextBox>
&nbsp; Дата на раждане:
        <asp:TextBox ID="inptMemberDay" runat="server" Width="31px"></asp:TextBox>
&nbsp;/<asp:TextBox ID="inptMemberMonth" runat="server" Width="31px"></asp:TextBox>
        /<asp:TextBox ID="inptMemberYear" runat="server" Width="54px"></asp:TextBox>
    </p>
    <p>Държава:
        <asp:TextBox ID="inptMemberCountry" runat="server" Width="126px"></asp:TextBox>
&nbsp; Процент победи:
        <asp:TextBox ID="inptMemberwr8" runat="server" Width="31px"></asp:TextBox>
&nbsp; Потрбителско име:
        <asp:TextBox ID="inptMemberNickname" runat="server" Width="124px"></asp:TextBox>
    </p>
    <p>Танк:</p>
    <p>Име на танк:
        <asp:TextBox ID="inptTankName" runat="server" Width="88px"></asp:TextBox>
&nbsp; Тип на танк:
        <asp:TextBox ID="inptTankType" runat="server" Width="97px"></asp:TextBox>
&nbsp; Нация на танка:
        <asp:TextBox ID="inptTankNation" runat="server" Width="101px"></asp:TextBox>
&nbsp; Ниво на танка:&nbsp;
        <asp:TextBox ID="inptTankTier" runat="server" Width="31px"></asp:TextBox>
&nbsp; ID:<asp:TextBox ID="inptTankId" runat="server" Width="31px"></asp:TextBox>
    </p>
    <p>Пробивност на оръдието:
        <asp:TextBox ID="inptGunPen" runat="server" Width="31px"></asp:TextBox>
&nbsp; Тип на амунициите:
        <asp:TextBox ID="inptAmmoType" runat="server" Width="31px"></asp:TextBox>
&nbsp; Максимална скорост:
        <asp:TextBox ID="inptTopSpeed" runat="server" Width="31px"></asp:TextBox>
&nbsp; Път до изобр.
        <asp:TextBox ID="inptImage" runat="server" Width="142px"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:Button ID="inptEnter" runat="server" OnClick="Button1_Click" Text="Въведи!" />
    </p>
</asp:Content>

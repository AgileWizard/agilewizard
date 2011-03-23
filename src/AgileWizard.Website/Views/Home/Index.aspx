<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: HomeString.IndexTitle %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:8px;">
        <img src="../../Content/Images/home_pic.png" alt="" align=middle />
    </div>
    <!-- to replace after art design-->
    <div>Top like resource list</div>
    <!-- to replace after art design-->
    <div><%Html.RenderAction("GetLikeList", "Resource"); %></div>
     <!-- to replace after art design-->
    <div>Top hit resource list</div>
    <!-- to replace after art design-->
   <div><%Html.RenderAction("GetHitList", "Resource"); %></div>
</asp:Content>

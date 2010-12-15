<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    <%: Model.Title %>
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2 class="Title"><%: Model.Title %></h2>
    <div><%:ResourceName.Author %>:<span class="Author"><%: Model.Author %></span>&nbsp;
    <%:ResourceName.SubmitUser %>:<span class="SubmitUser"><%: Model.SubmitUser%></span>&nbsp;<span><%: Model.CreateTime.ToString() %></span></div>
    <br />
    <span class="Content"><%=Model.Content %></span>
    <br />
    <%:ResourceName.Tags %>:<span class="Tags"><%:Model.Tags %></span>
</asp:Content>

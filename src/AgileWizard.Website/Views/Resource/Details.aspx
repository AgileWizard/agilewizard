<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    <%: Model.Title %>
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <link href="<%=Url.Content("~/Content/Resource.css") %>" rel="stylesheet" type="text/css" />
    <h1 class="Title"><%: Model.Title %></h1>
    <div class="Information">
        <%:ResourceName.Author %>:<span class="Author"><%: Model.Author %></span>&nbsp;
        <%:ResourceName.SubmitUser %>:<span class="SubmitUser"><%: Model.SubmitUser%></span>&nbsp;
        <span><%: Model.CreateTime.ToString() %></span>
        <%:ResourceName.ReferenceUrl %>: <span class="ReferenceUrl"><%=Model.ReferenceUrl %></span>
    </div>
    <br />
    <div class="Content"><%=Model.Content %></div>
    <div class="TagsArea"><%:ResourceName.Tags %>:<span class="Tags"><%:Model.Tags %></span></div>
</asp:Content>

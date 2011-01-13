<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    <%: Model.Title %>
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <link href="<%=Url.Content("~/Content/Resource.css") %>" rel="stylesheet" type="text/css" />
    <h1 id="title_field" class="Title"><%: Model.Title %></h1>
    <div class="Information">
        <%:ResourceName.Author %>:<span id="author_field" class="Author"><%: Model.Author %></span>&nbsp;
        <%:ResourceName.SubmitUser %>:<span id="submituser_field" class="SubmitUser"><%: Model.SubmitUser%></span>&nbsp;
        <span id="createtime_field"><%: Model.CreateTime.ToString() %></span>
        <%:ResourceName.ReferenceUrl %>: <span id="referenceurl_field" class="ReferenceUrl"><%=Model.ReferenceUrl %></span>
    </div>
    <br />
    <div id="content_field" class="Content"><%=Model.Content %></div>
    <div class="TagsArea"><%:ResourceName.Tags %>:<span id="tags_field" class="Tags"><%:Model.Tags %></span></div>
</asp:Content>

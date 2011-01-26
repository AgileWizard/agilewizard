<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    <%: Model.Title %>
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <link href="<%=Url.Content("~/Content/Resource.css") %>" rel="stylesheet" type="text/css" />
    <span class="button-group">
        <button title="<%=ResourceString.Like%>" type="button" class="button" id="like">
            <img class="icon-like" src="<%=Url.Content("~/Content/Images/empty.gif") %>" alt="" />
            <span class="button-content"><%=ResourceString.Like%></span>
        </button>
        <button title="<%=ResourceString.Dislike%>" type="button" class="button" id="dislike">
            <img class="icon-dislike" src="<%=Url.Content("~/Content/Images/empty.gif") %>" alt="" />
        </button>
    </span>
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
    <script type="text/javascript">
        $(function () {
            $("#like").click(function () {
                $.post('<%=Url.Action("Like") %>', {Id: '<%=Model.Id %>'}, function () {

                }, "json");
            });
            $("#dislike").click(function () {
                $.post('<%=Url.Action("Dislike") %>', {Id: '<%=Model.Id %>'}, function () {

                }, "json");
            });
        });
    </script>
</asp:Content>

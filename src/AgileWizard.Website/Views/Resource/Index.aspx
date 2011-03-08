<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<AgileWizard.Website.Models.ResourceListViewModel>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ResourceString.Resources%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ResourceString.Resources%></h2>
        <%if (Request.IsAuthenticated) {%>
        <p>
        <%: Html.ActionLink(ResourceString.CreateResourceLink, "Create", null, new { @class="link", @id="create_link"})%>
        </p>
        <%}%>
    <div id="resource-list-container"><%: Html.Partial("ResourceList", Model) %></div>
    <div id="more-area"><input type=button id="more" value="More" /></div>
    <script type="text/javascript" language="javascript">
        <%var nPage = (int)ViewData["currentPage"]; %>
        $(function () {
            $('#more').click(function () {
                $.get('/Resource/ResourceList', {currentPage:<%=nPage %>}, function(data){
                    $('#resource-list-container').append(data);
                });
            });
        });
    </script>
</asp:Content>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<AgileWizard.Website.Models.ResourceListViewModel>>" %>
 <h2>
        <%: ResourceString.Resources%></h2>
        <%if (Request.IsAuthenticated) {%>
        <p>
        <%: Html.ActionLink(ResourceString.CreateResourceLink, "Create", "Resource", null, new { @class="link", @id="create_link"})%>
        </p>
        <%}%>
    <div id="resource-list-container"><%: Html.Partial("ResourceList", Model) %></div>
<div align="center">
    <img src="<%=Url.Content("~/Content/Images/ajax-loader.gif") %>" alt="More" id="loadingImg" class="hidden" />
    <input type="button" id="more" value="More" />
</div>

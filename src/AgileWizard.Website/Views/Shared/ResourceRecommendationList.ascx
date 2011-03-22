<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<AgileWizard.Website.Models.ResourceListViewModel>>" %>
 <div id="resource-list-container"><%: Html.Partial("ResourceList", Model) %></div>

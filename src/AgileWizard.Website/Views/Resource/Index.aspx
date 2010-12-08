<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceList>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	All Resources
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>Resources</h2>

	<p>
		<%: Html.ActionLink("Create New Resource", "Create") %>
	</p>
	<p>
		<span class="display-label">Total resource count:</span>
		<span class="totalResourceCount"><%: Model.TotalCount %></span>
	</p>
	<table>
		<tr>
			<th></th>
			<th>Title</th>
			<th>Content</th>
		</tr>

	<% foreach (var item in Model) { %>
		<tr>
			<td>
				<%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>
			</td>
			<td><%: Html.ActionLink(item.Title, "Details", new { id = item.Id })%></td>
			<td><%: item.Content %></td>
		</tr>
	
	<% } %>

	</table>

</asp:Content>

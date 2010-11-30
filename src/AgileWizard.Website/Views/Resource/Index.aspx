<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AgileWizard.Website.Models.ResourceModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	All Resources
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>Resources</h2>

	<p>
		<%: Html.ActionLink("Create New Resource", "Create") %>
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
				<%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
				<%: Html.ActionLink("Edit", "Edit", new { id=item.Title }) %> |
				<%: Html.ActionLink("Delete", "Delete", new { id=item.Title })%>
			</td>
			<td><%: item.Title %></td>
			<td><%: item.Content %></td>
		</tr>
	
	<% } %>

	</table>

</asp:Content>

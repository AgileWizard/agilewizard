<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceList>" %>
<%@ Import Namespace="AgileWizard.Locale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	All Resources
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2><%:LocaleHelper.GetLocaleString("Resources")%></h2>

	<p>
		<%: Html.ActionLink(LocaleHelper.GetLocaleString("Create New Resource"), "Create", null, new { @class="createNewResource"})%>
	</p>
	<p>
		<span class="display-label"><%:LocaleHelper.GetLocaleString("Total resource count:") %></span>
		<span class="totalResourceCount"><%: Model.TotalCount %></span>
	</p>
	<table>
		<tr>
			<th></th>
			<th><%: LocaleHelper.GetLocaleString("Title")%></th>
			<th><%: LocaleHelper.GetLocaleString("Content")%></th>
		</tr>

	<% foreach (var item in Model) { %>
		<tr>
			<td>
				<%: Html.ActionLink(LocaleHelper.GetLocaleString("Edit"), "Edit", new { id=item.Id }) %>
			</td>
			<td><%: Html.ActionLink(item.Title, "Details", new { id = item.Id })%></td>
			<td><%: item.Content %></td>
		</tr>
	
	<% } %>

	</table>

</asp:Content>

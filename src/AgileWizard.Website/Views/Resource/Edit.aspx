<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" %>
<%@ Import Namespace="AgileWizard.Locale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2><%:  LocaleHelper.GetLocaleString("Edit") %></h2>
	<% Html.EnableClientValidation(); %>
	<% using (Html.BeginForm()) {%>
		
		<fieldset>
			<legend><%:  LocaleHelper.GetLocaleString("Edit a resource") %></legend>
			
		   
			<div class="editor-label">
				<%: Html.LabelFor(m => m.Title) %>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(m => m.Title) %>
				<%: Html.ValidationMessageFor(m => m.Title) %>
			</div>
			<div class="editor-label">
				<%: Html.LabelFor(m => m.Content) %>
			</div>
			<div class="editor-field">
				<%: Html.TextAreaFor(m => m.Content, new {rows=15, cols=60 })%>
				<%: Html.ValidationMessageFor(m => m.Content)%>
			</div>
			
			<p>
				<input type="submit" value="Save" />
			</p>
		</fieldset>

	<% } %>

	<div>
		<%: Html.ActionLink("Back to List", "Index") %>
	</div>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" %>
<%@ Import Namespace="AgileWizard.Website.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ResourceString.CreateResourceTitle %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ResourceString.Create %></h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend><%: ResourceString.CreateResourceTitle %></legend>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Title) %>
            <%: Html.ValidationMessageFor(m => m.Title) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Author) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Author)%>
            <%: Html.ValidationMessageFor(m => m.Author)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.ReferenceUrl) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.ReferenceUrl) %>
            <%: Html.ValidationMessageFor(m => m.ReferenceUrl) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Content) %>
        </div>
        <div class="editor-field">
            <%: Html.HtmlEditorFor(m => m.Content, new {rows=15, cols=60, Class="tinymce" })%>
            <%: Html.ValidationMessageFor(m => m.Content)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Tags) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Tags)%>
            <%: Html.ValidationMessageFor(m => m.Tags)%>
        </div>
        <p>
            <input type="submit" value="<%: ResourceString.Save %>" />
        </p>
    </fieldset>
    <div>
        <%:Html.ActionLink(ResourceString.BackToResources, "Index") %>
    </div>
    <% } %>
</asp:Content>

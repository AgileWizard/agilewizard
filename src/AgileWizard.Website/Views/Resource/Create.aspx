<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Resource
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend>Create Resource</legend>
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
    <div>
        <%:Html.ActionLink("Back to Resources", "Index") %>
    </div>
    <% } %>
</asp:Content>

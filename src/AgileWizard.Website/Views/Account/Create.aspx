<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.AccountCreateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: AccountString.CreateAccountTitle%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: AccountString.CreateAccountTitle%></h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
        <%: Html.ValidationSummary(true, AccountString.CreateUserFailed) %>
    <fieldset>
        <legend>
            <%: AccountString.CreateAccountTitle%></legend>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.UserName) %>
            <%: Html.ValidationMessageFor(m => m.UserName) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(m => m.Password)%>
            <%: Html.ValidationMessageFor(m => m.Password)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Rss) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Rss) %>
            <%: Html.ValidationMessageFor(m => m.Rss) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Bio) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(m => m.Bio) %>
            <%: Html.ValidationMessageFor(m => m.Bio) %>
        </div>

        <p>
            <input id="submit_button" type="submit" value="<%: SharedString.Save %>" />
        </p>
    </fieldset>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%: AccountString.LogOnTitle%>
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: AccountString.LogOnTitle%></h2>
    <p>
        <%: AccountString.PleaseEnterUserNameAndPassword %> <%--<%: AccountString.RegisterPleaseClick %><%: Html.ActionLink(AccountString.RegisterLink, "Register") %>--%>
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, AccountString.LoginFailedAndTryAgain) %>
        <div>
            <fieldset>
                <legend><%: AccountString.AccountInformation %></legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName, new { id="username_field" }) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password, new { id="password_field" }) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
              <%--  <div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe) %>
                </div>--%>
                
                <p>
                    <input id="submit_button" type="submit" value="<%: AccountString.LogOnButtonText %>" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>

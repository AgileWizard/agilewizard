<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceList>" %>

<%@ Import Namespace="AgileWizard.Locale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%:LocaleHelper.GetLocaleString("Resources")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%:LocaleHelper.GetLocaleString("Resources")%></h2>
    <p>
        <%: Html.ActionLink(LocaleHelper.GetLocaleString("Create New Resource"), "Create", null, new { @class="createNewResource"})%>
    </p>
    <p>
        <span class="display-label">
            <%:LocaleHelper.GetLocaleString("Total resource count:") %></span> <span class="totalResourceCount">
                <%: Model.TotalCount %></span>
    </p>
    <table class="contentList">
        <tr>
            <th class="link">
            </th>
            <th id="listTitle"><%: LocaleHelper.GetLocaleString("Title")%></th>
            <th id="listContent"><%: LocaleHelper.GetLocaleString("Content")%></th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td class="link"><%: Html.ActionLink(LocaleHelper.GetLocaleString("Edit"), "Edit", new { id=item.Id }) %></td>
            <td class="title"><%: Html.ActionLink(item.Title, "Details", new { id = item.Id })%></td>
            <td class="content"><%: item.Content %></td>
        </tr>
        <% } %>
    </table>
</asp:Content>

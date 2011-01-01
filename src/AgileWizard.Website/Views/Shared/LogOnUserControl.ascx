<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <%: SharedString.Welcome %> <b><%: Page.User.Identity.Name %></b>!
        <%: Html.ActionLink(SharedString.LogOffLink, "LogOff", "Account") %>
<%
    }
    else {
%> 
        <%: Html.ActionLink(SharedString.LogOnLink, "LogOn", "Account")%>
<%
    }
%>

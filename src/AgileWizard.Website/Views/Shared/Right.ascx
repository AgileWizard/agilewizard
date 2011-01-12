<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    var tagList = TagsHelper.GetTagList(20);
    foreach (var tag in tagList)
    {
%>
<%: tag.Name %> X <%: tag.TotalCount %><br />
<%} %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<link href="../../Content/Tag.css" rel="stylesheet" type="text/css" />
<div class="tag-list">
    <%
        var tagList = TagsHelper.GetTagList(20);
        foreach (var tag in tagList)
        {
    %>
    <div class="tag-row">
        <a href="#"><span class="tag-name"><%: tag.Name %></span></a>
        <span>× <%: tag.TotalCount %></span>
    </div>
    <%} %>
</div>

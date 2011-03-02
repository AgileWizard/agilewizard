<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AgileWizard.Website.Models.ResourceList>" %>
<link href="../../Content/Resource.css" rel="stylesheet" type="text/css" />
<% foreach (var item in Model)
   {%>
    <div class="resource-item">
        <div class="thumbs">
            <a href="<%:Url.Action("Details", "Resource", new {id = item.Id})%>">
                <img src="<%=item.ImageUrl ?? Url.Content("~/Content/Images/default_resource_icon.jpg")%>" width="125px" />
            </a>
        </div>
        <div class="indexs">
            <div class="counters">
                <div class="counter pageview">
                    <div class="counts"><%=item.PageView %></div>
                    <div class="actionResult"><%=ResourceString.PageView%></div>
                </div>
                <div class="counter dislike">
                    <div class="counts"><%=item.Dislike%></div>
                    <div class="actionResult"><%=ResourceString.Dislike%></div>
                </div>
                <div class="counter like">
                    <div class="counts"><%=item.Like %></div>
                    <div class="actionResult"><%=ResourceString.Like%></div>
                </div>
            </div>
            <h2>
                <a href="<%:Url.Action("Details", "Resource", new {id = item.Id})%>"><%:item.Title%></a>
            </h2>
            <div class="time">
                &copy; <a href="" title="<%:item.Author%>"><%:item.Author%></a> / 
                <%:item.CreateTime.ToString("yyyy.MM.dd")%> / <%:item.CreateTime.ToShortTimeString()%> 
            </div>
            <%=item.Content%>
            <% if (Request.IsAuthenticated) { %><div class="admin"><%:Html.ActionLink(ResourceString.Edit, "Edit", "Resource", new {id = item.Id}, new {Class= "admin-action"})%></div><% } %>
        </div>
        <div class="tag-container">
            <%
               var tagList = item.Tags;
               foreach (var tag in tagList)
               {
            %>
            <div class="tag-row">
               <a href="<%:Url.Action("ListByTag", "Resource", new {tagName = tag.Name})%>"> <span class="tag-name"><%: tag.Name %></span></a>
            </div>
            <%} %>
        </div>        
        <span class="break"></span>
    </div>
<% } %>
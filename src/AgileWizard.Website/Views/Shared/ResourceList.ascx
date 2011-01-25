<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AgileWizard.Website.Models.ResourceList>" %>
<%@ Import Namespace="AgileWizard.Domain.Services" %>
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
                    <div class="counts"><%=ServiceGateway.ResourceService.GetResourceCounter(item.Id, "PageView") %></div>
                    <div class="actionResult"><%=ResourceString.PageView%></div>
                </div>
                <div class="counter unlike">
                    <div class="counts">1</div>
                    <div class="actionResult"><%=ResourceString.Unlike%></div>
                </div>
                <div class="counter like">
                    <div class="counts">10</div>
                    <div class="actionResult"><%=ResourceString.Like%></div>
                </div>
            </div>
            <h2>
                <a href="<%:Url.Action("Details", "Resource", new {id = item.Id})%>"><%:item.Title%></a>
            </h2>
            <div class="time">
                &copy; <a href="" title="<%:item.Author%>"><%:item.Author%></a> / 
                <%:item.CreateTime.ToString("yyyy.MM.dd")%> / <%:item.CreateTime.ToShortTimeString()%> / 
                <%
       if (item.Tags.Count > 0)
       {%><a href=""><%:item.Tags[0].Name%></a><%
       }%>
            </div>
            <%=item.Content%>
            <% if (Request.IsAuthenticated) { %><div class="admin"><%:Html.ActionLink(ResourceString.Edit, "Edit", "Resource", new {id = item.Id}, new {Class= "admin-action"})%></div><% } %>
        </div>
        <span class="break"></span>
    </div>
<% } %>
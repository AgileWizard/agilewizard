<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AgileWizard.Website.Models.ResourceList>" %>
<link href="../../Content/Resource.css" rel="stylesheet" type="text/css" />
<% foreach (var item in Model) { %>
    <div class="resource-item">
        <div class="thumbs">
            <a href="<%: Url.Action("Details", "Resource", new { id = item.Id }) %>">
                <img src="<%= item.ImageUrl ?? Url.Content("~/Content/Images/default_resource_icon.jpg") %>" width="125px" />
            </a>
        </div>
        <div class="indexs">
            <div class="counters">
                <div class="counter pageview">
                    <div class="counts">20</div>
                    <div>点击</div>
                </div>
                <div class="counter unlike">
                    <div class="counts">1</div>
                    <div>踩</div>
                </div>
                <div class="counter like">
                    <div class="counts">10</div>
                    <div>顶</div>
                </div>
            </div>
            <h2>
                <a href="<%: Url.Action("Details", "Resource", new { id = item.Id }) %>"><%: item.Title %></a>
            </h2>
            <div class="time">
                &copy; <a href="" title="<%: item.Author %>"><%: item.Author%></a> / 
                <%: item.CreateTime.ToShortDateString() %> / <%: item.CreateTime.ToShortTimeString() %> / 
                <% foreach (var tag in item.Tags) { %><a href=""><%: tag.Name %></a> / <% } %>
            </div>
            <%= item.Content %>
        </div>
        <span class="break"></span>
    </div>
<% } %>
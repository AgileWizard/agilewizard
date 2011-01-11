<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AgileWizard.Website.Models.ResourceList>" %>
<link href="../../Content/Resource.css" rel="stylesheet" type="text/css" />
<% foreach (var item in Model) { %>
    <div class="resource-item">
        <div class="thumbs">
            <a href="<%: Url.Action("Details", "Resource", new { id = item.Id }) %>">
                <img src="" width="125px" />
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
                &copy; <a href="" title="<%: item.SubmitUser %>"><%: item.SubmitUser %></a> / 
                <%: item.CreateTime.ToShortDateString() %> / <%: item.CreateTime.ToShortTimeString() %> / 
                <%  if (!string.IsNullOrEmpty(item.Tags)) { foreach (var tag in item.Tags.Split(',')) { %><a href=""><%: tag %></a> / <% }} %>
            </div>
            <%= item.Content %>
        </div>
        <span class="break"></span>
    </div>
<% } %>
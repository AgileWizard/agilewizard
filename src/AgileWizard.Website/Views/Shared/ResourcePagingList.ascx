<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<AgileWizard.Website.Models.ResourceListViewModel>>" %>
 <h2>
        <%: ResourceString.Resources%></h2>
        <%if (Request.IsAuthenticated) {%>
        <p>
        <%: Html.ActionLink(ResourceString.CreateResourceLink, "Create", "Resource", new { @class="link", @id="create_link"})%>
        </p>
        <%}%>
    <div id="resource-list-container"><%: Html.Partial("ResourceList", Model) %></div>
    <div id="more-area" class="hidden" align="center">
        <img src="<%=Url.Content("~/Content/Images/ajax-loader.gif") %>" alt="More" />
        <input type="button" id="more" value="More" class="hidden" /></div>
    <script type="text/javascript" language="javascript">
        <%var nTicks = (long)ViewData["ticksOfLastCreateTime"]; %>
        $(function () {
            $('#more').click(function () {
                $.get('/Resource/ResourceList', {ticksOfLastCreateTime:<%=nTicks %>}, function(data){
                    $('#resource-list-container').append(data);
                    $("#more-area").hide();

                });
            });
            $(window).scroll(function(){
                if ($(window).scrollTop() >= $(document).height() - $(window).height() - 100){
                    $("#more-area").show();
                    $("#more").click();
                }
            });
        });
    </script>
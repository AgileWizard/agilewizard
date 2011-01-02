<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript" src="/scripts/tiny_mce/jquery.tinymce.js"></script>
<%
    var scriptUrl = UrlHelper.GenerateContentUrl("~/scripts/tiny_mce/tiny_mce.js", ViewContext.HttpContext);
%>
<script type="text/javascript">
    $().ready(function () {
        $('textarea.tinymce').tinymce({
            script_url: '<% =scriptUrl%>',
            theme: "advanced",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,
            content_css: "css/content.css",
            language: "zh"
        });
    });
</script>

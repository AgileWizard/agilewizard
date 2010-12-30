<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AgileWizard.Website.Models.ResourceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ResourceString.CreateResourceTitle %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="<%=Url.Content("~/scripts/tiny_mce/jquery.tinymce.js") %>"></script>
<script type="text/javascript">
    $().ready(function () {
        $('textarea.tinymce').tinymce({
            // Location of TinyMCE script
            script_url: '<%=Url.Content("~/scripts/tiny_mce/tiny_mce.js") %>',

            // General options
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,advlist",

            // Theme options
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
            content_css: "css/content.css",

            // Drop lists for link/image/media/template dialogs
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js",

            language: "zh"
        });
    });

</script>
    <h2>
        <%: ResourceString.Create %></h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend><%: ResourceString.CreateResourceTitle %></legend>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Title) %>
            <%: Html.ValidationMessageFor(m => m.Title) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Author) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Author)%>
            <%: Html.ValidationMessageFor(m => m.Author)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.ReferenceUrl) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.ReferenceUrl) %>
            <%: Html.ValidationMessageFor(m => m.ReferenceUrl) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Content) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(m => m.Content, new {rows=15, cols=60, Class="tinymce" })%>
            <%: Html.ValidationMessageFor(m => m.Content)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(m => m.Tags) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(m => m.Tags)%>
            <%: Html.ValidationMessageFor(m => m.Tags)%>
        </div>
        <p>
            <input type="submit" value="<%: ResourceString.Save %>" />
        </p>
    </fieldset>
    <div>
        <%:Html.ActionLink(ResourceString.BackToResources, "Index") %>
    </div>
    <% } %>
</asp:Content>

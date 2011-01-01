using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AgileWizard.Website.Helper
{
    public static class EditorExtensions
    {
        public static MvcHtmlString HtmlEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel,TProperty>> expression, object htmlAttributes)
        {
            var textAreaHtml =  htmlHelper.TextAreaFor(expression, htmlAttributes);
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendFormat(@"<script type=""text/javascript"" src=""{0}""></script>",
                                     UrlHelper.GenerateContentUrl(@"~/scripts/tiny_mce/jquery.tinymce.js",
                                                                  htmlHelper.ViewContext.HttpContext));
            htmlBuilder.AppendLine();
            htmlBuilder.AppendLine(@"<script type=""text/javascript"">");
            htmlBuilder.AppendLine(@"	$().ready(function () {");
            htmlBuilder.AppendLine(@"       $('textarea.tinymce').tinymce({");
            htmlBuilder.AppendFormat(@"         script_url: '{0}',", UrlHelper.GenerateContentUrl(@"~/scripts/tiny_mce/tiny_mce.js", htmlHelper.ViewContext.HttpContext));
            htmlBuilder.AppendLine();
            htmlBuilder.AppendLine(@"           theme: ""advanced"",");
            htmlBuilder.AppendLine(@"			plugins: ""pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,advlist"",");
            htmlBuilder.AppendLine(@"			theme_advanced_buttons1: ""save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect"",");
            htmlBuilder.AppendLine(@"			theme_advanced_buttons2: ""cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor"",");
            htmlBuilder.AppendLine(@"			theme_advanced_buttons3: ""tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen"",");
            htmlBuilder.AppendLine(@"			theme_advanced_buttons4: ""insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak"",");
            htmlBuilder.AppendLine(@"			theme_advanced_toolbar_location: ""top"",");
            htmlBuilder.AppendLine(@"			theme_advanced_toolbar_align: ""left"",");
            htmlBuilder.AppendLine(@"			theme_advanced_statusbar_location: ""bottom"",");
            htmlBuilder.AppendLine(@"			theme_advanced_resizing: true,");
            htmlBuilder.AppendLine(@"			content_css: ""css/content.css"",");
            htmlBuilder.AppendLine(@"			template_external_list_url: ""lists/template_list.js"",");
            htmlBuilder.AppendLine(@"			external_link_list_url: ""lists/link_list.js"",");
            htmlBuilder.AppendLine(@"			external_image_list_url: ""lists/image_list.js"",");
            htmlBuilder.AppendLine(@"			media_external_list_url: ""lists/media_list.js"",");
            htmlBuilder.AppendLine(@"           language: ""zh""");
            htmlBuilder.AppendLine(@"		});");
            htmlBuilder.AppendLine(@"	});");
            htmlBuilder.AppendLine(@"</script>");
            htmlBuilder.AppendLine(textAreaHtml.ToHtmlString());
            return MvcHtmlString.Create(htmlBuilder.ToString());
        }
    }
}
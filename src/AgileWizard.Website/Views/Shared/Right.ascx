<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<link href="../../Content/Tag.css" rel="stylesheet" type="text/css" />
<div class="partnerLogo">
    <div class="logoText">
        Agile tour</div>
    <div class="logoPic">
        <a href="http://www.agiletour.org/" target="_blank">
            <img src="http://www.agiletour.org/sites/default/files/agilii_logo.jpg" alt="Agile tour" /></a></div>
    <div class="at-language">
        <ul>
            <li><a href="http://www.agiletour.org/cn" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/zh-hans.png" alt="" />
            </a></li>
            <li><a href="http://www.agiletour.org/br" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/pt-br.png" alt="" />
            </a></li>
            <li><a href="http://www.agiletour.org/en" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/en.png" alt="" />
            </a></li>
            <li><a href="http://www.agiletour.org/fr" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/fr.png" alt="" />
            </a></li>
            <li><a href="http://www.agiletour.org/lt" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/lt.png" alt="" />
            </a></li>
            <li><a href="http://www.agiletour.org/es" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/es.png" alt="" />
            </a></li>
            <li><a href="http://www.agiletour.org/ja" class="">
                <img src="http://www.agiletour.org/modules/i18n/flags/ja.png" alt="" />
            </a></li>
        </ul>
    </div>
</div>
<div class="partnerLogo" style="height:150px">
    <div class="logoText">
        Scrum Alliance</div>
    <div class="logoPic">
        <a href="http://www.scrumalliance.org/" target="_blank">
            <img src="http://www.scrumalliance.org/images/scrum_logo.png?1298485545" alt="Scrum Alliance" /></a></div>
</div>
<div class="tag-list">
    <%
        var tagList = TagsHelper.GetTagList(20);
        foreach (var tag in tagList)
        {
    %>
    <div class="tag-row">
        <a href="<%: Url.Action("ListByTag", "Resource", new {tagName =tag.Name}) %>"><span
            class="tag-name">
            <%: tag.Name %></span></a> <span>×
                <%: tag.TotalCount %></span>
    </div>
    <%} %>
</div>

Feature: Add Resource
	As a admin, 
	I should be able to record the title, content and author

Scenario Outline: add resource
	Given new resource with  title - <title> and content - <content> and author - <author> and tags - <tags> and reference url - <referenceurl>
	When submit resource to system
	Then navigate to details page

	Examples:
	|   title                            |  author        | tags                              | referenceurl                               |  content  |
	| simple Resource            | Test Author |  Agilewizard,Shanghai  | http://www.cnblogs.com/tengzy/ |  simple Content  |
	| embed video Resource  | Test Author |  Agilewizard,Shanghai  | http://www.cnblogs.com/tengzy/ |  @"<embed src=""http://player.youku.com/player.php/sid/XMjI2MjI2MTQw/v.swf"" quality=""high"" width=""480"" height=""400"" align=""middle"" allowScriptAccess=""sameDomain"" type=""application/x-shockwave-flash""></embed>"   |
	
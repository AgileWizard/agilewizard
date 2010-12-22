Feature: Add Resource
	As a admin, 
	I should be able to record the title, content and author

Scenario: Add plain text resource
	Given new resource with  title - 'plain text Resource' and content - 'simple Content' and author - 'Test Author' and tags - 'Agilewizard,Shanghai'
	And reference url - 'http://www.cnblogs.com/tengzy/'
	When submit resource to system
	Then navigate to details page
	And display the title, content, author and submit user and tags

# expect specFlow.Net table feature
@ignore
Scenario: Add video resource
	Given new resource with  title - 'embed video Resource'
	And content -  @"<embed src=""http://player.youku.com/player.php/sid/XMjI2MjI2MTQw/v.swf"" quality=""high"" width=""480"" height=""400"" align=""middle"" allowScriptAccess=""sameDomain"" type=""application/x-shockwave-flash""></embed>" 
	And author - 'Test Author'
	When submit resource to system
	Then resource will be persisted
	And navigate to details page

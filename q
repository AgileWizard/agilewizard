[33mcommit 8946b18ed80e283438af5d64f73952e9752ea274[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 16 09:49:30 2011 +0800

    try to fix build, use the absolute path instead

[33mcommit 569410cb9e01a6e189049b724c7b0a03e37acabe[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 16 00:47:37 2011 +0800

    added publish task to deploy

[33mcommit 8723ebc088c159958b2607d49809c940b4562819[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 16 00:41:07 2011 +0800

    Added deploy script and adjust the reference strategy for rake

[33mcommit 5f58d8a97edeb096e36c1888e2203b72cf4646ba[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Jan 15 23:00:41 2011 +0800

    Call msbuild task to build deployment package
    
    In output files, you can deploy it to IIS directory

[33mcommit 8fab89f4a858ddb389ca5f61a7841902a690608b[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Sat Jan 15 16:55:31 2011 +0800

    Use resource list user control in resource list page

[33mcommit 0549d76a1496b9b7c95b7ebc1bde78e8fd3646ee[m
Merge: 596f591 b209e38
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Fri Jan 14 17:14:20 2011 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 596f591d3218fb1ce42db338aaabd01e53d7f143[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Fri Jan 14 17:13:27 2011 +0800

    Fixed edit resource IT.
    
    Removed private fields in resource steps definition, use scenario context instead.

[33mcommit b209e38ff9e94d2b874b491703ea9d7060344d63[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Fri Jan 14 17:12:54 2011 +0800

    Tag list style

[33mcommit 58864bec301a21f0c3fa212f795628385d9cff60[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Fri Jan 14 15:59:56 2011 +0800

    Add translation for like,unlike&pageview;Add just style for resource list;Only display one tag in resourcelist

[33mcommit 13c3e5c4362b652e582cf3b1bde794deeb4e8a92[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Fri Jan 14 13:46:38 2011 +0800

    Adjust resource list style in IE;Add min height for main div in site.master

[33mcommit b16e1bc86d762ee56f6499455134a55ad52fda5f[m
Merge: 7fded20 b6f17e0
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Fri Jan 14 09:53:39 2011 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit b6f17e03e5092a95afcdf1f2461beecee862697f[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Jan 13 20:50:04 2011 +0800

    According to Ayende's comments, change tag sorting from Map-Reduce index to query (c# code)

[33mcommit 2390ef2093117891bcc25f9d0ee5ab872140ced4[m
Merge: e2e634b c4b0d4c
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Jan 13 18:45:57 2011 +0800

    remove account feature AT

[33mcommit c4b0d4c685c7dfae3d7eddb9d396d4174c9e24e6[m
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Jan 13 18:32:47 2011 +0800

    remove account feature AT

[33mcommit e2e634bc89b92cdc7f5f46d1cb1dd4657a0ff7f2[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Jan 13 18:28:42 2011 +0800

    ignored edit resoure IT for future refactoring

[33mcommit d6f8ed674e4b94a27e6e5d37f2534152a1093eb6[m
Merge: b50f7c6 09e07d1
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Jan 13 18:05:42 2011 +0800

    Merge branch 'master' into refactor-IT

[33mcommit b50f7c69a6eb4a39886e1730e932abae8fc82ee5[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Jan 13 18:02:22 2011 +0800

    refactored add resource IT, extract IntegrationTestBase to wrap assert controller and action behavior

[33mcommit 09e07d1855e58f465c7229eb4e987edc38081dd5[m
Merge: 67a6e1f 81a862b
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Jan 13 17:23:21 2011 +0800

    Merge branch 'work'

[33mcommit 81a862b165c4ef769f4f191c80563aff1fae3404[m
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Jan 13 17:19:31 2011 +0800

    sg=complete resource feature acceptance test refactoring

[33mcommit 67a6e1fa1276addc056a756eb2c5b14546883fc8[m
Merge: 2433dc0 ea1f7a9
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Jan 13 15:57:19 2011 +0800

    Merge branch 'master' into refactor-IT

[33mcommit 2433dc0d29c0554c67bd1f860d525df56d80a84f[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Jan 13 15:55:08 2011 +0800

    refactored account IT, now support Scenario Outline

[33mcommit 7fded202f770c65c6581863ca8bc011f9af08d35[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Thu Jan 13 15:32:55 2011 +0800

    Finish test for fetch image url from content

[33mcommit ea1f7a97575e1a55da8f1458ad342db0a195f795[m
Merge: 2079f9d f2a7eb6
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Jan 13 14:57:42 2011 +0800

    Merge branch 'work'

[33mcommit f2a7eb684d01703e0165aa8f8c8fa1d38786eae7[m
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Jan 13 14:47:29 2011 +0800

    sg=Refactor page objects and resource AT feature

[33mcommit 2079f9dc4dc142a98032255b051816d37307908d[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Jan 12 20:35:37 2011 +0800

    Add taglist feature and show tag list in page without style

[33mcommit 85040e7817d20d93ad0ac92b5e94e16d5b17f692[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Jan 12 18:46:23 2011 +0800

    Introduce AutoMapper;Add default resource icon for resource list

[33mcommit 6a761511899b9c243fc46f1f13ecf9a612fe4c78[m
Merge: fc689eb 390d335
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Jan 12 02:29:30 2011 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard
    
    Conflicts:
    	src/AgileWizard.IntegrationTests/AgileWizard.IntegrationTests.csproj

[33mcommit fc689eb36aa290c9a5dddb7ffc84aeca60f2c165[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Jan 12 02:14:00 2011 +0800

    Use aggregate index for TagList

[33mcommit 390d3352062241ff3a0d0f6457d8c53d2df998fd[m
Merge: 0d7f781 9474800
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Jan 12 00:13:20 2011 +0800

    Merge branch 'master' into refactor-IT

[33mcommit 0d7f7815035ef738e25614bb4f726708f6da5314[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Jan 12 00:09:25 2011 +0800

    refactored account successful login IT

[33mcommit 94748008e4b65b682b525ec8a16e24f841787e07[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Tue Jan 11 23:48:07 2011 +0800

    Refactor excerpt utility;Add UT for excerpt utility

[33mcommit 5bae5fd06b720673f21a35921694d1ab3bacb117[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Tue Jan 11 18:38:14 2011 +0800

    Excerpt content

[33mcommit 9c7dd92f0ecb7eafe3875423f0d0d7f6d44ee562[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Tue Jan 11 13:53:38 2011 +0800

    Add skeleton and style for couters in resource list

[33mcommit d48cfac030cdaf97b46946631c3241a2ee7703fc[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Mon Jan 10 17:49:52 2011 +0800

    Implement skeleton style of resource list control

[33mcommit 27bb2408ba44c9c86071ab97c8cec2d998ae067a[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Jan 5 20:54:05 2011 +0800

    Refactored Resource & Tag Model

[33mcommit 663371e494e9e0de2c97f8f18edbfcd7d2fcb845[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Tue Jan 4 21:38:33 2011 +0800

    Renamed Domain.Resources folder to Domain.Models

[33mcommit 79ebd14fa740ba67f270702645b462787f53b6e5[m
Merge: 10fdb56 3ac2e66
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Mon Jan 3 12:49:20 2011 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 3ac2e6665163226a309cde6a1025bec2a16752ad[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Mon Jan 3 12:40:26 2011 +0800

    fixed the display issue in IE6

[33mcommit 10fdb565baa841cbd6bfe3711148c0fdee88aeb4[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Sun Jan 2 20:16:26 2011 +0800

    Refactored HtmlEditor to show less icons

[33mcommit 807647d13ffae8a8aa5000e63446e0cd8bce406d[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Sun Jan 2 18:20:17 2011 +0800

    Changed AT to set TextField text instead of type-in. Before this change, AT took 58 seconds. After this change, AT takes 39 seconds.

[33mcommit 37d817fadf3aa61f1ac8a882439fc8cdb76bf240[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 2 10:11:43 2011 +0800

    correct the layout for resource list after adding the right control

[33mcommit 189a17831e78271cf4ddbf6da7e807518724b581[m
Merge: 58f624e a4c7edd
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 2 00:15:37 2011 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 58f624e31757f05426561a092fbe90480643587d[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 2 00:14:25 2011 +0800

    change the font family

[33mcommit f6f86deb4caa2549808839dd873f05386b8adfbe[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Jan 2 00:12:18 2011 +0800

    Adjust user interface for master page

[33mcommit a4c7edd2d824de3fe286ade6fc1e9db6bc74b3e6[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sat Jan 1 23:39:15 2011 +0800

    show/hide create and edit link based on whether the visitor is authenticated

[33mcommit a924fa98330b8362114398c8203eb730dc8363cd[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sat Jan 1 20:01:04 2011 +0800

    moved all user authentication logic to userauthenticationservice, simplified accountcontrol login logic

[33mcommit 36ea706df3531b0fabc23689c53f46397ee13324[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Fri Dec 31 10:52:00 2010 +0800

    Add editor helper namespace to web.config

[33mcommit d2d5b1f0609a466addcab7bd57b7d5f8d768ee2e[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Fri Dec 31 00:16:14 2010 +0800

    Add helper for html editor

[33mcommit 4086668a4462aadead4bddb93f4a31576605e681[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Thu Dec 30 19:36:55 2010 +0800

    Change AT to use TinyMCE

[33mcommit 8f58618c99a091fc42bfe938d195f94285ba9bcb[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Thu Dec 30 16:45:04 2010 +0800

    Add TinyMCE

[33mcommit 461b64a71523c1d4047369e5b5f3f4c0336381f1[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 23 22:48:04 2010 +0800

    Refactored ResourceSteps by avoid saving data in scenario context

[33mcommit b78997c5706f5900ee5d2ca0c4be0debe7f75617[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 23 21:24:10 2010 +0800

    Refactored Resource Acceptance Test by using table to specify data

[33mcommit b3b054f5dd123af4ec977604e746207d3da82ecc[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 23 21:02:14 2010 +0800

    Corrected typo in ResourcePage class

[33mcommit e1bf89900036d5c0e3deba209d7f996429c751e2[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 23 20:58:37 2010 +0800

    Renamed classes under steps folder to end with steps

[33mcommit 00a4775e6d4a460528db24f6c3ab9878cb78b3c1[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 23 20:54:08 2010 +0800

    Removed @UI tag in Acceptance Test

[33mcommit 92a7213f7994860d40769c7005773fea3e91dbf6[m
Merge: 712322d 421fc25
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Dec 22 23:38:05 2010 +0800

    merged with master, refactored reference url to page objects

[33mcommit 712322dde1bbb8637b2eabfe4eadb2ed3f78577e[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Dec 22 17:42:36 2010 +0800

    refactored resource AT, created page objects for resource list, detail page

[33mcommit 421fc25b03e0444ec2d4cd0a21c9fbeeea8f0aae[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 22 01:16:19 2010 +0800

    Add IT for edit a resource;Implement editing resours's tag

[33mcommit 828f2a9d5fa2dcd39ddda6894459e863db4807cf[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Tue Dec 21 00:22:54 2010 +0800

    Display reference url in detail page and added update mode supporting

[33mcommit 5ad12072fa90f0001c0b8ab09e2ff5850b42dbc8[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Tue Dec 21 00:00:37 2010 +0800

    Added reference url field to resource and implemented Create Resource page AT, IT and UT

[33mcommit 9dd53751f69a71d14d7b9c57b1eb60720df59f58[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Dec 19 14:00:18 2010 +0800

    Added some tag logic

[33mcommit 5acdec0768efffec2ab2e4b1cbd7072f0c7272f9[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Dec 19 13:39:23 2010 +0800

    refactor resource tags AT

[33mcommit 49884ef49cff0e1d00334b8fcc58608619cbfdba[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Dec 18 16:24:18 2010 +0800

    refactor ResourcePage for removing some duplicated codes

[33mcommit 929ef66cb374a795da3b6450ba716fd0f730f7de[m
Merge: 1f6ae1b 67df833
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Fri Dec 17 23:39:20 2010 +0800

    merge with main branch

[33mcommit 67df833cfa263f3706c2f8f3b807b32771a2d7ce[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Fri Dec 17 23:24:24 2010 +0800

    refactored resource add feature, now we have resourcepage object

[33mcommit 1f6ae1baa7a7862cc756a9c56694052cd15afd74[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Wed Dec 15 20:02:36 2010 +0800

    add tags to resource.

[33mcommit 9eab2c7bcbee69dade3cc2f5bc6625967808689d[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Wed Dec 15 19:07:06 2010 +0800

    Move the domain objects to folders name more domain specified.

[33mcommit bd8406818b599af5b15161159a97d49f700ada10[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Dec 15 17:02:15 2010 +0800

    cleaned up resource acceptance test features

[33mcommit 5b57f02a924ed4482d3b35094e7e86181cec26c1[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Dec 15 00:12:56 2010 +0800

    removed wait custimization from ravendb query

[33mcommit be1af8f1f41475e863691432e8232f34368ad79e[m
Merge: 4f02391 e9755d4
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Dec 14 12:05:39 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit e9755d49ada178cc2e5eb7cc7d9eedc4e20a6d3c[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Tue Dec 14 01:09:52 2010 +0800

    correct the project file to fix build

[33mcommit a033130692b83d8811b6dc7ed0b6f45d30e2054c[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Tue Dec 14 01:05:04 2010 +0800

    save submit user value when create / edit and display it in detail page
    
    removed StateRepository class and added SessionStateRepository with interface to support require authentication attribute

[33mcommit 4f02391cfe325f3342db099888f8a3c87608d047[m
Merge: 41d31a0 5a28d7b
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Mon Dec 13 11:21:14 2010 +0800

    merge with master

[33mcommit 5a28d7ba06fea4c8a295bb480bd52bfd90819a1e[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Dec 12 23:24:14 2010 +0800

    Open logon page if wants to create/edit resource when you have not login already

[33mcommit 2fc43a4080edfe6e55eb4b166d61fda31bfaf8d3[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Sun Dec 12 19:15:47 2010 +0800

    Refactored Resource pages translation

[33mcommit a1c1e61ddde0f30d78acbd78726c51e5a2ce8a4d[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Dec 12 18:16:23 2010 +0800

    delete the dll output directory instead of bin before building

[33mcommit 41d31a0795b6beb4e4169f2b19b4f97e29598598[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sun Dec 12 17:31:51 2010 +0800

    change teamcity.rb, now only remove dlls in OUT_DLL_DIR folder instead of OUTPUT_DIRECTOR to avoid conflicting with IDE build

[33mcommit 8004b4d6457a73ae5ee70c48e85245b1b1747789[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Sun Dec 12 16:57:07 2010 +0800

    Refactored translation solution
    Translated Logon page, Home page and About page

[33mcommit f9d6b2d4018fbcf2b910b9a873bf9b6556142ad5[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sun Dec 12 16:58:51 2010 +0800

    fixed build, ignored new added embeded video add scenario Integration test

[33mcommit 2213e0a326c60aa7b56cb8d2987627093adecf62[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sun Dec 12 16:52:02 2010 +0800

    refactored resource AT, combined view detail step into one

[33mcommit 701220df875c2f601ddd6a2be9d9b0335bbf42b7[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Dec 11 23:28:36 2010 +0800

    Show resource list page title in current culture and refactor some UI of this page

[33mcommit 937d7b36cba7be55d219e565109c855d9f1285fc[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Sat Dec 11 14:40:49 2010 +0800

    Redirect to details page after creating or editing a resource

[33mcommit 86008f0ab163fc3766f7ff2fc691fa397de9a3c0[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sat Dec 11 00:35:27 2010 +0800

    add author to resource

[33mcommit c63294730b06089329bf22c39d525b33e2b01378[m
Author: lidingshan <lidingshan@gmail.com>
Date:   Thu Dec 9 22:24:55 2010 +0800

    Update code to display all of the LogOnModel properties' label in Chinese on Logon page

[33mcommit dfafc689e24da5c2084f7cf2172ca3052df6f7c3[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Thu Dec 9 12:40:32 2010 +0800

    Implement submitting a modified resource

[33mcommit 197ace34c0479b5831314b87a03bbcde2c7ec069[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Dec 9 00:24:42 2010 +0800

    Show the current culture characters for resource list page

[33mcommit f81a8247c90b4f651eafdf908cd63f8dad451320[m
Merge: 59dd531 f56ddc9
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 8 18:02:08 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 59dd5310e68bc913004aacf8616d1e1bcc9b8a1b[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 8 18:01:58 2010 +0800

    Add an edit view for resource

[33mcommit f56ddc91bc97300be78fbb68222f12529c4c347f[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Dec 8 17:43:31 2010 +0800

    set culture in web.config instead of in code

[33mcommit dce43b697603d700648eb09f0480e3a163162fa1[m
Merge: 2748f9c 2ed1d3d
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Wed Dec 8 09:57:08 2010 +0800

    deleted albacore local built gem

[33mcommit 2ed1d3d0abe41e9eea6b1ef49dc0de505c3031da[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Wed Dec 8 09:49:50 2010 +0800

    added locale test assembly for xunit test

[33mcommit 2748f9cef853933bb25b498063dae3f51395610b[m
Author: lidingshan <lidingshan@gmail.com>
Date:   Tue Dec 7 23:25:01 2010 +0800

    Be able to display user name label in Chinese for LogOnModel

[33mcommit cd20be43b309375dedc0081f6a7f3bf8f01eea10[m
Author: lidingshan <lidingshan@gmail.com>
Date:   Mon Dec 6 22:58:37 2010 +0800

    Change default language to be in Chinese

[33mcommit 811f2b71843b2586d5d816abcc9f90144244a70c[m
Author: Mike Li <lidingshan@gmail.com>
Date:   Mon Dec 6 22:49:06 2010 +0800

    Create AgileWizard.Locale assembly and its tests

[33mcommit bc833f977f3bfec0ae950b2a5ca5eede1d1bb328[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Dec 5 14:33:34 2010 +0800

    Added Integration Test to xunit task and added some readme information

[33mcommit 982fda5b6ccbd0a645f5312446819f38109ba86f[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Dec 5 09:48:22 2010 +0800

    Added albacore 0.2.0 gem and modified teamcity.rb

[33mcommit 490a51f523d8996e3b1b535fe1719a8d1ccba605[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Dec 4 21:35:35 2010 +0800

    added bat file for running rake script in command line mode

[33mcommit 9e0d885853077b7fd6139965f7ccd61237226a50[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Sat Dec 4 16:18:10 2010 +0800

    Add resource controller test

[33mcommit 0807b951caba9271cf8479931190e4c0690e5679[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Dec 2 23:41:22 2010 +0800

    refactor UserRepositoryTest based on the new test strategy what is using moq instead of memory ravendb

[33mcommit 2b5c916460325347929e7d3d85638c52aa5be75f[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 20:15:56 2010 +0800

    add AT for story US12 - "As a visitor, I want to see list of resources"
    include the # of resources

[33mcommit 411595cbf7f20cfb7d9d6c16ad77d7587754e886[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 19:54:23 2010 +0800

    1. fix new added resource won't show up in the resource index page.
    2. add total count to resource list page.
    3. fix RavenDBHelper when call Customize the return turns out to be null.

[33mcommit ace42a113fdcd2fd9ac999d82ec4c67cb8374b14[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 18:35:27 2010 +0800

    add repository method and UT to query resource count.

[33mcommit 3852eda4d803c059d73327f93bf582607afe7423[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 18:19:22 2010 +0800

    When call the query result multiple times, the result will be empty after the fist time.
    Add a closure to it and fix it.

[33mcommit e9bd9e1d60a649c010f4cdd18299027e513cf1a5[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 2 17:31:19 2010 +0800

    renamed User feature to Account feature, and corrected Resource feature name

[33mcommit 6d394648e726fcf8bf061866421e65e41dc3ccc7[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Dec 2 17:17:24 2010 +0800

    Added Integration test project and add one scenario, move datamanager into a new project

[33mcommit f8891062fd4b6e025ca20d9b4fe159e8ce9ce79e[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 17:00:52 2010 +0800

    refactor ResourceRepositoryTest
    add helper method for easy mocking raven query by index.

[33mcommit 56de7f48b813c370b8accd0a7ffeaa9815466b27[m
Merge: 4d176a9 3975afa
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 16:12:00 2010 +0800

    Merge branch 'master' of git@github.com:AgileWizard/agilewizard.git

[33mcommit 4d176a91d3bfda85a1af23a191a997e12e5a4793[m
Author: Wen Shi <qw.shi@hotmail.com>
Date:   Thu Dec 2 16:11:17 2010 +0800

    change LuceneQuery to Query for get list of resources and change the unit test as well.

[33mcommit 3975afaf8b6559baebc942fc532e711467bf1b4d[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Dec 1 23:16:31 2010 -0800

    Modified README

[33mcommit 93998307c25dcff1490a38d9477a893791c5a31a[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Dec 1 21:56:41 2010 -0800

    Added msysgit comment into readme

[33mcommit 3a9436226ee9aa54f3919a65eb598d76ca75ec98[m
Merge: 70639e2 273c1bd
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Thu Dec 2 01:30:46 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard
    
    Conflicts:
    	src/AgileWizard.Domain.Tests/Services/ResourceService.cs
    	src/AgileWizard.Domain.Tests/Services/ResourceServiceTest.cs

[33mcommit 70639e2b0efbf3c304f69ce9fa20e0513ed8972a[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Thu Dec 2 01:19:11 2010 +0800

    Refactor resource ut

[33mcommit 273c1bdd3fcb54b8172dacf45f72189428ad3eff[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Dec 2 00:57:24 2010 +0800

    temp solution for fixing the build

[33mcommit 16eb2849a1fd6cadba9a77128efc1ef626287d17[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Dec 2 00:19:15 2010 +0800

    Fixed UT 'when_user_exists_return_the_user' & removed references between test projects.

[33mcommit e3bea3d3a8104c04547e14729712129e7523c14f[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 1 15:56:44 2010 +0800

    Refactor resource controller using ResourceService.Not done yet

[33mcommit 84b3858a443b377c1fc8a22b5972518a072afada[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 1 14:55:01 2010 +0800

    Refactor domain test project

[33mcommit 06bf66c81ce664eafe9c66b54284a5ec36ecf077[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 1 14:41:15 2010 +0800

    Refactor domain project

[33mcommit dc52cd4753af6e3115d9862219d5e70b2e39b080[m
Merge: c07da28 584bbdf
Author: unknown <limi@.ads.autodesk.com>
Date:   Wed Dec 1 13:24:00 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 584bbdf1490cfdc62ad1b943d2a51183885a8ab3[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Wed Dec 1 11:44:13 2010 +0800

    Finish view resource details acceptance test

[33mcommit c07da28d91bb6f1d8e7fb69fb2c9b0aaef39e28a[m
Author: Mike Li <lidingshan@gmail.com>
Date:   Tue Nov 30 23:25:35 2010 +0800

    Change UerAuthentication to be UserAuthentication for good naming convension

[33mcommit 35e580a3681de4c56156f038b5be1672273a5c54[m
Merge: b7bdd66 f8e333f
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 30 20:57:59 2010 +0800

    merge with remote master

[33mcommit f8e333fc276930486a3f555a29fdc507eb77315e[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Tue Nov 30 19:44:06 2010 +0800

    Ignore non-implemented "resource" test

[33mcommit 6cd0b5fb4c5f7244a39b3c1cf78dc23f07411814[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Tue Nov 30 17:49:50 2010 +0800

    Implement view resource detail

[33mcommit b7bdd66d7dfb163638ccb82727b50c085764e9cf[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 30 16:24:23 2010 +0800

    resourcecontroller now talk to resourcerepository

[33mcommit fafaa1f52c9870dd643239ded4e3ca54ebbbb97d[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 30 15:51:12 2010 +0800

    added resourcerepository and refactored out resourcetesterbase

[33mcommit a5d742361b3379fa714730fef00b45e10a104a53[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Mon Nov 29 23:45:40 2010 +0800

    remove mvc project test from teamcity.rb

[33mcommit 5233aabd0517ea1d9a23e4dbbb237feed554ee05[m
Merge: e44cd33 478013e
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Mon Nov 29 23:40:30 2010 +0800

    merge with remote master

[33mcommit e44cd33b5b5c88be897ee8155d878827e90b81f9[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Mon Nov 29 23:13:06 2010 +0800

    moved biz logic from controller to domain, add behavior test for controllers

[33mcommit 478013e2988ff117840143444729d62ce020cc0c[m
Author: Wen Shi <qinwen.shi@gmail.com>
Date:   Mon Nov 29 13:57:34 2010 +0800

    fixed build

[33mcommit 1ec7fdc5b0a2be181a3c680faa67221b35010e10[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Mon Nov 29 00:50:28 2010 +0800

    Fixed solution file(Mvc.test.dll could not be built in msbuild mode before)

[33mcommit 788e9aeaa27c32441530a9b36e3fb44846f08f0d[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Mon Nov 29 00:34:34 2010 +0800

    removed one test which is failed sometime and added xnunit tasks to run all the tests in teamcity while removed ncover

[33mcommit fb7cc516b988e140babe8140bc85861daec47e4d[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Mon Nov 29 00:25:52 2010 +0800

    fix build

[33mcommit f00dce0ddcbfc52b138f1099ef09194193eb2262[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sun Nov 28 23:11:43 2010 +0800

    change the output path for the two new added test projects

[33mcommit c93e15a76c8e61d11c62218ab616222b943fcd3d[m
Author: Jackson Zhang <zbcjackson@gmail.com>
Date:   Sat Nov 27 23:25:44 2010 +0800

    Refactor acceptance tests

[33mcommit 72fe7daeb584b1e64b8e4639edd892cf37065c93[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Fri Nov 26 19:27:54 2010 +0800

    merge website.test project with mvc.test project and moved unit test

[33mcommit dbca05b1fe1a9c60225122c797301cc14805223c[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Fri Nov 26 19:26:57 2010 +0800

    merge website.test project with mvc.test project and moved unit test

[33mcommit 1b25402295aee4a60492e0e76dacb6b2d389aaa0[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Nov 25 23:14:37 2010 +0800

    try to fix build

[33mcommit 343fa67779500961eafcfd63d56e27dd014466a9[m
Merge: 4554409 b42bce5
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Nov 25 22:35:50 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 45544094b47d84056bcb6e7bc475b38e45371338[m
Merge: ea2b346 7b2012c
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Thu Nov 25 22:34:45 2010 +0800

    moved password match logic to logonmodel, merge with Steven's change, need to push the logic down to domain layer; added MVC test project, will merge with website.test project

[33mcommit b42bce5711d1e3d1c528af4cec592f25f1cd9527[m
Author: unknown <limi@.ads.autodesk.com>
Date:   Thu Nov 25 21:43:50 2010 +0800

    Add introduction for development environment setup

[33mcommit 7b2012c4808024fc4c5bc72836554f56701e0c30[m
Merge: b4cd3a0 c86d72b
Author: nEo <zbcjackson@gmail.com>
Date:   Thu Nov 25 09:55:12 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit b4cd3a0e6c3c8ed6e3f66e48bed7424f4d0e81d4[m
Author: nEo <zbcjackson@gmail.com>
Date:   Thu Nov 25 09:52:25 2010 +0800

    Add modified albacore;Update README

[33mcommit c86d72b0a27b6ffc6ec58c6bde4f47f88411c731[m
Merge: 96b3fe1 d6f3a4e
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Nov 24 18:31:50 2010 +0800

    Merge branch 'master' of git@github.com:AgileWizard/agilewizard.git

[33mcommit 96b3fe1e7566c47ad85784e5cf57302b7bb18b7f[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Wed Nov 24 18:31:18 2010 +0800

    Added StructureMap into project
    Added UnitTest for AccountController
    Updated Moq to latest version
    
    - Reviewed by Wen

[33mcommit d6f3a4ea484072b07ab773efb22134713470af4d[m
Author: nEo <zbcjackson@gmail.com>
Date:   Wed Nov 24 17:36:29 2010 +0800

    Update rake file to use relative path;New albacore gem to specify the framework version

[33mcommit ea2b346d57450723409413cb3f16d41de1d1b2ee[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Nov 24 17:02:07 2010 +0800

    Merge branches 'master' and 'logoncontrollertest'

[33mcommit 4d24e18f9a330a77169ae9eb9ac2a410849ffbe9[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Nov 24 17:00:34 2010 +0800

    moved password match logic to LogOnModel

[33mcommit b17bba918de075d782d45d8fb8aa70104c5401d6[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Nov 24 16:08:19 2010 +0800

    upgrade Moq to latest version to fixed UT mocking issue caused by current version

[33mcommit ef6d07a7da3075e503d6d714028c645591beb17b[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Wed Nov 24 15:31:46 2010 +0800

    Renamed files under Tests project from Tester to Test

[33mcommit bd3b571a4c1ac5e001d21a4a4ca38545aad14308[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 23 23:02:27 2010 +0800

    fix build

[33mcommit b25e923f014d6f69e9752909b53634fa5d296675[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 23 22:41:43 2010 +0800

    extracted IUserRepository interface and applied in controller

[33mcommit 51f1b50a13049fadc44d84bbdacda937744419d8[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 23 16:30:06 2010 +0800

    renamed userrepositorytester to GetUserByNameTester

[33mcommit 93ab89eab9cb2456894cfc03d28c2d132c03b83c[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 23 16:04:59 2010 +0800

    make user repository more readable

[33mcommit 9f0f9d3b818f0777fdc9b3623e2413a5b820d1b5[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Tue Nov 23 15:28:46 2010 +0800

    hooked controller to userrepository, when no user found return empty user

[33mcommit 03ed14ee11b7d5c116943c838d1c6388312bfa77[m
Merge: 07bb2e4 6fc2fea
Author: nEo <zbcjackson@gmail.com>
Date:   Tue Nov 23 11:20:01 2010 +0800

    Merge branch 'master' of github.com:AgileWizard/agilewizard

[33mcommit 07bb2e422eca4b37fe85e30bd8cbb9b6bd79bcf6[m
Author: nEo <zbcjackson@gmail.com>
Date:   Tue Nov 23 11:19:06 2010 +0800

    Change teamcity.rb to use relative path

[33mcommit 6fc2fea02aad4ed57305f3adeda2d3bbe90eee6c[m
Author: unknown <Steven@.(none)>
Date:   Tue Nov 23 00:37:55 2010 +0800

    Fix Domain Test project and refactor

[33mcommit 128c116f28e068356489cf85194f923b49d6a9b0[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Mon Nov 22 14:00:35 2010 +0800

    working on user repository, steven to help fix broken ut caused by unknown raven issue

[33mcommit 3199f02a119787b4151f89823b8b746084193f61[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sun Nov 21 23:10:56 2010 +0800

    Fixed build, solution file broken, one project could not checked in.

[33mcommit 4d73c0e8d9763005e7cd7ddace53a954edb8778a[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Sun Nov 21 14:10:06 2010 +0800

    Cleaned up auto-generated files and code by MVC
    Add one new project for MVC test

[33mcommit 862eb0ceb85a1c14b7dedf33fa08750293c73100[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Fri Nov 12 00:14:48 2010 +0800

    added missing files

[33mcommit bb1a1d68ed653b602bf9e0a465d5f584c6a3fe20[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Fri Nov 12 00:10:44 2010 +0800

    Added creating resource feature

[33mcommit 500ab36c07e3f441210a9b22009c6b77857b7e37[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Fri Nov 5 17:13:28 2010 +0800

    Still could not run multiple assemblies with xunit runner for ncover application

[33mcommit fbbb17a361ea61f31cbbef07ff871003fcfbf1fc[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Nov 4 23:23:07 2010 +0800

    Change test assembly orders

[33mcommit a2b86328f8ddd4425eb56a92458243c0e96903a1[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Thu Nov 4 23:09:43 2010 +0800

    Added SpecFlow and WatiN support to Teamcity

[33mcommit 63afdb87070d5d1ef4ffcbf2220421f36b98199d[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Thu Nov 4 17:00:32 2010 +0800

    Refactor User steps' name

[33mcommit 20b881aebe7cd19e969344287d12d2df2a3a0fbf[m
Merge: 6c01aae 1ae94fb
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Thu Nov 4 16:51:39 2010 +0800

    Merge branch 'master' of git@github.com:AgileWizard/agilewizard.git

[33mcommit 6c01aae88888514e7243406167e605d0bb4d0323[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Thu Nov 4 16:50:51 2010 +0800

    Completed first acceptance test, now user can login

[33mcommit 1ae94fb52d3ebf62e25e7439e175a7b76eec05df[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Wed Nov 3 23:23:04 2010 +0800

    fixed the incorrect output directory for ncover summary

[33mcommit 5bd11de6860c1a08806d2771a32053a847797d2a[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Wed Nov 3 23:10:31 2010 +0800

    Added NCover Project name and summary report result

[33mcommit d58d2411b83595baca529b01961b5d93a702a468[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Wed Nov 3 17:58:52 2010 +0800

    Added functionality to clear all documents when acceptance test start

[33mcommit b24b5be58bdb6294372d00ac9268857a36a5500d[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Mon Nov 1 17:59:33 2010 +0800

    Added AcceptanceTests project and User feature file

[33mcommit 455caa538112279250cd8685978c12f116513b9a[m
Author: Daniel Teng <tengzhenyu@gmail.com>
Date:   Wed Oct 20 15:19:38 2010 +0800

    fixed readme file under lib directory

[33mcommit 30f7af0a4e10689391253f6acc577d52bcce5644[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Oct 16 18:28:39 2010 +0800

    try to add code coverage for summary

[33mcommit f1f2190fa8fcc93737496a5f6e62a0dd99988641[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Oct 16 17:58:02 2010 +0800

    try to add the code coverage summary

[33mcommit 6c23df4dac0f7fcaa2f49b1767f834447d9e2523[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Oct 16 16:54:20 2010 +0800

    After reverting, redo the changes for teamcity code coverage

[33mcommit 1a1a15989369d6e9159ccc7b6d3e412c37a7ac0c[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Oct 16 16:52:03 2010 +0800

    Revert "Added ncover support for teamcity"
    
    This reverts commit 57e67e8de8ee63a887c5d7e6b7217815560ea69e.

[33mcommit 57e67e8de8ee63a887c5d7e6b7217815560ea69e[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Oct 16 16:46:41 2010 +0800

    Added ncover support for teamcity

[33mcommit cf5042624e1f0348fb2ecdf1ae8baa8418c13847[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Sat Oct 16 14:45:44 2010 +0800

    Added test project for teamcity code coverage test

[33mcommit 934f27ced34a801a3f9165a6f97524e616b6c726[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Fri Oct 15 23:39:45 2010 +0800

    Fixed the build file- handle the escape character

[33mcommit 26d4053192d91044deb0203a5814aece2b8a43a5[m
Author: Jeremy Cui <tsuijy@gmail.com>
Date:   Fri Oct 15 22:55:24 2010 +0800

    Added rake files

[33mcommit f08168972641092228c1561eac241631c5f311d2[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Thu Oct 14 17:42:31 2010 +0800

    Added readme file for

[33mcommit a26672c20679a44f53f084f20ba0c406586d86ca[m
Author: Steven@3500 <jdomzhang@gmail.com>
Date:   Thu Oct 14 17:35:57 2010 +0800

    initialized folder structure

[33mcommit c666f81412c9d53dd98207e11abaddd6e07b7a97[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Oct 14 11:18:55 2010 +0800

    added .gitignore file

[33mcommit c498a86af33d40e291b4484119c291f5426b3d52[m
Author: Steven Zhang <jdomzhang@gmail.com>
Date:   Thu Oct 14 10:56:44 2010 +0800

    first commit

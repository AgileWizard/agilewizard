// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.4.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace AgileWizard.IntegrationTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ResourceListFeature : Xunit.IUseFixture<ResourceListFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Resource List.feature"
#line hidden
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Resource List", "As a visitor\r\nI want to see  list of resources", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public virtual void SetFixture(ResourceListFeature.FixtureData fixtureData)
        {
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource List")]
        [Xunit.TraitAttribute("Description", "Group resource by tag")]
        public virtual void GroupResourceByTag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Group resource by tag", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Title",
                        "TDD Training Course"});
            table1.AddRow(new string[] {
                        "Content",
                        "Test-driven development"});
            table1.AddRow(new string[] {
                        "Author",
                        "Steven Zhang"});
            table1.AddRow(new string[] {
                        "Tags",
                        "TDD"});
#line 6
 testRunner.Given("there is a resource", ((string)(null)), table1);
#line 12
 testRunner.When("I wait for non-stale data");
#line 13
 testRunner.Then("the tag list should contain \'TDD\' tag");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource List")]
        [Xunit.TraitAttribute("Description", "List resources by given tag")]
        public virtual void ListResourcesByGivenTag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("List resources by given tag", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Title",
                        "Coding Dojo"});
            table2.AddRow(new string[] {
                        "Content",
                        "Coding Dojo is hot"});
            table2.AddRow(new string[] {
                        "Author",
                        "Steven Zhang"});
            table2.AddRow(new string[] {
                        "Tags",
                        "coding-dojo"});
#line 16
 testRunner.Given("there is a resource", ((string)(null)), table2);
#line 22
 testRunner.When("I wait for non-stale data");
#line 23
 testRunner.Then("resource list of tag \'coding-dojo\' should have 1 item");
#line 24
 testRunner.Then("resource list of tag \'Coding-Dojo\' should have 1 item");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource List")]
        [Xunit.TraitAttribute("Description", "resource list paging single page")]
        public virtual void ResourceListPagingSinglePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("resource list paging single page", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("there are 1 pages of resources");
#line 28
 testRunner.When("I wait for non-stale data");
#line 29
 testRunner.Then("there will be 1 resources on the page");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource List")]
        [Xunit.TraitAttribute("Description", "resource list paging multiple page")]
        public virtual void ResourceListPagingMultiplePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("resource list paging multiple page", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("there are 2 pages of resources");
#line 33
 testRunner.When("I wait for non-stale data");
#line 34
 testRunner.Then("there will be 20 resources on the page");
#line 35
 testRunner.When("next page");
#line 36
 testRunner.Then("there will be 1 more resources on the page");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ResourceListFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ResourceListFeature.FeatureTearDown();
            }
        }
    }
}
#endregion

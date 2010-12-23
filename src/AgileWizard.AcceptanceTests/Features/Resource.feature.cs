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
namespace AgileWizard.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ResourceFeature : Xunit.IUseFixture<ResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Resource.feature"
#line hidden
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Resource", "In order to manage resources\r\nAs a admin\r\nI should be able to add/edit a resource" +
                    " onto website", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public virtual void SetFixture(ResourceFeature.FixtureData fixtureData)
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
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Add Simple Resource")]
        public virtual void AddSimpleResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Simple Resource", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("login already");
#line 8
 testRunner.And("open adding-resource page");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Title",
                        "Embeded Video"});
            table1.AddRow(new string[] {
                        "Content",
                        "Modified Content"});
            table1.AddRow(new string[] {
                        "Author",
                        "Daniel"});
            table1.AddRow(new string[] {
                        "ReferenceUrl",
                        "http://www.cnblogs.com/tengzy/"});
            table1.AddRow(new string[] {
                        "Tags",
                        "Agile,Shanghai"});
#line 9
 testRunner.And("enter data in resource page", ((string)(null)), table1);
#line 17
 testRunner.When("press submit button");
#line 18
 testRunner.Then("resource details page should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Edit A Resource")]
        public virtual void EditAResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit A Resource", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("login already");
#line 22
 testRunner.And("open resource list page");
#line 23
 testRunner.And("edit a resource titled with \'Embeded Video\'");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Title",
                        "Embeded Video"});
            table2.AddRow(new string[] {
                        "Content",
                        "Modified Content"});
            table2.AddRow(new string[] {
                        "Author",
                        "Daniel"});
            table2.AddRow(new string[] {
                        "ReferenceUrl",
                        "http://www.cnblogs.com/tengzy/"});
#line 24
 testRunner.And("enter data in resource page", ((string)(null)), table2);
#line 31
 testRunner.When("press submit button");
#line 32
 testRunner.Then("resource details page should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "Add Resource require login")]
        public virtual void AddResourceRequireLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Resource require login", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("no login");
#line 36
 testRunner.And("open adding-resource page");
#line 37
 testRunner.Then("login page should be open");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "View Resource Detail")]
        public virtual void ViewResourceDetail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Resource Detail", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("open resource list page");
#line 41
 testRunner.When("open a resource titled with \'Embeded Video\'");
#line 42
 testRunner.Then("resource details page title with - \'Embeded Video\' should be shown");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Resource")]
        [Xunit.TraitAttribute("Description", "View Resource List")]
        public virtual void ViewResourceList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Resource List", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("login already");
#line 46
 testRunner.And("open resource list page");
#line 47
 testRunner.Then("resoure list page should be in current culture");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ResourceFeature.FeatureTearDown();
            }
        }
    }
}
#endregion

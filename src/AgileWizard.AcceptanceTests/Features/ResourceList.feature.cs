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
    public partial class ResourceListFeature : Xunit.IUseFixture<ResourceListFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ResourceList.feature"
#line hidden
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Resource List", "In order to see more resources\nAs a visitor\nI want to see more resources other th" +
                    "an current page", GenerationTargetLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.FactAttribute(Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Resource List")]
        [Xunit.TraitAttribute("Description", "Default resource list")]
        public virtual void DefaultResourceList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Default resource list", new string[] {
                        "Ignore"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.When("I go to resource list page");
#line 10
 testRunner.Then("I will see 20 resources on the page");
#line 11
 testRunner.When("I go to next page");
#line 12
 testRunner.Then("I will see 21 resources on the page");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Xunit.FactAttribute(Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Resource List")]
        [Xunit.TraitAttribute("Description", "tag resource list")]
        public virtual void TagResourceList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("tag resource list", new string[] {
                        "Ignore"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.When("I visit resource list of tag page");
#line 18
 testRunner.Then("I will see 20 resources on the page");
#line 19
 testRunner.When("I go to next page");
#line 20
 testRunner.Then("I will see 21 resources on the page");
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

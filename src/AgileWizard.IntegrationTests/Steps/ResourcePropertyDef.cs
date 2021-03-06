﻿using System.Web.Mvc;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Models;
using TechTalk.SpecFlow;

namespace AgileWizard.IntegrationTests.Steps
{
    public partial class ResourceSteps
    {
        private const string TAGNAME = "tagName";
        private const string ACTION_RESULT_KEY = "ActionResult";
        private const string EXISTING_RESOURCE_KEY = "ExistingResource";
        private const string SUBMITTED_RESOURCE_MODEL_KEY = "SubmittedResourceModel";
        private const string PENDING_SUBMITTED_RESOURCE_MODEL_KEY = "PendingSubmittedResourceModel";

        public ActionResult ActionResult
        {
            get
            {
                return CurrentScenario[ACTION_RESULT_KEY] as ActionResult;
            }
            set
            {
                CurrentScenario[ACTION_RESULT_KEY] = value;
            }
        }

        public Resource ExistingResource
        {
            get
            {
                return CurrentScenario[EXISTING_RESOURCE_KEY] as Resource;
            }
            set
            {
                CurrentScenario[EXISTING_RESOURCE_KEY] = value;
            }
        }

        public string TagName
        {
            get
            {
                return CurrentScenario[TAGNAME] as string;
            }
            set
            {
                CurrentScenario[TAGNAME] = value;
            }
        }

        public ResourceDetailViewModel SubmittedResourceDetailViewModel
        {
            get
            {
                return CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] as ResourceDetailViewModel;
            }
            set
            {
                CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] = value;
            }
        }

        public ResourceDetailViewModel PendingSubmittedResourceDetailViewModel
        {
            get
            {
                return CurrentScenario[PENDING_SUBMITTED_RESOURCE_MODEL_KEY] as ResourceDetailViewModel;
            }
            set
            {
                CurrentScenario[PENDING_SUBMITTED_RESOURCE_MODEL_KEY] = value;
            }
        }

        private ScenarioContext CurrentScenario
        {
            get
            {
                return ScenarioContext.Current;
            }
        }
    }
}

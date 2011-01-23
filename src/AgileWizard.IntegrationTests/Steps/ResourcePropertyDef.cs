using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Models;

namespace AgileWizard.IntegrationTests.Steps
{
    public partial class ResourceSteps
    {
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

        public ResourceModel SubmittedResourceModel
        {
            get
            {
                return CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] as ResourceModel;
            }
            set
            {
                CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] = value;
            }
        }

        public ResourceModel PendingSubmittedResourceModel
        {
            get
            {
                return CurrentScenario[PENDING_SUBMITTED_RESOURCE_MODEL_KEY] as ResourceModel;
            }
            set
            {
                CurrentScenario[PENDING_SUBMITTED_RESOURCE_MODEL_KEY] = value;
            }
        }
    }
}

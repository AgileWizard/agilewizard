﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Raven.Client.Document;
using Xunit;
using Raven.Database.Data;
using AgileWizard.AcceptanceTests.Data;

namespace AgileWizard.AcceptanceTests
{
    [Binding]
    public class ClearDatabase
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            documentStore.Initialize();

            var dataManager = new DataManager(documentStore);
            dataManager.ClearAllDocuments();
            dataManager.InitData();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //TODO: implement logic that has to run after the entire test run
        }
    }
}

using AltTester.AltTesterUnitySDK.Driver;
using BalssMergeAutotests.PageObjects;
using BalssMergeAutotests.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalssMergeAutotests.Fixtures
{
    public class BaseTestFixture
    {
        private AltDriver _altDriver;
        private AppInstall _appInstall;
        private StartApp _startApp;
        private ShutDownApp _shutDownApp;
        private CleanAppData _cleanAppData = new CleanAppData();

        protected MainPage _mainPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _appInstall = new AppInstall();

            _appInstall.CheckAndInstallApp();
            AltReversePortForwarding.ReversePortForwardingAndroid();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AltReversePortForwarding.RemoveReversePortForwardingAndroid();
        }

        [SetUp]
        public void Setup()
        {
            _startApp = new StartApp();

            _cleanAppData.ClearAppData();
            _startApp.StartApplication();
            _altDriver = new AltDriver();
            _mainPage = new MainPage(_altDriver);
            _mainPage.ClickTermOfUseAgreeButton();
            _mainPage.WaitForTermsOfUseNotToBePresented();
        }

        [TearDown]
        public void TearDown()
        {
            _shutDownApp = new ShutDownApp();

            _altDriver.Stop();
            _shutDownApp.ShutDownApplication();
            _cleanAppData.ClearAppData();
        }
    }
}

using AltTester.AltTesterUnitySDK.Driver;
using AltTester.AltTesterUnitySDK.Driver.Communication;
using BalssMergeAutotests.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BalssMergeAutotests.PageObjects
{
    public class MainPage
    {
        private readonly BackSystemCommand _backSystemCommand;
        private readonly AltDriver _driver;
        private const string TermOfUseAgreeButtonName = "AgreeButton";
        private const string FirstBallName = "Circle0";
        private const string SecondBallName = "Circle1";
        private const string ThirdBallName = "Circle2";
        private const string FourthBallName = "Circle3";
        private const string PlayerCurrentScoreName = "CurrentScore";
        private const string SettingsButtonName = "SettingsButton";

        public MainPage(AltDriver driver)
        {
            _driver = driver;
            _backSystemCommand = new BackSystemCommand();
        }

        public void ClickTermOfUseAgreeButton()
        {
            _driver.FindObject(By.NAME, TermOfUseAgreeButtonName).Click();
        }

        public void WaitForTermsOfUseNotToBePresented()
        {
            _driver.WaitForObjectNotBePresent(By.NAME, TermOfUseAgreeButtonName);
        }

        public void ClickOnFirstBall()
        {
            const int waitForBallFallingMs = 3000;
            _driver.WaitForObject(By.NAME, FirstBallName);
            _driver.FindObject(By.NAME, FirstBallName).Click();
            Thread.Sleep(waitForBallFallingMs);
        }

        public void ClickOnSecondBall()
        {
            const int waitForBallFallingMs = 3000;
            _driver.WaitForObject(By.NAME, SecondBallName);
            _driver.FindObject(By.NAME, SecondBallName).Click();
            Thread.Sleep(waitForBallFallingMs);
        }

        public void SwipeFirstBallDropPositionToLeft()
        {
            float swipingDurationSec = 2;
            var firstBall = _driver.FindObject(By.NAME, FirstBallName);
            var settingsButton = _driver.FindObject(By.NAME, SettingsButtonName);
            _driver.Swipe(new AltVector2(GetFirstBallXPosition(), GetFirstBallYPosition()), new AltVector2(settingsButton.GetWorldPosition().x, settingsButton.GetWorldPosition().y), swipingDurationSec);
        }

        public float GetFirstBallYPosition()
        {
            return _driver.FindObject(By.NAME, FirstBallName).UpdateObject().GetWorldPosition().y;
        }

        public float GetFirstBallXPosition()
        {
            return _driver.FindObject(By.NAME, FirstBallName).UpdateObject().GetWorldPosition().x;
        }

        public bool IsFirstBallPresent()
        {
            return IsObjectPresent(FirstBallName);
        }

        public bool IsSecondBallPresent()
        {
            return IsObjectPresent(SecondBallName);
        }

        public bool IsFourthBallPresent()
        {
            return IsObjectPresent(FourthBallName);
        }

        public int GetCurrentPlayerScore()
        {
            return Int32.Parse(Regex.Replace(_driver.FindObject(By.NAME, PlayerCurrentScoreName).GetText(), @"\D", ""));
        }

        public void WaitAdvertisementAvailablity()
        {
            int adAvailablityWaitingTimeMs = 30000;
            Thread.Sleep(adAvailablityWaitingTimeMs);
        }

        private bool IsObjectPresent(string objectName)
        {
            try
            {
                var targetObject = _driver.FindObject(By.NAME, objectName);
                return targetObject != null;
            }
            catch
            {
                return false;
            }
        }
    }
}

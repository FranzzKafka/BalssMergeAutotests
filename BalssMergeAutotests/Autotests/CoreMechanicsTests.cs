using AltTester.AltTesterUnitySDK.Driver;
using BalssMergeAutotests.Fixtures;
using BalssMergeAutotests.PageObjects;
using BalssMergeAutotests.Utils;
using NuGet.Frameworks;
using System.Numerics;
using FluentAssertions;
using NUnit.Allure.Core;

namespace BalssMergeAutotests.Autotests
{
    [TestFixture]
    [Allure.NUnit.AllureNUnitAttribute]
    public class CoreMechanicsTests : BaseTestFixture
    {
        [Test]
        [Description("Ball falls on the playing field after tapping")]
        public void Ball_Falls_On_Playing_Field_Test()
        {
            float expectedYBallPositionAfterFalling = -4.81886721f;

            _mainPage.ClickOnFirstBall();
            float firstBallPositionAfterClick = _mainPage.GetFirstBallYPosition();
            firstBallPositionAfterClick.Should().Be(expectedYBallPositionAfterFalling);
        }

        [Test]
        [Description("The ball's drop point is moved by swiping")]
        public void Ball_Drop_Point_Moving_Test()
        {
            float expectedPositionChanging = 4.1f;
            float firstBallInitXPosition = _mainPage.GetFirstBallXPosition();
            _mainPage.SwipeFirstBallDropPositionToLeft();
            float firstBallPositionAfterSwipe = _mainPage.GetFirstBallXPosition();
            float actualPositionChanging = firstBallInitXPosition - firstBallPositionAfterSwipe;
            expectedPositionChanging.Should().Be(actualPositionChanging);
        }

        [Test]
        [Description("Balls merge into another ball")]
        public void Balls_Merge_Test()
        {
            _mainPage.ClickOnFirstBall();
            _mainPage.ClickOnSecondBall();
            _mainPage.IsFirstBallPresent().Should().BeFalse("Because first ball dissappears after meging");
            _mainPage.IsSecondBallPresent().Should().BeFalse("Because second ball dissappears after meging");
            _mainPage.IsFourthBallPresent().Should().BeTrue("Because fourth ball appears after meging first and second ball");
        }

        [Test]
        [Description("Getting score for balls merge")]
        public void Score_Getting_Test()
        {
            int expectedScoreIncreasing = 1;

            int initPlayerScore = _mainPage.GetCurrentPlayerScore();
            _mainPage.ClickOnFirstBall();
            _mainPage.ClickOnSecondBall();
            int playerScoreAfterMerge = _mainPage.GetCurrentPlayerScore();
            int actualScoreIncreasing = playerScoreAfterMerge - initPlayerScore;
            expectedScoreIncreasing.Should().Be(actualScoreIncreasing);
        }
    }
}
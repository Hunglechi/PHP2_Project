using System.Collections;
using NUnit.Framework;
using NunitDemo.Library;
using NunitDemo.Pages;

namespace NunitDemo.Test
{
    public class TestManageUserUI : BaseTest
    {
        private HomePage _homePage;
        private LoginAssetManagerPage _loginAssetManagerPage;
        private ManageUserPage _manageUerPage;

        [SetUp]
        public void init()
        {
            _homePage = new HomePage(Webdriver);
            _loginAssetManagerPage = new LoginAssetManagerPage(Webdriver);
            _manageUerPage = new ManageUserPage(Webdriver);
        }

        [Test, TestCaseSource(nameof(GetUserDataFromJsonFile))]
        [Category("json")]
        public void TestUIManageUserPage(string userName, string password,string createButtonInfor, 
                string searchBarInfor, string staffCodeInfor,string fullNameInfor, string userNameInfor,
                string joinDateInfor, string typeInfor)
        {
            _loginAssetManagerPage.VisitHomePage();
            _loginAssetManagerPage.LoginAssetManager(userName, password);
            _homePage.ChoosingManageUser();
            var actualUI = _manageUerPage.GetResultFromManageUserPage();
            Console.WriteLine(actualUI);
            Assert.That(actualUI, Does.Contain(createButtonInfor));
            Assert.That(actualUI, Does.Contain(staffCodeInfor));
            Assert.That(actualUI, Does.Contain(fullNameInfor));
            Assert.That(actualUI, Does.Contain(userNameInfor));
        }

        public static IEnumerable GetUserDataFromJsonFile()
        {
            var datas = JsonHelper.GetTestDataFromJson("TestData\\TestData.json", "Information");
            return datas;
        }
    }
}
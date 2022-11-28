using OpenQA.Selenium;
using NunitDemo.Library;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace NunitDemo.Pages
{
    public class ManageUserPage : BasePage
    {
        private WebObject _createNewUserButton = new WebObject(By.XPath("//button[normalize-space()='Create new user']"), "Create New User Button");
        private WebObject _searchBar = new WebObject(By.XPath("//input[@placeholder='Search...']"), "Search Bar");
        private WebObject _staffCode = new WebObject(By.XPath("//div[contains(text(),'Staff Code')]"), "Staff Code");
        private WebObject _fullName = new WebObject(By.XPath("//div[contains(text(),'Full Name')]"), "Full Name Information");
        private WebObject _userName = new WebObject(By.XPath("//div[contains(text(),'Username')]"), "User Name Information");
        private WebObject _joinDate = new WebObject(By.XPath("//div[contains(text(),'Joined Date')]"), "Join Date Information");
        private WebObject _type = new WebObject(By.XPath("//div[@class='ams__columnname']//div[contains(text(),'Type')]"), "Type Information");

        public ManageUserPage(IWebDriver driver) : base(driver) { }

        //Page Methods

        public string GetResultFromManageUserPage()
        {
            return GetTextFromElement(_createNewUserButton)
            + GetTextFromElement(_staffCode) + " " +
            GetTextFromElement(_fullName) + " " + GetTextFromElement(_userName) + " " +
            GetTextFromElement(_joinDate) + " " + GetTextFromElement(_type);
        }

        public string GetAdmin()
        {
            List<WebObject> content_data = new List<WebObject>();
            var element = WaitForElementToBeVisible(new WebObject(By.XPath("//div[contains(text(),'Admin')]"), "Type Information"));
            content_data.Add(new WebObject(By.XPath("//div[contains(text(),'Admin')]"), "Type Information"));
            for (int i=0;i<content_data.Count;i++)
            {
                Console.WriteLine("Hello "+GetTextFromElement(content_data[i]));
                if(GetTextFromElement(content_data[i])!="Admin")
                {
                    return "0";
                }
            }
            return "1";
        }
    }
}
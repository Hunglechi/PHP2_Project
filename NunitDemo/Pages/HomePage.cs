using OpenQA.Selenium;
using NunitDemo.Library;
using OpenQA.Selenium.Chrome;

namespace NunitDemo.Pages
{
    public class HomePage : BasePage
    {
        private WebObject _manageUserButton = new WebObject(By.XPath("//span[@class='ant-menu-title-content'][normalize-space()='Manage User']"), "Manage User Tab");

        public HomePage(IWebDriver driver) : base(driver) { }

        //Page Methods
        public void ChoosingManageUser()
        {
            ClickOnElement(_manageUserButton);
        }
    }
}
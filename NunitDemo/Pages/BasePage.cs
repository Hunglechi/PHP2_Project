using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NunitDemo.Library;
using NunitDemo.Test;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace NunitDemo.Pages
{
    public abstract class BasePage
    {
        public IWebDriver WebDriver;
        public WebDriver driver;
        public WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            WebDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Int16.Parse(ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "TimeWait"))));
        }
        public void GotoUrl(string url)
        {
            WebDriver.Url = url;
        }
        //Wait Element 2 references 
        public IWebElement WaitForElementToBeVisible(WebObject webOject)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(webOject.By));
        }
        public IWebElement WaitForElementToBeClickable(WebObject webOject)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(webOject.By));
        }
        public void WaitForElementToBeInvisible(WebObject webOject)
        {
            try
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(webOject.By));
            }
            catch (WebDriverTimeoutException)
            {
                var message = $"Element is still visible. Element information: {webOject.By}";
                Console.WriteLine(message);
            }
        }
        //Get attribute of an Element
        public bool IsElementDisplayed(WebObject webOject)
        {
            bool result;
            try
            {
                result = Wait.Until(ExpectedConditions.ElementIsVisible(webOject.By)).Displayed;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public string GetTextFromElement(WebObject webOject)
        {
            var element = WaitForElementToBeVisible(webOject);
            Console.WriteLine("Get text from element: " + webOject.Name);
            return element.Text;
        }

        //Action on Element
        public void ClickOnElement(WebObject webOject)
        {
            var element = WaitForElementToBeClickable(webOject);
            element.Click();
            Console.WriteLine("Click on element: " + webOject.Name);
        }
        public void EnterText(WebObject webOject, string text)
        {
            var element = WaitForElementToBeVisible(webOject);
            element.Clear();
            element.SendKeys(text);
            Console.WriteLine("Input " + text + " to element " + webOject.Name);
        }
        public void EnterKey(WebObject webOject)
        {
            var element = WaitForElementToBeVisible(webOject);
            element.SendKeys(Keys.Enter);
        }
        public void ScrollPage()
        {
            Actions actions = new Actions(WebDriver);
            actions.SendKeys(Keys.PageDown).Build().Perform();
        }
        public void ScrollPageUp()
        {
            Actions actions = new Actions(WebDriver);
            actions.SendKeys(Keys.PageUp).Build().Perform();
        }
        public string GetAlertPopup()
        {
            IAlert alert = WebDriver.SwitchTo().Alert();
            return WebDriver.SwitchTo().Alert().Text;
        }
        public void AlertPopup()
        {
            IAlert alert = WebDriver.SwitchTo().Alert();
            // Accepting alert		
            alert.Accept();
        }

        public void ClickOnHideElement(WebObject webObject)
        {
            IWebElement element = WaitForElementToBeVisible(webObject);
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("arguments[0].click();", element);
        }
        public void HideAds(WebObject webObject)
        {
            IWebElement element= WaitForElementToBeVisible(webObject);
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("arguments[0].style.visibility='hidden';",element);           
        }
    }
}
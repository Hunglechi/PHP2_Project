using OpenQA.Selenium;
using NunitDemo.Library;
using OpenQA.Selenium.Chrome;

namespace NunitDemo.Pages
{
    public class LoginAssetManagerPage : BasePage
    {
        private WebObject _usernametextbox = new WebObject(By.Id("basic_username"), "User Name Textbox");
        private WebObject _passwordtextbox = new WebObject(By.Id("basic_password"), "Password Textbox");
        private WebObject _loginbutton = new WebObject(By.XPath("//button[@type='submit']"), "Login Button");
        string UrlFormPage = "https://ams-app-2.azurewebsites.net/";
        //Contructor
        public LoginAssetManagerPage (IWebDriver driver) : base(driver) { }

        //Page Methods
        public void VisitHomePage()
        {
            GotoUrl(UrlFormPage);
        }
        public void LoginAssetManager(string userName, string password)
        {
            EnterText(_usernametextbox, userName);
            EnterText(_passwordtextbox, password);
            ClickOnElement(_loginbutton);
        }
    }
}
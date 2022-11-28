using OpenQA.Selenium;
using NunitDemo.Library;
using OpenQA.Selenium.Chrome;

namespace NunitDemo.Pages
{
    public class DetailedUserInformationPage : BasePage
    {
        private WebObject _recordItem = new WebObject(By.XPath("//div[normalize-space()='SD0020']"), "Record Item");
        private WebObject _staffCodeInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Staff Code']"), "Staff Code");
        private WebObject _fullNameInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Full Name']"), "Full Name Information");
        private WebObject _userNameInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Username']"), "User Name Information");
        private WebObject _datOfBirthInfor = new WebObject(By.XPath("//div[normalize-space()='Date of Birth']"), "Date Of Birth Information");
        private WebObject _genderInfor = new WebObject(By.XPath("//div[normalize-space()='Gender']"), "Gender Information");
        private WebObject _joinDateInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Joined Date']"), "Join Date Information");
        private WebObject _typeInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Type']"), "Type Information");
        private WebObject _locationInfor = new WebObject(By.XPath("//div[normalize-space()='Location']"), "Location Information");


        public DetailedUserInformationPage(IWebDriver driver) : base(driver) { }

        //Page Methods

        public string GetResultFromRecordItemPage()
        {
            return GetTextFromElement(_typeInfor)+" "
            +GetTextFromElement(_staffCodeInfor)+" "+
            GetTextFromElement( _fullNameInfor)+" "+GetTextFromElement(_userNameInfor)+" "+
            GetTextFromElement(_datOfBirthInfor)+" "+GetTextFromElement(_genderInfor)
            +" "+ GetTextFromElement(_datOfBirthInfor)+" "+GetTextFromElement(_joinDateInfor)+
            " "+ GetTextFromElement(_locationInfor);

        }
        public void ChoosingRecordItem()
        {
            ClickOnElement(_recordItem);
        }
    }
}
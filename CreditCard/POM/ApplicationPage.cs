using OpenQA.Selenium;
using System.Collections.ObjectModel;

class ApplicationPage : Page
{
    public ApplicationPage(IWebDriver driver)
    {
        Driver = driver;
    }
    protected override string PageUrl => "http://localhost:44108/Apply";
    protected override string PageTitle => "Credit Card Application - Credit Cards";



    public ReadOnlyCollection<string> ValidationErrorMessages
    {
        get
        {
            return Driver.FindElements(
            By.CssSelector(".validation-summary-errors > ul > li"))
            .Select(x => x.Text)
            .ToList()
            .AsReadOnly();
        }
    }
}
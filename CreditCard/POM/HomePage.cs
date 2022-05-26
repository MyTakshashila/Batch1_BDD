using OpenQA.Selenium;
using System.Collections.ObjectModel;

class HomePage : Page
{
    public HomePage(IWebDriver driver)
    {
        Driver = driver;
    }

    protected override string PageUrl => "http://localhost:44108/";
    protected override string PageTitle => "Home Page - Credit Cards";
    public void ClickLiveChatFooterLink() => Driver.FindElement(By.Id("LiveChat")).Click();

    public ReadOnlyCollection<(string name, string interestRate)> Products
    {
        get
        {
            var products = new List<(string name, string interestRate)>();
            var productCells = Driver.FindElements(By.TagName("td"));
            for (int i = 0; i < productCells.Count - 1; i += 2)
            {
                string name = productCells[i].Text;
                string interestRate = productCells[i + 1].Text;
                products.Add((name, interestRate));
            }
            return products.AsReadOnly();
        }
    }

    public ApplicationPage ApplyNow()
    {
        Driver.FindElement(By.PartialLinkText("- Apply Now!")).Click();
        return new ApplicationPage(Driver);
    }
    public ApplicationPage ClickApplyLowRateLink()
    {
        Driver.FindElement(By.Name("ApplyLowRate")).Click();
        return new ApplicationPage(Driver);
    }

    public ApplicationPage ClickApplyEasyApplicationLink()
    {
        string script = @"document.evaluate('//a[text()[contains(.,\'Easy: Apply Now!\')]]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();";
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        js.ExecuteScript(script);
        return new ApplicationPage(Driver);
    }

    public ApplicationPage ClickCustomerServiceApplicationLink()
    {
       // Driver.FindElement(By.ClassName("customer-service-apply-now")).click();

        IWebElement ele = Driver.FindElement(By.ClassName("customer-service-apply-now"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        js.ExecuteScript("arguments[0].click();",ele);
        return new ApplicationPage(Driver);
    }
}
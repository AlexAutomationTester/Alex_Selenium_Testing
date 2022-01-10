using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;


namespace Inspired_Automation_Testing_Task2
{
    public class Functions
    {
        //Functions created directly from the Selenium Libraries/Frameworks 
        //Cornerstone of pretty much every other Function & Test Case Created, by far the most used functions of this project
        public static void NewWindow(ChromeDriver driver, String url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        //Creates an action for a ChromeDriver
        //Creates an element from an XPath String 
        //The Action then acts on the element (Click Element)
        public static void ClickButtonByXPath(ChromeDriver driver, String button)
        {
            Actions clickButton = new Actions(driver);
            IWebElement eleButton = driver.FindElement(By.XPath(button));
            clickButton.MoveToElement(eleButton).Click().Perform();
        }
        public static void ClickButtonByName(ChromeDriver driver, String buttonName)
        {
            Actions clickButton = new Actions(driver);
            IWebElement eleButton = driver.FindElement(By.Name(buttonName));
            clickButton.MoveToElement(eleButton).Click().Perform();
        }

        //Creates an action for a ChromeDriver
        //Creates an element from a Class
        //The Action then acts on the element (Click Element)
        public static void ClickButtonByClass(ChromeDriver driver, String buttonClass)
        {
            Actions clickButton = new Actions(driver);
            IWebElement eleButton = driver.FindElement(By.ClassName(buttonClass));
            clickButton.MoveToElement(eleButton).Click().Perform();
        }

        //Creates an action for a ChromeDriver
        //Creates an element from an ID 
        //The Action then acts on the element (Click Element)
        public static void ClickButtonById(ChromeDriver driver, String buttonId)
        {
            Actions clickButton = new Actions(driver);
            IWebElement eleButton = driver.FindElement(By.Id(buttonId));
            clickButton.MoveToElement(eleButton).Click().Perform();
        }

        //Creates an action for a ChromeDriver
        //Creates an element from an XPath String 
        //The Action then acts on the element (Write in Element)
        public static void WriteInfoByXPath(ChromeDriver driver, String text, String field)
        {
            Actions writeInfo = new Actions(driver);
            IWebElement eleInformation = driver.FindElement(By.XPath(field));
            writeInfo.MoveToElement(eleInformation).Click().SendKeys(text).Perform();
        }

        //Dropdown is defined with Select and Option tag
        //Therefore we are using the SelectElement class to select the value from the dropdown.
        //Select By Value (1,2,3,4,5) for each of the 5 customers in the dropdown
        public static void DropdownSelect(ChromeDriver driver, String value)
        {
            IWebElement Dropdown = driver.FindElement(By.Id("userSelect"));
            SelectElement select = new SelectElement(Dropdown);
            select.SelectByValue(value);
        }

        public static void AccountSelect(ChromeDriver driver, String accountNumber)
        {
            IWebElement Dropdown = driver.FindElement(By.Id("accountSelect"));
            SelectElement select = new SelectElement(Dropdown);
            select.SelectByValue(accountNumber);
        }

        //Creates a Screenshots folder to the Desktop of the current user and saves the Test Case screenshots in it
        public static void Printscreen(ChromeDriver driver, String name)
        {
            var outputdir2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var outPutDirectory = Path.Combine(outputdir2, "Automation_Test_Screenshots");
            if (!Directory.Exists(outPutDirectory)) {
                Directory.CreateDirectory(outPutDirectory);
            }
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(Path.Combine(outPutDirectory, name + ".png").ToString(), OpenQA.Selenium.ScreenshotImageFormat.Png);            
        }

        //Waits for the Page to load or will timeout after 30 seconds
        public static void PageLoad(ChromeDriver driver)
        {
            _ = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void Transactions(ChromeDriver driver)
        {
            ClickButtonByXPath(driver, Variables.transactions);
        }

        public static void TransactionsReset(ChromeDriver driver)
        {
            ClickButtonByXPath(driver, Variables.resetTransactions);
        }

        public static void TransactionsBack(ChromeDriver driver)
        {
            ClickButtonByXPath(driver, Variables.backTransactons);
        }

        public static void Deposit(ChromeDriver driver, String amount)
        {
            ClickButtonByXPath(driver, Variables.deposit);
            WriteInfoByXPath(driver, amount, Variables.depositAmount);
            ClickButtonByXPath(driver, Variables.confirmDeposit);
        }

        public static void Withdrawl(ChromeDriver driver, String amount)
        {
            ClickButtonByXPath(driver, Variables.withdrawl);
            WriteInfoByXPath(driver, amount, Variables.depositAmount);
            ClickButtonByXPath(driver, Variables.confirmDeposit);
        }

        public static void ChooseCustomer(ChromeDriver driver, String value)
        {
            OpenCustList(driver);
            DropdownSelect(driver, value);
        }

        public static void OpenCustList(ChromeDriver driver)
        {
            ClickButtonById(driver, Variables.customerNameListId);
        }

        public static void ChooseAccount(ChromeDriver driver, String accountNumber)
        {
            OpenAccList(driver);
            AccountSelect(driver, accountNumber);
        }

        public static void OpenAccList(ChromeDriver driver)
        {
            ClickButtonById(driver, Variables.accountSelectId);
        }

        public static void CustomerLogin(ChromeDriver driver)
        {
            NewWindow(driver, "http://www.way2automation.com/angularjs-protractor/banking/#/login");
            ClickButtonByXPath(driver, Variables.customerLogin);
        }

        public static void Login(ChromeDriver driver)
        {
            ClickButtonByXPath(driver, Variables.login);
        }

        public static void Logout(ChromeDriver driver)
        {
            ClickButtonByXPath(driver, Variables.logout);
        }
    }

    public class Variables
    {
        public static String customerLogin = "//button[contains(text(),'Customer Login')]";
        public static String customerNameList = "//select[@id='userSelect']";
        public static String customerNameListId = "userSelect";
        public static String login = "//button[contains(text(),'Login')]";
        public static String logout = "//body/div[3]/div[1]/div[1]/button[2]";
        public static String transactions = "//body/div[3]/div[1]/div[2]/div[1]/div[3]/button[1]";
        public static String deposit = "//body/div[3]/div[1]/div[2]/div[1]/div[3]/button[2]";
        public static String withdrawl = "//body/div[3]/div[1]/div[2]/div[1]/div[3]/button[3]";
        public static String depositAmount = "//body/div[3]/div[1]/div[2]/div[1]/div[4]/div[1]/form[1]/div[1]/input[1]";
        public static String withdrawlAmount = "//body/div[3]/div[1]/div[2]/div[1]/div[4]/div[1]/form[1]/div[1]/input[1]";
        public static String confirmWithdrawl = "//body/div[3]/div[1]/div[2]/div[1]/div[4]/div[1]/form[1]/button[1]";
        public static String confirmDeposit = "//body/div[3]/div[1]/div[2]/div[1]/div[4]/div[1]/form[1]/button[1]";
        public static String resetTransactions = "//body/div[3]/div[1]/div[2]/div[1]/div[1]/button[2]";
        public static String backTransactons = "//body/div[3]/div[1]/div[2]/div[1]/div[1]/button[1]";
        public static String accountSelectId = "accountSelect";
    }
}

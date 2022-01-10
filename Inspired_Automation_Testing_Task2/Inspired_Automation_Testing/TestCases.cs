
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Inspired_Automation_Testing_Task2
{
    [TestClass]
    public class InspiredAutomation_TestCases
    {
        [TestMethod]
        [Priority(10)]
        public void Test1()
        {
            using var driver = new ChromeDriver();
            Functions.PageLoad(driver);
            Functions.CustomerLogin(driver);
            Functions.ChooseCustomer(driver, "1");
            Functions.Login(driver);
            Functions.ChooseAccount(driver, "number:1001");
            Functions.Transactions(driver);
            Functions.TransactionsReset(driver);
            Functions.TransactionsBack(driver);
            Functions.Deposit(driver, "1500");
            Functions.Printscreen(driver, "Test 1 - Deposit Successfull");
            Functions.Transactions(driver);
            Functions.Printscreen(driver, "Test 1 - Transcation Successfull");
            Functions.Logout(driver);
            driver.Quit();
        }

        [TestMethod]
        [Priority(11)]
        public void Test2()
        {
            string[] customers = { "2", "3", "4", "5" };
            string[] custText = { "Cust 2", "Cust 3", "Cust 4", "Cust 5" };
            using var driver = new ChromeDriver();
            Functions.PageLoad(driver);
            Functions.CustomerLogin(driver); //this only needs to happen once
            Functions.ChooseCustomer(driver, "1");
            Functions.Login(driver);
            Functions.Transactions(driver);
            Functions.TransactionsReset(driver); //reseting this account for better visibility
            Functions.TransactionsBack(driver);
            Functions.Deposit(driver, "1500");
            Functions.Printscreen(driver, "Cust 1 - Deposit Successful");
            Functions.Transactions(driver);
            Functions.Printscreen(driver, "Cust 1 - Transcaction Successful");
            Functions.Logout(driver);
            foreach (string customer in customers)
            {
                Functions.ChooseCustomer(driver, customer);
                Functions.Login(driver);
                Functions.Deposit(driver, "1500");
                foreach (string cust in custText)
                {
                    Functions.Printscreen(driver, cust + " - Deposit Successful");
                }
                Thread.Sleep(1000);
                Functions.Transactions(driver);
                foreach (string cust in custText)
                {
                    Functions.Printscreen(driver, cust + " - Transaction Successful");
                }
                Thread.Sleep(1000);
                Functions.Logout(driver);
            }
            driver.Quit();
        }

        [TestMethod]
        [Priority(12)]
        public void Test3()
        {
            using var driver = new ChromeDriver();
            Functions.PageLoad(driver);
            Functions.CustomerLogin(driver);
            Functions.ChooseCustomer(driver, "1");
            Functions.Login(driver);
            Functions.ChooseAccount(driver, "number:1001");
            Functions.Transactions(driver);
            Functions.TransactionsReset(driver);
            Functions.TransactionsBack(driver);
            Functions.Deposit(driver, "31459");
            Functions.Printscreen(driver, "Test 3 - Deposit Successful");
            Functions.Transactions(driver);
            Functions.Printscreen(driver, "Test 3 - Deposit Transaction Successful");
            Functions.TransactionsBack(driver);
            Functions.Withdrawl(driver, "31459");
            Functions.Printscreen(driver, "Test 3 - Withdrawal Successful");
            Functions.Transactions(driver);
            Functions.Printscreen(driver, "Test 3 - Withdrawal Transaction Successful");
            Functions.Logout(driver);
            driver.Quit();
        }

        [TestMethod]
        [Priority(13)]
        public void Test4()
        {
            var settings = new ConfigurationBuilder().AddJsonFile("Task_4.json").Build();
            using var driver = new ChromeDriver();
            Functions.PageLoad(driver);
            Functions.CustomerLogin(driver);
            Functions.ChooseCustomer(driver, settings["Customer"]);
            Functions.Login(driver);
            Functions.ChooseAccount(driver, settings["Account"]);
            Functions.Transactions(driver);
            Functions.TransactionsReset(driver);
            Functions.TransactionsBack(driver);
            Functions.Deposit(driver, settings["DepositAmount"]);
            Functions.Printscreen(driver, "Test 4 - Deposit Successful");
            Functions.Transactions(driver);
            Functions.Printscreen(driver, "Test 4 - Deposit Transaction Successful");
            Functions.TransactionsBack(driver);
            Functions.Withdrawl(driver, settings["WithdrawlAmount"]);
            Functions.Printscreen(driver, "Test 4 - Withdrawal Successful");
            Functions.Transactions(driver);
            Functions.Printscreen(driver, "Test 4 - Withdrawal Transaction Successful");
            Functions.Logout(driver);
            driver.Quit();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeAndMaterial
{
    class Program
    {
        static void Main(string[] args)
        {
            //launch chromrdriver
            IWebDriver driver = new ChromeDriver();

            //launch url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //enter valid username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            //enter valid password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            //click on login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            //verify if your on home page
            //go to home page
            //identify 'hello hari
            driver.Manage().Window.Maximize();
            IWebElement HelloHomePage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (HelloHomePage.Text == "Hello hari!")
            {
                Console.WriteLine("Hello Hari Displayed Test pass");
            }
            else
            {
                Console.WriteLine("Hello Hari Not Displayed Test Failed");
            }

            //Click on the Dropdown list of Column "Administration"
            IWebElement TypeCodelabel_dropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            TypeCodelabel_dropdown.Click();

            //select Time and Materials option
            IWebElement TimeandMaterials = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeandMaterials.Click();

            //Click on "Create New" button
            IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNew.Click();

            //Click on TypeCode 
            IWebElement TypeCodeMenu = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/label"));
            TypeCodeMenu.Click();

            //To change Material to Time
            IWebElement timeLink = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeLink.Click();

            // enter the Code:18.05 in the text box Code
            IWebElement Codetextbox = driver.FindElement(By.XPath("//*[@id='Code']"));
            Codetextbox.SendKeys("18.05");

            //to chek user is able to put all the combinatins and max word in description
            IWebElement Descriptiontextbox = driver.FindElement(By.XPath("//*[@id='Description']"));
            Descriptiontextbox.SendKeys("123456789abcd");

            // to check if user is able to enter price per unit
            IWebElement PricePerUnit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            PricePerUnit.SendKeys("123");

            //To check if user is able to access the fiels from the system
            IWebElement Selectfiles = driver.FindElement(By.XPath("//*[@id='files']"));
            Selectfiles.SendKeys("C://Users/pravi_000/Documents");

            //to check if user is abel to save the record
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            SaveButton.Click();

            //To Verify if record is saved
            Thread.Sleep(1000);
            IWebElement LastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            LastPage.Click();
            Thread.Sleep(1000);
            IWebElement savedrecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[6]/td[1]"));
            Thread.Sleep(1000);
            if (savedrecord.Text == "18.05")
            {
                Console.WriteLine("Record saved successfully");
            }
            else
            {
                Console.WriteLine("Recocrd not saved");
            }

            // To Check if user is abel to edit any existing record
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            editbutton.Click();

            //To check if user is able to edit Typecode textbox
            IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/label"));
            TypeCode.Click();


            //To Ckheck if user is able to edit the Typecode from  Time to Material
            IWebElement TimeLink = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            Thread.Sleep(1000);
            TimeLink.Click();

            //To check if user is able to edit the code 
            IWebElement CodeTextBox = driver.FindElement(By.XPath("//*[@id='Code']"));
            CodeTextBox.Clear();
            CodeTextBox.SendKeys("007");

            //To check if user is able to edit the code
            IWebElement DescriptionText = driver.FindElement(By.XPath("//*[@id='Description']"));
            DescriptionText.Clear();
            DescriptionText.SendKeys("abcd007");

            //To check if user is able to edit the price per unit
            //IWebElement PriceText = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            //Thread.Sleep(1000);
            //PriceText.Clear();
            //PriceText.SendKeys("1234");

            //To check if user can save the edited record
            IWebElement SaveTextButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            SaveTextButton.Click();

            //To verify if Edited record is saved Successfrlly
            Thread.Sleep(1000);
            IWebElement EditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            Thread.Sleep(1000);
            if (EditedRecord.Text == "007")
            {
                Console.WriteLine("Edited Record saved successfully Test Passed");
            }
            else
            {
                Console.WriteLine("Edited Recorrd not saved Test Failed");
            }

            //To check if user is able to Delete the existing record

        }
    }
}

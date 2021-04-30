using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace rpawithchrome
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver(@"C:\Users\dougl\.nuget\packages\selenium.chrome.webdriver\85.0.0\driver\newdriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"http://fd###########in.jsp");
            if (driver.Url.Contains("http://f###########n.jsp"))
            {
                driver.FindElement(By.XPath("//*[@name='user']")).SendKeys("########");
                driver.FindElement(By.XPath("//*[@name='password']")).SendKeys("###########");
                driver.FindElement(By.XPath("//*[@id='boton-login']")).Submit();
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\dougl\CsharpProjects\chromerpatest\rpawithchrome\ui.csv");
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
                    string ui = columns[0];
                    string cp = columns[1];
                    string cto = columns[2];
                    gestionar_uuii(ui, cp, cto);
                }
                driver.Close();
            }




            void gestionar_uuii(string uuii, string codigoPostal, string cto)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl(@uuii);
                if (driver.FindElement(By.XPath("//*[@id='btnNew']")).Displayed)
                {
                    driver.FindElement(By.XPath("//*[@id='btnNew']")).Click();
                    if (driver.FindElement(By.XPath("//*[@id='btnFormEditSave']")).Displayed)
                    {
                        driver.FindElement(By.XPath("//*[@name='planta']")).SendKeys("BA");
                        driver.FindElement(By.XPath("//*[@name='cp']")).SendKeys(codigoPostal);
                        driver.FindElement(By.XPath("//*[@id='btnFormEditSave']")).Click();
                        if(driver.FindElement(By.XPath("//*[@class='tableCell']")).Displayed)
                        {
                            driver.FindElement(By.XPath("//*[@class='tableCell']")).Click();
                            driver.FindElement(By.XPath("//*[@id='btnRD']")).Click();
                            if(driver.FindElement(By.XPath("//*[@id='btnFormRDSave']")).Displayed)
                            {
                                driver.FindElement(By.XPath("//*[@name='rd']")).SendKeys(cto);
                                if (driver.Url.Contains("http://fdt############Method=rdSave"))
                                {
                                    Console.WriteLine("[*] Gestionada");
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}

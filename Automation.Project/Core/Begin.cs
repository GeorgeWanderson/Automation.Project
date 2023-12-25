global using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Project.Core
{
    public class Begin : DSL
    {

        #region Funções para acesso ao sistema
        [SetUp]
        public void Start()
        {
            AbreNavegador();
            driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
        }
        #endregion

        #region Finish
        [TearDown]
        public void Finish()
        {
            FechaNavegador();
        }
        #endregion

        #region Abre Navegador
        public void AbreNavegador()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var devMode = new ChromeOptions();
            devMode.AddArgument("disable-cache");
            devMode.AddArgument("start-maximized");

            // Headless
            var headlessMode = new ChromeOptions();
            headlessMode.AddArgument("disable-cache");
            headlessMode.AddArgument("window-size=1920x1080");
            headlessMode.AddUserProfilePreference("download.default_directory", downloadsPath);
            headlessMode.AddArgument("headless");

            if (headless) driver = new ChromeDriver(headlessMode);
            else driver = new ChromeDriver(devMode);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        #endregion

        #region Fecha Navegador

        public void FechaNavegador()
        {
            if (driverQuit) driver.Quit();
            else
            {
                ProcessStartInfo psi = new() { FileName = "taskkill", Arguments = "/F / IM chromedriver.exe" };
                using Process process = new() { StartInfo = psi };
                process.Start(); process.WaitForExit();
            }
        }
        #endregion
    }
}
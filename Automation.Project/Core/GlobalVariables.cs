using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Project.Core
{
    public class GlobalVariables
    {
        public IWebDriver driver;
        public bool driverQuit = false;
        // Define caminho padrão para download dos arquivos
        public string downloadsPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads\";
        // Habilita | Desabilita modo headless
        public bool headless = false;
    }
}

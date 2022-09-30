using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithJavaScript.Module.Helper
{
    // HACK: General Repo  | https://github.com/hlaueriksson/puppeteer-sharp
    // HACK: Documentation | https://gist.github.com/hlaueriksson/4a4199f0802681b06f0f508a2916164d
    public static class JavaScripCSharpFunctions
    {
        public static async Task<string> GetSiteScreenShot(string companyName, string siteUrl)
        {
            string currentDirectory = string.Empty;

            try
            {
                string url = siteUrl;

                Console.WriteLine("Starting Browser");
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
                await using var page = await browser.NewPageAsync();
                await page.GoToAsync(url);
                Console.WriteLine("Going to URL");


                // Take Screen Shop
                currentDirectory = Environment.CurrentDirectory + @"\wwwroot\siteimage" + $"\\{companyName}.png";
                Console.WriteLine(currentDirectory);
                await page.ScreenshotAsync(currentDirectory);
                Console.WriteLine(
                    "\nA screenshot of the Page has been stored on the following path: " + currentDirectory);


                await browser.CloseAsync();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return  currentDirectory;
            }


            return currentDirectory;
        }
    }
}

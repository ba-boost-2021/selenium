using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace BilgeAdam.Automation.Tests
{
    public class PageTestFixture
    {
        [Test]
        public async Task Save_New_Product()
        {
            var driver = new EdgeDriver(@"D:\BilgeAdam")
            {
                Url = "http://localhost:5173"
            };
            var txtName = driver.FindElement(By.Id("txtName"));
            txtName.SendKeys("Yeni Ürün " + Random.Shared.Next(1, 100));

            var categorySelect = driver.FindElement(By.Id("cmbCategory"));
            var cmbCategory = new SelectElement(categorySelect);
            cmbCategory.SelectByValue("3");

            var txtPrice = driver.FindElement(By.Id("txtPrice"));
            txtPrice.SendKeys(Random.Shared.Next(100, 1000).ToString());

            var txtAmount = driver.FindElement(By.Id("txtAmount"));
            txtAmount.SendKeys(Random.Shared.Next(5, 20).ToString());

            var btnSave = driver.FindElement(By.Id("btnSave"));
            btnSave.Click();

            await Task.Delay(2000);
            var alert = driver.SwitchTo().Alert();
            var result = alert.Text;
            alert.Accept();
            Assert.That(result, Is.EqualTo("Kayıt Başarılı"));
            driver.Close();
        }
    }
}
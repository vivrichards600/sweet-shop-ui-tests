package pages

import org.openqa.selenium.{By, Keys, WebDriver}

class SweetShopHomePage(private var driver: WebDriver) {

  var headingText = driver.findElement(By.tagName("h1")).getText
}

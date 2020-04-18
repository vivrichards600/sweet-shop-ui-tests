import org.openqa.selenium.WebDriver
import org.openqa.selenium.chrome.ChromeDriver
import org.scalatest._
import org.scalatestplus.selenium.WebBrowser
import org.scalatest.matchers.should.Matchers
import pages.{SweetShopHomePage}

class SweetShopHomePageTests extends FeatureSpec with GivenWhenThen with Matchers with WebBrowser
  with BeforeAndAfterAll with BeforeAndAfterEach {

  implicit val driver: WebDriver = new ChromeDriver()

  val baseUrl = "https://sweetshop.netlify.app/"
  lazy val sweetShopHomePage = new SweetShopHomePage(driver)

  override def beforeEach() = {
    go to (baseUrl)
  }

  override def afterAll() = {
    quit()
  }

  Feature("Sweet Shop Home Page") {
    Scenario("Verify Title") {
      Given("I am on the Sweet Shop Home Page")

      Then("Page title should be Sweet Shop")
      pageTitle should be("Sweet Shop")
    }

    Scenario("Verify Heading") {
      Given("I am on the Sweet Shop Home Page")

      Then("Heading should be Welcome to the Sweet Shop!")
      assert(sweetShopHomePage.headingText.equals(("Welcome to the sweet shop!")))
    }
  }
}

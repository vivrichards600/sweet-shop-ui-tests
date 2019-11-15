# Workshop Overview

Imagine you wrote tests for the [sweet shop app](https://sweetshop.netlify.com/) (v1) and then some [changes were made a week later](https://sweetshop2.netlify.com/) (v2) which included bugs. Some of these bugs are functional bugs and some of them are visual bugs.

## Description
This workshop involves you writing six (6) automated tests for both versions of the sweet shop app:

* One suite using your preferred traditional functional testing approach
* Another suite which covers the same tests but uses visual AI testing with Applitools

### What You Need Before Getting Started
* Please keep track of approximately how long it takes for you to write your tests the traditional way and the Visual AI way.
* Your test scripts can be written in any language but we may only be able to assist you if you get stuck using on of the following:
Selenium WebDriver (Ruby, Python or C# bindings)
* Only use one of the latest versions of Google Chrome browser (v73+).
* If you are using Selenium, please use Selenium version 3.
* If you can’t automate something, create an empty test and add a comment within the test stating the reason you were unable to automate it.
* Make sure to review the "Main Applitools Concepts" section below to get a high-level understanding of Applitools
When you are writing visual tests, the "V1" application should be used for the "Baseline" and "V2" application should be used for the checkpoint.
* You will need to use the Batching feature to group multiple tests into a single suite/batch. Simply create a batch called "Sweetshop"" and use that batch in all your tests. Then all the screenshots that are part of all the different tests will show up in the same test result.

## Technical Details
* Your task is to automate the following tests (see below) for the 1st version of the sweet shop app (V1) without using Applitools, call it "TraditionalTests.cs", "TraditionalTests.rb", etc, depending on the programming language you are using.
* Once you are happy with the coverage, run the same tests against version two (V2) of the sweet shop app. You are going to find a lot of failures. 
* Create another file to create the same tests but now with Applitools. Call it "VisualAITests.cs" (VisualAITests.rb, VisualAITests.py, etc).
* Run the same test again and see all the differences between the screenshots of the 1st version and the 2nd version of the sweet shop app.

Note: When you run the tests against V2, you’ll see differences in screenshots because the app is actually different. You should see exactly what those differences are (highlighted in pink). However, you’d not need to change any code at all. But instead just manage the screenshots within the Applitools dashboard by adding ignore regions, bug regions and so on.

## 6 Main Tasks To Automate
Below are the six tests you need to write.

### Dynamic Home Page Test
Open the home page and write assertions to ensure everything looks OK on that page. i.e. add assertions to ensure all text, buttons and sweets are displayed (there should be four). The displayed sweets are dynamic and so will be displayed in a different order each time you visit the page.

Notes:
* When you run the same test with the V2 version of the app (https://sweetshop2.netlify.com/), the sweets will be displayed in a different order from when you last visited the page. Your tests need to be smart enough to be aware of the different ordering (feature). For the visual test, It’s recommended that you use a Layout region annotation.
* When you take a screenshot of a page with dynamic content. It’ll constantly change so can’t create a baseline. If you use the "Ignore region", then you can create a baseline. However, you won’t know if the dynamic content goes completely missing. That’s where the "Layout Region" comes in. It’s like an ignore region but doesn’t completely ignore the contents in the region. It only ignore as long as there is some content and structure(or the layout) remains the same but fails if dynamic region is blank.

### Login Page UI Elements Test
Open the login page and write assertions to ensure everything looks OK on that page. i.e. add assertions to ensure all the fields, labels and all other items exist.

Notes:
* In the traditional approach, if you can’t test this or any other test, please write an empty test with a comment explaining your reason. For the visual testing suite, when you run the same test against V2, you’ll see differences. Mark bugs in the Applitools dashboard using the "Bug regions" feature and save the test as a failure.
* If you are confused about some part of the difference and do not know if that’s a bug or a feature, in the real world, you’ll add a "Remark" region to collaborate with the development team and ask questions. In this workshop, create a Remark region in the Applitools dashboard for any differences you’re not sure about.

### Data-Driven Test
Test the following login functionality by entering different values to username and password fields.
* If you don’t enter the username and password and click the login button, it should throw an error
* If you only enter the username and click the login button, it should throw an error
* If you only enter the password and click the login button, it should throw an error
* If you enter both username (any value) and password (any value), it should log you in.

Notes:
* For the visual testing suite, to test functionality (functional testing), you simply need to use Applitools to take a screenshot after the functionality is done (i.e. the end-state of the feature) to verify.
* You will need to use the Batching feature to group multiple tests into a single suite/batch.
* When you use eyes.open, give different test names (with numbers or something dynamic) so that Applitools can create four new screenshot (baselines) for each of the 4 sub tests instead of overriding each screenshot with the next sub-test’s screenshot and creating just one baseline.

### Table Sort Test
Once logged in (use any username and password to login), view the Previous Orders table. Your test should click on the "Order Total" header, and verify that the column is in descending order and that each row’s data stayed in tact after the sorting.

Notes:
* For the visual testing suite, if your viewport is too small and you see a scrollbar, you need to use Applitools "Full page screenshot" to capture a screenshot of the entire window. Alternatively, you may try increasing the viewport size to avoid this.

### Canvas Chart Test
Once logged in, take a look at the "Order Item Breakdown". This displays a bar chart swhowingprevious orders. Assume the values of the chart are coming from test data and the test data will not change across versions. Validate that the bar chart and representing data (number of bars and their heights). They should remain the same across versions. 

### Dynamic Content Test
Test for the existence of a display ad that’s dynamic and at times might go missing, you should see two different "Flash sale" gifs.

Notes:
* When you run the same test with the V2 version of the app (https://sweetshop2.netlify.com/), one of the gifs won’t be displayed and instead will be replaced with a different gif (because ads can change). Your tests need to be smart enough to be aware of the different gif (feature). For the visual test, It’s recommended that you use a Layout region annotation.
* When you take a screenshot of a page with dynamic content. It’ll constantly change so can’t create a baseline. If you use the "Ignore region", then you can create a baseline. However, you won’t know if the dynamic content goes completely missing. That’s where the "Layout Region" comes in. It’s like an ignore region but doesn’t completely ignore the contents in the region. It only ignore as long as there is some content and structure(or the layout) remains the same but fails if dynamic region is blank.

## Getting Started
Please sign up for a Applitools free account that we’ll use for the workshop if you haven't already

Applitools tutorials is the quickest way to get started. It has a ready to use Github repo (that has all the dependencies) and detailed instructions for each test runner and programming language combination.

You may start with this repo as a starting point and make changes like adding traditional test suite to this code.
If you are new to Applitools, we recommend going through at least one of the video courses on [Test Automation University](https://testautomationu.applitools.com/) to learn about the full power of the tool

* [Modern Functional Test Automation Through Visual AI](https://testautomationu.applitools.com//modern-functional-testing/index.html) (48 mins - Directly applicable to this workshop)
* [Automated Visual Testing with Java](https://testautomationu.applitools.com//automated-visual-testing-a-fast-path-to-test-automation-success/index.html)
* [Automated Visual Testing with WebdriverIO](https://testautomationu.applitools.com//automated-visual-testing-javascript-webdriverio/index.html)
* [Automated Visual Testing with C#](https://testautomationu.applitools.com//automated-visual-testing-in-csharp/index.html)

We have also listed the main Applitools concepts below that should be sufficient for you to quickly understand Applitools and use various features for this workshop

### Main Applitools Concepts
* Applitools compares screenshots of the tests using an AI. It compares the 1st test run’s screenshot (aka "Baseline") with the current version (aka "Checkpoint"). If there are no differences then the new test is marked as pass. But if there are differences, you need to take appropriate decisions and tell the AI what to do if such differences happen going forward. To do that, all you need to do is to annotate the screenshot and save it. The difference can be because of 3 reasons:
A new feature was added. In this case, you simply click on the "Thumbs up + Save" button so Applitools will make the new screenshot as the new "baseline" so that for future tests, this new screenshot is used to compare.
A bug was found: In this case, you’ll use the "bug region" feature to create a box around the bug and click Thumbs Down -> Mark as Fail + Save buttons, to save it as a failure.
For differences because of dynamic changes in the app, so everytime you take a screenshot, they are different. In this case, you can mark that dynamic region as an "ignore region", "floating region", "layout region", etc. This will essentially ignore dynamic sections of the screenshot from being compared and only compare the stable regions within the page giving you stable results.
* Baseline - When you first run a visual test, Applitools will take a screenshot. That screenshot becomes a baseline. This is the screenshot all future regression tests are compared against.
* Checkpoint - This is the latest screenshot that Applitools has taken during a regression run.
* Test: Within Applitools, you’ll take screenshots by calling eyes.open, eyes.checkWindow and eyes.close methods, and in that order. This screenshot is called as a "Test" within Applitools. If you have say, 3 steps in your tests, and you want to take three screenshots, you can call eyes.open, eyes.checkWindow, eyse.checkWindow, eyes.checkWindow, eyes.close. Now you’ll have a single test with 3 test steps (screenshots).
* Test Steps: Each screenshot within a Test is called a "Test Step". A single test can have multiple test steps. For example, if you call eyes.checkWindow between eyes.open and eyes.closeAsync methods, you’ll end up with a test with 3 tests steps.
* [Batching](https://help.applitools.com/hc/en-us/articles/360006914772-Batching): Batching allows you to combine multiple tests into a single batch

## Troubleshooting Common Issues
* Forgetting to set your API key (or getting 401 exception).
Resolution: [See here](https://applitools.com/docs/topics/overview/obtain-api-key.html) and [here](https://help.applitools.com/hc/en-us/articles/360018576772-401-Unauthorized-Exception)
* Applitools is not opening the app (appears to crash).
In order to make sure the screenshots are consistent across different tests runs. Applitools uses Viewport as an input. A viewport is simply the size of the screenshot you are taking (width and height). Applitools tries to resize the browser to that size before taking the screenshot. If you are running the app on a small laptop and/or have set the Viewport much larger than the laptop’s screen, then you’ll see this error.
Solution: Simply reduce the height or the width. For more [see here](https://help.applitools.com/hc/en-us/articles/360007188671-Why-is-my-selenium-appium-based-test-failed-to-set-the-viewport-size).
* Not properly loading the API key from the environment variable into your IDE (like Eclipse).
After setting the APPLITOOLS_API_KEY in the environment variable to hold your Applitools API key, open the IDE from the command line terminal (and not from the IDE directly). On Mac, it’d look like this: Open a Terminal and then type: "open ~/Applications/Eclipse.app". This will load Eclipse with all the environment variables.
* Incompatibility between Chrome browser and Chrome driver.
Make sure for your version of Google Chrome, you are using the [corresponding Chrome driver](https://docs.google.com/document/d/1tOFrw7XEXNDBW7S98PMTLkDhIsxEMTfcjQHp2Q7RY7M/edit)

_Copyright Ryan Moody 2021_

### Welcome! Here are my portfolio projects that demonstrate my manual and automated software testing skills:

# Project 1 - Flowchart Utility

![Flowchart Utility](/images/FlowchartUtility.png)

**Skills demonstrated:**
* C#
* XML
* Manual testing
* Functional Testing
* Report Writing
 
**Links:**
* [Read the report here](https://github.com/RyanMoodyPortfolio/Portfolio/raw/main/FlowchartUtility/FlowchartUtility.doc)
* [Source code and example flowcharts](https://github.com/RyanMoodyPortfolio/Portfolio/tree/main/FlowchartUtility)

**Description:**

During the 1980s and 1990s, “Choose Your Own Adventure” (CYOA) books were very popular. Unlike traditional books which are linearly read from start to finish, CYOA books allow you to decide how the story progresses by reading pages in a non-consecutive order. An example of a page from a CYOA book is shown below:

_You are lost in a jungle, it is starting to get dark, and you need to find shelter. You see a clearing in the forest, a nearby stream and a tall, old tree._

_If you decide to:_
* _Enter the forest clearing, turn to page 12_
* _Follow the stream, turn to page 85_
* _Climb the tree, turn to page 27_

My project aimed to create a GUI that can be used to read a CYOA book. This involved:
*	Designing a model for a CYOA book which can be easily processed by a GUI.
*	Implementing the GUI which allows the user to read these models of CYOA books.
*	Confirming that the GUI functions as required through manual testing.
*	Exploring the flexibility of the GUI and how it could be applied to real scenarios.

# Project 2 - Vending Machine

![Vending Machine](/images/VendingMachine1.png)

**Skills demonstrated:**
* HTML
* Bootstrap
* CSS
* JavaScript
* Python
* Pylint
* PyCharm
* Selenium WebDriver
* Page Object Model
* Automated Testing
* Manual Testing
* Functional Testing
* Code linting/validation
 
**Links:**
* [Play with the Vending Machine here](https://ryanmoodyportfolio.github.io/Portfolio/VendingMachine/VendingMachine.html)
* [Source Code and Automated Test Suite](https://github.com/RyanMoodyPortfolio/Portfolio/tree/main/VendingMachine)
* [Proof that the Vending Machine's HTML is valid](https://validator.w3.org/nu/?doc=https%3A%2F%2Fryanmoodyportfolio.github.io%2FPortfolio%2FVendingMachine%2FVendingMachine.html)
* [Proof that the Vending Machine's CSS is valid](https://jigsaw.w3.org/css-validator/validator?uri=https%3A%2F%2Fryanmoodyportfolio.github.io%2FPortfolio%2FVendingMachine%2FVendingMachine.css&profile=css3svg&usermedium=all&warning=1&vextwarning=&lang=en)
 
 **Description:**
 
My simple web-based vending machine allows the user to insert £1 coins and purchase either chocolate (costing £0.70) or lemonade (costing £1.20). The user is shown how much money they have inserted, and other messages based upon their interactions with the vending machine.

I implemented my vending machine using HTML, Bootstrap, CSS and JavaScript

I validated my HTML & CSS using the W3C's validation services (see links above). 

I improved the quality of my JavaScript code using [JSLint](https://jslint.com/)

To verify that my Vending Machine was functioning correctly, I prepared a suite of automated tests using Python and Selenium WebDriver, and utilising the [Page Object Model](https://www.selenium.dev/documentation/en/guidelines_and_recommendations/page_object_models/) design pattern.

I wrote my Python code using PyCharm, and used Pylint to improve the quality of my Python code.

The output of the automated test suite can be seen below:

![Automated Test Suite Output](/images/VendingMachine2.png)

The vending machine can also be manually tested as shown below:

Test No. | Test Procedure | Expected Result | Actual Result
-------- | -------------- | --------------- | -------------
1 | Visit the Vending Machine webpage. | The vending machine is displayed with Message = "Please insert coin(s) and make a selection" and Inserted = "£0.00". | As expected.
2 | Click on the "Insert £1 Coin" button. | Inserted now shows as "£1.00". | As expected.
3 | Click on the "Insert £1 Coin" button again. | Inserted now shows as "£2.00". | As expected.
4 | Close and re-open the Vending Machine webpage | The vending machine is displayed with Message = "Please insert coin(s) and make a selection" and Inserted = "£0.00". | As expected.
5 | Without inserting coins, click on the "Buy" button for chocolate. | The message "Cannot afford chocolate, please insert more coins!" is displayed. | As expected.
6 | Without inserting coins, click on the "Buy" button for lemonade. | The message "Cannot afford lemonade, please insert more coins!" is displayed. | As expected.
7 | Insert £1, and then attempt to buy chocolate. | The message "Enjoy your chocolate! Change = £0.30" is displayed, and Inserted resets to "£0.00". | As expected.
8 | Insert £1, and then attempt to buy lemonade. | The message "Cannot afford lemonade, please insert more coins!" is displayed. | As expected.
9 | Insert another £1, and then attempt to buy lemonade again. | The message "Enjoy your lemonade! Change = £0.80" is displayed, and Inserted resets to "£0.00". | As expected.

_Note - the [chocolate](https://publicdomainvectors.org/en/free-clipart/Chocolate-candy/78781.html) and [lemonade](https://publicdomainvectors.org/en/free-clipart/Vector-drawing-of-lemonade-in-glass/3960.html) images are public domain._

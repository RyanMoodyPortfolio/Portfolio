"""test_suite.py - Copyright Ryan Moody 2021"""
from selenium import webdriver
from selenium.common.exceptions import TimeoutException
from vending_machine import VendingMachine
import logger


class TestSuite:
    """Contains the tests to be executed"""

    def __init__(self):
        """Constructor"""
        self.tests_passed = 0
        self.tests_failed = 0
        self.driver = webdriver.Firefox()
        self.driver.get('https://ryanmoodyportfolio.github.io/Portfolio/VendingMachine/VendingMachine.html')
        self.vending_machine = VendingMachine(self.driver)

    def finish_testing(self):
        """Clear-down & log results once testing has finished"""
        self.driver.quit()
        logger.log_results(self.tests_passed, self.tests_failed)

    def execute_tests(self):
        """Executes the set of tests in the test suite"""
        self.execute_test(self.test_vending_machine_init)
        self.execute_test(self.test_insert_coins)
        self.execute_test(self.test_buy_chocolate_no_money)
        self.execute_test(self.test_buy_lemonade_no_money)
        self.execute_test(self.test_buy_chocolate_with_money)
        self.execute_test(self.test_buy_lemonade_with_money)

    def execute_test(self, test_to_execute):
        """Executes the given test, logs whether it passed or failed,
        and then refreshes the driver before the next test"""
        try:
            test_to_execute()
            logger.log_test_pass(test_to_execute)
            self.tests_passed += 1
        except AssertionError as assertion_id:
            logger.log_test_fail(test_to_execute, assertion_id)
            self.tests_failed += 1
        except TimeoutException:
            logger.log_timeout(test_to_execute)
            self.tests_failed += 1
        finally:
            self.driver.refresh()

    def test_vending_machine_init(self):
        """Tests that the vending machine displays the correct information on start-up"""
        message = self.vending_machine.get_message_text()
        assert message == "Please insert coin(s) and make a selection", "vending_machine_init_1"
        inserted_text = self.vending_machine.get_inserted_text()
        assert inserted_text == "£0.00", "vending_machine_init_2"

    def test_insert_coins(self):
        """Tests that the Insert £1 Coin button is operational"""
        self.vending_machine.insert_one_pound_coin()
        inserted_text = self.vending_machine.get_inserted_text()
        assert inserted_text == "£1.00", "insert_coins_1"
        self.vending_machine.insert_one_pound_coin()
        inserted_text = self.vending_machine.get_inserted_text()
        assert inserted_text == "£2.00", "insert_coins_2"

    def test_buy_chocolate_no_money(self):
        """Tests that chocolate cannot be bought without inserting coins"""
        self.vending_machine.buy_chocolate()
        message = self.vending_machine.get_message_text()
        assert message == "Cannot afford chocolate, please insert more coins!", "buy_chocolate_no_money_1"

    def test_buy_lemonade_no_money(self):
        """Tests that lemonade cannot be bought without inserting coins"""
        self.vending_machine.buy_lemonade()
        message = self.vending_machine.get_message_text()
        assert message == "Cannot afford lemonade, please insert more coins!", "buy_lemonade_no_money_1"

    def test_buy_chocolate_with_money(self):
        """Tests that chocolate can be bought when £1 is inserted
        (chocolate costs £0.70 in the vending machine)"""
        self.vending_machine.insert_one_pound_coin()
        self.vending_machine.buy_chocolate()
        message = self.vending_machine.get_message_text()
        assert message == "Enjoy your chocolate! Change = £0.30", "buy_chocolate_with_money_1"
        inserted_text = self.vending_machine.get_inserted_text()
        assert inserted_text == "£0.00", "buy_chocolate_with_money_2"

    def test_buy_lemonade_with_money(self):
        """Tests that lemonade can be bought when £2 is inserted
        (lemonade costs £1.20 in the vending machine)"""
        self.vending_machine.insert_one_pound_coin()
        self.vending_machine.buy_lemonade()
        message = self.vending_machine.get_message_text()
        assert message == "Cannot afford lemonade, please insert more coins!", "buy_lemonade_with_money_1"
        self.vending_machine.insert_one_pound_coin()
        self.vending_machine.buy_lemonade()
        message = self.vending_machine.get_message_text()
        assert message == "Enjoy your lemonade! Change = £0.80", "buy_lemonade_with_money_2"
        inserted_text = self.vending_machine.get_inserted_text()
        assert inserted_text == "£0.00", "buy_lemonade_with_money_3"


if __name__ == "__main__":
    suite = TestSuite()
    suite.execute_tests()
    suite.finish_testing()

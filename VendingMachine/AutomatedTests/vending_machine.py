"""vending_machine.py - Copyright Ryan Moody 2021"""
from web_interface import click_button
from web_interface import get_text


class VendingMachine:
    """Page Object for the Vending Machine webpage"""

    def __init__(self, driver):
        """Constructor"""
        self.driver = driver

    def buy_chocolate(self):
        """Clicks the Buy button for chocolate"""
        click_button(self.driver, 'buttonBuyChocolate')

    def buy_lemonade(self):
        """Clicks the Buy button for lemonade"""
        click_button(self.driver, 'buttonBuyLemonade')

    def get_message_text(self):
        """Returns the text in the Message textbox"""
        return get_text(self.driver, 'message')

    def get_inserted_text(self):
        """Returns the text in the Inserted textbox"""
        return get_text(self.driver, 'insertedAmount')

    def insert_one_pound_coin(self):
        """Clicks the Insert £1 Coin button"""
        click_button(self.driver, 'buttonInsertOnePoundCoin')

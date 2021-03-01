"""web_interface.py - Copyright Ryan Moody 2021"""
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as ec
from selenium.webdriver.common.by import By


def click_button(driver, button_id):
    """Clicks the button on the webpage with the given button ID"""
    button = get_element(driver, button_id)
    button.click()


def get_text(driver, textbox_id):
    """Returns the text shown in the textbox with the given textbox ID"""
    text_element = get_element(driver, textbox_id)
    text = text_element.get_attribute('value')
    return text


def get_element(driver, element_id):
    """Returns the web element with the given element ID once it becomes available"""
    wait = WebDriverWait(driver, 10)
    element = wait.until(ec.element_to_be_clickable((By.ID, element_id)))
    return element

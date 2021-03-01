// VendingMachine.js - Copyright Ryan Moody 2021
var insertedInPence = 0;

// Adds a zero (if required) to display the given value in two digits
function padZero(value) {
    "use strict";
    if (value < 10) {
        return "0" + value;
    } else {
        return value;
    }
}

// Shows the given message in the Message text box
function showMessage(message) {
    "use strict";
    var messageElement = document.getElementById("message");
    messageElement.value = message;
}

// Converts the given number of pence to "£X.XX"
function convertPenceToPounds(pence) {
    "use strict";
    return "£" + Math.floor(pence / 100) + "." + padZero(pence % 100);
}

// Updates the value shown in the Inserted textbox
function updateInsertedValue() {
    "use strict";
    var insertedAmountElement = document.getElementById("insertedAmount");
    insertedAmountElement.value = convertPenceToPounds(insertedInPence);
}

// Called when Insert £1 coin is clicked
function onInsertOnePoundCoin() {
    "use strict";
    insertedInPence += 100;
    updateInsertedValue();
    showMessage("Please insert coin(s) and make a selection");
}

// Called when a product's Buy button is clicked
function onBuy(productName, productPriceInPence) {
    "use strict";
    if (productPriceInPence > insertedInPence) {
        showMessage("Cannot afford " + productName + ", please insert more coins!");
    } else {
        var change = convertPenceToPounds(insertedInPence - productPriceInPence);
        showMessage("Enjoy your " + productName + "! Change = " + change);
        insertedInPence = 0;
        updateInsertedValue();
    }
}

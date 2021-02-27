var insertedInPence = 0;

function convertPenceToPounds(pence) {
	"use strict";
	return "£" + Math.floor(pence / 100) + "." + padZero(pence % 100); 
}

function padZero(value) {
	"use strict";
	if (value < 10) {
		return "0" + value;
	} else {
		return value;
	}
}

function onInsertOnePoundCoin() {
	"use strict";
	insertedInPence += 100;
	updateInsertedValue();
	showMessage("Please insert coin(s) and make a selection");
}

function updateInsertedValue() {
	"use strict";
	var insertedAmountElement = document.getElementById("insertedAmount");
	insertedAmountElement.value = convertPenceToPounds(insertedInPence);
}

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

function showMessage(message) {
	"use strict";
	var messageElement = document.getElementById("message");
	messageElement.value = message;
}
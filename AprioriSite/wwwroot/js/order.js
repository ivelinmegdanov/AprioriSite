document.getElementById("OrderDateAsp").value = Date();
document.getElementById("PriceAsp").value = parseFloat(document.getElementById("item__price").textContent);
let dynamicPrice = document.getElementById("item__price");
let itemPrice = parseFloat(dynamicPrice.textContent);
document.getElementById("quantity").addEventListener("change", () => {
	if (document.getElementById("quantity").value > 0 && document.getElementById("quantity").value < 100) {
		dynamicPrice.textContent = (itemPrice * parseFloat(document.getElementById("quantity").value)).toFixed(2) + " $";
		document.getElementById("PriceAsp").value = parseFloat(document.getElementById("item__price").textContent);
	}
});

let customImage = window.localStorage.getItem('customImage');
document.getElementById("customImage").src = customImage;
document.getElementById("CustomImageAsp").value = customImage;

function setContent() {
	//alert("Ky!");
	var div = document.getElementById("variableContent");
	var p = document.createElement("p");
	p.innerText = "Контент з файлу addNewContent1.js";
	p.style.color= "blue";
	div.innerHTML = p.outerHTML;
}
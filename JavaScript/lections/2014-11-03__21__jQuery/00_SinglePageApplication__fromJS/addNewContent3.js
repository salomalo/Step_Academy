
function setContent() {
	//alert("Ky!");
	var div = document.getElementById("variableContent");
	var p = document.createElement("p");
	p.innerText = "Контент з файлу addNewContent3.js";
	p.style.color= "violet";
	div.innerHTML = p.outerHTML;
}
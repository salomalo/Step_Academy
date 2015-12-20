
function setContent() {
	//alert("Ky!");
	var div = document.getElementById("variableContent");
	var p = document.createElement("p");
	p.innerText = "Контент з файлу addNewContent2.js";
	p.style.color= "green";
	div.innerHTML = p.outerHTML;
}
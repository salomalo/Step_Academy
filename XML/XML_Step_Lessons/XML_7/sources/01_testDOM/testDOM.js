//створюЇмо екземпл€р парсера MSXML
var doc = new ActiveXObject("MSXML2.DOMDocument.6.0");
//var doc = CreateObject("Microsoft.XMLDOM");

doc.async = false;
doc.validateOnParse = false;
doc.resolveExternals = false;

//завантажуЇмо XML документ дл€ обробки
if(!doc.load("notebook.xml"))	{
	WScript.echo("Error loading file!");
}
//виводимо текстовий вм≥ст завантаженого XML документа
WScript.echo("DOMDocument (text): " + doc.text);

//доступаЇмось до елемента <person> та виводимо його текстовий вм≥ст
WScript.echo("person: " + doc.getElementsByTagName("person").item(1).text);

var node = doc.getElementsByTagName("person").item(1);
WScript.echo("node name    : " + node.nodeName);
WScript.echo("attribute id : " + node.getAttribute("id"));

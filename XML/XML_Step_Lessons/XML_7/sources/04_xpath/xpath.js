function Search() 
{
	var doc = new ActiveXObject("MSXML2.DOMDocument.6.0");
	doc.async = false;
	doc.validateOnParse = false;
	doc.resolveExternals = false;

	//завантажуємо XML документ
	doc.load("users.xml");

	//виводимо ідентифікатор другого користувача
	var attr = doc.selectSingleNode("/users/user[1]/@id");
	WScript.echo("id: " + attr.value);
	
	//відбираємо всіх адміністраторів 
	//та виводимо їх імена і логіни
	var nodes = doc.selectNodes("/users/user[role = 'admin']");
	WScript.echo("Адміністраторів " + nodes.length + " чол.");

	for(var i=0; i<nodes.length; ++i) {
		var user = nodes.item(i);
		WScript.echo("id: " + user.getAttribute("id"));
		WScript.echo("name: " + user.childNodes[0].text);
		WScript.echo("login: " + user.selectSingleNode("login").text);
		WScript.echo();
	}
}

Search();
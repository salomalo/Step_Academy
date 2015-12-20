function Search() 
{
	var doc = new ActiveXObject("MSXML2.DOMDocument.6.0");
	doc.async = false;
	doc.validateOnParse = false;
	doc.resolveExternals = false;

	//����������� XML ��������
	doc.load("users.xml");

	//�������� ������������� ������� �����������
	var attr = doc.selectSingleNode("/users/user[1]/@id");
	WScript.echo("id: " + attr.value);
	
	//�������� ��� ������������ 
	//�� �������� �� ����� � �����
	var nodes = doc.selectNodes("/users/user[role = 'admin']");
	WScript.echo("������������ " + nodes.length + " ���.");

	for(var i=0; i<nodes.length; ++i) {
		var user = nodes.item(i);
		WScript.echo("id: " + user.getAttribute("id"));
		WScript.echo("name: " + user.childNodes[0].text);
		WScript.echo("login: " + user.selectSingleNode("login").text);
		WScript.echo();
	}
}

Search();
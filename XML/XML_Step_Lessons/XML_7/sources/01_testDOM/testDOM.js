//��������� ��������� ������� MSXML
var doc = new ActiveXObject("MSXML2.DOMDocument.6.0");
//var doc = CreateObject("Microsoft.XMLDOM");

doc.async = false;
doc.validateOnParse = false;
doc.resolveExternals = false;

//����������� XML �������� ��� �������
if(!doc.load("notebook.xml"))	{
	WScript.echo("Error loading file!");
}
//�������� ��������� ���� ������������� XML ���������
WScript.echo("DOMDocument (text): " + doc.text);

//����������� �� �������� <person> �� �������� ���� ��������� ����
WScript.echo("person: " + doc.getElementsByTagName("person").item(1).text);

var node = doc.getElementsByTagName("person").item(1);
WScript.echo("node name    : " + node.nodeName);
WScript.echo("attribute id : " + node.getAttribute("id"));

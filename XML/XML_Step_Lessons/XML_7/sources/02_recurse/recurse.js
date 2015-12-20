var cin = WScript.stdIn;      //��������� ���� ��� ����� �����
var cout = WScript.stdOut;    //��������� ���� ��� ������ �����

main();

function main() 
{
	var doc = new ActiveXObject("MSXML2.DOMDocument.6.0");
	doc.async = false;
	doc.validateOnParse = false;
	doc.resolveExternals = false;


	cout.write("Enter file name: ");
	var line = cin.readLine();
	if(!doc.load(line)) 
	{
		cout.writeLine("Error loading file!");
		cout.writeLine("Error Code: " + doc.parseError.errorCode + "<br />");
	        cout.writeLine("Error Reason: " + doc.parseError.reason + "<br />");
	        cout.writeLine("Error Line: " + doc.parseError.line + "<br />");

		WScript.quit(-1);
	}
	walk(doc, 0);
}

function tab(n) 
{
	for(var i=0; i<n; ++i) 
	{
		cout.write("  ");
	}
		
}

function walk(node, level) 
{
	tab(level);

	cout.writeLine("node: " + node.nodeName);
	if(node.nodeType == 1) 
	{ 
		//���� ���� - �� ������� (���)
		tab(level);
		cout.write("element ");
		
		//���������� �������� �������� �� �������� ��� ��� ����������,
                //���� ���� �����
		if(node.attributes.length == 0) 
		{
			cout.writeLine("with no attributes ");
		} else {
			cout.writeLine("with " + node.attributes.length + " attributes");
			for(var i=0; i<node.attributes.length; ++i) 
			{
				var attr = node.attributes.item(i);
				tab(level+1);
				cout.writeLine("attribute: " + attr.name + " = " + attr.value);
			}
		}

	} else 	
		if(node.nodeType == 3) //���� ���� - �� ��������� �����
		{ 
			tab(level);
			cout.writeLine("text: " + node.text);
		} else 
			if(node.nodeType == 9) //���� ���� - �� ��������� ����� ���������
			{ 
				cout.writeLine("document node");
			} else 
				if(node.nodeType == 7) //���� ���� - �� ���������� �� �������
				{
					tab(level);
					cout.writeLine("processing instruction: <?" + node.nodeName + " " + node.nodeValue + "?>");
				} else 
					if(node.nodeType == 8) //���� ���� - �� ��������
					{
						tab(level);
						cout.writeLine("comment: " + node.text);
					}

	//���������� �������� ������� ����� 
	if(node.hasChildNodes())
	{
		for(var i=0;i<node.childNodes.length; ++i) 
		{
			var child = node.childNodes.item(i);

			//�������� ���������� ��� ����� ������� �����	
			walk(child, level+1);
		}
	}
}
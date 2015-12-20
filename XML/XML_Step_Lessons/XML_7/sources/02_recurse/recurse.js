var cin = WScript.stdIn;      //створюємо обєкт для вводу даних
var cout = WScript.stdOut;    //створюємо обєкт для виводу даних

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
		//якщо нода - це елемент (тег)
		tab(level);
		cout.write("element ");
		
		//перевіряємо наявність атрибутів та виводимо про них інформацію,
                //якщо вони наявні
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
		if(node.nodeType == 3) //якщо нода - це текстовий вузол
		{ 
			tab(level);
			cout.writeLine("text: " + node.text);
		} else 
			if(node.nodeType == 9) //якщо нода - це кореневий вузол документа
			{ 
				cout.writeLine("document node");
			} else 
				if(node.nodeType == 7) //якщо нода - це інструкція по обробці
				{
					tab(level);
					cout.writeLine("processing instruction: <?" + node.nodeName + " " + node.nodeValue + "?>");
				} else 
					if(node.nodeType == 8) //якщо нода - це коментар
					{
						tab(level);
						cout.writeLine("comment: " + node.text);
					}

	//перевіряємо наявність дочірніх вузлів 
	if(node.hasChildNodes())
	{
		for(var i=0;i<node.childNodes.length; ++i) 
		{
			var child = node.childNodes.item(i);

			//виводимо інформацію про кожен дочірній вузол	
			walk(child, level+1);
		}
	}
}
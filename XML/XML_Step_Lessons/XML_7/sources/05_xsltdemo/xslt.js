var cin = WScript.stdIn;  
var cout = WScript.stdOut;

function createDom(fileName) {
    var doc = new ActiveXObject("MSXML2.DOMDocument.6.0");
    doc.async = false;
    doc.validateOnParse = false;
    doc.resolveExternals = false;

    if (fileName != null)
       doc.load(fileName);
    return doc;
}

function main() {
	//створюємо посилання на XML-документ та таблицю стилів
    cout.write("Введіть шлях до XML-документа: ");
    var filename = cin.readLine();
	var doc = createDom(filename);

    cout.write("Введіть шлях до XSLT-документа: ");
    filename = cin.readLine();
	var xsl = createDom(filename);

	//трансформуємо XML-документ згідно завантаженої таблиці стилів
	var result = doc.transformNode(xsl);
	
	//створюємо об'єкт FSO для роботи з файловою системою
	var fso = new ActiveXObject("Scripting.FileSystemObject");
	
	//створюємо файл або отримуємо посилання на існуючий
	var file = fso.createTextFile("D:\\result.html", true); 
	//var file = fso.openTextFile("D:\\result.html", 2, true);
	file.write(result);  //записуємо результат трансформації
	file.close();        //закриваємо файл
		
	cout.writeLine(result);
}

main();

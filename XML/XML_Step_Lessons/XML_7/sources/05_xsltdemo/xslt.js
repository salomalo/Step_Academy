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
	//��������� ��������� �� XML-�������� �� ������� �����
    cout.write("������ ���� �� XML-���������: ");
    var filename = cin.readLine();
	var doc = createDom(filename);

    cout.write("������ ���� �� XSLT-���������: ");
    filename = cin.readLine();
	var xsl = createDom(filename);

	//������������ XML-�������� ����� ����������� ������� �����
	var result = doc.transformNode(xsl);
	
	//��������� ��'��� FSO ��� ������ � �������� ��������
	var fso = new ActiveXObject("Scripting.FileSystemObject");
	
	//��������� ���� ��� �������� ��������� �� ��������
	var file = fso.createTextFile("D:\\result.html", true); 
	//var file = fso.openTextFile("D:\\result.html", 2, true);
	file.write(result);  //�������� ��������� �������������
	file.close();        //��������� ����
		
	cout.writeLine(result);
}

main();

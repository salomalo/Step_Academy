var ctx;
var clockRadius = 130;

function init() {
		
	var img = new Image();
	ctx = document.getElementById("canvas").getContext("2d")
			
	// �������� ���
	var date=new Date();
	var hours=date.getHours();
	var minutes=date.getMinutes();
	var seconds=date.getSeconds();
	
	// ������� ���������� ��������
	ctx.save(); 
	
	// ����� ���������� ���������
		img.onload = function() { 
			ctx.drawImage(img, 10, 10, 280, 280);
			}
		img.src ="img/clock_bg.png";
	
	// ����� ������� ��������� � �������� �������
	ctx.translate(canvas.width / 2, canvas.height / 2);		
	ctx.beginPath();
	
	
	//backupCanvas(0,1)
	
	
	// �������� �������
	//ctx.save();   
    var sarrow = (seconds - 15) * 2 * Math.PI / 60;
    ctx.rotate(sarrow); //������� ������ �� ���
	ctx.beginPath();
    ctx.moveTo(-15, -2);
    ctx.lineTo(-15, 2);
    ctx.lineTo(clockRadius * 0.9, 1);
    ctx.lineTo(clockRadius * 0.9, -1);
    ctx.fillStyle = 'orange';
    ctx.fill();
    ctx.restore();  //³��������� ��������� ���� ���� ��� �� ����� ������ ���������

	// ctx.restore();		
	
	setInterval(init, 1000);
}


function backupCanvasByIdx( idxCanvasSrc, idxCanvasDst, isCopy ) {
	var aCanvas	= document.getElementsByTagName("CANVAS");
	if( ! aCanvas || idxCanvasSrc >= aCanvas.length || idxCanvasDst >= aCanvas.length ) return;
	
	var ctxDest = aCanvas[idxCanvasDst].getContext('2d'); 
	var ctxSrc  = aCanvas[idxCanvasSrc].getContext('2d'); 
	
	if( isCopy ){
		ctxDest.save();
		ctxDest.globalCompositeOperation = "copy";
	}

	ctxDest.drawImage( aCanvas[idxCanvasSrc], 0, 0 );
	if( isCopy ) ctxDest.restore();
}
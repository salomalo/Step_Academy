
var canvas;
var context; 

function init() {
	canvas	= document.getElementsByTagName("CANVAS")[0];
	context = canvas.getContext('2d'); 
}


function drawRandomLine() {
	
	var startX	= getRandomInt( 0, canvas.width );
	var startY	= getRandomInt( 0, canvas.height );
	var endX	= getRandomInt( 0, canvas.width );
	var endY	= getRandomInt( 0, canvas.height );
	var width	= getRandomInt( 5, 30 );
	var color	= getRandomColor() ;
	
	context.beginPath();	// починає новий контур !
	context.moveTo( startX, startY );
	context.lineTo( endX, endY );
	context.strokeStyle	= color;
	context.lineWidth	= width;
	context.stroke();
	
	addTR( "Лінія", startX, startY, endX, endY, color, width  );
}


function drawRandomFilledRect() {
	
	var startX	= getRandomInt( 0, canvas.width );
	var startY	= getRandomInt( 0, canvas.height );
	var endX	= getRandomInt( 0, canvas.width );
	var endY	= getRandomInt( 0, canvas.height );
	var width	= getRandomInt( 5, 30 );
	var color	= getRandomColor() ;
	
	context.beginPath();	// починає новий контур !
	//context.moveTo( startX, startY );
	//context.lineTo( endX, endY );
	context.fillStyle	= color;
	context.lineWidth	= width;
	context.fillRect( startX, startY, endX, endY );
	//context.stroke();
	
	addTR( "fillRect", startX, startY, endX, endY, color, width  );
}



function clearCanvas( idxCanvas ) {
	var aCanvas	= document.getElementsByTagName("CANVAS");
	if( ! aCanvas || idxCanvas >= aCanvas.length ) return;
	aCanvas[idxCanvas].width = aCanvas[idxCanvas].width;
}

function backupCanvasByIdx( idxCanvasSrc, idxCanvasDst, isCopy ) {
	var aCanvas	= document.getElementsByTagName("CANVAS");
	if( ! aCanvas || idxCanvasSrc >= aCanvas.length || idxCanvasDst >= aCanvas.length ) return;
	
	var ctxDest = aCanvas[idxCanvasDst].getContext('2d'); 
	var ctxSrc  = aCanvas[idxCanvasSrc].getContext('2d'); 
	
	if( isCopy ){
		ctxDest.save();
		ctxDest.globalCompositeOperation = "copy";	//https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D.globalCompositeOperation
	}
	
	
	// http://www.w3schools.com/tags/canvas_drawimage.asp
	
	// копія цілого 1:1
	ctxDest.drawImage( aCanvas[idxCanvasSrc], 0, 0 );
	
	// копія цілого з масштабуванням
	// ctxDest.drawImage( aCanvas[idxCanvasSrc], 50, 50 , 100, 100);
	
	// копія частини з масштабуванням
	//ctxDest.drawImage( aCanvas[idxCanvasSrc], 100, 100 , 200, 200, 0, 0, 300, 300);

	
	if( isCopy ) ctxDest.restore();
}



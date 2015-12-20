
var canvas	= document.getElementsByTagName("CANVAS")[0];
var context = canvas.getContext('2d'); 


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

function clearCanvas(){
	canvas.width = canvas.width;
	
	var tbody = document.getElementsByTagName("TABLE")[0].tBodies[0];
	while( tbody.children.length  )
		tbody.removeChild( tbody.lastElementChild );
}


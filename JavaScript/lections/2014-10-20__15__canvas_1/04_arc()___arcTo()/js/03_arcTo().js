
var canvas	= document.getElementsByTagName("CANVAS")[0];
var context = canvas.getContext('2d'); 
context.drawPoint	= drawPoint;
context.drawLine	= drawLine;

var pt0 = { x: 10, y: 230 };
var pt1 = { x: 150, y: 10 };
var pt2 = { x: 280, y: 130 };

context.drawPoint( pt0.x, pt0.y, "red");
context.drawPoint( pt1.x, pt1.y, "cyan" );
context.drawPoint( pt2.x, pt2.y, "blue" );
context.drawLine( pt0, pt1, "cyan" );
context.drawLine( pt1, pt2, "green" );

context.beginPath();
context.lineWidth = 7;
context.moveTo( pt0.x, pt0.y );
context.strokeStyle = "rgba( 10, 200, 10, 0.5 )";
context.arcTo( pt1.x, pt1.y, pt2.x, pt2.y, 150 );
context.stroke();

context.strokeStyle = "rgba( 200, 10, 10, 0.3 )";
context.lineTo( pt2.x, pt2.y );
context.stroke();

//context.closePath();


function drawPoint( coordX, coordY, sColor ) {
	this.save();
	var color = sColor || "black";
	this.beginPath();
	this.moveTo( coordX, coordY );
	this.arc( coordX, coordY, 3, 0, 2*Math.PI );
	this.fillStyle = color;
	this.fill();
	this.restore();
}



function drawLine( ptStart, ptEnd, sColor ) {
	this.save();
	var color = sColor || "1px solid black";
	this.beginPath();
	this.moveTo( ptStart.x, ptStart.y );
	this.lineTo( ptEnd.x, ptEnd.y );
	this.strokeStyle = color;
	this.lineWidth = 2;
	this.stroke();
	this.restore();
}





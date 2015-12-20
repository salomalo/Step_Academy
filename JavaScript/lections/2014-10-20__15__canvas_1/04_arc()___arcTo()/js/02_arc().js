
var canvas	= document.getElementsByTagName("CANVAS")[0];
var context = canvas.getContext('2d'); 

context.drawPoint	= drawPoint;	// "причеплюємо" до контексту свій метод -- від одержує контекст як this

var ptStart		= { x: 250, y: 50 };
var ptCenter	= { x: 130, y: 130 };
var ptEnd		= { x: 250, y: 250 };

var angleStart	= 0;//-1/3 * Math.PI;	// кут початку арки
var angleEnd 	= 2*Math.PI;//4/5 * Math.PI;	// кут закінчення арки
var radius		= 100;

//обчислюємо точку початку арки
ptStart.x = Math.round( ptCenter.x + radius * Math.cos(angleStart) );
ptStart.y = Math.round( ptCenter.y + radius * Math.sin(angleStart) );



context.drawPoint( ptStart.x, ptStart.y, "red");
context.drawPoint( ptCenter.x, ptCenter.y, "cyan" );
context.drawPoint( ptEnd.x, ptEnd.y, "blue" );

context.beginPath();
	context.moveTo( ptStart.x, ptStart.y );
	
	
	context.arc( ptCenter.x, ptCenter.y, radius, angleStart, angleEnd, true );
	//context.arc( ptCenter.x, ptCenter.y, 100, -1/3 * Math.PI, 4/5 * Math.PI, false );
	//context.arc( ptCenter.x, ptCenter.y, 100, 0 , 1.9	* Math.PI, false );
	
	context.lineTo( ptEnd.x, ptEnd.y );
	//context.closePath();

	context.strokeStyle = "rgba( 100, 100, 100, 0.5 )";
	context.lineWidth = 7;
context.stroke();


function drawPoint( coordX, coordY, sColor ) {
	this.save();	// зберігає поточний стан контексту у внутрішній стек 
	
	var color = sColor || "black";
	
	this.beginPath();
		this.moveTo( coordX, coordY );
		this.arc( coordX, coordY, 3, 0, 2*Math.PI );
		this.fillStyle = color;
	this.fill();
	
	this.restore(); 	// відновлює стан контексту з внутрішнього стеку
}






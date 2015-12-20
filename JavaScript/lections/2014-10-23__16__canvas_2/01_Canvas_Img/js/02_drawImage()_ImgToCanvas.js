var magnifier;
var imgOutOffPage;

function init() {
	var eImg  = document.getElementsByTagName("img")[0];

	if( ! eImg ){	// якщо зображення на сторінці (в DOM) немає -- завантажимо його з файлу
		imgOutOffPage = document.createElement("img");
		imgOutOffPage.src = "img/2_cr.jpg";
		eImg = imgOutOffPage;
	}
	
	var eCnvs = document.getElementsByTagName("canvas")[0];
	magnifier = new Magnifier( eImg, eCnvs , 1 );
}


function Magnifier( eSrc, eDst, scale ){
	if( !eSrc || !eDst ) return null;
	scale = scale || 1;		// масштаб відображення
	
	var posSrc = { x: 0 , y:  0 };
	var step   = { x:10 , y: 10 };
	
	this.update = update;
	this.moveUp = moveUp;
	this.moveDown = moveDown;
	this.moveLeft = moveLeft;
	this.moveRight = moveRight;
	this.zoomIn = zoomIn;
	this.zoomOut = zoomOut;
	
	this.update();
	
	return this;
	
	
	
	
	function update(){		// виводить фрагмент зображення у канвас з урахуванням позиції і масштабу
	
		// розмір (з урахуванням масштабу) фрагмента img, який копіюватиметься у canvas
		var cxWidthSrc = eDst.width / scale;
		var cxHeightSrc = eDst.width / scale;
		
		eDst.getContext("2d").drawImage(
		
			// перші п'ять параметрів описують зразок, який малюватиметься
			  eSrc							// елемент, з якого береться зображення для малювання по канвасу ( може бути img, canvas, video і т.д.)
			, posSrc.x, posSrc.y 			// координати верхнього лівого кута прямокутника на eSrc -- фрагмета, котрий береться з eSrc
			, cxWidthSrc, cxHeightSrc		// ширина і висота прямокутника -- фрагмета, котрий береться з eSrc
			
			// наступні 4 параметри описують місце на канвасі, у якому той зразок буде промальований
			, 0, 0							// координати верхнього лівого кута прямокутника, в який на канвасі буде промальовано отой фрагмет
			, eDst.width, eDst.height 		// ширина і висота прямокутника, в який на канвасі буде промальовано отой фрагмет (зараз -- розміри сanvas)
		);
	}
	
	
	function check() { 
		posSrc.y = posSrc.y < 0 ? 0 : posSrc.y;
		posSrc.x = posSrc.x < 0 ? 0 : posSrc.x;
		
		var cxSrcWidth  = eDst.width / scale;
		var cySrcHeight = eDst.height / scale;
		
		// if( cxSrcWidth < eSrc.width )
			// scale = eDst.width / eSrc.width;
		// if( cySrcHeight < eSrc.height )
			// scale = eDst.height / eSrc.height;
		
		
		posSrc.y = posSrc.y > eSrc.height - cySrcHeight ? eSrc.height - cySrcHeight : posSrc.y;
		posSrc.x = posSrc.x > eSrc.width -  cxSrcWidth  ? eSrc.width - cxSrcWidth  : posSrc.x;

		update();
		
	}// function check()
	
	
	function moveUp(){
		posSrc.y -= step.y;
		check();
	}
	
	function moveDown(){
		posSrc.y += step.y;
		check();
	}
	
	function moveLeft(){
		posSrc.x -= step.x;
		check();
	}
	
	function moveRight(){
		posSrc.x += step.x;
		check();
	}
	
	function zoomIn(){
		scale *= 1.1;
		check();
	}
	
	function zoomOut(){
		scale *= 0.9;
		check();
	}
	
	
}// function Magnifier( eSrc, eDst, scale )



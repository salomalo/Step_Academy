
// в одному місці ставимо обробники на усі події
$(document).ready( function(){ 			// http://api.jquery.com/ready/
	//alert("Документ завантажено !"); 
	
	// ставить обробник на h1
	$("h1").click( function( event ){	// http://api.jquery.com/click/
		alert(event);
	});
	
	// вішає обробник на параграфи всередині #idFirst
	//$("#idFirst").on( "mouseover", "p:odd", function(){		// http://api.jquery.com/on/
	$("#idFirst").on( "mousemove", "p:odd", function(){
		//this.style.backgroundColor = "yellow" ;
		$(this).append(". ");									// http://api.jquery.com/append/
	});
	
	// вішає обробник на параграфи всередині #idFirst
	//$("#idFirst").on( "mouseout", "p:odd", function(){
	$("#idFirst").on( "mouseleave", "p:odd", function(){
		//this.style.backgroundColor = "yellow" ;
		//$(this).css( "background-color", "yellow" );
		$(this).append("* ");
	});
	
	$("#idFirst").on( "mousedown", "p:even", function( event ){
		$(this).css( "backgroundColor", event.button == 2 ? "red" : "yellow" )
	});
	
	$("#idFirst").on( "mouseup", "p:even", function( event ){
		$(this).css( "backgroundColor", "transparent" );
	});
	
	$("#idFirst").on( "contextmenu", "p:even", function( event ){
		event.preventDefault();		// скасовує дефолтну дію браузера
	});
	
	
	$("#idSecond p").eq(0).hover(		// http://api.jquery.com/hover/		http://api.jquery.com/eq/	
		function(){
			$(this).css( "backgroundColor", "blue" );
		}
		,
		function(){
			$(this).css( "backgroundColor", "transparent" );
		}
	);
	
	
	$("input").focus( function(){
		var oldValue = $(this).css("background");		// getComputedStyle()
		$(this).prop("old" , oldValue );					// причеплюємо до об'єкта "свою" властивість для зберігання старого кольору, щоб передати обробнику blur()
		$(this).css("background","green");
	});
	
	$("input").blur( function(){
		var old = $(this).prop("old");		// читаємо вміст властивості old
		$(this).css("background",old);
	});
	
	
	var $myButton = $('<p style="background-color:yellow"><input type="button" value=".off! all eventsHandlers"></p>');		//створюємо jQ-колекцію з одного елемента: p, котртий містить кнопку
	
	// .on "вішає" обробника на click <input>'a, вкладеного у <p>, на котрого посилається myButton
	//$( myButton ).on( "click" , function(  ){					//	--- вішає на <p>
	$myButton.on( "click" , "input", function(  ){		//	--- вішає на <input>
		//alert("Ku!  "+ this);
		$('*').off( 'mousemove mouseenter mouseleave mousedown mouseup contextmenu hover focus blur' );		// скасовує обробники подій
	});
	//$("h1").after( $myButton );	// додаємо параграф з інпутом після h1
	$("h1").before( $myButton );	// додаємо параграф з інпутом після h1
	
	
	
	
});



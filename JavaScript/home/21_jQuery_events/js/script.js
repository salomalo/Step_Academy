/////////////////////////////наведення курсора
$(document).ready( function(){ 

	$("li").eq(0).hover(		// http://api.jquery.com/hover/		http://api.jquery.com/eq/	
		function(){
			$("#practice input[type=text]").css( "background","red" );
		}
		,
		function(){
			$("#practice input[type=text]").css( "backgroundColor", "transparent" );
		}	
	);
/////////////////////////натиснення лывоъ клавиши (рiзнi властивостi зберегти)
	$("li").eq(1).on( "mousedown", function( event ){
	
		 var oldValue = $("#practice :not([id])").css( "borderStyle");
		 $("#practice :not([id])").prop("old",oldValue);

	$("#practice :not([id])").css( "borderStyle","dotted" );
	});

	
	$("li").eq(1).on( "mouseup", function( event ){
		var old = $("#practice :not([id])").prop("old");	
		
			$("#practice :not([id])").css( "borderStyle",old);
	});


/////////////////////////натиснення правоi клавиши (контекстне меню немаэ бути!!!!!!!!!!!!)
	$("li").eq(2).on( "mousedown", function( event ){
		var oldValue = $("#practice input[type=number]:not([value])").css( "background");
		$("#practice input[type=number]:not([value])").prop("old" , oldValue );
		var old = $("#practice input[type=number]:not([value])").prop("old");
		$(" #practice input[type=number]:not([value])").css( "background", event.button == 2 ? "blue":old );	
	});
	
	$("li").eq(2).on( "contextmenu", function( event ){
		event.preventDefault();		// скасовує дефолтну дію браузера
	});	
	
	$("li").eq(2).on( "mouseup", function( event ){
		$("#practice input[type=number]:not([value])").css( "background","transparent"  )
	});	
	
///////////////////////// проведення повз (рызны властивосты зберегти)
	$("li").eq(3).on( "mousemove", function(){
		var oldValue = $("#practice [id ^= message]").css( "borderStyle");
		$("#practice [id ^= message]").prop("old",oldValue);
		
		$("#practice [id ^= message]").css( "borderStyle","groove" );
	});


	$("li").eq(3).on( "mouseout", function(){	
	//$("li").eq(3).on( "mouseleave", function(){
		var old = $("#practice [id ^= message]").prop("old");
		$("#practice [id ^= message]").css( "borderStyle","none" );
	});
	
		
////////////////////////////	подвийний клик	
	$("li").eq(4).on( "dblclick", function(){	
	var b=$("#practice [class ^= left]").css( "borderRadius");
	if(b=="0px")
		$("#practice [class ^= left]").css( "borderRadius", "50%");
		else{
			$("#practice [class ^= left]").css( "borderRadius","0px" );
		}
	});		
////////////////////////////
		
		function href_zip(){
		$("#practice [href$=zip]").css( "fontWeight","bold" );
		}

		function delete_yel(){
		$("#practice [data-action~=delete]").css( "color","yellow" );
		}

		function delete_any(){
		$("#practice [data-action*=delete]").css( "color","green" );
		}

		function after_h_one(){
		$("#widget-title").next().css( "borderStyle","solid" ).css("borderColor","magenta");
		}

		function after_h_all(){
		$("#widget-title ~a").css( "text-decoration","line-through" );
		}
		
/////////////////////////////////////
		
		function last_el(){
		$("#messages :last-child :not([id])").css( "background","red" );
		}
		
	$("li").eq(10).on( "dblclick", function(){	
		var b=$("#messages :last-child :not([id])").css( "background");
		
	
		if($("#messages :last-child :not([id])").css( "background")==b)
			$("#messages :last-child :not([id])").css( "background", "transparent");
			else{
				$("#messages :last-child :not([id])").css( "background","red" );
			}
	});	
		
		
		
/////////////////////////////////////			
	$("li").eq(11).on( "mousemove", function(){	
		$("#messages li:odd").css( "text-decoration","line-through" );
	});

	$("li").eq(11).on( "mouseout", function(){	
	//$("li").eq(11).on( "mouseleave", function(){
		$("#messages li:odd").css( "text-decoration","none" );
	});
	
});
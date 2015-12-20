function showFunc( funcName ) {

	var names = [ "$", "jQuery" ];
	var idxColumn = names.indexOf( funcName );
	idxColumn < 0 && (idxColumn = names.length);
	
/*	switch( funcName ){		// цей switch робить те ж, що і три попередні рядки
		case "$":
			idxColumn = 0;
			break;
			
		case "jQuery":
			idxColumn = 1;
			break;
			
		default:
			idxColumn = 2;
			break;
			
	}// switch( funcName )
*/	
	
	td = document.getElementsByTagName( "tr" )[1].children[idxColumn];
	
	var getFunc  = new Function( "", "return "+ funcName +";" );
	var function_jQuery = getFunc();

	var eP = td.lastElementChild;
	eP = eP ? eP : td.appendChild( document.createElement( "p" ) );

	// підраховуємо к-ть властивостей за типами
	var nFunc = 0, nObj = 0, nProp = 0, nOther = 0;
	var msg = "typeof( "+ funcName +" ) ='"+ typeof( function_jQuery )	 +"'<br><br>";
	for( var key in function_jQuery ){
		msg += "typeof( "+ funcName +"."+ key +" ) = '"+ typeof( function_jQuery[key] )  +"'<br>";
		nProp++;
		switch( typeof( function_jQuery[key] ) ) {
		
			case 'function':
				nFunc++;
				break;
				
			case 'object':
				nObj++;
				break;
				
			default:
				nOther++;
				break;
				
		}// switch( typeof( func[key] ) )
	}// for( var key in function_jQuery )
	
	msg +="<br>Всього властивостей: "+ nProp +"<br>";
	msg +="в т.ч. функцій: "+ nFunc +"<br>";
	msg +="в т.ч. об'єктів: "+ nObj +"<br>";
	msg +="інших типів: "+ nOther +"<br>";
	eP.innerHTML = msg;
	
}// function showFunc()



function showCustomFunc() {
	var newName_jQuery = document.getElementById( "idFuncName" ).value;
	window[newName_jQuery] = jQuery.noConflict();
	showFunc( newName_jQuery );
	showFunc( "$" );
}// showCustomFunc()



function blink( id ){
	
	var el = document.getElementById( id );
	if( !el ) return;
	
	if( getComputedStyle( el ).opacity > 0 )
		el.style.opacity = "0";
	else
		el.style.opacity = "1";
		
	setTimeout( function(){ blink(id); }, 500 );
	
}// function blink()



function jQueryExists(){
	return typeof( $ ) === "function" || typeof( jQuery ) === "function";	// при успішному підключенні хоча б одна зі стандартних точок входу існуватиме як функція
}//jQueryExists


function check_jQuery(){
	var eMsg = document.getElementById( "idMessage" );
	eMsg.style.margin = "0";
	
	// виводимо повідомлення про реультат підключення jQuery
	if( jQueryExists() ) {
		eMsg.style.color = "green";
		eMsg.innerHTML	 = "jQuery підключено успішно !";
	}
	else {
	
		// робимо кнопки неактивними
		var aButtons = document.getElementsByTagName( "button" );
		for( var i = 0 ; i < aButtons.length ; i++ )
			aButtons[i].setAttribute( "disabled", "true" );		
		var aInputs = document.getElementsByTagName( "input" );
		for( var i = 0 ; i < aInputs.length ; i++ ){
			aInputs[i].setAttribute( "disabled", "true" );		
		}
		
		// виводимо блимаюче попередження
		eMsg.style.color = "red";
		eMsg.style.fontWeight = "bold";
		eMsg.innerHTML	 = "Помилка при підключенні jQuery !";
		blink( "idMessage" );
	}
	
}// check_jQuery()


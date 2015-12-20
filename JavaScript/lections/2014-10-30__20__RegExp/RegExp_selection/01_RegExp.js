



function insertDigits() {
	insertRndChars( "0123456789" );
}




function insertSymbols() {
	insertRndChars( "!@#$%^&*()_[]{}+-=/|*`~,.<>?;:'\"\\" );
}



function insertText() {
	var sInsert = document.getElementById( "idTextInsert" ).value;
	if( !sInsert ) return;

	var selection = window.getSelection();		// поточне виділення на сторіці --  http://learn.javascript.ru/vydelenie-range-textrange-i-selection#selection
	selection.removeAllRanges();				// знімаємо виділення
	
	var nodeText = document.getElementById( "idText" ).firstChild;
	var idxInsert = getRandomInt( 0, nodeText.nodeValue.length -1 );
	var str1 = nodeText.nodeValue.substr( 0, idxInsert );
	var str2 = nodeText.nodeValue.substr( idxInsert );
	nodeText.nodeValue = str1.concat( sInsert, str2 );

	var range = document.createRange();								// новий діапазон в документі -- http://learn.javascript.ru/vydelenie-range-textrange-i-selection#range
	range.setStart( nodeText, idxInsert );							// початок діапазону - символ зі зміщенням idxInsert     у ноді nodeText
	range.setEnd( nodeText, idxInsert + sInsert.length +1 );		// кінець діапазону  - символ зі зміщенням idxInsert +1  у ноді nodeText
	var selection;
	selection.addRange( range );				// додаємо до виділеного ще один діапазон

}



function selectFirst() {
	var selection = window.getSelection();		// поточне виділення на сторіці  http://learn.javascript.ru/vydelenie-range-textrange-i-selection#selection
	selection.removeAllRanges();				// знімаємо виділення
	
	var nodeText = document.getElementById( "idText" ).firstChild;
	var sRegExp  = document.getElementById( "idRegExpText" ).value;
	var idxFound = nodeText.nodeValue.search( sRegExp );		// індекс першого співпадіння 	https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/search
	var aMatches = nodeText.nodeValue.match(  sRegExp );		// масив усіх співпадінь		https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/match
	if( idxFound >= 0 ) {
		var len = aMatches[0].length;							// довжина першого співпадіння
		var range = document.createRange();							// новий діапазон в документі -- http://learn.javascript.ru/vydelenie-range-textrange-i-selection#range
		range.setStart( nodeText, idxFound );					// початок діапазону - символ зі зміщенням idxFound			у ноді nodeText
		range.setEnd( nodeText, idxFound + len );				// кінець діапазону  - символ зі зміщенням idxFound + len 	у ноді nodeText
		selection.addRange( range );							// додаємо до виділеного ще один діапазон
	}
}




function selectAll() {

	var nodeText = document.getElementById( "idText" ).firstChild;
	var selection = window.getSelection();							// поточне виділення на сторіці  http://learn.javascript.ru/vydelenie-range-textrange-i-selection#selection
	selection.removeAllRanges();									// знімаємо виділення
	
	var rxp = new RegExp( document.getElementById( "idRegExpText" ).value, "g" );
	var result = rxp.exec( nodeText.nodeValue );					// для пошуку усіх співпадінь	https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp/exec
	while( result ) {
		var idxFound = result.index;						// індекс знайденого входження (кожен наступний пошук починається з result.lastIndex )
		var len = result[0].length
		var range = document.createRange();					// новий діапазон в документі -- http://learn.javascript.ru/vydelenie-range-textrange-i-selection#range
		range.setStart( nodeText, idxFound );				// початок діапазону - символ зі зміщенням idxFound			у ноді nodeText
		range.setEnd( nodeText, idxFound + len );			// кінець діапазону  - символ зі зміщенням idxFound + len 	у ноді nodeText
		selection.addRange( range );						// додаємо до виділеного ще один діапазон
		result = rxp.exec( nodeText.nodeValue );				// для пошуку наступного співпадіння	https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp/exec
	}

}





function insertRndChars( sChars ) {
	var inputMinPeriod = document.getElementById( "idPeriodMin" );
	var inputMaxPeriod = document.getElementById( "idPeriodMax" );

	if( !inputMinPeriod || !inputMinPeriod.value || !(+inputMinPeriod.value) ) return;
	if( !inputMaxPeriod || !inputMaxPeriod.value || !(+inputMaxPeriod.value) ) return;
	var nodeText = document.getElementById( "idText" ).firstChild;
	
	var range, selection, aidxInserted = [];
	selection = window.getSelection();			// поточне виділення на сторіці --  http://learn.javascript.ru/vydelenie-range-textrange-i-selection#selection
	selection.removeAllRanges();				// знімаємо виділення
	
	var minPeriod = +inputMinPeriod.value;
	var maxPeriod = +inputMaxPeriod.value;
	var idxInsert = getRandomInt( minPeriod, maxPeriod );
	var str1, str2, symb;
	while( idxInsert < nodeText.nodeValue.length ) {
		str1 = nodeText.nodeValue.substr( 0, idxInsert );
		str2 = nodeText.nodeValue.substr( idxInsert );
		symb = sChars.charAt( getRandomInt( 0, sChars.length-1) );
		nodeText.nodeValue = str1.concat( symb, str2 );
		
		aidxInserted.push( idxInsert );
		for( var i = 0 ; i < aidxInserted.length ; i++ ) {
			range = document.createRange();						// новий діапазон в документі -- http://learn.javascript.ru/vydelenie-range-textrange-i-selection#range
			range.setStart( nodeText, aidxInserted[i] );		// початок діапазону - символ зі зміщенням aidxInserted[i]     у ноді nodeText
			range.setEnd( nodeText, aidxInserted[i] +1 );		// кінець діапазону  - символ зі зміщенням aidxInserted[i] +1  у ноді nodeText
			selection.addRange( range );						// додаємо до виділеного ще один діапазон
		}
		
		idxInsert += getRandomInt( minPeriod, maxPeriod );
	}

}









function getRandomInt( min, max ) {
	return Math.floor(Math.random() * (max - min + 1)) + min;
}

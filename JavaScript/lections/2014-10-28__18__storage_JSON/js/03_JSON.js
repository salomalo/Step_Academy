

function addData() {
	//var str = prompt( "Enter the string", "" );
	var str = document.getElementById("idText").value;
	if( !str ) {
		document.getElementById("idOut").innerHTML = "<span style='color:red;'>Не додано з пустим текстом</span>";
		return;
	}
	
	var num = getRandomInt( 0, 999 );
	var obj = {
		  string: str
		, number: num
	}
	obj.date = new Date();
	
	var arr = addToLocal( obj );
	
	var text = "Додано об'єкт: <br>";
	for( var key in obj ){
		text += "&nbsp; &nbsp; &nbsp;"+ key +" = "+ obj[key] +"&nbsp; &nbsp; &nbsp;("+ typeof( obj[key] ) +")<br>";
	}

	document.getElementById("idOut").innerHTML = text;
	
	
	var p = document.body.lastElementChild;
	var text = "";
	for( var i = 0; i < arr.length ; i++ ) {
		text += arr[i].string;
		text += " ("+ typeof( arr[i].string ) +") &nbsp; &nbsp; &nbsp;" ;
		text += arr[i].number;
		text += " ("+ typeof( arr[i].number ) +")  &nbsp; &nbsp; &nbsp;" ;
		text += arr[i].date;
		text += " ("+ typeof( arr[i].date ) +") &nbsp; &nbsp; &nbsp<br/>" ;
	}
	p.innerHTML = text;
}



function addToLocal( obj ){
	var arr = [];
	
	if( localStorage.testJSONdataArr && localStorage.testJSONdataArr.length > 0)	// якщо у localStorage.testJSONdataArr щось є
		var arr = JSON.parse( localStorage.testJSONdataArr );						// відновлюємо з нього масив
		
	// відновлюємо тип поля date	
	for( var i = 0 ; i < arr.length ; i++ ) {
		arr[i].date = new Date(arr[i].date);
	}
	
	arr.push( obj );	// до масиву додаємо новостворений об'єкт
	
	
	localStorage.testJSONdataArr = JSON.stringify( arr ); 	// масив зберігаємо у localStorage перетвореним до JSON
	
	
	return arr;
}




function getRandomInt( min, max ) {
	return Math.floor(Math.random() * (max - min + 1)) + min;
}



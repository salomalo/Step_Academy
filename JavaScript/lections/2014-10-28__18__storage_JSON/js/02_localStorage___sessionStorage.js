
function updateAll() {
	reportLS(); 
	reportSS();
	(document.getElementsByTagName("H1")[0]).nextElementSibling.innerHTML = decodeURI( location.href ); 
}




function reportLS(){
	document.getElementById("idLengthLS").innerHTML = localStorage.length;
	
	tdLocalStorage = document.getElementById( "idLocalStorageTD" );
	if( (! tdLocalStorage ) || tdLocalStorage.lastElementChild.tagName !== "P" ) return;
	
	var htmlContentLS = "";
	for( var key in localStorage ) {
		if( htmlContentLS.length ) htmlContentLS += "<br/>";
		htmlContentLS += "'"+ key +"' = '"+ localStorage[key] +"'";
	}
	
	tdLocalStorage.lastElementChild.innerHTML = htmlContentLS;
	
}




function addPropertyLS() {
	var key = document.getElementById( "idNewKeyLS" );
	var val = document.getElementById( "idNewValueLS" );
	if( !key || !val ) return;
	
	//localStorage[key.value] = val.value
	localStorage.setItem( key.value, val.value );
	
	key.value = "";
	val.value = "";
	
}



function removePropertyLS() {
	var key = document.getElementById( "idRemoveKeyLS" );
	
	//delete localStorage[ key.value ];
	localStorage.removeItem( key.value );
	
	key.value = "";
}




function reportSS(){
	document.getElementById("idLengthSS").innerHTML = sessionStorage.length;
	
	tdSessionStorage = document.getElementById( "idSessionStorageTD" );
	if( (! tdSessionStorage ) || tdSessionStorage.lastElementChild.tagName !== "P" ) return;
	
	var htmlContentSS = "";
	for( var key in sessionStorage ) {
		if( htmlContentSS.length ) htmlContentSS += "<br/>";
		htmlContentSS += "'"+ key +"' = '"+ sessionStorage[key] +"'";
	}
	
	tdSessionStorage.lastElementChild.innerHTML = htmlContentSS;
	
}



function addPropertySS() {
	var key = document.getElementById( "idNewKeySS" );
	var val = document.getElementById( "idNewValueSS" );
	if( !key || !val ) return;
	
	sessionStorage[key.value] = val.value
	//sessionStorage.setItem( key.value, val.value );
	
	key.value = "";
	val.value = "";
	
}



function removePropertySS() {
	var key = document.getElementById( "idRemoveKeySS" );
	
	delete sessionStorage[ key.value ];
	//sessionStorage.removeItem( key.value );
	
	key.value = "";
}





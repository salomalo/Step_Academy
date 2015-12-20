
function updateAll() {
	var aCookies = getCookies();
	
	document.getElementById("idLengthCookies").innerHTML = aCookies.length;
	
	tdCookies = document.getElementById( "idCookiesTD" );
	if( (! tdCookies ) || tdCookies.lastElementChild.tagName !== "P" ) return;
	
	var htmlContent = "";
	for( var i = 0 ; i < aCookies.length ; i++ ) {
		if( htmlContent.length ) htmlContent += "<br/>";
		htmlContent += "'"+ aCookies[i].key +"' = '"+ aCookies[i].val +"'";
	}
	
	tdCookies.lastElementChild.innerHTML = htmlContent;
	
}


function getCookies() {
	var sCookies = document.cookie;
	var aCookies = sCookies.split("; ")
	for( var i = aCookies.length -1 ; i >= 0 ; i--  ) {
		var curCookie = aCookies[i];
		var posEquate = curCookie.indexOf("=");
		aCookies[i] = { 
			  key: curCookie.substr( 0, posEquate )
			, val: decodeURIComponent( curCookie.substr( posEquate + 1 ) )
		}
	}
	
	return aCookies;
}



function clearCookies() {
	var aCookies = getCookies();
	for( var i = aCookies.length - 1 ; i >= 0 ; i--  ) {
		document.cookie = aCookies[i].key +"="+ "; max-age=0"
	}

}



function removeKey() {
	var key = document.getElementById( "idRemoveKey" );
	if( ( ! key ) || ( ! key.value ) ) return;
	
	document.cookie = key.value +"=; max-age=0";
	key.value = "";
}



function addCookie() {
	
	var eKey = document.getElementById( "idNewKey" );
	if( !eKey || !eKey.value ) return;
	
	var eValue = document.getElementById( "idNewValue" );
	var sValue = ""; 
	if( eValue ) {
		sValue = eValue.value;
		if( sValue.indexOf(";") >= 0 || sValue.indexOf(" ") >= 0 ) {
			sValue = encodeURIComponent( sValue );
		}
	}
	
	var eMaxAge = document.getElementById( "idMaxAge" );
	var sMaxAge = "";
	if ( eMaxAge && eMaxAge.value ) {
		sMaxAge = "; max-age="+ eMaxAge.value;
	}
	
	var ePath = document.getElementById( "idPath" );
	var sPath = "";
	if ( ePath && ePath.value ) {
		sPath = "; path="+ encodeURIComponent( ePath.value );
	}
	
	var eDomain = document.getElementById( "idDomain" );
	var sDomain = "";
	if ( eDomain && eDomain.value ) {
		sDomain = "; domain="+ encodeURIComponent( eDomain.value );
	}
	
	var sNewCookie = eKey.value +"="+ sValue
						+ sMaxAge
						+ sPath
						+ sDomain
	
	
	// хоча ми присвоюємо об'єкту document.cookie нове значення, насправді воно додається до існуючого
	document.cookie = sNewCookie;
/*
	eKey.value = "";
	eValue.value = "";
	eMaxAge.value = "";
	ePath.value = "";
	eDomain.value = "";
*/
}
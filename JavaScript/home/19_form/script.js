
function send(form) {

	//var reg = new RegExp("s","^[A-Z]","m" );

	var name=document.getElementById("name").value;
	var space = /\s/;    //spaces
	var res = space.test( name );

	var two_words=/^[A-Z]/m; // 2 words
	var res2 = two_words.test( name );
		
	var nametest=/^[A-Z][a-z]+@\s/;
	var r4=nametest.test( name );

		// x(?=y)
		
	//if( res && res2  ){
	if( r4  ){
	alert("A   and   Dd d");
	}

///////////////////
	var url=document.getElementById("url").value;
	var protokol_1 = new RegExp( "^((https?|ftp)\:\/\/)?([a-z0-9]{1})((\.[a-z0-9-])|([a-z0-9-]))*\.([a-z]{2,6})(\/?)$" );

	var res3 = url.search( protokol_1 );
	
	if( !res3 ){
		alert("http:// or https://");
	}
	
//////////////////////////////
	
	
	var email=document.getElementById("email").value;
	var test =/[0-9a-z_]+@[0-9a-z_^.]+.[a-z]{2,3}/i
	var res6 = test.test( email );
	
	if( res6){
		alert("em");
	}

}
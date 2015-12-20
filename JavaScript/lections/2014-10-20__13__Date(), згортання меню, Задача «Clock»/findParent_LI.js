

function onEvent( event ) {
	
	var eParent = event.target.parentElement;
	while( eParent && eParent.tagName != "LI"  )
		eParent = eParen.parentElement;
	
	// у цьому місці в eParen буде посилання на найближчого батька "LI" або null
	
}

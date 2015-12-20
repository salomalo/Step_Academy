$(document).ready( function(){ 

	document.oncontextmenu = function() {return false;};  

	$(window).mousedown(function(event){
		
		// var target = $("#context-menu"); 
		$(".context-menu").remove();
				if(event.button==2){
						$("<ol/>",{class:'context-menu'})
							.css ({ top: event.offsetY , left: event.offsetX})
									.append('<li> Cut </li>')
									.append("<li> Copy </li>")
									.append("<li> Paste </li>")
									.append("<li> Delete </li>")
									.append("<li> Select </li>")
									.append("<li> Hide </li>")	
							.appendTo("body")		
				}
						
			if(event.button==0){
				$('.context-menu').remove();// Удаляем предыдущие вызванное контекстное меню 
			}
			
			if( $("#event.target").css("top") ){
				$('.context-menu').remove();// Удаляем предыдущие вызванное контекстное меню 
			}	
			
		
		});
 }); 
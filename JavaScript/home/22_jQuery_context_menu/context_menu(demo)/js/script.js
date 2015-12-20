$(document).ready( function(){ 

	document.oncontextmenu = function() {return false;};  

	// $("body").on( "contextmenu", function( event ){
		// event.preventDefault();		// скасовує дефолтну дію браузера
	// });


	
	    
	$(document).mousedown(function(event) {// Вешаем слушатель события нажатие кнопок мыши для всего документа                  
	         
		$('*').removeClass('selected-html-element');// Убираем css класс selected-html-element у абсолютно всех элементов на странице с помощью селектора "*"         
				 
		$('.context-menu').remove();// Удаляем предыдущие вызванное контекстное меню                  
				 
			if (event.which === 3)  {  // Проверяем нажата ли именно правая кнопка мыши                        
						 
				var target = $(event.target);  // Получаем элемент на котором был совершен клик                     
							 
				target.addClass('selected-html-element'); // Добавляем класс selected-html-element что бы наглядно показать на чем именно мы кликнули (исключительно для тестирования)             
							 
				$('<div/>', { // Создаем меню               
				class: 'context-menu' 
				// Присваиваем блоку наш css класс контекстного меню:             
				}).css({
					left: event.pageX+'px',// Задаем позицию меню на X                  
					top: event.pageY+'px' // Задаем позицию меню по Y           
				}).appendTo('body')// Присоединяем наше меню к body документа            
				.append($('<ul/>').append('<li><a href="#">element</a></li>')                                  
								.append('<li><a href="#">element</a></li>')                                 
								.append('<li><a href="#">element</a></li>')                                  
								.append('<li><a href="#">element</a></li>')                                 
								.append('<li><a href="#">element</a></li>') 
							)             
							.show('fast'); // Показываем меню с небольшим стандартным эффектом jQuery. Как раз очень хорошо подходит для меню         
			 }     
	}); 
 
 }); 
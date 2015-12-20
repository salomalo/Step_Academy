var deg = Math.PI/180; // Для преобразования градусов в радианы 

// взято з книги Фленагана стр.684 -- там і пояснення

// Рисует n-уровневый фрактал снежинки Коха в контексте холста с, левый нижний угол 
// которого имеет координаты (х,у), а длина стороны равна len. 
function snowflake(c, n, x, у, len) { 
	c.save(); 			// https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D#save%28%29
	c.translate(x,у); 	// https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D#translate%28%29
	c.moveTo(0,0); 		// 
	leg(n); 			// 
	c.rotate(-120*deg); // https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D#rotate%28%29
	leg(n); 			// 
	c.rotate(-120*deg); // 
	leg(n); 			// 
	c.closePath(); 		// 
	c.restore(); 		// https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D#restore%28%29



	// Рисует одну ветвь n-уровневой снежинки Коха. Эта функция оставляет 
	// текущую позицию в конце нарисованной ветви и смещает начало координат так, 
	// что текущая точка оказывается в позиции (0,0). 
	// Это означает, что после рисования ветви можно вызвать rotate(). 
	function leg(n) { 
		c.save(); 
		if (n == 0) { 
			c.lineTo(len, 0); 
		} 
		else { 
			c.scale( 1/3, 1/3 ); 	// https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D#scale%28%29
			leg(n-1); 
			c.rotate(60*deg); 
			leg(n-1); 
			c.rotate(-120*deg) 
			leg(n-1); 
			c.rotate(60*deg); 
			leg(n-1); 
		} 
		c.restore(); 
		c.translate(len, 0); 
	} 
} 


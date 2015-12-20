function txt_red(){
$("#practice input[type=text]").css( "background","red" );
}

function  without_id(){
$("#practice :not([id])").css( "borderStyle","dotted" );
}

function input_number(){
$(" #practice input[type=number]:not([value])").css( "background","blue" );
}

function el_start_from_id(){
$("#practice [id ^= message]").css( "borderColor","magenta" );
}

function class_left(){
$("#practice [class ^= left]").css( "borderRadius","50%/50%" );
}

function href_zip(){
$("#practice [href$=zip]").css( "fontWeight","bold" );
}

function delete_yel(){
$("#practice [data-action~=delete]").css( "color","yellow" );
}

function delete_any(){
$("#practice [data-action*=delete]").css( "color","green" );
}

function after_h_one(){
$("#widget-title").next().css( "borderStyle","solid" ).css("borderColor","magenta");
}

function after_h_all(){
$("#widget-title ~a").css( "text-decoration","line-through" );
}

function last_el(){
$("#messages :last-child :not([id])").css( "background","red" );
}

function evry_second(){
$("#messages li:odd").css( "text-decoration","line-through" );
}
/*
   File       : sapinho.cpp
   Description: Implementation of the DATA class
   Copyright  : You may freely use and distribute this code!
   Compiller  : Borland Turbo C++ 2.0 (and family)

   A Simple Menu (for Console)
   ===========================

   I can still remember my 80386 with MS-DOS and all the games. I needed a
   menu to star all of them (with the arguments) so I created this. Of course,
   I was only 13 that time, so the code was a little "buggie". I made a few
   changes and decided to put it online...Have fun!

   Uses UP, DOWN, PGUP, PGDOWN, ENTER and ESC keys.


   How to use the class
   ====================

   You should include the header file sapinho.h (of course!) and compile
   sapinho.cpp together with the main file.

   Declare the class and use the following functions (from inside it) to:

 -> fill("Games 1", 1);
     Input the text "Games 1" as the option number 1 (second argument);
       Option number goes from 1 to 23;
 -> set_line(4);
     Used to set the line in which the menu will start
       If the line will be the first (as default) you don't need to use this;
 -> set_colm(2);
     Used to set the column in which the menu will start
       If the column will be the first (as default) you don't need to use this;
 -> main_menu(answer);
     Main menu function;
        answer is a int declared in your program, which will return the value
        of the chosen option or 69 if the ESC key was used.

   I also added some comments all around the source so begginers can see how
   and why I did some stuff.

   There are still some great things that can be done with this code. (eg. 
   use the first letter of the menu to access the option.)
   If I have some time I'll do that but, if you want a "clue", you must
   add in the main_menu() an option to verify the value of names[n][0],
   where n goes from 0 to --total_menu;


   Why with a class?
   =================

   I used a class to build this because you can (if you want) create
   sub-menus with the same object, only with different declarations.
   (eg.)
    DATA menu1;     // for the main menu
    //and, after the answer
    DATA submenu1;  // for the submenu
    //see?!?




*/
#include "sapinho.h"

void DATA::main_menu(int &resposta) {
   int keyboard_read, menu_option = 1, PASSES = 1;
   draw_menu(menu_option);
   while (PASSES) {
      keyboard_read = getch();
      if (keyboard_read == 0) {
	 keyboard_read = getch();
      }
      switch(keyboard_read) {
	 case 72:
	    if (menu_option == 1) {
	       menu_option = total_menu;
	    }
	    else {
	       menu_option -=1;
	    }
	 break;
         case 73:                                   
	    menu_option = 1;
	 break;
         case 81:                                   
	    menu_option = total_menu;
	 break;
	 case 80:
	    if (menu_option == total_menu) {
	       menu_option = 1;
	    }
	    else {
	       menu_option += 1;
	    }
	 break;
	 case 13:
	    PASSES = 0;
	 break;
	 case 27:
	    PASSES = 0;
	 break;
	 default:
	 break;
      }
      if (keyboard_read != 13 && keyboard_read != 27)
	 draw_menu(menu_option);
   }
   if (keyboard_read == 27) {
      resposta = (+69);         //+69  (more sixty-nine!) the number!!!
   }
   else {
      resposta = menu_option;
   }
}






void DATA::fill(char temp_name[50], int where) {
   strcpy(names[--where], temp_name);
   total_menu++;
}



void DATA::draw_menu(int draw_option){
   int temp_go1, temp_go2;
   temp_go1 = colm;
   temp_go2 = line;
   draw_option -= 1;
   for (int tmp = 0; tmp < total_menu; tmp++) {
      gotoxy(temp_go1, temp_go2);
      if (tmp == draw_option) {
	 textcolor(15);
	 textbackground(7);
      }
      else {
	 textcolor(7);
	 textbackground(0);
      }
      cprintf("%s", names[tmp]);
      temp_go2++;
   }
}



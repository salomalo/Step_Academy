/*
   File       : sapinho.h         (see sapinho.cpp)
   Copyright  : You may freely use and distribute this code!
   Compiller  : Borland Turbo C++ 2.0 (and family)
*/
#if !defined (__SAPINHO_H)
#define __SAPINHO_H

#include <conio.h>    // for getch(), gotoxy(), etc..
#include <string.h>   // for strcpy()


//let's give some extra-work to the pre-processor ;-)
#define MAX_REG 24               //23 possible menu lines
#define MAX_CHARS 40             //40 characters to the menu option


class DATA {
   public:
      DATA():total_menu(0),line(1),colm(1) { };        //start ints
      ~DATA() {} ;                                     
      void fill(char temp_names[41], int where);
      void main_menu(int &resposta);
      void set_line(int temp_line) { line = temp_line; }
      void set_colm(int temp_colm) { colm = temp_colm; }
   private:
      int line;
      int colm;
      int total_menu;
      char names[MAX_REG][(MAX_CHARS+1)];
      void draw_menu(int draw_option);
};
#endif


#include <iostream.h>   // for cout
#include "sapinho.h"

int main()
{
   clrscr();
   int lop = 1;
   DATA *data = new DATA;                //put data on heap
   if (data == NULL) {                   // no memory?!
      cout << "Not enough memory!";
      return 1;
   }
   data->fill("Aplications", 1);
   data->fill("Games      ", 2);
   data->fill("Prompt     ", 3);
   data->fill("Calculator ", 4);
   data->fill("Quit     ", 5);

   data->set_line(10);                   // for line 1, erase this
   data->set_colm(34);                   // for column 1, erase this
   _setcursortype(_NOCURSOR);            // cursor off
   int answer;
   while (lop) {
//      clrscr();                    //clears the screen before option
      data->main_menu(answer);           //call menu
      switch(answer) {
	 case 1:
	    //execution of option 1;
	 break;
	 case 2:
	    //execution of option 2;
	 break;
	 case 3:
	    //execution of option 3;
	 break;
	 case 4:
	    //execution of option 4;
	 break;
	 case 5:
	    //execution of option 5;
	    lop = 0;
	 break;
	 case 69:
	    //execution of 69 - esc key
	    lop = 0;
	 default:
	 break;
      }
   }
   _setcursortype(_NORMALCURSOR);        //cursor on
   delete data;                           //clears heap
   return 0;
}

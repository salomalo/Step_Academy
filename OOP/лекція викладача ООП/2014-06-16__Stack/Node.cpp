#include "Node.h"



Node::Node( int value, Node *pPrev )
	: value( value ), pPrev( pPrev )
{}



Node::~Node()
{
	if( !pPrev )
		return;

	delete pPrev;
}

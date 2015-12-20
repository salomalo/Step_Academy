

namespace NamespaceFromHeader
{

	class MyClass
	{

	public:
		MyClass();



	private:

		// оголосивши приватними оператор присвоєння та конструктор копій
		// ми забороняємо їх використання
		// тоді компілятор вкаже нам, коли він не зможе без них обійтися
		//
		MyClass & operator = (MyClass & );
		MyClass( MyClass & );

	}; // class MyClass

}// namespace NamespaceFromHeader
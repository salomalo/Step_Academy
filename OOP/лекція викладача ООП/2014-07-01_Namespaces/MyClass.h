

namespace NamespaceFromHeader
{

	class MyClass
	{

	public:
		MyClass();



	private:

		// ���������� ���������� �������� ��������� �� ����������� ����
		// �� ����������� �� ������������
		// ��� ��������� ����� ���, ���� �� �� ����� ��� ��� �������
		//
		MyClass & operator = (MyClass & );
		MyClass( MyClass & );

	}; // class MyClass

}// namespace NamespaceFromHeader
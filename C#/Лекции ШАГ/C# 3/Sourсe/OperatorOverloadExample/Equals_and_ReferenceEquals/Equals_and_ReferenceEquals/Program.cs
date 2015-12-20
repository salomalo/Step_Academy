using System;

namespace Equals_and_ReferenceEquals
{
class  CPoint
 {
   private int x, y;
    public CPoint(int x, int y)
    {
        this.x = x; this.y = y;
    }
 }

struct  SPoint
{
    private int x, y;
    public SPoint(int x, int y)
    {
        this.x = x; this.y = y;
    }
}
class Program
{
    static void Main()
    {
        //������ ������ ReferenceEquals � �������� � �������� ������
        //��������� ���
        CPoint p = new CPoint(0, 0);
        CPoint p1 = new CPoint(0, 0);
        CPoint p2 = p1;
        Console.WriteLine("ReferenceEquals(p, p1)= {0}", ReferenceEquals(p, p1)); //false
        //���� p,p1�������� ���������� ��������, ��� ��������� �� ������ ������ ������
        Console.WriteLine("ReferenceEquals(p1, p2)= {0}", ReferenceEquals(p1, p2));//true
        //p1 � p2 ��������� �� ���� � ��� �� ����� ������

        //������� ���
        SPoint p3 = new SPoint(0, 0);
        //��� �������� � ����� ReferenceEquals ����������� ��������, 
        //����������� ������� ������������� �� ������ �������
        Console.WriteLine("ReferenceEquals(p3, p3) =  {0}", ReferenceEquals(p3, p3)); //false

        //������ ������ Equals � �������� � �������� ������
        //��������� ���
        CPoint cp = new CPoint(0, 0);
        CPoint cp1 = new CPoint(0, 0);
        Console.WriteLine("Equals(cp, cp1) =  {0}", Equals(cp, cp1)); //false
        //����������� ��������� �������

        //������� ���
        SPoint sp = new SPoint(0, 0);
        SPoint sp1 = new SPoint(0, 0);
        Console.WriteLine("Equals(sp, sp1) =  {0}", Equals(sp, sp1)); //true
        //����������� ��������� �������� ����� 
        Console.ReadLine();
    }
}
}

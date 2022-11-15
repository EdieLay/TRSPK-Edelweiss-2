// See https://aka.ms/new-console-template for more information
using System.Collections;

A a1 = new A(5, 5);
A a2 = new A(2, 2);
A a3 = new A(7, 8);
CustomArray<A> aArray = new CustomArray<A>(3);
aArray[0] = a1;
aArray[1] = a2;
aArray[2] = a3;

// Вывод op2 у всех элементов
Console.WriteLine(aArray);
aArray.Sort();
Console.WriteLine(aArray);

// Смена значений поля op2 у всех элементов
foreach (A item in aArray)
{
    item.op2--;
}

Console.WriteLine(aArray);

B b1 = new B("wow", 145.35);
B b2 = new B("alright, no fighting", 2);
B b3 = new B("weewoo weewoo YesYes YesYes", -0.153);
CustomArray<B> bArray = new CustomArray<B>(3);
bArray[0] = b1;
bArray[1] = b2;
bArray[2] = b3;

Console.WriteLine(bArray);
bArray.Sort();
Console.WriteLine(bArray);

// Смена значений поля op2 у всех элементов
foreach (B item in bArray)
{
    item.op1 = "got it";
}

bArray.Sort();
Console.WriteLine(bArray);



public interface ICustomComparable<T>
{
    int CustomCompare(T val);
}

public class CustomArray<T> : IEnumerable where T: ICustomComparable<T>
{
    T[] valueArr;
    public CustomArray(int count)
    {
        valueArr = new T[count];
    }
    public void Sort()
    {
        for (int i = 0; i < valueArr.Length; i++)
        {
            for (int j = 0; j < valueArr.Length - i - 1; j++)
            {
                if (valueArr[j].CustomCompare(valueArr[j + 1]) > 0)
                {
                    T temp = valueArr[j];
                    valueArr[j] = valueArr[j + 1];
                    valueArr[j + 1] = temp;
                }
                }
            }
        }

    public IEnumerator GetEnumerator()
    {
        return valueArr.GetEnumerator();
    }

    public T this[int index] 
    {
        get => valueArr[index];
        set => valueArr[index] = value;
    }

    public override string ToString()
    {
        string result = string.Empty;
        for (int i = 0; i < valueArr.Length; i++)
        {
            result += $"{i+1}) " + valueArr[i].ToString() + Environment.NewLine;
}
        return result;
    }
}



public class A: ICustomComparable<A>
{
    int _op1;
    int _op2;
    public int op1
    {
        get => _op1;
        set => _op1 = value;
    }
    public int op2
{
        get => _op2;
        set => _op2 = value;
    }

    public A(int op1, int op2)
    {
        this.op1 = op1;
        this.op2 = op2;
    }
    
    public int CustomCompare(A val)
    {
        if (this.op1 + this.op2 > val.op1 + val.op2)
            return 1;
        if (this.op1 + this.op2 < val.op1 + val.op2)
            return -1;
        return 0;
    }

    public override string ToString()
    {
        return $"{op1} {op2}";
    }
}



public class B : ICustomComparable<B>
{
    string _op1;
    double _op2;
    public string op1
    {
        get => _op1;
        set => _op1 = value;
    }
    public double op2
    {
        get => _op2;
        set => _op2 = value;
    }

    public B(string op1, double op2)
    {
        this.op1 = op1;
        this.op2 = op2;
    }

    public int CustomCompare(B val)
    {
        if (this.op1.Length + this.op2 > val.op1.Length + val.op2)
            return 1;
        if (this.op1.Length + this.op2 < val.op1.Length + val.op2)
            return -1;
        return 0;
    }
    public override string ToString()
    {
        return $"{op1} {op2}";
    }
}



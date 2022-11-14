// See https://aka.ms/new-console-template for more information
using System.Collections;

A ClassA = new A(5, 5);
A ClassA2 = new A(2, 2);
A ClassA3 = new A(7, 8);
CustomArray<A> cArray = new CustomArray<A>(2);
cArray[0] = ClassA;
cArray[1] = ClassA2;

// Вывод op2 у всех элементов
foreach (A item in cArray)
{
    Console.WriteLine(item.op2);
}

// Смена значений поля op2 у всех элементов
foreach (A item in cArray)
{
    item.op2 = ClassA3.op2;
}

// Вывод op2 у всех элементов
foreach (A item in cArray)
{
    Console.WriteLine(item.op2);
}



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
    public void Sort(CustomArray<T> arr)
    {
        for (int i = 0; i < arr.valueArr.Length; i++)
        {
            for (int j = 0; j < arr.valueArr.Length - i - 1; j++)
            {
                if (arr[j].CustomCompare(arr[j + 1]) > 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
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
}



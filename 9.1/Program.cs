// See https://aka.ms/new-console-template for more information
public interface ICustomComparable<T>
{
    int CustomCompare(T val);
}

class CustomArray<T> where T: ICustomComparable<T>
{
    T[] valueArr;
    CustomArray(int count)
    {
        valueArr= new T[count];
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

    public T this[int index] 
    {
        get => valueArr[index];
        set => valueArr[index] = value;
    }
}

class A: ICustomComparable<A>
{
    int op1 { get; set; }
    int op2 { get; set; }

    A(int op1, int op2)
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

class B : ICustomComparable<B>
{
    string op1 { get; set; }
    double op2 { get; set; }

    B(int op1, int op2)
    {
        this.op1 = op1;
        this.op2 = op2;
    }

    public int CustomCompare(B val)
    {
        if (this.op1 + this.op2 > val.op1 + val.op2)
            return 1;
        if (this.op1 + this.op2 < val.op1 + val.op2)
            return -1;
        return 0;
    }
}
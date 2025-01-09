namespace QLab;
public class Program

{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Queue<int> q = new Queue<int>();
        q.Insert(7);
        q.Insert(10);
        q.Insert(3);
        Console.WriteLine(q);
        Queue<int> qCopy = SetQCopy(q);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        q.Insert(17);
        qCopy.Insert(13);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        bool isIn1 = CheckIfInQ(q, 9);
        Console.WriteLine(isIn1);
        bool isIn2 = CheckIfInQ(q, 3);
        Console.WriteLine(isIn2);
    }
    public static bool CheckIfInQ(Queue<int> q, int numToCheck)
    {
        Queue<int> qCopy = SetQCopy(q);
        int curItem;
        bool numInQ = false;
        while (!qCopy.IsEmpty())
        {
            curItem = qCopy.Remove();
            if (curItem == numToCheck) { numInQ = true; }
        }
        return numInQ;
    }
    public static Queue<int> SetQCopy(Queue<int> q)
    {
        Queue<int> qCopy = new();
        Queue<int> qTemp = new();
        int currItem;
        //פריקת התור המקורי ויצירת תור העתק ותור זמני
        while (!q.IsEmpty())
        {
            currItem = q.Remove();
            qTemp.Insert(currItem);
            qCopy.Insert(currItem);
        }
        //שחזור התור המקורי
        while (!qTemp.IsEmpty())
        {
            q.Insert(qTemp.Remove());
        }
        return qCopy;
    }
}
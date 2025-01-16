using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

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
        bool IsSides= CheckSidesInPlace(q, 1);
        Console.WriteLine(IsSides);
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
    public static bool CheckSidesInPlace(Queue<int> q, int idx)
    { 
        bool isSidesEqual=false;
        Queue < int> qCopy = SetQCopy(q);
        int curItem;
        int curPlace=0;
        int idxItem=0;
        int sumOfSides = 0;
        while (!qCopy.IsEmpty())
        {
            curPlace++;
            curItem = qCopy.Remove();
            if (curPlace == idx - 1) { sumOfSides += curItem;}
            else if (curPlace == idx) { idxItem = curItem;}
            else if (curPlace == idx + 1) { sumOfSides += curItem;}
        }
        if (sumOfSides == idxItem) {isSidesEqual = true;}
        return isSidesEqual;
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
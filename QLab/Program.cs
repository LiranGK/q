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
        q.Insert(-7);
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
        bool IsSides= CheckSidesInPlace(q, 3);
        Console.WriteLine(IsSides);
        bool isPerfect = CheckIfPerfect(q);
        Console.WriteLine(isPerfect);
        Queue<int> q2 = new Queue<int>();
        q2.Insert(-7);
        q2.Insert(3);
        q2.Insert(7);
        q2.Insert(10);       
        Queue<int> newQ = PutInQ(q2, 0);
        Console.WriteLine(newQ);
    }
    public static Queue<int> PutInQ(Queue<int> q, int numToPut) 
    {
        Queue<int> qCopy = SetQCopy(q);
        Queue<int> newQ = new Queue<int>();
        bool foundPlace=false;
        int curItem;
        while (!foundPlace)
        {
            curItem = qCopy.Remove();
            if (curItem > numToPut)
            {
                Console.WriteLine(curItem);
                newQ.Insert(numToPut);
                newQ.Insert(curItem);
                foundPlace = true;
            }
            else { newQ.Insert(curItem); }
        }
        while (!qCopy.IsEmpty()) 
        {
            curItem = qCopy.Remove();
            newQ.Insert(curItem);
        }
        return newQ;
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
        Queue<int> qCopy1 = SetQCopy(q);
        int length = 0;
        while (!qCopy1.IsEmpty())
        {
            qCopy1.Remove();
            length++;
        }
        bool isSidesEqual=false;
        if (idx != length && idx != 1)
        {
            Queue<int> qCopy2 = SetQCopy(q);
            int curItem;
            int curPlace = 0;
            int idxItem = 0;
            int sumOfSides = 0;
            while (!qCopy1.IsEmpty())
            {
                curPlace++;
                curItem = qCopy2.Remove();
                if (curPlace == idx - 1) { sumOfSides += curItem; }
                else if (curPlace == idx) { idxItem = curItem; }
                else if (curPlace == idx + 1) { sumOfSides += curItem; }
            }
            if (sumOfSides == idxItem) { isSidesEqual = true; }
        }
        return isSidesEqual;
    }
    public static bool CheckIfPerfect(Queue<int> q) 
    {
        Queue<int> qCopy1 = SetQCopy(q);
        int length = 0;
        while (!qCopy1.IsEmpty())
        {
            qCopy1.Remove();
            length++;
        }
        bool isPerfect=true;
        bool isCurPerfect=false;
        Queue<int> qCopy2 = SetQCopy(q);
        for (int i = 2; i < length; i++) 
        {
            isCurPerfect = CheckSidesInPlace(q, i);
            if (!isCurPerfect) { isPerfect = false; }
        }
        return isPerfect;
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
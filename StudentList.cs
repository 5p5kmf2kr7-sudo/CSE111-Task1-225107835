// Name: Khaled Mohamed Rady Alkeshow
// Student ID: 225107835

namespace Cse111Task1;

public class StudentList
{
    public Student? First { get; private set; }
    public Student? Last { get; private set; }
    public int Count { get; private set; }

    // O(1)
    public void AddFront(int id)
    {
        Student node = new Student(id);
        if (First == null)
        {
            First = node;
            Last = node;
        }
        else
        {
            node.Next = First;
            First = node;
        }
        Count++;
    }

    // O(1)
    public void AddEnd(int id)
    {
        Student node = new Student(id);
        if (Last == null)
        {
            First = node;
            Last = node;
        }
        else
        {
            Last.Next = node;
            Last = node;
        }
        Count++;
    }

    // O(n)
    public bool Remove(int id)
    {
        if (First == null) return false;

        if (First.Id == id)
        {
            First = First.Next;
            if (First == null) Last = null;
            Count--;
            return true;
        }

        Student? prev = First;
        Student? cur = First.Next;
        while (cur != null)
        {
            if (cur.Id == id)
            {
                prev.Next = cur.Next;
                if (cur == Last) Last = prev;
                Count--;
                return true;
            }
            prev = cur;
            cur = cur.Next;
        }
        return false;
    }

    // O(n)
    public void Reverse()
    {
        Student? prev = null;
        Student? cur = First;
        Last = First;
        while (cur != null)
        {
            Student? next = cur.Next;
            cur.Next = prev;
            prev = cur;
            cur = next;
        }
        First = prev;
    }

    // O(n)
    public void Print()
    {
        Student? cur = First;
        List<string> parts = new List<string>();
        while (cur != null)
        {
            parts.Add(cur.Id.ToString());
            cur = cur.Next;
        }
        Console.WriteLine(string.Join(" ", parts));
    }
}

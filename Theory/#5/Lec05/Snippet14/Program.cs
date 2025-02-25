﻿LinkedList<Document> list = new();
LinkedListNode<Document> first = list.AddFirst(new Document(1, "first"));
list.AddAfter(first, new Document(2, "after first"));
LinkedListNode<Document> last = list.AddLast(new Document(3, "Last"));
Document doc4 = new(4, "before last");
list.AddBefore(last, doc4);

foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine(new String('-',20));
if (list.First is not null)
{
    IterateUsingNext(list.First);
}
Console.WriteLine(new String('-', 20));
list.Remove(doc4);
Console.WriteLine("after removal");
foreach (var item in list)
{
    Console.WriteLine(item);
}


void IterateUsingNext(LinkedListNode<Document> start)
{
    if (start.Value is null) return;
    LinkedListNode<Document>? current = start;
    do
    {
        Console.WriteLine(current.Value);
        current = current.Next;
    } while (current is not null);
}

record Document(int Id, string Text);


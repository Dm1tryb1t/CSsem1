﻿


for (int i = 0; i < 10; i++)
{ 
    Console.WriteLine(i); 
}


for (int i = 9; i >= 0; i--)
{ 
    Console.WriteLine(i); // i goes out of scope her
} 

//doesn't work:
int j = 20;
for (int i = 0; i < 10; i++)
{
    //int j = 30; // Can't do this — j is still in scope 
    Console.WriteLine(j + i);
}

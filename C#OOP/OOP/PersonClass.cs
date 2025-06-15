using System;

internal partial class PersonClass
{
    public int Age { get; set; }
    partial void PrintAge();

    public void BirthDary()
    {
        Age++;
        PrintAge();
    }
}


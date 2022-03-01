//First demo

using Memento;

Console.WriteLine("Memento pattern\n");
var ba = new BankAccount(100);
var m1 = ba.Deposit(40);
var m2 = ba.Deposit(20);    
    
Console.WriteLine(ba);
//return to m1
ba.RestoreTo(m1);
Console.WriteLine(ba);

ba.Undo();
Console.WriteLine($"Undo 1: {ba}");

ba.Undo();
Console.WriteLine($"Undo 2: {ba}");

ba.Redo();
Console.WriteLine($"Redo: {ba}");
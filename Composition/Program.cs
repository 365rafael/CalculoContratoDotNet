﻿using Composition.Entities;
using Composition.Entities.Enums;
using System.Globalization;

Console.Write("Enter department´s name: ");
string deptName = Console.ReadLine();
Console.WriteLine("Enter worker data:");
Console.Write("Name: ");
string name = Console.ReadLine();
Console.Write("Level: ");
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
Console.Write("Base salary: ");
double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Department dept = new Department(deptName);
Worker worker = new Worker(name, level, baseSalary, dept);

Console.Write("How many contracts to this worker? ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");
    Console.Write("Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Duration (hours): ");
    int hours = int.Parse(Console.ReadLine());
    HourContract contract = new HourContract(date, valuePerHour, hours);
    worker.AddContract(contract);
}

Console.WriteLine();
Console.Write("Enter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine();
int mounth = int.Parse(monthAndYear.Substring(0, 2)); // data MM/YYYY pega 2 casas a partir de 0
int year = int.Parse(monthAndYear.Substring(3)); // data MM/YYYY pega a partir da posição 3
Console.WriteLine("Name: " + worker.Name);
Console.WriteLine("Department: " + worker.Department.Name);
Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, mounth).ToString("F2", CultureInfo.InvariantCulture);
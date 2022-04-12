using System;
using System.Text.Json;
using Client;
using Common.Dto;
using Common.Services;

var client = new RpcClient("http://localhost:2022");

var test = client.Create<ITestService>();
var request1 = new TestRequestDto
{
    Id = 1
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Without inheritance request/result");
var result1 = test.Test(request1);
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(JsonSerializer.Serialize(result1));
Console.ForegroundColor = (ConsoleColor) (-1);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
var request2 = new InheritanceTestDto
{
    Id = 2
};
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("With inheritance request/result");
var result2 = test.Test(request2);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(JsonSerializer.Serialize(result2));
Console.ForegroundColor = (ConsoleColor) (-1);

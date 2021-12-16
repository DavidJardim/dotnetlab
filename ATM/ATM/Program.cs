int code = 1234;
int attempts = 0;
int balance = 5000;
int limit = 200;

while (attempts < 3)
{

    Console.WriteLine("Introduza o pin:");
    int pin = int.Parse(Console.ReadLine());

    if (pin == code)
    {
        Console.WriteLine("Código correto");
        break;
    }
    else
    {
        Console.WriteLine("Código incorreto");
        attempts++;
        Console.WriteLine("Possui " + (3 - attempts) + " tentativas");
    }
}

if (attempts == 3)
{
    Console.WriteLine("Conta bloqueada");
}
else
{
    Console.WriteLine("Introduza a quantia a levantar");
    int amount = int.Parse(Console.ReadLine());

    if (amount <= balance && amount <= limit)
    {
        balance -= amount;
        Console.WriteLine("Levantou " + amount + ", saldo disponível: " + balance);
    }
    else
    {
        Console.WriteLine("Saldo insuficiente");
    }
}
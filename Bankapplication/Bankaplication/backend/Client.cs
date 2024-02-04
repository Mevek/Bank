using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Bankaplication.frontend;

namespace BankApplication.backend
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public Client(int id, string name, int accountNumber, decimal balance)
        {
            Id = id;
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Imie i Nazwisko: {Name}, Numer Konta: {AccountNumber}, Srodki: {Balance:C}";
        }

        public bool Login(int enteredId)
        {
            return Id == enteredId;
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>
            {
                new Client(1, "Jan Nowak", 001, 1457.23m),
                new Client(2, "Agnieszka Kowalska", 002, 3600.18m),
                new Client(3, "Robert Lewandowski", 003, 2745.03m),
                new Client(4, "Zofia Plucińska", 004, 7344.00m),
                new Client(5, "Grzegorz Strażak Braun", 005, 455.38m)
            };

            while (true)
            {
                Display.DisplayWelcome();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Display.ShowAllClients(clients);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Podaj ID do zalogowania:");
                        int enteredId;
                        while (!int.TryParse(Console.ReadLine(), out enteredId))
                        {
                            Console.WriteLine("Nieprawidłowy format ID. Spróbuj ponownie:");
                        }

                        Client loggedInClient = clients.FirstOrDefault(c => c.Login(enteredId));

                        if (loggedInClient != null)
                        {
                            Console.Clear();
                            //Console.WriteLine($"Zalogowano jako {loggedInClient.Name} (ID: {loggedInClient}).");
                            Console.WriteLine($"Imie i Nazwisko: {loggedInClient.Name}");
                            Console.WriteLine($"Numer konta: {loggedInClient.AccountNumber}");
                            Console.WriteLine($"Saldo: {loggedInClient.Balance:C}");
                            Console.WriteLine();

                            Console.WriteLine($"Wybierz jedna z opcji:");
                            Console.WriteLine();
                            Console.WriteLine($"1.Przelew");
                            Console.WriteLine($"2.Powrot");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Brak Klienta o podanym ID");
                        }

                        break;

                    //Opcja przelewu

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Do Nastepnego !");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                        break;
                }
            }
        }
    }
}
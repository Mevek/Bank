using System;
using System.Collections.Generic;
using BankApplication.backend;

namespace Bankaplication.frontend
{
    public static class Display
    {
        public static void DisplayWelcome()
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine();
            Console.WriteLine("1 => Lista wszystkich klientów banku");
            Console.WriteLine("2 => Logowanie.");
            Console.WriteLine("3 => Zakończ program.");
            Console.WriteLine();
            Console.WriteLine("Wybierz 1, 2 lub 3:");
        }

        public static void ShowAllClients(List<Client> clients)
        {
            Console.WriteLine("ID | IMIĘ I NAZWISKO | NR KONTA | SALDO");
            foreach (Client client in clients)
            {
                Console.WriteLine(client);
            }
        }
        public static Client Login(List<Client> clients)
        {
            Console.WriteLine("Podaj ID do zalogowania:");
            int enterId;
            while (!int.TryParse(Console.ReadLine(), out enterId))
            {
                Console.WriteLine("Nieprawidłowy format, spróbuj ponownie.");
            }

            Client loggedinClient = clients.FirstOrDefault(c => c.Id == enterId);

            if (loggedinClient != null)
            {
                Console.WriteLine($"Witaj ! {loggedinClient.Name} (ID: {loggedinClient.Id}).");
            }
            else
            {
                Console.WriteLine("Brak Klienta o podanym ID.");
            }
            return null;
        }
    }
}
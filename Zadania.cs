List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };

string heroName = "Ada";
int health = 80;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;

// Zadanie 1 & 5
int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage;
int Heal(int health, int amount, int maxHealth) => Math.Min(health + amount, maxHealth);
bool IsGameOver(int health) => health <= 0;
bool CanAfford(int gold, int price) => gold >= price;
int BuyItem(int gold, int price) => gold - price;

// Zadanie 2
void ShowPanelTitle(string title, ConsoleColor backgroundColor)
{
    Console.BackgroundColor = backgroundColor;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"  {title.ToUpper()}  ");
    Console.ResetColor();
}

void ShowStatus(string name, int health, int maxHealth, int gold)
{
    ShowPanelTitle("Status bohatera", ConsoleColor.DarkBlue);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Bohater: ");
    Console.ResetColor();
    Console.WriteLine(name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Zdrowie: ");
    Console.ResetColor();
    Console.WriteLine($"{health}/{maxHealth} HP");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Złoto:   ");
    Console.ResetColor();
    Console.WriteLine(gold);
}

void ShowMenu()
{
    ShowPanelTitle("Menu", ConsoleColor.DarkCyan);
    Console.WriteLine("[1] Atak treningowy");
    Console.WriteLine("[2] Odpoczynek");
    Console.WriteLine("[3] Pokaż ekwipunek");
    Console.WriteLine("[4] Koniec gry");
}

void ShowInventory(List<string> items)
{
    ShowPanelTitle("Ekwipunek", ConsoleColor.DarkMagenta);
    foreach (var item in items)
    {
        Console.WriteLine($"- {item}");
    }
}

// Zadanie 4
string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybór: ");
        string? command = Console.ReadLine();

        if (command == "1" || command == "2" || command == "3" || command == "4")
        {
            return command;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Niepoprawna komenda. Wybierz 1, 2, 3 lub 4.");
        Console.ResetColor();
    }
}

// Zadanie 6
while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń manekinowi.");
    }
    else if (command == "2")
    {
        health = Heal(health, 10, maxHealth);
        Console.WriteLine($"Odpoczywasz. Masz teraz {health}/{maxHealth} HP.");
    }
    else if (command == "3")
    {
        ShowInventory(inventory);
    }
    else if (command == "4")
    {
        isRunning = false;
        Console.WriteLine("Do zobaczenia, poszukiwaczu przygód!");
    }

    if (IsGameOver(health))
    {
        Console.WriteLine("Bohater poległ!");
        isRunning = false;
    }
}


/* Zadanie 7
A)
int Heal(int health, int amount) => health + amount;
Heal(health, 10);
Problem w tym że Heal nie zapisuje sie w health
B)
if (health < 20)
{
    string warning = "Mało zdrowia!";
}

Console.WriteLine(warning);
Zamiast zmiany "warning" możemy odrazu wypisać probleme ze zdrowiem
C)
int CalculateDamage(int strength, int weaponDamage)
{
    Console.Write("Czy chcesz zaatakować? ");
    string? answer = Console.ReadLine();
    Console.WriteLine("Rozpoczynam animację ataku...");
    return strength + weaponDamage;
}
Problem w tym że po "string? answer = Console.ReadLine();" nie mamy części "if" i odpowiedż użytkownika niema znaczenia

bool CanHeal(int health, int maxHealth, int potions) =>
    health < maxHealth && potions > 0 && health > 0;
Nic nie dostaniemy oprócz znaczenia true w przypadku jeżeli zdrowie mniejsze od Max i jeżeli mamy chociaz hp oraz potion większe od 0

*/
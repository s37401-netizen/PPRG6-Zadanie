
// Zadanie 5
List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };

void Inventory(List<string> inventory)
{
    foreach (var item in inventory)
    {
        Console.WriteLine(item);
    }
}

List<string> longNames = inventory.FindAll(item => item.Length >= 5);
bool hasSword = inventory.Exists(item => item == "miecz");

string heroName = "Ada";
int health = 80;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;

//Zadanie 1
void ShowMessage(string text) => Console.WriteLine(text);

int AddGold(int gold, int reward) => gold + reward;

bool HasEnoughGold(int gold, int price) => gold >= price;
// 1) nie zwraca wartosci a zapisuje wynik
// 2) true lub false
// 3) argumentami sa int gold oraz int reward
// 4) Można użyć dla kupowania rzeczy

//Zadanie 2
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
    Console.Write("Bohater:  ");
    Console.ResetColor();
    Console.WriteLine(name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Zdrowie: ");
    Console.ResetColor();
    Console.WriteLine($"{health}/{maxHealth} HP");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Złoto:    ");
    Console.ResetColor();
    Console.WriteLine(gold);
}

void ShowMenu()
{
    ShowPanelTitle("Menu", ConsoleColor.DarkCyan);
    Console.WriteLine("[1] Atak treningowy");
    Console.WriteLine("[2] Odpoczynek");
    Console.WriteLine("[3] Koniec gry");
}

// Zadanie 4
int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage;

int Heal(int health, int amount, int maxHealth)
{
    if (health + amount <= maxHealth)
    {
        health += amount;
        Console.WriteLine($"Dostajesz {amount} HP");
        return health;
    }
    else
    {
        health = maxHealth;
        Console.WriteLine($"Masz {maxHealth} HP");
        return health;
    }
}

bool IsGameOver(int health)
{
    if (health <= 0)
    {
        Console.WriteLine("Koniec gry");
        return isRunning = false;
    }
    else
    {
        Console.WriteLine("Nie");
        return isRunning;
    }
}

string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybór: ");
        string? command = Console.ReadLine();

        switch (command)
        {
            case "1":
                return "1";
            case "2":
                return "2";
            case "3":
                return "3";
            case "4":
                return "4";
            default:
                Console.WriteLine("Nie poprawna komenda");
                break;
        }
    }
}

while (isRunning)
{
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    // Zadanie 3
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń manekinowi.");
    }
    else if (command == "2")
    {
        health = Heal(health, 10, maxHealth);
        Console.WriteLine($"Odpoczywasz. Masz teraz {health} HP.");
    }
    else if (command == "3")
    {
        IsGameOver(health);
    }
    else if (command == "4")
    {
        Inventory(inventory);
    }
}


/* Zadanie 7
A)
int Heal(int health, int amount) => health + amount;
Heal(health, 10);
Problem w tym że health jest stringiem a musi być liczbą
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
// Dokończyć wdomu
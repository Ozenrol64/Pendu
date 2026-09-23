// Liste de mots pour le jeu du pendu
List<string> words =
[
    "pomme",
    "banane",
    "orange",
    "fraise",
    "kiwi",
    "mangue",
    "ananas",
    "raisin",
    "cerise",
    "peche",
    "abricot",
    "melon",
    "pasteque",
    "framboise",
    "myrtille",
    "cassis",
    "groseille",
    "litchi",
    "papaye",
    "grenade",
    "clementine",
    "mandarine",
    "tangerine",
    "kumquat",
    "nectarine",
    "prune",
    "mirabelle",
    "quetsche",
    "figue",
    "datte",
    "avocat",
    "olive",
    "tomate",
    "poivron",
    "courgette",
    "aubergine",
    "bonjour",
    "ordinateur",
    "programmation",
    "developpement",
    "intelligence",
    "artificielle",
    "machine",
    "clavier",
    "souris",
    "ecran",
    "internet",
    "logiciel",
    "robot",
    "voiture",
    "maison",
    "jardin",
    "montagne",
    "riviere",
    "ocean",
    "soleil",
    "nuage",
    "musique",
    "cinema",
    "livre",
    "ecole",
    "voyage",
];
List<string> guessedLetters = new List<string>();

// Status du pendu pour chaque nombre d'essais restants
List<string> status = [
    @"    _______
   |/    |
   |     O
   |    -|-
   |    / \
   |
___|________
",
@"    _______
   |/    |
   |     O
   |    -|-
   |    / 
   |
___|________
",
@"    _______
   |/    |
   |     O
   |    -|-
   |    
   |
___|________
",
@"    _______
   |/    |
   |     O
   |    -|
   |     
   |
___|________
   ",
   @"    _______
   |/    |
   |     O
   |     |
   |     
   |
___|________
",
@"    _______
   |/    |
   |     O
   |    
   |     
   |
___|________
",
@"    _______
   |/    |
   |     O
   |     
   |     
   |
___|________
   ",
   @"    _______
   |/    
   |     
   |     
   |     
   |
___|________
   ",
   @"
       
   |/    
   |     
   |     
   |     
   |
___|________
   ",
   @"
       
       
       
        
   
   ___|________",
   @""];

// Sélection aléatoire d'un mot dans la liste
Random random = new Random();
string selectedWord = words[random.Next(words.Count)];

// Initialisation du mot masqué et du nombre d'essais
string hiddenWord = new string('_', selectedWord.Length);
int attemptsLeft = 11;
bool gameOver = false;

//Début de l'affichage du jeu
Console.WriteLine(@"
  _____               _       _  
 |  __ \             | |     | | 
 | |__) |__ _ __   __| |_   _| | 
 |  ___/ _ \ '_ \ / _` | | | | | 
 | |  |  __/ | | | (_| | |_| |_| 
 |_|   \___|_| |_|\__,_|\__,_(_) 
                                 
");
Console.WriteLine(hiddenWord);
Console.WriteLine($"Essais restants: {attemptsLeft}");
Console.WriteLine("Commencer ?");
Console.ReadLine();
Console.Clear();

// Boucle principale du jeu
while (!gameOver && attemptsLeft > 0)
{
    Console.Clear();

    Console.WriteLine(@"
  _____               _       _  
 |  __ \             | |     | | 
 | |__) |__ _ __   __| |_   _| | 
 |  ___/ _ \ '_ \ / _` | | | | | 
 | |  |  __/ | | | (_| | |_| |_| 
 |_|   \___|_| |_|\__,_|\__,_(_) 
                                 
    ");
// Affichage du statut du pendu, du mot masqué et du nombre d'essais restants
    Console.WriteLine(status[attemptsLeft - 1]);
    Console.WriteLine();
    Console.WriteLine(hiddenWord);
    Console.WriteLine();
    Console.WriteLine($"Essais restants: {attemptsLeft}");
    string guessedLetter = Console.ReadLine().ToLower();

    // Vérification de la validité de la lettre devinée
    if (guessedLetter.Length != 1 || !char.IsLetter(guessedLetter[0]))
    {
        Console.WriteLine("Veuillez entrer une seule lettre.");
        continue;
    }

    // Vérification si la lettre a déjà été devinée
    if (guessedLetters.Contains(guessedLetter))
    {
        Console.WriteLine("Vous avez déjà deviné cette lettre.");
        continue;
    }

    guessedLetters.Add(guessedLetter);

    if (selectedWord.Contains(guessedLetter))
    {
        Console.WriteLine("Bonne lettre !");
    }
    else
    {
        Console.WriteLine("Mauvaise lettre.");
        attemptsLeft--;
    }

    // Mettre à jour le mot masqué
    char[] hiddenWordArray = hiddenWord.ToCharArray();
    for (int i = 0; i < selectedWord.Length; i++)
    {
        if (selectedWord[i].ToString() == guessedLetter)
        {
            hiddenWordArray[i] = guessedLetter[0];
        }
    }
    hiddenWord = new string(hiddenWordArray);

    // Vérification de la fin du jeu
    if (!hiddenWord.Contains('_'))
    {
        Console.WriteLine($"Félicitations ! Vous avez deviné le mot : {selectedWord}");
        gameOver = true;
    }
    else if (attemptsLeft == 0)
    {
        Console.WriteLine($"Dommage ! Le mot était : {selectedWord}");
        gameOver = true;
    }
}
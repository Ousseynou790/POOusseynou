# Bonnes Pratiques - P2UpdateClasses

## 1. Encapsulation des données

### Utilisation de champs privés
Les champs doivent être privés pour protéger les données internes de la classe :
```csharp
private string _firstName;
private string _lastName;
```

### Exposition via propriétés
L'accès aux données se fait via des propriétés publiques :
```csharp
public string FirstName
{
    get { return _firstName; }
    set { _firstName = value; }
}
```

## 2. Types de propriétés

### Propriétés complètes (Full Properties)
Utilisées quand on a besoin de logique dans les accesseurs :
```csharp
private string _firstName;
public string FirstName
{
    get { return _firstName; }
    set { _firstName = value?.Trim(); } // Validation
}
```

### Propriétés auto-implémentées (Auto-implemented Properties)
Utilisées pour une implémentation simple sans logique supplémentaire :
```csharp
public string AccountType { get; set; } = "Checking";
```

### Propriétés en lecture seule (Read-only Properties)
Pour les données qui ne doivent pas changer après l'initialisation :
```csharp
public int AccountNumber { get; }
```

### Propriétés avec setter privé
Pour les données modifiables uniquement de l'intérieur de la classe :
```csharp
public double Balance { get; private set; } = 0;
```

## 3. Méthodes de classe

### Principe de responsabilité unique
Chaque méthode devrait avoir une seule responsabilité :
```csharp
// Bonne pratique - fait une seule chose
public void Deposit(double amount)
{
    if (amount > 0)
    {
        Balance += amount;
    }
}
```

### Validation des paramètres
Toujours valider les entrées :
```csharp
public bool Withdraw(double amount)
{
    if (amount > 0 && Balance >= amount)
    {
        Balance -= amount;
        return true;
    }
    return false;
}
```

### Retourner des valeurs significatives
Les méthodes devraient retourner des informations utiles :
```csharp
public bool Transfer(BankAccount targetAccount, double amount)
{
    if (Withdraw(amount))
    {
        targetAccount.Deposit(amount);
        return true; // Succès
    }
    return false; // Échec
}
```

## 4. Méthodes d'extension

### Quand utiliser les méthodes d'extension
- Pour ajouter des fonctionnalités à des classes qu'on ne peut pas modifier
- Pour organiser le code de manière logique
- Pour créer des méthodes utilitaires réutilisables

### Syntaxe des méthodes d'extension
```csharp
public static class BankCustomerExtensions
{
    public static bool IsValidCustomerId(this BankCustomer customer)
    {
        return customer.CustomerId.Length == 10;
    }
}
```

### Bonnes pratiques pour les extensions
1. Créer une classe statique pour chaque type étendu
2. Nommer la classe avec le suffixe "Extensions"
3. Utiliser le mot-clé `this` sur le premier paramètre

## 5. Constructeurs

### Initialisation appropriée
Les constructeurs doivent initialiser tous les champs requis :
```csharp
public BankCustomer(string firstName, string lastName)
{
    FirstName = firstName;
    LastName = lastName;
    this.CustomerId = (s_nextCustomerId++).ToString("D10");
}
```

### Surcharge de constructeurs
Offrir plusieurs constructeurs pour différents scénarios :
```csharp
public BankAccount(string customerIdNumber)
{
    this.AccountNumber = s_nextAccountNumber++;
    this.CustomerId = customerIdNumber;
}

public BankAccount(string customerIdNumber, double balance, string accountType)
{
    this.AccountNumber = s_nextAccountNumber++;
    this.CustomerId = customerIdNumber;
    this.Balance = balance;
    this.AccountType = accountType;
}
```

## 6. Champs statiques

### Utilisation appropriée
Les champs statiques sont partagés entre toutes les instances :
```csharp
private static int s_nextCustomerId;
public static double InterestRate;
```

### Constructeur statique
Initialiser les champs statiques dans un constructeur statique :
```csharp
static BankCustomer()
{
    Random random = new Random();
    s_nextCustomerId = random.Next(10000000, 20000000);
}
```

## 7. Nommage des conventions

### Champs privés
Préfixer avec underscore : `_firstName`, `_lastName`

### Champs statiques privés
Préfixer avec s_ : `s_nextCustomerId`, `s_nextAccountNumber`

### Propriétés et méthodes
Utiliser PascalCase : `FirstName`, `ReturnFullName()`

### Paramètres et variables locales
Utiliser camelCase : `firstName`, `lastName`, `amount`

## 8. Documentation du code

### Commentaires XML
Documenter les méthodes publiques :
```csharp
/// <summary>
/// Dépose un montant sur le compte
/// </summary>
/// <param name="amount">Le montant à déposer</param>
public void Deposit(double amount)
{
    if (amount > 0)
    {
        Balance += amount;
    }
}
```

### Commentaires en ligne
Expliquer la logique complexe :
```csharp
// Vérifier que le montant est positif et que le solde est suffisant
if (amount > 0 && Balance >= amount)
{
    Balance -= amount;
    return true;
}
```

## 9. Sécurité des données

### Champs readonly
Utiliser `readonly` pour les données qui ne devraient jamais changer :
```csharp
public readonly string CustomerId;
public readonly int AccountNumber;
```

### Setter privé
Utiliser des setters privés pour protéger les données :
```csharp
public double Balance { get; private set; } = 0;
```

## 10. Tests et validation

### Toujours tester
- Tester les cas normaux
- Tester les cas limites (valeurs nulles, zéro, négatifs)
- Tester les erreurs potentielles

### Exemple de validation
```csharp
public void Deposit(double amount)
{
    if (amount > 0) // Validation
    {
        Balance += amount;
    }
    // Ignorer silencieusement les dépôts invalides
}
```

## Résumé
L'application de ces bonnes pratiques permet de créer du code :
- ? Maintenable
- ? Lisible
- ? Sécurisé
- ? Évolutif
- ? Testable

# Tic Tac Toe (C# / WPF)

Boter, kaas en eieren voor twee spelers op één computer. Gemaakt in **C#** met **WPF** (Windows Presentation Foundation).

## Functies
- Startscherm met een **Start Game**-knop
- Speelbord van 3×3; X en O worden om de beurt geplaatst
- Herkent automatisch **winst** (rij, kolom of diagonaal) en **gelijkspel**
- Eindscherm met de winnaar en een **Play Again**-knop

## Hoe het werkt
| Bestand | Uitleg |
|---|---|
| `XOcell.xaml` + `.cs` | Eigen **UserControl** voor één vakje. Heeft een `Value` (X, O of leeg) en tekent zelf een X of O met een `Path`. Bij een klik vuurt het het event `CellClicked` af. |
| `MainWindow.xaml` | Het venster: startmenu, het 3×3-bord (9 × `XOcell`) en de win/gelijkspel-schermen |
| `MainWindow.xaml.cs` | De spellogica: wie is aan de beurt, `CheckForWin()`, `CheckForDraw()` en opnieuw spelen |

De vakjes worden opgeslagen in een 2D-array `XOcell[3, 3]`, zodat rijen, kolommen en diagonalen makkelijk te controleren zijn.

## Starten
Open `Tic tac toe.sln` in **Visual Studio** en druk op **F5**.

## Gebruikte technieken
C# · WPF / XAML · UserControls · events · 2D-arrays

## Wat ik heb geleerd
- Een eigen UserControl maken en hergebruiken
- Events gebruiken om componenten met elkaar te laten praten
- Spellogica opsplitsen in kleine methodes

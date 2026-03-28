# Projekt - wypozyczalnia sprzetu

Prosta aplikacja konsolowa w C# obslugujaca uczelniana wypozyczalnie sprzetu. Projekt zostal przygotowany w prosty sposob, ale z zachowaniem czytelnego podzialu odpowiedzialnosci pomiedzy model domenowy, serwisy i warstwe konsolowa.

## Jak uruchomic

1. Otworz projekt w Riderze lub Visual Studio.
2. Uruchom projekt `Projekt`.
3. Po starcie wybierz:
   `1`, aby uruchomic scenariusz demonstracyjny,
   `2`, aby wejsc do prostego menu tekstowego.

## Struktura projektu

- `Domain` - klasy domenowe opisujace sprzet, uzytkownikow i wypozyczenia.
- `Services` - logika biznesowa oraz raportowanie.
- `App` - scenariusz demonstracyjny, dane startowe i menu tekstowe.
- `Program.cs` - punkt wejscia aplikacji.

## Najwazniejsze decyzje projektowe

- `Equipment` i `User` sa klasami bazowymi dla konkretnych typow obiektow.
- `RentalService` odpowiada za obsluge wypozyczen i zwrotow.
- `ReportService` i `FilteredReportService` odpowiadaja za generowanie raportow.
- `SampleDataSeeder` przygotowuje dane testowe w jednym miejscu.
- `ConsoleMenu` obsluguje interakcje z uzytkownikiem bez przenoszenia logiki biznesowej do `Program.cs`.

## Zakres funkcjonalny

- dodawanie i prezentacja danych startowych,
- wypozyczanie sprzetu,
- zwrot sprzetu,
- kontrola limitow wypozyczen,
- raport calego sprzetu,
- raport aktywnych wypozyczen,
- raport sprzetu dostepnego,
- raport sprzetu uszkodzonego,
- raport przeterminowanych wypozyczen,
- scenariusz demonstracyjny i proste menu tekstowe.

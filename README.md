# Projekt 1 - Wypozyczalnia sprzetu

Prosta aplikacja konsolowa w C# obslugujaca uczelniana wypozyczalnie sprzetu. Projekt zostal zrobiony celowo mozliwie prosto, ale z zachowaniem sensownego podzialu odpowiedzialnosci.

## Jak uruchomic

1. Otworz projekt w Riderze lub Visual Studio. .
2.Uruchom projekt `Projekt1`.

Po starcie aplikacja wykona gotowy scenariusz demonstracyjny i wyswietli raport koncowy.

## Struktura projektu

- `Domain` - model domeny: sprzet, uzytkownicy, wypozyczenia, enumy i generator identyfikatorow.
- `Services` - logika biznesowa: wypozyczanie, zwroty, limity, kara za opoznienie i raport.
- `App` - prosty scenariusz demonstracyjny dla konsoli.
- `Program.cs` - tylko uruchamia `DemoRunner`, bez logiki biznesowej.

## Najwazniejsze decyzje projektowe

- `Equipment` i `User` sa klasami abstrakcyjnymi, bo maja czesc wspolna i kilka specjalizacji.
- `RentalService` zbiera logike biznesowa w jednym miejscu, dzieki czemu nie ma jej w `Program.cs`.
- `RentalPolicy` przechowuje limity i zasady naliczania kary, wiec taka regule da sie latwo zmienic bez szukania jej po calym projekcie.
- `DemoRunner` odpowiada tylko za pokazanie scenariusza, a nie za podejmowanie decyzji biznesowych.

## Kohezja i coupling

- Kohezja: kazda klasa ma jedno glowne zadanie, np. `Rental` opisuje wypozyczenie, a `RentalService` wykonuje operacje na systemie.
- Coupling: klasy domenowe nie znaja szczegolow konsoli. Warstwa `App` korzysta z serwisu, ale model nie zalezy od interfejsu uzytkownika.

## Zakres funkcjonalny

- dodawanie uzytkownikow,
- dodawanie sprzetu,
- lista calego sprzetu,
- lista dostepnego sprzetu,
- wypozyczenie sprzetu,
- zwrot w terminie i po terminie,
- blokada wypozyczenia po przekroczeniu limitu,
- blokada wypozyczenia sprzetu niedostepnego,
- lista aktywnych wypozyczen uzytkownika,
- lista przeterminowanych wypozyczen,
- raport podsumowujacy.

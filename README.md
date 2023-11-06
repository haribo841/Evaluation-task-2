# Evaluation task 2

<b>Program odczytuje dane z pliku CSV zawierajacego informacje o skladnikach nalesników, przetwarza i agreguje te dane, a nastepnie zapisuje wyniki do innego pliku CSV.</b>

## Uzyta biblioteka: 

<b>CsvHelper</b>

## Metoda glówna:

Metoda Main stanowi punkt wejscia do programu.
Poczatkowo definiuje sciezke do pliku <b>CSV</b> zawierajacego dane o skladnikach nalesników.
Inicjalizuje instancje klas odpowiedzialnych za przetwarzanie danych, takich jak <b>CsvDataReader</b>, <b>DataAnalyzer</b>, <b>PancakeProcessor</b>, oraz <b>DataService</b>.
Nastepnie wywoluje metode <b>ProcessCsvFile</b> z klasy <b>DataService</b>, aby odczytac i przetworzyc plik <b>CSV</b>.
Po przetworzeniu danych, program zapisuje wyniki do nowego pliku <b>CSV</b>.
W przypadku wystapienia bledów, program obsluguje wyjatki i wyswietla odpowiednie komunikaty.

## Klasa PancakeProcessor:

Klasa ta przetwarza i przeksztalca dane dotyczace ilosci skladników nalesników.
Przelicza jednostki miar (dkg na kg, g na kg, ml na l) i agreguje dane.

## Klasa PancakeDataMap:

Jest to klasa definiujaca mapowanie miedzy kolumnami pliku <b>CSV</b> a wlasciwosciami klasy <b>PancakeData</b>.
Ta klasa przyjmuje podsumowane dane i wyswietla je w formie tabelarycznej.

## Klasa PancakeData:

Ta klasa definiuje strukture danych, w której przechowywane sa informacje o ilosci skladników nalesników, takie jak znacznik czasu, Maka, Kasza, Mleko i Jajka.

## Klasa IngredientUsage:

Klasa ta jest podobna do klasy <b>PancakeData</b> i definiuje strukture do przechowywania informacji o uzyciu skladników.

## Interfejs ICsvReader:

Interfejs ten okresla metode do odczytywania plików <b>CSV</b>.

## Klasa CsvDataReader:

Ta klasa implementuje interfejs <b>ICsvReader</b> i jest odpowiedzialna za odczyt i przetwarzanie pliku <b>CSV</b>.
Zawiera równiez metode do grupowania i sumowania danych.

## Klasa SumResult:

Ta klasa jest odpowiedzialna za agregacje i sumowanie danych zwiazanych z ilosciami skladników nalesników.
Dane grupowane sa wedlug daty i godziny, a nastepnie obliczane sa sumy skladników (Maka, Kasza, Mleko, Jajka) dla kazdej grupy.
Wyniki sa sortowane wedlug znacznika czasu.

## Klasa DataAnalyzer:

Ta klasa bierze podsumowane dane i wyswietla je w formie tabelarycznej.

## Klasa DataService:

Klasa ta koordynuje przetwarzanie danych, wykorzystujac interfejs <b>ICsvReader</b> oraz <b>PancakeProcessor</b> do odczytywania i przetwarzania danych.
Wykorzystuje równiez klase <b>DataAnalyzer</b> do analizy i wyswietlania wyników.

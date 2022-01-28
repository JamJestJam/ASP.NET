# Projekt zaliczeniowy z przedmiotu "Programowanie w środowisku ASP. NET"
## Konfiguracja przed uruchomieniowa
### Połączenie
Konfigurację należy zacząć od ustawienia "ConnectionString" w pliku "appsetings.json" wewnątrz projektu "ASP .net Aplication" pod nazwą "DataBase"=>"Connect". 
### Tworzenie bazy danych
W konsoli menedżera pakietów wpisać odpowiednie komendy: 
`add-migration`
`update-database`
Po ich wpisaniu powinna stworzyć się baza danych.
### Ostatnim punktem konfiguracji jest sprawdzenie czy pobrały się wszystkie pakiety
## Opis aplikacji
Aplikacja służy do wysyłania obrazków na serwer i możliwości ich oceniania.
### Funkcje
Wewnątrz aplikacji każda osoba może zobaczyć wcześniej wysłane obrazki, czytać komentarze jak i sprawdzić jak dany obrazek jest oceniany. Można również stać się lepszym użytkownikiem poprzez rejestrację.
Po zalogowaniu zyskujemy możliwość wrzucania własnych obrazków, pisania komentarzy, oceniania. Mamy możliwość również edytować i usuwać napisane przez siebie komentarze i wysłane obrazki.
Jako administrator możemy usuwać i modyfikować wszystkie komentarze i obrazki.
### Domyślni użytkownicy
|Login|Hasło|Grupa
|--|--|--|
|admin|zaq1@WSX|Administrator
|Admin2|zaq1@WSX|Administrator
|Marek|zaq1@WSX|Użytkownik
|Karola|zaq1@WSX|Użytkownik
|Jaszczur|zaq1@WSX|Użytkownik





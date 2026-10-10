# MIP_Lab2_cerinte
LABORATOR 2
Fire de execuție 
Tipul delegate
Debug & Trace
Să se creeze o aplicație Windows Forms. 
Să de adauge două butoane: Start și Stop.
La apăsarea butonului Start se va lansa un fir de execuție (metoda run se va implementa în aceeași clasă). La apăsarea butonului Stop același fir va fi oprit.
Se va modifica metoda Dispose() din clasa Form1 pentru oprirea firului de execuție (dacă acesta rulează).
Firul de execuție va asigura desenarea și deplasarea unui text pe form. Modificarea poziției textului se va realiza la intervale de 100ms.
Să se adauge alte două butoane pentru selectarea culorii de fundal și a culorii de desenare a textului.
La apăsarea butoanelor se va utiliza ColorDialog pentru alegerea unei culori.
Utilizând clasa Trace se va scrie într-un fișier text timpul sistemului (data, ora, minut, secunda, milisecunda) la care a avut loc deplasarea textului.
Utilizând clasa BooleanSwitch și Application Configuration File se va activa/dezactiva funcția de logare în fișier de la cerința anterioară.
Să se modifice aplicația anterioară astfel încât metodele specifice firului de execuție să fie implementate într-o altă clasă (ex: MyThread). Această clasă va fi responsabilă pentru administrarea timpului de viață complet al firului.
Desenarea se va realiza într-o metodă implementată în clasa Form1. Pentru apelul metodei se vor testa două variante:
















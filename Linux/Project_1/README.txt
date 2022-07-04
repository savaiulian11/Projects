Modul de abordare a temei:

Codul sursă, fie primit ca argument al programului fie de la STDIN 
este analizat linie cu linie, liniile fiind împărțite în cuvinte.

Cuvintele sunt de două tipuri:
-caractere speciale înlănțuite;
-posibile directive sau cuvinte normale.

O linie care conține directive de preprocesare este marcată cu 
canWrite=0, ceea ce înseamnă că nu este luată în calcul la scriere.

Dacă o linie nu conține directive, iar canWrite este setat pe 1, 
va fi scrisă.

Analizarea este făcută în două etape: aflarea tipului de directivă și
evaluarea condiției acesteia.

----------------------------------------------------------------------

Tema, deși pune la încercare imaginația, are în principal componență 
elemente de programare de anul 1, singurul lucru identificat de mine 
care are legătură cu Programarea Sistemelor de Operare fiind citirea 
de la STDIN. Astfel nu consider această temă ca fiind utilă.

Cât despre implementarea mea, codul poate fi segmentat mult, mult mai bine.
Ceea ce consider că putea fi îmbunătățit ar fi reducerea variabelelor globale și
desigur, fragmentarea mai clară a codului.

----------------------------------------------------------------------

Întregul enunț al temei a fost implementat.
Ceea ce consider că ar putea fi scos din calculul punctajului codului este
testul 0, deoarce stilul de scriere este unul personal, fiecare dintre noi
având particularități de scriere. Am încercat să urmez stilul de cod al kernelului
Linux, însă consider că sunt și lucruri ușor exagerate.

Ceea ce m-a pus în dificultate a fost enunțul temei, multe aspecte importante 
fiind ușor ascunse și greu reperabile. Acest lucru îl confirm atât din experienta 
mea cât și din urma discuțiilor cu colegii.

-----------------------------------------------------------------------

Executabilul programului este obținut în urma link-ului cu biblioteca HashMap,
ce are ca scop managerierea directivelor #DEFINE.

-----------------------------------------------------------------------

Resurse utilizate:
https://ocw.cs.pub.ro/courses/so/laboratoare/laborator-01/
https://www.geeksforgeeks.org/
https://stackoverflow.com/
https://www.cplusplus.com/
https://wiki.mta.ro/c/1/sda/lab/11




 
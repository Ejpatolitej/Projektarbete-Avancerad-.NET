Detta projektet var väldigt intressant att jobba med. Dels för att det var mycket som var nytt och dels för att man fick tänka mycket själv. 
Programmet är uppbyggt av två projekt, ett för models som innehåller Employees, TimeReport, Project och en kopplingstabell mellan Employees och TimeReport. 
Programmet är en REST-api med CRUD i tanken. Anledningen till det är för att kunna skala upp det om jag skulle vilja utveckla programmet och ge mig 
möjligheten att lägga till nya funktioner och andra delar så enkelt som möjligt.

Jag valde att göra en Interface för alla mina repositories att använda, på så sätt slipper jag skriva om samma sak flera gånger, 
och återigen om jag skulle vilja lägga till och skala upp det så kan jag göra det på ett enkelt sätt. Det enda som inte används av alla 
repositories är att kunna hämta alla delar i en specifik vecka. Det använder jag bara i timereport för att kunna plocka info om en specifik vecka, 
men det behöver jag inte för dom andra. Men det finns där om jag skulle vilja ändra på det också.

Annars ser metoderna i stort sett likadana ut. Det är några som hämtar mer info, om du t.ex. hämtar en specifik Employee så får du tidsrapportering för den personen, 
men det får du inte om du hämtar alla Employees. Jag tyckte inte att det var nödvändigt, den infon får man som sagt ändå när man söker efter specifika personer. 
Jag hade velat göra så att viss info inte hämtas. När man t.ex. hämtar hela listan med Employees får man vilket Project en Employee är del av, 
men man får också informationen om vilka mer som jobbar på samma Project. Var osäker på hur man tar bort det.

Just i detta projektet så räckte det med att ha ett interface tyckte jag, men skulle jag börja lägga till fler funktioner och fler repositories så skulle jag 
vilja göra fler interfaces. Det finns ett par funktioner som man skulle kunna ha på t.ex. Employee som man kanske inte vill ha på Project. 
Ett problem jag fick när jag började var att jag tänkte att jag inte behövde någon kopplingstabell, men kom på ganska snabbt att varje Employee vill lägga 
till mer än en vecka med arbete.

Som jag skrivit innan så tyckte jag att detta projektarbetet var riktigt intressant! Det är så mycket mer som jag hade velat göra, och kanske kolla upp 
olika API strukturer. Testa vad som funkar bättre, och sämre på vad. Men detta gav mig en väldigt stor inblick i hur det är att skriva och göra en bra API. 
Hur mycket struktur, och hur mycket planering man gärna gör innan man ens börjar skriva koden. Det är mycket som ska fungera tillsammans, och mycket som man kan utveckla.

Jag hade kunnat sitta med detta i en månad bara för att utveckla och polera det som jag har färdigt just nu. Men det får bli ett senare projekt.

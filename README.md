# Mettbrötchenkostenberechner
Dieses Programm lässt Personen Mettbrötchen bestellen und berechnet die Kosten
für die Bestellung. Es wird ein Name, die Anzahl der Mettbrötchen und die 
Grammzahl des Metts benötigt.

Der Host muss die Kosten eintragen und erstellt dann Emails mit 
Zahlungsdetails für die jeweiligen Personen.

## Für Hosts:

### Einladen:
1. Starten Sie das Programm & Klicken Sie auf "Einladen"
2. Sie können dort die Zeit eintragen, bis zu der die Bestellung möglich ist.
3. Klicken Sie auf "Mitteilungen senden"
   - Die Nutzer welche die Software installiert und gestartet haben, erhalten eine Mitteilung.
   
![/MettbroetchenWpf/einladen.png](Assets%2Fscreenshots%2Feinladen.png)
### Abrechnen:
1. Starten Sie das Programm & Klicken Sie auf "Rechnungseditor"
2. Wählen Sie das Datum der Bestellung aus
    - Im Label wird angezeigt, wie viele Personen an diesem Datum bestellt haben.
3. Geben Sie die anderen erforderlichen Daten ein.
4. Klicken Sie auf "Senden"
    - Die Nutzer erhalten automatisch eine Email mit den Zahlungsdetails.

![/MettbroetchenWpf/rechnungseditor.png](Assets%2Fscreenshots%2Frechnungseditor.png)
    
## Für Benutzer:
1. Starten Sie das Programm
2. Geben Sie die erforderlichen Daten ein
    - Wichtig: Die Emailadresse muss korrekt sein, da Sie sonst keine Zahlungsinformationen erhalten.
4. Klicken Sie auf "Senden"
5. Wenn der Vorgang erfolgreich war, wird Ihnen eine Mitteilung angezeigt.
6. Sie können nun das Programm schließen.

![/MettbroetchenWpf/anmeldung.png](Assets%2Fscreenshots%2Fanmeldung.png)

Guten Appetit!

## Für Entwickler:

### Anforderungen:
- .NET Framework 7.0
- SQL Server 2012 oder höher

### Installation:
1. Laden Sie das Repo runter
2. Öffnen Sie die Solution in Visual Studio
3. Wechseln Sie zum Microsoft SQL Server Management Studio
4. Erstellen Sie eine neue Datenbank (Standardname: "local")
5. Wechseln Sie zurück zu Visual Studio
6. In der "SessionFactory.cs" müssen Sie die Datenbankverbindung anpassen
    - Dafür verändern Sie Zeile 11-14.
7. Kompilieren Sie das Projekt


## Todo:
### Rechnungseditor
- *keine*
- sonstige Rechnungen hinzufügen
- runden auf nächsthöhere 10 cent
- schauen wer noch bezahlen muss + Mahnung
- abhaken wer bezahlt

### Automatische Email an den Host mit Bestellliste wenn der Anmeldeschluss erreicht wurde.
- async
- erweitern der comboboxen als admin
- daten in config speichern

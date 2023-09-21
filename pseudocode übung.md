#Winter 2020

## Pseudocode für 2FA

```text
INPUTS: string: username, string: password
OUTPUTS: boolean:

IF username IS wrong OR password IS wrong
    RETURN false
ELSE
    GET OTP
    INPUT otp
    IF opt IS OTP
    RETURN true
    ELSE
    RETURN false
```

## Pseudocode für Rezeptfarbe
```
INPUTS: string: versicherungsart, string: arzneimittelart
OUTPUTS: string: rezeptfarbe

CHECK versicherungsart
IF versicherungsart IS gesetzlich
    CHECK arzneimittelart
    IF arzneimittelart IS verschreibungspflichtig
        SET rezeptfarbe TO rosa
    ELSE
        SET rezeptfarbe TO grün
ELSE
    CHECK arzneimittelart
    IF arzneimittelart IS verschreibungspflichtig
        SET rezeptfarbe TO gelb
    ELSE
        SET rezeptfarbe TO blau

RETURN rezeptfarbe
```

## Pseudocode für Fakultät

```
INPUTS: integer: number
OUTPUTS: integer: factorial

IF number is negativ
RETURN -1

IF number is zero
RETURN 1

SET factorial TO number
SET number TO numer - 1S
WHILE number is bigger than one
    SET number TO number - 1
    SET factorial TO factorial * number
REPEAT WHILE

RETURN factorial
```
Please note. The following pseudo code ist André certified.
```text
Gib eine Zahl ein und speicher diese unter der Variable N
Initalisiere eine Variable F

Wenn N kleiner als 1
    Gib -1 zurück

Wenn N gleich 0
    Gib 1 zurück

Sonst
    Setze F gleich N
    Wiederhole bis N gleich 1
        Verkleinere N um 1
        Berechne F * N und setze F als das Ergebnis
    
    Gib F zurück
```
#Winter 2020

## Pseudocode für 2FA

```text
INPUTS: username, password
OUTPUTS: inputsBool?

IF username IS wrong OR password IS wrong
SET inputsBool TO false
RETURN inputsBool
ELSE GET OTP 
    IF OTP IS correct
    SET inputsBool TO true
    RETURN inputsBool
    ELSE
    SET inputsBool TO false
    RETURN inputsBool
```

## Pseudocode für Rezeptfarbe
```
INPUTS: versicherungsart, arzneimittelart
OUTPUTS: rezeptfarbe

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

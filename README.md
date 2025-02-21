# 15-Windmills-sshaar

Funktionsweise

    Windmühlensteuerung:

        - Drückt man die Leertaste, beginnt die erste Windmühle sich zu drehen. Je länger die Leertaste gedrückt wird, desto schneller dreht sich die Windmühle.
        - Die Geschwindigkeit wird visuell durch einen Slider auf der Windmühle angezeigt.
        - Ein Licht, das sich ebenfalls auf der Windmühle befindet, wird heller, je schneller sich die Windmühle dreht. Die Lichtstärke ist direkt an die                Geschwindigkeit gekoppelt.

    Lock-Button:

        - Jede Windmühle hat einen Lock-Button. Drückt man diesen, wird die aktuelle Geschwindigkeit der Windmühle "eingefroren".
        - Nachdem die Geschwindigkeit gesperrt ist, kann die nächste Windmühle gesteuert werden.
        - Dieser Vorgang wiederholt sich für jede weitere Windmühle.

    Farbe des Hintergrunds:

        - Im Hintergrund befindet sich eine Box, die als Farbanzeigefeld dient. Die Farbe dieser Box wird basierend auf den Geschwindigkeiten der ersten drei Windmühlen dynamisch angepasst.
        - Jede Windmühle steuert eine Farbkomponente:

           Die erste Windmühle beeinflusst den Rotwert.
           Die zweite Windmühle beeinflusst den Grünwert.
           Die dritte Windmühle beeinflusst den Blauwert.

    Anpassbarkeit:

        - Es können beliebig viele Windmühlen hinzugefügt werden. Das System erkennt automatisch die Lichter, Slider und Rotoren der Windmühlen und passt die Steuerung - entsprechend an.
        - Der Hintergrund wird farblich basierend auf den Geschwindigkeiten der ersten drei Windmühlen angepasst, aber alle Windmühlen können unabhängig voneinander  gesteuert werden.

    Steuerung:

        - Leertaste: Erhöht die Geschwindigkeit der aktuellen Windmühle.
        - Lock-Button: Sperrt die Geschwindigkeit der aktuellen Windmühle und wechselt zur Steuerung der nächsten Windmühle.
    
    UML-Diagramm:
   ![15-UML-sshaar](https://github.com/user-attachments/assets/8680b675-fd3e-4c5a-b9e7-54248d0ad021)


    

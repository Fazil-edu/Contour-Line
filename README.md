# Contour line
Ausgangspunkt für dieses Projekt ist die Aufgabe ist: https://www.matse-ausbildung.de/hoehenlinien.html

  1. [Problemanalyse](#1-Problemanalyse)
      1. [Überführung der Daten aus der Datei in die Datenstruktur](#Überführung-der-Daten-aus-der-Datei-in-die-Datenstruktur)
      1. [Volumenberechnung](#Volumenberechnung)
      1. [Transportdauer](#Transportdauer)
      1. [Balkenform](#Balkenform)
      1. [Höhenlinien](#Höhenlinien)
  2. [Entwurf](#2-Entwurf)
## 1. Problemanalyse
### Überführung der Daten aus der Datei in die Datenstruktur
Die Messdaten sind sowohl vertikal als auch horizontal mit dem gleichen Abstand in einem Rost gegeben. Gegeben seien z.B. 12 Höhenwerte wie unten.

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Measuringdata%20WD.png" width="600" height="550">

Um das nicht so kompliziert zu machen, nehme man an, dass die bei (x,y)- Koordinaten x und y für ganze Zaheln stehen (das werden wir unten zur Nutze machen).

Und sie sind in einer Datei **sequentiell** gespeichert, wie z.B. unter in einer Textdatei.

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Measuringdata%20TF.png" width="300" height="450">

Für die Verwaltung solcher Daten aus der Textdatei ist ein (n,m) - Array, der aus (x,y,h)-Tupeln besteht, geeignet. Bei obigem Bild ist z.B. n = 3 und m =  4. Da Daten **sequentiell** in der Textdatei gespeichert ist, ist es nicht ohne die n und m - Werte zu finden. Denn, wenn die Textdatei z.B. 64 Zeilen hat, kann es mehrere Formen wie diese Fo (8,8), (4,16),(16,4),(2,32), (32,2), (1,64) oder (64,1) haben. Um das Problem zu lösen suche man den ersten x-Wert in den anderen Zeilen. Hat man es gefunden, so steht die Index der jeweiligen Zeile für die Anzahl der Spalten in dem Raster. Danach kann man dann die Daten in einem Array speichern. Das Struktogramm dafür:
<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Transport%20time%20NS-diagram.jpg" width="630" height="500">
### Volumenberechnung

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Prisma.png" width="630" height="500">

Um das Volumen einer Prisma zu berechnen, kann man die Querschnittsmethode verwenden. Dafür rechne man das Mittel der Höhen der Vorderseite und das Volumen aus diesem Mittel und ebenso jenes Mittel der Höhen der Rückseite somit das Volumen aus jenem Mittel. Das Volumen der ganzen Prisma nehme man dann das Mittel aus diesen beiden Volumen. In Formeln:

<img src="https://latex.codecogs.com/svg.image?A_{v}=\frac{1}{2}\Delta&space;x^2(h_{1}&space;&plus;&space;h_{2})" title="A_{v}=\frac{1}{2}(h_{1} + h_{2})\Delta x^2" />

und

<img src="https://latex.codecogs.com/svg.image?A_{r}=\frac{1}{2}\Delta&space;x^2(h_{3}&space;&plus;&space;h_{4})" title="A_{r}=\frac{1}{2}(h_{3} + h_{4})\Delta x^2" />

Somit gesamt Volumen der Prisma ergibt sich:

<img src="https://latex.codecogs.com/svg.image?V&space;=&space;\frac{A_v&space;&plus;&space;A_r}{2}&space;=&space;\frac{(\frac{1}{2}\Delta&space;x^2(h_1&space;&plus;&space;h_2)&space;&space;&plus;&space;\frac{1}{2}\Delta&space;x^2(h_1&space;&plus;&space;h_2))}{2}=\frac{\Delta&space;x^2}{4}(h_1&space;&plus;&space;h_2&space;&plus;&space;h_3&space;&plus;&space;h_4)" title="V = \frac{A_v + A_r}{2} = \frac{(\Delta x^2\frac{1}{2}(h_1&space;&plus;&space;h_2)&space;+\frac{1}{2}\Delta x^2(h_1 + h_2)\Delta x^2)}{2}=\frac{\Delta x^2}{4}(h_1+h_{2}+h_{3}+h_{4})"/>


Das Volumen des Hügels berechnet sich aus den Volumen 1, 2, 3, 4, 5 und 6 im Grün

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Volume.png" width="630" height="500">

Dafür bräucte man nur die roten Knoten zu wissen. Für die Höhe <img src="https://latex.codecogs.com/svg.image?i" title="i" />, liegen die anderen Höhen einer Prisma

<img src="https://latex.codecogs.com/svg.image?i&plus;1,&space;i&plus;4,&space;i&plus;5" title="i+1, i+4, i+5" />

Das Struktogramm für die Volumenberechnung:

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Volume%20calculation%20NS-diagram.jpg" width="2000" height="350">

### Transportdauer
Ein LKW kann in einer Fahrt, die 30 Minuten dauert, 7 m3 Erde abtransportieren. Wie lange dauert bis ein LKW ein x m3 Erde abtransportieren kann. Aus Dreissatzrechntung folgt, dass ein LKW   <img src="https://latex.codecogs.com/svg.image?\frac{30&space;x}{7}" title="\frac{30 x}{7}" /> Minuten braucht, um einen Hügel abzutransportieren. Wie lange braucht dann bis n LKWs einen x m3 Erde abtransportieren? Ebenso aus der Dreissatzrechnung folgt: <img src="https://latex.codecogs.com/svg.image?\frac{30&space;x}{7&space;n}" title="\frac{30 x}{7}" />. Umgerechnet auf Stunden und Tagen ergibt sich: <img src="https://latex.codecogs.com/svg.image?\frac{30&space;x}{14}" title="\frac{30 x}{14}" /> Stunden und <img src="https://latex.codecogs.com/svg.image?\frac{30&space;x}{336}" title="\frac{30 x}{336}" /> Tage. Struktogramm dafür: 

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Transport%20time%20NS-diagram.jpg" width="430" height="300">

### Balkenform

Für die Balkenform kann man aus 2 Perspektiven und in jeder Tiefe Profile bzw. Schichten zeichnen und damit die ungefähre Form des Hügels darstellen. Im Bild unten würde z.B. einen Hügel in bzw. aus einer bestimmten Tiefe bzw. Perspektive in Balkenform sehen.

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Layers.png" width="550" height="350">

Dies wir natürlich mit hohen Anzahl der Messpunkten entsprechend "runder".

Das Struktogramm dafür:

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Problem-Analysis/Barshape-NS-diagram.png" width="550" height="350">


### Höhenlinien

## 2. Entwurf

**Klassendiagramm**

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Draft/Class%20diagram.png" width="550" height="350">

**Sequenzdiagramm für Dateiauswählen**

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Draft/Sequence diagram - file selection.png" width="550" height="350">

**Sequenzdiagramm für Transportzeit**

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Draft/Sequence diagram - transport time.png" width="550" height="350">

**Sequenzdiagramm für Volumenberechnung**

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Draft/Sequence diagram - volume calculation.png" width="550" height="350">

**Sequenzdiagramm für Balkenform**

<img src="https://github.com/Fazil-edu/Contour-Lines/blob/main/Pictures/Draft/Sequence diagram - bar shape.png" width="550" height="350">


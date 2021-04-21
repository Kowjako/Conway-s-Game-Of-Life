# Automat komórkowy "Gra w życie"
Program demonstruje automat komórkowy "Gra w życie" wymyślony brytyjskim matemtykiem Johnem Conway'em, program napisany na platformie WPF
# Reguły  
💡 ``Klatka może być lub żywa lub martwa ``  
💡 ``Jeżeli klatka jest żywa oraz ma dwóch lub trzech sąsiadów to pozostaje żywa w przeciwnym przypadku wymiera``  
💡 ``Jeżeli klatka martwa ale na kolejnym kroku symulacji ma dokładnie trzech sąsiadów staje się żywą.`` 
# Idea realizacji komórek
Najciekawsze w tym projekcie to było zaimplementowanie środowiska do symulacji, zdecydowałem utworzyć w **XAML** kontener **Canvas**. Na początku programu generuje się środowisko, czyli do Canvas wstawiane Rectangle z metką że nie jest ta klatka żywa. Następnie do kolejnych iteracji po pierwszej stworzyłem tablicę dwuwymiarową która będzie odpowiedzialna za poszczególne komórki, komórka przedstawiona obiektem **Rectangle**, ale do każdego Rectangle dodaje swoją metkę którą realizuje klasa **Cell** (właściwość **Tag** klasy Rectangle) która będzie pomagała sprawdzać czy ta komórka jest żywa lub martwa.
# Screenshot
![gameoflife](https://user-images.githubusercontent.com/19534189/115613837-31b7a580-a2ed-11eb-862a-efce7bdb28d5.gif)

# Bullethell
*Projekt zaliczeniowy na laboratoria przedmiotu Wstęp do programowania
Przygotowane przez **Annę Krasowską** i **Konrada Kowalczyka***

## Koncept gry

Gra 2D, skupia się na walce z bossem (docelowo wiele bossów), który posiada różne mechaniki (fazy) ataku gracza. W obecnej wersji gry po pokonaniu przeciwnika (tj. kiedy punkty życia przeciwnika <=0) pokazuje się ekran wygranej, natomiast po śmierci gracza pokazuje się ekran porażki.

## Narzędzia

Silnik użyty do stworzenia gry to Unity, skrypty natomiast pisane były w C# przy wykorzystaniu podstawowych zasad programowania obiektowego (enkapsulacji, dziedziczenia, abstrakcji i polimorfizmu). Z pomocą narzędzi dostarczanych razem z Unity zarządzamy fizyką gry - w tym momencie głównie wykrywanie kolizji pomiędzy obiektami w grze. Unity zajmuje się również renderowaniem grafiki, w tym przypadku sprite'ów 2D.

## Skrypty
Wszystkie skrypty oraz obiekty w folderze Assets/Scripts zostały stworzone/napisane przez nas od zera. Pozostałe skrypty oraz obiekty są zewnętrznymi pluginami/assetami.

# Zasada działania

## Gracz

Gracz porusza się przyciskami WSAD, obrót postaci natomiast jest wykonywany myszką. Gracz posiada życie, które jest wyświetlane jako element UI (interfejsu użytkownika), skończenie się życia graczowi skutkuje wyświetleniem się ekranu końca gry (game over).

## Pociski gracza

Pociski gracza są pobierane z puli i umieszczane przy graczu w kierunku w którym obecnie jest obrócony i w tym kierunku również jest nadawana prędkość pociskowi po przez przyłożenie do niego punktowej siły. Istnieją dwa typy pocisków: zielony i czerwony. Nie różnią się one niczym oprócz koloru, ich implementacja miała na celu przetestowanie działania puli dla różnych obiektów. Strzelanie obsługiwane jest przez skrypt Shooting.cs, natomiast pula pocisków przez BulletsPool.cs. 

### Zasada działania puli
Pula składa się ze słownika kluczowanego po ID pocisków (różne dla każdego typu pocisku). Wartościami słownika są kolejki trzymające nieaktywne pociski. Gdy system zrequestuje pocisk, a kolejka dla jego ID jest pusta to powstaje nowy pocisk tworzony z konkretnego prefabu. W momencie zniszczenia (po 4s lub trafienie w cel) pocisk jest zwracany do puli i wyłączany. 

### Singleton
Dostęp do puli został zrealizowany przy użyciu wzorca projektowego Singleton. Wzorzec ten ma zapewnić jedną i tylko jedną instancje danej klasy. Zrealizowany został po przez napisanie generycznej klasy Singleton.cs

### Zmiana broni gracza
Gracz ma dostęp do dwóch pocisków zmienianych przy użyciu klawiszy 1 i 2. Pociski są trzymane w ScriptableObjectcie o nazwie ItemsDB i z niego są na starcie pobierane.

## Przeciwnik

Aktualnie jedyny przeciwnik posiada wykrywanie ścieżki do gracza przy wykorzystaniu pluginu z algorytmem A* (znajdowanie najkrótszej ścieżki w grafie ważonym) oraz różne fazy (stany), które zarządzane są FSM (Finite State Machine, skończona maszyna stanów). Stany te to:
- InitState -- stan wejściowy
- ChasePatternState -- algorytm wyszukiwania ścieżki jest włączony, przeciwnik chodzi za graczem (wykrycie kolizji oraz pozostanie w kolizji z graczem powoduje zadawanie obrażeń graczowi)
- CrossLaserPatternState -- przeciwnik stoi na środku areny i tworzy 4 'lasery', które się dookoła niego obracają. Lasery wykrywają kolizję na podstawie Raycastów, ponieważ lasery są renderowane jako linie, bez collider'a
- CircleProjectile(Pattern)State -- przeciwnik wypuszcza 8 pocisków utworzonych dookoła niego, początkowe pozycje pocisków obliczone za pomocą podstawowych funkcji trygonometrycznych

Przeciwnik po wyjściu ze stanu wejściowego będzie po kolei przełączał się pomiędzy 3 zaimplementowanymi stanami aż do śmierci.

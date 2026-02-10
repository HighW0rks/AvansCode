# 🕹 Debugging Race – Unity Challenge

Welkom bij de **Debugging Race**!  
In deze oefening debug je een Unity-project en optimaliseer je de performance. Het project bevat veelvoorkomende fouten rond **UI, MonoBehaviours, SetActive, OnClick, Start/Update** en **Inspector-referenties**.

---

##  Doel van de oefening

- Werken met **breakpoints** en **Attach to Unity** (Visual Studio / VS Code).
- Fouten herkennen en oplossen:
  - **NullReferenceException**
  - Verkeerde **OnClick**-koppelingen
  - Logica-problemen bij **SetActive()**
  - **Performanceproblemen** in `Update()`
- Begrip van **primitives** vs **reference types** in Unity.

---

## Inhoud van het project

**Scene:** `DebuggingRace`

**Hierarchy (samenvatting):**
- `Canvas`
  - `Label` (Text of TextMeshProUGUI)
  - `ActionButton` (Button)
  - `TogglePanelButton` (Button)
  - `StatusText` (Text)
- `Panel` *(start op inactive)*
- `Managers`
  - `UIManager` (script)
  - `GameController` (script)
- `Rotatingtriangle` (triangle)
- `EventSystem`

>  In het startproject zijn expres een paar referenties in de **Inspector** niet gevuld en sommige knoppen niet (goed) gekoppeld.

---

## Jouw missie

Er zitten **5 bugs** in het project, mogelijk meer! Maar dat kan niet met zekerheid worden gezegd. Los ze op en zorg dat alles werkt zoals bedoeld:

1. **Label crasht bij start**  
   - **Symptoom:** `NullReferenceException` in `UIManager.Start()`.  
   - **Hint:** Staat de `label`-referentie correct ingesteld in de Inspector? Klopt het type (UGUI vs TMP)?  
   - **Tip:** Zet een breakpoint in `UIManager.Start()` en inspecteer `label`.

2. **ActionButton doet niets**  
   - **Symptoom:** Klikken verandert de tekst niet.  
   - **Hint:** Is de juiste **methode** gekoppeld (public, juiste signatuur)? Verwijst de Button naar het goede **GameObject**?  
   - **Tip:** Check in de Inspector: `Button → OnClick()`-lijst en de `GameController.ui`-referentie.

3. **Panel toggle werkt niet goed**  
   - **Symptoom:** Panel blijft uit of werkt omgekeerd.  
   - **Hint:** Logica in `TogglePanel()` en initiële state van `panel`.  
   - **Tip:** Wat doet `activeSelf`? Moet je deze **inverteren**?

4. **Performanceprobleem in Update()**  
   - **Symptoom:** Console-spam of framedrops.  
   - **Hint:** Staat er `Debug.Log` in `Update()`? Wordt er iets duur per frame gedaan (Find/GetComponent/Instantiate)?  
   - **Tip:** Open **Profiler** en **Console** om het te lokaliseren.

5. **UI rendering volgorde klopt niet**  
   - **Symptoom:** Label lijkt niet te updaten / zit “achter” andere UI.  
   - **Hint:** **Canvas-hierarchy** bepaalt de volgorde; ook `transform.SetAsLastSibling()` kan helpen.  
   - **Tip:** Sleep `Label` in de Hierarchy naar boven/onder en test.

---

##  Tools & werkwijze

### Debuggen (Visual Studio / VS Code)
1. Open het project in Unity en je IDE (via **Open C# Project**).
2. Zet **breakpoints** (bijv. in `UIManager.Start()` en `GameController.OnActionButtonClicked()`).
3. **Attach to Unity**:
   - **Visual Studio:** `Debug → Attach Unity Debugger → kies Unity Editor`.
   - **VS Code:** Installeer *Debugger for Unity* → `Run and Debug → Attach to Unity`.
4. Druk op **Play** in Unity en gebruik je breakpoints om variabelen te inspecteren (Locals/Watch/Call Stack).

### Profiler (performance)
1. Open **Window → Analysis → Profiler**.
2. Let op **CPU**-tijd en **GC.Alloc** pieken.
3. Zoek naar log-spam, `Update()`-allocaties en dure calls (Find/GetComponent/Instantiate).

---

##  Doeltoestand (wanneer ben je klaar?)

- Label toont correcte tekst bij start (geen NullReference).
- `ActionButton` verandert de Label-tekst via `OnClick`.
- `TogglePanelButton` laat `Panel` zien/verbergen (logica klopt).
- Geen **NullReferenceExceptions**.
- Geen **log-spam** of onnodig zware acties in `Update()`.
- UI-elementen staan in een **logische rendering-volgorde**.

---

##  Extra uitdaging (optioneel)

- Voeg een extra Button toe die de Label-tekst dynamisch aanpast (bijv. met een teller of timestamp).
- Optimaliseer UI-updates: pas alleen de Label-tekst aan **als de waarde verandert** (debounce/throttle).
- Verplaats dure calls uit `Update()` naar `Start()`/`Awake()` en **cache** componentreferenties.

---

##  Tips & veelgemaakte valkuilen

- **NullReferenceException** → Controleer **Inspector-referenties** en types (UGUI vs TMP). Voeg **null-checks** toe.
- **OnClick werkt niet** → Methode moet **public** zijn en de signatuur moet kloppen; koppel de **juiste component**.
- **Zware Update()** → Vermijd `Debug.Log` en `Find/GetComponent/Instantiate` elke frame; gebruik **caching**, **throttling**, **object pooling**.
- **Rendering-volgorde** → De **child-volgorde** in de Canvas bepaalt wat bovenop ligt. Gebruik eventueel `SetAsLastSibling()`.


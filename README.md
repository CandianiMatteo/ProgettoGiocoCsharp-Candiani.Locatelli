# 🎮 **Concept del Gioco**

Un’esperienza narrativa/puzzle basata sull’interazione con un pannello di controllo minimale.  
Il giocatore non riceve istruzioni dettagliate: deve osservare, sperimentare e dedurre le regole di ogni livello.  
Ogni azione modifica lo stato del mondo di gioco e può generare risultati inattesi, incoraggiando curiosità e tentativi.

L’obiettivo non è “vincere”, ma **scoprire**: trovare soluzioni, provare combinazioni, godersi gli imprevisti.

---

# 🧩 **Struttura dei Livelli**

## **LIVELLO 1 – Il primo click**
**Obiettivo:** cliccare il bottone centrale  
**Schermata:** un grande bottone al centro  
**Regole:**
- Qualsiasi click completa il livello  
- Nessun timer  
- Non è possibile fallire  

---

## **LIVELLO 2 – Numero corretto**
**Obiettivo:** cliccare il bottone esattamente **3 volte**  
**Schermata:** bottone con contatore visibile  
**Regole:**
- Ogni click incrementa il contatore  
- Al terzo click esatto → livello completato  
- Se si supera il 3 → contatore si resetta  

---

## **LIVELLO 3 – Sequenza corretta**
**Obiettivo:** premere i bottoni nell’ordine mostrato  
**Schermata:** tre bottoni etichettati **A – B – C**  
**Regole:**
- All’inizio viene mostrata una sequenza per 1 secondo (es. A → C → B)  
- Poi i bottoni tornano normali  
- Il giocatore deve ripetere la sequenza  
- Errore → reset del livello  
- Sequenza corretta → livello superato  

---

## **LIVELLO 4 – Caccia al colore**
**Obiettivo:** cliccare le celle che cambiano colore  
**Schermata:** griglia **3×3**  
**Regole:**
- Tre celle casuali si colorano per 1 secondo  
- Poi tornano normali  
- Il giocatore deve cliccare solo quelle tre  
- L’ordine non conta  
- Cella sbagliata → reset  
- Tutte e tre corrette → livello completato  

---

## **LIVELLO 5 – Doppio click sincronizzato**
**Obiettivo:** premere due bottoni quasi contemporaneamente  
**Schermata:** due bottoni (sinistra e destra)  
**Regole:**
- I due click devono avvenire entro **0,5 secondi**  
- Se troppo distanti → reset  
- Se abbastanza vicini → livello completato  

---

## **LIVELLO 6 – Pannello di controllo**

**Obiettivo:** trovare la configurazione corretta del pannello
**Schermata:**  
- Sei **CheckBox**  
- Una **Progress Bar**  
**Regole:**
- Le sei CheckBox possono essere attivate o disattivate liberamente.
- La **Progress Bar** aumenta o diminuisce in base a quanto ci si avvicina alla soluzione.
- Esiste **una sola combinazione corretta** di CheckBox.
- Il giocatore deve interpretare gli indizi e osservare la Progress Bar per capire se si sta avvicinando alla soluzione.

---

## **LIVELLO 7 – Indovinello + azione**
**Obiettivo:** risolvere un indovinello e compiere un’azione  
**Indovinello:** “Ho un'infinita memoria ma non ricordo nulla. Posso essere veloce ma anche lento. Cosa sono?” → **Hard Disk**  
**Regole:**
- Inserire la risposta corretta  
- Si sblocca una griglia  
- Va cliccata la cella centrale  

---

## **LIVELLO 8 – Trappole invisibili**
**Obiettivo:** evitare le celle sbagliate  
**Schermata:** griglia **3×3**  
**Regole:**
- Tre celle sono trappole  
- Se cliccate → reset  
- Devono essere cliccate almeno 3 celle sicure  

---

## **LIVELLO 9 – Percorso continuo**
**Obiettivo:** cliccare cinque celle adiacenti formando un percorso  
**Schermata:** griglia **5×5**  
**Regole:**
- Ogni cella deve essere adiacente alla precedente (orizzontale, verticale)  
- Non si può cliccare due volte la stessa cella  
- Cella non adiacente → percorso annullato  
- Cinque celle valide → livello completato  

---

## **LIVELLO 10 – Prova finale**
**Obiettivo:** completare una sequenza di azioni  
**Regole:**
1. Attendere 3 secondi  
2. Risolvere un indovinello  
3. Ripetere una sequenza  
4. Accendere tutte le celle della griglia  

---

# 🏁 **Fine del gioco**
Messaggio finale: **“Hai superato tutte le prove.”**

Vengono mostrati:
- Username  
- Tempo di gioco  

---


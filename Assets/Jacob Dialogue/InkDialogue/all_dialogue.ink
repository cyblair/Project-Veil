-> npc
=== npc ===
Waffles or pancakes?
+ [Waffles]
    You are so fucking wrong.
    Why would you ever think waffles are better.
    Get a grip.
    I'll ask again.
    -> npc
* [Pancakes]
    Good job you're right.
- -> DONE

-> dummy
=== dummy ===
VAR inBattle = false
+ [No]
The dummys cold stare frightens you.
(You walk away slowly)
(coward)
-> DONE
+ [Yes]
(You prepare for battle!)
~inBattle = true
-> DONE
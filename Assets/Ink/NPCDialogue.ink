// Start of dialogue
VAR playerName = "Traveler"

Hello, {playerName}. Welcome to the cyber city!
+ "What’s happening here?"
-> city_story
+ "Who are you?"
-> npc_identity
+ "Goodbye."
-> END

== start ==
Hello, {playerName}. Welcome to the cyber city!
+ "What’s happening here?"
-> city_story
+ "Who are you?"
-> npc_identity
+ "Goodbye."
-> END

== city_story ==
The city is in chaos. The gangs have taken control.
+ "That sounds dangerous."
-> danger_warning
+ "Can I help?"
-> mission_offer

== npc_identity ==
I'm just an old man trying to survive.
-> start

== danger_warning ==
Yes, be careful out there.
-> start

== mission_offer ==
Actually, I do have a task for you...
-> END

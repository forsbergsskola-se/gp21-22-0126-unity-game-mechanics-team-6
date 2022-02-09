# gp21-22-0126-unity-game-mechanics-team-6
gp21-22-0126-unity-game-mechanics-team-6 created by GitHub Classroom


Todo:
You should also write a ReadMe file inside of the project repository containing the following information about each team member:
- Their name
- The word or phrase describing their game mechanic
- A brief description of the 2 different implementations of their mechanic and which level the different implementations are used in.

- VG only: What AI units did the student create and which game mechanic/mechanics the AI units uses. If they use a game mechanic created by another team member, write their name in parentheses after the game mechanic’s name.




Who did what?

-------------------------------------------
Oskar:

I made two different flight based movement systems.
Both have been made to be easily configurable, and modular.

Version 1:

- Fuel based, if it runs out, you fall down. Found in level 1.

Version 2: 

- Floating movement. No gravity affects you. Found in level 2.

Ai's:
- In the first level I made three small companions that follow the player around using version 2 of my movement system.
- In the second level I made a enemy that will chase the player in the event of a collision, until another collision between them occur. Basically he gets mad that you hit him, so he tries to hit you back.

-------------------------------------------

Emanoel:

I made different balls that gives the player different power-up.
The power-up can be an effect that is forever, or just in an amount of time. Default: 10 Seconds.

Version 1 - Level 1:
Different powerUps that is placed in the level.
When player is walking on it, a nice effect is shown while you gain a powerup.
Power up could be:
	•	Bigger Size
	•	Faster Movement Speed
	
Version 2 - Level 2:
A Powerup that effects the player and the enemy.
Giving the player positive stats and the enemy Negative stats
	•	Player: Faster Movement Speed, Enemy: Slower MovementSpeed	

Some extra PowerUps that was planning on being used, works but needs some different changes:
PowerUp: Teleport
Player gets two teleports within a time limit.
Works better if it is not a platformer view. (2D)

-------------------------------------------

Olle:
I made different ways for the character to dash in the game.

Version 1 - Level 1:
When pressing spacebar, player dashes in the direction they're moving in. The dash'force' decreases over time as the button is pressed, to create a nice quick acceleration followed by a slowing down at the end of the dash. I also initially made it with the intention to allow the player to move in 4 directions as I misunderstood how we defined 2.5D, and so I left the code that would allow the player to dash in the Z direction intact, should we want to expand the game in that way, and since it doesn't do any harm to the game in it's current state with the Z position being frozen in the editor

Version 2 - Level 2: 
A charged dash that lets the player hold down either V(left) or B(right) to charge up a more powerful dash to the left or right depending on which key has been pressed. I considered clamping the values of the dash but found it too funny that player can basically charge up an infinite amount of dashpower to bring myself to implement that limit.

-------------------------------------------
Toofan:


I made a Fighting System that a character can get into the hand to hand combat with the enemy, there are two Keys that are responsible for character Attack which they are X for punches and Z for Kicks. These inputs trigger different sets of attacks and rapidly pressing them will create a COMBOS and player can mix variety of movements to eliminate the enemy.
Also I created the Enemy Fighting system which it looks for player and runs towards him/her and when it reached in the range of attacks it combines it moves to attack the player also there is a health mechanism implemented which indicates enemy and players health Bar.
There are animation delegates and events for each movements and attacks.

For level two:
Player also have its own battle technique but it can equip weapons and get in battles in long ranges, There combinations of takedowns in the player which automaticallyu trigger when get in short range with The Enemy. the health and animations delegates are universal but character input switch from X and Z to Q and E to shoot and throw.



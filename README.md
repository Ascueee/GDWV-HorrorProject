# GDWV-HorrorProject
Video Link

https://www.youtube.com/watch?v=v-D0HC1q0Ac

Team Members and Roles

Dylan Dos Ramos - 100873698 

Partially coding, UML Graphs, Explanation of functions, 33%

Hayyan Khan - 100858456

Coding, Explanation of functions 33%

Shehryar Aamir - 100876618 

Idea suggestion for integration of design patterns, visual explanation, explanation of functions33%


# Game Information

The game is going to be a short horror game that has a monster constantly trying to find, and chase the player around the area. It contains escape-room-like puzzles and the player must complete the puzzle to finish the game. The game contains no combat within it, so the only thing the player can do if they see the monster, is to run away from it. In addition if the monster reaches the player, then the player will instantly die, since the player will only have access to a single hit point. The player's main goal is to go around the map without the monster seeing them, and completing the necessary puzzles in order to escape. Aspects that further down the line are going to really enhance the experience will be implementing further lighting effects, and textures to make it feel much more like a horror game. 

# Singleton

Time Manager

The time manager found in the game is responsible for handling the pause menu, and also responsible for handling the timer that’s found at the top of the game. Starting with how the pause menu was implemented, it’s fairly basic in the way it works, firstly when the player presses escape it calls to the manager, and freeze’s all aspects of the game with Time.Timescale being set to 0, and then when the game resumes it then sets the time.Timescale to 1 for normal movement and time. For the handling of the timer now, it’s mostly the same, just instead of Timescale, DeltaTime is being used instead because while Timescale can track the speed of which the game is running at, DeltaTime can track how long a specific action is running for or meant to be running for, such as a timer that tracks the amount of time passed in the game.

UI Manager

The Ui Manager is responsible for displaying the elements that the player would like to see at all times, such as total time in game, and the amount of stamina the player has at the moment. The Manager is set within the canvas for easy access since all the data going in and out would be there. For example, telling the game to pause will make the Ui manager check the Pause menu, and then tell it to be active, letting the player be able to see it and interact with it.

Audio Manager

The audio manager's main purpose is to play audio files onto different objects who need them. For example the manager plays audio, and makes that audio come off of the monster, and the player, each of them having different sound effects. The way it works though, is that the audio manager looks for whenever one of the specified objects move, once they move the audio manager would detect it, and play the sound accordingly around the object. 




# Command

Customization

For customization, we decided to make it so that by pressing some assigned buttons (1-5) on the top of the keyboard the player can cycle between different colors that the player will appear as. This was done by taking the player as a GameObject, getting the mesh of the player, and replacing the material with a list of 4 different preassigned materials.

AI Updates

A second way we decided to implement the Command design pattern in our game was through AI behaviors through an EntityBrain script. This script when attached to a monster houses the many different behavior goals the monster has access to. In addition, the EntityBrain then creates a list of active tasks that the monster can do and then a list of dead behaviors the monster ignores. After, sorting and returning the right goal back to the monster as a variable called currentgoal; the monster then uses the command design pattern by using the current goal variable to call the goal function. This allows for easy goal creation as well as behavioral changes within the monster.

PlayerState/Movement State

Another way the command design pattern is implemented is through what we call player states which control what the player can do when the state is active. The way this is achieved is through the command design pattern which is done by calling a method called StateAction housed in the PlayerState script. This method holds the logic behind  the action for the player, for example, the logic behind walking. This would then be called in the player script like a command. This allows for dynamic state changes as well as expansion of new movement states with the scalability of the code.


# Factory


AI goals

The goals are objects that the monster will use to perform different tasks. The monster would use goalTrigger and PerformGoal, the monster would use a base goal template to perform any kind of behavior that we may want, for example we can add a behavior of making the Monster swim, or even dance. The weight system also determines the priority of the task, so the higher the weight the bigger the priority, and lower the weight the lower the priority. The Patrol goal would have a weight of 2, and idle a weight of 1, so the Monster would prioritize patrolling over being idle.



Monster

A second way we decided to implement the factory design pattern in our game is through our monsters actions. Within the monster class, we have the idle method and the patrol method, both of which perform different actions based on the situation the AI is faced with. To make our AI a bit more robust, we needed to have various methods tied to different actions so the monster isn’t always moving or isn’t always standing still. This can be further expanded down the line when we implement chase and investigate methods that can behave differently and create a more diverse set of actions for our monsters. The more the monster is capable of, the scarier they can be, so the more useful and functional methods we come up with through the factory design pattern, the better our monster AI can be.


Movement

A third way we decided to implement the factory design pattern in our game was through the movement of the player. Through the player movement class, we can add various methods that cause the player to perform certain actions based on what input is given. These actions range from basic movement via WASD, to a sprint feature using shift. These methods will be contained within the player movement class to reduce unnecessary pollution for classes, and can be easily modified and built upon at a later point in time.




# Observer

Sound Effects

One way we decided to implement the observer design pattern in our game was through sound effects. Since our game will put importance on the sound you make, for the current build, we want to implement sounds that vary depending on sprint and can be listened for by the AudioManager. When the player changes movement states, the audio manager is notified and changes the sound that must be played to represent that action. Walking and sprinting would be two different states, and having the audio manager listen for the player's state changes will help differentiate the audio output occurring. This can then be further expanded by having the monster sense audio within a certain proximity, and proximity can vary depending on noise generated from walking or sprinting states.




UI Updates

A second way we decided to implement the observer design pattern in our game was through updating the UI based on changes taking place in the game. For this build specifically, we plan to implement the design pattern by having UI elements be updated through deltaTime. When the player sprints, the listeners are notified of the stamina consumption taking place, reduce the stamina from the stamina bar, and visually update it at every frame to show the consumption. In the same vein, the game's timer will also be ticking through deltaTime.


Stamina Updates

A third way we decided to implement the observer design pattern in our game was through a stamina system in which the player can sprint to consume stamina from the stamina counter and move faster. To regenerate stamina, the player must return to a walking state, and the player can only sprint for a set amount of time before the entire stamina counter is depleted. Using the observer design pattern, we implement it by having the player class contain a method that consumes stamina through sprinting. Through the observer pattern, we can have the game be notified about these changes in stamina that can then be visually represented through a stamina counter, updating it actively through deltaTime. DeltaTime can also be used to set a max duration on the amount of time spent sprinting before stamina is fully depleted and the player must return to walking.




# Sources

ÖZDENFollow, C. B. (2017, February 16). Maw J Laygo - 3D model by Can Berk özden (@canberkozden). Sketchfab. https://sketchfab.com/3d-models/maw-j-laygo-eab313eee35f4e498cad7ffd100bec4a
For this, we decided to use an already existing model so we can more accurately test and see behaviors for the monster, this would be a lot better than using a capsule object or any basic Unity objects. In addition since our modeler isn’t in this class, we didn’t want to have to rush them to have it done in time for this assignment, and to give them more time so they can have it done for our main GDW project. 



https://www.mixamo.com/#/?page=1&query=idle&type=Motion%2CMotionPack
In addition to using a model from sketchfab we are using a temporary idle animation for testing from Adobe Mixamos library to test the entity states.

![image](https://github.com/user-attachments/assets/8fddcfc0-7f30-4fbd-8e1b-d2f47cc25516)

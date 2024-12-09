Mini-Project
Project Name: Target Practice
Name: Oscar Nielsen Bagger
Student Number: 20234314
Link to Project: https://github.com/oscarbagger/PI3D_Mini-Project 
Overview of the Game:
The main idea of the game was to make a movement shooter inspired by games like Lovely Planet and Neon White with a focus on speedrunning. The player must navigate the levels to find and shoot a number of targets as quickly as possible. The game tracks your time to beat each level, pushing players to try and beat their own fastest time. Therefore, the game should also feel fast-paced and skill-based, with a fail quickly putting you back into the action without wasting too much time.  
The main parts of the game are:
•	Player – Move with WASD. Control the direction you’re looking with mouse and shoot with left mouse button.
•	Targets - 2D sprite that rotates to always look at player. Can move up or down, bac k and forth in wave-like motion to be more difficult to hit. 
•	Levels - consists of simple cubes scattered around for player to jump around on and hide certain targets from view. Levels should be short, fast and replayable.  
•	Timer - When a level starts it tracks how long the player takes to finish a level and gives a final time at the end, which will be saved. 
•	Level selection menu - from here you can pick which of the 3 levels you want to play. 
Project Parts:
•	Scripts:
o	FPScontrols - Used for all player behaviour, moving, jumping, looking around and shooting.
o	UIcontroller – Used for handling and updating the UI. Both time and number of targets.
o	Billboard - Used to rotate 2D elements towards camera view.
o	Target - Target behaviour, movement and counting number of targets.
o	LevelController - Keeps track of when a level ends or restarts.
o	Highscore - used for updating and loading highscores of the different levels.
o	LevelSelection - handles everything to do with level selection scene.
o	DestroyTimer - will destroy a gameobject after a specified time. Used to remove stuff like particles after they’re done playing. 
•	Materials and textures:
o	Basic Unity materials for ground and player. Ground texture from asset pack: https://kenney.nl/assets/prototype-textures 
Sprites: 
o	Aim, target and particle images, made in Figma. 
•	Sound and music:
o	Used various asset packs found at: https://ovanisound.com/ 
•	Scenes:
o	The game consists of 3 levels and a level selection. 

How were the Different Parts of the Course Utilized:
The player is moved around the game world using a CharacterController for movement via keyboard inputs. The camera is put as a child gameobject of the player, moving along with it. The rotation is then handled by getting inputs from the mouse, changing the camera’s localRotation accordingly. 
If the player character falls from a platform, a collision with an invisible floor object will be detected on OnTriggerEnter, telling the LevelController to restart the level. 
To shoot, the game uses raycasting. Casting the ray from the middle of the cameras nearclipplane and outwards towards middle of the screen area for the same length as the camera can see. The raycast will only be detecting objects in the layer named Target, and if it hits something will immediately destroy it.  
The visuals of the shot are then done with a linerenderer tracing the path of the raycast, but with the start position angled from the arm of the player, to look like its starting from there instead. The linerenderer also uses a tiled sprite material to create the effect of a lightning shape to the line. If the ray hit something, the line will end at the objects position, but if not, it will draw the end as far as the ray has been cast. 
Moving around the targets is done by changing its local position based on a sine wave evaluation of time.time, making it do a waving motion back and forth, over a specified amount of time. 
When hitting a target, a particle system will be spawned to simulate the target breaking into smaller parts. The same particle texture is also reused for when completing a level. 
The Probuilder level editor was used to prototype and set up level. 
In an effort to give the game a more distinctive look, the color and intensity of the directional lighting was changed, also removing any shadows. On top of that, a Global Volume was used for post-processing effects on the camera, adding effects like bloom, chromatic aberration and vignette. 
Time Management
Task	Time it Took (in hours)
Setting up Unity project and github	0.5
Player movement	1.5
Shooting	2.0
Setting up UI elements 	1.0
Audio and music Implementation	1.0
Visual effects and particles	1.5
Level design	3.0
Level selection	1.5
Highscore saving	1.0
All	13

Used Resources
•	How To Make An FPS Player In Under A Minute - Unity Tutorial: https://www.youtube.com/watch?v=qQLvcS9FxnY 
•	LESSONS FROM AN IMPATIENT DEVELOPER: https://docs.google.com/presentation/d/1y7yU0jAg5_WakN46T6ccThDrT0UUbfqb/edit#slide=id.p1 
•	How To... Billboarding in Unity 2020 - 2D Sprites in 3D https://www.youtube.com/watch?v=_LRZcmX_xw0 



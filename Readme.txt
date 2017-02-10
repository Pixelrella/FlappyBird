Readme for awesome flappy bird clone 3000
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

- Infinite Backgrounds:
The Pipes and ground game objects are picked up and repositioned when the camera passes the screen. (HorizonalCollector.cs, PipeCollector.cs)

- Bird:
The bird is bounced and titled when the player hits a big button that covers most of the screen (Bird.cs, FlapButton)

- Scene mechanics:
There are two popups in the gameplay scene.
1) The ready button, active in beginning of the scene. (Game is paused)
2) The game over panel with restart/share options.

- Extras:
1) Day/Night cycle for the background image. (DayNightChange.cs)
2) Moving pipes (MovingPipes.cs)
3) Collectables that will change the scaling of the bird (Scripts/Collectables)

- Invincibility:
The bird has an option not to die on contact. (Bird script on bird gameobject).+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Ideas for more time:
1) Facebook connect: Display score of you friends in game.
2) Monetization/Fun: Different avatars (e.g. flying carpet), would be used to show high score in game for Facebook friends.
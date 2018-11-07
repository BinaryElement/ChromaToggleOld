# MediocreMapper

EditSaber, by Ikeiwa, has been modified and updated by squeksies to make **MediocreMapper**.  This is your primary method of mapping custom lights/notes.

You can get it [here](https://github.com/squeaksies/MediocreMapper).

# Lightmap Events

ChromaToggle is capable of enabling more lighting options, as well as doing other crazy lighting stuff.
Note that specially-coloured lighting is available no matter what gamemode, and specially-coloured lightmaps can be designed to work well with AND without ChromaToggle installed.

Note that currently **only the RGB event is enabled in MediocreMapper**.  The below info is *technobabble* - in other words, if you're interested in other features and/or JSON event data, this is for you.  If you want to just use the mapper to place stuff, use MediocreMapper's guide!

## Colour Events
Colour Events are the meat and bones of ChromaToggle.  These events store two colours (in the case of RGB events, it stores two copies of the same colour).  On their own, they manipulate the track lighting.  However, they are also used to store variables for "Data Events".

When used without a data event, they will recolour all future lights on that track.  For example, if you place a "Alternate Lights" custom event, future blue events will be green, and future red events will be magenta.

### Colour Event Types
* RGB
  * ID: >2000000000
    * You can use [this tool](https://cdn.discordapp.com/attachments/500829371549089793/500851384069914664/ChromaToggleRGBFinder.exe) to get the ID you want.
  * A = RGB colour selected (recommended to use MediocreMapper for this)
  * B = Copy of A
* Reset
  * ID: 1900000001
  * A = Player Set Light A (Default blue)
  * B = Player Set Light B (Default red)
* Alternate Lights
  * ID: 1900000002
  * A = Player Set Alt Light A (Default green)
  * B = Player Set Alt Light B (Default magenta)
* White Lights
  * ID: 1900000003
  * A = Player Set White (Default white)
  * B = Player Set Half White (Default half-strength white)
* Technicolour
  * ID: 1900000004
  * A = Random Colour from player's Technicolour A palette
  * B = Random Colour from player's Technicolour B palette
* Pure Random
  * ID: 1900000004
  * A = Purely random colour.
  * B = Purely random colour.

## Data Events
Data Events require a Colour Event to be placed before them, as they utilize the values stored within the Colour Event to perform their bidding.

**IMPORTANT:** Remember, in Unity, and therefore Beat Saber, colours use 0-1 values, not 0-255 values.  Data Events go by these rules.  Therefore, if you choose 255,0,0 for a Red colour. the Data event will read this as 1,0,0.  Basically, divide your colour values by 255 to get the raw data value used.

Also remember Colour Events store two colours, A and B.  Each colour has an r, g, and b value.  These values are 0-1.
For example, if you make an RGB event of the colour (255,128,0), it has these values (remember RGB events set both colours the same):
A.r = 1, A.g = 0.5, A.b = 0
B.r = 1, B.g = 0.5, B.b = 0

**You can also use [this calculator](https://www.desmos.com/calculator/awukx1rdpr) to find the values you desire.**

### Data Event Types
* Note Scale Event
  * ID: 1950000001
  * A = Sets all future spawned notes to (A.r * 1.5) * 100%
    * Minimum value of 0%
    * Maximum value of 150%
    * Default value of 100% (RGB 170)
* Health Event
  * ID: 1950000002
  * A = Changes the player's health by ((A.r - 0.5) * 2) * 100%
    * Minimum value of -100%
    * Maximum value of 100%
    * Player's full health is 100% (duh)
* Rotate Event
  * ID: 1950000003
  * A = Rotates the player around a Vector3 (x, y, z)
    * x = A.r * 360°
    * y = A.g * 360°
    * z = A.b * 360°
* Ambient Light Event
  * ID: 1950000004
  * A = Immediately changes the ambient lights to colour A
* Barrier Colour Event
  * ID: 1950000005
  * A = Immediately changes all future Barrier spawns to colour A

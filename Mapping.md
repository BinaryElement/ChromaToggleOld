# IMPORTANT:
**The mapping system is going to be overhauled with a much more powerful custom event system, and in the long run, a new mapper to handle placing them properly.**

**What this means to you is these events will be obsolete, and no longer work, soon.  With the sole exception of RGB lighting - for backwards compatibility purposes, the current RGB system is not going away (but there will still be a better one alongside it).**

**In other words: ONLY USE RGB, DO NOT USE THE OTHER EVENTS**

# MediocreMapper

EditSaber, by Ikeiwa, has been modified and updated by squeksies to make **MediocreMapper**.  This is your primary method of mapping custom lights/notes.

You can get it [here](https://github.com/squeaksies/MediocreMapper).

# Lightmap Events

ChromaToggle is capable of enabling more lighting options, as well as doing other crazy lighting stuff.
Note that specially-coloured lighting is available no matter what gamemode, and specially-coloured lightmaps can be designed to work well with AND without ChromaToggle installed.

Note that currently **only the RGB event is enabled in MediocreMapper**.  The below info is *technobabble* - in other words, if you're interested in other features and/or JSON event data, this is for you.  If you want to just use the mapper to place stuff, use MediocreMapper's guide!

MediocreMapper does have a custom event ID field, which allows you to place most of these blocks in-editor, but it requires you to know the values and where to place them.

## Colour Events
Colour Events are the meat and bones of ChromaToggle.  These events store two colours (in the case of RGB events, it stores two copies of the same colour).  On their own, they manipulate the track lighting.  However, they are also used to store variables for "Data Events".

When used without a data event, they will recolour all future lights on that track.  For example, if you place a "Alternate Lights" custom event, future blue events will be green, and future red events will be magenta.

Colour Events store two colours, an A and a B.
When used on their own, A replaces the blue lights, and B replaces the red lights.

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
  * ID: 1900000005
  * A = Purely random colour.
  * B = Purely random colour.
  
## Simple Events
Simple events are various events that perform simple tasks on their own.  They may require a specific lane, or the may be placeable anywhere, they simply use special IDs.

### Simple Event Types
* Ring Rotate Left
  * ID: 1910000000
  * Can be placed anywhere
  * Rotates the rings counter-clockwise only
* Ring Rotate Right
  * ID: 1910000001
  * Can be placed anywhere
  * Rotates the rings clockwise only
* Laser Controls
  * Reset State
    * Reset State Enabled (Default)
      * ID: 1910000002
      * When enabled, lasers will reset their position when set to speed zero, or randomize their position when changed to anything else.
    * Reset State Disabled
      * ID: 1910000003
      * When disabled, laser position will remain over speed changes, resulting in smoother less jarring transitions, as well as allowing you to freeze the laser at any position.
  * Spin Direction
    * Random Spin Direction (Default)
      * ID: 1910000004
      * Lasers will pick a random direction to spin when speed is set above zero
    * Inboard Spin Direction
      * ID: 1910000005
      * When lasers begin moving, [the higher half of the lasers will travel inboard](https://i.imgur.com/cPkjO8e.png).
        * Left lasers will travel CW, right lasers will travel CCW
    * Outboard Spin Direction
      * ID: 1910000006
      * When lasers begin moving, [the higher half of the lasers will travel outboard](https://i.imgur.com/NiaMT96.png).
        * Left lasers will travel CCW, right lasers will travel CW


## Data Events
Data Events require a Colour Event to be placed before them, as they utilize the values stored within the Colour Event to perform their bidding.

**IMPORTANT:** Remember, in Unity, and therefore Beat Saber, colours use 0-1 values, not 0-255 values.  Data Events go by these rules.  Therefore, if you choose 255,0,0 for a Red colour. the Data event will read this as 1,0,0.  Basically, divide your colour values by 255 to get the raw data value used.

Also remember Colour Events store two colours, A and B.  Each colour has an r, g, and b value.  These values are 0-1.
For example, if you make an RGB event of the colour (255,128,0), it has these values (remember RGB events set both colours the same):
A.r = 1, A.g = 0.5, A.b = 0
B.r = 1, B.g = 0.5, B.b = 0

**You can also use [this calculator](https://www.desmos.com/calculator/vok01bilbr) to find the values you desire.**

### Data Event Types
* Note Scale Event
  * ID: 1950000001
  * Applies to all notes placed after this event in the editor.
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
      * x rotation is pitching forward/back, like a plane taking off.
    * y = A.g * 360°
      * y rotation is spinning on the spot, like a plane taxiing around a bend on the ground.
    * z = A.b * 360°
      * z rotation is banking left/right, like a plane doing a corkscrew roll.
* Ambient Light Event
  * ID: 1950000004
  * A = Immediately changes the ambient lights to colour A
* Barrier Colour Event
  * ID: 1950000005
  * All barriers spawned after the position of this event will be colour A.
* Ring Speed Multiplier
  * ID: 1950000006
  * Applies to all ring rotate events in the future, including Chroma ring spin events.
  * Colour dictates the [speed multiplier of the rings](https://streamable.com/fxlse).  Colour percentages are added together.
    * A.r = 0-100%
    * A.g = 0-1,500%
    * A.b = 0-10,000%
    * Default value of 100% (A.r = 255, A.g = 0, A.b = 0)
    * Maximum Combined Value of 11,600%
* Ring Propagation Multiplier
  * ID: 1950000007
  * Applies to all ring rotate events in the future, including Chroma ring spin events.
  * Colour dictates the rate at which rings behind the first one have physics applied to them.  High value makes all rings move simultaneously, low value gives them [significant delay](https://streamable.com/vsdr9)  Colour percentages are added together.
    * A.r = 0-100%
    * A.g = 0-1,500%
    * A.b = 0-10,000%
    * Default value of 100% (A.r = 255, A.g = 0, A.b = 0)
    * Maximum Combined Value of 11,600%
* Ring Step Multiplier
  * ID: 1950000008
  * Applies to all ring rotate events in the future, including Chroma ring spin events.
  * Colour multiplies the "step" value of the rings.  I'm honestly not sure what effect this has.  Colour percentages are added together.
    * A.r = 0-100%
    * A.g = 0-1,500%
    * A.b = 0-10,000%
    * Default value of 100% (A.r = 255, A.g = 0, A.b = 0)
    * Maximum Combined Value of 11,600%

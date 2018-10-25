**[![Return to Readme](https://i.imgur.com/SkABia5.png)](https://github.com/BinaryElement/ChromaToggle/blob/master/README.md)**  **[![JOIN THE DISCORD](https://i.imgur.com/j525zt0.png)](https://discord.gg/BBntx2e)**

# Custom Game Modes

Custom Game Modes can be placed in the **UserData/ChromaToggle/CustomGamemodes** folder.  
Custom modes are composed of XML files, with a plethora of options to tweak to your hearts content.

It's recommended to start with an existing custom gamemode file to alter.  Copies of the official gamemodes (including default) come with ChromaToggle, but you can also [download the default gamemode here](https://discordapp.com/channels/488923582370545664/502961900846579732/504855424059572236).

Below is the list of possible settings for game modes:

## Info Section
![Info Section](https://i.imgur.com/puDgkp0.png)

* Internal Name
  * Required
  * No spaces, no special characters
  * This is the internal ID used by the gamemode
* Display Name
  * Required
  * Limited to 10 characters
  * This is the name the player will see
* Show In Menu
  * Required
  * true/false
  * Dictates whether the mode is visible in the in-game menu
* AllowedGameModes
  * Dictates what vanilla game mode this can be played in
  * Multiple Entries allowed

## Barrier Section [NOT YET IMPLEMENTED]
![Barrier Section](https://i.imgur.com/aNfBhCi.png)

## Colour Section
![Colour Section](https://i.imgur.com/S4e33QE.png)

* Pentachrome
  * Must be true to enable special blocks
* Monochrome
  * Forces all blocks to the same colour (blue)
* InvertColoursOnMirror
  * If mirror is enabled, all colours will be flipped
  * This plus monochrome makes all blocks red

## Map Section
![Map Section](https://i.imgur.com/VxMXtIt.png)

* AllNotesDots
  * Makes all notes dots...
* DoubleHitsDots
  * Makes all double or more hits into dot blocks
* DoubleHitsMonochrome
  * Makes all double or more hits into one colour
* DoubleHitsDuochrome
  * Ensures two colours per double hit (useful for pentachrome)
* DoubleHitsRemoved
  * Removes blocks from double hits until only one remains
* ExtendedSlashMonochrome
  * Makes extended slashes (also known as long slashes) into one colour
* ExtendedSlashRemoved
  * Cuts down extended slashes until only one block remains
* MirrorColours
  * Turns all red blocks blue and vice versa
* MirrorDirections
  * Turns all left slashes into right slashes, and vice versa
* MirrorPositions
  * Blocks on the left are now on the right, and vice versa

## Randomization Section
![Randomization Section](https://i.imgur.com/wkARoBy.png)

* AltColourRandomizationStyle
  * Sets the method used by the On-The-Fly Map Maker to add special blocks
    * 0 = None
    * 1 = Simple : Similar randomization to No Arrows Mode
    * 2 = Controlled : RECOMMENDED : Intelligently divides the map into chunks to switch colours, eradicating isolated alt notes during intense patterns. Recommended AltColourRandomizationFactor is 0.3
    * 3 = Intense : Simply randomizes by chance, but is consistent on multiple playthroughs.  Chance is equal to AltColourRandomizationFactor.  Recommended Factor is 0.5
    * 4 = True : Same as intense, except it's different each time you play.
    * 5 = Legacy Controlled : Same as simple, except all notes of the same kind on one beat are swapped.  This is the controlled randomization from version 0.4.x
* AltColourRandomizationFactor
  * Used to control the chance of randomization.  Use a decimal value - 0 is 0%, 1 is 100%
* AltColourRevertChanceFactor
  * Multiplies the AltColourRandomizationFactor by this value when reverting to standard colours for controlled mode.
* BaseColourRandomizationStyle
  * Sets the method used by the On-The-Fly Map Maker to randomize red/blue
    * 0 = None
    * 1 = Standard : Same randomization system as No Arrows Mode
    * 2 = Controlled : RECOMMENDED : Same as Standard, with an extra layer of control to make sure it's not too much.
    * 3 = Intense : Simply randomizes by chance, but is consistent on multiple playthroughs.
    * 4 = True : Same as Intense, except it's different each time you play.
* RandomDotsChance
  * Chance of a note being converted to a directionless note.  Use decimal value.
* RandomGreyBlocksChance
  * Chance of a note being converted to a grey note.  Use decimal value.
* RandomMirrorChance
  * Chance to apply mirror to a single block.  This applies MirrorColour, MirrorDirection, and MirrorPosition all at once.  Use decimal value.
* RandomMirrorDirectionChance
  * Chance to mirror the direction of a single block.  Use decimal value.
* RandomMirrorPositionChance
  * Chance to mirror the position of a single block.  Use decimal value.

## Sabers Section
![Sabers Section](https://i.imgur.com/F4o8fgD.png)
* GreyToggle
  * NOT YET IMPLEMENTED
* SaberToggle
  * Required to enable trigger up/down presses
* Saber
  * Saber declarations declare, well, a saber.  Any number of Saber fields are allowed.
  
### Saber Sub-Section
![Saber Sub-Section](https://i.imgur.com/LHKku5n.png)
* SaberType
  * Dictates what kind of saber it is.
  * A (left), B (right), ALT_A (alt_left), ALT_B (alt_right), ANY (monochrome/grey), SUPER (super/gold)
* BodyPosition
  * Dictates where the saber attaches to you.
  * LeftHand, RightHand, Head (Not Yet Implemented)
* Offset
  * Offset the saber physically from its default position.
  * x is left/right, y is up/down, z is forward/back
* Rotation
  * Similar to offset, but in rotation.
  * x is left/right, y is up/down, z is forward/back
* Scale
  * Change the size of your saber.
  * x is left/right, y is up/down, z is forward/back
* Origin
  * Extremely important
  * ANY recommended
    * A and ALT_A sabers will always use left hand, B and ALT_B will always use right, and other types will use any. Typically you will want to leave this as ANY, but in special cases you might need to specify LEFT or RIGHT.
* SaberMechanic
  * Multiple Fields allowed
    * FLIPPED - Inverts saber (mantis style, or bottom of darth mauls)
    * FLIPPED_IF_ALTERNATE - Inverts saber (again?) if alternateMaul is enabled in ModPrefs.
    * HIDE_BLADE - Sets blade invisible
    * HIDE_HANDLE - Sets handle invisible
    * HIDE_ORNAMENTS - Sets the shiny bits on handle invisible
    * HIDE_TRAIL - Hides the trail
    * REMOVE_HITBOX - [NOT IMPLEMENTED]
    * MIRROR_SWITCHES_HAND - When mirror enabled, BodyPosition setting will switch from LeftHand to RightHand (and vice versa)
    * MIRROR_SWITCHES_TYPE - When mirror enabled, SaberType setting will switch from A/ALT_A to B/ALT_B (and vice versa)
    * TRIGGER_DOWN_DISABLED - Saber is disabled when the trigger is held (requires SaberToggle true)
    * TRIGGER_UP_DISABLED - Saber is disabled when the trigger is not held (requires SaberToggle true).  Also used to disable saber by default.
    * TRIGGER_INVERTED_IF_ALTERNATE - If alternateToggle is enabled in ModPrefs, DOWN and UP are switched.

## Scale Section
![Scale Section](https://i.imgur.com/orwFHEr.png)
* BombStartingSize
  * Global scale for bombs
* NoteStartingSize
  * Global scale for notes
* NoteComboScaleFactor
  * NOT FULLY IMPLEMENTED
  * Notes will shrink/grow based on your combo

## Score Section [NOT YET IMPLEMENTED]
![Score Section](https://i.imgur.com/v3neKKW.png)

## Powerups Section
![Powerups Section](https://i.imgur.com/uLnySCE.png)
* PowerupsEnabled
  * Required for powerups (duh)
* ChargePowerSpark
  * Charge gained per second while clashing the sabers together
* ChargeWallSpark
  * NOT YET IMPLEMENTED
* ChargeCutAccuracy
  * Factor for accuracy bonus charging your powerups.
* ChargeLossOnComboDrop
  * How much charge is lost when dropping combo
* Powerup
  * Multiple entries allowed
  * Defines the list of possibly obtainable powerups
  * See [Powerups](https://github.com/BinaryElement/ChromaToggle/blob/master/Powerups.md)

## Special Section
![Special Section](https://i.imgur.com/M7Qy9x0.png)
* Nightmare
  * Enables nightmare mode (ambiance and lightning-on-grey-notes)
* RequiresWaiver
  * If set to true, the end-user must have agreed to the safety waiver.

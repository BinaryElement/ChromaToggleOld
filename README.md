# READ EVERYTHING UP UNTIL AND INCLUDING THE GAMEMODE SETTING

# [JOIN THE DISCORD](https://discord.gg/BBntx2e)

# ChromaToggle v0.5
### "The Technicolor Phase"

This is an even less early version of ChromaToggle.

[Download it from the releases page.](https://github.com/BinaryElement/ChromaToggle/releases)

IMPORTANT: GameMode is the main method of setting, well, the game mode.  This now works in any game mode, even no arrows and single saber (assuming the gamemode is applicable).  However, leaderboards will not show or upload for any modes that do not have them enabled.  Below is a list of active leaderboards:

**Active Leaderboards:**
* Forced Single Saber

## Settings

All the settings can be found in the standard ModPrefs ini file.  After changing the ModPrefs settings, you can press backslash ( \\ ) while the game is focused to reload the settings without rebooting Beat Saber.  You will hear a sound to indicate a successful reload of settings.  This sound was definitely not stolen from Discord.  Nope.

You can also reload by pressing the menu button on the right vive controller while in the main menu.

For true/false options, the numbers 1 and 0 will be used.  
*1 = true*  
*0 = false*  

**GameMode, when set above zero, will handle all the other settings for you.**  Most other settings are for if you want to make your own custom mode out of sub-features.  To do this, set GameMode to zero, and play in party mode.

**triggerThreshold is now changed in-game via the Gameplay Options menu**
### triggerThreshold (0-1, or -1) [IMPORTANT FOR OCULUS USERS]  
**Default: -1 or 0.8f**  
This changes the control scheme for toggle modes.  
* When set to -1, toggle when occur when "clicking the trigger".  This only works for Vive.  
* When set to a number between 0 (exclusive) and 1 (inclusive), the toggle will occur at that percentage press of the trigger.  For example, 0.8 will make the toggle happen when the trigger is half pressed.

**GameMode is now changed in-game via the Gameplay Options menu**
### GameMode (0-8)  

* **0 = None/Party**
  * Leaderboard Enabled: **N/A**
  * Description:
    * Standard gameplay, while in Solo Standard.
    * Standard gameplay by default while in Party Mode
    * Enables use of individual or multiple features from main modes in any configuration the user desires (In Party Mode)
    * No leaderboards  
* **1 = ChromaToggle**
  * Leaderboard Enabled: **FALSE**
  * Description:
    * Two Colour Game Mode.
    * Map is colour randomized (not applicable to ChromaToggle tailored maps)
    * Player can hold the trigger to change the colour of their sabers between blue/red.  
* **2 = Forced Single Saber**
  * Leaderboard Enabled: **TRUE**
  * Description:
    * One Colur Game Mode
    * Turns any two handed map into a one handed map.  Simple!
    * Disables left saber (or right if mirror).  
* **3 = Random Standard**
  * Leaderboard Enabled: **FALSE**
  * Description:
    * Two Colour Game Mode.
    * Colour randomization feature of no-arrows mode is applied.
    * Maps retain their arrows.  Don't hit yourself.  
* **4 = Single Saber ChromaToggle**
  * Leaderboard Enabled: **FALSE**
  * Description:
    * Two Colour Game Mode.
    * Combination of ChromaToggle and Forced Single Saber.
    * Effectively Forced Single Saber but with two colours.  Hold trigger to toggle.
* **5 = GreyToggle**
  * Leaderboard Enabled: **DISABLED**
  * Description:
    * Three Colour Game Mode.
    * Map is tailored.
    * Grey notes will trigger saber colour changes.  
* **6 = PentaChrome Toggle**
  * Leaderboard Enabled: **FALSE**
  * Description:
    * Five Colour Game Mode.
    * Map is alt-colour randomized.
    * Player can hold the trigger to change the colour of their sabers between standard/alt colours.
    * Grey notes are scattered throughout the map. 
* **7 = PentaChrome Maul**
  * Leaderboard Enabled: **FALSE**
  * Description:
    * Five Colour Game Mode.
    * Map is alt-colour randomized.
    * Player is provided two two-coloured Darth Maul sabers, for a total of four active colours.
    * Grey notes are scattered throughout the map.  
* **8 = Nightmare** [DISABLED - NYI]
  * Leaderboard Enabled: **FALSE**
  * Description:
    * Future gamemode.
    * No spoilers!
    * Extremely difficult.



### enableSaberToggle (true/false)  
**Default: false**  
The founding feature of ChromaToggle, the feature the plugin's name came from.  When enabled, both sabers will be blue - however, holding the trigger will turn them red!  



### alternateToggle (true/false)  
**Default: false**  
This inverts your left ChromaToggle saber, making it red by default and blue on toggle.  This is more akin to the regular game, however it makes actually *using* the toggle feature much harder to wrap your head around.  



### permanentToggle (true/false)  
**Default: false**  
Got weak fingers?  Have no fear!  You no longer have to hold the trigger to slice those red blocks!  



### enableGreyToggle (true/false) [DISABLED - NYI]  
**Default: false**  
Flips your saber over to a new colour upon hitting a grey block.  



### enableAlternateColours (true/false)  
**Default: false**  
Required for any fancy three-or-more colour modes.  



### enableRandomizedAlternateLights (true/false)  
**Default: false**  
This will enable a randomization system for Pentachrome Lighting, *but only for pentachrome gamemodes*.  Additionally, there is currently no check for maps with custom lighting events, so this setting will ruin those maps for you (this will be fixed at a later time).  



### enableOneColorMode (true/false)  
**Default: false**  
Colour blind?  Doesn't matter anymore!  This forces all blocks to be the same colour (unless stacked with other colour changing features, of course)!  This is especially useful for forcing one saber mode!  



### invertColorMode (true/false)  
**Default: false**  
Blue is lame.  Nobody likes blue.  Make everything red!  Or maybe you don't like red.  I don't know, I don't judge.  This option swaps the colour of all blocks.  'nuff said.  



### mirrorPosition (true/false)  
**Default: false**  
Mirrors the note positions without mirroring the direction or colour.  



### mirrorDirection (true/false)  
**Default: false**  
Prefer to swipe in instead of out?  Give this a try, you *monster*.  
Mirrors the direction without mirroring colour or position.  



### extendedSlashMonochrome (true/false)  
**Default: false**  
Forces all (individual) extended slash patterns to be one colour.  
Note: Only applies to base colour.  Will not apply to alt colours.  Use randomAltColoursStyle=2 to achieve monochrome extended slashes with more than two colours.  



### extendedSlashRemoved (true/false)  
**Default: false**  
Gets rid of those extended slashes people seem to want to use far too much.  



### removeDoubleHits (true/false)  
**Default: false**  
Turns all double (or more) hits into single hits.  Who'd'a thunk it??  



### enableMonoDoubles (true/false)  
**Default: false**  
Forces all double (or more) hits to all be the same colour.  Fixes a lot of, shall we say, slightly stupid patterns when randomization is enabled.  



### enableDotDoubles (true/false)  
**Default: false**  
Always dreamed of hitting eight blocks with one saber in one moment?  Well now you can!  This makes all double or greater hits all dot notes.  Especially useful for forced single saber!  



### enableAllDots (true/false)  
**Default: false**  
Turns the entire map into dots.  What do you mean "why wouldn't I just play no-arrows"?  Because this one doesn't randomize the colours!  



### randomizationStyle (0, 1, 2, 3)  
**Default: 0**  
This feature sets the colour randomization system.  We got a little crazy with this one!  
0 = None.  Zilch.  Zip.  Nada.  
1 = Simple.      - The colour randomization feature from no-arrows mode.  
2 = Controlled.  - Same as simple, except for high-intensity sections where the randomization is toned down. [USED FOR GAMEMODE 1 AND 4]  
3 = Intense.     - Makes literally each block 50/50 chance of being either colour.  
4 = True.        - True as in true random - this is the same as intense, except it will be differently randomized on each playthrough!  



### randomAltColoursStyle (0, 1, 2, 3)  
**Default: 0**  
This feature sets the colour randomization system for alternate colours (excluding grey).  We got extra crazy with this one!  
0 = None.  Zilch.  Zip.  Nada.  
1 = Simple.                - Similar randomization as no-arrows mode.  
2 = Controlled.            - Intelligently divides the map into chunks to switch colours, eradicating isolated alt notes during intense patterns. [USED FOR GAMEMODE 6 AND 7]  
3 = Intense.               - Makes literally each block 50/50 chance of being either colour.  
4 = True.                  - True as in true random - this is the same as intense, except it will be differently randomized on each playthrough!  
5 = Legacy Controlled.     - Same as simple, except all notes of the same kind on one beat are swapped.  STRONGLY RECOMMENDED OVER SIMPLE.  



### randomGreyBlocks (true/false)  
**Default: false**  
Adds in grey blocks here and there, to make your life simultaneously easier and harder.  



### randomDots (true/false)  
**Default: false**  
Randomly dot-ifies some blocks.  An interesting compromise between the guided flow of standard and the improvising-friendly no-arrows mode.  



### randomMirror (true/false)  
**Default: false**  
Randomly applies the full mirror effect to select blocks.  



### randomMirrorDirection (true/false)  
**Default: false**  
Randomly applies the mirrorDirection effect to select blocks.  



### randomMirrorPosition (true/false)  
**Default: false**  
Randomly applies the mirrorPosition effect to select blocks.  



### enableDarthMaul (true/false)  
**Default: false**  
Ever thought two sabers weren't enough?  Well now you can have four!  Don't ask where I found these sabers.  



### alternateLeftMaul (true/false)  
**Default: false**  
With maul enabled, the front saber on both hands are blue.  This will flip your left saber, making the front saber red.  



### forceSingleSaber (true/false)  
**Default: false**  
Ever thought two sabers were too many?  I'll take one off your hands.  I know a few people who want four...  



### enableMantisStyle (true/false)  
**Default: false**  
Made for those poor souls on the bottom of the planet.  Flips your sabers back around the right way up.  Or turns your darth maul sabers around.  



### darthMantisOffset (any decimal number)  
**Default: 0.25**  
Offsets your flipped sabers (mantis or the bottom part of your darth maul sabers)  



### highBarriersIgnoreRules (true/false) [DISABLED - NYI]  
**Default: false**  
Those high barrier bois are such punks!  Stay away from those rebels!  
High barriers will not follow the rules imposed on regular barriers.  



### barrierDenyCenter (true/false) [DISABLED - NYI]  
**Default: false**  
MAKE WAY, <your name> COMING THROUGH!  
Barriers that occupy both center lanes will be shrunk or moved until the problem is resolved.  



### maxBarrierLength (true/false) [DISABLED - NYI]  
**Default: -1**  
*x < 0 >> Disabled  
x = 0 >> Remove Barriers  
x > 0 >> Barrier length in song beats*  
Song too barrier intense, but don't want to actually remove them?  Shrink them!  



### maxBarrierWidth (true/false)  
**Default: -1**  
*x < 0 >> Disabled  
x = 0 >> Remove Barriers  
x > 0 >> Barrier width in lanes*  
Prevent barriers from exceeding a certain width.  
Attempts to prioritize pushing barriers to the sides and shrinking them, keeping the mid lanes open.  



### globalNoteScale (0.1-3.0)  
**Default: 1.0**  
Multiplies the size of notes by the given number.  



### comboBasedMultiplier (true/false)  [NOT YET IMPLEMENTED]
**Default: false**  
Changes the multiplier system to be more focused on getting full combos.



### comboNoteShrink (true/false)  
**Default: false**  
Notes will shrink as you rack up combo.  



### customSabersCompatibilityWorkaround (Time in seconds)  
**Default: 0.25**  
This delays the full activation of ChromaToggle in order to ensure custom sabers work properly.  The number you enter is the time in seconds for the plugin to delay itself.  If you do not use custom sabers, or you're experiencing problems with getting ChromaToggle to work properly, set this to zero for maximum reliability.  If ChromaToggle works properly, but custom sabers do not, increase this number (0.25, 0.5, and 1 are good numbers).  



### masterVolume (0-1)  
**Default: 1**  
The volume of added sound effects.  



**technicolour is now changed in-game via the Gameplay Options menu**
### technicolour (LIGHTS, BLOCKS, SABERS, OR ANY COMBINATION OF)  
**Default: OFF**  
VISUAL CHANGE ONLY  
Makes blocks, lights, sabers, or any chosen combination of the three a plethora of random colours, but they will still respect saber colours based on their "true colour".  Randomized colours will be selected from the two colour palettes (red turns into a colour from technicolourA, blue turns into a colour from technicolourB).  The default palettes are warm for A and cold for B.



### baseColourOverrideSaber (true/false)  
**Default: true**  
VISUAL CHANGE ONLY  
When disabled, your sabers will ignore custom colour rules.  



**enableHapticsOverride is now changed in-game via the Gameplay Options menu**
### enableHapticsOverride (true/false)  
**Default: false**  
ChromaToggle takes control over the haptics system.  
Fixes issues with ChromaToggle modes, but may cause problems elsewhere.  



### customHapticsDuration (0.1 - 1)  
**Default: 0.1** - Base game default  
How long your controller vibrates after interacting with a block, in seconds.  



### customHapticsStrength (0.1 - 10)  
**Default: 0.1** - Base game default  
How stronk your controller is.  
There's even a couple secret features to play with...  They're pretty dumb though.  Just saying.  


### partyOnly (true/false)  
**Default: false**  
Forces ChromaToggle not to activate in standard, no arrows, or single saber mode.  



### debugMode (true/false)    
**Default: false**  
This will basically be useless to you.  



## Custom Colour Options (RGBA)   
Change the colour of your sabers and your lights!  
Lights are given a different value for *maximum customization!*  Additionally, the lights in the base game are actually a different value than the saber/block, so to mimic vanilla Beat Saber this was necessary.  

### Blocks/Sabers (RGBA)  
**colourA=255;0;0;255** (Red Blocks) - Base Game Default  
**colourB=0;128;255;255** (Blue Blocks) - Base Game Default  
**colourAltA=255;0;255;255** (Alt Red Blocks)  
**colourAltB=0;255;0;255** (Alt Blue Blocks)  
**colourNonColoured=255;255;255;255** - (Grey Blocks)  
  
### Lighting (RGBA)  
**lightAmbient=0;192;255;255** (The menu lighting and behind-the-player lighting during songs) - Base Game Default  
**lightColourA=255;4;4;255** (Red Lights) - Base Game Default  
**lightColourB=0;192;255;255** (Blue Lights) - Base Game Default  
**lightColourAltA=255;8;255;255** (Alt Red Lights) - Pentachrome Lighting Only  
**lightColourAltB=4;255;4;255** (Alt Blue Lights) - Pentachrome Lighting Only  
**lightColourWhite=255;255;255;255** (White Lights) - Pentachrome Lighting Only  
**lightColourGrey=153;153;153;255** (Half-White Lights) - Pentachrome Lighting Only  

### Technicolour (RGBA-RGBA-RGBA-RGBA...)
Technicolour palettes use lists of colours.  Colours are declared the same way as above, however you can add multiple colours to one line by separating them with a dash (-).  Default technicolour lists are warm for A (red) and cold for B (blue).
**technicolourA** (Default 255;0;0;255-255;0;255;255-255;153;0;255-255;0;102;255)
**technicolourB** (Default 0;128;255;255-0;255;0;255-0;0;255;255-0;255;204;255)
  
### Other (RGBA)  
**laserPointerColour** - Defaults to same colour as *colourA*.  Must be added manually to change separately.  

## Safety Warning  
Certain features of ChromaToggle have some potentially "health aversive" mechanics, therefore I need you to agree to some kind of "hey I'm not liable" agreement to enable them.  Outlined below is a list of features requiring safety warning, and why they require this warning.  

**Nightmare** - Flashing lights are involved, and static lights cannot prevent them.  Therefore an epilepsy warning is required.  Don't play Nightmare if you have epilepsy.  There.  You have been warned.  
**Breaking Reality** - This one is hard to explain, but if you are even a little bit prone to VR sickness, *do not break reality*.  Each eye will see different things, and it is *extremely disorienting*.  

There.  You have now read the safety warnings.  I hope you're happy.  You enable the modes outlined above, create a *IDoReadSafetyWarnings=* option in the ModPrefs.ini file, under the [ChromaToggle] section, and set the right side of the equals sign to *ISwearIReadIt*.  
I swear to god if you just added that option without reading it, the value, or the safety warning, I will come to your house and I will stab you in technicolour.   

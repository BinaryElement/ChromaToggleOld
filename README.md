# ChromaToggle v0.4
### "Luminous"

This is an even less early version of ChromaToggle.

[Download it from the releases page.](https://github.com/BinaryElement/ChromaToggle/releases)

IMPORTANT: GameMode is the main method of setting, well, the game mode.  This works in Party Mode for all modes, and in Solo Standard for any ChromaToggle custom gamemode that has leaderboards enabled (see below).
If you set GameMode to zero (standard), you can use any configuration of custom settings while in party mode, however ChromaToggle will be completely disabled in Solo Standard.

**Active Leaderboards:**
* Forced Single Saber

## Settings

All the settings can be found in the standard ModPrefs ini file.  After changing the ModPrefs settings, you can press backslash ( \\ ) while the game is focused to reload the settings without rebooting Beat Saber.  You will hear a sound to indicate a successful reload of settings.  This sound was definitely not stolen from Discord.  Nope.

You can also reload by pressing the menu button on the right vive controller while in the main menu.

1 = true
0 = false

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

### enableAlternateColours (true/false) [CBT ONLY]
**Default: false**
Required for any fancy three-or-more colour modes.

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
2 = Controlled.  - Same as simple, except for high-intensity sections where the randomization is toned down.
3 = Intense.     - Makes literally each block 50/50 chance of being either colour.
4 = True.        - True as in true random - this is the same as intense, except it will be differently randomized on each playthrough!

### altRandomizationStyle (0, 1, 2, 3) [CBT ONLY]
**Default: 0**
This feature sets the colour randomization system for alternate colours (excluding grey).  We got extra crazy with this one!
0 = None.  Zilch.  Zip.  Nada.
1 = Simple.      - Similar randomization as no-arrows mode.
2 = Controlled.  - Same as simple, except all notes of the same kind on one beat are swapped.  STRONGLY RECOMMENDED OVER SIMPLE.
3 = Intense.     - Makes literally each block 50/50 chance of being either colour.
4 = True.        - True as in true random - this is the same as intense, except it will be differently randomized on each playthrough!

### randomGreyBlocks (true/false) [CBT ONLY]
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

### customSabersCompatibilityWorkaround (Time in seconds)
**Default: 0.25**
This delays the full activation of ChromaToggle in order to ensure custom sabers work properly.  The number you enter is the time in seconds for the plugin to delay itself.  If you do not use custom sabers, or you're experiencing problems with getting ChromaToggle to work properly, set this to zero for maximum reliability.  If ChromaToggle works properly, but custom sabers do not, increase this number (0.25, 0.5, and 1 are good numbers).

### debugMode (true/false)
**Default: false**
This will basically be useless to you.

### masterVolume (0-1)
**Default: 1**
The volume of added sound effects.

### technicolour (true/false) [CBT ONLY]
**Default: false**
VISUAL CHANGE ONLY
Makes blocks a plethora of random colours, but they will still respect saber colours based on their "true colour".
Best used with Monochrome mode.

### enableHapticsOverride (true/false)
**Default: true**
ChromaToggle takes control over the haptics system.
Fixes issues with ChromaToggle modes, but may cause problems elsewhere.

### customHapticsDuration (0.1 - 1)
**Default: 0.1** - Base game default
How long your controller vibrates after interacting with a block, in seconds.

### customHapticsStrength (0.1 - 10)
**Default: 0.1** - Base game default
How stronk your controller is.
There's even a couple secret features to play with...  They're pretty dumb though.  Just saying.

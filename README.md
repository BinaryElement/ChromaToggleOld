# ChromaToggle v0.2
### "Ridiculous"

This is a less early version of ChromaToggle.

Custom leaderboards coming soon!  They are currently disabled as I still have some tweaks to do to these modes.
Proper Oculus support is also next on my agenda, as well as in-game UI.  Once this is accomplished, ChromaToggle will be ready for proper release.

[Download it from the releases page.](https://github.com/BinaryElement/ChromaToggle/releases)

IMPORTANT: You can use any cluster of settings you like while in Party Mode.  You can use specific setting configurations in standard mode, but I don't recommend this, as this is only a thing for custom leaderboards (which are disabled, so it doesn't matter).  Basically, play in party mode!

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

### enableOneColorMode (true/false)
**Default: false**
Colour blind?  Doesn't matter anymore!  This forces all blocks to be the same colour (unless stacked with other colour changing features, of course)!  This is especially useful for forcing one saber mode!

### invertColorMode (true/false)
**Default: false**
Blue is lame.  Nobody likes blue.  Make everything red!  Or maybe you don't like red.  I don't know, I don't judge.  This option swaps the colour of all blocks.  'nuff said.

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
1 = Original.  This is the colour randomization feature from no-arrows mode.
2 = Intense.  This makes literally each block 50/50 chance of being either colour.
3 = True.  True as in true random - this is the same as intense, except it will be differently randomized on each playthrough!

### forceSingleSaber (true/false)
**Default: false**
Ever thought two sabers were too many?  I'll take one off your hands.  I know a few people who want four...

### enableDarthMaul (true/false)
**Default: false**
Ever thought two sabers weren't enough?  Well now you can have four!  Don't ask where I found these sabers.

### enableMantisStyle (true/false)
**Default: false**
Made for those poor souls on the bottom of the planet.  Flips your sabers back around the right way up.  Or turns your darth maul sabers around.

### darthMantisOffset (any decimal number)
**Default: 0.25**
Offsets your flipped sabers (mantis or the bottom part of your darth maul sabers)

### debugMode (true/false)
**Default: false**
This will basically be useless to you.

### alternateLeftMaul (true/false)
**Default: false**
With maul enabled, the front saber on both hands are blue.  This will flip your left saber, making the front saber red.

### mirrorPosition (true/false)
**Default: false**
Mirrors the note positions without mirroring the direction or colour.

### mirrorDirection (true/false)
**Default: false**
Prefer to swipe in instead of out?  Give this a try, you *monster*.
Mirrors the direction without mirroring colour or position.

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

### customSabersCompatibilityWorkaround (Time in seconds)
**Default: 0.25**
This delays the full activation of ChromaToggle in order to ensure custom sabers work properly.  The number you enter is the time in seconds for the plugin to delay itself.  If you do not use custom sabers, or you're experiencing problems with getting ChromaToggle to work properly, set this to zero for maximum reliability.  If ChromaToggle works properly, but custom sabers do not, increase this number (0.25, 0.5, and 1 are good numbers).

### masterVolume (0-1)
**Default: 1**
The volume of added sound effects.

There's even a couple secret features to play with...  They're pretty dumb though.  Just saying.

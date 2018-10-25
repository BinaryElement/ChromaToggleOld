**[Return to Readme](https://github.com/BinaryElement/ChromaToggle/blob/master/README.md)**

# Settings

Settings can be found in the standard ModPrefs ini file.  After changing the ModPrefs settings, you can press backslash ( \\ ) while the game is focused to reload the settings without rebooting Beat Saber.  You will hear a sound to indicate a successful reload of settings.  This sound was definitely not stolen from Discord.  Nope.

You can also reload by pressing the menu button on the right vive controller while in the main menu.

For true/false options, the numbers 1 and 0 will be used.  
*1 = true*  
*0 = false*  


## Settings List



### permanentToggle (true/false)  
**Default: false**  
Got weak fingers?  Have no fear!  You no longer have to hold the trigger to slice those red blocks!  



### alternateToggle (true/false)  
**Default: false**  
This inverts your left ChromaToggle saber, making it red by default and blue on toggle.  This is more akin to the regular game, however it makes actually *using* the toggle feature much harder to wrap your head around.  



### alternateMaul (true/false)  
**Default: false**  
This inverts your left Darth Maul (excluding Pentachrome Maul), making it red forward by default.  This is more akin to the regular game.



### enableMantisStyle (true/false)  
**Default: false**  
Made for those poor souls on the bottom of the planet.  Flips your sabers back around the right way up.  Or turns your darth maul sabers around.  



### darthMantisOffset (any decimal number)  
**Default: 0.25**  
Offsets your flipped sabers (mantis or the bottom part of your darth maul sabers)  



### masterVolume (0-1)  
**Default: 1**  
The volume of added sound effects.  



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
Also, Nightmare is EXTREMELY HARD.  If you're an Expert+ player, *expect to die on Hard difficulty maps.*  
**Breaking Reality** - This one is hard to explain, but if you are even a little bit prone to VR sickness, *do not break reality*.  Each eye will see different things, and it is *extremely disorienting*.  

There.  You have now read the safety warnings.  I hope you're happy.  You enable the modes outlined above, create a *IDoReadSafetyWarnings=* option in the ModPrefs.ini file, under the [ChromaToggle] section, and set the right side of the equals sign to *ISwearIReadIt*.  If you are having difficulty doing this, *DO NOT ASK FOR HELP DOING SO, BECAUSE IF YOU CANNOT BE TRUSTED TO ADD A LINE TO THE PREFERENCE FILE, YOU CANNOT BE TRUSTED WITH YOUR OWN HEALTH*.
I swear to god if you just added that option without reading it, the value, or the safety warning, I will come to your house and I will stab you in technicolour.   
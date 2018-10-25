**[![Return to Readme](https://i.imgur.com/SkABia5.png)](https://github.com/BinaryElement/ChromaToggle/blob/master/README.md)**  **[![JOIN THE DISCORD](https://i.imgur.com/j525zt0.png)](https://discord.gg/BBntx2e)**

# Powerups
![PowerupsExample](https://i.imgur.com/NIkDFq8.png)

**Features shared by all powerups:**
* DisplayName
  * The name shown to the player

## NoteOverridePowerup
Causes all notes spawned within the next **[Duration]** seconds to be a certain type
* NoteType
  * NORMAL, ALTERNATE, ANY, SUPER
* Duration
  * Decimal values allowed.
  
## SaberTypePowerup
Overrides your sabers into being a certain type
* SaberType
  * A, B, ALT_A, ALT_B, ANY, SUPER
* Duration
  * Decimal values allowed.
  
## FluxCavitatePowerup
While holding the use button, the player charges the powerup for up to 3.4 seconds (100%), but no less than 0.85 seconds (25%).
Upon activation, time is frozen for **[FreezeDuration] x PercentCharged** seconds.
After the time freeze ends, time smoothly transitions from frozen to normal over **[FadeDuration] x PercentCharged** seconds.
* FreezeDuration
  * Decimal values allowed.
* FadeDuration
  * Decimal values allowed.
  
## NukePowerup
Obliterates every block on screen, with a perfect 110 cut score.
Has multiple uses.
* InitialUses
  * How many uses the player is granted.
  * Use a whole number.
* AudioFile
  * The audio file used for the nuke's sound effect
* AudioDuck
  * If true, the nuke will silence the song briefly
  
## ShieldPowerup
*ShieldPowerup is the internal ID, the actual powerup is known as God Saber*
Summons a god saber from the heavens to block an entire column of the map for **[Duration]** seconds.
This god saber will cut all blocks it touches for a perfect 110 score.
* Duration
  * Decimal values allowed.

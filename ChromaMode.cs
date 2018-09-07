using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaToggle {

    public enum ChromaMode {

        CHROMATOGGLE,               //CT*, CTSS*, NM*
        CHROMATOGGLE_ALT,           //CT,  CTSS
        CHROMATOGGLE_PERM,          //CT,  CTSS
        DARTH_MAUL,                 
        DARTH_ALT_LEFT,
        DOUBLES_DOTS,               //CT*,   CTSS*, FSS*
        DOUBLES_MONO,               //CTSS*, FSS
        DOUBLES_REMOVED,            
        INVERT_COLOUR,              //FSS
        MANTIS,                     //CT,  CTSS, FSS, RA, NM
        MIRROR_POSITION,
        MIRROR_DIRECTION,
        MONOCHROME,                 //FSS*
        NIGHTMARE,
        NO_ARROWS,                  
        RANDOM_COLOURS_CHROMA,      //CT*, CTSS*
        RANDOM_COLOURS_INTENSE,
        RANDOM_COLOURS_ORIGINAL,    //RA*
        RANDOM_COLOURS_TRUE,
        RANDOM_DOTS,                //NM*
        RANDOM_MIRROR,              //NM*
        RANDOM_MIRROR_DIRECTION,    //NM*
        RANDOM_MIRROR_POSITION,     //NM*
        RANDOM_SABERS,              
        RANDOM_NIGHTMARE_SABERS,    //NM*
        SINGLE_SABER,               //CTSS*, FSS*

    }

    /*
    
    ChromaToggle Leaderboard
    Forced Options:
        -ChromaToggle
        -Doubles Dots
        -Random Colours (Chroma), not applicable if map is made for ChromaToggle
    Optional:
        -Alternate Toggle
        -Permanent Toggle
        -Mantis

    Single Saber Leaderboard
    Forced Options:
        -Single Saber
        -Doubles Dots
        -Monochrome
    Optional:
        -Mantis
        -Invert Colours
        -Doubles Mono (does nothing, but that means no reason to disallow it)

    ChromaToggle Single Saber Leaderboard
    Forced Options:
        -ChromaToggle
        -Single Saber
        -Doubles Dots
        -Mono Doubles
        -Random Colours (Chroma)
    Optional:
        -Alternate Toggle
        -Permanent Toggle
        -Mantis

    Random Arrows Leaderboard
    Forced Options:
        -Random Colours (Original)
    Optional:
        -Mantis

    Nightmare Leaderboard
    Forced Options:
        -ChromaToggle
        -Random Dots
        -Random Mirror
        -Random Mirror Direction
        -Random Mirror Position
        -Random Nightmare Sabers


    */
}

# Dinkum Auto Save

I wrote this mod to allow to automatically save at a give time interval.

This has been helpful if you have been finding that you have disconnection issues from time to time or power issues for example. You will lose a lot less of your day with autosave. So if that is this is something that you have an issues with this mod could help.
>>>>>>> c292d53 (chore: create readme)
The application comes with a few option that can be configured within the configuration file that is generated after the first run of Dinkem with the mod installed.

## Default Hotkeys
`F11` - Toggle Autosave\
`F12` - Save Immediately


By default the tool is enabled and automatically saves at `5 minute` intervals.

A configuration file is created after the first run. 

This file can be found in the `/bepinex/config` folder. The name will match the plugins name as well.

## Installation:

BepInEx needs to be installed. 
- https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.1
- https://docs.bepinex.dev/articles/user_guide/installation/index.html

The unzipped files should be stored in the `/bepinex/plugins` folder located inside of your game installation directory.

Note: In some rooms the autosave feature will not complete. Leaving the room will resolve that.
I am not responsible for any save issues you may have from this. I haven't had any issues and have tested it with a few of my friends, but this is just something I threw together to help my friends.


## Build

A guide for environment Setup for building a plugin in BepInEx is here:
https://docs.bepinex.dev/articles/dev_guide/plugin_tutorial/1_setup.html

You'll need to setup a .NET Environement details in the guide above.

`dotnet build` - To build once environrment is setup.
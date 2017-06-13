PiARno

EE267 Final Project Spring 2017
Author:
Yijun ZHou
yjz@stanford.edu
Yinghao Xu
ericx@stanford.edu


Prerequisites:
——Softaware:
1. Windows 10
2. Visual Studio 2017
3. Unity5.5.1p4 for windows
4. UWP SDK10.0.14393.0
5. Vuforia 6.1
6. Garageband for Mac OSX
——Hardware:
7. AXIOM25 Keyboard
8. Hololens

To build the app:
1. Launch the Unity, select the File in the menu bar;
2. Click Build Setting…;
3. Load playScene to the Scene to Build;
4. Make the settings like this: Platform: Windows Store, SDK: Universal 10, Target device: Hololens, UWP Build Type: D3D, UWP SDK: 10.0.14393.0, Build and run on: Local Machine
5. Select a folder to build the solution.

To launch the app in the Hololens:
0. Connect the Hololens to the PC with USB;
1. Open the building target folder set before;
2. Open the PiARno2.sln with Visual Studio 2017;
3. Make the settings like this: Solution Configuration: Release, Solution Platforms: x86, Emulator: Device
4. Start building.

To launch the keyboard:
1. Connect AXIOM25 to the Mac with USB;
2. Launch the Garageband file to receive the midi from the keyboard;
3. Change the IP Address in the python code to specify the address of the Hololens;
4. Run the python code to send key stroke info to Hololens;

To play with it:
1. Launch the PiARno2 in the Hololens;
2. Take a look at the logo of the keyboard to locate and recognize it;
3. You Rock! Press the key where the little monster is jumping.


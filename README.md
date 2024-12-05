# MinesweepAR User Manual
## Introduction
_MinesweepAR_ is a minesweeper game that was integrated with augmented reality. A classic is brought to life in a different reality, upgrading its experience and playability to players.

## Installation
There are two ways to install the application:
* Download and Install the APK file
* Build and Run through Unity Editor

### Download and Install the APK file
Access the google drive link to download the [APK file](https://drive.google.com/file/d/1YToO7PYNcgT6mjKDhfXkuxGQz7TYAmTf/view?usp=sharing).

### Build and Run through Unity Editor
#### Prerequisites:
* Unity Hub installed 2023.x version
  * Android SDK & NDK tools installed
* OpenJDK installed
* An Android Device (preferably android version 14)

1. Download the zip file via the GitHub Link: https://github.com/S1ngSOng/ARVR100-MCO1
   - (Press Code -> Download Zip) Then extract it to your drive
3. Launch Unity Hub, Press Add (Add Project from disk), locate and add the extracted folder then open it.
4. While launching, connect your phone to your device.
    - Make sure developer options is enabled on your device, which can be done by tapping the OS version of your phone 6 times.
    - Once done, locate the developer options page in settings and turn USB debugging on.
7. Once the project has loaded on your computer, go to file and build settings, then on the left side bar, select Android and switch platform
8. Change the default device to your phone then hit build and run.
9. Once done, the game should automatically launch.

## Getting Started
After opening the application, you will be greeted with a main menu. There are two buttons present, <ins>PLAY</ins> or <ins>Multiplayer</ins>. 

### Play Button
Clicking this button will launch you to the game as Single Player mode. 

### Multiplayer Button
Clicking this button will bring you the connection menu for multiplayer. If there no current room open, your device will open and host a room automatically and will wait for another device to connect to your room. Once there are two devices are connected to a room, the host,11 will be able to launch the game for both devices.

### Placing the Game Board
Once the game has launched, the device's camera will open and start scanning for planes to place the board on. Once plane outlines have been scanned, it is up to the host to place the board on a plane to start the game.

## Basic Controls
* Tap on a plane to place the game board.
* Tap a tile on the board to reveal its contents.

## Troubleshooting

### Unity not recognizing your device
* Ensure your phone is in developer mode with USB debugging on.

### App is not interacting/responding 
* Try resetting the application.

### Board not being placed
* Try to stay in a bright environment for the camera to be able to any horizaontal planes.

### The board is moving/drifting 
* Reset the app and try holding the phone steadily when placing the board.
* Refrain from moving the camera too much.

### Board too big
* Try placing the board nearer to your feet.

### My game is not connecting to the room with my friend
* Make sure your phone is connected to the same network as your friend’s device.
* Make sure your phone is connected to the photon network. This will be done automatically and is indicated by how many players there are in your current room.
* If no number shows up, press the back button and wait for a few seconds before clicking the multiplayer button again.

## Contact Information
If there any more issues, kindly contact any of the following people:
* Shaun Ong - shaun_ong@dlsu.edu.ph
* Pierce Hokia - pierce_zachary_hokia@dlsu.edu.ph 
* Gerald Belardo - gerald_belardo@dlsu.edu.ph
* Simone Capio - simone_franceska_capio@dlsu.edu.ph 


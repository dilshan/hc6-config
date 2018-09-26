# hc6-config
This is simple .net framework based application to configure HC-06 bluetooth module paramaters. This utility can edit following parameters of the bluetooth module:
- Bluetooth display name
- Pair password
- BAUD rate
- Parity check type
## Building and usage
hc6-config binaries are available to download at [release](https://github.com/dilshan/hc6-config/releases) section of this page.

If you plan to compile this project use Microsoft .net framework 4.5 and Visual Studio 2012 or newer version. This application uses standard .net framework classes and does not require any additional 3rd party libraries. 
## Hardware setup
This application communicates with HC-06 module through COM port. To emulate the COM port use any Windows compatible USB to Serial converter. While at the testing we try following modules with this application:
- FTDI FT232 USB to Serial module
- CH340 USB to Serial module
- CP2102 USB to Serial module

If you are not familiar with the HC-06 Bluetooth module it's highly recommended to refer HC-06 datasheet first.


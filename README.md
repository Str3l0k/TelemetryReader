# Telemetry Reader
The all in one solution for reading, processing and transmitting telemetry for Sim-Racing.

## Games
The games module includes necessary information about the games supported.
This includes some declared identifiers for every game and their known process-names.
Also included are structures for most games, which are used to convert raw byte data into
a easy-to-use format.

## Library

### 1. Read data

### 2. Process data

### 3. Telemetry Protocol
The included protocol is aimed to ease the access to specific telemetry values without having
to implement the data conversion yourself.
The whole protocol consists of two main functions.
* Conversion of game specific structures into ID-based value datapool
* Package selected values for transmit

#### 3.1. Value IDs
Every defined value has a unique 16-bit (2-byte) unsigned integer als identifier.
As 16-bit enable 65536 different values, this should be more than enough to include 
all available information from many different racing simulations.

##### 3.1.1 ID Ranges
The IDs are divided into five different main categories:

- Connection (0 - 511)
- Car (512 - 10399)
- Driver (10400 - 13471)
- Session (13472 - 16383)
- Opponents (16384 - 65535)

The Connection category is the smallest (512 values), as it is mainly to add non-game values to the protocol, 
like packet number or similar control values.
The most important and second largest category (9887 values) is for anything 
related to the car of the actual driver/player.
Data about the driver himself, which includes timing and control input is almost the same size
than the session category (both inlcude around 3000 possible IDs).
The opponents category is based on the assumption that the maximum number of cars is 128.
Therefore for every single opponent there are 384 different IDs to use for values regarding a single opponent.

##### 3.1.2 Value classes
The categories car, driver and session are divided into some classes, which
might have additional sub-classes.
These are primarily aimed for better structuring and not essential.
The protocol-datapool uses interfaces based on this structure to reflect classes
and sub-classes for easy access without having to know specific value IDs.

## Application
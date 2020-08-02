# MarsRover

### Usage ###
Add the rover instructions to the Instructions.txt file and then run the program.

Example instructions
```
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```

Rover output
```
1 3 N
5 1 E
```

### Design ###
The functionality for the Mars Rover is split into two different parts. The Rover class is responsible for simple individual Rover actions such as keeping track of the current position and direction, turning left or right, and getting the new position after moving. The RoverController is responsible for keeping track of the size of the plateau, parsing and validating the NASA instructions, and issuing the validated commands to the rovers. There is basic unit test coverage for both of these classes.

### Validation ###
Specific validation requirements were not given so here is the list of validations I chose to implement. Output will be included to alert the user if any validation issues were encountered.
* If the plateau bounds are invalid, an InvalidDataException is thrown and the rest of the instructions are not completed
* If either a rover's start position or command set is invalid, then all of that rover's commands are skipped and instructions continue with the next rover
* If a move command is issued that will cause a rover to move out of bounds of the plateau, the command is skipped and instructions continue with the next command for that rover

### Assumptions ###
In addition to the above validations I assumed that the instructions could never be missing a line or have an extra line. The way each line is parsed is strictly based on it's position. It is also assumed that the rover's given start position is accurate.

# Codec.Console

This is a project that helps a robot to walk on Mars.

# Technologies
.Net 6.0
Console Application

## Installation

Get from github.

```bash
gh repo clone fneto3/Robot.Console
```

## Usage

```csharp
Create a reference to Codec.Library

# Create the 'Robot'
var robot = new Robot();

# Pass the size of plateau as 'NumberxNumber' and movements
var finalPosition = robot.Move(plateauSize, movements);

# Get final positions and facing
return String.Format("{0},{1},{2}", finalPosition.x, finalPosition.y, finalPosition.Facing.ToString());
```

## Unit Test
Unit test are using DataTestMethod to create different inputs for each test case.

The tests are:

#### Same Direction
Move the robot always in the same direction and check if the facing are correct.
```csharp
void Move_AlwaysForwardSameDirection_SameFacing(string movements, FacingDirection expected);
```

#### Move front and come back
Move x steps to front on Axis y, turn around and move x steps back to start position.
```csharp
void Move_GoFrontAndReturnSamePositionYAxis_StartPositionOfYAxis(string movements);
```

Move x steps to front on Axis x, turn around and move x steps back to start position.
```csharp
void Move_GoFrontAndReturnSamePositionXAxis_StartPositionOfXAxis(string movements);
```

#### 1x1 plateau
The plateau is 1x1 size, the robot need to ignore all movements.
```csharp
void Move_IgnoreAllMovementsInPlateau1x1_Position1(string movements);
```
#### Square
Moving in a square.
```csharp
void Move_WalkingInASquare_Position1(string movements);
```

#### Go outside
Try to move outside of plateau.
```csharp
void Move_GoOutOfPlateau_IgnoreMovementsReturnInitialPosition(string movements);
```

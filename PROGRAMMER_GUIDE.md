# Programmer guide

This is a guide for anyone looking to dig into how this piece of software is made.

## Table of Contents
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)

## Getting Started

### Prerequisites

- Download Visual Studio with support for .NET Framework 4.7.2

### Installation

Follow these steps to set up and run the project on your local machine:

1. Clone the project onto your local machine `git clone https://github.com/dynamo58/modified-gol.git`.
2. Open the solution file `new.sln` in Visual Studio.
3. Download the `Newtonsoft.json`, `AnimatedGif` and `MSTest` packages with NuGet (or via `dotnet restore`).

## Usage

The solution includes two projects `new` - which is program itself and `tests`, which is a seperate project that holds all the tests.

All of the actual C# code is location in the `new` subfolder. There are some auto-generated files by Visual Studio for some reason, the only files that should really be tampered with are:
- `Program.cs`
- `MainWindow.cs`
- `Simulation.cs`
- `Organism.cs`

### Dissection of the code

The entire project has only two namespaces: `modified_gol` and `tests`. Each of those is a special namespace for the belonging project. They are not further divided.

#### `Program.cs`

This is the entrypoint of the application as governed by the Windows Forms framework. The Winforms boilerplate gives it its class `Program` along with the function `Main()`, which starts the application. There are 2 additional things: the `_rand` property. It is an instance of `Random` and is used in the entire program for generating (pseudo)random values. There is one extra class: `Utils`. It includes all of the miscellaneous functions that *just do not fit* anywhere else.

#### `MainWindow.cs`

One of the things the `Main()` function does is start an instance of `MainWindow`. That is the sole class of the `MainWindow.cs` file. This file combines the logic with the UI and forms a bridge to gap those two. This class has 4 attributes:
- `sim` - the corresponding `Simulation` instance of the program,
- `recording` - boolean indicating whether the simulation is currently being recorded or not,
- `gif` - nullable instance of `AnimatedGif.AnimatedGifCreator` for burning images onto the GIF when recording,
- `framerate` - FPS when recording; set to 4 by default.

First the functions that arent called from the UI:
- `UpdateEntireUIFromSimulation()` - here and there it is useful to update everything in the UI that is dependant on the parameters of `sim`
- `WriteCellsToGif()` - translates the cells panel into a form that is can be burnt to a GIF

... all the others basically respond to a UI action and update something or call some function of `sim`. To see which UI component does what, check the [user guide](./USER_DOCUMENTATION.md).

#### `Simulation.cs`

`Simulation.cs` has all of the actual logic governing how the simulation works. It has two classes. 

`Cell` is sort of like a helper class to be able to represent, whether a cell within the simulation has some organism present or not.
The `Simulation` class is the real deal. Its attributes are:
- `boardSize` - integer denoting the width of the cells panel,
- `cells` - a `boardSize` x `boardSize` square of instances of the `Cell` class,
- `speed` the FPS for when the simulation is being automatically generated,
- `randomizationFactor` -  when the cell randomization button is pressed, whats the chance of each cell to turn int a healthy org.,
- `generationCount` - current number of generations since last edit,
- `newCellBeBornConds` - possible amounts of neighbors for an empty cell to become a new org.,
- `surviveConds` - possible amounts of neighbors for a healthy cell to survive,
- `incubationPeriod` - how long it takes an infected cell to heal/aggressify,
- `chanceOfInfectedHealing` - chance that an infected org. heals at the end of its incubation period,
- `sporadicInfectionChance` - chance that a healthy cell will randomly get infected during a single generation,
- `hungerStrikeThreshold` - how many generations it takes an aggressive cell to die without food.

Now onto the functions of `Simulation`:
- `Resize()` - changes the size of the board,
- `Clean()` - makes the entire board into dead cells,
- `GetHealthyNeighborCount()` - returns and integer indicating how many healthy neighbors a given cell has,
- `UnagressiveNeighbors()` - yields all of the position of unaggressive neighbors of a given cell one-by-one,
- `AdvanceGeneration()` - computes everything needed to get the new board - the next iteration,
- `ChangeCellState()` - changes the state of a given cell to a desired on,
- `RandomizeCells()` - makes all cells either dead or alive and healthy according to the given % factor,
- `HandleUserAction()` - includes everything that has to be done each time the user updates the configuration,
- `ToJSON()` - used to serialize the entire `Simulation` instance object to string,
- `DeserializeFromFile()` - used to parse a file into a `Simulation` instance object.

#### `Organism.cs`

The sole carrier of this file is the abstract `Organism` class serving as a template for all of the possible states a cell organism can be in. This abstract class has a single attribute:
- `kind` - an en of type `Kind` - *ad hoc* enumeration used to indicate which state it is in,

Onto the functions:
- `DecideNextState()` - different states of the organism need different logic for how to decide the next state,
- `DecideEmptyCellNextState()` - this one is non-abstract for the empty cells,
- `FromStr()` - returns a new organism, the state of which is deduced based on a string,
- `GetBrush()` - returns an instance of `System.Drawing.Brush` based on which color is to be used when drawing the organism in the UI.

The classes inheriting from `Organism` are:
- `HealthyOrganism` - represents a healthy cell, has no additional attributes,
- `InfectedOrganism` - represents an organism that is transitioning from being healthy to `AggresiveOrganism` or dying,
  - `currentDaysIncubating` - how many days has the cell been infected,
- `AggressiveOrganism` - represents an organism that has become aggressive after getting infected (which means that it eats surrounding cells),
  - `currentHungerStrike` - how many days has it been that the organism has not eaten anything (when it reaches the the set threshold, it dies).

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them with clear and concise messages.
4. Push your changes to your fork.
5. Open a pull request and describe your changes.

The pull request should have the basic following outline
1. WHY
2. WHAT
3. HOW

Your pull request will be automatically tested with Github Actions. If it adds some significant logic, also add tests for it.

For any other questions or inquiries, open an issue.

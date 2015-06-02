# Setup instructions
This repo does not contain the game's solution, but rather the source and content files of the game. In order to use these files you'll need to start a local project and import these files.

### Namespaces
The files in this repo are all within the `Ratcycle` namespace. If you name the solution something different you will need to change the namespace in `Game1.cs` to the namespace of your solution. You will also need to prepend the `Ratcycle` namespace to the `World` class in `Game1.cs`

## Xamarin (Mac OS)

1. Create a new Monogame (MonoMac) solution. 
2. Go to the solution folder.
3. Remove `Game1.cs` from the folder.
4. Clone this repo to the solution folder as `GameFiles`.
5. In Xamarin, add the `GameFiles` folder to the project using the solution sidebar.


>Alternatively it's possible to clone this repo outside of the solution directory. When adding the folder at step 5 select `Link` in stead of `Copy` or `Move`.


### Terminal example
```
$ cd ~/Projects/ProjectName/SolutionName
$ rm Game1.cs
$ git clone https://github.com/evil-moustachio/Ratcycle.git GameFiles
```


## Visual Studio

1. Create a new Monogame (Windows) solution.
2. Go to the solution folder.
3. Remove `Game1.cs` from the folder.
4. Clone this repo to the solution folder as `GameFiles`.
5. In Visual Studio create add all the files in `GameFiles` to the project.

# Project Structure
```
Project                                   // Project folder created by IDE
├── Solution                              // Solution folder created by IDE
│   └── GameFiles                         // This repo
│       ├── Content                       // For all content files
│       └── src                           // For all source files
│           ├── Game1.cs                  // Part of MonoGame framework
│           ├── World.cs                  // Manages the game
│           ├── Model.cs                  // Holds relevant data
│           ├── Player.cs                 // Handles the player's input
│           ├── Views                     // Directory for all view classes
│           │   ├── ViewController.cs     // Manages views
│           │   ├── View.cs
│           │   ├── Menu.cs
│           │   └── Stage.cs
│           ├── Entities                   // Directory for all entity classes
│           │   ├── Entity.cs
│           │   ├── Rat.cs
│           │   ├── Enemy.cs
│           │   ├── Trash.cs
│           │   └── TrashCan.cs
│           └── UIElements                 // Directory for all ui element classes
│               ├── UIElement.cs
│               ├── Button.cs
│               └── Bar.cs
```

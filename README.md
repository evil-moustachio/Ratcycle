# Setup instructions
This repo does not contain the game's solution, but rather the source and content files of the game. In order to use these files you'll need to start a local project and import these files.

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

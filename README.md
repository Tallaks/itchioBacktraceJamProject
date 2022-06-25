# itchioBacktraceJamProject
## Team
- [Tallaks](https://github.com/Tallaks) as programmer
- [DebabratDas1](https://github.com/DebabratDas1) as programmer
- [QreatureZhong](https://github.com/QreatureZhong) as 2d artist
## About Jam
You can find all information about jam [here](https://itch.io/jam/gamejam-4-by-backtrace)
## About Game
For now it doesn not have title, but it has some concept. According to the jame theme **No Violence** we've decided to make a game about guys that are helping people that met the violence during wars, local military conflicts, epidemies, etc. I am talking about humanitarian movements like Red Cross. Their goal is to help people, suffering from deaths, wounds, illness and hunger. They heal the world trembling from violence.

In this game you are playng as a pilot, driving сargo airplane that drops the humanitarian aid to refugees camps, cities, etc. The flight is risky, the weather si not very good, pirates and bandits are trying to damage your plane and steal your cargo. The more camps you help, the more score points you get. 
## Code Structure
### Architecture layers
Code base is divided into 4 layers:

**Infrastructure** - initializers, services, factories and state machine. Unites other layers

**Gameplay** - all gameplay Monobehaviours around player, obstacle, particles, animation

**Application** - components, that are connected to gameplay, but not being it's part. For example, music, high scores, working with data

**UI** - user interface, buttons, panels and mediator, that controls every user action with UI elements
### Entry point
To make everything working you need to open the _BootScene_. There placed a Bootstrapper component where starts state machine from the Bootstrap State. In this state we register all required services and then we load the _MainMenu_ scene.

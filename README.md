# 3D FPS Game - Unity Project

A beginner-friendly First-Person Shooter built with Unity and C#. This project includes core FPS mechanics ready to expand.

## Project Structure

```
Assets/
├── Scripts/
│   ├── PlayerMovement.cs       # WASD movement, mouse look, jumping
│   ├── WeaponController.cs     # Raycast shooting system
│   ├── EnemyAI.cs              # Enemy chase and attack behavior
│   ├── PlayerHealth.cs         # Player health and damage
│   └── GameManager.cs          # Score and game state
└── Prefabs/                    # (Create prefabs here after setup)
```

## Quick Start in Unity

### 1. Create a New Unity Project
- Open **Unity Hub**
- Create new **3D URP Project** (or Built-in Render Pipeline)
- Name it `3D-FPS-Game`

### 2. Add These Scripts to Your Project
- Create folder: `Assets/Scripts/`
- Copy all `.cs` files from this repo into `Assets/Scripts/`

### 3. Set Up the Player
1. Create empty GameObject: `Player`
   - Tag it as "Player" (create the tag in Inspector)
   - Add Component: **CharacterController**
   - Add Component: **PlayerMovement** script
   - Add Component: **PlayerHealth** script

2. Create child Camera:
   - Right-click `Player` → 3D Object → Camera
   - Rename to `MainCamera`
   - Set Position to (0, 0.8, 0)
   - Delete the old `MainCamera` from scene

3. Add Weapon:
   - Right-click `Player` → Create Empty → `WeaponSlot`
   - Add **WeaponController** script
   - In WeaponController Inspector, drag `MainCamera` into "Player Camera"
   - Set Hit Mask to "Enemy" layer (or "Default" for testing)

### 4. Set Up an Enemy
1. Create empty GameObject: `Enemy`
   - Add Component: **CharacterController**
   - Add Component: **EnemyAI** script
   - Add a child Mesh (3D Object → Cube, color it red)

2. Create Layer "Enemy":
   - Select Enemy → Layer dropdown → "Add Layer" → name it "Enemy"
   - Set Enemy to this layer

3. Duplicate the Enemy a few times around the scene

### 5. Set Up GameManager
1. Create empty GameObject: `GameManager`
2. Add **GameManager** script

### 6. Build the Level
- Create a floor: 3D Object → Plane, scale it (10, 1, 10)
- Add walls to contain the action
- Add some obstacles

### 7. Test It!
- Press **Play**
- Move with **WASD**, look with **Mouse**, jump with **Space**
- Click **Left Mouse** to shoot enemies
- Enemies chase and attack you
- Score increases when enemies die

## Building in Visual Studio

### Option A: Edit Scripts in Visual Studio
1. In Unity, go to **Edit** → **Preferences** → **External Tools**
2. Set "External Script Editor" to **Visual Studio 2022** (or your version)
3. Double-click any script in the Project window
4. Visual Studio opens automatically
5. Edit, save (Ctrl+S), and Unity hot-reloads

### Option B: Open Unity Project in Visual Studio
1. File → Open → Project/Solution
2. Navigate to your Unity project folder
3. Open the `.sln` file (Visual Studio Solution)
4. You can now browse and edit all scripts
5. Save changes → return to Unity to see them applied

## Next Steps to Expand
- [ ] Add enemy spawn waves
- [ ] Add UI for health and score
- [ ] Add ammo/magazine system
- [ ] Add sound effects and muzzle flash
- [ ] Add level progression
- [ ] Add main menu and pause menu
- [ ] Add more enemy types
- [ ] Add power-ups

## Controls
- **WASD** - Move
- **Space** - Jump
- **Mouse** - Look around
- **Left Click** - Shoot
- **Shift** - Sprint

## Troubleshooting
- Enemies not moving? Make sure they're not inside walls
- Shooting doesn't work? Check the WeaponController's Hit Mask setting
- Player falls through floor? Add a Collider to the floor
- Scripts have errors? Make sure all scripts are in `Assets/Scripts/` folder

## Resources
- [Unity Learning](https://learn.unity.com/)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [GDC Game Talks](https://gdcvault.com/) - Learn from industry pros

# ApexRush Racing — Project Structure

```
Assets/
  Art/
    Cars/
    Environments/
    Characters/
    VFX/
  Audio/
    Music/
    SFX/
    Engines/
  Data/
    Cars/
    Tracks/
    Economy/
    Challenges/
  Materials/
  Prefabs/
    Cars/
    UI/
    Props/
    Police/
  Scenes/
    Bootstrap.unity
    MainMenu.unity
    Garage.unity
    City.unity
    Desert.unity
    Mountains.unity
    Snow.unity
    Highway.unity
    HarborNight.unity
    Canyon.unity
    Coastal.unity
    Forest.unity
    Airport.unity
  Scripts/
    Core/
      CarController.cs
      VehiclePhysicsModel.cs
      InputRouter.cs
      GameBootstrap.cs
    AI/
      AIOpponentController.cs
      AdaptiveDifficulty.cs
      TrafficController.cs
    UI/
      HUDController.cs
      GarageUIController.cs
      MainMenuController.cs
    Systems/
      EconomySystem.cs
      ProgressionSystem.cs
      SaveLoadSystem.cs
      WeatherSystem.cs
      ReplaySystem.cs
      PhotoModeSystem.cs
      DamageSystem.cs
      NitroSystem.cs
      PoliceChaseSystem.cs
      ChallengeSystem.cs
      AchievementSystem.cs
      LeaderboardSystem.cs
      AudioManager.cs
    Multiplayer/
      NetworkRaceManager.cs
      LobbyManager.cs
    Utilities/
      Timer.cs
      EventBus.cs
ProjectSettings/
Packages/
```

## Suggested 50+ Cars Dataset
Place 50+ entries as `CarData` scriptable objects across classes:
- Sports (15)
- Supercars (12)
- Hypercars (8)
- Muscle (8)
- SUVs (7)

Each entry includes:
- MaxSpeed
- Acceleration
- Handling
- Braking
- Weight
- Traction
- Drivetrain
- UnlockTier
- Price

# ApexRush Racing — Setup Guide (Unity URP/HDRP)

## 1) Prerequisites
- Unity 6 LTS (or Unity 2022.3+)
- Visual Studio / Rider
- Git LFS (recommended for large assets)
- Optional: Photon Fusion or Unity Netcode package for multiplayer

## 2) Create Project
1. Open Unity Hub → New Project.
2. Select **3D (HDRP)** for top-end visuals or **URP** for broader hardware support.
3. Name project `ApexRushRacing`.
4. Copy this repository contents into the Unity project root.

## 3) Import Packages
Use Package Manager and install:
- Input System
- Cinemachine
- TextMeshPro
- ProBuilder (optional for blockouts)
- Netcode for GameObjects (or Photon/FishNet)
- Addressables
- Post Processing (if needed per render pipeline)

## 4) Project Settings
- Player → Active Input Handling: **Both**
- Time → Fixed Timestep: `0.01` for stable physics
- Quality levels: Low / Medium / High / Ultra
- Physics:
  - Solver Iterations 10+
  - Default Contact Offset tuned for vehicle colliders

## 5) Scene Bootstrap
Create scenes:
- `Scenes/Bootstrap.unity`
- `Scenes/MainMenu.unity`
- `Scenes/Garage.unity`
- `Scenes/CityMap.unity`

In Bootstrap scene:
1. Add `GameManager` object with `GameBootstrap` script.
2. Add `AudioManager` object with `AudioManager` script.
3. Add `UIRoot` canvas and attach `HUDController`.
4. Mark managers as `DontDestroyOnLoad`.

## 6) Car Pipeline
1. Add car prefabs to `Assets/Prefabs/Cars`.
2. Create one `CarData` asset per car in `Assets/Data/Cars`.
3. Assign:
   - top speed
   - acceleration curve
   - brake force
   - handling and drift profile
4. Bind `CarController` + wheel colliders + VFX/audio.

## 7) AI Pipeline
- Add race waypoints.
- Create `TrackPath` object per track.
- Assign AI cars with `AIOpponentController` and `AdaptiveDifficulty`.

## 8) Multiplayer Pipeline (Prototype)
- Integrate `NetworkRaceManager`.
- Host/client lobby scene.
- Sync car transforms using prediction + reconciliation.
- Sync race state (countdown, laps, finish).

## 9) Performance Checklist
- Use LOD groups on all cars and environment props.
- Occlusion culling for city maps.
- Texture streaming enabled.
- Reduce real-time lights on Low/Medium profiles.
- Use baked GI where possible.

## 10) Build
- PC build target: Windows x86_64.
- Enable DX12 for ray tracing compatible GPUs.
- Create build presets:
  - `Dev`
  - `QA`
  - `Shipping`

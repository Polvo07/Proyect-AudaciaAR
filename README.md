# Audacia AR

Mobile augmented reality app built in Unity with Vuforia. Capstone project ("proyecto integrador"). Point the phone camera at a physical machine or object and the app recognizes it and plays a spoken explanation over it.

## What it does

The app showcases a set of engineering projects in augmented reality. You log in, pick a target from the menu, point the camera at the real object, and when Vuforia recognizes it the app shows an audio button and plays a narration describing that project. Losing sight of the object stops the audio. It ships with five targets: ROV, Calvin, the railway monitoring system (Sistema Férreo), Robot, and Vart.

## Stack

- Unity 2022.3.62f3 LTS
- Vuforia Engine 11.4.4 (Model Targets)
- C# (MonoBehaviour scripts)
- TextMeshPro for UI
- Android build target (needs a device with a camera)
- Git LFS for the audio clips and the Vuforia engine package

## How it works

The recognition uses Vuforia **Model Targets**, not flat image markers. Each machine is tracked from its 3D shape (a mesh plus a depth contour stored under `Assets/StreamingAssets/Vuforia`), so the app recognizes the real object from different angles instead of a printed picture.

The flow is one scene per target: `02-MenuScan` is the picker, and `MenuTrabajos.cs` loads a dedicated scene (`03-Rov`, `04-Calvin`, `05-SMFerreo`, `06-Robot`, `07-Vart`) for each one. Inside a target scene, `ARAudioManager.cs` is wired to Vuforia's target-found and target-lost events: on found it reveals the audio button and plays that target's clip, on lost it stops playback. The button then toggles play and pause. Keeping the audio logic in one component per scene made it simple to reuse the same prefab across every target and only swap the clip.

## Running it locally

1. Install **Unity 2022.3.62f3** (LTS).
2. Clone the repo (Git LFS pulls the Vuforia package and audio automatically).
3. Open the project. The Vuforia Engine package resolves from the versioned tarball in `Packages/` through the Package Manager, so no extra download is needed.
4. **Add your own Vuforia license key.** The key is not versioned in this repo. Open `Window > Vuforia Configuration` (or edit `Assets/Resources/VuforiaConfiguration.asset`) and paste a key from the free tier at [developer.vuforia.com](https://developer.vuforia.com). Without a key the AR camera will not start.
5. Build to an Android device. AR needs a real camera, so the app is meant to run on a phone, not in a plain editor window.

Login for the demo build: user `admin`, password `1234`.

## Screenshots

> Screenshots pending. TODO: AD to add. Suggested shots: the scan menu, and the app running with a target recognized and the audio button visible.

## Status

Finished as a capstone project. Runs on Android against the five bundled targets.

Known limitation: the login in `Assets/Scripts/LoginManager.cs` is hardcoded (`admin` / `1234`). It is a demo gate for the presentation build, not real authentication. The in-editor Play Mode was also switched back to the live camera, since the original recording used for simulation was a large local file that is no longer part of the repo.

[![npm package](https://img.shields.io/npm/v/com.rmc.rmc-core)](https://www.npmjs.com/package/com.rmc.rmc-core)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# RMC Core

Core library for Unity Development by Rivello Multimedia Consulting

- [Install](#install)
  - [via Git URL](#via-git-url)
  - [Tests](#tests)


<!-- toc -->

### Install Depencencies via Git URL


Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
   "jillejr.newtonsoft.json-for-unity": "https://github.com/jilleJr/Newtonsoft.Json-for-Unity.git#upm",
   "com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask"
  }
}
```

### Tests

The package can optionally be set as *testable*.
In practice this means that tests in the package will be visible in the [Unity Test Runner](https://docs.unity3d.com/2017.4/Documentation/Manual/testing-editortestsrunner.html).

Open `Packages/manifest.json` with your favorite text editor. Add following line **after** the dependencies block:
```json
{
  "dependencies": {
  },
  "testables": [ "com.rmc.rmc-core" ]
}
```

### Import Samples
To see clear use cases, import and run the samples:

1. Open Unity and then open `Window > Package Manager`
1. Select `RMC Core` 
1. Select Samples and import

Created By
=============

- Samuel Asher Rivello 
- Over 23 years XP with game development (2023)
- Over 10 years XP with Unity (2023)

Contact
=============

- Twitter - <a href="https://twitter.com/srivello/">@srivello</a>
- Resume & Portfolio - <a href="http://www.SamuelAsherRivello.com">SamuelAsherRivello.com</a>
- Git - <a href="https://github.com/SamuelAsherRivello/">Github.com/SamuelAsherRivello</a>
- LinkedIn - <a href="https://Linkedin.com/in/SamuelAsherRivello">Linkedin.com/in/SamuelAsherRivello</a> <--- Say Hello! :)





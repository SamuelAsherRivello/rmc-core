[![npm package](https://img.shields.io/npm/v/com.rmc.rmc-core)](https://www.npmjs.com/package/com.rmc.rmc-core)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

<img width = "400" src="https://github.com/SamuelAsherRivello/rmc-core/blob/main/RMC%20Core/Documentation~/com.rmc_namespace_logo.png" />

# RMC Core

- [How To Use](#how-to-use)
- [Install](#install)
  - [Via NPM](#via-npm)
  - [Via Git URL](#via-git-url)
  - [Tests](#tests)
  - [Samples](#samples)
- [Configuration](#configuration)

<!-- toc -->

## How to use

Core library for Unity Development by Rivello Multimedia Consulting.

Import the package into your new or existing Unity Project. Enjoy!

## Install

### Via NPM

Open `Packages/manifest.json` with your favorite text editor. Add a [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) and following line(s) to dependencies block:
```json
{
  "scopedRegistries": [
    {
      "name": "npmjs",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "com.rmc"
      ]
    }
  ],
  "dependencies": {
    "com.com.rmc.rmc-core": "1.0.1"
  }
}
```
Package should now appear in package manager.


### Via Git URL
#### Manifest

Open `Packages/manifest.json` with your favorite text editor. Add following line(s) to the dependencies block:
```json
{
  "dependencies": {
      "com.rmc.rmc-core": "https://github.com/SamuelAsherRivello/rmc-core",
      "com.rmc.rmc-unitask": "https://github.com/SamuelAsherRivello/rmc-unitask",
      "jillejr.newtonsoft.json-for-unity": "https://github.com/jilleJr/Newtonsoft.Json-for-Unity.git#upm"
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

### Samples

Some packages include optional samples with clear use cases. To import and run the samples:

1. Open Unity and then open `Window > Package Manager`
1. Select this package 
1. Select samples
1. Import

## Configuration

* `Unity Target` - [Standalone MAC/PC](https://support.unity.com/hc/en-us/articles/206336795-What-platforms-are-supported-by-Unity-)
* `Unity Version` - Any [Unity Editor](https://unity.com/download) 2021.x or higher
* `Unity Rendering` - Any [Unity Render Pipeline](https://docs.unity3d.com/Manual/universal-render-pipeline.html)
* `Unity Aspect Ratio` - Any [Unity Game View](https://docs.unity3d.com/Manual/GameView.html)


Created By
=============

- Samuel Asher Rivello 
- Over 23 years XP with game development (2023)
- Over 10 years XP with Unity (2023)

Contact
=============

- Twitter - <a href="https://twitter.com/srivello/">@srivello</a>
- Resume & Portfolio - <a href="http://www.SamuelAsherRivello.com">SamuelAsherRivello.com</a>
- Source Code on Git - <a href="https://github.com/SamuelAsherRivello/">Github.com/SamuelAsherRivello</a>
- LinkedIn - <a href="https://Linkedin.com/in/SamuelAsherRivello">Linkedin.com/in/SamuelAsherRivello</a> <--- Say Hello! :)

License
=============

Provided as-is under MIT License | Copyright © 2023 Rivello Multimedia Consulting, LLC





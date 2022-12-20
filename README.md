[![npm package](https://img.shields.io/npm/v/com.rmc.rmc-core)](https://www.npmjs.com/package/com.rmc.rmc-core)
[![openupm](https://img.shields.io/npm/v/com.rmc.rmc-core?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.rmc.rmc-core/)
![Tests](https://github.com/rmc/rmc-core/workflows/Tests/badge.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# RMC Core

Core library for Unity Development by Rivello Multimedia Consulting

- [How to use](#how-to-use)
- [Install](#install)
  - [via npm](#via-npm)
  - [via OpenUPM](#via-openupm)
  - [via Git URL](#via-git-url)
  - [Tests](#tests)
- [Configuration](#configuration)

<!-- toc -->

## How to use

*Work In Progress* (The only way that fully fucnctions is the "via Git URL" below)

## Install

### via npm

Open `Packages/manifest.json` with your favorite text editor. Add a [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) and following line to dependencies block:
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
    "com.rmc.rmc-core": "1.0.0"
  }
}
```
Package should now appear in package manager.

### via OpenUPM

The package is also available on the [openupm registry](https://openupm.com/packages/com.rmc.rmc-core). You can install it eg. via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.rmc.rmc-core
```

### via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
    "com.rmc.rmc-core": "https://github.com/rmc/rmc-core.git"
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

## Configuration

*Work In Progress*

## License

MIT License

Copyright © 2022 rmc


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





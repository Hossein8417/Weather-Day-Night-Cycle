# Weather-Day-Night-Cycle State Machine

A Unity project that demonstrates a modular **State Machine architecture** for controlling environmental conditions such as **Weather** and **Time of Day**.

The project was built as a software architecture and game programming exercise to practice state-driven design, separation of concerns, and scalable system organization inside Unity.

---

## Overview

This system allows runtime switching between different weather conditions and time-of-day states through a simple UI.

Each state is responsible for managing its own visual behavior, including:

* Lighting
* HDRP Volumes
* Particle Systems
* Material Changes
* Environmental Settings

The project uses a custom State Machine implementation rather than hardcoded conditional logic, making it easier to extend and maintain.

---

## Features

### Weather States

* Default
* Sunny
* Cloudy
* Rainy
* Snowy

### Time States

* Default
* Morning
* Midday
* Evening
* Night

### Environment Control

* Dynamic sun rotation
* Light temperature adjustments
* HDRP light intensity control
* Volume activation/deactivation
* Rain particle effects
* Snow particle effects
* Ground material switching

### UI Controls

* Dropdown-based weather selection
* Dropdown-based time selection
* Runtime state switching

---

## Architecture

The project follows a State Machine architecture.

### Core Components

#### IState

Common contract implemented by every state.

Responsibilities:

* Enter State
* Exit State

#### Manager

Controls active weather and time states.

Responsibilities:

* Store current state references
* Handle state transitions
* Initialize default states

#### Data

Centralized container for scene references.

Responsibilities:

* Lights
* Volumes
* Materials
* Particle Systems
* Environment Objects

#### UI Manager

Acts as a bridge between user input and the state system.

Responsibilities:

* UI initialization
* Dropdown events
* State transition requests

---

## Technical Concepts Practiced

* State Machine Pattern
* Object-Oriented Programming (OOP)
* Separation of Concerns
* Single Responsibility Principle mindset
* Unity HDRP
* Runtime Environment Control
* UI Event Handling
* Project Refactoring

---

## What I Learned

During this project I practiced:

* Designing and implementing a State Machine
* Separating UI from gameplay logic
* Structuring larger Unity projects
* Refactoring code into smaller responsibilities
* Managing environmental systems through states
* Improving code maintainability and scalability
* Identifying coupling and architectural issues

---

## Future Improvements

Planned improvements include:

* Transition effects between states
* Smooth weather blending
* Smooth day/night transitions
* State configuration using ScriptableObjects
* Reduced coupling between systems
* Shared base classes for common state behavior
* Further architecture refinement

---

## Technologies

* Unity
* C#
* HDRP
* TextMeshPro
* Object-Oriented Programming
* State Machine Pattern

---

## Author

Hossein

Built as part of my game programming and software architecture learning journey.

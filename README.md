# FlightRadar
This repository contains a Flight Radar application developed for "Object Oriented Design" university course using C# and .NET 8. This application offers real-time flight tracking and management capabilities. Designed with a focus on object-oriented principles, the system showcases a practical implementation of design patterns such as Singleton, Adapter and Visitor.

### Prerequisites
- Make sure the .NET 8 is installed on your device

## Stages of implementation
(for more detailed stage description and code-quality requirements check "Task" folder)
## Stage 1: Data Loading and Serialization
### Objective
Establish the foundational code for reading flight data from a custom-formatted FTR file and serialize this data into JSON format.
### Key Features
- Data deserialization from FTR file format.
- Data serialization into JSON format.
### Implemented Patterns
- Factory method

## Stage 2: Integration with a Simulated Data Source
### Objective
Extend the application to receive and process binary messages from a simulated TCP server, incorporating functionality for creating data snapshots.
### Key Features
- Integration with `NetworkSourceSimulator` class from an external DLL to process binary data.
- Implementation of thread-safe message handling.
- Real-time data processing with support for "print" and "exit" commands.
### Implemented Patterns
- Singleton

## Stage 3: Synchronization with Graphical User Interface (GUI)
### Objective
Synchronize the data acquired from the server or text file with a graphical interface displaying a world map with airplane positions.
### Key Features
- Utilization of the `FlightTrackerGUI` package for window display and data updates.
- Conversion of flight data for GUI representation.
- Calculation of airplane positions and rotations based on geographical coordinates, with continuous position updates.
### Implemented Patterns
- Adapter

## Stage 4: News Report Generation
### Objective
Implement a feature to generate news reports for different types of objects, such as airports and planes, from various news providers.
### Key Features
- Creation of news provider classes: Television, Radio, and Newspaper.
- Interface implementation for reportable objects.
- Development of `NewsGenerator` class for dynamic news string generation based on object types.
- Introduction of a "report" command to trigger news overview generation.
### Implemented Patterns
- Visitor

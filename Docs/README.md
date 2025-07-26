# New-Cellular-Automat-Engine

## Description

This project implements an engine for one-dimensional cellular automata with support for custom rules. You can use built-in rules (Rule22, Rule30, Rule110) or create your own in JSON format.

## Quick Start

1. **Clone the repository:**
   ```
   git clone https://github.com/XeshSufferer/New-Cellular-Automat-Engine.git
   ```

2. **Open the project in Visual Studio or another IDE with C# support, or use the Release files**

3. **Configure parameters:**
   - Modify the `settings.json` file to set simulation parameters (map size, number of generations, rule to use, etc.).

4. **Add or modify rules:**
   - For custom rules, use the `CustomRules/` folder and the file format described below.

5. **Build and run the project:**
   - In Visual Studio: press F5 or select "Run".
   - In command line:
     ```
     dotnet run
     ```

6. **Results:**
   - Simulation results will be output to the console.

## Getting Started if you are NOT a programmer

1. **Download the version you need for your operating system from https://github.com/XeshSufferer/New-Cellular-Automat-Engine/releases**

2. **Run New-Cellular-Automat-Engine.exe**
   - After launching - close it if you need to configure or change rules. Configuration is only applied on restart

3. **Configure parameters:**
   - Modify the `settings.json` file to set simulation parameters (map size, number of generations, rule to use, etc.). How to modify parameters and what parameters affect what - read below

4. **Add or modify rules:**
   - For custom rules, use the `CustomRules/` folder and the file format described below.

5. **After configuration - run New-Cellular-Automat-Engine.exe again! Settings will be applied**

## Project Configuration in settings.json

1. **Settings file breakdown**
   - Automatically generated standard settings
   ```json
   {
      "Width":1200,
      "Height":600
      ,"GenerationType":"RandomDot",
      "GenerationCount":100,
      "Delay":100,
      "Rule":"Rule22",
      "JsonMode":false, 
      "JsonRule":"ExampleRule"
   }
   ```

   - 'Width' - Simulation map width
   - 'Height' - Simulation map height
   - 'GenerationType' - Seed generation type (RandomDot, FullSeed, RandomSeed)
   - 'GenerationCount' - Number of generations
   - 'Delay' - Delay between generations
   - 'Rule' - Name of built-in rule for demonstration (Built-in rules include Rule22, Rule30, Rule110 | Will be ignored if JsonMode - true)
   - 'JsonMode' - Enable/disable reading JSON generation rules
   - 'JsonRule' - Name value of custom JSON rule (will be ignored if JsonMode - false)

## Project Structure

- `Cell.cs` — cell description.
- `Map.cs`, `MapRegenerator.cs` — map logic and generation of generations.
- `Rule.cs`, `Rule22.cs`, `Rule30.cs`, `Rule110.cs`, `CustomJsonRule.cs` — rule implementation.
- `CustomRulesReader.cs` — reading custom rules from JSON.
- `Settings.cs`, `SettingsReader.cs`, `settings.json` — settings management.
- `Writer.cs` — output results.
- `ExamplesFactory.cs`, `Examples.cs` — rapid prototyping system for cellular automaton rules Examples.

## How to Create a Custom Rule in JSON Format

1. **Create a file in the `CustomRules/` folder**  
   For example: `MyRule.json`

2. **File structure**  
   Example content:
   ```json
   {
     "Name": "MyRule",
     "WritedConditions": [
       "001",
       "010",
       "100"
     ]
   }
   ```
   - `Name` — unique rule name (string).
   - `WritedConditions` — array of strings (conditions), each string is a combination of neighbor states and the cell itself (for example, `"001"` means: left — 0, center — 0, right — 1). More details about conditions below
   - If the condition is met, the cell becomes alive (filled).

3. **Specify the rule in settings**  
   In the `settings.json` file:
   ```json
   {
     // ... other parameters ...
     "JsonMode": true,
     "JsonRule": "MyRule"
   }
   ```
   - `"JsonMode": true` — enables the use of custom rules but built-in standard rules will be ignored.
   - `"JsonRule": "MyRule"` — name of your rule (must match the `Name` field in JSON).

4. **Run the project**  
   The program will automatically load and apply your rule.

**Notes:**
- The condition format `"001"` corresponds to the pattern: left, center, right (0 — dead, 1 — alive).
- If no condition is met, the cell remains/becomes dead.
- For an example, see the file `CustomRules/ExampleRule.json`.
- If you set the Delay value to -1, the next simulation will be launched by pressing a key.
- If you set the GenerationCount value to -1, generation will continue infinitely (within the established field).

## Conditions

**Standard Conditions**

- Standard conditions include conditions in the format "001", "100", "010".

- **Important:** If you are not familiar with Wolfram cellular automaton notation, we recommend studying the basics before creating complex rules.

**Simple notation explanation:**
- Three-digit number: left neighbor | center | right neighbor
- 0 = dead cell, 1 = alive cell
- Example: "001" = left dead, center dead, right alive

**Probabilistic Conditions**

- Probabilistic conditions are any conditions (in our case, any of the standard ones), but they trigger with a certain chance specified in the name.

- The format of probabilistic conditions is determined by the following format {condition name}_p{trigger chance when condition is met}.

- Currently, for all standard conditions, the prefixes _p50, _p75, _p10, _p25 are relevant for 50, 75, 10, 25 percent trigger chance respectively

**Example**
- Condition "001_p50" will trigger with 50% chance if the standard condition "001" is true.

## License

The project is distributed under the MIT license.


Zenith Virtual Assistant
A modern desktop virtual assistant built with C# and WinUI 3.
Features

Background Process: Runs continuously, listening for voice commands.
Voice Commands: Activated with "Zenith" prefix (e.g., "Zenith wake up").
AI Integration: Uses local Ollama AI for command processing.
System Control: Open apps, shutdown, restart, and open terminals (cmd, PowerShell, Git Bash, WSL).
Widget Mode: Compact UI for quick interactions.
Local Database: Stores command history using SQLite.
Text-to-Speech: Provides voice feedback.

Setup

Install .NET 8.0 SDK.
Install Ollama and run it locally (http://localhost:11434).
Clone the repository.
Open ZenithVirtualAssistant.sln in Visual Studio.
Build and run the solution.

Usage

Say "Zenith wake up" to activate the AI.
Use commands like "Zenith open notepad" or "Zenith open terminal cmd".
Interact with the widget UI for quick actions.

Dependencies

Microsoft.WindowsAppSDK
System.Speech
Microsoft.Data.Sqlite
System.Net.Http


# Computer Watcher

**Computer Watcher** is a Windows Forms application built in C# that monitors running processes on your computer. It displays essential information about each process, including its name, PID, CPU usage, and RAM consumption.

---

## Features

- Real-time display of all active processes.
- Displays **Process Name**, **PID**, **CPU (%)**, and **RAM (MB)**.
- User-friendly interface with **grid lines**, **full row selection**, and **resizable columns**.
- Responsive layout that adjusts to the window size.
- Columns are right-aligned for numeric values for better readability.

---

## Installation

1. Clone the repository or download the project files.
2. Open the solution in **Visual Studio**.
3. Build the project using `Ctrl+Shift+B` or via the Build menu.
4. Run the project with `F5` or by starting without debugging.

---

## Usage

1. Launch the application.
2. The main window will display a list of running processes.
3. CPU and RAM usage are shown in real-time for each process (requires additional logic to update values periodically).

---

## Requirements

- Windows OS
- .NET Framework (or .NET 6/7 if updated)
- Visual Studio 2019 or later

---

## Notes

- Currently, the project displays static CPU and RAM values. You may integrate a timer or background thread to update these metrics periodically.
- UI/UX improvements include full row selection, grid lines, responsive layout, and readable fonts.

---

## License

MIT License

# 🛡️ The Overly Complicated Password Checker
> **"Because if it's worth doing, it's worth over-engineering."**

## 🖋️ Overview
A professional-grade Command Line Interface (CLI) application for secure password creation. While a simple password check could be done in 10 lines, this project demonstrates **Clean Code**, **User Experience (UX)**, and **Defensive Programming** principles used in industry-standard software.

## ✨ "Pro" Features
* **Secure Masked Input:** Uses `StringBuilder` and `Console.ReadKey(true)` to mask input with `*`. No plain-text passwords appear in the terminal history.
* **Custom ANSI Theme Engine:** A decoupled `Theme` class providing:
    * **Bold** and High-Contrast colors.
    * Standardized labels: `SUCCESS:`, `WARNING:`, `ERROR:`, and `INSTRUCTION:`.
    * One-line reset logic to prevent color "bleeding."
* **Validation Waterfall:** A logical priority system that checks for empty strings, length, and complexity *before* bothering to check for matching confirmation—saving the user's time.
* **Interface Management:** Active use of `Console.Clear()` and `Thread.Sleep()` to create a state-driven UI rather than a scrolling text log.

## 🛠️ Technical Stack
* **Language:** C# (.NET 8.0+)
* **Styling:** ANSI Escape Sequences (VT100)
* **Character Encoding:** UTF-8

## 🚀 How to Run
1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Clone this repository:
   ```bash
   git clone [https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git](https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git)
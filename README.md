# Date utilizator — Tema 5 C#

A simple C# Windows Forms application for the exercise at the end of the supplied PDF.

## Run

On Windows 10/11 (64-bit), extract the entire `Date-utilizator-Windows.zip`
archive into a writable folder and double-click `UserDataApp.exe`.
The Windows download includes .NET; no separate runtime installation is needed.

The form contains Nume, Prenume, Email and Telefon. `Salvează` checks that all
fields are filled and that the email has a valid format, then lets you choose a
JSON file. `Anulează` clears the fields; Escape does the same. Enter saves.
Phone numbers remain text to preserve prefixes and leading zeros.

## Open the source

Extract `Date-utilizator-source.zip` and open `UserDataApp.sln` in a Visual Studio
version supporting .NET 10, with the .NET desktop development workload installed.
Build and run with F5. The project has no third-party dependencies.

## Assignment requirements

| Requirement from the PDF | Implementation |
| --- | --- |
| TableLayoutPanel | Two-column form with automatic label widths and expanding input column |
| Anchor | Text boxes anchored left/right, labels left |
| Dock | Main table and button panel use DockStyle.Fill |
| AutoSize | Labels, buttons and button panel size themselves to their contents |
| MinimumSize | 800 × 500 outer window size |
| AutoScaleMode.Dpi | Set on the form; application uses PerMonitorV2 high DPI mode |
| Test at three window sizes | Included Windows test mode: 800 × 500, 1000 × 600, 1200 × 700 |
| Check maximization | Included Windows test mode maximizes, checks and restores the form |

## Windows layout checks

Double-click `test-layout.cmd` in the Windows download. It runs the actual form
at the three sizes, maximizes and restores it, and checks minimum size enforcement.
At each step it checks that controls are visible, fit within the form and their
parents, and do not overlap. Results are saved beside the executable in
`layout-test-results.txt`. If Windows limits a requested window size to the
current screen, the report records both the requested and actual dimensions.
Use a screen large enough for 1200 × 700 to test all three exact sizes.

Also manually resize the window, maximize and restore it, use Tab to move through
the fields, and verify Save and Cancel. For DPI testing, repeat at 100% and 150%
Windows display scaling and, if available, move the form between monitors.

From the source directory you can run:

```powershell
dotnet run --project UserDataApp -- --test-layout
```

To start the form at a specific outer window size, provide the width and height
in pixels:

```powershell
dotnet run --project UserDataApp -- --size 1200 700
```

`--window-size` is also accepted as an alias. Both dimensions must be at least
the form's minimum size of 800 × 500.

## Verification status

The release build and self-contained Windows publish were verified in the Linux
build workspace. Windows Forms cannot run in that environment, so the included
Windows layout checks and manual behavior/DPI checks have **not been executed**.
Run them on Windows to finish the exercise's runtime verification requirements.

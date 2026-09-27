# Judo

C# tools for judo events and clubs: UDP scoreboards, venue displays, kata scoring, membership and Revolutionise export. The collection grew between 2016 and 2025 and covers match-day software (scoreboard broadcasters and listeners for IJF/EuroJudo scoreboard feeds, the Shisutemu venue system with scoreboard, kiosk, media player and switchboard apps, a flag-raising ceremony display, kata scorecards and a video-based match analyser) and club administration (membership and ClubWeb web apps, a match video renamer, and an exporter that turns Revolutionise Sports registrations into EuroJudo XLS or IJF import files). Many projects exist in several framework generations side by side (.NET Framework 4.x, .NET Core, .NET Standard and .NET 5 to 10); folders ending in `.org`, `_48` or `_5` hold earlier or alternate-framework versions.

Working copy from my Historical Dev folder.

**Source last updated:** 2025-11-23 · **Language:** C# · **Target frameworks:** .NET Framework 4.5.2-4.8, .NET Core 1.1-3.1, .NET Standard 2.0/2.1, .NET 5/6/8/10 (incl. `-windows`) · **Output types:** WinForms exes, console apps, ASP.NET Core / Blazor web apps, class libraries, MSIX package

## Solution structure

About 70 C# projects in 18 solutions, grouped by area:

| Area | Projects | Language | Type | Purpose |
|------|----------|----------|------|---------|
| Root (`Judo.sln`) | Pose | C# | WinForms exe (.NET 8) | Match video player and analyser using OpenCvSharp, NAudio and FFmpeg to track judogi colours frame by frame |
| UDP scoreboard (`UDP/UDP.sln`, `UDP/UDP_5/UDP_5.sln`) | Foundation, Foundation_5, Foundation.Standard, Foundation.org, JudoBase, UDP | C# | Libraries (.NET Framework 4.8, .NET Standard, .NET Core 2.0, .NET 5-8) | Shared scoreboard model (players, belts, contests) and UDP packet handling |
| | Sender, Internet Sender | C# | Console / WinForms exe | Broadcast scoreboard state on the LAN or over the internet |
| | Receiver, Receiver_5, Receiver.Standard, Receiver.org, Listener, ReceiverTest | C# | Libraries / test exe | Receive and decode scoreboard packets |
| | Scoreboard, Scoreboard.org, Scoreboard Listener, ScoreboardInfo, ScoreboardInfo.org | C# | Libraries / console / WinForms exes | Scoreboard display and scoreboard-info viewers driven by received packets |
| | EuroJudoListener, Replay, GUITest | C# | Console / WinForms exes (.NET 5-8, 4.8) | Listen to EuroJudo feeds, replay captured traffic (`BigData.pcap`), UI test harness |
| | CustomControls, CustomControls_48 | C# | WinForms control libraries | Shared scoreboard controls |
| Venue system (`Shisutemu/Shisutemu.sln`) | Scoreboard, Judo Scoreboard, Kiosk, Media Player, Haidenban, Switchboard, App Starter | C# | WinForms / console exes (.NET Framework 4.6.1-4.7.1) | Venue scoreboards, kiosk, media playback, switchboard and a service-based app starter / key remapper |
| | Classes (Kurasu), Comms | C# | Libraries | Shared tournament classes and communications |
| | JudoWA, xJudoWA | C# | ASP.NET Core 1.1 web app / ASP.NET library | Web front end with identity (accounts) for the venue system |
| | WillissConverter, ConsoleTest, GUITest | C# | Exes | Draw-sheet data converter and test harnesses |
| Core judo model (`Judo`, `Judo_48`, `Judo.org`) | Judo | C# | Library (.NET Framework 4.8 / .NET 6) | Tournaments, clubs, people, belts, weight categories, locations |
| | Kata Manager: KataManager, Setup | C# | WinForms exe / MSIX packaging project | Manual and electronic kata scorecards |
| | Membership | C# | ASP.NET Core 3.1 web app | Club membership |
| | Video Namer | C# | WinForms exe | Renames recorded match videos |
| Controls (`JudoControls`, `JudoControls_5`, `JudoControls.org`) | JudoControls | C# | WinForms control libraries (.NET 8 / 5 / 4.8) | Shared judo UI controls |
| Objects (`JudoObjects/JudoObjects.sln`) | Classes | C# | Library (.NET 10) | Judo object model (players, belts, weight categories) |
| Club web (`ClubWeb/ClubWeb.sln`) | ClubWeb, ClubWeb.Data | C# | Blazor Server app / EF Core data library (.NET 10) | Judo club management web app |
| Ceremonies (`FlagRaising/Judo.sln`) | FlagRaising | C# | WinForms exe (.NET Framework 4.8) | Flag-raising display with national flags and anthems |
| Federations | EuroJudo, IJF | C# | Libraries (.NET Framework 4.8) | EuroJudo and IJF data formats |
| Revolutionise (`Revolutionise/RevExport/RevExport.sln`) | MappingTool (Revolutionise Exporter), Library, ClubFunction, DownShift, Setup | C# | WinForms exe / libraries / Azure Function / setup project | Create EuroJudo (XLS) or IJF (.txt) import files from a Revolutionise Sports export |
| | xxxDownShift: Designer, DownShift, Library | C# | WinForms exes / library | Earlier exporter experiment (retired, marked `xxx`) |
| Helpers | NPOIHelper, Test | C# | Library / console exe | NPOI spreadsheet helpers and scratch tests |

## How to open

Open `Judo.sln` in the repository root (Pose). The larger areas have their own solutions: `UDP/UDP.sln`, `Shisutemu/Shisutemu.sln`, `Revolutionise/RevExport/RevExport.sln`, `ClubWeb/ClubWeb.sln`, `JudoObjects/JudoObjects.sln`, `FlagRaising/Judo.sln`, and the `Kata Manager.sln`, `Membership.sln` and `VideoNamer/Judo.sln` solutions under `Judo`, `Judo_48` and `Judo.org`. Restore NuGet packages before building.

## Requirements

- Visual Studio 2026 for the .NET 10 projects (ClubWeb, JudoObjects); Visual Studio 2022 or 2026 for everything else (solution format 12.00 / VS 17)
- Workloads: .NET desktop development and ASP.NET and web development
- .NET 10 and .NET 8 SDKs; .NET 5/6 targeting packs for the older SDK-style projects
- .NET Framework 4.5.2-4.8 developer / targeting packs
- .NET Core 1.1-3.1 SDKs to build the oldest ASP.NET Core and WindowsDesktop projects unchanged
- Windows Application Packaging (MSIX) tools for Kata Manager `Setup`
- Microsoft Visual Studio Installer Projects extension for `Revolutionise/RevExport/Setup/Setup.vdproj`
- Azure Functions tools for `ClubFunction`

## Attribution and provenance

Working copy from my Development folder `Judo`. Assembly metadata credits Vader Consulting (Copyright 2016-2020); package author Dave Robinson. `Revolutionise/Excel DLL` contains the third-party CarlosAg.ExcelXmlWriter library used by the exporter.

Left out of this repository:

- Build and tool output: `bin`, `obj`, `packages`, `.vs`, `.vshistory`, `node_modules`, `.nugetaudit`, generated code-graph XML, MSIX `AppPackages` bundles (over 95 MB each) and the RevExport `Setup/Debug` installer output
- The redistributable Microsoft Edge WebView2 runtime installer from Kata Manager
- An unused third-party Npoi.Core copy (`Revolutionise/xxxNpoi.Core-master`)
- Entrant and registration exports, sample member lists, tournament databases (`.mdf`/`.ldf`/`.mdb`) and the MSIX test signing key, because they contain personal data or secrets
- Third-party IJF / scoreboard protocol PDFs

The Google API client file for Kiosk is provided as `Shisutemu/Kiosk/client_secret.json.json.example`; copy it to `client_secret.json.json` and fill in your own values. Local user paths, database user names and organisation email addresses were replaced with placeholders.

## License

MIT License, Copyright (c) 2026 VaderConsulting. See [LICENSE](LICENSE).

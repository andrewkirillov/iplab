; IPLab setup project

[Setup]
AppName=Image Processing Lab
AppVerName=Image Processing Lab 2.6.1
AppPublisher=AForge.NET
AppPublisherURL=http://www.aforgenet.com/projects/iplab/
AppSupportURL=http://www.aforgenet.com/projects/iplab/
AppUpdatesURL=http://www.aforgenet.com/projects/iplab/
DefaultDirName={pf}\AForge.NET\IPLab
DefaultGroupName=AForge.NET\IPLab
AllowNoIcons=yes
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes
LicenseFile=gpl-3.0.txt

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Components]
Name: "app"; Description: "Image Processing Lab"; Types: full compact custom; Flags: fixed
Name: "sources"; Description: "Sources"; Types: full custom

[Files]
Source: "Files\Copyright.txt"; DestDir: "{app}"; Components: app
Source: "Files\Release notes.txt"; DestDir: "{app}"; Components: app
Source: "Files\gpl-3.0.txt"; DestDir: "{app}"; Components: app
Source: "Files\License.txt"; DestDir: "{app}"; Components: app
Source: "Files\Release\*"; DestDir: "{app}\bin"; Components: app
Source: "Files\Sources\*"; DestDir: "{app}\Sources"; Components: sources; Flags: recursesubdirs
Source: "Files\References\*"; DestDir: "{app}\References"; Components: sources; Flags: recursesubdirs

[Icons]
Name: "{group}\Image Processing Lab"; Filename: "{app}\bin\iplab.exe"
Name: "{group}\Project Home"; Filename: "http://www.aforgenet.com/projects/iplab/"
Name: "{group}\Release Notes"; Filename: "{app}\Release notes.txt"

Name: "{group}\{cm:UninstallProgram,IPLab}"; Filename: "{uninstallexe}"

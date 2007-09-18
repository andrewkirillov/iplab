; IPLab setup project

[Setup]
AppName=Image Processing Lab
AppVerName=Image Processing Lab 2.5.1
AppPublisher=AForge
AppPublisherURL=http://code.google.com/p/iplab
AppSupportURL=http://code.google.com/p/iplab
AppUpdatesURL=http://code.google.com/p/iplab
DefaultDirName={pf}\IPLab
DefaultGroupName=IPLab
AllowNoIcons=yes
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes
LicenseFile=gpl.txt

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Components]
Name: "app"; Description: "Image Processing Lab"; Types: full compact custom; Flags: fixed
Name: "sources"; Description: "Sources"; Types: full custom

[Files]
Source: "Files\Copyright.txt"; DestDir: "{app}"; Components: app
Source: "Files\Release notes.txt"; DestDir: "{app}"; Components: app
Source: "Files\Release\*"; DestDir: "{app}\bin"; Components: app
Source: "Files\Sources\*"; DestDir: "{app}\Sources"; Components: sources; Flags: recursesubdirs
Source: "Files\References\*"; DestDir: "{app}\References"; Components: sources; Flags: recursesubdirs

[Icons]
Name: "{group}\Image Processing Lab"; Filename: "{app}\bin\iplab.exe"
Name: "{group}\Project Home"; Filename: "http://code.google.com/p/iplab/"
Name: "{group}\Release Notes"; Filename: "{app}\Release notes.txt"

Name: "{group}\{cm:UninstallProgram,IPLab}"; Filename: "{uninstallexe}"

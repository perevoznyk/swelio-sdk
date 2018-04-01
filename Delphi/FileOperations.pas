//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

unit FileOperations;

interface

uses
  Windows, SysUtils, Classes, SwelioEngine;

type
  TFileOperation = class
  public
    class procedure CreateUnicodeFile(const FileName : string);
    class function  IsUnicodeFile(const FileName : string) : boolean;
    class procedure DeleteToRecycleBin(FileName : string; Silent : boolean);
    class procedure ShellCopyFile(oldName : string; NewName : string);
    class function  GetSize(const FileName : string) : DWORD;
    class function  Exists(FileName : string) : boolean;
    class function  ExtensionIs(const FileName : string; Ext : string) : boolean;
    class function  IsImage(const FileName : string) : boolean;
    class procedure Delete(FileName : string);
    class procedure ClearAttributes(FileName : string);
    class function  Rename(OldName : string; NewName : string) : boolean;
    class function  StripName(const FileName : string) : string;
    class function  Copy(OldName : string; NewName : string) : boolean;
    class function  FullPath(FileName : string) : string;
    class function  FolderOrFileExists(FileName : string) : boolean;
    class function  FolderExists(FileName : string) : boolean;
    class function  IsFolder(FolderName : string) : boolean;
    class function  IsExecutable(FileName : string) : boolean;
    class function  IsIcon(FileName : string) : boolean;
    class function  ValidFileName(FileName : string) : boolean;
    class function  ValidPathName(FileName : string) : boolean;
    class function  NumberFilesInFolder(FolderName : string) : integer;
  end;

implementation

{ TFileOperation }

class procedure TFileOperation.ClearAttributes(FileName: string);
begin
  if FileName <> '' then
    ClearFileAttributes(PChar(FileName));
end;

class function TFileOperation.Copy(OldName, NewName: string): boolean;
begin
  if ((OldName <> '') and (NewName <> '')) then
    Result := SwelioEngine.FileCopy(PChar(OldName), PChar(NewName))
      else
        Result := false;
end;

class procedure TFileOperation.CreateUnicodeFile(const FileName: string);
begin
  if FileName <> '' then
    SwelioEngine.CreateUnicodeFile(PChar(FileName));
end;

class procedure TFileOperation.Delete(FileName: string);
begin
  if FileName <> '' then
    SwelioEngine.FileDelete(PChar(FileName));
end;

class procedure TFileOperation.DeleteToRecycleBin(FileName: string;
  Silent: boolean);
begin
  if FileName <> '' then
    SwelioEngine.DeleteToRecycleBin(PChar(FileName), Silent);
end;

class function TFileOperation.Exists(FileName: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.FileExists(PChar(FileName))
      else
        Result := false;
end;

class function TFileOperation.ExtensionIs(const FileName: string;
  Ext: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.FileExtensionIs(PChar(FileName), PChar(Ext))
      else
        Result := false;
end;

class function TFileOperation.FolderExists(FileName: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.DirectoryExists(PChar(FileName))
     else
       Result := false;
end;

class function TFileOperation.FolderOrFileExists(FileName: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.FileOrFolderExists(PChar(FileName))
      else
        Result := false;
end;

class function TFileOperation.FullPath(FileName : string) : string;
var
  FullName : array[0..MAX_PATH] of char;
begin
  if FileName <> '' then
    begin
      if SwelioEngine.FullPath(PChar(FileName), FullName) then
        Result := string(FullName)
          else
            Result := FileName;
    end
     else
       Result := '';
end;

class function TFileOperation.GetSize(const FileName: string): DWORD;
begin
  if FileName <> '' then
    Result := SwelioEngine.FileGetSize(PChar(FileName))
      else
        Result := 0;
end;

class function TFileOperation.IsExecutable(FileName: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.FileIsExe(PChar(FileName))
      else
        Result := false;
end;

class function TFileOperation.IsFolder(FolderName: string): boolean;
begin
  if FolderName <> '' then
    Result := SwelioEngine.IsDirectory(PChar(FolderName))
      else
        Result := false;
end;

class function TFileOperation.IsIcon(FileName: string): boolean;
begin
  Result := SwelioEngine.FileIsIcon(PChar(FileName));
end;

class function TFileOperation.IsImage(const FileName: string): boolean;
begin
  if (FileName <> '') then
    Result := SwelioEngine.FileIsImage(PChar(FileName))
      else
        Result := false;
end;

class function TFileOperation.IsUnicodeFile(const FileName: string): boolean;
begin
  if (FileName <> '') then
    Result := SwelioEngine.IsUnicodeFile(PChar(FileName))
      else
        Result := false;
end;

class function TFileOperation.NumberFilesInFolder(FolderName: string): integer;
begin
  Result := SwelioEngine.GetFilesCount(PChar(FolderName));
end;

class function TFileOperation.Rename(OldName, NewName: string): boolean;
begin
  if ( (OldName <> '') and (NewName <> '')) then
    Result := SwelioEngine.FileRename(PChar(OldName), PChar(NewName))
     else
       Result := false;
end;

class procedure TFileOperation.ShellCopyFile(oldName, NewName: string);
begin
  if ((OldName <> '') and (NewName <> '')) then
    SwelioEngine.ShellCopyFile(PChar(oldName), PChar(NewName));
end;

class function TFileOperation.StripName(const FileName: string) : string;
var
  FullName : array[0..MAX_PATH] of char;
begin
  if FileName <> '' then
    begin
      SwelioEngine.StripFileName(PChar(FileName), FullName);
      Result := string(FullName);
    end
     else
       begin
         Result := '';
       end;
end;

class function TFileOperation.ValidFileName(FileName: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.IsValidFileName(PChar(FileName))
      else
       Result := false;
end;

class function TFileOperation.ValidPathName(FileName: string): boolean;
begin
  if FileName <> '' then
    Result := SwelioEngine.IsValidPathName(PChar(FileName))
      else
        Result := false;
end;

end.

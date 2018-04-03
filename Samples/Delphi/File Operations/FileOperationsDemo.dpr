program FileOperationsDemo;

{$APPTYPE CONSOLE}

uses
  SysUtils,
  FileOperations in '..\..\..\Binding\Delphi\FileOperations.pas',
  SwelioEngine in '..\..\..\Binding\Delphi\SwelioEngine.pas';

var
  FileName : string;
begin
  try

    TFileOperation.CreateUnicodeFile('readme.txt');
    if TFileOperation.Exists('readme.txt') then
     begin
       if TFileOperation.IsUnicodeFile('readme.txt') then
        begin
          TFileOperation.ClearAttributes('readme.txt');
          TFileOperation.ShellCopyFile('readme.txt', 'readme.doc');
          TFileOperation.DeleteToRecycleBin('readme.txt', false);
        end;
     end;

    if TFileOperation.GetSize('readme.doc') = 2 then
      begin
        if TFileOperation.ExtensionIs('readme.doc', '.doc') then
          begin
            TFileOperation.Rename('readme.doc', 'readme.txt');
            TFileOperation.Delete('readme.txt');
          end;
      end;

     Write('Please enter the file name: ');
     Readln(FileName);
     Writeln;
     FileName := TFileOperation.StripName(FileName);

     if TFileOperation.ValidFileName(FileName) then
      begin
        TFileOperation.CreateUnicodeFile(FileName);
        Writeln('The file ', TFileOperation.FullPath(FileName), ' was created');
        TFileOperation.Delete(FileName);
      end
        else
          Writeln('The name of the file is not valid');
  except
    on E:Exception do
      Writeln(E.Classname, ': ', E.Message);
  end;
end.

program ASICContainerDemo;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,
  AsicContainer in '..\..\..\Delphi\AsicContainer.pas',
  EidFormatter in '..\..\..\Delphi\EidFormatter.pas',
  EidReader in '..\..\..\Delphi\EidReader.pas',
  SwelioEngine in '..\..\..\Delphi\SwelioEngine.pas',
  SwelioTypes in '..\..\..\Delphi\SwelioTypes.pas';

var
 ctx : TAsicContainer;
begin
  try
    ctx := TAsicContainer.Create;
    ctx.SelectCertificate('test_pkcs12.pfx', 'test');
    ctx.AddFile('test1.pdf');
    ctx.AddFile('test2.pdf');
    ctx.Save('demo.asice');
    ctx.Free;
  except
    on E: Exception do
      Writeln(E.ClassName, ': ', E.Message);
  end;
end.

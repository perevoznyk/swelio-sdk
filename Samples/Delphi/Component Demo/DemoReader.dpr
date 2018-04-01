program DemoReader;

uses
  Forms,
  frm_main in 'frm_main.pas' {frmMain},
  EidFormatter in '..\..\..\Binding\Delphi\EidFormatter.pas',
  EidReader in '..\..\..\Binding\Delphi\EidReader.pas',
  SwelioEngine in '..\..\..\Binding\Delphi\SwelioEngine.pas',
  SwelioTypes in '..\..\..\Binding\Delphi\SwelioTypes.pas';

{$R *.RES}

begin
  Application.Initialize;
  Application.Title := 'EID Demo';
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.

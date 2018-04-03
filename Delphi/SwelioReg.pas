unit SwelioReg;

interface

uses
  Windows,
  SysUtils,
  Classes,
  EidReader;

procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Swelio', [TEidReader]);
end;

end.

unit AsicContainer;

interface

uses
 Windows,
 SwelioEngine,
 Classes;

 type
   TAsicContainer = class
   private
     FCertificateSelected : boolean;
     ctx : pointer;
     FReaderNumber : integer;
   public
     constructor Create; virtual;
     destructor Destroy; override;
     procedure Close;
     property ReaderNumber : integer read FReaderNumber write FReaderNumber;
     function Save(FileName : WideString) : boolean;
     function SelectCertificate(EID : boolean) : boolean; overload;
     function SelectCertificate(FileName : WideString; Password : WideString) : boolean; overload;
     function AddFile(FileName : AnsiString) : boolean;
   end;

implementation

{ TAsicContainer }

function TAsicContainer.AddFile(FileName: AnsiString): boolean;
begin
  result := AddFileToContainer(ctx, PAnsiChar(FileName));
end;

procedure TAsicContainer.Close;
begin
  if (ctx <> nil) then
     begin
       FreeContainer(ctx);
       ctx := nil;
     end;
end;

constructor TAsicContainer.Create;
begin
  inherited Create;
  ctx := InitializeContainer;
end;

destructor TAsicContainer.Destroy;
begin
  Close;
  inherited;
end;

function TAsicContainer.Save(FileName: WideString): boolean;
begin
  result := false;
  if ctx <> nil then
    begin
      result := SaveContainer(ctx, PWideChar(FileName));
    end;
end;

function TAsicContainer.SelectCertificate(EID: boolean): boolean;
begin
  result := false;
  if ctx <> nil then
     begin
       if EID then
         result := ContainerEidCertificate(ctx, ReaderNumber)
           else
             result := ContainerPickCertificate(ctx);
     end;
end;

function TAsicContainer.SelectCertificate(FileName,
  Password: WideString): boolean;
begin
  result := false;
  if ctx <> nil then
    begin
      result := ContainerCertificate(ctx, PWideChar(FileName), PWideChar(password));
    end;
end;

end.

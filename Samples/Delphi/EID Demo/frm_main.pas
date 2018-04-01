unit frm_main;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls,  SwelioEngine, jpeg;

type
  TfrmMain = class(TForm)
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    edtlastName: TLabeledEdit;
    edtFirstName: TEdit;
    imgPerson: TImage;
    edtBirthDate: TLabeledEdit;
    edtBirthPlace: TLabeledEdit;
    edtNationalNumber: TLabeledEdit;
    edtSex: TLabeledEdit;
    edtStreet: TLabeledEdit;
    edtZip: TLabeledEdit;
    edtCity: TEdit;
    edtCardNumber: TLabeledEdit;
    edtFrom: TLabeledEdit;
    edtUntil: TLabeledEdit;
    btnReadCard: TButton;
    btnClose: TButton;
    edtHouseNumber: TEdit;
    edtType: TLabeledEdit;
    edtNationality: TLabeledEdit;
    edtChipNumber: TLabeledEdit;
    edtMunicipality: TLabeledEdit;
    Events: TListBox;
    btnSaveLog: TButton;
    dlgSave: TSaveDialog;
    procedure btnCloseClick(Sender: TObject);
    procedure btnReadCardClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure btnSaveLogClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    procedure LoadUnknownImage;
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.DFM}

procedure HandleReaderCallBack(var ReaderNumber : DWORD; var EventType : DWORD; UserContext : Pointer); stdcall;
begin
  if Assigned(frmMain) then
    begin
      case EventType of
        1 : begin
              frmMain.Events.Items.Add(DateTimeToStr(Now) + ' card inserted');
              ActivateCardEx(ReaderNumber);
              frmMain.btnReadCard.Enabled := true;
            end;
        2 : begin
              frmMain.Events.Items.Add(DateTimeToStr(Now) + ' card removed');
              DeactivateCardEx(ReaderNumber);
              frmMain.btnReadCard.Enabled := false;
            end;
        3:  begin
              frmMain.Events.Items.Add(DateTimeToStr(Now) + ' readers list changed');
              frmMain.btnReadCard.Enabled := false;
              SetCallback(HandleReaderCallBack, nil);
            end;
      end;
    end;
end;

procedure TfrmMain.btnCloseClick(Sender: TObject);
begin
   Close;
end;

procedure TfrmMain.btnReadCardClick(Sender: TObject);
var
  Identity : TEIDIdentity;
  Address : TEIDAddress;
  SisData : TSisRecord;
  Pic : TEIDPicture;
  MS : TMemoryStream;
  Img : TJPEGImage;
  idx : integer;
  Street : string;
begin
  edtlastName.Text  := '';
  edtFirstName.Text := '';
  edtBirthDate.Text := '';
  edtBirthPlace.Text := '';
  edtNationalNumber.Text :=  '';
  edtSex.Text := '';
  edtNationality.Text := '';
  edtMunicipality.Text := '';

  edtStreet.Text := '';
  edtHouseNumber.Text := '';
  edtZip.Text := '';
  edtCity.Text := '';

  edtCardNumber.Text := '';
  edtFrom.Text := '';
  edtUntil.Text := '';
  edtType.Text := '';
  edtChipNumber.Text := '';

  if not IsEIDCard then
   begin
     if not IsSISCard then
       begin
         ShowMessage('Belgian EID card is not detected in the reader');
         Exit;
       end;
   end;

  FillChar(Identity, sizeof(TEIDIdentity), 0);
  FillChar(SisData, sizeof(TSisRecord), 0);

  if IsSISCard then
    begin
      if ReadSISCard(@SisData) then
         begin
          edtlastName.Text := SisData.Name;
          edtFirstName.Text := SisData.FirstName;
          edtBirthDate.Text := FormatEIDDate(SisData.BirthDate);
         end;
      Exit;
    end;

  if ReadIdentity(@Identity) then
   begin
     FillChar(Address, sizeof(TEIDAddress), 0);
     ReadAddress(@Address);

     edtlastName.Text := Identity.name;
     edtFirstName.Text := Identity.firstName1;
     edtBirthDate.Text := FormatEIDDate(Identity.birthDate);
     edtBirthPlace.Text := Identity.birthLocation;
     edtNationalNumber.Text := FormatNationalNumber(Identity.nationalNumber);
     edtSex.Text := Identity.sex;
     edtNationality.Text := Identity.nationality;
     edtMunicipality.Text := Identity.municipality;

     edtCardNumber.Text := FormatCardNumber(Identity.cardNumber);
     edtFrom.Text := FormatEIDDate(Identity.validityDateBegin);
     edtUntil.Text := FormatEIDDate(Identity.validityDateEnd);
     edtType.Text := DocumentTypeToString(Identity.documentType);
     edtChipNumber.Text := Identity.chipNumber;

     Street := Address.Street;
     Street := Trim(Street);
     idx := length(Street);

    while idx > 0 do
     begin
       if Street[idx] = ' ' then
        break
          else
            dec(idx);
     end;

     if idx > 1 then
      begin
         edtHouseNumber.Text := Copy(Street, idx +1, MaxInt);
         if Length(edtHouseNumber.Text) > 0 then
           begin
             if edtHouseNumber.Text[1] = '/' then
               edtHouseNumber.Text := Copy(edtHouseNumber.Text, 2, Length(edtHouseNumber.Text) - 1);
           end;
         edtStreet.Text := Copy(Street, 1, idx -1);
      end
        else
          edtStreet.Text := Street;

       edtZip.Text := Address.zip;
       edtCity.Text := Address.municipality;
   end;


   if ReadPhoto(@Pic) then
    begin
       MS := TMemoryStream.Create;
       MS.Write(Pic.picture, Pic.pictureLength);
       MS.Position := 0;
       Img := TJPEGImage.Create;
       Img.LoadFromStream(MS);
       imgPerson.Stretch := true;
       imgPerson.Picture.Assign(Img);
       Img.Free;
       MS.Free;
    end;

end;

procedure TfrmMain.btnSaveLogClick(Sender: TObject);
begin
  if (dlgSave.Execute) then
   begin
     Events.Items.SaveToFile(dlgSave.FileName);
   end;
end;

procedure TfrmMain.LoadUnknownImage;
var
  B : TBitmap;
begin
   B := TBitmap.Create;
    try
      B.Width  := 114;
      B.Height := 114;
      B.Canvas.Brush.Color := Self.Color;
      B.Canvas.FillRect(B.Canvas.ClipRect);
      imgPerson.Stretch := false;
      imgPerson.Picture.Bitmap.Assign(B);
    finally
      B.Free;
    end;
end;

procedure TfrmMain.FormCreate(Sender: TObject);
var
  cnt : integer;
  TotalReaders : integer;
  len : integer;
  buffer : PChar;
begin
  LoadUnknownImage;
  StartEngine;
  TotalReaders := GetReadersCount;
  Events.Items.Add(DateTimeToStr(Now) + ' ' + IntToStr(TotalReaders) + ' card readers detected');
  for cnt := 0 to TotalReaders - 1 do
    begin
      len := GetReaderNameLen(cnt);
      Buffer := AllocMem(len * sizeof(char));
      GetReaderName(cnt, Buffer, len);
      Events.Items.Add(DateTimeToStr(Now) + ' ' + Buffer);
      FreeMem(Buffer);
    end;
  SetCallback(HandleReaderCallBack, nil);
end;

procedure TfrmMain.FormDestroy(Sender: TObject);
begin
  RemoveCallback;
  StopEngine;
end;

end.

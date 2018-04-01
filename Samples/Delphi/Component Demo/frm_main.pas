unit frm_main;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, jpeg, EidReader, SwelioTypes;

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
    EidReader: TEidReader;
    procedure btnCloseClick(Sender: TObject);
    procedure btnReadCardClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure btnSaveLogClick(Sender: TObject);
    procedure EidReaderCardInserted(Sender: TObject; ReaderNumber: Integer);
    procedure EidReaderCardRemoved(Sender: TObject; ReaderNumber: Integer);
    procedure EidReaderReadersListChanged(Sender: TObject;
      ReaderNumber: Integer);
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

procedure TfrmMain.EidReaderCardInserted(Sender: TObject;
  ReaderNumber: Integer);
begin
  Events.Items.Add(DateTimeToStr(Now) + ' card inserted');
  EidReader.Activate(ReaderNumber);
  btnReadCard.Enabled := true;
end;

procedure TfrmMain.EidReaderCardRemoved(Sender: TObject; ReaderNumber: Integer);
begin
  Events.Items.Add(DateTimeToStr(Now) + ' card removed');
  EidReader.Deactivate(ReaderNumber);
  btnReadCard.Enabled := false;
end;

procedure TfrmMain.EidReaderReadersListChanged(Sender: TObject;
  ReaderNumber: Integer);
begin
  Events.Items.Add(DateTimeToStr(Now) + ' readers list changed');
  btnReadCard.Enabled := false;
  EidReader.TraceEvents := true;
end;

procedure TfrmMain.btnCloseClick(Sender: TObject);
begin
   Close;
end;

procedure TfrmMain.btnReadCardClick(Sender: TObject);
var
  Identity : TPersonInfo;
  Address : TAddressInfo;
  Pic : TBitmap;
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

  if not EidReader.IsCardInserted(0) then
   begin
     ShowMessage('Belgian EID card is not detected in the reader');
     Exit;
   end;

  Identity := EidReader.GetPersonInfo(0);
  Address := EidReader.GetAddressInfo(0);

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
  EidReader.TraceEvents := false;
end;

end.

//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

unit EidReader;

interface

uses
  Windows, SysUtils, Classes, Controls, Graphics,
  SwelioEngine, SwelioTypes;

type
  TEidEvent = procedure (Sender : TObject; ReaderNumber : integer) of object;

  TEidReader = class(TComponent)
  private
    FReaders : TStringList;
    FOnCardRemoved: TEidEvent;
    FOnCardInserted: TEidEvent;
    FOnReadersListChanged: TEidEvent;
    FTraceEvents : boolean;
    FTraceLoading : boolean;
    function GetReader(Index: Integer): string;
    function GetReaderCount: Integer;
    procedure SetTraceEvents(const Value: boolean);
  protected
    procedure RetrieveReadersList;
    procedure DoCardEvent(ReaderNumber : DWORD; EventCode : TCardEventType);
    procedure StartEventsTracing;
    procedure StopEventsTracing;
    procedure Loaded; override;
  public
    constructor Create(AOwner : TComponent); override;
    destructor Destroy; override;
    function Activate(ReaderNumber : integer) : boolean;
    procedure Deactivate(ReaderNumber : integer);
    function IsCardInserted(ReaderNumber : integer) : boolean;
    function GetPersonInfo(ReaderNumber : integer) : TPersonInfo;
    function GetAddressInfo(ReaderNumber : integer) : TAddressInfo;
    function GetPicture : TBitmap;
    function SaveQRCode(const FileName : string) : boolean;
    property Readers[Index: Integer]: string read GetReader;
    property ReaderCount: Integer read GetReaderCount;
  published
    property TraceEvents : boolean read FTraceEvents write SetTraceEvents default false;
    property OnCardInserted : TEidEvent read FOnCardInserted write FOnCardInserted;
    property OnCardRemoved : TEidEvent read FOnCardRemoved write FOnCardRemoved;
    property OnReadersListChanged : TEidEvent read FOnReadersListChanged write FOnReadersListChanged;
  end;

implementation


{ TEidReader }

function TEidReader.Activate(ReaderNumber: integer): boolean;
begin
   Result := ActivateCardEx(ReaderNumber);
   if Result then
    SelectReader(ReaderNumber);
end;

constructor TEidReader.Create(AOwner: TComponent);
begin
  inherited;
  FTraceEvents := false;
  FReaders := TStringList.Create;
  RetrieveReadersList;
end;

procedure TEidReader.Deactivate(ReaderNumber: integer);
begin
  DeactivateCardEx(ReaderNumber);
end;

destructor TEidReader.Destroy;
begin
  RemoveCallback;
  FReaders.Free;
  inherited;
end;

procedure TEidReader.DoCardEvent(ReaderNumber : DWORD; EventCode : TCardEventType);
begin
  case EventCode of
    ewtCardInsert :
     begin
       if Assigned(FOnCardInserted) then
        FOnCardInserted(Self, ReaderNumber);
     end;
    ewtCardRemove :
     begin
       if Assigned(FOnCardRemoved) then
        FOnCardRemoved(Self, ReaderNumber);
     end;
    ewtReadersChange:
     begin
       if Assigned(FOnReadersListChanged) then
         FOnReadersListChanged(Self, ReaderNumber);
     end;
  end;
end;

function TEidReader.SaveQRCode(const FileName : string) : boolean;
begin
  Result := GenerateQRCode(PChar(FileName));
end;

function TEidReader.GetAddressInfo(ReaderNumber: integer): TAddressInfo;
var
  AddressTag : TEIDAddress;
begin
  if ReadAddress(@AddressTag) then
   begin
     Result.Street := AddressTag.Street;
     Result.Zip := AddressTag.Zip;
     Result.Municipality := AddressTag.Municipality;
   end;
end;

function TEidReader.GetPersonInfo(ReaderNumber: integer): TPersonInfo;
var
  PersonTag : TEIDIdentity;
begin
   if ReadIdentity(@PersonTag) then
     begin
       Result.CardNumber := PersonTag.CardNumber;
       Result.ChipNumber := PersonTag.ChipNumber;
       Result.ValidityDateBegin := StrToDate(PersonTag.ValidityDateBegin);
       Result.ValidityDateEnd := StrToDate(PersonTag.ValidityDateEnd);
       Result.Municipality := PersonTag.Municipality;
       Result.NationalNumber := PersonTag.NationalNumber;
       Result.Name := PersonTag.Name;
       Result.FirstName1 := PersonTag.FirstName1;
       Result.FirstName2 := PersonTag.FirstName2;
       Result.Nationality := PersonTag.Nationality;
       Result.BirthLocation := PersonTag.BirthLocation;
       Result.BirthDate := StrToDate(PersonTag.BirthDate);
       if IsMale(@PersonTag) then
        Result.Sex := gtMale
          else
            Result.Sex := gtFemale;
       Result.NobleCondition := PersonTag.NobleCondition;
       case PersonTag.DocumentType of
         1: Result.DocumentType := dtBelgianCitizen;
         2: Result.DocumentType := dtEuropeanCommunity;
         3: Result.DocumentType := dtNonEuropeanCommunity;
         4: Result.DocumentType := dtKidsCard;
         6: Result.DocumentType := dtKidsCard;
         7: Result.DocumentType := dtBootstrapCard;
         8: Result.DocumentType := dtHabilitationCard;
        11: Result.DocumentType := dtForeignerCard;
        12: Result.DocumentType := dtForeignerCard;
        13: Result.DocumentType := dtForeignerCard;
        14: Result.DocumentType := dtForeignerCard;
        15: Result.DocumentType := dtForeignerCard;
        16: Result.DocumentType := dtForeignerCard;
        17: Result.DocumentType := dtForeignerCard;
        18: Result.DocumentType := dtForeignerCard;
         else
           Result.DocumentType := dtUnknown;
      end;
      Result.WhiteCane := PersonTag.WhiteCane;
      Result.YellowCane := PersonTag.YellowCane;
      Result.ExtendedMinority := PersonTag.ExtendedMinority;
     end;
end;

function TEidReader.GetPicture: TBitmap;
var
  Bitmap : HBITMAP;
begin
  Result := nil;
  Bitmap := ReadPhotoAsBitmap;
  if Bitmap <> 0 then
    begin
      Result := TBitmap.Create;
      Result.Handle := Bitmap;
    end;
end;

function TEidReader.GetReader(Index: Integer): string;
begin
  if (Index < FReaders.Count) then
    Result := FReaders[Index]
      else
        Result := '';
end;

function TEidReader.GetReaderCount: Integer;
begin
  Result := FReaders.Count;
end;

function TEidReader.IsCardInserted(ReaderNumber: integer): boolean;
begin
  Result := IsCardPresentEx(ReaderNumber);
end;

procedure TEidReader.Loaded;
begin
  inherited;
  if FTraceLoading then
   TraceEvents := true;
end;

procedure TEidReader.RetrieveReadersList;
var
  I : integer;
  L : integer;
  P : PChar;
  St : string;
begin
  if ( not (csDesigning in ComponentState) ) then
    begin
      FReaders.Clear;
      for I := 0 to SwelioEngine.GetReadersCount - 1 do
       begin
         L := SwelioEngine.GetReaderNameLen(I);
         P := AllocMem(L);
         GetReaderName(I, P, L);
         St := StringOfChar(#0, L);
         Move(P^, St[1], L);
         FreeMem(P);
         FReaders.Add(St);
       end;
    end;
end;


procedure ReaderCallback(var ReaderNumber : DWORD; var EventCode : DWORD; UserContext : Pointer); stdcall;
var
  Reader : TEidReader;

begin
  Reader := TEidreader(UserContext);
  if Reader <> nil then
    begin
      Reader.DoCardEvent(ReaderNumber, TCardEventType(EventCode));
    end;
end;

procedure TEidReader.SetTraceEvents(const Value: boolean);
begin
  if (csReading in ComponentState) then
    begin
      FTraceLoading := true;
    end
      else
         begin
          FTraceEvents := Value;
          if Value then
            StartEventsTracing
              else
                StopEventsTracing;
         end;
end;

procedure TEidReader.StartEventsTracing;
begin
  if ( not (csDesigning in ComponentState)) then
    begin
      SetCallback(ReaderCallback, Self);
    end;
end;

procedure TEidReader.StopEventsTracing;
begin
  if (not (csDesigning in ComponentState)) then
    begin
      RemoveCallback;
    end;
end;

initialization
  StartEngine;
finalization
  StopEngine;
end.

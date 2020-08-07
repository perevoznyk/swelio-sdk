//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

unit SwelioEngine;

interface

uses
 Windows, SysUtils;

const
  // Maximum length of the card number field
  EID_MAX_CARD_NUMBER_LEN = 12;
  // Maximum length of the chip number field
  EID_MAX_CHIP_NUMBER_LEN = 32;
  // Maximum length of the begin date field
  EID_MAX_DATE_BEGIN_LEN = 10;
  // Maximum length of the end date field
  EID_MAX_DATE_END_LEN = 10;
  // Maximum length of the name of the devivery municipality
  EID_MAX_DELIVERY_MUNICIPALITY_LEN = 80;
  // Maximum length of the national number
  EID_MAX_NATIONAL_NUMBER_LEN = 11;
  // Maximum length of the surname
  EID_MAX_NAME_LEN = 110;
  // Maximum length of the first name
  EID_MAX_FIRST_NAME1_LEN = 95;
  // Maximum length of the first name
  EID_MAX_FIRST_NAME2_LEN = 3;
  // Maximum length of the nationality
  EID_MAX_NATIONALITY_LEN = 85;
  // Maximum length of the birthplace
  EID_MAX_BIRTHPLACE_LEN = 80;
  // Maximum length of the birthdate
  EID_MAX_BIRTHDATE_LEN = 12;
  // Maximum length of the sex field
  EID_MAX_SEX_LEN = 1;
  // Maximum length of the noble condition field
  EID_MAX_NOBLE_CONDITION_LEN = 50;
  // Maximum length of the document type field
  EID_MAX_DOCUMENT_TYPE_LEN = 2;
  // Maximum length of the special status field
  EID_MAX_SPECIAL_STATUS_LEN = 2;

  // Maximum length of the street name field
  EID_MAX_STREET_LEN = 80;
  // Maximum length of the ZIP code field
  EID_MAX_ZIP_LEN = 4;
  // Maximum length of the municipality name field
  EID_MAX_MUNICIPALITY_LEN = 67;


  // Maximum length of the picture data
  EID_MAX_PICTURE_LEN = 4096;
  // Maximum length of the certificate data
  EID_MAX_CERT_LEN = 2048;

type

  //The smart card reader callback procedure
  TReaderCallback = procedure(var ReaderNumber : DWORD; var EventCode : DWORD; UserContext : Pointer); stdcall;

  //The type of the reader event
  TCardEventType = (
  //Unknown event
  ewtUnknownEvent,
  //Card was inserted in the reader
	ewtCardInsert,
  //Card was removed from the reader
  ewtCardRemove,
  //The readers list changed
	ewtReadersChange);


  // Identity information stored on EID card
  tagEidIdentityA =
    record
      // Electronic ID card number
      CardNumber : array[0..EID_MAX_CARD_NUMBER_LEN] of AnsiChar;
      // Electronic ID card physical chip number
      ChipNumber : array[0..EID_MAX_CHIP_NUMBER_LEN] of AnsiChar;
      // Card validity date begin
      ValidityDateBegin : array[0..EID_MAX_DATE_BEGIN_LEN] of AnsiChar;
      // Card validity date end
      ValidityDateEnd : array[0..EID_MAX_DATE_END_LEN] of AnsiChar;
      // Card delivery municipality
      Municipality : array[0..EID_MAX_DELIVERY_MUNICIPALITY_LEN] of AnsiChar;
      // National number
      NationalNumber : array[0..EID_MAX_NATIONAL_NUMBER_LEN] of AnsiChar;
      // Surname
      Name : array[0..EID_MAX_NAME_LEN] of AnsiChar;
      // First name (2 first given names)
      FirstName1 : array[0..EID_MAX_FIRST_NAME1_LEN] of AnsiChar;
      // First name part 2 (first letter of the 3rd given name).
      FirstName2 : array[0..EID_MAX_FIRST_NAME2_LEN] of AnsiChar;
      // Nationality
      Nationality : array[0..EID_MAX_NATIONALITY_LEN] of AnsiChar;
      // Birth location
      BirthLocation : array[0..EID_MAX_BIRTHPLACE_LEN] of AnsiChar;
      // Birth date
      BirthDate : array[0..EID_MAX_BIRTHDATE_LEN] of AnsiChar;
      // Sex
      Sex : array[0..EID_MAX_SEX_LEN] of AnsiChar;
      // Noble condition
      NobleCondition : array[0..EID_MAX_NOBLE_CONDITION_LEN] of AnsiChar;
      // Document type code (Belgian citizen card, Kids Card, Foreigner card)
      DocumentType : Longint;
      // White cane (blind people)
      WhiteCane : BOOL;
      // Yellow cane (partially sighted people)
      YellowCane : BOOL;
      // Extended minority
      ExtendedMinority : BOOL;
    end;

  // Identity information stored on EID card
  tagEidIdentityW =
    record
      // Electronic ID card number
      CardNumber : array[0..EID_MAX_CARD_NUMBER_LEN] of WideChar;
      // Electronic ID card physical chip number
      ChipNumber : array[0..EID_MAX_CHIP_NUMBER_LEN] of WideChar;
      // Card validity date begin
      ValidityDateBegin : array[0..EID_MAX_DATE_BEGIN_LEN] of WideChar;
      // Card validity date end
      ValidityDateEnd : array[0..EID_MAX_DATE_END_LEN] of WideChar;
      // Card delivery municipality
      Municipality : array[0..EID_MAX_DELIVERY_MUNICIPALITY_LEN] of WideChar;
      // National number
      NationalNumber : array[0..EID_MAX_NATIONAL_NUMBER_LEN] of WideChar;
      // Surname
      Name : array[0..EID_MAX_NAME_LEN] of WideChar;
      // First name (2 first given names)
      FirstName1 : array[0..EID_MAX_FIRST_NAME1_LEN] of WideChar;
      // First name part 2 (first letter of the 3rd given name).
      FirstName2 : array[0..EID_MAX_FIRST_NAME2_LEN] of WideChar;
      // Nationality
      Nationality : array[0..EID_MAX_NATIONALITY_LEN] of WideChar;
      // Birth location
      BirthLocation : array[0..EID_MAX_BIRTHPLACE_LEN] of WideChar;
      // Birth date
      BirthDate : array[0..EID_MAX_BIRTHDATE_LEN] of WideChar;
      // Sex
      Sex : array[0..EID_MAX_SEX_LEN] of WideChar;
      // Noble condition
      NobleCondition : array[0..EID_MAX_NOBLE_CONDITION_LEN] of WideChar;
      // Document type code (Belgian citizen card, Kids Card, Foreigner card)
      DocumentType : Longint;
      // White cane (blind people)
      WhiteCane : BOOL;
      // Yellow cane (partially sighted people)
      YellowCane : BOOL;
      // Extended minority
      ExtendedMinority : BOOL;
    end;

  // Identity information stored on EID card
  TEIDIdentityA = tagEidIdentityA;
  // Identity information stored on EID card
  PEIDIdentityA = ^TEIDIdentityA;
  // Identity information stored on EID card
  TEIDIdentityW = tagEidIdentityW;
  // Identity information stored on EID card
  PEIDIdentityW = ^TEIDIdentityW;

{$IFDEF UNICODE}
  // Identity information stored on EID card
  TEIDIdentity = TEIDIdentityW;
  // Identity information stored on EID card
  PEIDIdentity = ^TEIDIdentityW;
{$ELSE}
  // Identity information stored on EID card
  TEIDIdentity = TEIDIdentityA;
  // Identity information stored on EID card
  PEIDIdentity = ^TEIDIdentityA;
{$ENDIF}

  // EID address information, stored on the card
  tagEidAddressA =
    record
      // Street name
      Street : array[0..EID_MAX_STREET_LEN] of AnsiChar;
      // ZIP code
      Zip : array[0..EID_MAX_ZIP_LEN] of AnsiChar;
      // Municipality
      Municipality : array[0..EID_MAX_MUNICIPALITY_LEN] of AnsiChar;
    end;

  // EID address information, stored on the card
  tagEidAddressW =
    record
      // Street name
      Street : array[0..EID_MAX_STREET_LEN] of WideChar;
      // ZIP code
      Zip : array[0..EID_MAX_ZIP_LEN] of WideChar;
      // Municipality
      Municipality : array[0..EID_MAX_MUNICIPALITY_LEN] of WideChar;
    end;

  // EID address information, stored on the card
  TEIDAddressA = tagEidAddressA;
  // EID address information, stored on the card
  PEIDAddressA = ^TEIDAddressA;
  // EID address information, stored on the card
  TEIDAddressW = tagEidAddressW;
  // EID address information, stored on the card
  PEIDAddressW = ^TEIDAddressW;

{$IFDEF UNICODE}
  // EID address information, stored on the card
  TEIDAddress = TEIDAddressW;
  // EID address information, stored on the card
  PEIDAddress = ^TEIDAddressW;
{$ELSE}
  // EID address information, stored on the card
  TEIDAddress = TEIDAddressA;
  // EID address information, stored on the card
  PEIDAddress = ^TEIDAddressA;
{$ENDIF}

  // Raw picture data from EID card
  tagEidPicture =
  record
    // Picture raw data buffer
    Picture : array[0..EID_MAX_PICTURE_LEN] of byte;
    // Picture raw data buffer length
    PictureLength : integer;
  end;

  // Raw picture data from EID card
  TEIDPicture = tagEidPicture;
  // Raw picture data from EID card
  PEIDPicture = ^TEIDPicture;

  // Certificate, stored on EID card
  tagEidCertificate =
  record
     // Certificate raw data buffer
     Certificate : array[0..EID_MAX_CERT_LEN] of byte;
     // Certificate data length
     CertificateLength : integer;
  end;

  // Certificate, stored on EID card
  TEIDCertificate = tagEidCertificate;
  // Certificate, stored on EID card
  PEIDCertificate = ^TEIDCertificate;


const
  // Maximum length of the surname field
  SIS_MAX_NAME_LEN = 48;
  // Maximum length of the first name field
  SIS_MAX_FIRSTNAMES_LEN = 24;
  // Maximum length of the initial field
  SIS_MAX_INITIAL_LEN = 1;
  // Maximum length of the sex field
  SIS_MAX_SEX_LEN = 1;
  // Maximum length of the card name field
  SIS_MAX_CARDNAME_LEN = 6;
  // Maximum length of the birth date field
  SIS_FIELD_MAX_BIRTHDATE_LEN = 8;
  // Maximum length of the capture date field
  SIS_FIELD_MAX_CAPTUREDATE_LEN = 8;
  // Maximum length of the start validity date field
  SIS_FIELD_MAX_VALIDBEGIN_LEN = 8;
  // Maximum length of the end validity date field
  SIS_FIELD_MAX_VALIDEND_LEN = 8;
  // Maximum length of the social security number field
  SIS_FIELD_MAX_SOCIAL_SECURITY_NUMBER_LEN = 11;
  // Maximum length of the car number field
  SIS_FIELD_MAX_CARDNUMBER_LEN = 10;

type
  //Public information stored on Belgian SIS card.
  //The SIS card is the social security card of each Belgian resident
  //(Belgian or foreigner)
  tagSISRecordA = record
    //Family name of the card owner
    Name :                 array[0..SIS_MAX_NAME_LEN] of AnsiChar;
    //First name of the card owner
    FirstName :            array[0..SIS_MAX_FIRSTNAMES_LEN] of AnsiChar;
    //Initial of the card owner
    Initial :              array[0..SIS_MAX_INITIAL_LEN] of AnsiChar;
    //Sex of the card owner
    Sex :                  array[0..SIS_MAX_SEX_LEN] of AnsiChar;
    //Birth date of the card owner
    BirthDate :            array[0..SIS_FIELD_MAX_BIRTHDATE_LEN] of AnsiChar;
    //Social security number of the card owner
    SocialSecurityNumber : array[0..SIS_FIELD_MAX_SOCIAL_SECURITY_NUMBER_LEN] of AnsiChar;
    //Date of issue
    CaptureDate :          array[0..SIS_FIELD_MAX_CAPTUREDATE_LEN] of AnsiChar;
    //Card validity begin date
    ValidityDateBegin :    array[0..SIS_FIELD_MAX_VALIDBEGIN_LEN] of AnsiChar;
    //Card validity end date
    ValidityDateEnd :      array[0..SIS_FIELD_MAX_VALIDEND_LEN] of AnsiChar;
    //Card number
    CardNumber :           array[0..SIS_FIELD_MAX_CARDNUMBER_LEN] of AnsiChar;
    //Name of the card
    CardName :             array[0..SIS_MAX_CARDNAME_LEN] of AnsiChar;
  end;

  //Public information stored on Belgian SIS card.
  //The SIS card is the social security card of each Belgian resident
  //(Belgian or foreigner)
  tagSISRecordW = record
    //Family name of the card owner
    Name :                 array[0..SIS_MAX_NAME_LEN] of WideChar;
    //First name of the card owner
    FirstName :            array[0..SIS_MAX_FIRSTNAMES_LEN] of WideChar;
    //Initial of the card owner
    Initial :              array[0..SIS_MAX_INITIAL_LEN] of WideChar;
    //Sex of the card owner
    Sex :                  array[0..SIS_MAX_SEX_LEN] of WideChar;
    //Birth date of the card owner
    BirthDate :            array[0..SIS_FIELD_MAX_BIRTHDATE_LEN] of WideChar;
    //Social security number of the card owner
    SocialSecurityNumber : array[0..SIS_FIELD_MAX_SOCIAL_SECURITY_NUMBER_LEN] of WideChar;
    //Date of issue
    CaptureDate :          array[0..SIS_FIELD_MAX_CAPTUREDATE_LEN] of WideChar;
    //Card validity begin date
    ValidityDateBegin :    array[0..SIS_FIELD_MAX_VALIDBEGIN_LEN] of WideChar;
    //Card validity end date
    ValidityDateEnd :      array[0..SIS_FIELD_MAX_VALIDEND_LEN] of WideChar;
    //Card number
    CardNumber :           array[0..SIS_FIELD_MAX_CARDNUMBER_LEN] of WideChar;
    //Name of the card
    CardName :             array[0..SIS_MAX_CARDNAME_LEN] of WideChar;
  end;

  //Public information stored on Belgian SIS card
  TSISRecordA = tagSISRecordA;
  //Public information stored on Belgian SIS card
  PSISRecordA = ^TSISRecordA;
  //Public information stored on Belgian SIS card
  TSISRecordW = tagSISRecordW;
  //Public information stored on Belgian SIS card
  PSISRecordW = ^TSISRecordW;

{$IFDEF UNICODE}
  //Public information stored on Belgian SIS card
  TSISRecord = TSISRecordW;
  //Public information stored on Belgian SIS card
  PSISRecord = ^TSISRecordW;
{$ELSE}
  //Public information stored on Belgian SIS card
  TSISRecord = TSISRecordA;
  //Public information stored on Belgian SIS card
  PSISRecord = ^TSISRecordA;
{$ENDIF}

// Summary:
//		Set the compatibility mode with the old version of the oficial EID MiddleWare
// Description:
//		The compatibility mode can be useful when the MiddleWare version 1.x or 2.x is installed on the target PC.
//		Usually the more recent MiddleWare is used and this function is provided for backward compatibility only
procedure SetMWCompatibility(); stdcall;

// Summary:
//     Activates the Swelio Engine. 
// Description:
//     This procedure must be called first before any other functions from
//     Swelio library can be used. 
// Return Value:
//     Returns TRUE if the Swelio Engine is successfully started; otherwize returns FALSE 
function  StartEngine() : BOOL; stdcall;

// Summary:
//     Deactivates the Swelio Engine
// Description:
//     Deactivates the Swelio Engine and clean up the used memory. Call this procedure at the end of you application 
//     once to finalize the usage of the Swelio Engine.
procedure StopEngine(); stdcall;

// Summary:
//     Checks if the Swelio Engine is activated
// Description:
//     This function checks if the Engine already activated using the StartEngine function.
// Return Value:
//     Returns TRUE if the Swelio Engine is active, otherwise returns FALSE.
function  IsEngineActive() : BOOL; stdcall;

// Summary:
//      Get number of card readers connected to PC
// Description:
//      Checks how many smart card readers are connected to PC. If there is no readers connected then
//      the usage of the Swelio Engine is not possible. The engine can control the change of the number of the card
//      readers and can raise an event when the reader is connected or disconnected from PC
// Return Value:
//      The number of the connected smart card readers
function  GetReadersCount() : integer; stdcall;

// Summary:
//      When more than 1 reader connected, select the reader with specified number
//      The first reader has number 0
// Arguments:
//      readerNumber - The reader index, starting from 0
// Return Value:
//      TRUE if the reader is selected, FALSE if the reader with specified number does not exist
function  SelectReader(ReaderNumber : integer) : BOOL; stdcall;

// Summary:
//      Returns the index of the active smart card reader
// Return Value:
//      The number of the selected card reader. The first reader has number 0.
function  GetSelectedReaderIndex() : integer; stdcall;

// Summary:
//      Select active smart card reader by providing the reader name
// Description:
//      Activates the reader with specified name
// Arguments:
//      ReaderName - The name of the card reader
// Return Value:
//      Returns TRUE if the reader is selected. If the reader with specified name is not found - returns FALSE
function  SelectReaderByName(ReaderName : PChar) : BOOL; stdcall;

// Summary:
//      Select active smart card reader by providing the reader name
// Arguments:
//      Reader Name - the name of the card reader
// Return Value:
//      TRUE if the reader is selected, FALSE if the reader with specified number does not exist
function  SelectReaderByNameW(ReaderName : PWideChar) : BOOL; stdcall;

// Summary:
//      Select active smart card reader by providing the reader name
// Arguments:
//      ReaderName - the name of the card reader
// Return Value:
//      TRUE if the reader is selected, FALSE if the reader with specified number does not exist
function  SelectReaderByNameA(ReaderName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Returns the length of the reader name 
// Description:
//      Returns the length of the reader name for the smart card reader with specified zero-based index
// Arguments:
//	    ReaderNumber - The zero-based index of the card reader
// Return Value:
//      The length of the reader name
function  GetReaderNameLen(ReaderNumber : integer) : integer; stdcall;

// Summary:
//      Returns the length of the reader name
// Description:
//      Returns the length of the reader name for the smart card reader with specified zero-based index
// Arguments:
//	    ReaderNumber - The zero-based index of the card reader
// Return Value:
//      The length of the reader name
function  GetReaderNameLenA(ReaderNumber : integer) : integer; stdcall;

// Summary:
//      Returns the length of the reader name
// Description:
//      Returns the length of the reader name for the smart card reader with specified zero-based index
// Arguments:
//	    ReaderNumber - The zero-based index of the card reader
// Return Value:
//      The length of the reader name
function  GetReaderNameLenW(ReaderNumber : integer) : integer; stdcall;

// Summary:
//		Returns the name of the reader
// Arguments:
//		ReaderNumber - index of the reader
//		StrDest - Destination string
//		Count - Number of characters to be copied
function  GetReaderName(ReaderNumber : integer; StrDest : PChar; Count : integer) : integer; stdcall;

// Summary:
//		Returns the name of the reader
// Arguments:
//		ReaderNumber - index of the reader
//		StrDest - Destination string
//		Count - Number of characters to be copied
function  GetReaderNameA(ReaderNumber : integer; StrDest : PAnsiChar; Count : integer) : integer; stdcall;

// Summary:
//		Returns the name of the reader
// Arguments:
//		ReaderNumber - index of the reader
//		StrDest - Destination string
//		Count - Number of characters to be copied
function  GetReaderNameW(ReaderNumber : integer; StrDest : PWideChar; Count : integer) : integer; stdcall;

// Summary: 
//     Checks if the SIS cards are supported by the engine   
// Description:
//	   The SIS card reading operation takes more time than the reading of the eID card. 
//     By default when the card is inserted in the reader the engine will try to detect the card type and 
//     the card insertion event will be raised for eID cards only. If you want to support the SIS cards in your 
//     application then you have to activate it using SetSupportSIS function.
//     Use GetSupportSIS function to check if the SIS card support is activated.
// Return Value:
//     Returns TRUE if SIS card support is activated, otherwise returns FALSE
function  GetSupportSIS() : BOOL; stdcall;

// Summary:
// 	   Activates or deactivates SIS card support by engine
// Description:
//     Use SetSupportSIS to activate or deactivate the SIS card detection and reading.
//     Even if SIS card support is activated it can be used only with ACR38U card readers
//     Other card readers are not supported.
// Arguments:
//     value - The SIS card support status
procedure SetSupportSIS(Value : BOOL); stdcall;

// Summary:
//     Checks if the card is present in the card reader
// Description:
//     Use IsCardPresent function to check if the card is inserted in the card reader or not
// Return Value:
//     Returns TRUE if the card is inserted in the reader, otherwise returns FALSE
function  IsCardPresent() : BOOL; stdcall;

// Summary:
//     Checks if the card is present in the card reader
// Description:
//     Use isCardPresent function to check if the card is inserted in the card reader or not
// Arguments:
//		readerNumber - The zero-based index of the card reader
// Return Value:
//     Returns TRUE if the card is inserted in the reader, otherwise returns FALSE
function  IsCardPresentEx(ReaderNumber : integer) : BOOL; stdcall;

// Summary:
//    Returns the zero-based reader index with specified name
// Description:
//    Use this function to get the zero-based index of the card reader with specified name
// Arguments:
//    readerName - The name of the reader
// Return Value:
//    The zero-based reader index
function  GetReaderIndex(ReaderName : PChar) : integer; stdcall;

// Summary:
//    Returns the zero-based reader index with specified name
// Description:
//    Use this function to get the zero-based index of the card reader with specified name
// Arguments:
//    readerName - The name of the reader
// Return Value:
//    The zero-based reader index
function  GetReaderIndexW(ReaderName : PWideChar) : integer; stdcall;

// Summary:
//    Returns the zero-based reader index with specified name
// Description:
//    Use this function to get the zero-based index of the card reader with specified name
// Arguments:
//    readerName - The name of the reader
// Return Value:
//    The zero-based reader index
function  GetReaderIndexA(ReaderName : PAnsiChar) : integer; stdcall;

// Summary:
//   Established communication between the card and the reader
//   Description:
//   The ActivateCard function establishes a connection between
//   the calling application and a smart card contained by a
//   specific reader. If no card exists in the specified reader,
//   an error is returned.
//   Return Value:
//   Returns TRUE if the card is activated, otherwise returns
//   FALSE
function  ActivateCard() : BOOL; stdcall;

// Summary:
//    Established communication between the card and the reader
// Description:
//   The ActivateCard function establishes a connection between the calling application and a smart card contained 
//   by a specific reader. If no card exists in the specified reader, an error is returned.
// Arguments:
//	 readerNumber - The zero-based index of the card reader
// Return Value:
//   Returns TRUE if the card is activated, otherwise returns FALSE
function  ActivateCardEx(ReaderNumber : integer) : BOOL; stdcall;

// Summary:
//     Terminates a cennection between a smart card and a reader
// Description:
//     The DeactivateCard function terminates a connection previously opened between the calling application and a smart card in the target reader.
procedure DeactivateCard(); stdcall;

// Summary:
//     Terminates a connection between a smart card and a reader
// Description:
//     The DeactivateCard function terminates a connection previously opened between the calling application and a smart card in the target reader.
// Arguments:
//	 readerNumber - The zero-based index of the card reader
procedure DeactivateCardEx(ReaderNumber : integer); stdcall;

// Summary:
//      Check if Belgian EID card is inserted into card reader
// Description:
//      If the card is inserted in the reader, this function performs the card
//      type check.
// Return Value:
//      Returns TRUE, if Belgian eID card is inserted in the reader. If there is
//      no card in the reader or the card of other type is inserted, returns FALSE
function  IsEIDCard() : BOOL; stdcall;

// Summary:
//    Check if Belgian SIS card is inserted into card reader
// Description:
//    If the card is inserted in the reader, this function performs the card
//    type check.
// Return Value:
//    Returns TRUE, if Belgian SIS card is inserted in the reader. If there is
//    no card in the reader or the card of other type is inserted, returns FALSE
function  IsSISCard() : BOOL; stdcall;

// Summary:
//    Check if Belgian EID card is inserted into card reader
// Description:
//    If the card is inserted in the reader, this function performs the card
//    type check.
// Arguments:
//		ReaderNumber - The zero-based index of the card reader.
// Return Value:
//    Returns TRUE, if Belgian eID card is inserted in the reader. If there is
//    no card in the reader or the card of other type is inserted, returns FALSE
function  IsEIDCardEx(ReaderNumber : integer) : BOOL; stdcall;

// Summary:
//    Check if Belgian SIS card is inserted into card reader
// Description:
//    If the card is inserted in the reader, this function performs the card
//    type check.
// Arguments:
//		readerNumber - The zero-based index of the card reader.
// Return Value:
//    Returns TRUE, if Belgian SIS card is inserted in the reader. If there is
//    no card in the reader or the card of other type is inserted, returns FALSE
function  IsSISCardEx(ReaderNumber : integer) : BOOL; stdcall;

// Summary:
//    Save the picture from the card to JPG file
// Decription:
//    Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//    Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//    FileName - File name to store the photo
// Return Value:
//    Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsJpeg(FileName : PChar) : BOOL; stdcall;

// Summary:
//    Save the picture from the card to JPG file
// Decription:
//    Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//    Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//    FileName - File name to store the photo
// Return Value:
//    Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsJpegW(FileName : PWideChar) : BOOL; stdcall;

// Summary:
//    Save the picture from the card to JPG file
// Decription:
//    Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//    Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//    FileName - File name to store the photo
// Return Value:
//    Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsJpegA(FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//    Save the picture from the card to JPG file
// Decription:
//    Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//    Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		ReaderNumber - The zero-based index of the card reader.
//    FileName - File name to store the photo
// Return Value:
//    Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsJpegEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall;

// Summary:
//    Save the picture from the card to JPG file
// Decription:
//    Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//    Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		ReaderNumber - The zero-based index of the card reader.
//    FileName - File name to store the photo
// Return Value:
//    Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsJpegExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall;

// Summary:
//    Save the picture from the card to JPG file
// Decription:
//    Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//    Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		ReaderNumber - The zero-based index of the card reader.
//    FileName - File name to store the photo
// Return Value:
//    Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsJpegExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Save the picture from the card to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsBitmap(FileName : PChar) : BOOL; stdcall;

// Summary:
//      Save the picture from the card to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsBitmapW(FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Save the picture from the card to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsBitmapA(FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Reads the picture from the card and saves it to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - the zero-based index of the card reader.  
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsBitmapEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall;

// Summary:
//      Reads the picture from the card and saves it to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - the zero-based index of the card reader.  
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsBitmapExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Reads the picture from the card and saves it to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - the zero-based index of the card reader.  
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  SavePhotoAsBitmapExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Reads the picture from the card, converts it to bitmap and returns the bitmap handle
// Decription:
//      Reads the photo from the Belgian eID card and returns the bitmap handle
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Return Value:
//      A handle to a bitmap indicates success. NULL indicates failure. 
function  ReadPhotoAsBitmap() : HBITMAP; stdcall;

// Summary:
//      Reads the picture from the card, converts it to bitmap and returns the bitmap handle
// Decription:
//      Reads the photo from the Belgian eID card and returns the Windows bitmap handle
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
// Return Value:
//      A handle to a bitmap indicates success. NULL indicates failure. 
function  ReadPhotoAsBitmapEx(ReaderNumber : integer) : HBITMAP; stdcall;

// Summary:
//     Reads a photo from a card
// Description:
//     Reads a photo from Belgian eID card to EidPicture structure. This structure holds the raw image bytes and 
//     the length of the image bytes array
// Arguments:
//     photo - The pointer to EidPicture structure
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  ReadPhoto(Photo : PeidPicture) : BOOL; stdcall;

// Summary:
//     Reads a photo from a card
// Description:
//     Reads a photo from Belgian eID card to EidPicture structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader.  
//     photo - The pointer to EidPicture structure
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
function  ReadPhotoEx(ReaderNumber : integer; Photo : PeidPicture) : BOOL; stdcall;

// Summary:
//     Performs Base64 encoding of the photo
// Description:
//     Use this function for Base64 encoding of the photo
// Arguments:
//     photo - The pointer to EidPicture structure
//     buffer - The Base64 encoded photo buffer
//     bufferSize - The size of the buffer
// Return value:
//     Returns the size of the buffer needed to hold the encoded photo
function  EncodePhoto(Photo : PeidPicture;  Buffer : PBYTE;  BufferSize : integer) : integer; stdcall;

// Summary:
//     Calculates buffer size for Base64 encoded photo
// Description:
//     Use this function to calculate the size of the buffer needed for Base64 encoding of the photo
//     This can be useful for including the photo data to the text document, for example to XML file
// Arguments:
//     photo - The pointer to EidPicture structure
// Return Value:
//     The desired size of the buffer
function  GetEncodedPhotoSize(photo : PeidPicture) : integer; stdcall;

// Summary:
//     Loads photo from a file
// Description:
//     Loads raw picture data from a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
procedure LoadPhoto(Photo : PeidPicture; FileName : PChar); stdcall;

// Summary:
//     Loads photo from a file
// Description:
//     Loads raw picture data from a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
procedure LoadPhotoW(Photo : PeidPicture; FileName : PWideChar); stdcall;

// Summary:
//     Loads photo from a file
// Description:
//     Loads raw picture data from a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
procedure LoadPhotoA(Photo : PeidPicture; FileName : PAnsiChar); stdcall;

// Summary:
//     Saves photo to a file
// Description:
//     Saves the raw picture data to a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
procedure SavePhoto(Photo : PeidPicture; FileName : PChar); stdcall;

// Summary:
//     Saves photo to a file
// Description:
//     Saves the raw picture data to a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
procedure SavePhotoW(Photo : PeidPicture; FileName : PWideChar); stdcall;

// Summary:
//     Saves photo to a file
// Description:
//     Saves the raw picture data to a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
procedure SavePhotoA(Photo : PeidPicture; FileName : PAnsiChar); stdcall;

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadIdentity(identity : PEidIdentity) : BOOL; stdcall;

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadIdentityW(identity : PEidIdentityW) : BOOL; stdcall;

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadIdentityA(identity : PEidIdentityA) : BOOL; stdcall;

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//      address - the pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadAddress(address : PEidAddress) : BOOL; stdcall;

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//      address - the pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadAddressW(address : PEidAddressW) : BOOL; stdcall;

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//      address - the pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadAddressA(address : PEidAddressA) : BOOL; stdcall;

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadIdentityEx(ReaderNumber : integer; identity : PEidIdentity) : BOOL; stdcall;

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadIdentityExW(ReaderNumber : integer; identity : PEidIdentityW) : BOOL; stdcall;

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadIdentityExA(ReaderNumber : integer; identity : PEidIdentityA) : BOOL; stdcall;

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      address - The pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadAddressEx(ReaderNumber : integer; address : PEidAddress) : BOOL; stdcall;

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      address - The pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadAddressExA(ReaderNumber : integer; address : PEidAddressA) : BOOL; stdcall;

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      address - The pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadAddressExW(ReaderNumber : integer; address : PEidAddressW) : BOOL; stdcall;

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//      PSISRecordW - The pointer to SISRecordW structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadSISCard(Identity : PSISRecord) : BOOL; stdcall;

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//      PSISRecordW - The pointer to SISRecordW structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadSISCardW(Identity : PSISRecordW) : BOOL; stdcall;

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//      PSISRecordW - The pointer to SISRecordW structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadSISCardA(Identity : PSISRecordA) : BOOL; stdcall;

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      PSISRecordA - The pointer to SISRecordA structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadSISCardEx(ReaderNumber : integer; Identity : PSISRecord) : BOOL; stdcall;

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      PSISRecordA - The pointer to SISRecordA structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadSISCardExW(ReaderNumber : integer; Identity : PSISRecordW) : BOOL; stdcall;

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      PSISRecordA - The pointer to SISRecordA structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
function  ReadSISCardExA(ReaderNumber : integer; Identity : PSISRecordA) : BOOL; stdcall;

// Summary:
//     Saves indentity infornation to a file
// Description:
//     Use this function to store the raw identity information from the Belgian
//     eID card to a file. You can use LoadIdentityW to read this information from the file to
//     EidIdentityW structure
// Arguments:
//     fileName - The name of the destination file 
procedure SaveIdentity(FileName : PChar); stdcall;

// Summary:
//     Saves indentity infornation to a file
// Description:
//     Use this function to store the raw identity information from the Belgian
//     eID card to a file. You can use LoadIdentityW to read this information from the file to
//     EidIdentityW structure
// Arguments:
//     fileName - The name of the destination file 
procedure SaveIdentityW(FileName : PWideChar); stdcall;

// Summary:
//     Saves indentity infornation to a file
// Description:
//     Use this function to store the raw identity information from the Belgian
//     eID card to a file. You can use LoadIdentityW to read this information from the file to
//     EidIdentityW structure
// Arguments:
//     fileName - The name of the destination file 
procedure SaveIdentityA(FileName : PAnsiChar); stdcall;

// Summary:
//     Reads the raw identity information from a file
// Description:
//     Use this function to read back the identity information stored to the file using SaveIdentityW function
// Arguments:
//     fileName - The name of the source file 
//     identity - The pointer to EidIdentityW structure
procedure LoadIdentity(FileName : PChar;  identity : PEidIdentity); stdcall;

// Summary:
//     Reads the raw identity information from a file
// Description:
//     Use this function to read back the identity information stored to the file using SaveIdentityW function
// Arguments:
//     fileName - The name of the source file 
//     identity - The pointer to EidIdentityW structure
procedure LoadIdentityA(FileName : PAnsiChar;  identity : PEidIdentityA); stdcall;

// Summary:
//     Reads the raw identity information from a file
// Description:
//     Use this function to read back the identity information stored to the file using SaveIdentityW function
// Arguments:
//     fileName - The name of the source file 
//     identity - The pointer to EidIdentityW structure
procedure LoadIdentityW(FileName : PWideChar; identity : PEidIdentityW); stdcall;

// Summary:
//      Save Authentication Certificate to a file
// Description:
//      Read Authentication Certificate from the card and save it to a file.
// Arguments:
//      fileName - File name to store the certificate
procedure SaveAuthenticationCertificate(FileName : PChar); stdcall;

// Summary:
//     Save Non Repudiation Certificate to a file
// Description:
//     Read Non Repudiation Certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveNonRepudiationCertificate(FileName : PChar); stdcall;

// Summary:
//     Save Ca Certificate to a file
// Description:
//     Read Ca Certificate from the card and save it to a file
// Arguments:
//    fileName - File name to store the certificate
procedure SaveCaCertificate(FileName : PChar); stdcall;

// Summary:
//     Save Root Ca Certificate to a file
// Description:
//     Read Root CA certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveRootCaCertificate(FileName : PChar); stdcall;

// Summary:
//     Save RRN Certificate to a file
// Description:
//     Read RRN certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveRrnCertificate(FileName : PChar); stdcall;

// Summary:
//      Save Authentication Certificate to a file
// Description:
//      Read Authentication Certificate from the card and save it to a file.
// Arguments:
//      fileName - File name to store the certificate
procedure SaveAuthenticationCertificateW(FileName : PWideChar); stdcall;

// Summary:
//     Save Non Repudiation Certificate to a file
// Description:
//     Read Non Repudiation Certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveNonRepudiationCertificateW(FileName : PWideChar); stdcall;

// Summary:
//     Save Ca Certificate to a file
// Description:
//     Read Ca Certificate from the card and save it to a file
// Arguments:
//    fileName - File name to store the certificate
procedure SaveCaCertificateW(FileName : PWideChar); stdcall;

// Summary:
//     Save Root Ca Certificate to a file
// Description:
//     Read Root CA certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveRootCaCertificateW(FileName : PWideChar); stdcall;

// Summary:
//     Save RRN Certificate to a file
// Description:
//     Read RRN certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveRrnCertificateW(FileName : PWideChar); stdcall;

// Summary:
//      Save Authentication Certificate to a file
// Description:
//      Read Authentication Certificate from the card and save it to a file.
// Arguments:
//      fileName - File name to store the certificate
procedure SaveAuthenticationCertificateA(FileName : PAnsiChar); stdcall;

// Summary:
//     Save Non Repudiation Certificate to a file
// Description:
//     Read Non Repudiation Certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveNonRepudiationCertificateA(FileName : PAnsiChar); stdcall;

// Summary:
//     Save Ca Certificate to a file
// Description:
//     Read Ca Certificate from the card and save it to a file
// Arguments:
//    fileName - File name to store the certificate
procedure SaveCaCertificateA(FileName : PAnsiChar); stdcall;

// Summary:
//     Save Root Ca Certificate to a file
// Description:
//     Read Root CA certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveRootCaCertificateA(FileName : PAnsiChar); stdcall;

// Summary:
//     Save RRN Certificate to a file
// Description:
//     Read RRN certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
procedure SaveRrnCertificateA(FileName : PAnsiChar); stdcall;

// Summary:
//     Read Authentication Certificate to memory
// Description:
//     Read Authentication Certificate from the card to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
function  ReadAuthenticationCertificate(Certificate : PEidCertificate) : BOOL; stdcall;

// Summary:
//     Read Non Repudiation Certificate to memory
// Description:
//     Read Non Repudiation Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
function  ReadNonRepudiationCertificate(Certificate : PEidCertificate) : BOOL; stdcall;

// Summary:
//     Read Ca Certificate to memory
// Description:
//     Read Ca Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
function  ReadCaCertificate(Certificate : PEidCertificate) : BOOL; stdcall;

// Summary:
//     Read Root Ca Certificate to memory
// Description:
//     Read Root Ca Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
function  ReadRootCaCertificate(Certificate : PEidCertificate) : BOOL; stdcall;

// Summary:
//     Read Rrn Certificate to memory
// Description:
//     Read Rrn Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
function  ReadRrnCertificate(Certificate : PEidCertificate) : BOOL; stdcall;

// Summary:
//     Performs Base64 encoding of the certificate
// Arguments:
//     certificate - The certificate data
//     buffer - The Base64 encoded certificate buffer
//     bufferSize - The size of the buffer
// Return value:
//     Returns the size of the buffer needed to hold the encoded certificate
function  EncodeCertificate(Certificate : PEidCertificate; Buffer : PBYTE;  BufferSize : integer) : integer; stdcall;

// Summary:
//     Returns the size of the Base64 encoded certificate
// Description:
//    Use this function to calculate the size of the buffer needed to encode the certificate
// Arguments:
//   certificate - The certificate data
// Return value:
//     Returns the size of the buffer needed to hold the encoded certificate
function  GetEncodedCertificateSize(Certificate : PEidCertificate) : integer; stdcall;

// Summary:
//     Displays the dialog window with certificate information
// Description:
//     Use this function to show the certificate for the user
// Arguments:
//   certificate - The certificate data
procedure DisplayCertificate(Certificate : PEidCertificate); stdcall;

// Summary:
//     Reads the certificate from a file
// Description:
//     Use this function to read the certificate from the file
// Arguments:
//     fileName - The source file name
//     certificate - The pointer to EidCertificate structure
procedure LoadCertificate(FileName : PChar; Certificate : PEidCertificate); stdcall;

// Summary:
//     Reads the certificate from a file
// Description:
//     Use this function to read the certificate from the file
// Arguments:
//     fileName - The source file name
//     certificate - The pointer to EidCertificate structure
procedure LoadCertificateW(FileName : PWideChar; Certificate : PEidCertificate); stdcall;

// Summary:
//     Reads the certificate from a file
// Description:
//     Use this function to read the certificate from the file
// Arguments:
//     fileName - The source file name
//     certificate - The pointer to EidCertificate structure
procedure LoadCertificateA(FileName : PAnsiChar; Certificate : PEidCertificate); stdcall;

// Summary:
//      Verify PIN code
// Arguments:
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
function  VerifyPin(Value : PChar) : BOOL; stdcall;

// Summary:
//      Verify PIN code
// Arguments:
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
function  VerifyPinW(Value : PWideChar) : BOOL; stdcall;

// Summary:
//      Verify PIN code
// Arguments:
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
function  VerifyPinA(Value : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Verify PIN code
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
function  VerifyPinEx(ReaderNumber : integer; Value : PChar) : BOOL; stdcall;

// Summary:
//      Verify PIN code
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
function  VerifyPinExW(ReaderNumber : integer; Value : PWideChar) : BOOL; stdcall;

// Summary:
//      Verify PIN code
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
function  VerifyPinExA(ReaderNumber : integer; Value : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SavePersonToCsv(FileName : PChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SavePersonToCsvW(FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SavePersonToCsvA(FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SavePersonToCsvEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SavePersonToCsvExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SavePersonToCsvExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SaveCardToXml(FileName : PChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SaveCardToXmlW(FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SaveCardToXmlA(FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SaveCardToXmlEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SaveCardToXmlExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  SaveCardToXmlExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  GenerateQRCode(FileName : PChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  GenerateQRCodeW(FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  GenerateQRCodeA(FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  GenerateQRCodeEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  GenerateQRCodeExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall;

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
function  GenerateQRCodeExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall;

// Summary:
//     Checks if the card owner is female
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is female, otherwise returns FALSE
function  IsFemale(Identity : PEidIdentity) : BOOL; stdcall;

// Summary:
//     Checks if the card owner is female
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is female, otherwise returns FALSE
function  IsFemaleW(Identity : PEidIdentityW) : BOOL; stdcall;

// Summary:
//     Checks if the card owner is female
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is female, otherwise returns FALSE
function  IsFemaleA(Identity : PEidIdentityA) : BOOL; stdcall;

// Summary:
//     Checks if the card owner is male
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is male, otherwise returns FALSE
function  IsMale(Identity : PEidIdentity) : BOOL; stdcall;

// Summary:
//     Checks if the card owner is male
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is male, otherwise returns FALSE
function  IsMaleW(Identity : PEidIdentityW) : BOOL; stdcall;

// Summary:
//     Checks if the card owner is male
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is male, otherwise returns FALSE
function  IsMaleA(Identity : PEidIdentityA) : BOOL; stdcall;

// Summary:
//     Generate authentication signature
// Description:
//     Generate authentication signature using provided hash value 
// Arguments:
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateAuthenticationSignature(PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate authentication signature
// Description:
//     Generate authentication signature using provided hash value
// Arguments:
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateAuthenticationSignatureW(PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate authentication signature
// Description:
//     Generate authentication signature using provided hash value 
// Arguments:
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateAuthenticationSignatureA(PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate non repudiation signature
// Description:
//     Generate non repudiation signature using provided hash value
// Arguments:
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateNonRepudiationSignature(PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate non repudiation signature
// Description:
//     Generate non repudiation signature using provided hash value
// Arguments:
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateNonRepudiationSignatureA(PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate non repudiation signature
// Description:
//     Generate non repudiation signature using provided hash value
// Arguments:
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateNonRepudiationSignatureW(PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate authentication signature
// Description:
//     Generate authentication signature using provided hash value 
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateAuthenticationSignatureEx(ReaderNumber : integer; PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate authentication signature
// Description:
//     Generate authentication signature using provided hash value 
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateAuthenticationSignatureExW(ReaderNumber : integer; PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate authentication signature
// Description:
//     Generate authentication signature using provided hash value 
// Arguments:
//		readerNumber - The zero-based index of the card reader.
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateAuthenticationSignatureExA(ReaderNumber : integer; PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate non repudiation signature
// Description:
//     Generate non repudiation signature using provided hash value
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateNonRepudiationSignatureEx(ReaderNumber : integer; PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate non repudiation signature
// Description:
//     Generate non repudiation signature using provided hash value
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateNonRepudiationSignatureExA(ReaderNumber : integer; PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Generate non repudiation signature
// Description:
//     Generate non repudiation signature using provided hash value
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      pinCode - The card PIN code value
//      dataHash - The hash value buffer
//      hashSize - The size of the hash data buffer
//      signature - The output buffer that contains the generated signature
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is successfully generated, otherwise returns FALSE
function  GenerateNonRepudiationSignatureExW(ReaderNumber : integer; PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall;

// Summary:
//     Verifies the signature from the specified hash value. 
// Description:
//     Verify the signature using the public certificate of the signer
// Arguments:
//      certificate - The public certificate 
//      buffer - The hash buffer
//      bufferSize - The size of the hash buffer
//      signature - The signature to be verified. 
//      signatureSize - The size of the signature buffer
// Return Value:
//     Returns TRUE if the signature is valid for the hash; otherwise, FALSE. 
function  VerifySignature(Certificate : PEidCertificate; Buffer : PBYTE; BufferSize : integer; Signature : PBYTE; signatureSize : DWORD) : BOOL; stdcall;

// Summary:
//     Activates callback procedure for card status change event
// Description:
//     Your application can be notified about insertion or removal of the card from the card reader and
//     the changes of the available card readers list (the reader is connected or disconnected from PC)
//     Use this function to install the callback procedure
// Arguments:
//     callback - The pointer to callback procedure
//     userContext - The user defined value passed to the callback procedure
procedure SetCallback(callback : TReaderCallback; userContext : Pointer); stdcall;

// Summary:
//     Remove callback procedure for card events
// Description:
//     Use this function to deactivate card events callback procedure
procedure RemoveCallback(); stdcall;

// Summary:
//     Reloads the list of the available card readers
// Description:
//     When the card reader is inserted or removed you may need to reload the list
//     of the available card readers
procedure ReloadReadersList; stdcall;

 //  Summary
 //  Gets the SHA1 hash value for the file
 //  Description
 //  Calculates SHA1 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
function GetFileSHA1(FileName : PChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the SHA1 hash value for the file
 //  Description
 //  Calculates SHA1 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
function GetFileSHA1W(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the SHA1 hash value for the file
 //  Description
 //  Calculates SHA1 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
function GetFileSHA1A(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the MD5 hash value for the file
 //  Description
 //  Calculates MD5 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
function GetFileMD5(FileName : PChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the MD5 hash value for the file
 //  Description
 //  Calculates MD5 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
function GetFileMD5W(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the MD5 hash value for the file
 //  Description
 //  Calculates MD5 hash value for the given file
 //  Parameters
 //  fileName :    The name of the file
 //  buffer :      The buffer to store the hash value
 //  bufferSize :  The size of the buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE       
function GetFileMD5A(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the SHA1 hash value for the content of the memory buffer
 //  Description
 //  Calculates SHA1 hash value for the given memory buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE
 //  Parameters
 //  source :      The source memory block
 //  sourceSize :  The size of the source memory block
 //  buffer :      The buffer for the hash value
 //  bufferSize :  The size of the destination buffer              
function GetSHA1(Source : PBYTE; SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Gets the MD5 hash value for the content of the memory buffer
 //  Description
 //  Calculates MD5 hash value for the given memory buffer
 //  Return Value
 //  The result of the function is equal to TRUE if operation is
 //  completed successfully, otherwise the result is FALSE
 //  Parameters
 //  source :      The source memory block
 //  sourceSize :  The size of the source memory block
 //  buffer :      The buffer for the hash value
 //  bufferSize :  The size of the destination buffer              
function GetMD5(Source : PBYTE;  SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Checks the SHA1 hash value of the memory buffer
 //  Description
 //  This function checks if the provided value of the hash is
 //  valid
 //  Parameters
 //  source :      The source bytes
 //  sourceSize :  The size of the source buffer
 //  buffer :      The hash value buffer
 //  bufferSize :  The size of the hash value buffer
 //  Return Value
 //  Returns TRUE if the hash value is correct, otherwise returns
 //  false                                                                
function CheckSHA1(Source : PBYTE; SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Checks the MD5 hash value of the memory buffer
 //  Description
 //  This function checks if the provided value of the hash is
 //  valid
 //  Parameters
 //  source :      The source bytes
 //  sourceSize :  The size of the source buffer
 //  buffer :      The hash value buffer
 //  bufferSize :  The size of the hash value buffer
 //  Return Value
 //  Returns TRUE if the hash value is correct, otherwise returns
 //  false                                                                
function CheckMD5(Source : PBYTE;  SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall;

 //  Summary
 //  Encrypts file using AES algorithm.
 //  Description
 //  Use this function to encrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The encrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully encrypted, otherwise
 //  returns FALSE                                                 
function EncryptFileAES(Source : PChar; Destination : PChar; Password : PChar) : BOOL; stdcall;

 //  Summary
 //  Encrypts file using AES algorithm.
 //  Description
 //  Use this function to encrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The encrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully encrypted, otherwise
 //  returns FALSE                                                 
function EncryptFileAESW(Source : PWideChar; Destination : PWideChar; Password : PWideChar) : BOOL; stdcall;

 //  Summary
 //  Encrypts file using AES algorithm.
 //  Description
 //  Use this function to encrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The encrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully encrypted, otherwise
 //  returns FALSE                                                 
function EncryptFileAESA(Source : PAnsiChar; Destination : PAnsiChar; Password : PAnsiChar) : BOOL; stdcall;

 //  Summary
 //  Decrypts file using AES algorithm.
 //  Description
 //  Use this function to decrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The decrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully decrypted, otherwise
 //  returns FALSE.                                                
function DecryptFileAES(Source : PChar; Destination : PChar; Password : PChar) : BOOL; stdcall;

 //  Summary
 //  Decrypts file using AES algorithm.
 //  Description
 //  Use this function to decrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The decrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully decrypted, otherwise
 //  returns FALSE.                                                
function DecryptFileAESW(Source : PWideChar; Destination : PWideChar; Password : PWideChar) : BOOL; stdcall;

 //  Summary
 //  Decrypts file using AES algorithm.
 //  Description
 //  Use this function to decrypt the file using AES algorithm
 //  Parameters
 //  szSource :       The source file name
 //  szDestination :  The decrypted file name
 //  szPassword :     The password
 //  Return Value
 //  Returns TRUE if the file is successfully decrypted, otherwise
 //  returns FALSE.                                                
function DecryptFileAESA(Source : PAnsiChar; Destination : PAnsiChar; Password : PAnsiChar) : BOOL; stdcall;

 //  Summary
 //  Encrypt file using Belgian Id card
 //  Description
 //  Encrypt file using Belgian Id card. The card must be inserted
 //  in the reader
 //  Parameters
 //  szSource :       The name of the source file
 //  szDestination :  The name of the encrypted file               
function CardEncryptFile(Source : PChar; Destination : PChar) : BOOL; stdcall;

 //  Summary
 //  Encrypt file using Belgian Id card
 //  Description
 //  Encrypt file using Belgian Id card. The card must be inserted
 //  in the reader
 //  Parameters
 //  szSource :       The name of the source file
 //  szDestination :  The name of the encrypted file               
function CardEncryptFileW(Source : PWideChar; Destination : PWideChar) : BOOL; stdcall;

 //  Summary
 //  Encrypt file using Belgian Id card
 //  Description
 //  Encrypt file using Belgian Id card. The card must be inserted
 //  in the reader
 //  Parameters
 //  szSource :       The name of the source file
 //  szDestination :  The name of the encrypted file               
function CardEncryptFileA(Source : PAnsiChar; Destination : PAnsiChar) : BOOL; stdcall;

 //  Summary
 //  Decrypt file using Belgian Id card
 //  Description
 //  Decrypt file which was encrypted using CardEncryptFile
 //  function
 //  Parameters
 //  szSource :       The name of the encrypted file
 //  szDestination :  The name of the decrypted file        
function CardDecryptFile(Source : PChar; Destination : PChar) : BOOL; stdcall;

 //  Summary
 //  Decrypt file using Belgian Id card
 //  Description
 //  Decrypt file which was encrypted using CardEncryptFile
 //  function
 //  Parameters
 //  szSource :       The name of the encrypted file
 //  szDestination :  The name of the decrypted file        
function CardDecryptFileW(Source : PWideChar; Destination : PWideChar) : BOOL; stdcall;

 //  Summary
 //  Decrypt file using Belgian Id card
 //  Description
 //  Decrypt file which was encrypted using CardEncryptFile
 //  function
 //  Parameters
 //  szSource :       The name of the encrypted file
 //  szDestination :  The name of the decrypted file        
function CardDecryptFileA(Source : PAnsiChar; Destination : PAnsiChar) : BOOL; stdcall;

// Summary:
//      Converts the national number value to its formatted String representation
// Arguments:
//      D - The unformatted national number
// Return Value:
//      Formatted string
function FormatEIDDate(D : String; Separator : String = '/') : String;

// Summary:
//      Format the national number string for better visualization
// Arguments:
//      Number - The unformatted national number
// Return Value:
//      Formatted string
function FormatNationalNumber(Number : String) : String;

// Summary:
//      Format card number string for better visualization
// Arguments:
//      Number - The unformatted card number
// Return Value:
//      Formatted string
function FormatCardNumber(Number : String) : String;

// Summary:
//      Returns the textual representation of the card type (in English)
// Arguments:
//      AType - the document type (eID card, Kids card, etc...)
// Return Value:
//      English description of the card type.
function DocumentTypeToString(AType : integer) : String;

//   Summary
//   Creates UNICODE file
//   Parameters
//   fileName :  The name of the file 
procedure CreateUnicodeFile(const FileName : PChar); stdcall;

//   Summary
//   Checks if the file is UNICODE file
//   Description
//   This function checks the file encoding based on BOM (Byte
//   Order Mark).
//   Parameters
//   fileName :  The name of the file
//   Return Value
//   Returns TRUE if file is stored in UNICODE format, otherwise
//   returns FALSE.                                              
function IsUnicodeFile(const FileName : PChar) : BOOL; stdcall;

//   Summary
//   Deletes file to WIndows Recycle Bin
//   Description
//   Use this function to delete the file to Windows Recycle Bin
//   Parameters
//   fileName :  The name of the file
//   silent :    Do not display a progress dialog box            
procedure DeleteToRecycleBin(FileName : PChar; Silent : BOOL); stdcall;

//  Summary
//  Copies file to the new location
//  Description
//  Copies file to the new location using Windows shell copy
//  routine
//  Parameters
//  oldName :  The source file name
//  newName :  The destination file name
procedure ShellCopyFile(oldName : PChar; NewName : PChar); stdcall;

//  Summary
//  Retrieves the size of a specified file.
//  Description
//  This function determines the size of the file specified by the name of the file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  The size of the file in bytes.                             
function FileGetSize(const FileName : PChar) : DWORD; stdcall;

//  Summary
//  Tests whether a specified file exists.
//  Description
//  Use this function to check if the file with provided name
//  exists.
//  Return Value
//  FileExists returns TRUE if the file specified by FileName
//  exists. If the file does not exist, FileExists returns FALSE. 
function FileExists(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Checks the file extension
//  Description
//  This function checks if the file has a given extension
//  Parameters
//  fileName :  The name of the file
//  ext :       The file name extension
//  Return Value
//  Returns true if the file has a specified extension, otherwise
//  returns false.                                                
function FileExtensionIs(const FileName : PChar; Ext : PChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is an image file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is an image file, otherwise returns
//  FALSE.                                                       
function FileIsImage(const FileName : PChar) : BOOL; stdcall;

//  Summary
//  Deletes a file from disk.
//  Description
//  DeleteFile deletes the file named by fileName from the disk.
//  Parameters
//  fileName :  The name of the file                             
procedure FileDelete(FileName : PChar); stdcall;

//  Summary
//  This function sets the file attributes to normal.
//  Description
//  This function removed additional file attributes, like
//  system, read-only and hidden.
//  Parameters
//  fileName :  The name of the file                       
procedure ClearFileAttributes(FileName : PChar); stdcall;

//  Summary
//  Creates new or overwrites existing file
//  Description
//  This function creates the new file with provided file name if
//  the file with given name does not exists.
//  If the file exists, it will be overwritten and the current
//  content of the file will be lost
//  Return Value
//  The result of the function is the handle of the file 
function FileCreateRewrite(const FileName : PChar) : THandle; stdcall;

//  Summary
//  Concludes input/output (I/O) to a file opened using the
//  FileCreateRewrite function.
//  Description
//  Closes the file handle of the specified file when its not in
//  use anymore
//  Parameters
//  handle :  The handle of the file                             
procedure FileClose(Handle : THandle); stdcall;

//  Summary
//  Writes string to the file
//  Parameters
//  handle :  The handle of the file
//  text :    The text to write      
procedure FileWrite(handle : THandle; Text : PChar); stdcall;

//  Summary
//  Writes one character to the file
//  Parameters
//  handle :  The handle of the file
//  text :    The character to write 
procedure FileWriteChar(Handle : THandle; Text : WideChar); stdcall;

//  Summary
//  Writes new line sequence to the file
//  Parameters
//  handle :  The handle of the file     
procedure FileWriteNewLine(Handle : THandle); stdcall;

//  Summary
//  Checks if the file is an animated GIF image file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is an animated GIF image file,
//  otherwise returns FALSE.                                
function IsAnimatedGIF(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Renames the file
//  Parameters
//  oldName :  \File to be renamed
//  newName :  New name of the file
//  Return Value
//  Returns TRUE if the file was successfully renamed, otherwise
//  returns FALSE                                                
function FileRename(OldName : PChar; NewName : PChar) : BOOL; stdcall;

//  Summary
//  Replaces environment variable names with values
//  Description
//  This function expands environment-variable strings and
//  replaces them with their defined values in the file name.
//  Parameters
//  fileName :  The source file name
//  fullName :  The expanded file name                        
procedure StripFileName(const FileName : PChar; FullName : PChar); stdcall;

//  Summary
//  The CopyFile function copies an existing file to a new file.
//  Description
//  This function makes a copy of the file with the new name or
//  path.
//  Parameters
//  oldName :  The name of the source file
//  newName :  The name of the destination file
//  Return Value
//  The result of the function is TRUE when the file is
//  successfully copied to the new location, otherwise the result
//  is FALSE.                                                     
function FileCopy(OldName : PChar; NewName : PChar) : BOOL; stdcall;

//  Summary
//  Gets the full path to the file based on file name
//  Parameters
//  fileName :  The name of the file
//  fullName :  The full path to the file             
function FullPath(FileName : PChar; FullName : PChar) : BOOL; stdcall;

//  Summary
//  Checks if the file or folder with the given name exists
//  Parameters
//  fileName :  The file or folder name
//  Return Value
//  Returns TRUE if the file or folder exists, otherwise returns
//  FALSE.                                                       
function FileOrFolderExists(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Determines whether a specified directory exists.
//  Description
//  Call DirectoryExists to determine whether the directory
//  specified by the Directory parameter exists. If the directory
//  exists, the function returns True. If the directory does not
//  exist, the function returns False.
//  If a full path name is entered, DirectoryExists searches for
//  the directory along the designated path. Otherwise, the
//  Directory parameter is interpreted as a relative path name
//  from the current directory.
//  Parameters
//  fileName :  The name of the directory
//  Return Value
//  Returns TRUE if the directory exists, otherwise returns FALSE 
function DirectoryExists(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Verifies that a path is a valid directory.
//  Description
//  This function verifies if provided value is the name of the
//  folder
//  Return Value
//  Returns TRUE if the path is a valid directory, or FALSE
//  otherwise. 
function IsDirectory(FolderName : PChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is a Windows executable
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is a Windows executable, otherwise
//  returns FALSE.                                              
function FileIsExe(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is a Windows icon (.ico) file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is a Windows icon (.ico) file,
//  otherwise returns FALSE.                                
function FileIsIcon(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Checks if provided string is a valid file name
//  Description
//  Checks if provided string is a valid file name and does not
//  contain any illegal characters
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if provided string is valid file name, otherwise
//  returns FALSE                                                 
function IsValidFileName(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Checks if provided string is a valid file path
//  Description
//  Checks if provided string is a valid file path and does not
//  contain any illegal characters
//  Parameters
//  fileName :  The file path to check
//  Return Value
//  Returns TRUE if provided string is valid file path, otherwise
//  returns FALSE                                                 
function IsValidPathName(FileName : PChar) : BOOL; stdcall;

//  Summary
//  Calculates the number of files in the given folder
//  Parameters
//  folderName :  The name of the folder
//  Return Value
//  The number of files in the given folder            
function GetFilesCount(FolderName : PChar) : integer; stdcall;

//  Summary
//  Creates UNICODE file
//  Parameters
//  fileName :  The name of the file 
procedure CreateUnicodeFileW(const FileName : PWideChar); stdcall;

//  Summary
//  Checks if the file is UNICODE file
//  Description
//  This function checks the file encoding based on BOM (Byte
//  Order Mark).
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if file is stored in UNICODE format, otherwise
//  returns FALSE.                                              
function IsUnicodeFileW(const FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Deletes file to the Windows Recycle Bin
//  Description
//  Use this function to delete the file to Windows Recycle Bin
//  Parameters
//  fileName :  The name of the file
//  silent :    Do not display a progress dialog box            
procedure DeleteToRecycleBinW(FileName : PWideChar; Silent : BOOL); stdcall;

//  Summary
//  Copies file to the new location
//  Description
//  Copies file to the new location using Windows shell copy
//  routine
//  Parameters
//  oldName :  The source file name
//  newName :  The destination file name                     
procedure ShellCopyFileW(oldName : PWideChar; NewName : PWideChar); stdcall;

//  Summary
//  Retrieves the size of a specified file.
//  Description
//  This function determines the size of the file specified by the file name.
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  The size of the file in bytes.                             
function FileGetSizeW(const FileName : PWideChar) : DWORD; stdcall;

//  Summary
//  Tests whether a specified file exists.
//  Description
//  Use this function to check if the file with provided name
//  exists.
//  Return Value
//  FileExists returns TRUE if the file specified by FileName
//  exists. If the file does not exist, FileExists returns FALSE. 
function FileExistsW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks the file extension
//  Description
//  This function checks if the file has a given extension
//  Parameters
//  fileName :  The name of the file
//  ext :       The file name extension
//  Return Value
//  Returns true if the file has a specified extension, otherwise
//  returns false.                                                
function FileExtensionIsW(const FileName : PWideChar; Ext : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is an image file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is an image file, otherwise returns
//  FALSE.                                                       
function FileIsImageW(const FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Deletes a file from disk.
//  Description
//  DeleteFile deletes the file named by fileName from the disk.
//  Parameters
//  fileName :  The name of the file                             
procedure FileDeleteW(FileName : PWideChar); stdcall;

//  Summary
//  This function sets the file attributes to normal.
//  Description
//  This function removed additional file attributes, like
//  system, read-only and hidden.
//  Parameters
//  fileName :  The name of the file                       
procedure ClearFileAttributesW(FileName : PWideChar); stdcall;

//  Summary
//  Creates new or overwrites existing file
//  Description
//  This function creates the new file with provided file name if
//  the file with given name does not exists.
//  If the file exists, it will be overwritten and the current
//  content of the file will be lost
//  Return Value
//  The result of the function is the handle of the file 
function FileCreateRewriteW(const FileName : PWideChar) : THandle; stdcall;

//  Summary
//  Concludes input/output (I/O) to a file opened using the
//  FileCreateRewrite function.
//  Description
//  Closes the file handle of the specified file when its not in
//  use anymore
//  Parameters
//  handle :  The handle of the file                             
procedure FileCloseW(Handle : THandle); stdcall;

//  Summary
//  Writes string to the file
//  Parameters
//  handle :  The handle of the file
//  text :    The text to write      
procedure FileWriteW(handle : THandle; Text : PWideChar); stdcall;

//  Summary
//  Writes one character to the file
//  Parameters
//  handle :  The handle of the file
//  text :    The character to write 
procedure FileWriteCharW(Handle : THandle; Text : WideChar); stdcall;

//  Summary
//  Writes new line sequence to the file
//  Parameters
//  handle :  The handle of the file     
procedure FileWriteNewLineW(Handle : THandle); stdcall;

//  Summary
//  Checks if the file is an animated GIF image file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is an animated GIF image file,
//  otherwise returns FALSE.                                
function IsAnimatedGIFW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Renames the file
//  Parameters
//  oldName :  \File to be renamed
//  newName :  New name of the file
//  Return Value
//  Returns TRUE if the file was successfully renamed, otherwise
//  returns FALSE                                                
function FileRenameW(OldName : PWideChar; NewName : PWideChar) : BOOL; stdcall;

//  Summary
//  Replaces environment variable names with values
//  Description
//  This function expands environment-variable strings and
//  replaces them with their defined values in the file name.
//  Parameters
//  fileName :  The source file name
//  fullName :  The expanded file name                        
procedure StripFileNameW(const FileName : PWideChar; FullName : PWideChar); stdcall;

//  Summary
//  The CopyFile function copies an existing file to a new file.
//  Description
//  This function makes a copy of the file with the new name or
//  path.
//  Parameters
//  oldName :  The name of the source file
//  newName :  The name of the destination file
//  Return Value
//  The result of the function is TRUE when the file is
//  successfully copied to the new location, otherwise the result
//  is FALSE.                                                     
function FileCopyW(OldName : PWideChar; NewName : PWideChar) : BOOL; stdcall;

//  Summary
//  Gets the full path to the file based on file name
//  Parameters
//  fileName :  The name of the file
//  fullName :  The full path to the file             
function FullPathW(FileName : PWideChar; FullName : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks if the file or folder with the given name exists
//  Parameters
//  fileName :  The file or folder name
//  Return Value
//  Returns TRUE if the file or folder exists, otherwise returns
//  FALSE.                                                       
function FileOrFolderExistsW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Determines whether a specified directory exists.
//  Description
//  Call DirectoryExists to determine whether the directory
//  specified by the Directory parameter exists. If the directory
//  exists, the function returns True. If the directory does not
//  exist, the function returns False.
//  If a full path name is entered, DirectoryExists searches for
//  the directory along the designated path. Otherwise, the
//  Directory parameter is interpreted as a relative path name
//  from the current directory.
//  Parameters
//  fileName :  The name of the directory
//  Return Value
//  Returns TRUE if the directory exists, otherwise returns FALSE 
function DirectoryExistsW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Verifies that a path is a valid directory.
//  Description
//  This function verifies if provided value is the name of the
//  folder
//  Return Value
//  Returns TRUE if the path is a valid directory, or FALSE
//  otherwise. 
function IsDirectoryW(FolderName : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is a Windows executable
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is a Windows executable, otherwise
//  returns FALSE.                                              
function FileIsExeW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is a Windows icon (.ico) file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is a Windows icon (.ico) file,
//  otherwise returns FALSE.                                
function FileIsIconW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks if provided string is a valid file name
//  Description
//  Checks if provided string is a valid file name and does not
//  contain any illegal characters
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if provided string is valid file name, otherwise
//  returns FALSE                                                 
function IsValidFileNameW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Checks if provided string is a valid file path
//  Description
//  Checks if provided string is a valid file path and does not
//  contain any illegal characters
//  Parameters
//  fileName :  The file path to check
//  Return Value
//  Returns TRUE if provided string is valid file path, otherwise
//  returns FALSE                                                 
function IsValidPathNameW(FileName : PWideChar) : BOOL; stdcall;

//  Summary
//  Calculates the number of files in the given folder
//  Parameters
//  folderName :  The name of the folder
//  Return Value
//  The number of files in the given folder            
function GetFilesCountW(FolderName : PWideChar) : integer; stdcall;

//  Summary
//  Creates UNICODE file
//  Parameters
//  fileName :  The name of the file 
procedure CreateUnicodeFileA(const FileName : PAnsiChar); stdcall;

//  Summary
//  Checks if the file is UNICODE file
//  Description
//  This function checks the file encoding based on BOM (Byte
//  Order Mark).
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if file is stored in UNICODE format, otherwise
//  returns FALSE.                                              
function IsUnicodeFileA(const FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Deletes file to the Windows Recycle Bin
//  Description
//  Use this function to delete the file to Windows Recycle Bin
//  Parameters
//  fileName :  The name of the file
//  silent :    Do not display a progress dialog box            
procedure DeleteToRecycleBinA(FileName : PAnsiChar; Silent : BOOL); stdcall;

//  Summary
//  Copies file to the new location
//  Description
//  Copies file to the new location using Windows shell copy
//  routine
//  Parameters
//  oldName :  The source file name
//  newName :  The destination file name                     
procedure ShellCopyFileA(OldName : PAnsiChar; NewName : PAnsiChar); stdcall;

//  Summary
//  Retrieves the size of a specified file.
//  Description
//  This function determines the size of the file specified by the file name.
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  The size of the file in bytes.                             
function FileGetSizeA(const FileName : PAnsiChar) : DWORD; stdcall;

//  Summary
//  Tests whether a specified file exists.
//  Description
//  Use this function to check if the file with provided name
//  exists.
//  Return Value
//  FileExists returns TRUE if the file specified by FileName
//  exists. If the file does not exist, FileExists returns FALSE. 
function FileExistsA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks the file extension
//  Description
//  This function checks if the file has a given extension
//  Parameters
//  fileName :  The name of the file
//  ext :       The file name extension
//  Return Value
//  Returns true if the file has a specified extension, otherwise
//  returns false.                                                
function FileExtensionIsA(const FileName : PAnsiChar; Ext : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is an image file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is an image file, otherwise returns
//  FALSE.                                                       
function FileIsImageA(const FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Deletes a file from disk.
//  Description
//  DeleteFile deletes the file named by fileName from the disk.
//  Parameters
//  fileName :  The name of the file                             
procedure FileDeleteA(FileName : PAnsiChar); stdcall;

//  Summary
//  This function sets the file attributes to normal.
//  Description
//  This function removed additional file attributes, like
//  system, read-only and hidden.
//  Parameters
//  fileName :  The name of the file                       
procedure ClearFileAttributesA(FileName : PAnsiChar); stdcall;

//  Summary
//  Creates new or overwrites existing file
//  Description
//  This function creates the new file with provided file name if
//  the file with given name does not exists.
//  If the file exists, it will be overwritten and the current
//  content of the file will be lost
//  Return Value
//  The result of the function is the handle of the file 
function FileCreateRewriteA(const FileName : PAnsiChar) : THandle; stdcall;

//  Summary
//  Concludes input/output (I/O) to a file opened using the
//  FileCreateRewrite function.
//  Description
//  Closes the file handle of the specified file when its not in
//  use anymore
//  Parameters
//  handle :  The handle of the file                             
procedure FileCloseA(Handle : THandle); stdcall;

//  Summary
//  Writes string to the file
//  Parameters
//  handle :  The handle of the file
//  text :    The text to write      
procedure FileWriteA(Handle : THandle; Text : PAnsiChar); stdcall;

//  Summary
//  Writes one character to the file
//  Parameters
//  handle :  The handle of the file
//  text :    The character to write 
procedure FileWriteCharA(Handle : THandle; Text : AnsiChar); stdcall;

//  Summary
//  Writes new line sequence to the file
//  Parameters
//  handle :  The handle of the file     
procedure FileWriteNewLineA(Handle : THandle); stdcall;

//  Summary
//  Checks if the file is an animated GIF image file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is an animated GIF image file,
//  otherwise returns FALSE.                                
function IsAnimatedGIFA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Renames the file
//  Parameters
//  oldName :  \File to be renamed
//  newName :  New name of the file
//  Return Value
//  Returns TRUE if the file was successfully renamed, otherwise
//  returns FALSE                                                
function FileRenameA(OldName : PAnsiChar; NewName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Replaces environment variable names with values
//  Description
//  This function expands environment-variable strings and
//  replaces them with their defined values in the file name.
//  Parameters
//  fileName :  The source file name
//  fullName :  The expanded file name                        
procedure StripFileNameA(FileName : PAnsiChar; FullName : PAnsiChar); stdcall;

//  Summary
//  The CopyFile function copies an existing file to a new file.
//  Description
//  This function makes a copy of the file with the new name or
//  path.
//  Parameters
//  oldName :  The name of the source file
//  newName :  The name of the destination file
//  Return Value
//  The result of the function is TRUE when the file is
//  successfully copied to the new location, otherwise the result
//  is FALSE.                                                     
function FileCopyA(OldName : PAnsiChar; NewName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Gets the full path to the file based on file name
//  Parameters
//  fileName :  The name of the file
//  fullName :  The full path to the file             
function FullPathA(FileName : PAnsiChar; FullName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks if the file or folder with the given name exists
//  Parameters
//  fileName :  The file or folder name
//  Return Value
//  Returns TRUE if the file or folder exists, otherwise returns
//  FALSE.                                                       
function FileOrFolderExistsA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Determines whether a specified directory exists.
//  Description
//  Call DirectoryExists to determine whether the directory
//  specified by the Directory parameter exists. If the directory
//  exists, the function returns True. If the directory does not
//  exist, the function returns False.
//  If a full path name is entered, DirectoryExists searches for
//  the directory along the designated path. Otherwise, the
//  Directory parameter is interpreted as a relative path name
//  from the current directory.
//  Parameters
//  fileName :  The name of the directory
//  Return Value
//  Returns TRUE if the directory exists, otherwise returns FALSE 
function DirectoryExistsA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Verifies that a path is a valid directory.
//  Description
//  This function verifies if provided value is the name of the
//  folder
//  Return Value
//  Returns TRUE if the path is a valid directory, or FALSE
//  otherwise. 
function IsDirectoryA(FolderName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is a Windows executable
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is a Windows executable, otherwise
//  returns FALSE.                                              
function FileIsExeA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks if the file is a Windows icon (.ico) file
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if the file is a Windows icon (.ico) file,
//  otherwise returns FALSE.                                
function FileIsIconA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks if provided string is a valid file name
//  Description
//  Checks if provided string is a valid file name and does not
//  contain any illegal characters
//  Parameters
//  fileName :  The name of the file
//  Return Value
//  Returns TRUE if provided string is valid file name, otherwise
//  returns FALSE                                                 
function IsValidFileNameA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Checks if provided string is a valid file path
//  Description
//  Checks if provided string is a valid file path and does not
//  contain any illegal characters
//  Parameters
//  fileName :  The file path to check
//  Return Value
//  Returns TRUE if provided string is valid file path, otherwise
//  returns FALSE                                                 
function IsValidPathNameA(FileName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Calculates the number of files in the given folder
//  Parameters
//  folderName :  The name of the folder
//  Return Value
//  The number of files in the given folder            
function GetFilesCountA(FolderName : PAnsiChar) : integer; stdcall;

//  Summary
//  Writes the memory buffer to file
//  Description
//  This function stores the content of the memory buffer to the file.
//  Parameters
//  fileName :    The name of the file
//  buffer :      The address of the memory block
//  bufferSize :  The size of the memory block                   
procedure WriteBufferToFile(FileName : PChar; Buffer : PBYTE; BufferSize : integer); stdcall;

//  Summary
//  Writes the memory buffer to file
//  Description
//  This function stores the content of the memory buffer to the file.
//  Parameters
//  fileName :    The name of the file
//  buffer :      The address of the memory block
//  bufferSize :  The size of the memory block                   
procedure WriteBufferToFileW(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer); stdcall;

//  Summary
//  Writes the memory buffer to file
//  Description
//  This function stores the content of the memory buffer to the file.
//  Parameters
//  fileName :    The name of the file
//  buffer :      The address of the memory block
//  bufferSize :  The size of the memory block                   
procedure WriteBufferToFileA(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer); stdcall;

//  Summary
//  Reads the content of the file to the memory buffer
//  Description
//  Use this function to retrieve the content of the file to the
//  memory block
//  Parameters
//  fileName :    The name of the file
//  buffer :      The address of the memory block
//  bufferSize :  The size of the memory block                   
procedure ReadBufferFromFile(FileName : PChar; Buffer : PBYTE; BufferSize : integer); stdcall;

//  Summary
//  Reads the content of the file to the memory buffer
//  Description
//  Use this function to retrieve the content of the file to the
//  memory block
//  Parameters
//  fileName :    The name of the file
//  buffer :      The address of the memory block
//  bufferSize :  The size of the memory block                   
procedure ReadBufferFromFileW(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer); stdcall;

//  Summary
//  Reads the content of the file to the memory buffer
//  Description
//  Use this function to retrieve the content of the file to the
//  memory block
//  Parameters
//  fileName :    The name of the file
//  buffer :      The address of the memory block
//  bufferSize :  The size of the memory block                   
procedure ReadBufferFromFileA(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer); stdcall;

//  Summary
//  Allocates the buffer in memory
//  Description
//  AllocateBuffer allocates a block of the given size on the
//  heap, and returns the address of this memory.The bytes of the
//  allocated buffer are not set to zero. To dispose of the
//  buffer, use DeallocateBuffer function.
//  Parameters
//  bufferSize :  The size of the buffer
//  Return Value
//  The pointer to the allocated memory block                     
function AllocateBuffer(BufferSize : integer) : Pointer; stdcall;

//  Summary
//  Deallocates the memory buffer
//  Description
//  DeallocateBuffer frees a memory block previously allocated
//  with AllocateBuffer.
//  Use this procedure to dispose of a memory block obtained with
//  AllocateBuffer.
//  Parameters
//  buffer :  The pointer to the memory buffer                    
procedure DeallocateBuffer(Buffer : Pointer); stdcall;

//  Summary
//  Returns the country ISO code based on the nationality string
//  Description
//  This function converts the nationality string stored on ID
//  card to the country ISO code
//  Parameters
//  nationality :  The nationality string
//  iso :          The ISO code memory buffer
//  bufferSize :   The size if the memory buffer
//  Return Value
//  Returns TRUE if the ISO code is successfully obtained; FALSE
//  otherwise                                                    
function GetISOCode(Nationality : PChar; IsoCode : PChar; BufferSize : integer) : BOOL; stdcall;

//  Summary
//  Returns the country ISO code based on the nationality string
//  Description
//  This function converts the nationality string stored on ID
//  card to the country ISO code
//  Parameters
//  nationality :  The nationality string
//  iso :          The ISO code memory buffer
//  bufferSize :   The size if the memory buffer
//  Return Value
//  Returns TRUE if the ISO code is successfully obtained; FALSE
//  otherwise                                                    
function GetISOCodeW(Nationality : PWideChar; IsoCode : PWideChar; BufferSize : integer) : BOOL; stdcall;

//  Summary
//  Returns the country ISO code based on the nationality string
//  Description
//  This function converts the nationality string stored on ID
//  card to the country ISO code
//  Parameters
//  nationality :  The nationality string
//  iso :          The ISO code memory buffer
//  bufferSize :   The size if the memory buffer
//  Return Value
//  Returns TRUE if the ISO code is successfully obtained; FALSE
//  otherwise                                                    
function GetISOCodeA(Nationality : PAnsiChar; IsoCode : PAnsiChar; BufferSize : integer) : BOOL; stdcall;

//  Summary
//  This function brings the specified window to the top of the
//  z-order.
//  Parameters
//  window :  Handle to the window to bring to the top of the
//            z\-order.                                         
procedure BringWindowToFront(Window : THandle); stdcall;

//  Summary
//  Logs off the interactive user, shuts down the system.
//  Description
//  Logs off the interactive user, shuts down the system, or
//  shuts down and restarts the system. It sends the
//  WM_QUERYENDSESSION message to all applications to determine
//  if they can be terminated.
//  
//  This function accepts the following parameter:
//  
//  flags :  The shutdown type. This parameter must include one of
//           the following values\:
//  
//  <table>
//  Value             Meaning
//  ----------------  ------------------------------------------------
//  EWX_LOGOFF        Shuts down all processes running in the logon
//                     session of the process that called the
//                     ExitWindowsEx function. Then it logs the user
//                     off.
//  EWX_POWEROFF      Shuts down the system and turns off the power.
//                     The system must support the power-off feature.
//  EWX_REBOOT        Shuts down the system and then restarts the
//                     system.
//  EWX_RESTARTAPPS   Shuts down the system and then restarts it
//  EWX_SHUTDOWN      Shuts down the system to a point at which it is
//                     safe to turn off the power.
//  </table>
//  
//  Return Value
//  If the function succeeds returns TRUE, otherwise returns
//  FALSE                                                              
function  ShutdownWindows(Flags : UINT) : BOOL; stdcall;

//  Summary
//  Suspends Windows 
function  SuspendWindows() : BOOL; stdcall;

//  Summary
//  Hibernates Windows 
function  HibernateWindows() : BOOL; stdcall;

//  Summary
//  Updated the window position
//  Parameters
//  handle :  The handle of the window
//  x :       New horizontal coordinate
//  y :       New vertical coordinate   
procedure UpdateWindowPosition(Handle : THandle; X : integer; Y : integer); stdcall;

//  Summary
//  Turns the monitor on 
procedure TurnMonitorOn(); stdcall;

//  Summary
//  Turns the monitor off 
procedure TurnMonitorOff(); stdcall;

//  Summary
//  Clears unused memory and minimized the application memory
//  usage                                                     
procedure ClearUnusedMemory(); stdcall;

//  Summary
//  Empties the recycle bin
//  Description
//  Removes all files from the Windows recycle bin 
procedure EmptyRecycleBin(); stdcall;

//  Summary
//  Adds or removes a message from the User Interface Privilege
//  Isolation (UIPI) message filter.
//  Description
//  This function changes the message filter for Windows Vista or
//  better. UIPI is a security feature that prevents messages
//  from being received from a lower integrity level sender. All
//  such messages with a value above WM_USER are blocked by
//  default. The filter, somewhat contrary to intuition, is a
//  list of messages that are allowed through. Therefore, adding
//  a message to the filter allows that message to be received
//  from a lower integrity sender, while removing a message
//  blocks that message from being received.
//  
//  Certain messages with a value less than WM_USER are required
//  to pass through the filter regardless of the filter setting.
//  You can call this function to remove one of those messages
//  from the filter and it will return TRUE. However, the message
//  will still be received by the calling process.
//  Parameters
//  message :  Specifies the message to add to or remove from the
//             filter.
//  dwFlags :  Specifies the action to be performed. One of the
//             following values.
//             * MSGFLT_ADD &#45; Adds the message to the filter.
//               This has the effect of allowing the message to be
//               received.
//             * MSGFLT_REMOVE &#45; Removes the message from the
//               filter. This has the effect of blocking the
//               message.                                          
procedure AddRemoveMessageFilter(Message : UINT; dwFlags : DWORD); stdcall;

//  Summary
//  Repaints the surface of the layered window
//  Parameters
//  handle :      The handle of the window
//  left :        The horizontal coordinate of the window
//  top :         The vertical coordinate of the window
//  width :       The width of the window
//  height :      The height of the window
//  buffer :      Handle to a DC for the surface that defines the
//                layered window
//  colorKey :    COLORREF structure that specifies the color key
//                to be used when composing the layered window. 
//  alpha :       Specifies an alpha transparency value to be used
//                on the entire source bitmap
//  redrawOnly :  Only redraw and do not update the window
//                position                                         
procedure DrawLayeredWindow(WindowHndle : THandle; Left : integer; Top : integer; Width : integer; Height : integer; buffer : HDC; ColorKey : COLORREF; Alpha : byte; redrawOnly : BOOL); stdcall;

//  Summary
//  This function creates the invisible tool window
//  Description
//  This function creates the invisible zero-size tool window
//  that can be used for internal purposes, like processing the
//  special Windows messages for synchronization, etc...
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateDefaultHWND() : THandle; stdcall;

//  Summary
//  The default window procedure for the layered window 
function  LayeredWndProc(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall;

//  Summary
//  Checks if the application is registered to run when Windows
//  starts
//  Parameters
//  appName :  The name of the application                      
function  GetStartup(const AppName : PChar) : BOOL; stdcall;

//  Summary
//  Register application to run when Windows starts
//  Parameters
//  appName :  The name of the application
//  appPath :  The path to the application executable 
procedure SetStartup(const AppName : PChar; const AppPath : PChar); stdcall;

//  Summary
//  Removes the application from the list of the automatically
//  started applications
//  Description
//  For application that starts automatically when Windows starts
//  removes it from the automatically launching applications list
//  Parameters
//  appName :  The name of the application                        
procedure RemoveStartup(const AppName : PChar); stdcall;

//  Summary
//  This function creates the standard window using the provided
//  window class name
//  Description
//  This function creates the standard window using the provided
//  window class name
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateWindowClass(const ClassName : PChar) : THandle; stdcall;

//  Summary
//  This function creates the layered window using the provided
//  window class name
//  Description
//  This function creates the layered window using the provided
//  window class name
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateLayeredWindow(const ClassName : PChar) : THandle; stdcall;

//  Summary
//  Plays the wave sound from the file
//  Description
//  This function plays a sound specified by the given file name.
//  Parameters
//  soundName :  The name of the file
procedure MakeSoundFromFile(const SoundName : PChar); stdcall;

//  Summary
//  Plays the wave sound from the resource
//  Parameters
//  hModule :    Handle to the executable file that contains the
//               resource to be loaded.
//  soundName :  A string that specifies the sound to play.
//  
//  Description
//  This function plays a sound specified by the given resource
//  name.                                                        
procedure MakeSoundFromResource(ModuleHandle : THandle; const SoundName : PChar); stdcall;

//  Summary
//  This function creates the invisible tool window using the
//  provided window procedure
//  Description
//  This function creates the invisible zero-size tool window
//  that can be used for internal purposes, like processing the
//  special Windows messages for synchronization, etc...
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateHWND(WndFunc : TFNWndProc) : THandle; stdcall;

//  Summary
//  This function destroys the specified window.
//  Description
//  This function restores the window default procedure and
//  destroys the window
//  Parameters
//  hwnd :  Handle to the window to be destroyed            
function  DeallocateHWND(Hwnd : THandle) : BOOL; stdcall;

//  Summary
//  Restores window standard procedure
//  Parameters
//  hwnd :  The window handle          
procedure RestoreWindowSubclass(Hwnd : THandle); stdcall;

//  Summary
//  This function creates the invisible tool window
//  Description
//  This function creates the invisible zero-size tool window
//  that can be used for internal purposes, like processing the
//  special Windows messages for synchronization, etc...
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateDefaultHWNDW() : THandle; stdcall;

//  Summary
//  The default window procedure for the layered window 
function  LayeredWndProcW(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall;

//  Summary
//  Checks if the application is registered to run when Windows
//  starts
//  Parameters
//  appName :  The name of the application                      
function  GetStartupW(const AppName : PWideChar) : BOOL; stdcall;

//  Summary
//  Register application to run when Windows starts
//  Parameters
//  appName :  The name of the application
//  appPath :  The path to the application executable 
procedure SetStartupW(const AppName : PWideChar; const AppPath : PWideChar); stdcall;

//  Summary
//  Removes the application from the list of the automatically
//  started applications
//  Description
//  For application that starts automatically when Windows starts
//  removes it from the automatically launching applications list
//  Parameters
//  appName :  The name of the application                        
procedure RemoveStartupW(const AppName : PWideChar); stdcall;

//  Summary
//  This function creates the standard window using the provided
//  window class name
//  Description
//  This function creates the standard window using the provided
//  window class name
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateWindowClassW(const ClassName : PWideChar) : THandle; stdcall;

//  Summary
//  This function creates the layered window using the provided
//  window class name
//  Description
//  This function creates the layered window using the provided
//  window class name
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateLayeredWindowW(const ClassName : PWideChar) : THandle; stdcall;

//  Summary
//  Plays the wave sound from the file
//  Description
//  This function plays a sound specified by the given file name.
//  Parameters
//  soundName :  The name of the file                             
procedure MakeSoundFromFileW(const SoundName : PWideChar); stdcall;

//  Summary
//  Plays the wave sound from the resource
//  Parameters
//  hModule :    Handle to the executable file that contains the
//               resource to be loaded.
//  soundName :  A string that specifies the sound to play.
//  Description
//  This function plays a sound specified by the given resource
//  name.                                                        
procedure MakeSoundFromResourceW(ModuleHandle : THandle; const SoundName : PWideChar); stdcall;

//  Summary
//  This function creates the invisible tool window using the
//  provided window procedure
//  Description
//  This function creates the invisible zero-size tool window
//  that can be used for internal purposes, like processing the
//  special Windows messages for synchronization, etc...
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL. 
function  AllocateHWNDW(WndFunc : TFNWndProc) : THandle; stdcall;

//  Summary
//  This function destroys the specified window.
//  Description
//  This function restores the window default procedure and
//  destroys the window
//  Parameters
//  hwnd :  Handle to the window to be destroyed            
function  DeallocateHWNDW(Hwnd : THandle) : BOOL; stdcall;

//  Summary
//  Restores window standard procedure
//  Parameters
//  hwnd :  The window handle          
procedure RestoreWindowSubclassW(Hwnd : THandle); stdcall;

//  Summary
//  This function creates the invisible tool window
//  Description
//  This function creates the invisible zero-size tool window
//  that can be used for internal purposes, like processing the
//  special Windows messages for synchronization, etc...
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateDefaultHWNDA() : THandle; stdcall;

//  Summary
//  The default window procedure for the layered window 
function  LayeredWndProcA(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall;

//  Summary
//  Checks if the application is registered to run when Windows
//  starts
//  Parameters
//  appName :  The name of the application                      
function  GetStartupA(const AppName : PAnsiChar) : BOOL; stdcall;

//  Summary
//  Register application to run when Windows starts
//  Parameters
//  appName :  The name of the application
//  appPath :  The path to the application executable 
procedure SetStartupA(const AppName : PAnsiChar; const AppPath : PAnsiChar); stdcall;

//  Summary
//  Removes the application from the list of the automatically
//  started applications
//  Description
//  For application that starts automatically when Windows starts
//  removes it from the automatically launching applications list
//  Parameters
//  appName :  The name of the application                        
procedure RemoveStartupA(const AppName : PAnsiChar); stdcall;

//  Summary
//  This function creates the standard window using the provided
//  window class name
//  Description
//  This function creates the standard window using the provided
//  window class name
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateWindowClassA(const ClassName : PAnsiChar) : THandle; stdcall;

//  Summary
//  This function creates the layered window using the provided
//  window class name
//  Description
//  This function creates the layered window using the provided
//  window class name
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL.  
function  AllocateLayeredWindowA(const ClassName : PAnsiChar) : THandle; stdcall;

//  Summary
//  Plays the wave sound from the file
//  Description
//  This function plays a sound specified by the given file name.
//  Parameters
//  soundName :  The name of the file                             
procedure MakeSoundFromFileA(const SoundName : PAnsiChar); stdcall;

//  Summary
//  Plays the wave sound from the resource
//  Parameters
//  hModule :    Handle to the executable file that contains the
//               resource to be loaded.
//  soundName :  A string that specifies the sound to play.
//  Description
//  This function plays a sound specified by the given resource
//  name.                                                        
procedure MakeSoundFromResourceA(ModuleHandle : THandle; const SoundName : PAnsiChar); stdcall;

//  Summary
//  This function creates the invisible tool window using the
//  provided window procedure
//  Description
//  This function creates the invisible zero-size tool window
//  that can be used for internal purposes, like processing the
//  special Windows messages for synchronization, etc...
//  Return Value
//  If the function succeeds, the return value is a handle to the
//  new window. If the function fails, the return value is NULL. 
function  AllocateHWNDA(WndFunc : TFNWndProc) : THandle; stdcall;

//  Summary
//  This function destroys the specified window.
//  Description
//  This function restores the window default procedure and
//  destroys the window
//  Parameters
//  hwnd :  Handle to the window to be destroyed            
function  DeallocateHWNDA(Hwnd : THandle) : BOOL; stdcall;

//  Summary
//  Restores window standard procedure
//  Parameters
//  hwnd :  The window handle          
procedure RestoreWindowSubclassA(Hwnd : THandle); stdcall;

//Checks if PC is Running Windows 8 or better
function IsWindows8() : BOOL; stdcall;

//Checks if metro interface is active
function IsMetroActive() : BOOL; stdcall;

//Checks if PC is running Windows 7 or better
function IsWindows7() : BOOL; stdcall;

//Checks if PC is running Windows Vista or better
function IsWindowsVista() : BOOL; stdcall;

//Checks if PC is running Windows XP
function IsWindowsXP() : BOOL; stdcall;

//Checks if PC is running Windows XP with Service Pack 2 installed
function IsWindowsXPSP2() : BOOL; stdcall;

//Checks if the system is multi touch ready
function IsMultiTouchReady() : BOOL; stdcall;

//Checks if the application is running on the Tablet PC
function IsTabletPC() : BOOL; stdcall;

//Checks if the Media Center version of Windows is installed
function IsMediaCenter() : BOOL; stdcall;

//Checks if PC is connected to Internet
function IsConnectedToInternet() : BOOL; stdcall;

//Checks if the port with specified number is available
function PortAvailable(PortNumber : integer) : BOOL; stdcall;

//Checks if the 32 bit application runs on 64 bit Windows
function IsWow64() : BOOL; stdcall;

//Checks if the application is native 64 bit executable
function IsNativeWin64() : BOOL; stdcall;

//Returns the IP address
procedure CurrentIPAddress(Address : PChar; Len : UINT); stdcall;

//Returns the IP address
procedure CurrentIPAddressW(Address : PWideChar; Len : UINT); stdcall;

//Returns the IP address
procedure CurrentIPAddressA(Address : PAnsiChar; Len : UINT); stdcall;

//Shows Dialog with the text message corresponding to the Windows
//error code
procedure ShowError(ErrorCode : DWORD); stdcall;

//  Summary
//  Generates PNG file with QR Code image
//  Description
//  Generates PNG file with encoded text as QR Code image
//  Parameters
//  fileName :  The name of the file
//  text :      The text to encode
//  margin :    The margin from the border in points
//  size :      The size of the one point in pixels
//  level :     The error correction level                
procedure GeneratePNG (FileName: PChar; Text : PChar; Margin : integer; Size : integer; Level : integer); stdcall;

//  Summary
//  Generates PNG file with QR Code image
//  Description
//  Generates PNG file with encoded text as QR Code image
//  Parameters
//  fileName :  The name of the file
//  text :      The text to encode
//  margin :    The margin from the border in points
//  size :      The size of the one point in pixels
//  level :     The error correction level                
procedure GeneratePNGW(FileName: PWideChar; Text : PWideChar; Margin : integer; Size : integer; Level : integer); stdcall;

//  Summary
//  Generates PNG file with QR Code image
//  Description
//  Generates PNG file with encoded text as QR Code image
//  Parameters
//  fileName :  The name of the file
//  text :      The text to encode
//  margin :    The margin from the border in points
//  size :      The size of the one point in pixels
//  level :     The error correction level
procedure GeneratePNGA(FileName: PAnsiChar; Text : PAnsiChar; Margin : integer; Size : integer; Level : integer); stdcall;

//  Summary
//  Generates Windows Bitmap in memory with QR Code image
//  Description
//  Generates Windows Bitmap in memory file with encoded text as
//  QR Code image
//  Parameters
//  text :    The text to encode
//  margin :  The margin from the border in points
//  size :    The size of the one point in pixels
//  level :   The error correction level
//  Return Value
//  The result of the function is HBITMAP handle. You have to
//  destroy it by yourself when its not needed anymore.          
function GetHBitmap(Text : PChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall;

//  Summary
//  Generates Windows Bitmap in memory with QR Code image
//  Description
//  Generates Windows Bitmap in memory file with encoded text as
//  QR Code image
//  Parameters
//  text :    The text to encode
//  margin :  The margin from the border in points
//  size :    The size of the one point in pixels
//  level :   The error correction level
//  Return Value
//  The result of the function is HBITMAP handle. You have to
//  destroy it by yourself when its not needed anymore.          
function GetHBitmapW(Text : PWideChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall;

//  Summary
//  Generates Windows Bitmap in memory with QR Code image
//  Description
//  Generates Windows Bitmap in memory file with encoded text as
//  QR Code image
//  Parameters
//  text :    The text to encode
//  margin :  The margin from the border in points
//  size :    The size of the one point in pixels
//  level :   The error correction level
//  Return Value
//  The result of the function is HBITMAP handle. You have to
//  destroy it by yourself when its not needed anymore.          
function GetHBitmapA(Text : PAnsiChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall;

//  Summary
//  Generates Windows Bitmap file with QR Code image
//  Description
//  Generate Windows Bitmap file with encoded text as QR Code
//  image
//  Parameters
//  fileName :  The name of the file
//  text :      The text to encode
//  margin :    The margin from the border in points
//  size :      The size of the one point in pixels
//  level :     The error correction level                    
procedure GenerateBMP(FileName: PChar; Text : PChar; Margin : integer; Size : integer; Level : integer); stdcall;

//  Summary
//  Generates Windows Bitmap file with QR Code image
//  Description
//  Generate Windows Bitmap file with encoded text as QR Code
//  image
//  Parameters
//  fileName :  The name of the file
//  text :      The text to encode
//  margin :    The margin from the border in points
//  size :      The size of the one point in pixels
//  level :     The error correction level                    
procedure GenerateBMPW(FileName: PWideChar; Text : PWideChar; Margin : integer; Size : integer; Level : integer); stdcall;

//  Summary
//  Generates Windows Bitmap file with QR Code image
//  Description
//  Generate Windows Bitmap file with encoded text as QR Code
//  image
//  Parameters
//  fileName :  The name of the file
//  text :      The text to encode
//  margin :    The margin from the border in points
//  size :      The size of the one point in pixels
//  level :     The error correction level                    
procedure GenerateBMPA(FileName: PAnsiChar; Text : PAnsiChar; Margin : integer; Size : integer; Level : integer); stdcall;

//  Summary
//  Writes PNG image to the memory buffer.
//  Description
//  Writes PNG image to the memory buffer. Can be useful for web
//  development.
//  Parameters
//  text :     The text to encode
//  margin :   The margin from the image border in points
//  size :     The size of the point in pixels
//  level :    The error correction level
//  bufSize :  The size of the output buffer
//  ppvBits :  The buffer when the resulting image is stored
procedure GetPNG(Text : PChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall;

//  Summary
//  Writes PNG image to the memory buffer.
//  Description
//  Writes PNG image to the memory buffer. Can be useful for web
//  development.
//  Parameters
//  text :     The text to encode
//  margin :   The margin from the image border in points
//  size :     The size of the point in pixels
//  level :    The error correction level
//  bufSize :  The size of the output buffer
//  ppvBits :  The buffer when the resulting image is stored
procedure GetPNGW(Text : PWideChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall;

//  Summary
//  Writes PNG image to the memory buffer.
//  Description
//  Writes PNG image to the memory buffer. Can be useful for web
//  development.
//  Parameters
//  text :     The text to encode
//  margin :   The margin from the image border in points
//  size :     The size of the point in pixels
//  level :    The error correction level
//  bufSize :  The size of the output buffer
//  ppvBits :  The buffer when the resulting image is stored
procedure GetPNGA(Text : PAnsiChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall;

//  Summary
//  Destroys the memory buffer
//  Description
//  Destroys the memory buffer created to hold the image returned
//  by GetPNGA (Ansi) or GetPNGW (Unicode) functions
//  Parameters
//  buffer :  The memory buffer
procedure DestroyImageBuffer(Buffer : PByte); stdcall;

// Summary
// Gets the card serial number
// Description
// Use this function to read the serial number of the card
// Parameters
// readerNumber : the index of the card reader
// serialNumber : the buffer to get the serial number value
// serialNumberSize: the size of the buffer
function GetCardSerialNumber(readerNumber : integer; serialNumber :PBYTE; var serialNumberSize : DWORD) : BOOL; stdcall;

// Summary:
//		Sign data with eID card according to CMS standard
// Description:
//		Create CMS signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		readerNumber - The zero-based index of the card reader.
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
// Return value:
//		Returns true if the operation is successful, otherwise returns false
function CardSignCMS(readerNumber : integer; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall;

// Summary:
//		Sign data with eID card according to CADES-T standard
// Description:
//		Create CADES-T signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		readerNumber - The zero-based index of the card reader.
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
// Return value:
//		Returns true if the operation is successful, otherwise returns false
function CardSignCadesT(readerNumber : integer; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall;

// Summary:
//		Sign data with certificate according to CMS standard
// Description:
//		Create CMS signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		certificate : the name of the certificate file
//    password : password of the certificate file
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
// Return value:
//		Returns true if the operation is successful, otherwise returns false
function CertSignCMS(certificate : PWideChar; password : PWideChar; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall;

// Summary:
//		Sign data with certificate according to CADES-T standard
// Description:
//		Create CADES-T signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		certificate : the name of the certificate file
//    password : password of the certificate file
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
// Return value:
//		Returns true if the operation is successful, otherwise returns false
function CertSignCadesT(certificate : PWideChar; password : PWideChar; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall;

function InitializeContainer() : pointer; stdcall;

procedure FreeContainer(Container: pointer); stdcall;

function SaveContainer(Container: pointer; fileName: PWideChar) : BOOL; stdcall;

function AddFileToContainer(Container: pointer; fileName: PAnsiChar) : BOOL; stdcall;

function ContainerCertificate(Container: pointer; fileName: PWideChar; password : PWideChar) : BOOL; stdcall;

function ContainerPickCertificate(Container: pointer) : BOOL; stdcall;

function ContainerEidCertificate(Container: pointer; readerNumber : integer) : BOOL; stdcall;

implementation

const
{$IFDEF CPUX64}
  SwelioLib = 'Swelio64.dll';
{$ELSE}
  SwelioLib = 'Swelio32.dll';
{$ENDIF}

function GetCardSerialNumber(readerNumber : integer; serialNumber :PBYTE; var serialNumberSize : DWORD) : BOOL; stdcall; external SwelioLib;
function CardSignCMS(readerNumber : integer; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall; external SwelioLib;
function CardSignCadesT(readerNumber : integer; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall; external SwelioLib;
function CertSignCMS(certificate : PWideChar; password : PWideChar; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall; external SwelioLib;
function CertSignCadesT(certificate : PWideChar; password : PWideChar; data : PBYTE; dataLen : integer; signature : PBYTE; var signatureLen : longword) : BOOL; stdcall; external SwelioLib;

function InitializeContainer() : pointer; stdcall; external SwelioLib;

procedure FreeContainer(Container: pointer); stdcall; external SwelioLib;

function SaveContainer(Container: pointer; fileName: PWideChar) : BOOL; stdcall; external SwelioLib;

function AddFileToContainer(Container: pointer; fileName: PAnsiChar) : BOOL; stdcall; external SwelioLib;

function ContainerCertificate(Container: pointer; fileName: PWideChar; password : PWideChar) : BOOL; stdcall; external SwelioLib;

function ContainerPickCertificate(Container: pointer) : BOOL; stdcall; external SwelioLib;

function ContainerEidCertificate(Container: pointer; readerNumber : integer) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure GeneratePNG (FileName: PChar; Text : PChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib name 'GeneratePNGW';
{$ELSE}
procedure GeneratePNG (FileName: PChar; Text : PChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib name 'GeneratePNGA';
{$ENDIF}

procedure GeneratePNGW(FileName: PWideChar; Text : PWideChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib;
procedure GeneratePNGA(FileName: PAnsiChar; Text : PAnsiChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib;

{$IFDEF UNICODE}
function GetHBitmap(Text : PChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall; external SwelioLib name 'GetHBitmapW';
{$ELSE}
function GetHBitmap(Text : PChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall; external SwelioLib name 'GetHBitmapA';
{$ENDIF}

function GetHBitmapW(Text : PWideChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall; external SwelioLib;
function GetHBitmapA(Text : PAnsiChar; Margin : integer; Size : integer; Level : integer) : HBITMAP; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure GenerateBMP(FileName: PChar; Text : PChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib name 'GenerateBMPW';
{$ELSE}
procedure GenerateBMP(FileName: PChar; Text : PChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib name 'GenerateBMPA';
{$ENDIF}

procedure GenerateBMPW(FileName: PWideChar; Text : PWideChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib;
procedure GenerateBMPA(FileName: PAnsiChar; Text : PAnsiChar; Margin : integer; Size : integer; Level : integer); stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure GetPNG(Text : PChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall; external SwelioLib name 'GetPNGW';
{$ELSE}
procedure GetPNG(Text : PChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall; external SwelioLib name 'GetPNGA';
{$ENDIF}

procedure GetPNGW(Text : PWideChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall; external SwelioLib;
procedure GetPNGA(Text : PAnsiChar; Margin : integer; Size : integer; Level : integer; var BufSize : integer; out ppvBits : PByte); stdcall; external SwelioLib;

procedure DestroyImageBuffer(Buffer : PByte); stdcall; external SwelioLib;

procedure SetMWCompatibility(); stdcall; external SwelioLib name 'SetMWCompatibility';
function  StartEngine() : BOOL; stdcall; external SwelioLib name 'StartEngine';
procedure StopEngine(); stdcall; external SwelioLib name 'StopEngine';
function  IsEngineActive() : BOOL; stdcall; external SwelioLib;
function  GetReadersCount() : integer; stdcall; external SwelioLib name 'GetReadersCount';
function  SelectReader(ReaderNumber : integer) : BOOL; stdcall; external SwelioLib name 'SelectReader';
function  GetSelectedReaderIndex() : integer; stdcall; external SwelioLib name 'GetSelectedReaderIndex';

{$IFDEF UNICODE}
function  SelectReaderByName(ReaderName : PChar) : BOOL; stdcall; external SwelioLib name 'SelectReaderByNameW';
{$ELSE}
function  SelectReaderByName(ReaderName : PChar) : BOOL; stdcall; external SwelioLib name 'SelectReaderByNameA';
{$ENDIF}

function  SelectReaderByNameW(readerName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SelectReaderByNameA(ReaderName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GetReaderNameLen(ReaderNumber : integer) : integer; stdcall; external SwelioLib name 'GetReaderNameLenW';
{$ELSE}
function  GetReaderNameLen(ReaderNumber : integer) : integer; stdcall; external SwelioLib name 'GetReaderNameLenA';
{$ENDIF}

function  GetReaderNameLenW(ReaderNumber : integer) : integer; stdcall; external SwelioLib;
function  GetReaderNameLenA(ReaderNumber : integer) : integer; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GetReaderName(ReaderNumber : integer; StrDest : PChar; Count : integer) : integer; stdcall; external SwelioLib name 'GetReaderNameW';
{$ELSE}
function  GetReaderName(ReaderNumber : integer; StrDest : PChar; Count : integer) : integer; stdcall; external SwelioLib name 'GetReaderNameA';
{$ENDIF}

function  GetReaderNameW(ReaderNumber : integer; StrDest : PWideChar; Count : integer) : integer; stdcall; external SwelioLib;
function  GetReaderNameA(ReaderNumber : integer; StrDest : PAnsiChar; Count : integer) : integer; stdcall; external SwelioLib;

function  GetSupportSIS() : BOOL; stdcall; external SwelioLib;
procedure SetSupportSIS(Value : BOOL); stdcall; external SwelioLib;

function  IsCardPresent() : BOOL; stdcall; external SwelioLib;
function  IsCardPresentEx(ReaderNumber : integer) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GetReaderIndex(ReaderName : PChar) : integer; stdcall; external SwelioLib name 'GetReaderIndexW';
{$ELSE}
function  GetReaderIndex(ReaderName : PChar) : integer; stdcall; external SwelioLib name 'GetReaderIndexA';
{$ENDIF}

function  GetReaderIndexW(ReaderName : PWideChar) : integer; stdcall; external SwelioLib;
function  GetReaderIndexA(ReaderName : PAnsiChar) : integer; stdcall; external SwelioLib;

function  ActivateCard() : BOOL; stdcall; external SwelioLib;
function  ActivateCardEx(ReaderNumber : integer) : BOOL; stdcall; external SwelioLib;

procedure DeactivateCard(); stdcall; external SwelioLib;
procedure DeactivateCardEx(ReaderNumber : integer); stdcall; external SwelioLib;

function  IsEIDCard() : BOOL; stdcall; external SwelioLib;
function  IsSISCard() : BOOL; stdcall; external SwelioLib;

function  IsEIDCardEx(ReaderNumber : integer) : BOOL; stdcall; external SwelioLib;
function  IsSISCardEx(ReaderNumber : integer) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SavePhotoAsJpeg(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsJpegW';
{$ELSE}
function  SavePhotoAsJpeg(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsJpegA';
{$ENDIF}

function  SavePhotoAsJpegW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SavePhotoAsJpegA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SavePhotoAsJpegEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsJpegExW';
{$ELSE}
function  SavePhotoAsJpegEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsJpegExA';
{$ENDIF}

function  SavePhotoAsJpegExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SavePhotoAsJpegExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SavePhotoAsBitmap(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsBitmapW';
{$ELSE}
function  SavePhotoAsBitmap(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsBitmapA';
{$ENDIF}

function  SavePhotoAsBitmapW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SavePhotoAsBitmapA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SavePhotoAsBitmapEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsBitmapExW';
{$ELSE}
function  SavePhotoAsBitmapEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePhotoAsBitmapExA';
{$ENDIF}

function  SavePhotoAsBitmapExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SavePhotoAsBitmapExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

function  ReadPhotoAsBitmap() : HBITMAP; stdcall; external SwelioLib;
function  ReadPhotoAsBitmapEx(ReaderNumber : integer) : HBITMAP; stdcall; external SwelioLib;
function  ReadPhoto(Photo : PeidPicture) : BOOL; stdcall; external SwelioLib;
function  ReadPhotoEx(ReaderNumber : integer; Photo : PeidPicture) : BOOL; stdcall; external SwelioLib;
function  EncodePhoto(Photo : PeidPicture;  Buffer : PBYTE;  BufferSize : integer) : integer; stdcall; external SwelioLib;
function  GetEncodedPhotoSize(photo : PeidPicture) : integer; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure LoadPhoto(Photo : PeidPicture; FileName : PChar); stdcall; external SwelioLib name 'LoadPhotoW';
{$ELSE}
procedure LoadPhoto(Photo : PeidPicture; FileName : PChar); stdcall; external SwelioLib name 'LoadPhotoA';
{$ENDIF}

procedure LoadPhotoW(Photo : PeidPicture; FileName : PWideChar); stdcall; external SwelioLib;
procedure LoadPhotoA(Photo : PeidPicture; FileName : PAnsiChar); stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure SavePhoto(Photo : PeidPicture; FileName : PChar); stdcall; external SwelioLib name 'SavePhotoW';
{$ELSE}
procedure SavePhoto(Photo : PeidPicture; FileName : PChar); stdcall; external SwelioLib name 'SavePhotoA';
{$ENDIF}

procedure SavePhotoW(Photo : PeidPicture; FileName : PWideChar); stdcall; external SwelioLib;
procedure SavePhotoA(Photo : PeidPicture; FileName : PAnsiChar); stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  ReadIdentity(identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'ReadIdentityW';
{$ELSE}
function  ReadIdentity(identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'ReadIdentityA';
{$ENDIF}

function  ReadIdentityW(identity : PEidIdentityW) : BOOL; stdcall; external SwelioLib;
function  ReadIdentityA(identity : PEidIdentityA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  ReadAddress(address : PEidAddress) : BOOL; stdcall; external SwelioLib name 'ReadAddressW';
{$ELSE}
function  ReadAddress(address : PEidAddress) : BOOL; stdcall; external SwelioLib name 'ReadAddressA';
{$ENDIF}

function  ReadAddressW(address : PEidAddressW) : BOOL; stdcall; external SwelioLib;
function  ReadAddressA(address : PEidAddressA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  ReadIdentityEx(ReaderNumber : integer; identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'ReadIdentityExW';
{$ELSE}
function  ReadIdentityEx(ReaderNumber : integer; identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'ReadIdentityExA';
{$ENDIF}

function  ReadIdentityExW(ReaderNumber : integer; identity : PEidIdentityW) : BOOL; stdcall; external SwelioLib;
function  ReadIdentityExA(ReaderNumber : integer; identity : PEidIdentityA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  ReadAddressEx(ReaderNumber : integer; address : PEidAddress) : BOOL; stdcall; external SwelioLib name 'ReadAddressExW';
{$ELSE}
function  ReadAddressEx(ReaderNumber : integer; address : PEidAddress) : BOOL; stdcall; external SwelioLib name 'ReadAddressExA';
{$ENDIF}

function  ReadAddressExW(ReaderNumber : integer; address : PEidAddressW) : BOOL; stdcall; external SwelioLib;
function  ReadAddressExA(ReaderNumber : integer; address : PEidAddressA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  ReadSISCard(Identity : PSISRecord) : BOOL; stdcall; external SwelioLib name 'ReadSISCardW';
{$ELSE}
function  ReadSISCard(Identity : PSISRecord) : BOOL; stdcall; external SwelioLib name 'ReadSISCardA';
{$ENDIF}

function  ReadSISCardW(Identity : PSISRecordW) : BOOL; stdcall; external SwelioLib;
function  ReadSISCardA(Identity : PSISRecordA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  ReadSISCardEx(ReaderNumber : integer; Identity : PSISRecord) : BOOL; stdcall; external SwelioLib name 'ReadSISCardExW';
{$ELSE}
function  ReadSISCardEx(ReaderNumber : integer; Identity : PSISRecord) : BOOL; stdcall; external SwelioLib name 'ReadSISCardExA';
{$ENDIF}

function  ReadSISCardExW(ReaderNumber : integer; Identity : PSISRecordW) : BOOL; stdcall; external SwelioLib;
function  ReadSISCardExA(ReaderNumber : integer; Identity : PSISRecordA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure SaveIdentity(FileName : PChar); stdcall; external SwelioLib name 'SaveIdentityW';
{$ELSE}
procedure SaveIdentity(FileName : PChar); stdcall; external SwelioLib name 'SaveIdentityA';
{$ENDIF}

procedure SaveIdentityW(FileName : PWideChar); stdcall; external SwelioLib;
procedure SaveIdentityA(FileName : PAnsiChar); stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure LoadIdentity(FileName : PChar;  identity : PEidIdentity); stdcall; external SwelioLib name 'LoadIdentityW';
{$ELSE}
procedure LoadIdentity(FileName : PChar;  identity : PEidIdentity); stdcall; external SwelioLib name 'LoadIdentityA';
{$ENDIF}

procedure LoadIdentityW(FileName : PWideChar; identity : PEidIdentityW); stdcall; external SwelioLib;
procedure LoadIdentityA(FileName : PAnsiChar;  identity : PEidIdentityA); stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure SaveAuthenticationCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveAuthenticationCertificateW';
procedure SaveNonRepudiationCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveNonRepudiationCertificateW';
procedure SaveCaCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveCaCertificateW';
procedure SaveRootCaCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveRootCaCertificateW';
procedure SaveRrnCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveRrnCertificateW';
{$ELSE}
procedure SaveAuthenticationCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveAuthenticationCertificateW';
procedure SaveNonRepudiationCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveNonRepudiationCertificateW';
procedure SaveCaCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveCaCertificateW';
procedure SaveRootCaCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveRootCaCertificateW';
procedure SaveRrnCertificate(FileName : PChar); stdcall; external SwelioLib name 'SaveRrnCertificateW';
{$ENDIF}

procedure SaveAuthenticationCertificateW(FileName : PWideChar); stdcall; external SwelioLib;
procedure SaveNonRepudiationCertificateW(FileName : PWideChar); stdcall; external SwelioLib;
procedure SaveCaCertificateW(FileName : PWideChar); stdcall; external SwelioLib;
procedure SaveRootCaCertificateW(FileName : PWideChar); stdcall; external SwelioLib;
procedure SaveRrnCertificateW(FileName : PWideChar); stdcall; external SwelioLib;

procedure SaveAuthenticationCertificateA(FileName : PAnsiChar); stdcall; external SwelioLib;
procedure SaveNonRepudiationCertificateA(FileName : PAnsiChar); stdcall; external SwelioLib;
procedure SaveCaCertificateA(FileName : PAnsiChar); stdcall; external SwelioLib;
procedure SaveRootCaCertificateA(FileName : PAnsiChar); stdcall; external SwelioLib;
procedure SaveRrnCertificateA(FileName : PAnsiChar); stdcall; external SwelioLib;

function  ReadAuthenticationCertificate(Certificate : PEidCertificate) : BOOL; stdcall; external SwelioLib;
function  ReadNonRepudiationCertificate(Certificate : PEidCertificate) : BOOL; stdcall; external SwelioLib;
function  ReadCaCertificate(Certificate : PEidCertificate) : BOOL; stdcall; external SwelioLib;
function  ReadRootCaCertificate(Certificate : PEidCertificate) : BOOL; stdcall; external SwelioLib;
function  ReadRrnCertificate(Certificate : PEidCertificate) : BOOL; stdcall; external SwelioLib;

function  EncodeCertificate(Certificate : PEidCertificate; Buffer : PBYTE;  BufferSize : integer) : integer; stdcall; external SwelioLib;
function  GetEncodedCertificateSize(Certificate : PEidCertificate) : integer; stdcall; external SwelioLib;
procedure DisplayCertificate(Certificate : PEidCertificate); stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure LoadCertificate(FileName : PChar; Certificate : PEidCertificate); stdcall; external SwelioLib name 'LoadCertificateW';
{$ELSE}
procedure LoadCertificate(FileName : PChar; Certificate : PEidCertificate); stdcall; external SwelioLib name 'LoadCertificateA';
{$ENDIF}

procedure LoadCertificateW(FileName : PWideChar; Certificate : PEidCertificate); stdcall; external SwelioLib;
procedure LoadCertificateA(FileName : PAnsiChar; Certificate : PEidCertificate); stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  VerifyPin(Value : PChar) : BOOL; stdcall; external SwelioLib name 'VerifyPinW';
{$ELSE}
function  VerifyPin(Value : PChar) : BOOL; stdcall; external SwelioLib name 'VerifyPinA';
{$ENDIF}

function  VerifyPinW(Value : PWideChar) : BOOL; stdcall; external SwelioLib;
function  VerifyPinA(Value : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  VerifyPinEx(ReaderNumber : integer; Value : PChar) : BOOL; stdcall; external SwelioLib name 'VerifyPinExW';
{$ELSE}
function  VerifyPinEx(ReaderNumber : integer; Value : PChar) : BOOL; stdcall; external SwelioLib name 'VerifyPinExA';
{$ENDIF}

function  VerifyPinExW(ReaderNumber : integer; Value : PWideChar) : BOOL; stdcall; external SwelioLib;
function  VerifyPinExA(ReaderNumber : integer; Value : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SavePersonToCsv(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePersonToCsvW';
{$ELSE}
function  SavePersonToCsv(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePersonToCsvA';
{$ENDIF}

function  SavePersonToCsvW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SavePersonToCsvA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SavePersonToCsvEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePersonToCsvExW';
{$ELSE}
function  SavePersonToCsvEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SavePersonToCsvExA';
{$ENDIF}

function  SavePersonToCsvExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SavePersonToCsvExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SaveCardToXml(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SaveCardToXmlW';
{$ELSE}
function  SaveCardToXml(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SaveCardToXmlA';
{$ENDIF}

function  SaveCardToXmlW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SaveCardToXmlA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  SaveCardToXmlEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SaveCardToXmlExW';
{$ELSE}
function  SaveCardToXmlEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'SaveCardToXmlExA';
{$ENDIF}

function  SaveCardToXmlExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  SaveCardToXmlExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GenerateQRCode(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'GenerateQRCodeW';
{$ELSE}
function  GenerateQRCode(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'GenerateQRCodeA';
{$ENDIF}

function  GenerateQRCodeW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  GenerateQRCodeA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GenerateQRCodeEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'GenerateQRCodeExW';
{$ELSE}
function  GenerateQRCodeEx(ReaderNumber : integer; FileName : PChar) : BOOL; stdcall; external SwelioLib name 'GenerateQRCodeExA';
{$ENDIF}

function  GenerateQRCodeExW(ReaderNumber : integer; FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function  GenerateQRCodeExA(ReaderNumber : integer; FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  IsFemale(Identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'IsFemaleW';
{$ELSE}
function  IsFemale(Identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'IsFemaleA';
{$ENDIF}

function  IsFemaleW(Identity : PEidIdentityW) : BOOL; stdcall; external SwelioLib;
function  IsFemaleA(Identity : PEidIdentityA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  IsMale(Identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'IsMaleW';
{$ELSE}
function  IsMale(Identity : PEidIdentity) : BOOL; stdcall; external SwelioLib name 'IsMaleA';
{$ENDIF}

function  IsMaleW(Identity : PEidIdentityW) : BOOL; stdcall; external SwelioLib;
function  IsMaleA(Identity : PEidIdentityA) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GenerateAuthenticationSignature(PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateAuthenticationSignatureW';
{$ELSE}
function  GenerateAuthenticationSignature(PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateAuthenticationSignatureA';
{$ENDIF}

function  GenerateAuthenticationSignatureW(PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;
function  GenerateAuthenticationSignatureA(PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GenerateNonRepudiationSignature(PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateNonRepudiationSignatureW';
{$ELSE}
function  GenerateNonRepudiationSignature(PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateNonRepudiationSignatureA';
{$ENDIF}

function  GenerateNonRepudiationSignatureW(PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;
function  GenerateNonRepudiationSignatureA(PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GenerateAuthenticationSignatureEx(ReaderNumber : integer; PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateAuthenticationSignatureExW';
{$ELSE}
function  GenerateAuthenticationSignatureEx(ReaderNumber : integer; PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateAuthenticationSignatureExA';
{$ENDIF}

function  GenerateAuthenticationSignatureExW(ReaderNumber : integer; PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;
function  GenerateAuthenticationSignatureExA(ReaderNumber : integer; PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  GenerateNonRepudiationSignatureEx(ReaderNumber : integer; PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateNonRepudiationSignatureExW';
{$ELSE}
function  GenerateNonRepudiationSignatureEx(ReaderNumber : integer; PinCode : PChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib name 'GenerateNonRepudiationSignatureExA';
{$ENDIF}

function  GenerateNonRepudiationSignatureExA(ReaderNumber : integer; PinCode : PAnsiChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;
function  GenerateNonRepudiationSignatureExW(ReaderNumber : integer; PinCode : PWideChar; DataHash : PBYTE; HashSize : integer; Signature : PBYTE; SignatureSize : LPDWORD) : BOOL; stdcall; external SwelioLib;

function  VerifySignature(Certificate : PEidCertificate; Buffer : PBYTE; BufferSize : integer; Signature : PBYTE; signatureSize : DWORD) : BOOL; stdcall; external SwelioLib;

procedure SetCallback(callback : TReaderCallback; userContext : Pointer); stdcall; external SwelioLib;

procedure RemoveCallback(); stdcall; external SwelioLib;

procedure ReloadReadersList; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function GetFileSHA1(FileName : PChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib name 'GetFileSHA1W';
{$ELSE}
function GetFileSHA1(FileName : PChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib name 'GetFileSHA1A';
{$ENDIF}

function GetFileSHA1W(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;
function GetFileSHA1A(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function GetFileMD5(FileName : PChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib name 'GetFileMD5W';
{$ELSE}
function GetFileMD5(FileName : PChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib name 'GetFileMD5A';
{$ENDIF}

function GetFileMD5W(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;
function GetFileMD5A(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;

function GetSHA1(Source : PBYTE; SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;
function GetMD5(Source : PBYTE;  SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;

function CheckSHA1(Source : PBYTE; SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;
function CheckMD5(Source : PBYTE;  SourceSize : integer; Buffer : PBYTE; BufferSize : integer) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function EncryptFileAES(Source : PChar; Destination : PChar; Password : PChar) : BOOL; stdcall; external SwelioLib name 'EncryptFileAESW';
{$ELSE}
function EncryptFileAES(Source : PChar; Destination : PChar; Password : PChar) : BOOL; stdcall; external SwelioLib name 'EncryptFileAESA';
{$ENDIF}

function EncryptFileAESW(Source : PWideChar; Destination : PWideChar; Password : PWideChar) : BOOL; stdcall; external SwelioLib;
function EncryptFileAESA(Source : PAnsiChar; Destination : PAnsiChar; Password : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function DecryptFileAES(Source : PChar; Destination : PChar; Password : PChar) : BOOL; stdcall; external SwelioLib name 'DecryptFileAESW';
{$ELSE}
function DecryptFileAES(Source : PChar; Destination : PChar; Password : PChar) : BOOL; stdcall; external SwelioLib name 'DecryptFileAESA';
{$ENDIF}

function DecryptFileAESW(Source : PWideChar; Destination : PWideChar; Password : PWideChar) : BOOL; stdcall; external SwelioLib;
function DecryptFileAESA(Source : PAnsiChar; Destination : PAnsiChar; Password : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function CardEncryptFile(Source : PChar; Destination : PChar) : BOOL; stdcall; external SwelioLib name 'CardEncryptFileW';
{$ELSE}
function CardEncryptFile(Source : PChar; Destination : PChar) : BOOL; stdcall; external SwelioLib name 'CardEncryptFileA';
{$ENDIF}

function CardEncryptFileW(Source : PWideChar; Destination : PWideChar) : BOOL; stdcall; external SwelioLib;
function CardEncryptFileA(Source : PAnsiChar; Destination : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
function CardDecryptFile(Source : PChar; Destination : PChar) : BOOL; stdcall; external SwelioLib name 'CardDecryptFileW';
{$ELSE}
function CardDecryptFile(Source : PChar; Destination : PChar) : BOOL; stdcall; external SwelioLib name 'CardDecryptFileA';
{$ENDIF}

function CardDecryptFileW(Source : PWideChar; Destination : PWideChar) : BOOL; stdcall; external SwelioLib;
function CardDecryptFileA(Source : PAnsiChar; Destination : PAnsiChar) : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure CreateUnicodeFile(const FileName : PChar); stdcall; external SwelioLib name 'CreateUnicodeFileW';
function IsUnicodeFile(const FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsUnicodeFileW';
procedure DeleteToRecycleBin(FileName : PChar; Silent : BOOL); stdcall; external SwelioLib name 'DeleteToRecycleBinW';
procedure ShellCopyFile(oldName : PChar; NewName : PChar); stdcall; external SwelioLib name 'ShellCopyFileW';
function FileGetSize(const FileName : PChar) : DWORD; stdcall; external SwelioLib name 'FileGetSizeW';
function FileExists(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileExistsW';
function FileExtensionIs(const FileName : PChar; Ext : PChar) : BOOL; stdcall; external SwelioLib name 'FileExtensionIsW';
function FileIsImage(const FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileIsImageW';
procedure FileDelete(FileName : PChar); stdcall; external SwelioLib name 'FileDeleteW';
procedure ClearFileAttributes(FileName : PChar); stdcall; external SwelioLib name 'ClearFileAttributesW';
function FileCreateRewrite(const FileName : PChar) : THandle; stdcall; external SwelioLib name 'FileCreateRewriteW';
procedure FileClose(Handle : THandle); stdcall; external SwelioLib name 'FileCloseW';
procedure FileWrite(handle : THandle; Text : PChar); stdcall; external SwelioLib name 'FileWriteW';
procedure FileWriteChar(Handle : THandle; Text : WideChar); stdcall; external SwelioLib name 'FileWriteCharW';
procedure FileWriteNewLine(Handle : THandle); stdcall; external SwelioLib name 'FileWriteNewLineW';
function IsAnimatedGIF(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsAnimatedGIFW';
function FileRename(OldName : PChar; NewName : PChar) : BOOL; stdcall; external SwelioLib name 'FileRenameW';
procedure StripFileName(const FileName : PChar; FullName : PChar); stdcall; external SwelioLib name 'StripFileNameW';
function FileCopy(OldName : PChar; NewName : PChar) : BOOL; stdcall; external SwelioLib name 'FileCopyW';
function FullPath(FileName : PChar; FullName : PChar) : BOOL; stdcall; external SwelioLib name 'FullPathW';
function FileOrFolderExists(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileOrFolderExistsW';
function DirectoryExists(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'DirectoryExistsW';
function IsDirectory(FolderName : PChar) : BOOL; stdcall; external SwelioLib name 'IsDirectoryW';
function FileIsExe(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileIsExeW';
function FileIsIcon(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileIsIconW';
function IsValidFileName(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsValidFileNameW';
function IsValidPathName(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsValidPathNameW';
function GetFilesCount(FolderName : PChar) : integer; stdcall; external SwelioLib name 'GetFilesCountW';
{$ELSE}
procedure CreateUnicodeFile(const FileName : PChar); stdcall; external SwelioLib name 'CreateUnicodeFileA';
function IsUnicodeFile(const FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsUnicodeFileA';
procedure DeleteToRecycleBin(FileName : PChar; Silent : BOOL); stdcall; external SwelioLib name 'DeleteToRecycleBinA';
procedure ShellCopyFile(oldName : PChar; NewName : PChar); stdcall; external SwelioLib name 'ShellCopyFileA';
function FileGetSize(const FileName : PChar) : DWORD; stdcall; external SwelioLib name 'FileGetSizeA';
function FileExists(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileExistsA';
function FileExtensionIs(const FileName : PChar; Ext : PChar) : BOOL; stdcall; external SwelioLib name 'FileExtensionIsA';
function FileIsImage(const FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileIsImageA';
procedure FileDelete(FileName : PChar); stdcall; external SwelioLib name 'FileDeleteA';
procedure ClearFileAttributes(FileName : PChar); stdcall; external SwelioLib name 'ClearFileAttributesA';
function FileCreateRewrite(const FileName : PChar) : THandle; stdcall; external SwelioLib name 'FileCreateRewriteA';
procedure FileClose(Handle : THandle); stdcall; external SwelioLib name 'FileCloseA';
procedure FileWrite(handle : THandle; Text : PChar); stdcall; external SwelioLib name 'FileWriteA';
procedure FileWriteChar(Handle : THandle; Text : WideChar); stdcall; external SwelioLib name 'FileWriteCharA';
procedure FileWriteNewLine(Handle : THandle); stdcall; external SwelioLib name 'FileWriteNewLineA';
function IsAnimatedGIF(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsAnimatedGIFA';
function FileRename(OldName : PChar; NewName : PChar) : BOOL; stdcall; external SwelioLib name 'FileRenameA';
procedure StripFileName(const FileName : PChar; FullName : PChar); stdcall; external SwelioLib name 'StripFileNameA';
function FileCopy(OldName : PChar; NewName : PChar) : BOOL; stdcall; external SwelioLib name 'FileCopyA';
function FullPath(FileName : PChar; FullName : PChar) : BOOL; stdcall; external SwelioLib name 'FullPathA';
function FileOrFolderExists(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileOrFolderExistsA';
function DirectoryExists(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'DirectoryExistsA';
function IsDirectory(FolderName : PChar) : BOOL; stdcall; external SwelioLib name 'IsDirectoryA';
function FileIsExe(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileIsExeA';
function FileIsIcon(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'FileIsIconA';
function IsValidFileName(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsValidFileNameA';
function IsValidPathName(FileName : PChar) : BOOL; stdcall; external SwelioLib name 'IsValidPathNameA';
function GetFilesCount(FolderName : PChar) : integer; stdcall; external SwelioLib name 'GetFilesCountA';
{$ENDIF}

procedure CreateUnicodeFileW(const FileName : PWideChar); stdcall; external SwelioLib;
function IsUnicodeFileW(const FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
procedure DeleteToRecycleBinW(FileName : PWideChar; Silent : BOOL); stdcall; external SwelioLib;
procedure ShellCopyFileW(oldName : PWideChar; NewName : PWideChar); stdcall; external SwelioLib;
function FileGetSizeW(const FileName : PWideChar) : DWORD; stdcall; external SwelioLib;
function FileExistsW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function FileExtensionIsW(const FileName : PWideChar; Ext : PWideChar) : BOOL; stdcall; external SwelioLib;
function FileIsImageW(const FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
procedure FileDeleteW(FileName : PWideChar); stdcall; external SwelioLib;
procedure ClearFileAttributesW(FileName : PWideChar); stdcall; external SwelioLib;
function FileCreateRewriteW(const FileName : PWideChar) : THandle; stdcall; external SwelioLib;
procedure FileCloseW(Handle : THandle); stdcall; external SwelioLib;
procedure FileWriteW(handle : THandle; Text : PWideChar); stdcall; external SwelioLib;
procedure FileWriteCharW(Handle : THandle; Text : WideChar); stdcall; external SwelioLib;
procedure FileWriteNewLineW(Handle : THandle); stdcall; external SwelioLib;
function IsAnimatedGIFW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function FileRenameW(OldName : PWideChar; NewName : PWideChar) : BOOL; stdcall; external SwelioLib;
procedure StripFileNameW(const FileName : PWideChar; FullName : PWideChar); stdcall; external SwelioLib;
function FileCopyW(OldName : PWideChar; NewName : PWideChar) : BOOL; stdcall; external SwelioLib;
function FullPathW(FileName : PWideChar; FullName : PWideChar) : BOOL; stdcall; external SwelioLib;
function FileOrFolderExistsW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function DirectoryExistsW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function IsDirectoryW(FolderName : PWideChar) : BOOL; stdcall; external SwelioLib;
function FileIsExeW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function FileIsIconW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function IsValidFileNameW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function IsValidPathNameW(FileName : PWideChar) : BOOL; stdcall; external SwelioLib;
function GetFilesCountW(FolderName : PWideChar) : integer; stdcall; external SwelioLib;


procedure CreateUnicodeFileA(const FileName : PAnsiChar); stdcall; external SwelioLib;
function IsUnicodeFileA(const FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
procedure DeleteToRecycleBinA(FileName : PAnsiChar; Silent : BOOL); stdcall; external SwelioLib;
procedure ShellCopyFileA(OldName : PAnsiChar; NewName : PAnsiChar); stdcall; external SwelioLib;
function FileGetSizeA(const FileName : PAnsiChar) : DWORD; stdcall; external SwelioLib;
function FileExistsA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FileExtensionIsA(const FileName : PAnsiChar; Ext : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FileIsImageA(const FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
procedure FileDeleteA(FileName : PAnsiChar); stdcall; external SwelioLib;
procedure ClearFileAttributesA(FileName : PAnsiChar); stdcall; external SwelioLib;
function FileCreateRewriteA(const FileName : PAnsiChar) : THandle; stdcall; external SwelioLib;
procedure FileCloseA(Handle : THandle); stdcall; external SwelioLib;
procedure FileWriteA(Handle : THandle; Text : PAnsiChar); stdcall; external SwelioLib;
procedure FileWriteCharA(Handle : THandle; Text : AnsiChar); stdcall; external SwelioLib;
procedure FileWriteNewLineA(Handle : THandle); stdcall; external SwelioLib;
function IsAnimatedGIFA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FileRenameA(OldName : PAnsiChar; NewName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
procedure StripFileNameA(FileName : PAnsiChar; FullName : PAnsiChar); stdcall; external SwelioLib;
function FileCopyA(OldName : PAnsiChar; NewName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FullPathA(FileName : PAnsiChar; FullName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FileOrFolderExistsA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function DirectoryExistsA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function IsDirectoryA(FolderName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FileIsExeA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function FileIsIconA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function IsValidFileNameA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function IsValidPathNameA(FileName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
function GetFilesCountA(FolderName : PAnsiChar) : integer; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure WriteBufferToFile(FileName : PChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib name 'WriteBufferToFileW';
{$ELSE}
procedure WriteBufferToFile(FileName : PChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib name 'WriteBufferToFileA';
{$ENDIF}

procedure WriteBufferToFileW(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib;
procedure WriteBufferToFileA(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure ReadBufferFromFile(FileName : PChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib name 'ReadBufferFromFileW';
{$ELSE}
procedure ReadBufferFromFile(FileName : PChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib name 'ReadBufferFromFileA';
{$ENDIF}

procedure ReadBufferFromFileW(FileName : PWideChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib;
procedure ReadBufferFromFileA(FileName : PAnsiChar; Buffer : PBYTE; BufferSize : integer); stdcall; external SwelioLib;

function AllocateBuffer(BufferSize : integer) : Pointer; stdcall; external SwelioLib;
procedure DeallocateBuffer(Buffer : Pointer); stdcall; external SwelioLib;

{$IFDEF UNICODE}
function GetISOCode(Nationality : PChar; IsoCode : PChar; BufferSize : integer) : BOOL; stdcall; external SwelioLib name 'GetISOCodeW';
{$ELSE}
function GetISOCode(Nationality : PChar; IsoCode : PChar; BufferSize : integer) : BOOL; stdcall; external SwelioLib name 'GetISOCodeA';
{$ENDIF}

function GetISOCodeW(Nationality : PWideChar; IsoCode : PWideChar; BufferSize : integer) : BOOL; stdcall; external SwelioLib;

function GetISOCodeA(Nationality : PAnsiChar; IsoCode : PAnsiChar; BufferSize : integer) : BOOL; stdcall; external SwelioLib;

procedure BringWindowToFront(Window : THandle); stdcall; external SwelioLib;
function  ShutdownWindows(Flags : UINT) : BOOL; stdcall; external SwelioLib;
function  SuspendWindows() : BOOL; stdcall; external SwelioLib;
function  HibernateWindows() : BOOL; stdcall; external SwelioLib;
procedure UpdateWindowPosition(Handle : THandle; X : integer; Y : integer); stdcall; external SwelioLib;
procedure TurnMonitorOn(); stdcall; external SwelioLib;
procedure TurnMonitorOff(); stdcall; external SwelioLib;
procedure ClearUnusedMemory(); stdcall; external SwelioLib;
procedure EmptyRecycleBin(); stdcall; external SwelioLib;
procedure AddRemoveMessageFilter(Message : UINT; dwFlags : DWORD); stdcall; external SwelioLib;
procedure DrawLayeredWindow(WindowHndle : THandle; Left : integer; Top : integer; Width : integer; Height : integer; buffer : HDC; ColorKey : COLORREF; Alpha : byte; redrawOnly : BOOL); stdcall; external SwelioLib;

{$IFDEF UNICODE}
function  AllocateDefaultHWND() : THandle; stdcall; external SwelioLib name 'AllocateDefaultHWNDW';
function  LayeredWndProc(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall; external SwelioLib name 'LayeredWndProcW';
function  GetStartup(const AppName : PChar) : BOOL; stdcall; external SwelioLib name 'GetStartupW';
procedure SetStartup(const AppName : PChar; const AppPath : PChar); stdcall; external SwelioLib name 'SetStartupW';
procedure RemoveStartup(const AppName : PChar); stdcall; external SwelioLib name 'RemoveStartupW';
function  AllocateWindowClass(const ClassName : PChar) : THandle; stdcall; external SwelioLib name 'AllocateWindowClassW';
function  AllocateLayeredWindow(const ClassName : PChar) : THandle; stdcall; external SwelioLib name 'AllocateLayeredWindowW';
procedure MakeSoundFromFile(const SoundName : PChar); stdcall; external SwelioLib name 'MakeSoundFromFileW';
procedure MakeSoundFromResource(ModuleHandle : THandle; const SoundName : PChar); stdcall; external SwelioLib name 'MakeSoundFromResourceW';
function  AllocateHWND(WndFunc : TFNWndProc) : THandle; stdcall; external SwelioLib name 'AllocateHWNDW';
function  DeallocateHWND(Hwnd : THandle) : BOOL; stdcall; external SwelioLib name 'DeallocateHWNDW';
procedure RestoreWindowSubclass(Hwnd : THandle); stdcall; external SwelioLib name 'RestoreWindowSubclassW';
{$ELSE}
function  AllocateDefaultHWND() : THandle; stdcall; external SwelioLib name 'AllocateDefaultHWNDA';
function  LayeredWndProc(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall; external SwelioLib name 'LayeredWndProcA';
function  GetStartup(const AppName : PChar) : BOOL; stdcall; external SwelioLib name 'GetStartupA';
procedure SetStartup(const AppName : PChar; const AppPath : PChar); stdcall; external SwelioLib name 'SetStartupA';
procedure RemoveStartup(const AppName : PChar); stdcall; external SwelioLib name 'RemoveStartupA';
function  AllocateWindowClass(const ClassName : PChar) : THandle; stdcall; external SwelioLib name 'AllocateWindowClassA';
function  AllocateLayeredWindow(const ClassName : PChar) : THandle; stdcall; external SwelioLib name 'AllocateLayeredWindowA';
procedure MakeSoundFromFile(const SoundName : PChar); stdcall; external SwelioLib name 'MakeSoundFromFileA';
procedure MakeSoundFromResource(ModuleHandle : THandle; const SoundName : PChar); stdcall; external SwelioLib name 'MakeSoundFromResourceA';
function  AllocateHWND(WndFunc : TFNWndProc) : THandle; stdcall; external SwelioLib name 'AllocateHWNDA';
function  DeallocateHWND(Hwnd : THandle) : BOOL; stdcall; external SwelioLib name 'DeallocateHWNDA';
procedure RestoreWindowSubclass(Hwnd : THandle); stdcall; external SwelioLib name 'RestoreWindowSubclassA';
{$ENDIF}

function  AllocateDefaultHWNDW() : THandle; stdcall; external SwelioLib;
function  LayeredWndProcW(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall; external SwelioLib;
function  GetStartupW(const AppName : PWideChar) : BOOL; stdcall; external SwelioLib;
procedure SetStartupW(const AppName : PWideChar; const AppPath : PWideChar); stdcall; external SwelioLib;
procedure RemoveStartupW(const AppName : PWideChar); stdcall; external SwelioLib;
function  AllocateWindowClassW(const ClassName : PWideChar) : THandle; stdcall; external SwelioLib;
function  AllocateLayeredWindowW(const ClassName : PWideChar) : THandle; stdcall; external SwelioLib;
procedure MakeSoundFromFileW(const SoundName : PWideChar); stdcall; external SwelioLib;
procedure MakeSoundFromResourceW(ModuleHandle : THandle; const SoundName : PWideChar); stdcall; external SwelioLib;
function  AllocateHWNDW(WndFunc : TFNWndProc) : THandle; stdcall; external SwelioLib;
function  DeallocateHWNDW(Hwnd : THandle) : BOOL; stdcall; external SwelioLib;
procedure RestoreWindowSubclassW(Hwnd : THandle); stdcall; external SwelioLib;

function  AllocateDefaultHWNDA() : THandle; stdcall; external SwelioLib;
function  LayeredWndProcA(hWnd : THandle; Message : UINT; wParam : WPARAM;  lParam : LPARAM) : LRESULT; stdcall; external SwelioLib;
function  GetStartupA(const AppName : PAnsiChar) : BOOL; stdcall; external SwelioLib;
procedure SetStartupA(const AppName : PAnsiChar; const AppPath : PAnsiChar); stdcall; external SwelioLib;
procedure RemoveStartupA(const AppName : PAnsiChar); stdcall; external SwelioLib;
function  AllocateWindowClassA(const ClassName : PAnsiChar) : THandle; stdcall; external SwelioLib;
function  AllocateLayeredWindowA(const ClassName : PAnsiChar) : THandle; stdcall; external SwelioLib;
procedure MakeSoundFromFileA(const SoundName : PAnsiChar); stdcall; external SwelioLib;
procedure MakeSoundFromResourceA(ModuleHandle : THandle; const SoundName : PAnsiChar); stdcall; external SwelioLib;
function  AllocateHWNDA(WndFunc : TFNWndProc) : THandle; stdcall; external SwelioLib;
function  DeallocateHWNDA(Hwnd : THandle) : BOOL; stdcall; external SwelioLib;
procedure RestoreWindowSubclassA(Hwnd : THandle); stdcall; external SwelioLib;

//Checks if PC is Running Windows 8 or better
function IsWindows8() : BOOL; stdcall; external SwelioLib;

//Checks if metro interface is active
function IsMetroActive() : BOOL; stdcall; external SwelioLib;

//Checks if PC is running Windows 7 or better
function IsWindows7() : BOOL; stdcall; external SwelioLib;

//Checks if PC is running Windows Vista or better
function IsWindowsVista() : BOOL; stdcall; external SwelioLib;

//Checks if PC is running Windows XP
function IsWindowsXP() : BOOL; stdcall; external SwelioLib;

//Checks if PC is running Windows XP with Service Pack 2 installed
function IsWindowsXPSP2() : BOOL; stdcall; external SwelioLib;

//Checks if the system is multi touch ready
function IsMultiTouchReady() : BOOL; stdcall; external SwelioLib;

//Checks if the application is running on the Tablet PC
function IsTabletPC() : BOOL; stdcall; external SwelioLib;

//Checks if the Media Center version of Windows is installed
function IsMediaCenter() : BOOL; stdcall; external SwelioLib;

//Checks if PC is connected to Internet
function IsConnectedToInternet() : BOOL; stdcall; external SwelioLib;

function PortAvailable(PortNumber : integer) : BOOL; stdcall; external SwelioLib;

function IsWow64() : BOOL; stdcall; external SwelioLib;

function IsNativeWin64() : BOOL; stdcall; external SwelioLib;

{$IFDEF UNICODE}
procedure CurrentIPAddress(Address : PChar; Len : UINT); stdcall; external SwelioLib name 'CurrentIPAddressW';
{$ELSE}
procedure CurrentIPAddress(Address : PChar; Len : UINT); stdcall; external SwelioLib name 'CurrentIPAddressA';
{$ENDIF}

procedure CurrentIPAddressW(Address : PWideChar; Len : UINT); stdcall; external SwelioLib;
procedure CurrentIPAddressA(Address : PAnsiChar; Len : UINT); stdcall; external SwelioLib;

procedure ShowError(ErrorCode : DWORD); stdcall; external SwelioLib;

function FormatEIDDate(D : String; Separator : string = '/') : String;
begin
  if Length(D) <> 8 then
   Result := ''
     else
       Result := Copy(D, 7, 2) + Separator + Copy(D, 5, 2)+ Separator +
         Copy(D, 1, 4);
end;

function FormatNationalNumber(Number : String) : String;
begin
  Result := Copy (Number, 1,2) + '.' + Copy (Number, 3,2) + '.' + Copy (Number, 5,2) +
            ' ' + Copy (Number, 7,3) + '-' + Copy (Number, 10,2) ;
end;


function FormatCardNumber(Number : String) : String;
begin

  if Length(Number) = 12 then
    Result := Copy(Number, 1, 3) + '-' + Copy(Number, 4, 7) + '-' + Copy(Number, 11, 2)
    else
     if Length(Number) = 10 then
       Result := Copy(Number, 1, 1) + ' ' + Copy(Number, 2, 7) + ' ' + Copy(Number, 9, 2)
         else
           Result := Number;
end;

function DocumentTypeToString(AType : integer) : String;
begin
  case AType of
   1: Result := 'Belgian citizen card';
   2: Result := 'European Community citizen card';
   3: Result := 'Non-European Community citizen card';
   4: Result := 'Kids card';
   6: Result := 'Kids card';
   7: Result := 'Bootstrap card';
   8: Result := 'Habilitation card';
  11: Result := 'Foreigner card type A';
  12: Result := 'Foreigner card type B';
  13: Result := 'Foreigner card type C';
  14: Result := 'Foreigner card type D';
  15: Result := 'Foreigner card type E';
  16: Result := 'Foreigner card type E+';
  17: Result := 'Foreigner card type F+';
  18: Result := 'Foreigner card type F+';
   else
     Result := 'Unknown card';
  end;
end;

end.

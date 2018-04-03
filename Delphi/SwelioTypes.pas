//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

unit SwelioTypes;

interface

uses
  Windows, SysUtils;

type

  TGender = (gtMale, gtFemale);

  TDocumentType = (
   dtUnknown,
   dtBelgianCitizen,
   dtEuropeanCommunity,
   dtNonEuropeanCommunity,
   dtKidsCard,
   dtBootstrapCard,
   dtHabilitationCard,
   dtForeignerCard);

  // Identity information stored on EID card
  TPersonInfo =
    record
      // Electronic ID card number
      CardNumber : string;
      // Electronic ID card physical chip number
      ChipNumber : string;
      // Card validity date begin
      ValidityDateBegin : TDateTime;
      // Card validity date end
      ValidityDateEnd : TDateTime;
      // Card delivery municipality
      Municipality : string;
      // National number
      NationalNumber : string;
      // Surname
      Name : string;
      // First name (2 first given names)
      FirstName1 : string;
      // First name part 2 (first letter of the 3rd given name).
      FirstName2 : string;
      // Nationality
      Nationality : string;
      // Birth location
      BirthLocation : string;
      // Birth date
      BirthDate : TDateTime;
      // Sex
      Sex : TGender;
      // Noble condition
      NobleCondition : string;
      // Document type code (Belgian citizen card, Kids Card, Foreigner card)
      DocumentType : TDocumentType;
      // White cane (blind people)
      WhiteCane : boolean;
      // Yellow cane (partially sighted people)
      YellowCane : boolean;
      // Extended minority
      ExtendedMinority : boolean;
    end;

  // EID address information, stored on the card
   TAddressInfo = record
      // Street name
      Street : string;
      // ZIP code
      Zip : string;
      // Municipality
      Municipality : string;
   end;


implementation

end.

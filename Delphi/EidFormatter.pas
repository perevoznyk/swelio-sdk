//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

unit EidFormatter;

interface

uses
  Windows, SysUtils, SwelioEngine;

type
  TEidFormatter = class
  public
    class function FormatDate(const Value : string) : string;
    class function FormatNationalNumber(const Value : string) : string;
    class function FormatCardNumber(const Value : string) : string;
  end;
implementation

{ TEidFormatter }

class function TEidFormatter.FormatCardNumber(const Value: string): string;
begin
  Result := SwelioEngine.FormatCardNumber(Value);
end;

class function TEidFormatter.FormatDate(const Value: string): string;
begin
  Result := SwelioEngine.FormatEIDDate(Value);
end;

class function TEidFormatter.FormatNationalNumber(const Value: string): string;
begin
  Result := SwelioEngine.FormatNationalNumber(Value);
end;

end.

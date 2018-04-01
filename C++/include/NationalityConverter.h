//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

#ifdef __cplusplus
extern "C" {
#endif

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
BOOL WINAPI GetISOCodeW(LPCWSTR nationality, LPWSTR iso, int bufferSize);

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
BOOL WINAPI GetISOCodeA(LPCSTR nationality, LPSTR iso, int bufferSize);

#ifdef UNICODE
#define GetISOCode GetISOCodeW
#else
#define GetISOCode GetISOCodeA
#endif

#ifdef __cplusplus
}
#endif

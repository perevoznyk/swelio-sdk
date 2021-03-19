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
 //  Generates PNG file with QR Code image
 //  Description
 //  Generates PNG file with encoded text as QR Code image
 //  Parameters
 //  fileName :  The name of the file
 //  text :      The text to encode
 //  margin :    The margin from the border in points
 //  size :      The size of the one point in pixels
 //  level :     The error correction level                
void WINAPI GeneratePNGW(LPWSTR fileName, LPWSTR text, int margin, int size, int level);

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
void WINAPI GeneratePNGA(LPSTR fileName, LPSTR text, int margin, int size, int level);

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
HBITMAP WINAPI GetHBitmapW(LPWSTR text, int margin, int size, int level);

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
HBITMAP WINAPI GetHBitmapA(LPSTR text, int margin, int size, int level);

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
void WINAPI GenerateBMPW(LPWSTR fileName, LPWSTR text, int margin, int size, int level);

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
void WINAPI GenerateBMPA(LPSTR fileName, LPSTR text, int margin, int size, int level);

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
void WINAPI GetPNGW(LPWSTR text, int margin, int size, int level, LPINT bufSize, __deref_opt_out void **ppvBits);

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
void WINAPI GetPNGA(LPSTR text, int margin, int size, int level, LPINT bufSize, __deref_opt_out void **ppvBits);

 //  Summary
 //  Destroys the memory buffer
 //  Description
 //  Destroys the memory buffer created to hold the image returned
 //  by GetPNGA (Ansi) or GetPNGW (Unicode) functions
 //  Parameters
 //  buffer :  The memory buffer                                   
void WINAPI DestroyImageBuffer(void* buffer);

//DOM-IGNORE-BEGIN
#ifdef UNICODE
#define GeneratePNG  GeneratePNGW
#define GetHBitmap  GetHBitmapW
#define GenerateBMP  GenerateBMPW
#define GetPNG  GetPNGW
#else
#define GeneratePNG  GeneratePNGA
#define GetHBitmap  GetHBitmapA
#define GenerateBMP  GenerateBMPA
#define GetPNG  GetPNGA
#endif // !UNICODE
//DOM-IGNORE-END

#ifdef __cplusplus
}
#endif

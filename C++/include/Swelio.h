//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

//05.03.2021 - Applet 1.8 support

#pragma once

#if !defined( _SWELIO_H_ )
#define _SWELIO_H_

#include <windows.h>
#include "CardStructures.h"
#include "CardEvents.h"


#ifdef __cplusplus
extern "C" {
#endif



// Summary: 
//     Set the compatibility mode with the old version of the oficial EID MiddleWare
// Description:
//     The compatibility mode can be useful when the MiddleWare version 1.x or 2.x is installed on the target PC.
//     Usually the more recent MiddleWare is used and this function is provided for backward compatibility only
void WINAPI SetMWCompatibility();

// Summary:
//     Activates the Swelio Engine. 
// Description:
//     This procedure must be called first before any other functions from
//     Swelio library can be used. 
// Return Value:
//     Returns TRUE if the Swelio Engine is successfully started; otherwize returns FALSE 
BOOL WINAPI StartEngine();

// Summary:
//     Deactivates the Swelio Engine
// Description:
//     Deactivates the Swelio Engine and clean up the used memory. Call this procedure at the end of you application 
//     once to finalize the usage of the Swelio Engine.
void WINAPI StopEngine();

// Summary:
//     Checks if the Swelio Engine is activated
// Description:
//     This function checks if the Engine already activated using the StartEngine function.
// Return Value:
//     Returns TRUE if the Swelio Engine is active, otherwise returns FALSE.
BOOL WINAPI IsEngineActive();

// Summary:
//      Get number of card readers connected to PC
// Description:
//      Checks how many smart card readers are connected to PC. If there is no readers connected then
//      the usage of the Swelio Engine is not possible. The engine can control the change of the number of the card
//      readers and can raise an event when the reader is connected or disconnected from PC
// Return Value:
//      The number of the connected smart card readers
int  WINAPI GetReadersCount(VOID);

// Summary:
//      When more than 1 reader connected, select the reader with specified number
// Description:
//      Selects the default card reader using the zero-based reader index. 
//      The first reader has number 0, second - 1, etc...
//      You can read the information only from one selected reader at once.
// Arguments:
//      readerNumber - The reader index, starting from 0
// Return Value:
//      TRUE if the reader is selected, FALSE if the reader with specified number does not exist
BOOL WINAPI SelectReader(int readerNumber);

// Summary:
//      Get the applet version number for card in the reader with specified number
// Description:
//      Get the version number of eid card applet using the zero-based reader index. 
//      The first reader has number 0, second - 1, etc...
//      You can read the information only from one selected reader at once.
// Arguments:
//      readerNumber - The reader index, starting from 0
// Return Value:
//      The card applet version number
int WINAPI GetCardVersion(int readerNumber);

// Summary:
//      Returns the index of the active smart card reader
// Description:
//      The zero-based index of the selected card reader. If there is only one reader is connected
//      to PC then this reader has the index 0 and it's a default (selected) reader.
// Return Value:
//      The index of the selected card reader. The first reader has index 0.
int  WINAPI GetSelectedReaderIndex(void);

// Summary:
//      Select active smart card reader by providing the reader name
// Description:
//      Activates the reader with specified name
// Arguments:
//      readerName - The name of the card reader
// Return Value:
//      Returns TRUE if the reader is selected. If the reader with specified name is not found - returns FALSE
BOOL WINAPI SelectReaderByNameW(LPWSTR readerName);

// Summary:
//      Select active smart card reader by providing the reader name
// Description:
//      Activates the reader with specified name
// Arguments:
//      readerName - The name of the card reader
// Return Value:
//      TRUE if the reader is selected. If the reader with specified name is not found - returns FALSE
BOOL WINAPI SelectReaderByNameA(LPSTR readerName);

// Summary:
//      Returns the length of the reader name 
// Description:
//      Returns the length of the reader name for the smart card reader with specified zero-based index
// Return Value:
//      The length of the reader name
int WINAPI GetReaderNameLenA(int readerNumber);

// Summary:
//      Returns the length of the reader name 
// Description:
//      Returns the length of the reader name for the smart card reader with specified zero-based index
// Return Value:
//      The length of the reader name
int WINAPI GetReaderNameLenW(int readerNumber);

// Summary:
//		Returns the name of the card reader 
// Description:
//      Returns the name of the card reader with the specified zero-based index
// Arguments:
//		readerNumber - The zero-based index of the card reader
//		strDest - Destination string
//		count - The number of characters to be copied
// Return Value:
//      Returns the reader name length
int WINAPI GetReaderNameA(int readerNumber, LPSTR strDest, int count);

// Summary:
//		Returns the name of the card reader 
// Description:
//      Returns the name of the card reader with the specified zero-based index
// Arguments:
//		readerNumber - The zero-based index of the card reader
//		strDest - Destination string
//		count - Number of characters to be copied
// Return Value:
//      The character count of the reader name
int WINAPI GetReaderNameW(int readerNumber, LPWSTR strDest, int count);

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
BOOL WINAPI GetSupportSIS();

// Summary:
// 	   Activates or deactivates SIS card support by engine
// Description:
//     Use SetSupportSIS to activate or deactivate the SIS card detection and reading.
//     Even if SIS card support is activated it can be used only with ACR38U card readers
//     Other card readers are not supported.
// Arguments:
//     value - The SIS card support status
void WINAPI SetSupportSIS(BOOL value);

// Summary:
//     Checks if the card is present in the card reader
// Description:
//     Use IsCardPresent function to check if the card is inserted in the card reader or not
// Return Value:
//     Returns TRUE if the card is inserted in the reader, otherwise returns FALSE
BOOL WINAPI IsCardPresent();

// Summary:
//     Checks if the card is present in the card reader
// Description:
//     Use isCardPresent function to check if the card is inserted in the card reader or not
// Arguments:
//		readerNumber - The zero-based index of the card reader
// Return Value:
//     Returns TRUE if the card is inserted in the reader, otherwise returns FALSE
BOOL WINAPI IsCardPresentEx(int readerNumber);

// Summary:
//    Returns the zero-based reader index with specified name
// Description:
//    Use this function to get the zero-based index of the card reader with specified name
// Arguments:
//    readerName - The name of the reader
// Return Value:
//    The zero-based reader index
int WINAPI GetReaderIndexW(LPWSTR readerName);

// Summary:
//    Returns the zero-based reader index with specified name
// Description:
//    Use this function to get the zero-based index of the card reader with specified name
// Arguments:
//    readerName - The name of the reader
// Return Value:
//    The zero-based reader index
int WINAPI GetReaderIndexA(LPSTR readerName);

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
//   Example:
//   <code lang="c++">
//   if (IsCardPresent())
//   {
//      ActivateCard();
//   }
//   </code>
BOOL WINAPI ActivateCard();

// Summary:
//    Established communication between the card and the reader
// Description:
//   The ActivateCard function establishes a connection between the calling application and a smart card contained 
//   by a specific reader. If no card exists in the specified reader, an error is returned.
// Arguments:
//	 readerNumber - The zero-based index of the card reader
// Return Value:
//   Returns TRUE if the card is activated, otherwise returns FALSE
BOOL WINAPI ActivateCardEx(int readerNumber);

// Summary:
//     Terminates a cennection between a smart card and a reader
// Description:
//     The DeactivateCard function terminates a connection previously opened between the calling application and a smart card in the target reader.
void WINAPI DeactivateCard();

// Summary:
//     Terminates a connection between a smart card and a reader
// Description:
//     The DeactivateCard function terminates a connection previously opened between the calling application and a smart card in the target reader.
// Arguments:
//	 readerNumber - The zero-based index of the card reader
void WINAPI DeactivateCardEx(int readerNumber);

// Summary:
//     Checks the connection between a smart card and a reader
// Description:
//     This function checks the connection between the calling application and a smart card in the target reader.
BOOL WINAPI IsCardActivated();

// Summary:
//     Checks the connection between a smart card and a reader
// Description:
//     This function checks the connection between the calling application and a smart card in the target reader.
// Arguments:
//	 readerNumber - The zero-based index of the card reader
BOOL WINAPI IsCardActivatedEx(int readerNumber);

// Summary:
//     Checks if the card is still inserted in the card reader
// Description:
//     This function checks if the card is still present in the card reader
BOOL WINAPI IsCardStillInserted();

// Summary:
//     Checks if the card is still inserted in the card reader
// Description:
//     This function checks if the card is still present in the card reader
// Arguments:
//	 readerNumber - The zero-based index of the card reader
BOOL WINAPI IsCardStillInsertedEx(int readerNumber);

// Summary:
//      Check if Belgian EID card is inserted into card reader
// Description:
//      If the card is inserted in the reader, this function performs the card
//      type check.
// Return Value:
//      Returns TRUE, if Belgian eID card is inserted in the reader. If there is
//      no card in the reader or the card of other type is inserted, returns FALSE
BOOL WINAPI IsEIDCard();

// Summary:
//      Check if Belgian SIS card is inserted into card reader
// Description:
//      If the card is inserted in the reader, this function performs the card
//      type check.
// Return Value:
//      Returns TRUE, if Belgian SIS card is inserted in the reader. If there is
//      no card in the reader or the card of other type is inserted, returns FALSE
BOOL WINAPI IsSISCard();

// Summary:
//      Check if Belgian EID card is inserted into card reader
// Description:
//      If the card is inserted in the reader, this function performs the card
//      type check.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
// Return Value:
//      Returns TRUE, if Belgian eID card is inserted in the reader. If there is
//      no card in the reader or the card of other type is inserted, returns FALSE
BOOL WINAPI IsEIDCardEx(int readerNumber);

// Summary:
//      Check if Belgian SIS card is inserted into card reader
// Description:
//      If the card is inserted in the reader, this function performs the card
//      type check.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
// Return Value:
//      Returns TRUE, if Belgian SIS card is inserted in the reader. If there is
//      no card in the reader or the card of other type is inserted, returns FALSE
BOOL WINAPI IsSISCardEx(int readerNumber);

// Summary:
//      Save the picture from the card to JPG file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsJpegW(LPWSTR fileName);

// Summary:
//      Save the picture from the card to JPG file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsJpegA(LPSTR fileName);

// Summary:
//      Save the picture from the card to JPG file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsJpegExW(int readerNumber, LPWSTR fileName);

// Summary:
//      Save the picture from the card to JPG file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as JPG image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - the zero-based index of the card reader.  
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsJpegExA(int readerNumber, LPSTR fileName);

// Summary:
//      Save the picture from the card to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsBitmapW(LPWSTR fileName);

// Summary:
//      Save the picture from the card to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsBitmapA(LPSTR fileName);

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
BOOL WINAPI SavePhotoAsBitmapExW(int readerNumber, LPWSTR fileName);

// Summary:
//      Reads the picture from the card and saves it to Windows Bitmap file
// Decription:
//      Reads the photo from the Belgian eID card and writes it to the file as bitmap image.
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      fileName - File name to store the photo
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI SavePhotoAsBitmapExA(int readerNumber, LPSTR fileName);

// Summary:
//      Reads the picture from the card, converts it to bitmap and returns the bitmap handle
// Decription:
//      Reads the photo from the Belgian eID card and returns the bitmap handle
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Return Value:
//      A handle to a bitmap indicates success. NULL indicates failure. 
HBITMAP WINAPI ReadPhotoAsBitmap();

// Summary:
//      Reads the picture from the card, converts it to bitmap and returns the bitmap handle
// Decription:
//      Reads the photo from the Belgian eID card and returns the Windows bitmap handle
//      Reading the photo from the card is a time consuming operation. Do it only when needed.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
// Return Value:
//      A handle to a bitmap indicates success. NULL indicates failure. 
HBITMAP WINAPI ReadPhotoAsBitmapEx(int readerNumber);

// Summary:
//     Reads a photo from a card
// Description:
//     Reads a photo from Belgian eID card to EidPicture structure. This structure holds the raw image bytes and 
//     the length of the image bytes array
// Arguments:
//     photo - The pointer to EidPicture structure
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI ReadPhoto(PeidPicture photo);

// Summary:
//     Reads a photo from a card
// Description:
//     Reads a photo from Belgian eID card to EidPicture structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader.  
//     photo - The pointer to EidPicture structure
// Return Value:
//      Returns TRUE if the photo is retrieved from the card, otherwise return FALSE
BOOL WINAPI ReadPhotoEx(int readerNumber, PeidPicture photo);

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
int  WINAPI EncodePhoto(PeidPicture photo, BYTE* buffer, int bufferSize);

// Summary:
//     Calculates buffer size for Base64 encoded photo
// Description:
//     Use this function to calculate the size of the buffer needed for Base64 encoding of the photo
//     This can be useful for including the photo data to the text document, for example to XML file
// Arguments:
//     photo - The pointer to EidPicture structure
// Return Value:
//     The desired size of the buffer
int  WINAPI GetEncodedPhotoSize(PeidPicture photo);

// Summary:
//     Loads photo from a file
// Description:
//     Loads raw picture data from a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
void WINAPI LoadPhotoW(PeidPicture photo, LPWSTR fileName);

// Summary:
//     Loads photo from a file
// Description:
//     Loads raw picture data from a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
void WINAPI LoadPhotoA(PeidPicture photo, LPSTR fileName);

// Summary:
//     Saves photo to a file
// Description:
//     Saves the raw picture data to a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
void WINAPI SavePhotoW(PeidPicture photo, LPWSTR fileName);

// Summary:
//     Save photo to a file
// Description:
//     Save the raw picture data to a file
// Arguments:
//     photo - The pointer to EidPicture structure
//     fileName - Destination file name
void WINAPI SavePhotoA(PeidPicture photo, LPSTR fileName);

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadIdentityW(PEidIdentityW identity);

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//      address - the pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadAddressW(PEidAddressW address);

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadIdentityA(PEidIdentityA identity);

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//      address - The pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadAddressA(PEidAddressA address);

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      identity - The pointer to the identity information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadIdentityExW(int readerNumber, PEidIdentityW identity);

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      address - The pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadAddressExW(int readerNumber, PEidAddressW address);

// Summary:
//      Read identity information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      identity - The pointer to the identity information structure
// Return value:
//      Returns TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadIdentityExA(int readerNumber, PEidIdentityA identity);

// Summary:
//      Read address information from Belgian eID card
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      address - The pointer to the address information structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadAddressExA(int readerNumber, PEidAddressA address);

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
BOOL WINAPI ReadSISCardW(PSISRecordW identity);

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//      PSISRecordA - The pointer to SISRecordA structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadSISCardA(PSISRecordA identity);

// Summary:
//      Read Belgian SIS card.
// Description:
//      Read the public information from the Belgian SIS card.
//      The SIS card is the social security card of each Belgian resident
//      (Belgian or foreigner)
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      PSISRecordW - The pointer to SISRecordW structure
// Return value:
//      TRUE when information is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadSISCardExW(int readerNumber, PSISRecordW identity);

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
BOOL WINAPI ReadSISCardExA(int readerNumber, PSISRecordA identity);

// Summary:
//     Saves indentity infornation to a file
// Description:
//     Use this function to store the raw identity information from the Belgian
//     eID card to a file. You can use LoadIdentityW to read this information from the file to
//     EidIdentityW structure
// Arguments:
//     fileName - The name of the destination file 
void WINAPI SaveIdentityW(LPWSTR fileName);

// Summary:
//     Reads the raw identity information from a file
// Description:
//     Use this function to read back the identity information stored to the file using SaveIdentityW function
// Arguments:
//     fileName - The name of the source file 
//     identity - The pointer to EidIdentityW structure
void WINAPI LoadIdentityW(LPWSTR fileName, PEidIdentityW identity);

// Summary:
//     Saves indentity infornation to a file
// Description:
//     Use this function to store the raw identity information from the Belgian
//     eID card to a file. You can use LoadIdentityA to read this information from the file to
//     EidIdentityA structure
// Arguments:
//     fileName - The name of the destination file 
void WINAPI SaveIdentityA(LPSTR fileName);

// Summary:
//     Reads the raw identity information from a file
// Description:
//     Use this function to read back the identity information stored to the file using SaveIdentityA function
// Arguments:
//     fileName - The name of the source file 
//     identity - The pointer to EidIdentityA structure
void WINAPI LoadIdentityA(LPSTR fileName, PEidIdentityA identity);

void WINAPI SaveAddressW(LPWSTR fileName);
void WINAPI LoadAddressW(LPWSTR fileName, PEidAddressW address);
void WINAPI SaveAddressA(LPSTR fileName);
void WINAPI LoadAddressA(LPSTR fileName, PEidAddressA address);


// Summary:
//      Save Authentication Certificate to a file
// Description:
//      Read Authentication Certificate from the card and save it to a file.
// Arguments:
//      fileName - File name to store the certificate
void WINAPI SaveAuthenticationCertificateW(LPWSTR fileName);

// Summary:
//     Save Non Repudiation Certificate to a file
// Description:
//     Read Non Repudiation Certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
void WINAPI SaveNonRepudiationCertificateW(LPWSTR fileName);

// Summary:
//     Save Ca Certificate to a file
// Description:
//     Read Ca Certificate from the card and save it to a file
// Arguments:
//    fileName - File name to store the certificate
void WINAPI SaveCaCertificateW(LPWSTR fileName);

// Summary:
//     Save Root Ca Certificate to a file
// Description:
//     Read Root CA certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
void WINAPI SaveRootCaCertificateW(LPWSTR fileName);

// Summary:
//     Save RRN Certificate to a file
// Description:
//     Read RRN certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
void WINAPI SaveRrnCertificateW(LPWSTR fileName);

// Summary:
//      Save Authentication Certificate to a file
// Description:
//      Read Authentication Certificate from the card and save it to a file.
// Arguments:
//      fileName - File name to store the certificate
void WINAPI SaveAuthenticationCertificateA(LPSTR fileName);

// Summary:
//     Save Non Repudiation Certificate to a file
// Description:
//     Read Non Repudiation Certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
void WINAPI SaveNonRepudiationCertificateA(LPSTR fileName);

// Summary:
//     Save Ca Certificate to a file
// Description:
//     Read Ca Certificate from the card and save it to a file
// Arguments:
//    fileName - File name to store the certificate
void WINAPI SaveCaCertificateA(LPSTR fileName);

// Summary:
//     Save Root Ca Certificate to a file
// Description:
//     Read Root CA certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
void WINAPI SaveRootCaCertificateA(LPSTR fileName);

// Summary:
//     Save RRN Certificate to a file
// Description:
//     Read RRN certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
void WINAPI SaveRrnCertificateA(LPSTR fileName);

// Summary:
//     Read Authentication Certificate to memory
// Description:
//     Read Authentication Certificate from the card to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadAuthenticationCertificate(PEidCertificate certificate);

// Summary:
//     Read Non Repudiation Certificate to memory
// Description:
//     Read Non Repudiation Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadNonRepudiationCertificate(PEidCertificate certificate);

// Summary:
//     Read Ca Certificate to memory
// Description:
//     Read Ca Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadCaCertificate(PEidCertificate certificate);

// Summary:
//     Read Root Ca Certificate to memory
// Description:
//     Read Root Ca Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadRootCaCertificate(PEidCertificate certificate);

// Summary:
//     Read Rrn Certificate to memory
// Description:
//     Read Rrn Certificate to EidCertificate structure
// Arguments:
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadRrnCertificate(PEidCertificate certificate);


// Summary:
//     Read Authentication Certificate to memory
// Description:
//     Read Authentication Certificate from the card to EidCertificate structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadAuthenticationCertificateEx(int readerNumber, PEidCertificate certificate);

// Summary:
//     Read Non Repudiation Certificate to memory
// Description:
//     Read Non Repudiation Certificate to EidCertificate structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadNonRepudiationCertificateEx(int readerNumber, PEidCertificate certificate);

// Summary:
//     Read Ca Certificate to memory
// Description:
//     Read Ca Certificate to EidCertificate structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadCaCertificateEx(int readerNumber, PEidCertificate certificate);

// Summary:
//     Read Root Ca Certificate to memory
// Description:
//     Read Root Ca Certificate to EidCertificate structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadRootCaCertificateEx(int readerNumber, PEidCertificate certificate);

// Summary:
//     Read Rrn Certificate to memory
// Description:
//     Read Rrn Certificate to EidCertificate structure
// Arguments:
//	   readerNumber - The zero-based index of the card reader
//     cerificate - The pointer to EidCertificate structure
// Return value:
//      TRUE when certificate is successfully received from the card;
//      otherwise returns FALSE
BOOL WINAPI ReadRrnCertificateEx(int readerNumber, PEidCertificate certificate);

BOOL WINAPI SendAPDU(int readerNumber, LPCBYTE apdu, DWORD apduLen, PCHAR result, LPDWORD len);

// Summary:
//     Performs Base64 encoding of the certificate
// Arguments:
//     certificate - The certificate data
//     buffer - The Base64 encoded certificate buffer
//     bufferSize - The size of the buffer
// Return value:
//     Returns the size of the buffer needed to hold the encoded certificate
int  WINAPI EncodeCertificate(PEidCertificate certificate, BYTE* buffer, int bufferSize);

// Summary:
//     Returns the size of the Base64 encoded certificate
// Description:
//    Use this function to calculate the size of the buffer needed to encode the certificate
// Arguments:
//   certificate - The certificate data
// Return value:
//     Returns the size of the buffer needed to hold the encoded certificate
int  WINAPI GetEncodedCertificateSize(PEidCertificate certificate);

// Summary:
//     Displays the dialog window with certificate information
// Description:
//     Use this function to show the certificate for the user
// Arguments:
//   certificate - The certificate data
void WINAPI DisplayCertificate(PEidCertificate certificate);

// Summary:
//     Reads the certificate from a file
// Description:
//     Use this function to read the certificate from the file
// Arguments:
//     fileName - The source file name
//     certificate - The pointer to EidCertificate structure
void WINAPI LoadCertificateW(LPWSTR fileName, PEidCertificate certificate);

// Summary:
//     Reads the certificate from a file
// Description:
//     Use this function to read the certificate from the file
// Arguments:
//     fileName - The source file name
//     certificate - The pointer to EidCertificate structure
void WINAPI LoadCertificateA(LPSTR fileName, PEidCertificate certificate);

// Summary:
//      Verify PIN code
// Arguments:
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
BOOL WINAPI VerifyPinW(LPWSTR value);

// Summary:
//      Verify PIN code
// Arguments:
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
BOOL WINAPI VerifyPinA(LPSTR value);

// Summary:
//      Verify PIN code
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
BOOL WINAPI VerifyPinExW(int readerNumber, LPWSTR value);

// Summary:
//      Verify PIN code
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      value - PIN code to verify
// Return value:
//      TRUE when the correct PIN code is provided;
//      otherwise returns FALSE
BOOL WINAPI VerifyPinExA(int readerNumber, LPSTR value);

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SavePersonToCsvW(LPWSTR fileName);

// Summary:
//      Read eID card and save the identity information and address to CSV file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SavePersonToCsvA(LPSTR fileName);


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
BOOL WINAPI SavePersonToCsvExW(int readerNumber, LPWSTR fileName);

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
BOOL WINAPI SavePersonToCsvExA(int readerNumber, LPSTR fileName);

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SaveCardToXmlW(LPWSTR fileName);

// Summary:
//      Read eID card and save the information to XML file
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML file.
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SaveCardToXmlA(LPSTR fileName);

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
BOOL WINAPI SaveCardToXmlExW(int readerNumber, LPWSTR fileName);

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
BOOL WINAPI SaveCardToXmlExA(int readerNumber, LPSTR fileName);

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI GenerateQRCodeW(LPWSTR fileName);

// Summary:
//      Read eID card and save the identity information and address to PNG QR Code file
// Description:
//      Use this function to read the information about the owner of the card and
//      generate the QR Code PNG image 
// Arguments:
//      fileName - File name to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI GenerateQRCodeA(LPSTR fileName);

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
BOOL WINAPI GenerateQRCodeExW(int readerNumber, LPWSTR fileName);

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
BOOL WINAPI GenerateQRCodeExA(int readerNumber, LPSTR fileName);

// Summary:
//     Checks if the card owner is female
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is female, otherwise returns FALSE
BOOL WINAPI IsFemaleW(PEidIdentityW identity);

// Summary:
//     Checks if the card owner is female
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is female, otherwise returns FALSE
BOOL WINAPI IsFemaleA(PEidIdentityA identity);

// Summary:
//     Checks if the card owner is male
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is male, otherwise returns FALSE
BOOL WINAPI IsMaleW(PEidIdentityW identity);

// Summary:
//     Checks if the card owner is male
// Description:
//     Use this function to check the gender of the card owner  
// Arguments:
//     identity - The person identity information structure 
// Return Value:
//     Returns TRUE if the card owner is male, otherwise returns FALSE
BOOL WINAPI IsMaleA(PEidIdentityA identity);

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
BOOL WINAPI GenerateAuthenticationSignatureW(LPWSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateNonRepudiationSignatureW(LPWSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateAuthenticationSignatureA(LPSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateNonRepudiationSignatureA(LPSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateAuthenticationSignatureExW(int readerNumber, LPWSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateNonRepudiationSignatureExW(int readerNumber, LPWSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateAuthenticationSignatureExA(int readerNumber, LPSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI GenerateNonRepudiationSignatureExA(int readerNumber, LPSTR pinCode, BYTE* dataHash, int hashSize, BYTE* signature, LPDWORD signatureSize);

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
BOOL WINAPI VerifySignature(PEidCertificate certificate, BYTE* buffer, int bufferSize, BYTE* signature, DWORD signatureSize);

// Summary:
//     Activates callback procedure for card status change event
// Description:
//     Your application can be notified about insertion or removal of the card from the card reader and
//     the changes of the available card readers list (the reader is connected or disconnected from PC)
//     Use this function to install the callback procedure
// Arguments:
//     callback - The pointer to callback procedure
//     userContext - The user defined value passed to the callback procedure
void WINAPI SetCallback(CALLBACK_HANDLER callback, LPVOID userContext);

// Summary:
//     Remove callback procedure for card events
// Description:
//     Use this function to deactivate card events callback procedure
void WINAPI RemoveCallback();

// Summary:
//     Reloads the list of the available card readers
// Description:
//     When the card reader is inserted or removed you may need to reload the list
//     of the available card readers
void WINAPI ReloadReadersList();

// Summary:
//      Save Authentication Certificate to a file
// Description:
//      Read Authentication Certificate from the card and save it to a file.
// Arguments:
//      fileName - File name to store the certificate
//      readerNumber - The reader index, starting from 0
void WINAPI SaveAuthenticationCertificateExW(LPWSTR fileName, int readerNumber);

// Summary:
//     Save Non Repudiation Certificate to a file
// Description:
//     Read Non Repudiation Certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
//     readerNumber - The reader index, starting from 0
void WINAPI SaveNonRepudiationCertificateExW(LPWSTR fileName, int readerNumber);

// Summary:
//     Save Ca Certificate to a file
// Description:
//     Read Ca Certificate from the card and save it to a file
// Arguments:
//    fileName - File name to store the certificate
//    readerNumber - The reader index, starting from 0
void WINAPI SaveCaCertificateExW(LPWSTR fileName, int readerNumber);

// Summary:
//     Save Root Ca Certificate to a file
// Description:
//     Read Root CA certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
//     readerNumber - The reader index, starting from 0
void WINAPI SaveRootCaCertificateExW(LPWSTR fileName, int readerNumber);

// Summary:
//     Save RRN Certificate to a file
// Description:
//     Read RRN certificate from the card and save it to a file
// Arguments:
//     fileName - File name to store the certificate
//     readerNumber - The reader index, starting from 0
void WINAPI SaveRrnCertificateExW(LPWSTR fileName, int readerNumber);

// Summary:
//      Read eID card and save the information to XML buffer
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML buffer in the memory.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      buffer - The memory buffer to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SaveCardToToXMLStreamExW(int readerNumber, void* buffer);

// Summary:
//      Read eID card and save the information to XML buffer
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to XML buffer in the memory.
// Arguments:
//		readerNumber - The zero-based index of the card reader.  
//      buffer - The memory buffer to store information
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SaveCardToToXMLStreamExA(int readerNumber, void* buffer);

// Summary:
//		This function returns the size of the buffer needed to hold the information
//		from the eID card in the XML or CSV format
// Description:
//		Use this function to get the size of the XML buffer before allocating the buffer in memory
// Return Value:
//		The size of the XML or CSV buffer
int WINAPI GetCardBufferSize(void* buffer);

// Summary:
//		Gets XML or CSV information from the  memory buffer
// Description:
//		Use this function to get the card information in CSV or XML format from the memory buffer
// Arguments:
//		buffer: Memory buffer with information
//		strDest: Destination buffer
//		count: Destination buffer size
// Return Value:
//		None
void WINAPI GetCardBufferA(void* buffer, void* strDest, int count);

// Summary:
//		Gets XML or CSV information from the  memory buffer
// Description:
//		Use this function to get the card information in CSV or XML format from the memory buffer
// Arguments:
//		buffer: Memory buffer with information
//		strDest: Destination buffer
//		count: Destination buffer size
// Return Value:
//		None
void WINAPI GetCardBufferW(void* buffer, void* strDest, int count);

// Summary:
//		Deletes XML buffer
// Description:
//		Use this function to delete the buffer
// Arguments:
//		buffer - The memory buffer to store information
void WINAPI DeleteCardBuffer(void* buffer);

// Summary:
//		Creates XML buffer
// Description:
//		Use this function to create XML buffer
// Return value:
//		The memory buffer to store information	
void* WINAPI CreateCardBuffer();

// Summary:
//      Read eID card and save the identity information to CSV memory buffer
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV memory buffer.
// Arguments:
//		readerNumber - the card reader index
//      buffer - Memory buffer
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SavePersonCsvToStreamW(int readerNumber, void* buffer);

// Summary:
//      Read eID card and save the identity information to CSV memory buffer
// Description:
//      Use this function to read the information about the owner of the card and
//      save it to CSV memory buffer.
// Arguments:
//		readerNumber - the card reader index
//      buffer - Memory buffer
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI SavePersonCsvToStreamA(int readerNumber, void* buffer);

// Summary:	
//		Get the serial number of EID card
// Description:
//		Use this function to get the serial number of EID card into the memory buffer
//	Arguments:
//		readerNumber - The zero-based index of the card reader. 
//		serialNumber - The memory buffer for getting the card serial number
//		serialNumberSize - the size of the memory buffer in bytes
// Return Value:
//      Returns TRUE if the information is retrieved from the card, otherwise returns FALSE
BOOL WINAPI GetCardSerialNumber(int readerNumber,  BYTE* serialNumber, LPDWORD serialNumberSize);

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
BOOL WINAPI CardSignCMS(int readerNumber, BYTE *data, UINT dataLen, BYTE *signature, UINT *signatureLen);

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
//      error - error information
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI CardSignCMSEx(int readerNumber, BYTE* data, UINT dataLen, BYTE* signature, UINT* signatureLen, ErrorInformation* Error);

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
BOOL WINAPI CardSignCadesT(int readerNumber, BYTE *data, UINT dataLen, BYTE *signature, UINT *signatureLen);

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
//      error - error information
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI CardSignCadesTEx(int readerNumber, BYTE* data, UINT dataLen, BYTE* signature, UINT* signatureLen, ErrorInformation* error);

// Summary:
//		Sign data with the certificate file according to CMS standard
// Description:
//		Create CMS signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		certificate - The name of the certificate file
//      password - The private key password  
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI CertSignCMS(LPWSTR certificate, LPWSTR password, BYTE *data, UINT dataLen, BYTE *signature, UINT *signatureLen);

// Summary:
//		Sign data with the certificate file according to CMS standard
// Description:
//		Create CMS signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		certificate - The name of the certificate file
//      password - The private key password  
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
//      error - error information
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI CertSignCMSEx(LPWSTR certificate, LPWSTR password, BYTE* data, UINT dataLen, BYTE* signature, UINT* signatureLen, ErrorInformation* error);

// Summary:
//		Sign data with the certificate file according to CADES-T standard
// Description:
//		Create CADES-T signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		certificate - The name of the certificate file
//      password - The private key password  
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI CertSignCadesT(LPWSTR certificate, LPWSTR password, BYTE *data, UINT dataLen, BYTE *signature, UINT *signatureLen);

// Summary:
//		Sign data with the certificate file according to CADES-T standard
// Description:
//		Create CADES-T signature for data buffer. Can be used for digital signature of PDF documents in combination with external PDF library
// Arguments:
//		certificate - The name of the certificate file
//      password - The private key password  
//		data - the data to sign
//		dataLen - the size of the data buffer
//		signature - the signature buffer
//		signatureLen - the size of the signature buffer
//      error - error information
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI CertSignCadesTEx(LPWSTR certificate, LPWSTR password, BYTE* data, UINT dataLen, BYTE* signature, UINT* signatureLen, ErrorInformation* error);

/// <summary>
/// Sign data with the certificate according to CMS standard
/// </summary>
/// <param name="certificate">The byte array with the signing certificate content</param>
/// <param name="certLen">The size of th signing certificate</param>
/// <param name="password">The password of the signing certificate</param>
/// <param name="data">The data to be signed</param>
/// <param name="dataLen">The size of the data to be signed</param>
/// <param name="signature">The value of the signature</param>
/// <param name="signatureLen">The size of the signature</param>
/// <param name="error">The error information</param>
/// <returns>Returns true if the operation is successful, otherwise returns false</returns>
BOOL WINAPI CertSignCMSData(BYTE* certificate, DWORD certLen, LPWSTR password, BYTE* data, UINT dataLen, BYTE* signature, UINT* signatureLen, ErrorInformation* error);

/// <summary>
/// Sign data with the certificate according to CADES-T standard
/// </summary>
/// <param name="certificate">The byte array with the signing certificate content</param>
/// <param name="certLen">The size of th signing certificate</param>
/// <param name="password">The password of the signing certificate</param>
/// <param name="data">The data to be signed</param>
/// <param name="dataLen">The size of the data to be signed</param>
/// <param name="signature">The value of the signature</param>
/// <param name="signatureLen">The size of the signature</param>
/// <param name="error">The error information</param>
/// <returns>Returns true if the operation is successful, otherwise returns false</returns>
BOOL WINAPI CertSignCadesTData(BYTE* certificate, DWORD certLen, LPWSTR password, BYTE* data, UINT dataLen, BYTE* signature, UINT* signatureLen, ErrorInformation* error);

// Summary:
//		Initializes ASIC container
// Description:
//		This functions initializes container handle needed for all container operations.
//		Must be called first prior to other container-related calls
// Arguments:
//		Returns container handle which is used for all operations with the container
// Return value:
//		Retrns container handle pointer
LPVOID WINAPI InitializeContainer();

// Summary:
//		Deallocates ASIC container 
// Description:
//		Call this function to deallocate container memory and release container handle. 
// Arguments:
//		container: Container handle, which is allocated by calling InitializeContainer function
// Return value:
//		None
void WINAPI FreeContainer(LPVOID container);

// Summary:
//		Save container to the file
// Description:
//		After adding all necessary files to the container call this function to save 
//		container to the file
// Arguments:
//		container: Container handle, which is allocated by calling InitializeContainer function
//		fileName: Desired name of the container file 
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI SaveContainer(LPVOID container, LPWSTR fileName);

// Summary:
//		Add existing file to the container
// Description:
//		Call this function to include the file to the container. The file must exist.
// Arguments:
//		container: Container handle, which is allocated by calling InitializeContainer function
//		fileName: The name of the file which will be added to the container 
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI AddFileToContainer(LPVOID container, LPSTR fileName);

// Summary:
//		Assign certificate for signing ASIC container
// Description:
//		Use this function to assign certificate which will be used to sign container at 
//		the moment when container will be saved to the file
// Arguments:
//		container: Container handle, which is allocated by calling InitializeContainer function
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI ContainerCertificate(LPVOID container, LPWSTR fileName, LPWSTR password);

// Summary:
//		Pick certificate to sign ASIC container
// Description:
//		Use this function to let user pick the certificate to sign ASIC contaner
//		The dialog to choose the certificate will be shown to the user
// Arguments:
//		container: Container handle, which is allocated by calling InitializeContainer function
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI ContainerPickCertificate(LPVOID container);

// Summary:
//		Select EID card certificate to sign ASIC container
// Description:
//		Call this function to select EID certificate to sign ASIC container
// Arguments:
//		container: Container handle, which is allocated by calling InitializeContainer function
// Return value:
//		Returns true if the operation is successful, otherwise returns false
BOOL WINAPI ContainerEidCertificate(LPVOID container, int readerNumber);

/// <summary>
/// Ignore smartcard service stop events when reporting readers list change
/// </summary>
/// <param name="value">To ignore or not the service event</param>
/// <returns>None</returns>
void WINAPI IgnoreServiceEvents(BOOL value);

/// <summary>
/// Ignore USB reader insert / remove events
/// </summary>
/// <param name="value">true - to ignore reader remove / insert events</param>
/// <returns>None</returns>
void WINAPI IgnoreHardwareEvents(BOOL value);

//DOM-IGNORE-BEGIN
#ifdef UNICODE
#define SelectReaderByName SelectReaderByNameW
#define GetReaderNameLen GetReaderNameLenW
#define GetReaderName GetReaderNameW
#define GetReaderIndex GetReaderIndexW
#define SavePhotoAsJpeg SavePhotoAsJpegW
#define SavePhotoAsJpegEx SavePhotoAsJpegExW
#define ReadIdentity ReadIdentityW
#define ReadAddress ReadAddressW
#define ReadIdentityEx ReadIdentityExW
#define ReadAddressEx ReadAddressExW
#define ReadSISCard ReadSISCardW
#define ReadSISCardEx ReadSISCardExW
#define SaveIdentity SaveIdentityW
#define LoadIdentity LoadIdentityW
#define SaveAuthenticationCertificate SaveAuthenticationCertificateW
#define SaveNonRepudiationCertificate SaveNonRepudiationCertificateW
#define SaveCaCertificate SaveCaCertificateW
#define SaveRootCaCertificate SaveRootCaCertificateW
#define SaveRrnCertificate SaveRrnCertificateW
#define VerifyPin VerifyPinW
#define SavePersonToCsv SavePersonToCsvW
#define LoadPhoto LoadPhotoW
#define SavePhoto SavePhotoW
#define SaveCardToXml SaveCardToXmlW
#define IsFemale IsFemaleW
#define LoadCertificate LoadCertificateW
#define IsMale IsMaleW
#define GenerateQRCode GenerateQRCodeW
#define SavePhotoAsBitmap SavePhotoAsBitmapW
#define SavePhotoAsBitmapEx SavePhotoAsBitmapExW
#define GenerateAuthenticationSignature GenerateAuthenticationSignatureW
#define GenerateNonRepudiationSignature GenerateNonRepudiationSignatureW
#define GenerateQRCodeEx GenerateQRCodeExW
#define SavePersonToCsvEx SavePersonToCsvExW
#define SaveCardToXmlEx SaveCardToXmlExW
#define VerifyPinEx VerifyPinExW
#define SaveCardToToXMLStreamEx SaveCardToToXMLStreamExW
#define SavePersonCsvToStream SavePersonCsvToStreamW
#else
#define SelectReaderByName SelectReaderByNameA
#define GetReaderNameLen GetReaderNameLenA
#define GetReaderName GetReaderNameA
#define GetReaderIndex GetReaderIndexA
#define SavePhotoAsJpeg SavePhotoAsJpegA
#define SavePhotoAsJpegEx SavePhotoAsJpegExA
#define ReadIdentity ReadIdentityA
#define ReadAddress ReadAddressA
#define ReadIdentityEx ReadIdentityExA
#define ReadAddressEx ReadAddressExA
#define ReadSISCard ReadSISCardA
#define ReadSISCardEx ReadSISCardExA
#define SaveIdentity SaveIdentityA
#define LoadIdentity LoadIdentityA
#define SaveAuthenticationCertificate SaveAuthenticationCertificateA
#define SaveNonRepudiationCertificate SaveNonRepudiationCertificateA
#define SaveCaCertificate SaveCaCertificateA
#define SaveRootCaCertificate SaveRootCaCertificateA
#define SaveRrnCertificate SaveRrnCertificateA
#define VerifyPin VerifyPinA
#define SavePersonToCsv SavePersonToCsvA
#define LoadPhoto LoadPhotoA
#define SavePhoto SavePhotoA
#define SaveCardToXml SaveCardToXmlA
#define IsFemale IsFemaleA
#define LoadCertificate LoadCertificateA
#define IsMale IsMaleA
#define GenerateQRCode GenerateQRCodeA
#define SavePhotoAsBitmap SavePhotoAsBitmapA
#define SavePhotoAsBitmapEx SavePhotoAsBitmapExA
#define GenerateAuthenticationSignature GenerateAuthenticationSignatureA
#define GenerateNonRepudiationSignature GenerateNonRepudiationSignatureA
#define GenerateQRCodeEx GenerateQRCodeExA
#define SavePersonToCsvEx SavePersonToCsvExA
#define SaveCardToXmlEx SaveCardToXmlExA
#define VerifyPinEx VerifyPinExA
#define SaveCardToToXMLStreamEx SaveCardToToXMLStreamExA
#define SavePersonCsvToStream SavePersonCsvToStreamA
#endif
//DOM-IGNORE-END

#ifdef __cplusplus
}
#endif

#endif     // __SWELIO_H__



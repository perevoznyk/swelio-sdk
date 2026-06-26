//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

#include <Windows.h>

#if !defined( _NETWORK_H_ )
#define _NETWORK_H_

#ifdef __cplusplus
extern "C" {
#endif

	// Summary:
	//     Checks if the server is accessible
	// Description:
	//     This function checks if the server is accessible. It can be used to check if the server 
	//     is reachable before trying to download the certificate revocation list (CRL) or other 
	//     resources from the server.
	// Arguments:
	//     name - The server name or URL to check
	// Return Value:
	//     Returns TRUE if the server is accessible, otherwise returns FALSE.
	BOOL WINAPI ServerAccessible(LPWSTR name);

#ifdef __cplusplus
}
#endif

#endif     // __NETWORK_H__



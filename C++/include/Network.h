//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

#include <windows.h>

#if !defined( _NETWORK_H_ )
#define _NETWORK_H_

#ifdef __cplusplus
extern "C" {
#endif
	BOOL WINAPI ServerAccessible(LPWSTR name);
#ifdef __cplusplus
}
#endif

#endif     // __NETWORK_H__



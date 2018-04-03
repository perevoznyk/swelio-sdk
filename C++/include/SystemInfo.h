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

//Checks if PC is running Windows 10 or better
BOOL WINAPI IsWindows10();

//Checks if PC is Running Windows 8 or better
BOOL WINAPI IsWindows8();

//Checks if metro interface is active
BOOL WINAPI IsMetroActive();

//Checks if PC is running Windows 7 or better
BOOL WINAPI IsWindows7();

//Checks if PC is running Windows Vista or better
BOOL WINAPI IsWindowsVista();

//Checks if PC is running Windows XP
BOOL WINAPI IsWindowsXP();

//Checks if PC is running Windows XP with Service Pack 2 installed
BOOL WINAPI IsWindowsXPSP2(); 

//Checks if the system is multi touch ready
BOOL WINAPI IsMultiTouchReady();

//Checks if the application is running on the Tablet PC
BOOL WINAPI IsTabletPC();

//Checks if the Media Center version of Windows is installed
BOOL WINAPI IsMediaCenter();

//Checks if PC is connected to Internet
BOOL WINAPI IsConnectedToInternet();

//Checks if the port with specified number is available
BOOL WINAPI PortAvailable(int port);

//Checks if the 32 bit application runs on 64 bit Windows
BOOL WINAPI IsWow64();

//Checks if the application is native 64 bit executable
BOOL WINAPI IsNativeWin64();

//Checks if application is running in RDP session
BOOL WINAPI IsRemoteSession();

//Checks if application is running in Citrix session
BOOL WINAPI IsCitrixSession();

//Returns the IP address
void WINAPI CurrentIPAddressW(LPWSTR address, UINT len);

//Returns the IP address
void WINAPI CurrentIPAddressA(LPSTR address, UINT len);

//Returns TRUE if Windows Recyce Bin is empty
BOOL WINAPI RecycleBinEmpty();

#ifdef UNICODE
#define CurrentIPAddress CurrentIPAddressW
#else
#define CurrentIPAddress CurrentIPAddressA
#endif

#ifdef __cplusplus
}
#endif

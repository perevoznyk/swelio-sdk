//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once
#include <Windows.h>

#ifdef __cplusplus
extern "C" {
#endif

	//Summary:
	//     Checks if PC is running Windows 11 or better
	//Description:
	//     This function checks if the PC is running Windows 11 or better. It can be used to check 
	//     if the application can use the new features of Windows 11.
	//Return Value:
	//     Returns TRUE if the PC is running Windows 11 or better, otherwise returns FALSE.
	BOOL WINAPI IsWindows11();

	//Summary:
	//     Checks if PC is running Windows 10 or better
	//Description:
	//     This function checks if the PC is running Windows 10 or better.
	//Return Value:
	//     Returns TRUE if the PC is running Windows 10 or better, otherwise returns FALSE.
	BOOL WINAPI IsWindows10();

	//Summary:
	//     Checks if PC is Running Windows 8 or better
	//Description:
	//     This function checks if the PC is running Windows 8 or better.
	//Return Value:
	//     Returns TRUE if the PC is running Windows 8 or better, otherwise returns FALSE.
	BOOL WINAPI IsWindows8();

	//Summary:
	//     Checks if metro interface is active
	//Description:
	//     This function checks if the metro interface is active.
	//Return Value:
	//     Returns TRUE if the metro interface is active, otherwise returns FALSE.
	BOOL WINAPI IsMetroActive();

	//Summary:
	//     Checks if PC is running Windows 7 or better
	//Description:
	//     This function checks if the PC is running Windows 7 or better.
	//Return Value:
	//     Returns TRUE if the PC is running Windows 7 or better, otherwise returns FALSE.
	BOOL WINAPI IsWindows7();

	//Summary:
	//     Checks if PC is running Windows Vista or better
	//Description:
	//     This function checks if the PC is running Windows Vista or better.
	//Return Value:
	//     Returns TRUE if the PC is running Windows Vista or better, otherwise returns FALSE.
	BOOL WINAPI IsWindowsVista();

	//Summary:
	//     Checks if PC is running Windows XP
	//Description:
	//     This function checks if the PC is running Windows XP.
	//Return Value:
	//     Returns TRUE if the PC is running Windows XP, otherwise returns FALSE.
	BOOL WINAPI IsWindowsXP();

	//Summary:
	//     Checks if PC is running Windows XP with Service Pack 2 installed
	//Description:
	//     This function checks if the PC is running Windows XP with Service Pack 2 installed.
	//Return Value:
	//     Returns TRUE if the PC is running Windows XP with Service Pack 2 installed, otherwise returns FALSE.
	BOOL WINAPI IsWindowsXPSP2();

	//Summary:
	//     Checks if the system is multi touch ready
	//Description:
	//     This function checks if the system is multi touch ready.
	//Return Value:
	//     Returns TRUE if the system is multi touch ready, otherwise returns FALSE.
	BOOL WINAPI IsMultiTouchReady();

	//Summary:
	//     Checks if the application is running on the Tablet PC
	//Description:
	//     This function checks if the application is running on the Tablet PC.
	//Return Value:
	//     Returns TRUE if the application is running on the Tablet PC, otherwise returns FALSE.
	BOOL WINAPI IsTabletPC();

	//Summary:
	//     Checks if the Media Center version of Windows is installed
	//Description:
	//     This function checks if the Media Center version of Windows is installed.
	//Return Value:
	//     Returns TRUE if the Media Center version of Windows is installed, otherwise returns FALSE.
	BOOL WINAPI IsMediaCenter();

	//Summary:
	//     Checks if PC is connected to Internet
	//Description:
	//     This function checks if the PC is connected to the Internet.
	//Return Value:
	//     Returns TRUE if the PC is connected to the Internet, otherwise returns FALSE.
	BOOL WINAPI IsConnectedToInternet();

	//Summary:
	//     Checks if the port with specified number is available
	//Description:
	//     This function checks if the port with the specified number is available.
	//Return Value:
	//     Returns TRUE if the port is available, otherwise returns FALSE.
	BOOL WINAPI PortAvailable(int port);

	//Summary:
	//     Checks if the 32 bit application runs on 64 bit Windows
	//Description:
	//     This function checks if the 32 bit application is running on 64 bit Windows.
	//Return Value:
	//     Returns TRUE if the 32 bit application is running on 64 bit Windows, otherwise returns FALSE.
	BOOL WINAPI IsWow64();

	//Summary:
	//     Checks if the application is native 64 bit executable
	//Description:
	//     This function checks if the application is a native 64 bit executable.
	//Return Value:
	//     Returns TRUE if the application is a native 64 bit executable, otherwise returns FALSE.
	BOOL WINAPI IsNativeWin64();

	//Summary:
	//     Checks if application is running in RDP session
	//Description:
	//     This function checks if the application is running in an RDP session.
	//Return Value:
	//     Returns TRUE if the application is running in an RDP session, otherwise returns FALSE.
	BOOL WINAPI IsRemoteSession();

	//Summary:
	//     Checks if application is running in Citrix session
	//Description:
	//     This function checks if the application is running in a Citrix session.
	//Return Value:
	//     Returns TRUE if the application is running in a Citrix session, otherwise returns FALSE.
	BOOL WINAPI IsCitrixSession();

	//Summary:
	//     Returns the IP address
	//Description:
	//     This function returns the IP address of the current system.
	//Return Value:
	//     None.
	void WINAPI CurrentIPAddressW(LPWSTR address, UINT len);

	//Summary:
	//     Returns the IP address
	//Description:
	//     This function returns the IP address of the current system.
	//Return Value:
	//     None.
	void WINAPI CurrentIPAddressA(LPSTR address, UINT len);

	//Summary:
	//     Checks if Windows Recycle Bin is empty
	//Description:
	//     This function checks if the Windows Recycle Bin is empty.
	//Return Value:
	//     Returns TRUE if the Recycle Bin is empty, otherwise returns FALSE.
	BOOL WINAPI RecycleBinEmpty();

	//DOM-IGNORE-BEGIN
#ifdef UNICODE
#define CurrentIPAddress CurrentIPAddressW
#else
#define CurrentIPAddress CurrentIPAddressA
#endif
//DOM-IGNORE-END
#ifdef __cplusplus
}
#endif

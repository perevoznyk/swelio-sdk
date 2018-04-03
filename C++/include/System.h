//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

#include <windows.h>

#ifdef __cplusplus
extern "C" {
#endif

 //  Summary
 //  This function brings the specified window to the top of the
 //  z-order.
 //  Parameters
 //  window :  Handle to the window to bring to the top of the
 //            z\-order.                                         
void WINAPI BringWindowToFront(HWND window);

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
BOOL WINAPI ShutdownWindows(UINT flags);

 //  Summary
 //  Suspends Windows 
BOOL WINAPI SuspendWindows();

 //  Summary
 //  Hibernates Windows 
BOOL WINAPI HibernateWindows();

 //  Summary
 //  Updated the window position
 //  Parameters
 //  handle :  The handle of the window
 //  x :       New horizontal coordinate
 //  y :       New vertical coordinate   
void WINAPI UpdateWindowPosition(HWND handle, int x, int y);

 //  Summary
 //  Turns the monitor on 
void WINAPI TurnMonitorOn();

 //  Summary
 //  Turns the monitor off 
void WINAPI TurnMonitorOff();

 //  Summary
 //  Clears unused memory and minimized the application memory
 //  usage                                                     
void WINAPI ClearUnusedMemory();

 //  Summary
 //  Empties the recycle bin
 //  Description
 //  Removes all files from the Windows recycle bin 
void WINAPI EmptyRecycleBin();

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
void WINAPI AddRemoveMessageFilter(UINT message, DWORD dwFlags);

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
void WINAPI DrawLayeredWindow(HWND handle, int left, int top, int width, int height, HDC buffer, COLORREF colorKey, byte alpha, BOOL redrawOnly);

 //  Summary
 //  This function creates the invisible tool window
 //  Description
 //  This function creates the invisible zero-size tool window
 //  that can be used for internal purposes, like processing the
 //  special Windows messages for synchronization, etc...
 //  Return Value
 //  If the function succeeds, the return value is a handle to the
 //  new window. If the function fails, the return value is NULL.  
HWND WINAPI AllocateDefaultHWNDW();

 //  Summary
 //  The default window procedure for the layered window 
LRESULT CALLBACK LayeredWndProcW(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

 //  Summary
 //  Checks if the application is registered to run when Windows
 //  starts
 //  Parameters
 //  appName :  The name of the application                      
BOOL WINAPI GetStartupW(LPCWSTR appName);

 //  Summary
 //  Register application to run when Windows starts
 //  Parameters
 //  appName :  The name of the application
 //  appPath :  The path to the application executable 
void WINAPI SetStartupW(LPCWSTR appName, LPCWSTR appPath);

 //  Summary
 //  Removes the application from the list of the automatically
 //  started applications
 //  Description
 //  For application that starts automatically when Windows starts
 //  removes it from the automatically launching applications list
 //  Parameters
 //  appName :  The name of the application                        
void WINAPI RemoveStartupW(LPCWSTR appName);

 //  Summary
 //  This function creates the standard window using the provided
 //  window class name
 //  Description
 //  This function creates the standard window using the provided
 //  window class name
 //  Return Value
 //  If the function succeeds, the return value is a handle to the
 //  new window. If the function fails, the return value is NULL.  
HWND WINAPI AllocateWindowClassW(LPCWSTR className);

 //  Summary
 //  This function creates the layered window using the provided
 //  window class name
 //  Description
 //  This function creates the layered window using the provided
 //  window class name
 //  Return Value
 //  If the function succeeds, the return value is a handle to the
 //  new window. If the function fails, the return value is NULL.  
HWND WINAPI AllocateLayeredWindowW(LPCWSTR className);

 //  Summary
 //  Plays the wave sound from the file
 //  Description
 //  This function plays a sound specified by the given file name.
 //  Parameters
 //  soundName :  The name of the file                             
void WINAPI MakeSoundFromFileW(LPCWSTR soundName);

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
void WINAPI MakeSoundFromResourceW(HMODULE hModule, LPCWSTR soundName);

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
HWND WINAPI AllocateHWNDW(LONG_PTR method);

 //  Summary
 //  This function destroys the specified window.
 //  Description
 //  This function restores the window default procedure and
 //  destroys the window
 //  Parameters
 //  hwnd :  Handle to the window to be destroyed            
BOOL WINAPI DeallocateHWNDW(HWND hwnd);

 //  Summary
 //  Restores window standard procedure
 //  Parameters
 //  hwnd :  The window handle          
void WINAPI RestoreWindowSubclassW(HWND hwnd);

 //  Summary
 //  This function creates the invisible tool window
 //  Description
 //  This function creates the invisible zero-size tool window
 //  that can be used for internal purposes, like processing the
 //  special Windows messages for synchronization, etc...
 //  Return Value
 //  If the function succeeds, the return value is a handle to the
 //  new window. If the function fails, the return value is NULL.  
HWND WINAPI AllocateDefaultHWNDA();

 //  Summary
 //  The default window procedure for the layered window 
LRESULT CALLBACK LayeredWndProcA(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

 //  Summary
 //  Checks if the application is registered to run when Windows
 //  starts
 //  Parameters
 //  appName :  The name of the application                      
BOOL WINAPI GetStartupA(LPCSTR appName);

 //  Summary
 //  Register application to run when Windows starts
 //  Parameters
 //  appName :  The name of the application
 //  appPath :  The path to the application executable 
void WINAPI SetStartupA(LPCSTR appName, LPCWSTR appPath);

 //  Summary
 //  Removes the application from the list of the automatically
 //  started applications
 //  Description
 //  For application that starts automatically when Windows starts
 //  removes it from the automatically launching applications list
 //  Parameters
 //  appName :  The name of the application                        
void WINAPI RemoveStartupA(LPCSTR appName);

 //  Summary
 //  This function creates the standard window using the provided
 //  window class name
 //  Description
 //  This function creates the standard window using the provided
 //  window class name
 //  Return Value
 //  If the function succeeds, the return value is a handle to the
 //  new window. If the function fails, the return value is NULL.  
HWND WINAPI AllocateWindowClassA(LPCSTR className);

 //  Summary
 //  This function creates the layered window using the provided
 //  window class name
 //  Description
 //  This function creates the layered window using the provided
 //  window class name
 //  Return Value
 //  If the function succeeds, the return value is a handle to the
 //  new window. If the function fails, the return value is NULL.  
HWND WINAPI AllocateLayeredWindowA(LPCSTR className);

 //  Summary
 //  Plays the wave sound from the file
 //  Description
 //  This function plays a sound specified by the given file name.
 //  Parameters
 //  soundName :  The name of the file                             
void WINAPI MakeSoundFromFileA(LPCSTR soundName);

 //  Summary
 //  Plays the wave sound from the resource
 //  Parameters
 //  hModule :    Handle to the executable file that contains the
 //               resource to be loaded.
 //  soundName :  A string that specifies the sound to play.
 //  Description
 //  This function plays a sound specified by the given resource
 //  name.                                                        
void WINAPI MakeSoundFromResourceA(HMODULE hModule, LPCSTR soundName);

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
HWND WINAPI AllocateHWNDA(LONG_PTR method);

 //  Summary
 //  This function destroys the specified window.
 //  Description
 //  This function restores the window default procedure and
 //  destroys the window
 //  Parameters
 //  hwnd :  Handle to the window to be destroyed            
BOOL WINAPI DeallocateHWNDA(HWND hwnd);

 //  Summary
 //  Restores window standard procedure
 //  Parameters
 //  hwnd :  The window handle          
void WINAPI RestoreWindowSubclassA(HWND hwnd);

#ifdef UNICODE
#define GetStartup GetStartupW
#define SetStartup SetStartupW
#define AllocateDefaultHWND AllocateDefaultHWNDW
#define LayeredWndProc LayeredWndProcW
#define RemoveStartup RemoveStartupW
#define AllocateWindowClass AllocateWindowClassW
#define AllocateLayeredWindow AllocateLayeredWindowW
#define MakeSoundFromFile MakeSoundFromFileW
#define MakeSoundFromResource MakeSoundFromResourceW
#define AllocateHWND AllocateHWNDW
#define DeallocateHWND DeallocateHWNDW
#define RestoreWindowSubclass RestoreWindowSubclassW
#else
#define GetStartup GetStartupA
#define SetStartup SetStartupA
#define RemoveStartup RemoveStartupA
#define AllocateWindowClass AllocateWindowClassA
#define AllocateLayeredWindow AllocateLayeredWindowA
#define MakeSoundFromFile MakeSoundFromFileA
#define MakeSoundFromResource MakeSoundFromResourceA
#define AllocateDefaultHWND AllocateDefaultHWNDA
#define LayeredWndProc LayeredWndProcA
#define AllocateHWND AllocateHWNDA
#define DeallocateHWND DeallocateHWNDA
#define RestoreWindowSubclass RestoreWindowSubclassA
#endif

#ifdef __cplusplus
}
#endif


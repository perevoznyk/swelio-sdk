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

#define WIDTHBYTES(i) (((i) + 31) / 32 * 4)

#define FONT_NORMAL		0x00
#define FONT_BOLD		0x01
#define FONT_ITALIC		0x02
#define FONT_UNDERLINE	0x04
#define FONT_STRIKEOUT	0x08

	//Summary:
	//     Calculates the size of the text in pixels
	//Parameters:
	//     s - The text string to be measured
	//     hFont - The font to use for measurement
	//     flags - Additional flags for measurement
	//Returns:
	//     A SIZE structure containing the width and height of the text in pixels
	SIZE WINAPI GetTextSize(LPCWSTR s, HFONT hFont, UINT flags);

	//Summary:
	//     Draws text directly onto a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     color - The color of the text
	//     left - The left coordinate of the text position
	//     top - The top coordinate of the text position
	//Returns:
	//     None
	void WINAPI DrawTextDirect(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, int left, int top);

	//Summary:
	//     Draws text with alpha blending onto a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     color - The color of the text
	//     width - The width of the text area
	//     height - The height of the text area
	//     flags - Additional flags for drawing
	//Returns:
	//     None
	void WINAPI DrawAlphaText(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, int width, int height, UINT flags);

	//Summary:
	//     Draws text with alpha blending within a specified rectangle on a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     color - The color of the text
	//     lpRect - A pointer to the rectangle that defines the text area
	//     flags - Additional flags for drawing
	//Returns:
	//     None
	void WINAPI DrawAlphaTextRect(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, LPRECT lpRect, UINT flags);

	//Summary:
	//     Creates a Windows font with specified properties
	//Parameters:
	//     fontFamily - The name of the font family
	//     size - The size of the font in points
	//     fontStyle - The style of the font (e.g., bold, italic)
	//     fontQuality - The quality of the font rendering
	//Returns:
	//     A handle to the created font (HFONT)
	HFONT WINAPI CreateWindowsFont(LPCWSTR fontFamily, INT size, INT fontStyle, INT fontQuality);

	//Summary:
	//     Calculates the size of a single line of text in pixels
	//Parameters:
	//     s - The text string to be measured
	//     hFont - The font to use for measurement
	//Returns:
	//     A SIZE structure containing the width and height of the text line in pixels
	SIZE WINAPI GetTextLineSize(LPCWSTR s, HFONT hFont);

	//Summary:
	//     Draws a single line of text onto a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     color - The color of the text
	//     left - The left coordinate of the text position
	//     top - The top coordinate of the text position
	//Returns:
	//     None
	void WINAPI DrawTextLine(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, int left, int top);

	//Summary:
	//     Clones an existing font
	//Parameters:
	//     hFont - Handle to the font to be cloned
	//Returns:
	//	 A handle to the cloned font (HFONT)
	HFONT WINAPI CloneFont(HFONT hFont);

	//Summary:
	//     Draws text with an outline effect onto a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     foreColor - The color of the text outline
	//     backColor - The background color
	//     left - The left coordinate of the text position
	//     top - The top coordinate of the text position
	//Returns:
	//     None
	void WINAPI DrawTextOutline(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF foreColor, COLORREF backColor, int left, int top);

	//Summary:
	//     Draws text with a glowing effect onto a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     foreColor - The color of the glowing text
	//     left - The left coordinate of the text position
	//     top - The top coordinate of the text position
	//Returns:
	//     None
	void WINAPI DrawTextGlow(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF foreColor, int left, int top);

	//Summary:
	//     Draws text within a specified rectangle on a device context
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     color - The color of the text
	//     background - The background color
	//     lpRect - A pointer to the rectangle that defines the text area
	//     flags - Additional flags for drawing
	//Returns:
	//     None
	void WINAPI DrawTextRect(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, COLORREF background, LPRECT lpRect, UINT flags);

	//Summary:
	//     Destroys a font and releases its resources
	//Parameters:
	//     hFont - Handle to the font to be destroyed
	//Returns:
	//     None
	void WINAPI DestroyFont(HFONT hFont);

	//Summary:
	//     Creates a bitmap compatible with the specified source bitmap
	//Parameters:
	//     source - Handle to the source bitmap
	//     width - The width of the new bitmap
	//     height - The height of the new bitmap
	//Returns:
	//     A handle to the created compatible bitmap (HBITMAP)
	HBITMAP WINAPI MakeCompatibleBitmap(HBITMAP source, int width, int height);

	//Summary:
	//     Draws a native bitmap onto another bitmap
	//Parameters:
	//     src - Handle to the source bitmap
	//     dst - Handle to the destination bitmap
	//     width - The width of the area to draw
	//     height - The height of the area to draw
	//Returns:
	//     None
	void WINAPI DrawNativeBitmap(HBITMAP src, HBITMAP dst, int width, int height);

	//Summary:
	//     Stretches a native bitmap to fit the specified dimensions
	//Parameters:
	//     src - Handle to the source bitmap
	//     dst - Handle to the destination bitmap
	//     srcWidth - The width of the source bitmap
	//     srcHeight - The height of the source bitmap
	//     dstWidth - The width of the destination bitmap
	//     dstHeight - The height of the destination bitmap
	//Returns:
	//     TRUE if the operation was successful; otherwise, FALSE
	BOOL WINAPI StretchNativeBitmap(HBITMAP src, HBITMAP dst, int srcWidth, int srcHeight, int dstWidth, int dstHeight);

	//Summary:
	//     Performs alpha blending of a bitmap onto a device context
	//Parameters:
	//     src - Handle to the source bitmap
	//     hdc - Handle to the device context
	//     left - The left coordinate of the destination position
	//     top - The top coordinate of the destination position
	//     width - The width of the area to draw
	//     height - The height of the area to draw
	//     alpha - The alpha value for blending (0-255)
	//Returns:
	//     None
	void WINAPI AlphaBlendBitmap(HBITMAP src, HDC hdc, int left, int top, int width, int height, int alpha);

	//Summary:
	//     Loads a PNG bitmap from a file
	//Parameters:
	//     szFile - The path to the PNG file
	//     lpiWidth - Pointer to an integer that receives the width of the bitmap
	//     lpiHeight - Pointer to an integer that receives the height of the bitmap
	//     ppvBits - Pointer to a pointer that receives the bitmap bits (optional)
	//Returns:
	//     A handle to the loaded bitmap (HBITMAP) if successful; otherwise, NULL
	HBITMAP WINAPI LoadBitmapPNG(LPCWSTR szFile, LPINT lpiWidth, LPINT lpiHeight, __deref_opt_out void** ppvBits);

	//Summary:
	//     Loads a PNG bitmap from a resource
	//Parameters:
	//     handle - Handle to the module containing the resource
	//     szName - The name of the PNG resource
	//     lpiWidth - Pointer to an integer that receives the width of the bitmap
	//     lpiHeight - Pointer to an integer that receives the height of the bitmap
	//     ppvBits - Pointer to a pointer that receives the bitmap bits (optional)
	//Returns:
	//     A handle to the loaded bitmap (HBITMAP) if successful; otherwise, NULL
	HBITMAP WINAPI LoadPNGResource(HMODULE handle, LPCWSTR szName, LPINT lpiWidth, LPINT lpiHeight, __deref_opt_out void** ppvBits);

	//Summary:
	//     Loads a JPEG bitmap from a file
	//Parameters:
	//     szFile - The path to the JPEG file
	//     lpiWidth - Pointer to an integer that receives the width of the bitmap
	//     lpiHeight - Pointer to an integer that receives the height of the bitmap
	//     ppvBits - Pointer to a pointer that receives the bitmap bits (optional)
	//Returns:
	//     A handle to the loaded bitmap (HBITMAP) if successful; otherwise, NULL
	HBITMAP WINAPI LoadBitmapJPG(LPCWSTR szFile, LPINT lpiWidth, LPINT lpiHeight, __deref_opt_out void** ppvBits);

	//Summary:
	//     Copies a native bitmap to a device context
	//Parameters:
	//     src - Handle to the source bitmap
	//     dstDC - Handle to the destination device context
	//     width - The width of the area to copy
	//     height - The height of the area to copy
	//     left - The left coordinate of the destination position
	//     top - The top coordinate of the destination position
	//Returns:
	//     None
	void WINAPI CopyNativeBitmap(HBITMAP src, HDC dstDC, int width, int height, int left, int top);

	//Summary:
	//     Creates a new native bitmap
	//Parameters:
	//     width - The width of the bitmap
	//     height - The height of the bitmap
	//     ppvBits - Pointer to a pointer that receives the bitmap bits (optional)
	//Returns:
	//     A handle to the created bitmap (HBITMAP) if successful; otherwise, NULL
	HBITMAP WINAPI CreateNativeBitmap(INT width, INT height, __deref_opt_out void** ppvBits);

	//Summary:
	//     Gets the size of text when rendered with a specific font
	//Parameters:
	//     s - The text string
	//     hFont - Handle to the font
	//     proposedWidth - The proposed width of the text area
	//     flags - Flags for text measurement
	//     margins - Whether to include margins in the size calculation
	//Returns:
	//     The size of the text (SIZE)
	SIZE WINAPI GetTextSizeEx(LPCWSTR s, HFONT hFont, UINT proposedWidth, UINT flags, BOOL margins);

	//Summary:
	//     Converts em units to pixels
	//Parameters:
	//     em - The value in em units
	//Returns:
	//     The equivalent value in pixels
	int WINAPI EmToPixels(int em);

	//Summary:
	//     Converts points to pixels
	//Parameters:
	//     points - The value in points
	//Returns:
	//     The equivalent value in pixels
	int WINAPI PointsToPixels(int points);

	//Summary:
	//     Draws text directly onto a device context with specified background color
	//Parameters:
	//     hDC - Handle to the device context
	//     s - The text string to be drawn
	//     hFont - The font to use for drawing
	//     color - The color of the text
	//     background - The background color
	//     left - The left coordinate of the text position
	//     top - The top coordinate of the text position
	//Returns:
	//     None
	void WINAPI DrawTextDirectEx(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, COLORREF background, int left, int top);

	//Summary:
	//     Gets the horizontal DPI of the display
	//Returns:
	//     The horizontal DPI value
	int WINAPI DpiY();

	//Summary:
	//     Performs alpha blending between two device contexts
	//Parameters:
	//   hdcDest - Handle to the destination device context
	//	 xoriginDest - The x-coordinate of the upper-left corner of the destination rectangle
	//	 yoriginDest - The y-coordinate of the upper-left corner of the destination rectangle
	//	 wDest - The width of the destination rectangle
	//	 hDest - The height of the destination rectangle
	//	 hdcSrc - Handle to the source device context
	//	 xoriginSrc - The x-coordinate of the upper-left corner of the source rectangle
	//	 yoriginSrc - The y-coordinate of the upper-left corner of the source rectangle
	//	 wSrc - The width of the source rectangle
	//	 hSrc - The height of the source rectangle
	//	 alpha - The alpha value for blending (0-255)
	//Returns:
	//     None
	void WINAPI AlphaBlendNative(HDC hdcDest,
		int xoriginDest,
		int yoriginDest,
		int wDest,
		int hDest,
		HDC hdcSrc,
		int xoriginSrc,
		int yoriginSrc,
		int wSrc,
		int hSrc,
		BYTE alpha);


#ifdef __cplusplus
}
#endif

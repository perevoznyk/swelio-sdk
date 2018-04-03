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

SIZE WINAPI GetTextSize(LPCWSTR s, HFONT hFont, UINT flags);
void WINAPI DrawTextDirect(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, int left, int top);
void WINAPI DrawAlphaText(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, int width, int height, UINT flags);
void WINAPI DrawAlphaTextRect(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, LPRECT lpRect, UINT flags);
HFONT WINAPI CreateWindowsFont(LPCWSTR fontFamily, INT size, INT fontStyle, INT fontQuality); 
SIZE WINAPI GetTextLineSize(LPCWSTR s, HFONT hFont);
void WINAPI DrawTextLine(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, int left, int top);
HFONT WINAPI CloneFont(HFONT hFont);
void WINAPI DrawTextOutline(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF foreColor, COLORREF backColor, int left, int top);
void WINAPI DrawTextGlow(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF foreColor, int left, int top);
void WINAPI DrawTextRect(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, COLORREF background, LPRECT lpRect, UINT flags);
void WINAPI DestroyFont(HFONT hFont);
HBITMAP WINAPI MakeCompatibleBitmap(HBITMAP source, int width, int height);
void WINAPI DrawNativeBitmap(HBITMAP src, HBITMAP dst, int width, int height);
BOOL WINAPI StretchNativeBitmap(HBITMAP src, HBITMAP dst, int srcWidth, int srcHeight, int dstWidth, int dstHeight);
void WINAPI AlphaBlendBitmap(HBITMAP src, HDC hdc, int left, int top, int width, int height, int alpha);
HBITMAP WINAPI LoadBitmapPNG(LPCWSTR szFile, LPINT lpiWidth, LPINT lpiHeight, __deref_opt_out void **ppvBits);
HBITMAP WINAPI LoadPNGResource(HMODULE handle, LPCWSTR szName, LPINT lpiWidth, LPINT lpiHeight, __deref_opt_out void **ppvBits);
HBITMAP WINAPI LoadBitmapJPG(LPCWSTR szFile, LPINT lpiWidth, LPINT lpiHeight, __deref_opt_out void **ppvBits);
void WINAPI CopyNativeBitmap(HBITMAP src, HDC dstDC, int width, int height, int left, int top);
HBITMAP WINAPI CreateNativeBitmap(INT width, INT height, __deref_opt_out void **ppvBits);
SIZE WINAPI GetTextSizeEx(LPCWSTR s, HFONT hFont, UINT proposedWidth, UINT flags, BOOL margins);
int WINAPI EmToPixels(int em);
int WINAPI PointsToPixels(int points);
void WINAPI DrawTextDirectEx(HDC hDC, LPCWSTR s, HFONT hFont, COLORREF color, COLORREF background, int left, int top);
int WINAPI DpiY();
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

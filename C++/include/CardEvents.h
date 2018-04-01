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

typedef VOID (CALLBACK * CALLBACK_HANDLER) (LPDWORD, LPDWORD, PVOID);

/* The type of the reader event */
typedef enum tagCardEventType {
    ewtUnknownEvent, /* Unknown event */
	ewtCardInsert, /* The card was inserted in the reader */
    ewtCardRemove, /* The card was removed from the reader */
	ewtReadersChange /* The readers list changed */
} CardEventType ;

#ifdef __cplusplus
}
#endif

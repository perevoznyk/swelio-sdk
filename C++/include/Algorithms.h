//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#pragma once

#define SIGN_ALGO_RSASSA_PKCS1			0x01
#define SIGN_ALGO_RSASSA_PKCS1_SHA1		0x02
#define SIGN_ALGO_RSASSA_PKCS1_MD5		0x04
#define SIGN_ALGO_RSASSA_PKCS1_SHA256	0x08
#define SIGN_ALGO_RSASSA_PSS_SHA1		0x10
#define SIGN_ALGO_RSASSA_PSS_SHA256		0x20

#define SIGN_ALGO_ECDSA_SHA2_256		0x01
#define SIGN_ALGO_ECDSA_SHA2_384		0x02
#define SIGN_ALGO_ECDSA_SHA2_512		0x04
#define SIGN_ALGO_ECDSA_SHA3_256		0x08
#define SIGN_ALGO_ECDSA_SHA3_384		0x10
#define SIGN_ALGO_ECDSA_SHA3_512		0x20
#define SIGN_ALGO_ECDSA					0x40

//===============================================================================
//= Copyright (c) Serhiy Perevoznyk.  All rights reserved.
//= THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//= OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//= LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//= FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

//05.03.2021 - Applet 1.8 support

#if _MSC_VER > 1000
#pragma once
#endif

#if !defined( _CARDSTRUCTURES_H_ )
#define _CARDSTRUCTURES_H_

#ifdef __cplusplus
extern "C" {
#endif

// Maximum length of the card number field
#define EID_MAX_CARD_NUMBER_LEN                         0xc
// Maximum length of the chip number field
#define EID_MAX_CHIP_NUMBER_LEN                         0x20
// Maximum length of the begin date field
#define EID_MAX_DATE_BEGIN_LEN                          0xa
// Maximum length of the end date field
#define EID_MAX_DATE_END_LEN                            0xa
// Maximum length of the name of the devivery municipality
#define EID_MAX_DELIVERY_MUNICIPALITY_LEN               0x50
// Maximum length of the national number
#define EID_MAX_NATIONAL_NUMBER_LEN                     0xb
// Maximum length of the surname
#define EID_MAX_NAME_LEN                                0x6e
// Maximum length of the first name
#define EID_MAX_FIRST_NAME1_LEN                         0x5f
// Maximum length of the first name
#define EID_MAX_FIRST_NAME2_LEN                         0x3
// Maximum length of the nationality
#define EID_MAX_NATIONALITY_LEN                         0x55
// Maximum length of the birthplace
#define EID_MAX_BIRTHPLACE_LEN                          0x50
// Maximum length of the birthdate
#define EID_MAX_BIRTHDATE_LEN                           0xc
// Maximum length of the sex field
#define EID_MAX_SEX_LEN                                 0x1
// Maximum length of the noble condition field
#define EID_MAX_NOBLE_CONDITION_LEN                     0x32
// Maximum length of the document type field
#define EID_MAX_DOCUMENT_TYPE_LEN                       0x2
// Maximum length of the special status field
#define EID_MAX_SPECIAL_STATUS_LEN                      0x2
// Maximum length of the street name field
#define EID_MAX_STREET_LEN                              0x50
// Maximum length of the ZIP code field
#define EID_MAX_ZIP_LEN                                 0x4
// Maximum length of the municipality name field
#define EID_MAX_MUNICIPALITY_LEN                        0x43
// Maximum length of the picture data
#define EID_MAX_PICTURE_LEN                             0x1000
// Maximum length of the certificate data
#define EID_MAX_CERT_LEN                                0x800
// Maximum length of the Duplicate field
#define EID_MAX_DUPLICATE_LEN							2
// Maximum length of the Special organization field
#define EID_MAX_SPECIALORGANIZATION_LEN					1
// Maximum length of the Member of family field
#define EID_MAX_MEMBEROFFAMILY_LEN						1
// Maximum length of theDate and country of protection field
#define EID_MAX_DATEANDCOUNTRYOFPROTECTION_LEN			13
// Maximum length of the type of the workpermit
#define EID_MAX_WORKPERMITTYPE_LEN						1
// Maximum length of the VAT1 field
#define EID_MAX_VAT1_LEN								13
// Maximum length of the VAT2 field
#define EID_MAX_VAT2_LEN								13
// Maximum length of regional file number field
#define EID_MAX_REGIONALFILENUMBER_LEN					18
// Maximum length of the BREXIT mention field
#define EID_MAX_BREXITMENTION1_LEN						1
// Maximum length of the BREXIT mention field
#define EID_MAX_BREXITMENTION2_LEN						1






// Maximum length of the surname field
#define SIS_MAX_NAME_LEN								0x30
// Maximum length of the first name field
#define SIS_MAX_FIRSTNAMES_LEN							0x18
// Maximum length of the initial field
#define SIS_MAX_INITIAL_LEN								0x1
// Maximum length of the sex field
#define SIS_MAX_SEX_LEN									0x1
// Maximum length of the card name field
#define SIS_MAX_CARDNAME_LEN							0x6
// Maximum length of the birth date field
#define SIS_FIELD_MAX_BIRTHDATE_LEN						0x8
// Maximum length of the capture date field
#define SIS_FIELD_MAX_CAPTUREDATE_LEN					0x8
// Maximum length of the start validity date field
#define SIS_FIELD_MAX_VALIDBEGIN_LEN					0x8
// Maximum length of the end validity date field
#define SIS_FIELD_MAX_VALIDEND_LEN						0x8
// Maximum length of the social security number field
#define SIS_FIELD_MAX_SOCIAL_SECURITY_NUMBER_LEN		0xb
// Maximum length of the car number field
#define SIS_FIELD_MAX_CARDNUMBER_LEN					0xa


// Identity information stored on EID card - ANSI version
typedef struct tagEidIdentityA
{
public:
    // Electronic ID card number
	char cardNumber[EID_MAX_CARD_NUMBER_LEN+1];
    // Electronic ID card physical chip number
	char chipNumber[EID_MAX_CHIP_NUMBER_LEN+1];
    // Card validity start date 
	char validityDateBegin[EID_MAX_DATE_BEGIN_LEN+1];
    // Card validity end date
	char validityDateEnd[EID_MAX_DATE_END_LEN +1];
    // Card delivery municipality
	char municipality[EID_MAX_DELIVERY_MUNICIPALITY_LEN+1];
    // National number
	char nationalNumber[EID_MAX_NATIONAL_NUMBER_LEN+1];
    // Surname
	char name[EID_MAX_NAME_LEN+1];
    // First name (2 first given names)
	char firstName1[EID_MAX_FIRST_NAME1_LEN+1];
    // First name part 2 (first letter of the 3rd given name).
	char firstName2[EID_MAX_FIRST_NAME2_LEN+1];
    // Nationality
	char nationality[EID_MAX_NATIONALITY_LEN+1];
    // Birth location
	char birthLocation[EID_MAX_BIRTHPLACE_LEN+1];
    // Birth date
	char birthDate[EID_MAX_BIRTHDATE_LEN+1];
    // Sex
	char sex[EID_MAX_SEX_LEN+1];
    // Noble condition
	char nobleCondition[EID_MAX_NOBLE_CONDITION_LEN+1];
    // Document type code (Belgian citizen card, Kids Card, Foreigner card)
	int documentType;
    // White cane (blind people)
	BOOL whiteCane;
    // Yellow cane (partially sighted people)
	BOOL yellowCane;
    // Extended minority
	BOOL extendedMinority;
	// Duplicata
	char duplicate[EID_MAX_DUPLICATE_LEN + 1];
	// Special Organization
	char specialOrganization[EID_MAX_SPECIALORGANIZATION_LEN + 1];
	// Member of family
	BOOL memberOfFamily;
	// Date and country of protection
	char dateAndCountryOfProtection[EID_MAX_DATEANDCOUNTRYOFPROTECTION_LEN + 1];
	// Work Permit type
	char workPermitType[EID_MAX_WORKPERMITTYPE_LEN + 1];
	// Employer VAT1
	char vat1[EID_MAX_VAT1_LEN + 1];
	// Employer VAT2
	char vat2[EID_MAX_VAT2_LEN + 1];
	// Regional file number
	char regionalFileNumber[EID_MAX_REGIONALFILENUMBER_LEN + 1];
	// BREXIT
	char brexitMention1[EID_MAX_BREXITMENTION1_LEN + 1];
	// BREXIT
	char brexitMention2[EID_MAX_BREXITMENTION2_LEN + 1];
} EidIdentityA, *PEidIdentityA;


// Identity information stored on EID card - UNICODE version
typedef struct tagEidIdentityW
{
public:
    // Electronic ID card number
	WCHAR cardNumber[EID_MAX_CARD_NUMBER_LEN+1];
    // Electronic ID card physical chip number
	WCHAR chipNumber[EID_MAX_CHIP_NUMBER_LEN+1];
    // Card validity start date 
	WCHAR validityDateBegin[EID_MAX_DATE_BEGIN_LEN+1];
    // Card validity end date
	WCHAR validityDateEnd[EID_MAX_DATE_END_LEN +1];
    // Card delivery municipality
	WCHAR municipality[EID_MAX_DELIVERY_MUNICIPALITY_LEN+1];
    // National number
	WCHAR nationalNumber[EID_MAX_NATIONAL_NUMBER_LEN+1];
    // Surname
	WCHAR name[EID_MAX_NAME_LEN+1];
    // First name (2 first given names)
	WCHAR firstName1[EID_MAX_FIRST_NAME1_LEN+1];
    // First name part 2 (first letter of the 3rd given name).
	WCHAR firstName2[EID_MAX_FIRST_NAME2_LEN+1];
    // Nationality
	WCHAR nationality[EID_MAX_NATIONALITY_LEN+1];
    // Birth location
	WCHAR birthLocation[EID_MAX_BIRTHPLACE_LEN+1];
    // Birth date
	WCHAR birthDate[EID_MAX_BIRTHDATE_LEN+1];
    // Sex
	WCHAR sex[EID_MAX_SEX_LEN+1];
    // Noble condition
	WCHAR nobleCondition[EID_MAX_NOBLE_CONDITION_LEN+1];
    // Document type code (Belgian citizen card, Kids Card, Foreigner card)
	int documentType;
    // White cane (blind people)
	BOOL whiteCane;
    // Yellow cane (partially sighted people)
	BOOL yellowCane;
    // Extended minority
	BOOL extendedMinority;
	// Duplicata
	WCHAR duplicate[EID_MAX_DUPLICATE_LEN + 1];
	// Special Organization
	WCHAR specialOrganization[EID_MAX_SPECIALORGANIZATION_LEN + 1];
	// Member of family
	BOOL memberOfFamily;
	// Date and country of protection
	WCHAR dateAndCountryOfProtection[EID_MAX_DATEANDCOUNTRYOFPROTECTION_LEN + 1];
	// Work permit type
	WCHAR workPermitType[EID_MAX_WORKPERMITTYPE_LEN + 1];
	// Employer VAT1
	WCHAR vat1[EID_MAX_VAT1_LEN + 1];
	// Employer VAT2
	WCHAR vat2[EID_MAX_VAT2_LEN + 1];
	// Regional file number
	WCHAR regionalFileNumber[EID_MAX_REGIONALFILENUMBER_LEN + 1];
	// BREXIT
	WCHAR brexitMention1[EID_MAX_BREXITMENTION1_LEN + 1];
	// BREXIT
	WCHAR brexitMention2[EID_MAX_BREXITMENTION2_LEN + 1];
} EidIdentityW, *PEidIdentityW;

// Raw picture data from EID card
typedef struct tagEidPicture
{
public:
    // Picture raw data buffer
	BYTE picture[EID_MAX_PICTURE_LEN+1];
    // Picture raw data buffer length
	int pictureLength;
} EidPicture, *PeidPicture;

// Certificate, stored on EID card
typedef struct tagEidCertificate
{
public:
    // Certificate raw data buffer
	BYTE certificate[EID_MAX_CERT_LEN+1];
    // Certificate data length
	int certificateLength;
} EidCertificate, *PEidCertificate;

// EID address information, stored on the card - ANSI version
typedef struct tagEidAddressA
{
public:
    // Street name
	char street[EID_MAX_STREET_LEN+1];
    // ZIP code
	char zip[EID_MAX_ZIP_LEN+1];
    // Municipality
	char municipality[EID_MAX_MUNICIPALITY_LEN+1];
} EidAddressA, *PEidAddressA;

// EID address information, stored on the card - UNICODE version
typedef struct tagEidAddressW
{
public:
    // Street name
	WCHAR street[EID_MAX_STREET_LEN+1];
    // ZIP code
	WCHAR zip[EID_MAX_ZIP_LEN+1];
    // Municipality
	WCHAR municipality[EID_MAX_MUNICIPALITY_LEN+1];
} EidAddressW, *PEidAddressW;

//Public information stored on Belgian SIS card - ANSI version.
//The SIS card is the social security card of each Belgian resident
//(Belgian or foreigner)
typedef struct tagSISRecordA
{
public:
    //Family name of the card owner
	char Name[SIS_MAX_NAME_LEN + 1];
    //First name of the card owner
	char FirstName[SIS_MAX_FIRSTNAMES_LEN + 1];
    //Initial of the card owner
	char Initial[SIS_MAX_INITIAL_LEN+ 1];
    //Sex of the card owner
	char Sex[SIS_MAX_SEX_LEN + 1];
    //Birth date of the card owner
	char BirthDate[SIS_FIELD_MAX_BIRTHDATE_LEN + 1];
    //Social security number of the card owner
	char SocialSecurityNumber[SIS_FIELD_MAX_SOCIAL_SECURITY_NUMBER_LEN + 1];
    //Date of issue
	char CaptureDate[SIS_FIELD_MAX_CAPTUREDATE_LEN + 1];
    //Card validity begin date
	char ValidityDateBegin[SIS_FIELD_MAX_VALIDBEGIN_LEN + 1];
    //Card validity end date
	char ValidityDateEnd[SIS_FIELD_MAX_VALIDEND_LEN + 1];
    //Card number
	char CardNumber[SIS_FIELD_MAX_CARDNUMBER_LEN + 1];
    //Name of the card
	char CardName[SIS_MAX_CARDNAME_LEN +1 ];
} SISRecordA, *PSISRecordA;

//Public information stored on Belgian SIS card - UNICODE version.
//The SIS card is the social security card of each Belgian resident
//(Belgian or foreigner)
typedef struct tagSISRecordW
{
public:
    //Family name of the card owner
	WCHAR Name[SIS_MAX_NAME_LEN + 1];
    //First name of the card owner
	WCHAR FirstName[SIS_MAX_FIRSTNAMES_LEN + 1];
    //Initial of the card owner
	WCHAR Initial[SIS_MAX_INITIAL_LEN+ 1];
    //Sex of the card owner
	WCHAR Sex[SIS_MAX_SEX_LEN + 1];
    //Birth date of the card owner
	WCHAR BirthDate[SIS_FIELD_MAX_BIRTHDATE_LEN + 1];
    //Social security number of the card owner
	WCHAR SocialSecurityNumber[SIS_FIELD_MAX_SOCIAL_SECURITY_NUMBER_LEN + 1];
    //Date of issue
	WCHAR CaptureDate[SIS_FIELD_MAX_CAPTUREDATE_LEN + 1];
    //Card validity begin date
	WCHAR ValidityDateBegin[SIS_FIELD_MAX_VALIDBEGIN_LEN + 1];
    //Card validity end date
	WCHAR ValidityDateEnd[SIS_FIELD_MAX_VALIDEND_LEN + 1];
    //Card number
	WCHAR CardNumber[SIS_FIELD_MAX_CARDNUMBER_LEN + 1];
    //Name of the card
	WCHAR CardName[SIS_MAX_CARDNAME_LEN +1 ];
} SISRecordW, *PSISRecordW;


//DOM-IGNORE-BEGIN
#ifdef UNICODE
#define EidIdentity EidIdentityW
#define PEidIdentity PEidIdentityW
#define EidAddress EidAddressW
#define PEidAddress PEidAddressW
#define SISRecord SISRecordW
#define PSISRecord PSISRecordW
#else
#define EidIdentity EidIdentityA
#define PEidIdentity PEidIdentityA
#define EidAddress EidAddressA
#define PEidAddress PEidAddressA
#define SISRecord SISRecordA
#define PSISRecord PSISRecordA
#endif
//DOM-IGNORE-END
#ifdef __cplusplus
}
#endif

#endif	// _CARDSTRUCTURES_H_
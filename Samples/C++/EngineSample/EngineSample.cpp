// EngineSample.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <windows.h>
#include "Swelio.h"
#include "encryption.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{

	StartEngine();
	int cnt = GetReadersCount();
	cout << cnt;
	cout << " readers found\n";

	if (cnt > 0)
	{
		SelectReader(0);
		cout << GetSelectedReaderIndex();
		cout << "\n";

		int len = GetReaderNameLenA(0);
		char buf[256];
		GetReaderNameA(0, (LPSTR)&buf, len);
		cout << buf;
		cout << "\n";

		ActivateCard();

		SaveAuthenticationCertificateW(L"auth.cer");
		SaveRootCaCertificateW(L"root.cert");
		SaveCaCertificateW(L"citizen.cert");
		
		tagEidCertificate certificate;
		LoadCertificateW(L"citizen.cert", &certificate);
		DisplayCertificate(&certificate);


		GenerateQRCodeW(L"qrcode.png");

		SaveCardToXmlW(L"info_card_w.xml");
		SaveCardToXmlA("info_card_a.xml");

		SavePersonToCsvW(L"person_w.csv");
		SavePersonToCsvA("person_a.csv");

		SavePhotoAsBitmapW(L"person_w.bmp");
		SavePhotoAsBitmapA("person_a.bmp");

		SavePhotoAsJpeg(L"person.jpg");


	}

	StopEngine();

	cout << "\n";
	cout << "Press Enter to continue...";
	cin.get();
	return 0;

	return 0;
}


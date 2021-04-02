cls

set exepath=openssl.exe
set OPENSSL_CONF=c:\OpenSSL-Win32\bin\openssl.cnf

%exepath% genrsa -out "%1.key" %2 
IF NOT EXIST "%1.key" (
    ECHO genera failed to produce output
    pause
    EXIT /B
    )

%exepath% req -new -key "%1.key" -out "%1.csr" -config c:\OpenSSL-Win32\bin\openssl.cnf -extensions v3_req  
IF NOT EXIST "%1.csr" (
    ECHO req failed to produce output
    pause
    EXIT /B
    )

%exepath% x509 -req -days %3 -in "%1.csr" -signkey "%1.key" -out "%1.crt" -extfile v3.ext
IF NOT EXIST "%1.crt" (
    ECHO x509 failed to produce output
    pause
    EXIT /B
    )

%exepath% pkcs12 -export -in "%1".crt -inkey "%1".key -out "%1_pkcs12.pfx" -name "Universe Self-Signed SSL" 
IF NOT EXIST "%1_pkcs12.pfx" (
    ECHO pkcs12 failed to produce output
    pause
    EXIT /B
    )

//del "%1.key"
//del "%1.csr"
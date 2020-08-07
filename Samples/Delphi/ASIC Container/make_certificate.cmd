cls

set exepath=C:\OpenSSL-Win32\bin\openssl.exe

%exepath% genrsa -out "%1.key" %2
IF NOT EXIST "%1.key" (
    ECHO genera failed to produce output
    EXIT /B
    )

%exepath% req -new -key "%1.key" -out "%1.csr" -config c:\openssl\openssl.cnf
IF NOT EXIST "%1.csr" (
    ECHO req failed to produce output
    EXIT /B
    )

%exepath% x509 -req -days %3 -in "%1.csr" -signkey "%1.key" -out "%1.crt"
IF NOT EXIST "%1.crt" (
    ECHO x509 failed to produce output
    EXIT /B
    )

%exepath% pkcs12 -export -in "%1".crt -inkey "%1".key -out "%1_pkcs12.pfx" -name "Universe Self-Signed SSL"
IF NOT EXIST "%1_pkcs12.pfx" (
    ECHO pkcs12 failed to produce output
    EXIT /B
    )

del "%1.key"
del "%1.csr"
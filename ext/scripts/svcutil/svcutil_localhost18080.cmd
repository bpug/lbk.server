@echo off
color 0a

REM set SHAREDLIB="..\..\lib\app shared\AssemblyDto.dll"
REM if exist %SHAREDLIB% goto buildproxy
REM echo Unable to detect current %SHAREDLIB%. Build may not succeed.
REM goto end


:buildproxy
set TOOLPATH="..\..\tools\svcutil\SvcUtil.exe"
set SERVICEURL="http://localhost:18080/services/MainModuleService.svc/mex"

set OUTPUTPATH=%~dp0
REM same as set OUTPUTPATH="%cd%"

set CONFIGNAME="client.config"
set OUTPUTFILE="ClientProxy.cs"
set NAMESPACE="DistributedService.ServiceAgent"

set COLLECTIONTYPEFLAG1=/collectionType:System.Collections.Generic.List`1
set COLLECTIONTYPEFLAG2=
set COLLECTIONTYPEFLAG3=
REM set COLLECTIONTYPEFLAG?=/collectionType:System.Collections.Generic.List`1

set TARGETCLIENTVERSION=Version35

set REFERENCEDASSEMBLYFLAG1=
set REFERENCEDASSEMBLYFLAG2=
set REFERENCEDASSEMBLYFLAG3=
REM set REFERENCEDASSEMBLYFLAG?=/reference:"..\..\lib\AssemblyDto.dll"

set ASYNCFLAG=
REM set ASYNCFLAG=/async

set SERIALIZABLEFLAG=
REM set SERIALIZABLEFLAG=/serializable

set SERIALIZERFLAG=
REM /serializer:XmlSerializer
REM /serializer:DataContractSerializer
REM /serializer:Auto

set ENABLEDATABINDINGFLAG=
REM set ENABLEDATABINDINGFLAG=/enableDataBinding


%TOOLPATH% ^
/directory:%OUTPUTPATH% ^
/config:%CONFIGNAME% ^
/out:%OUTPUTFILE% ^
/namespace:*,%NAMESPACE% ^
%COLLECTIONTYPEFLAG1% ^
%COLLECTIONTYPEFLAG2% ^
%COLLECTIONTYPEFLAG3% ^
/targetClientVersion:%TARGETCLIENTVERSION% ^
%REFERENCEDASSEMBLYFLAG1% ^
%REFERENCEDASSEMBLYFLAG2% ^
%REFERENCEDASSEMBLYFLAG3% ^
%ASYNCFLAG% ^
%SERIALIZABLEFLAG% ^
%ENABLEDATABINDINGFLAG% ^
%SERVICEURL%
goto end


:end
pause
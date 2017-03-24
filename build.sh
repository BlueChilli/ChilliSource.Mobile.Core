#!/bin/sh
if [[ $# -gt 0 ]] 
then
	cd scripts && sh license-header.sh add
	exitCode=$?

	cd ..

	if [[ $exitCode != 0 ]]
	then 
	   git commit -a -m "automated addition of header license info"
	   git push origin HEAD
	fi
fi	

rm -rf artifacts/*.*
rm -rf **/bin
rm -rf **/obj
rm -rf src/*.tmp.*
mono tools/nuget/nuget.exe update -self
mono tools/nuget/nuget.exe install Cake -OutputDirectory tools -ExcludeVersion

mono tools/Cake/Cake.exe build.cake

cd /c/github/database

rm -f -r -d docs/*
powershell.exe -noprofile ./gendoc.ps1
git add .
git commit .
git push
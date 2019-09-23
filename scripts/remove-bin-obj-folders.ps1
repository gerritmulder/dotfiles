# Will remove all /bin and /obj folders in all directories.
Get-ChildItem ../ -Include bin,obj -Recurse | ForEach ($_) { Write-Host "Deleting $_.FullName" | Remove-Item $_.FullName -Force -Recurse  }
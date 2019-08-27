# Will remove all /bin and /obj folders in all directories
Get-ChildItem .. -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }
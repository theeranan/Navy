readme file

post-build event
xcopy "$(ProjectDir)Library\tessdata" "$(TargetDir)tessdata" /Y /I
xcopy "$(ProjectDir)Library\EmguCV\lib\*.lib" "$(TargetDir)" /Y/I
xcopy "$(ProjectDir)Library\EmguCV\*.dll" "$(TargetDir)" /Y/I

post-build event for default
xcopy "$(EMGUCV_HOME)bin\tessdata" "$(TargetDir)tessdata" /Y /I
xcopy "$(EMGUCV_HOME)bin\x86\*.dll" "$(TargetDir)" /Y/I
xcopy "$(EMGUCV_HOME)lib\x64\*.lib" "$(TargetDir)" /Y/I
xcopy "$(EMGUCV_HOME)x64\vc12\staticlib\*.lib" "$(TargetDir)" /Y/I
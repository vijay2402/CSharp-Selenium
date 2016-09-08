cd C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\
set MYBROWSER=Firefox
set RESULTDIRECTORY=c:\Tests\TestResults
vstest.console.exe "C:\Users\Admin\Documents\Visual Studio 2015\Projects\CategoriesDataDriven\CategoriesDataDriven\bin\Debug\CategoriesDataDriven.dll" /UseVsixExtensions:true /logger:"sqliteLogger"
Pause
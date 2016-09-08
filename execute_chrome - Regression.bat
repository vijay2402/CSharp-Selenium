cd C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\
set MYBROWSER=Chrome
set RESULTDIRECTORY=c:\Tests\TestResults
vstest.console.exe "C:\Users\tcolley\Documents\Visual Studio 2015\Projects\CategoriesDataDriven\CategoriesDataDriven\bin\Debug\CategoriesDataDriven.dll" /TestCaseFilter:TestCategory=Regression /UseVsixExtensions:true /logger:"comboLogger"
Pause
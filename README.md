# Donate-Money-For-Unicorns-ubbse2015

External dependencies:
  -poker evaluator source: http://theg2.net/texasholdem/ -> TexasHoldem_Greg_Bray_V1.09_2009AUG25/TexasHoldem/Other/Hand_Evaluator_V2_Original_Source/Hand_Evaluator/Hand Evaluator/HandEvaluator
  
Resources:
  -card-BMPs : card images
  
How to build:
	-Requirement: .NET Framework 4.0.30319
	
	-Run following line in command line:
    C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild "Dynamic Games\Dynamic Games\Dynamic Games.csproj" /p:Configuration=Release;DeployOnBuild=True;PackageAsSingleFile=True;outdir="..\..\bin\

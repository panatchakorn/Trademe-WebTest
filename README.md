# Trademe-WebTest
This Web UI Trademe Sandbox test project (https://www.tmsandbox.co.nz) implements using VisualStudio 2019 (Community version). 
It is a C# NUnit Test Project using .Net, SpecFlow and Selenium. It uses SpecFlow LivingDoc to generate test reports. The report needs to be run in command line. See further info below.

The project is to test that user can search and view used car listing.

<b>---- Pre-requisites ----</b>
- Install Visual Studio 2019 (I use community version) with:

  -- NET desktop development (from installation details section > tick .NET Framework 4.6.1 development tools)
  
  -- Universal Windows Platform development
- Open Visual Studio 2019 without launching any project > Go to Extensions > Manage Extensions
- Search, download and install: 

   -- GitHub Extension for Visual Studio
   
   -- SpecFlow for Visual Studio 2019
- Chrome (Version 88.0.4324.104) and Firefox (84.0.2).
If you have different browsers version, Webdrivers will need to be updated in Nuget.
<i><b>BrowserType has been set to use Chrome for testing. This can be changed to Firefox in SearchUsedCarsSteps.cs</b></i>

<b>---- Clone project and run test----</b>

- From Visual studio clone a new project from https://github.com/panatchakorn/Trademe-WebTest
It will download and restore required packages:
    <PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
    <PackageReference Include="nunit" Version="3.13.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="3.17.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.8.3" />
    <PackageReference Include="Selenium.Firefox.WebDriver" Version="0.27.0" />
    <PackageReference Include="Selenium.Support" Version="3.141.0" />
    <PackageReference Include="Selenium.WebDriver" Version="3.141.0" />
    <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="88.0.4324.9600" />
    <PackageReference Include="SpecFlow" Version="3.5.5" />
    <PackageReference Include="SpecFlow.NUnit" Version="3.5.5" />
    <PackageReference Include="SpecFlow.Plus.LivingDocPlugin" Version="3.5.286" />
    <PackageReference Include="SpecFlow.Tools.MsBuild.Generation" Version="3.5.5" />

<i><b>Note:</b> LivingDocPlugin depends on SpecFlow 3.5.5 and SpecFlow.NUnit 3.5.5 so don't upgrade to latest</i>

- Now you can right click on the Solution and select Run Tests

<b>---- Manual Reference Download from Nuget -----</b>

In the case where it has failed to automatically restore the packages, you can download it via Nuget

- Expand TrademeSandbox Project > Dependencies > Packages to see current packages.
- Right click TrademeSandbox Project and Select Manage Nuget Packages
- Go to Browse section, search and install any missing packages
- Rebuild the project.

<b>---- Rebuild Trademe Solution and run the test ----</b>

- Right click on the TrademeSandbox Solution > Select Clean Solution
- Right click on the TrademeSandbox Solution > Select Build Solution
- From Test Explorer > Run the test

<b>---- SpecFlow Living Doc ----</b>

1. First install SpecFlow Living Doc from command prompt

To do this follow cli install from https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Installing-the-command-line-tool.html

It will install to ..bin\Debug\netcoreapp3.1 folder. 

Example location from my machine C:\Users\panat\source\repos\TrademeSandbox\bin\Debug\netcoreapp3.1

2. Run the test in Visual Studio

3. Run command to generate report in command prompt. Notes to make changes to the directory path before running the command. This will generate report call LivingDoc.html in the Results folder.

- See command to generate report https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Using-the-command-line-tool.html#generating-with-test-results

Examples: 
- Generate the Living Documentation from SpecFlow test assembly:

<i> livingdoc test-assembly C:\Users\panat\source\repos\TrademeSandbox\bin\Debug\netcoreapp3.1\TrademeSandbox.dll -t C:\Users\panat\source\repos\TrademeSandbox\bin\Debug\netcoreapp3.1\TestExecution.json --title "Trademe Sandbox Testing" --output "C:\Users\panat\source\repos\TrademeSandbox\Results" </i>

- Generate the Living Documentation from feature files:

<i> livingdoc feature-folder C:\Users\panat\source\repos\TrademeSandbox -t C:\Users\panat\source\repos\TrademeSandbox\bin\Debug\netcoreapp3.1\TestExecution.json --title "Trademe Sandbox Testing" --output "C:\Users\panat\source\repos\TrademeSandbox\Results" </i>


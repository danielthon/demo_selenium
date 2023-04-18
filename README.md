# demo_selenium

This is a .NET Core 6.0

-   **SpecFlow**  for BDD feature/scenario/step management;
-   **NUnit**  for test identification and execution;
-   **Selenium.WebDriver**  for performing browser actions;
-   **SpecFlow.LivingDocs**  for BDD tests reporting.

##

For running **SpecFlow.LivingDocs** it is needed first to install the CLI tool:

`dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI `

After that, the command below generates the HTML report based in in the test execution file inside the `bin` project folder after a test run:

` livingdoc test-assembly tests.dll -t TestExecution.json `

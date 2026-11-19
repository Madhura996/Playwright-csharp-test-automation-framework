# Playwright C# Test Automation Framework

## Test run videos

Each test runs in a Playwright browser context configured to record video. NUnit
teardown closes the context before the browser, which finalizes and saves the
recording for both passing and failing tests.

Videos are written as `.webm` files to
`Playwright-csharp-test-automation-framework/TestResults/videos/`. Playwright
generates a separate filename for each recording. The output directory is
ignored by Git.

Run the tests with the included settings file to configure the application URL
and browser:

```powershell
dotnet test .\Playwright-csharp-test-automation-framework\Playwright-csharp-test-automation-framework.csproj --settings .\Playwright-csharp-test-automation-framework\local.runsettings
```

Playwright C# Test Automation Framework

A small Playwright + NUnit project for trying out UI tests against SauceDemo. It uses a Page Object Model (POM), so the tests can focus on what a user does while the page and element details live in their own classes.

## What you'll need

- Git
- The .NET 10 SDK
- PowerShell on Windows

## Get it running

1. Clone the repo and move into the project folder:

   ```powershell
   git clone https://github.com/Madhura996/Playwright-csharp-test-automation-framework.git
   cd Playwright-csharp-test-automation-framework
   ```

2. Restore and build the solution:

   ```powershell
   dotnet build .\Playwright-csharp-test-automation-framework.slnx
   ```

3. Install Playwright's browser binaries. The test project uses Chromium by default:

   ```powershell
   .\Playwright-csharp-test-automation-framework\bin\Debug\net10.0\playwright.ps1 install chromium
   ```

4. Run the tests with the checked-in settings:

   ```powershell
   dotnet test .\Playwright-csharp-test-automation-framework\Playwright-csharp-test-automation-framework.csproj --settings .\Playwright-csharp-test-automation-framework\local.runsettings
   ```

The settings file points at `https://www.saucedemo.com` and selects Chrome (Playwright's Chromium). To try another supported browser, change `RunLocalPlatform` in `local.runsettings` to `Firefox` or `Webkit`, then install that browser too with the matching name, for example `playwright.ps1 install firefox`.

The URL can also be overridden with the `URL` environment variable. If neither that variable nor the `Url` test-run parameter is set, test setup reports that the URL is missing.

## Where things live

```text
.
├── Playwright-csharp-test-automation-framework.slnx
├── Playwright-csharp-test-automation-framework/
│   ├── Tests/
│   │   ├── BaseTest.cs
│   │   ├── LoginPageTests.cs
│   │   └── EndToEndTest.cs
│   ├── local.runsettings
│   └── Playwright-csharp-test-automation-framework.csproj
└── Test-automation-PageObjectModel/
    ├── Components/
    ├── Interfaces/
    ├── Pages/
    └── Test-automation-PageObjectModel.csproj
```

- `Playwright-csharp-test-automation-framework` is the NUnit test project. `BaseTest` starts a browser and a fresh context for each test, creates `pageDriver`, and closes the context and browser during teardown.
- `Tests` contains the test scenarios. `LoginPageTests` covers successful and locked-out login; `EndToEndTest` walks through the shopping and checkout flow.
- `Test-automation-PageObjectModel` is a separate class library referenced by the test project. It holds the reusable page and component classes.
- `local.runsettings` supplies the default site URL and browser choice when running tests locally.

## How the POM is set up

The page objects are in `Test-automation-PageObjectModel/Pages`. Each page class represents a site page and exposes the elements or actions that tests need. For example, `LoginPage` extends `BasePage`, gives the login URL to the base class, and exposes `Username`, `Password`, `Login`, and `Error` as reusable components.

`BasePage` keeps the Playwright `IPage` and builds the page URL from a base URL and a path. Its `GotoAsync` and `WaitForURLAsync` methods handle common navigation and waiting. Individual page classes can then add their own page-specific components.

The reusable element wrappers live in `Components`. `BaseComponent` locates elements using their `data-test` attribute; wrappers such as `TextField`, `Button`, and `HeaderComponent` provide the operations used by pages and tests. The small interfaces in `Interfaces` describe shared component behaviors.

In a test, create the page object with the `pageDriver` and `BaseUrl` from `BaseTest`, then call its components and page methods. For example, a login test navigates with `LoginPage.GotoAsync()`, fills `Username` and `Password`, clicks `Login`, and checks the result. That keeps selectors and common interactions out of the test steps.

## Test run videos

Each test records a video, whether it passes or fails. Playwright writes a separate `.webm` file for each test under `Playwright-csharp-test-automation-framework/TestResults/videos/`. The test teardown awaits browser-context closure before closing the browser, which lets Playwright finish the recording. The generated video folder is ignored by Git.

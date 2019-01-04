# End to End Tests

These tests use the [xUnit](https://github.com/xunit/xunit) framework these are __NOT__ unit tests. They are integration tests that exercise the SDK functions the way a user would use them. The tests run in 2 modes:

1. __Recording__: when the [recordings] folder is empty the tests record the HTTP payloads into this folder as JSON.
2. __Replaying__: when [recordings] are present the tests do not actually make any network calls. They simply compare the requests to the recorded ones and replay the recorded responses.

The tests use the helper classes from [Autodesk.Forge.Core.E2eTestHelpers](https://git.autodesk.com/forge-ozone/shared-dotnet-rsdk/tree/master/src/Autodesk.Forge.Core.E2eTestHelpers).

## Running  tests
```
dotnet test DesignAutomation.sln
```
Or 

Use the the Text Explorer in Visual Studio.

## Adding new tests

Integration tests by their very nature are order dependement so if you are adding a new test then you will likely have to delete all a recordings so that test make real calls and you get the expected results in your new test.

When you create the recording it is very important that you review the resulting .json files so that they have the expected content.



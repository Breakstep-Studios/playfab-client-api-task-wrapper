# PlayFab Client API Task Wrapper
The PlayFab client API Task wrapper wraps the Unity client API to convert the async callback pattern to task async await pattern.

### Usage Note
In most cases it would be preferrable to utilize the [PlayFab C# sdk](https://docs.microsoft.com/en-us/gaming/playfab/sdks/c-sharp/) ([Additional notes here](https://community.playfab.com/questions/47743/unity-stripping-doesnt-work-on-low-setting.html)) within Unity. This tool is most beneficial for projects that have already gone the Unity SDK route and are looking to gradually move code base to async await pattern. 

# Examples
### Example Conversion
```csharp
/// <inheritdoc cref="PlayFabClientAPI.GetTitleData"/>
public static Task<PlayFabCommonResponse<GetTitleDataResult>> GetTitleDataAsync(
    GetTitleDataRequest request)
{
    var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetTitleDataResult>>();
    PlayFabClientAPI.GetTitleData(request, (result) =>
    {
        taskCompletionSource.SetResult(new PlayFabCommonResponse<GetTitleDataResult>(result,null));
    }, (error) =>
    {
        taskCompletionSource.SetResult(new PlayFabCommonResponse<GetTitleDataResult>(null, error));
    });
    return taskCompletionSource.Task;
}
```

### Example Usage
```csharp
public async PlayFabCommonResponse<GetTitleDataResult> GetTitleDataData()
{
    var getTitleDataRequest = new GetTitleDataRequest
    {
        Keys = new List<string> { "Data" }
    };
    var result = await PlayFabClientAPIWrapper.GetTitleDataAsync(getTitleDataRequest);
    if (result.ContainsError)
    {
        return result;
    }
}
```

using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using ThomasBrown.PlayFab;

namespace BreakstepStudios.Scripts.Runtime.PlayFab
{
    public static class PlayFabClientAPIWrapper
    {
        /// <inheritdoc cref="PlayFabClientAPI.ExecuteCloudScript"/>
        public static Task<PlayFabCommonResponse<LoginResult>> LoginWithCustomIdAsync(LoginWithCustomIDRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<LoginResult>>();
            PlayFabClientAPI.LoginWithCustomID(request, 
                (result) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<LoginResult>(result,null));
                },
                (error) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<LoginResult>(null,error));
                }
            );
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.ExecuteCloudScript"/>
        public static Task<PlayFabCloudScriptResponse> ExecuteCloudScriptAsync(ExecuteCloudScriptRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCloudScriptResponse>();
            PlayFabClientAPI.ExecuteCloudScript(request, 
                (result) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCloudScriptResponse(result,null));
                },
                (error) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCloudScriptResponse(null,error));
                }
            );
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.ExecuteCloudScript{TOut}"/>
        public static Task<PlayFabCommonResponse<ExecuteCloudScriptResult>> ExecuteCloudScriptAsync<T>(ExecuteCloudScriptRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<ExecuteCloudScriptResult>>();
            PlayFabClientAPI.ExecuteCloudScript<T>(request, 
                (result) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<ExecuteCloudScriptResult>(result,null));
                },
                (error) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<ExecuteCloudScriptResult>(null,error));
                }
            );
            return taskCompletionSource.Task;
        }

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
    }
}
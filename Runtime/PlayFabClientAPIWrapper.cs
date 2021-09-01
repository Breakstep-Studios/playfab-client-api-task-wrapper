﻿using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using ThomasBrown.PlayFab;

namespace BreakstepStudios.Scripts.Runtime.PlayFab
{
    public static class PlayFabClientAPIWrapper
    {
        /// <inheritdoc cref="PlayFabClientAPI.LoginWithCustomID"/>
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

        /// <inheritdoc cref="PlayFabClientAPI.LoginWithPlayFab"/>
        public static Task<PlayFabCommonResponse<LoginResult>> LoginWithPlayFabAsync(LoginWithPlayFabRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<LoginResult>>();
            PlayFabClientAPI.LoginWithPlayFab(request,
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

        /// <inheritdoc cref="PlayFabClientAPI.LoginWithEmailAddress"/>
        public static Task<PlayFabCommonResponse<LoginResult>> LoginWithEmailAddressAsync(LoginWithEmailAddressRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<LoginResult>>();
            PlayFabClientAPI.LoginWithEmailAddress(request,
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
        
        /// <inheritdoc cref="PlayFabClientAPI.GetTitleData"/>
        public static Task<PlayFabCommonResponse<UpdateCharacterDataResult>> UpdateCharacterDataAsync(
            UpdateCharacterDataRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<UpdateCharacterDataResult>>();
            PlayFabClientAPI.UpdateCharacterData(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<UpdateCharacterDataResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<UpdateCharacterDataResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetTime"/>
        public static Task<PlayFabCommonResponse<GetTimeResult>> GetTimeAsync(
            GetTimeRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetTimeResult>>();
            PlayFabClientAPI.GetTime(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetTimeResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetTimeResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
    }
}
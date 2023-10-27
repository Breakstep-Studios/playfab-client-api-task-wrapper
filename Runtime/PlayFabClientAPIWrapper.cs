using System.Threading.Tasks;
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

        /// <inheritdoc cref="PlayFabClientAPI.LinkSteamAccount"/>
        public static Task<PlayFabCommonResponse<LinkSteamAccountResult>> LinkSteamAccountAsync(LinkSteamAccountRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<LinkSteamAccountResult>>();
            PlayFabClientAPI.LinkSteamAccount(request,
                (result) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<LinkSteamAccountResult>(result,null));
                },
                (error) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCommonResponse<LinkSteamAccountResult>(null,error));
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
        public static Task<PlayFabCloudScriptResponse<T>> ExecuteCloudScriptAsync<T>(ExecuteCloudScriptRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCloudScriptResponse<T>>();
            PlayFabClientAPI.ExecuteCloudScript<T>(request, 
                (result) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCloudScriptResponse<T>(result,null));
                },
                (error) =>
                {
                    taskCompletionSource.SetResult(new PlayFabCloudScriptResponse<T>(null,error));
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
        
        /// <inheritdoc cref="PlayFabClientAPI.UpdateCharacterData"/>
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
        
        /// <inheritdoc cref="PlayFabClientAPI.GetCharacterData"/>
        public static Task<PlayFabCommonResponse<GetCharacterDataResult>> GetCharacterDataAsync(
            GetCharacterDataRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetCharacterDataResult>>();
            PlayFabClientAPI.GetCharacterData(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetCharacterDataResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetCharacterDataResult>(null, error));
            });
            return taskCompletionSource.Task;
        }

        /// <inheritdoc cref="PlayFabClientAPI.GetCharacterInventory"/>
        public static Task<PlayFabCommonResponse<GetCharacterInventoryResult>> GetCharacterInventoryAsync(
            GetCharacterInventoryRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetCharacterInventoryResult>>();
            PlayFabClientAPI.GetCharacterInventory(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetCharacterInventoryResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetCharacterInventoryResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetLeaderboardAroundPlayer"/>
        public static Task<PlayFabCommonResponse<GetLeaderboardAroundPlayerResult>> GetLeaderboardAroundPlayerAsync(
            GetLeaderboardAroundPlayerRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetLeaderboardAroundPlayerResult>>();
            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetLeaderboardAroundPlayerResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetLeaderboardAroundPlayerResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetLeaderboard"/>
        public static Task<PlayFabCommonResponse<GetLeaderboardResult>> GetLeaderboardAsync(GetLeaderboardRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetLeaderboardResult>>();
            PlayFabClientAPI.GetLeaderboard(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetLeaderboardResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetLeaderboardResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetCatalogItems"/>
        public static Task<PlayFabCommonResponse<GetCatalogItemsResult>> GetCatalogItemsAsync(
            GetCatalogItemsRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetCatalogItemsResult>>();
            PlayFabClientAPI.GetCatalogItems(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetCatalogItemsResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetCatalogItemsResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetUserInventory"/>
        public static Task<PlayFabCommonResponse<GetUserInventoryResult>> GetUserInventoryAsync(
            GetUserInventoryRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetUserInventoryResult>>();
            PlayFabClientAPI.GetUserInventory(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetUserInventoryResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetUserInventoryResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GrantCharacterToUser"/>
        public static Task<PlayFabCommonResponse<GrantCharacterToUserResult>> GrantCharacterToUserAsync(
            GrantCharacterToUserRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GrantCharacterToUserResult>>();
            PlayFabClientAPI.GrantCharacterToUser(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GrantCharacterToUserResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GrantCharacterToUserResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetFriendsList"/>
        public static Task<PlayFabCommonResponse<GetFriendsListResult>> GetFriendsListAsync(GetFriendsListRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetFriendsListResult>>();
            PlayFabClientAPI.GetFriendsList(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetFriendsListResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetFriendsListResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.AddFriend"/>
        public static Task<PlayFabCommonResponse<AddFriendResult>> AddFriendAsync(AddFriendRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<AddFriendResult>>();
            PlayFabClientAPI.AddFriend(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<AddFriendResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<AddFriendResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.RemoveFriend"/>
        public static Task<PlayFabCommonResponse<RemoveFriendResult>> RemoveFriendAsync(RemoveFriendRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<RemoveFriendResult>>();
            PlayFabClientAPI.RemoveFriend(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<RemoveFriendResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<RemoveFriendResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.SetFriendTags"/>
        public static Task<PlayFabCommonResponse<SetFriendTagsResult>> SetFriendTagsAsync(SetFriendTagsRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<SetFriendTagsResult>>();
            PlayFabClientAPI.SetFriendTags(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<SetFriendTagsResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<SetFriendTagsResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.PurchaseItem"/>
        public static Task<PlayFabCommonResponse<PurchaseItemResult>> PurchaseItemAsync(
            PurchaseItemRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<PurchaseItemResult>>();
            PlayFabClientAPI.PurchaseItem(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<PurchaseItemResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<PurchaseItemResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.ValidateGooglePlayPurchase"/>
        public static Task<PlayFabCommonResponse<ValidateGooglePlayPurchaseResult>> ValidateGooglePlayPurchaseAsync(
            ValidateGooglePlayPurchaseRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<ValidateGooglePlayPurchaseResult>>();
            PlayFabClientAPI.ValidateGooglePlayPurchase(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<ValidateGooglePlayPurchaseResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<ValidateGooglePlayPurchaseResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.ValidateIOSReceipt"/>
        public static Task<PlayFabCommonResponse<ValidateIOSReceiptResult>> ValidateIOSReceiptAsync(
            ValidateIOSReceiptRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<ValidateIOSReceiptResult>>();
            PlayFabClientAPI.ValidateIOSReceipt(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<ValidateIOSReceiptResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<ValidateIOSReceiptResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
        
        /// <inheritdoc cref="PlayFabClientAPI.GetAccountInfo"/>
        public static Task<PlayFabCommonResponse<GetAccountInfoResult>> GetAccountInfoAsync(
            GetAccountInfoRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetAccountInfoResult>>();
            PlayFabClientAPI.GetAccountInfo(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetAccountInfoResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetAccountInfoResult>(null, error));
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
        
        /// <inheritdoc cref="PlayFabClientAPI.GetStoreItems"/>
        public static Task<PlayFabCommonResponse<GetStoreItemsResult>> GetStoreItemsAsync(GetStoreItemsRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetStoreItemsResult>>();
            PlayFabClientAPI.GetStoreItems(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetStoreItemsResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetStoreItemsResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
    }
}
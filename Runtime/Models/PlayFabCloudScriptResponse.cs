﻿using PlayFab;
using PlayFab.ClientModels;

namespace ThomasBrown.PlayFab
{
    public class PlayFabCloudScriptResponse : PlayFabCommonResponse<ExecuteCloudScriptResult>
    {
        public PlayFabCloudScriptResponse(ExecuteCloudScriptResult result, PlayFabError error) : base(result, error)
        {
        }

        /// <summary>
        /// Checks if we had an error in our response, or if we had a script execution error
        /// </summary>
        public override bool ContainsError
        {
            get { return Result.Error != null || base.ContainsError; }
        }
    }
}
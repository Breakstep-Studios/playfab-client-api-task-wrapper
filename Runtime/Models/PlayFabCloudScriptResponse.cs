using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

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
    
    public class PlayFabCloudScriptResponse<T> : PlayFabCommonResponse<ExecuteCloudScriptResult>
    {
        private T functionResult;
        
        public PlayFabCloudScriptResponse(ExecuteCloudScriptResult result, PlayFabError error) : base(result, error)
        {
            functionResult = (T)result?.FunctionResult;
        }

        /// <summary>
        /// Checks if we had an error in our response, or if we had a script execution error
        /// </summary>
        public override bool ContainsError
        {
            get { return Result.Error != null || base.ContainsError; }
        }

        /// <summary>
        /// The error code contained in our logs if any <see cref="PlayFabCloudScriptResponseLogsErrorCode"/> code example for more info.
        /// </summary>
        public PlayFabCloudScriptResponseLogsErrorCode LogsErrorCode
        {
            get
            {
                if (Result.Error == null)
                {
                    return PlayFabCloudScriptResponseLogsErrorCode.NoError;
                }

                if (Result.Logs.Count <= 0)
                {
                    return PlayFabCloudScriptResponseLogsErrorCode.Unknown;
                }

                if (Result.Logs[0].Data == null)
                {
                    return PlayFabCloudScriptResponseLogsErrorCode.Unknown;
                }
                
                //prefer this so we are using all PlayFab json deserialization
                var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
                try
                {
                    var logsErrorData = serializer.DeserializeObject<LogsErrorData>(Result.Logs[0].Data.ToString());
                    return logsErrorData.ErrorCode;
                }
                catch (Exception)
                {
                    // ignored
                }

                return PlayFabCloudScriptResponseLogsErrorCode.Unknown; 
            }
        }

        public T FunctionResult
        {
            get { return functionResult; }
        }
    }
    
    /// <summary>
    /// Allows us to map a cloud script error code using log.error(message,object errorCodeDataObject)
    /// <code>
    /// function throwError(message){
    ///     let errorDataObject = {};
    ///     errorData["Data"] = {
    ///         "ErrorCode":5
    ///     }
    ///     log.error(message,errorData)
    ///     throw message;
    /// }
    /// </code>
    /// </summary>
    public enum PlayFabCloudScriptResponseLogsErrorCode
    {
        NoError = -1,
        Unknown = 1,
        InvalidParams = 1000,
        PlayerStatsNotFoundForLeaderboard = 1001,
        LeaderboardEmpty = 1002
    }

    /// <summary>
    /// Represents the additional error data our log contains if any
    /// </summary>
    public class LogsErrorData
    {
        public PlayFabCloudScriptResponseLogsErrorCode ErrorCode;
    }
}
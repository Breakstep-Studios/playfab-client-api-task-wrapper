using System;
using System.Collections.Generic;
using System.Linq;
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
            get { return Result?.Error != null || base.ContainsError; }
        }
        
        /// <summary>
        /// The error code contained in our logs if any <see cref="PlayFabCloudScriptResponseLogsErrorCode"/> code example for more info.
        /// </summary>
        public PlayFabCloudScriptResponseLogsErrorCode LogsErrorCode
        {
            get
            {
                if (Result?.Error == null)
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
                    //explicitly instantiate to fix bug where unity strips out LogsErrorData because it thinks it's not used
                    //see https://community.playfab.com/comments/60164/view.html
                    var logsErrorData = new LogsErrorData();
                    logsErrorData = serializer.DeserializeObject<LogsErrorData>(Result.Logs.Last().Data.ToString());
                    return logsErrorData.ErrorCode;
                }
                catch (Exception)
                {
                    // ignored
                }

                return PlayFabCloudScriptResponseLogsErrorCode.Unknown; 
            }
        }

        /// <summary>
        /// Converts a <see cref="PlayFabError"/> to a <see cref="PlayFabCloudScriptResponse"/> with <see cref="LogsErrorData"/>
        /// <remarks>This can be useful when relying on <see cref="LogsErrorCode"/> to check cloud scripts errors</remarks>
        /// </summary>
        /// <param name="playFabError">The PlayFabError to convert</param>
        /// <typeparam name="T">The type of reponse we will return, doesn't do much but can be nice for easily returning same return type</typeparam>
        /// <returns>A "success" cloud script response marked with a "ContainsError" from <see cref="LogsErrorCode"/></returns>
        public static PlayFabCloudScriptResponse<T> ConvertToLogsError<T>(PlayFabError playFabError)
        {
            //prefer this so we are using all PlayFab json deserialization
            var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var errorCode = PlayFabCloudScriptResponseLogsErrorCode.Unknown;
            try
            {
                errorCode = (PlayFabCloudScriptResponseLogsErrorCode)(int)playFabError.Error;
            }
            catch (Exception e)
            {
                Debug.LogError(
                    "ConvertToLogsError tried to convert PlayFabErrorCode to PlayFabCloudScriptResponseLogsErrorCode and failed. Unknown error will be used.");
            }
            var logsErrorData = new LogsErrorData
            {
                ErrorCode = errorCode,
                ErrorMessage = playFabError.ErrorMessage
            };
            return new PlayFabCloudScriptResponse<T>(new ExecuteCloudScriptResult
            {
                Error = new ScriptExecutionError
                {
                    Error = "ConvertToLogsError",
                    Message = $"This error was generated by PlayFabCloudScriptResponse.ConvertToLogsError."
                },
                Logs = new List<LogStatement>
                {
                    new LogStatement
                    {
                        Data = serializer.SerializeObject(logsErrorData),
                        Level = "Error",
                        Message = playFabError.ErrorMessage
                    }
                }
            }, null);
        }
    }
    
    public class PlayFabCloudScriptResponse<T> : PlayFabCloudScriptResponse
    {
        private T functionResult;
        
        public PlayFabCloudScriptResponse(ExecuteCloudScriptResult result, PlayFabError error) : base(result, error)
        {
            try
            {
                functionResult = (T)result?.FunctionResult;
            }
            catch (Exception)
            {
                functionResult = default;
            }
        }

        public T FunctionResult
        {
            get { return functionResult; }
        }
    }
    
    /// <summary>
    /// Allows us to map a cloud script error code using log.error(message,object errorCodeDataObject)
    /// <remarks>
    /// PlayFab ErrorCodes = 1 - 19999 (Should directly map to <see cref="PlayFabErrorCode"/>.<br/>
    /// Custom error codes = -1 and 20000+.
    /// </remarks>
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
        AccountNotFound = 1001,
        UsersAlreadyFriends = 1183,
        //--- Our error codes below ---
        PlayerStatsNotFoundForLeaderboard = 20001,
        LeaderboardEmpty = 20002
    }

    /// <summary>
    /// Represents the additional error data our log contains if any
    /// </summary>
    public class LogsErrorData
    {
        public PlayFabCloudScriptResponseLogsErrorCode ErrorCode;
        public string ErrorMessage;
    }
}
using PlayFab;
using PlayFab.SharedModels;

namespace ThomasBrown.PlayFab
{
    /// <summary>
    /// A <see cref="PlayFabResponse{T}"/> where the result is of type <see cref="PlayFabResultCommon"/>
    /// </summary>
    /// <typeparam name="T">The type of response</typeparam>
    public class PlayFabCommonResponse<T> : PlayFabResponse<T> where T : PlayFabResultCommon
    {
        public PlayFabCommonResponse(T result, PlayFabError error) : base(result, error)
        {
            
        }
    }
}
using PlayFab;

namespace ThomasBrown.PlayFab
{
    /// <summary>
    /// Data wrapper for a response coming from <see cref="PlayFab"/> server. Used extensively with async await
    /// </summary>
    /// <typeparam name="T">The type of result that will be returned</typeparam>
    public class PlayFabResponse<T>
    {
        public PlayFabResponse(T result, PlayFabError error)
        {
            Result = result;
            Error = error;
        }

        /// <summary>
        /// The result of the async server call
        /// </summary>
        public T Result { get; }
        
        /// <summary>
        /// The error of the async server call
        /// </summary>
        public PlayFabError Error { get; }

        /// <summary>
        /// Returns true if <see cref="Error"/> == null, false otherwise
        /// </summary>
        public virtual bool ContainsError
        {
            get { return Error != null; }
        }
    }
}
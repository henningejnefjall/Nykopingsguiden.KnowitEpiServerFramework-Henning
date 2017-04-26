namespace Knowit.EpiserverFramework.Utilities.DotNetFramework
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string is not null or empty
        /// </summary>
        /// <param name="text">String to check</param>
        /// <returns>True if not null or empty</returns>
        public static bool IsNotNullOrEmpty(this string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
}

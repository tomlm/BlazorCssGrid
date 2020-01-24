namespace RazorCssGrid
{
    public class Scrollbar
    {
        /// <summary>
        ///  The overflow is clipped, and the rest of the content will be invisible
        /// </summary>
        public const string None = "hidden";

        /// <summary>
        /// The overflow is clipped, and a scrollbar is added to see the rest of the content
        /// </summary>
        public const string Show = "scroll";

        /// <summary>
        /// Adds scrollbar only when necessary
        /// </summary>
        public const string Auto = "auto";
    }
}

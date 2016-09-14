namespace BringSharp.Details
{
    public struct Product
    {
        /// <summary>
        /// Gets the products name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Gets the products code
        /// </summary>
        public readonly string Code;

        public Product(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
namespace NStruct.IoC
{
    /// <summary>
    /// The container holder
    /// </summary>
    public static class ContainerHolder
    {
        /// <summary>
        /// Gets the current container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static Container CurrentContainer { get; internal set; }
    }
}

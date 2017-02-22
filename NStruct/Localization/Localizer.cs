namespace NStruct.Localization
{
    /// <summary>
    /// Delegate Localizer
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="args">The arguments.</param>
    /// <returns>LocalizedString.</returns>
    public delegate LocalizedString Localizer(string text, params object[] args);
}

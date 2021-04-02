namespace AutoBet.Domain.Enums
{
    /// <summary>
    /// Contains the possible certificate types using throught the application.
    /// </summary>
    public enum AppCertificates
    {
        /// <summary>
        /// The certificate required to authenticate users in the betfair api with the Non-Interactive auth mode.
        /// <para>
        /// This authentication mode allows the app to make automated calls without requiring user interference in the betfair api.
        /// </para>
        /// </summary>
        BetfairNonInteractiveAuthCertificate
    }
}

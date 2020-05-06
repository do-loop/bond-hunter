namespace BondHunter.Objects
{
    using Responses;

    public sealed class HunterData
    {
        public int RemainingRequests { get; set; }

        public int LimitExpirationInSeconds { get; set; }

        public HunterResponse Response { get; set; }
    }
}
namespace BondHunter.Objects.Enums
{
    using System.Runtime.Serialization;

    public enum HunterStatus
    {
        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "fail")]
        Failure
    }
}
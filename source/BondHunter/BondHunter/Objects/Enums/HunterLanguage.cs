namespace BondHunter.Objects.Enums
{
    using System.Runtime.Serialization;

    public enum HunterLanguage
    {
        [EnumMember(Value = "en")]
        English,

        [EnumMember(Value = "de")]
        German,

        [EnumMember(Value = "es")]
        Spanish,

        [EnumMember(Value = "pt-BR")]
        Portuguese,

        [EnumMember(Value = "fr")]
        French,

        [EnumMember(Value = "ja")]
        Japanese,

        [EnumMember(Value = "zh-CN")]
        Chinese,

        [EnumMember(Value = "ru")]
        Russian
    }
}
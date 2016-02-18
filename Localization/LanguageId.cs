using System;

namespace Meringue
{

/// <summary>
/// Identifier for languages, wrapper of an IETF Language Tag.
/// </summary>
/// <remarks>
/// Immutable.
/// Equality and comparison are based on the tag string, case-insensitive.
/// </remarks>
public class LanguageId : CaseInsensitiveString< LanguageId >
{
    /// <summary>
    /// Should be an IETF Language Tag.
    /// </summary>
    public string tag { get { return m_value; }}
    

    /// <summary>
    /// Create by an IETF Language Tag.
    /// </summary>
    /// <remarks>
    /// <c>langTag</c> should be an IETF Language Tag. But Meringue would not validate it.
    /// </remarks>
    public LanguageId( string langTag )
        : base( langTag )
    {}


    // Predicates //

    public bool isUndefined
    {
        get { return m_value == LanguageTag.Xx; }
    }

    public bool isKindOfChinese
    {
        get { return m_value.StartsWith( LanguageTag.Zh, StringComparison.OrdinalIgnoreCase ); }
    }


    // Common Language Ids //

    public static LanguageId English { get { return new LanguageId( LanguageTag.En ); }}
    public static LanguageId Chinese { get { return new LanguageId( LanguageTag.Zh ); }}

    // Chinese, by script style
    public static LanguageId TraditionalChinese { get { return new LanguageId( LanguageTag.ZhHant ); }}
    public static LanguageId SimplifiedChinese  { get { return new LanguageId( LanguageTag.ZhHant ); }}

    // Chinese, by region
    public static LanguageId ChineseTaiwan   { get { return new LanguageId( LanguageTag.ZhTw ); }}
    public static LanguageId ChineseHongKong { get { return new LanguageId( LanguageTag.ZhHk ); }}
    public static LanguageId ChineseChina    { get { return new LanguageId( LanguageTag.ZhCn ); }}

    // Initial value of variables
    public static LanguageId Undefined { get { return new LanguageId( LanguageTag.Xx ); }}
}


/// <summary>
/// Predefined IETF Language Tag.
/// </summary>
/// <remarks>
/// Here provides a series of language tags for Chinese languages, since they are complex in modern usage.
/// </remarks>
public class LanguageTag
{
    public static readonly string En = "en";    // English

    public static readonly string Zh = "zh";    // Chinese

    // Chinese, by script style
    public static readonly string ZhHant = "zh-Hant";   // Traditional Chinese
    public static readonly string ZhHans = "zh-Hans";   // Simplified Chinese

    // Chinese, by region
    public static readonly string ZhTw = "zh-TW";   // Chinese in Taiwan
    public static readonly string ZhHk = "zh-HK";   // Chinese in Hong Kong
    public static readonly string ZhCn = "zh-CN";   // Chinese in China

    // Special value means undefined, used as an initial value of variables.
    public static readonly string Xx = "xx";
}


}  // namespace Meringue


namespace Meringue
{

/// <summary>
/// Case-insensitive string
/// </summary>
/// A simple implementation of CaseInsensitive< Derived >.
/// For a more complicate example, see Meringue.LanguageId .
public class CaseInsensitiveString : CaseInsensitive< CaseInsensitiveString >
{
    public CaseInsensitiveString()
    {}

    public CaseInsensitiveString( string value )
        : base( value )
    {}
}


}  // namespace Meringue

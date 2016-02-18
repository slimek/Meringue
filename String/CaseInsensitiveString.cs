using System;


namespace Meringue
{

/// <summary>
/// Case-insensitive string wrapper.
/// </summary>
/// <typeparam name="T">The derived class.</typeparam>
public class CaseInsensitiveString< T > : IComparable< T > where T : CaseInsensitiveString< T >
{
    protected string m_value;

    public string value { get { return m_value; }}


    // Constructor //

    public CaseInsensitiveString()
    {
        m_value = "";
    }

    public CaseInsensitiveString( string value )
    {
        m_value = value;
    }


    // Equality and Comparisons //

    public override bool Equals( object obj )
    {
        var derived = obj as T;
        if ( (object)derived == null ) { return false; }

        return this.Equals( derived );
    }

    public bool Equals( CaseInsensitiveString< T > other )
    {
        if ( (object)other == null ) { return false; }

        return m_value.Equals( other.m_value, StringComparison.OrdinalIgnoreCase );
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode( m_value );
    }

    public static bool operator ==( CaseInsensitiveString< T > lhs, CaseInsensitiveString< T > rhs )
    {
        if ( Object.ReferenceEquals( lhs, rhs )) { return true; }

        if ( (object)lhs == null ) { return false; }

        return lhs.Equals( rhs );
    }

    public static bool operator !=( CaseInsensitiveString< T > lhs, CaseInsensitiveString< T > rhs )
    {
        return !( lhs == rhs );
    }

    public int CompareTo( T other )
    {
        return String.Compare( m_value, other.m_value, true );  // true: ignore case.
    }
}


}  // namespace Meringue

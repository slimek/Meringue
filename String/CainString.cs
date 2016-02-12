using System;


namespace Meringue
{

/// <summary>
/// Case-insensitive string wrapper.
/// </summary>
/// <typeparam name="T">The derived class.</typeparam>
public class CainString< T > : IComparable< T > where T : CainString< T >
{
    protected string m_value;

    public string value { get { return m_value; }}


    // Constructor //

    public CainString()
    {
        m_value = "";
    }

    public CainString( string value )
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

    public bool Equals( CainString< T > other )
    {
        if ( (object)other == null ) { return false; }

        return m_value.Equals( other.m_value, StringComparison.OrdinalIgnoreCase );
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode( m_value );
    }

    public static bool operator ==( CainString< T > lhs, CainString< T > rhs )
    {
        if ( Object.ReferenceEquals( lhs, rhs )) { return true; }

        if ( (object)lhs == null ) { return false; }

        return lhs.Equals( rhs );
    }

    public static bool operator !=( CainString< T > lhs, CainString< T > rhs )
    {
        return !( lhs == rhs );
    }

    public int CompareTo( T other )
    {
        return String.Compare( m_value, other.m_value, true );  // true: ignore case.
    }
}


}  // namespace Meringue

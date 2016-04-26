using System;


namespace Meringue
{

/// <summary>
/// Case-insensitive string base class
/// </summary>
/// Provide equality and comparison operators which only can be used by the derived class.
/// Immutable.
/// 'Derived' should be the derived class itself.
public class CaseInsensitive< Derived > : IComparable 
                                        , IEquatable< Derived >
                                        , IComparable< Derived >
                                    where Derived : CaseInsensitive< Derived >
{
    // Fields //

    protected string m_value;


    // Constructors //

    public CaseInsensitive()
    {
        m_value = "";
    }

    public CaseInsensitive( string value )
    {
        m_value = value;
    }


    // Properties //

    public string value { get { return m_value; } }


    // Method - Equality //

    public override bool Equals( object obj )
    {
        var derived = obj as Derived;
        if ( (object)derived == null ) { return false; }

        return this.Equals( derived );
    }

    public bool Equals( Derived other )
    {
        if ( (object)other == null ) { return false; }

        return m_value.Equals( other.m_value, StringComparison.OrdinalIgnoreCase );
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode( m_value );
    }

    public static bool operator ==( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        if ( object.ReferenceEquals( lhs, rhs )) { return true; }

        if ( (object)lhs == null ) { return false; }

        return lhs.Equals( rhs );
    }

    public static bool operator !=( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        return !( lhs == rhs );
    }


    // Method - Comparisons //

    public int CompareTo( object obj )
    {
        if ( obj == null ) { return 1; }

        var derived = obj as Derived;
        if ( (object)derived == null )
        {
            throw new ArgumentException( "Not a " + typeof( Derived ).Name );
        }

        return this.CompareTo( derived );
    }
    
    public int CompareTo( Derived other )
    {
        if ( (object)other == null ) { return 1; }

        return String.Compare( m_value, other.m_value, true );  // true implies case insensitive
    }

    public static int Compare( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        if ( object.ReferenceEquals( lhs, rhs )) { return 0; }

        if ( (object)lhs == null ) { return -1; }

        return lhs.CompareTo( rhs );
    }

    public static bool operator <( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        return Compare( lhs, rhs ) < 0;
    }

    public static bool operator >( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        return Compare( lhs, rhs ) > 0;
    }

    public static bool operator <=( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        return Compare( lhs, rhs ) <= 0;
    }

    public static bool operator >=( CaseInsensitive< Derived > lhs, CaseInsensitive< Derived > rhs )
    {
        return Compare( lhs, rhs ) >= 0;
    }


    // Method - Others //

    public override string ToString()
    {
        return m_value;
    }
}


}  // namespace Meringue

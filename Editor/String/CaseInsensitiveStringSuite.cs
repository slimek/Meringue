using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable 1718  // x == x


namespace Meringue
{

class CainText : CaseInsensitiveString< CainText >
{
    public CainText() {}

    public CainText( string value )
        : base( value )
    {}
}


public class CainStringSuite
{
    [Test]
    public void CainStringTest()
    {
        var empty = new CainText();
        var alice = new CainText( "Alice" );
        var lower = new CainText( "alice" );
        var upper = new CainText( "ALICE" );
        var camel = new CainText( "Alice" );
        var reimu = new CainText( "Reimu" );

        
        // Values //

        Assert.AreEqual( "", empty.value );
        Assert.AreEqual( "Alice", alice.value );
        Assert.AreEqual( "ALICE", upper.value );


        // Equality //

        // X == X
        Assert.True( alice.Equals( alice ));
        Assert.True( alice == alice );
        Assert.False( alice != alice );
        Assert.True( alice.GetHashCode() == alice.GetHashCode() );

        // X == Y
        Assert.True( alice == camel );
        Assert.True( alice != reimu );
        Assert.True( alice.GetHashCode() == camel.GetHashCode() );

        // X == Y, case insensitive
        Assert.True( alice == lower );
        Assert.True( alice == upper );
        Assert.True( lower == upper );
        Assert.True( lower.GetHashCode() == upper.GetHashCode() );

        // X == ref( X )
        var reffer = alice;
        Assert.True( reffer == alice );
        Assert.True( reffer.GetHashCode() == alice.GetHashCode() );

        // Compare to null
        CainText nullA = null;
        CainText nullB = null;
        Assert.False( alice.Equals( null ));
        Assert.False( alice == null );
        Assert.False( null == alice );
        Assert.False( alice == nullA );
        Assert.True( nullA == nullB );

        
        // Comparerions //

        var set = new HashSet< CainText >();

        Assert.True( set.Add( alice ));
        Assert.True( set.Add( reimu ));

        // key collided
        Assert.False( set.Add( alice ));
        Assert.False( set.Add( upper ));
        Assert.False( set.Add( lower ));

        Assert.True( set.Contains( reimu ));
        Assert.True( set.Contains( alice ));
        Assert.False( set.Contains( new CainText( "Marisa" )));

        // case insensitive
        Assert.True( set.Contains( upper ));
        Assert.True( set.Contains( lower ));
        

        var list = new List< CainText >();

        list.Add( reimu );
        list.Add( empty );
        list.Add( alice );

        list.Sort();

        Assert.True( list[0] == empty );
        Assert.True( list[1] == alice );
        Assert.True( list[2] == reimu );
    }
}


}  // namespace Meringue

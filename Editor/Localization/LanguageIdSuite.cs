using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable 1718  // x == x


namespace Meringue
{

public class LanguageIdSuite
{
    [Test]
    public void LanguageIdTest()
    {
        var undef = LanguageId.Undefined;
        var english = LanguageId.English;
        var chinese = LanguageId.Chinese;
        var camelEn = new LanguageId( "En" );
        var upperEn = new LanguageId( "EN" );
        var lowerEn = new LanguageId( "en" );


        // Values //

        Assert.AreEqual( english.tag, LanguageTag.En );
        Assert.AreEqual( chinese.tag, LanguageTag.Zh );
        Assert.AreEqual( undef.tag, LanguageTag.Xx );


        // Equality //

        // X == X
        Assert.True( english.Equals( english ));
        Assert.True( english == english );
        Assert.False( english != english );
        Assert.True( english.GetHashCode() == english.GetHashCode() );

        // X == Y
        Assert.True( english == camelEn );
        Assert.True( english != chinese );
        Assert.True( english.GetHashCode() == camelEn.GetHashCode() );

        // X == Y, case insensitive
        Assert.True( english == lowerEn );
        Assert.True( english == upperEn );
        Assert.True( lowerEn == upperEn );
        Assert.True( lowerEn.GetHashCode() == upperEn.GetHashCode() );

        // X == ref( X )
        var refEn = english;
        Assert.True( english == refEn );
        Assert.True( english.GetHashCode() == refEn.GetHashCode() );

        // Compare to null
        LanguageId nullA = null;
        LanguageId nullB = null;
        Assert.False( english.Equals( null ));
        Assert.False( english == null );
        Assert.False( null == english );
        Assert.False( english == nullA );
        Assert.True( nullA == nullB );


        // Comparisons //

        var set = new HashSet< LanguageId >();

        Assert.True( set.Add( english ));
        Assert.True( set.Add( chinese ));

        // key collided
        Assert.False( set.Add( english ));
        Assert.False( set.Add( upperEn ));
        Assert.False( set.Add( lowerEn ));

        Assert.True( set.Contains( english ));
        Assert.True( set.Contains( chinese ));
        Assert.False( set.Contains( new LanguageId( "de" )));

        // case insensitive
        Assert.True( set.Contains( upperEn ));
        Assert.True( set.Contains( lowerEn ));


        var list = new List< LanguageId >();

        list.Add( english );
        list.Add( chinese );
        list.Add( undef );

        list.Sort();

        Assert.True( list[0] == english );
        Assert.True( list[1] == undef );
        Assert.True( list[2] == chinese );
    }


    [Test]
    public void LanguageIdPredicateTest()
    {
        Assert.False( LanguageId.English.isKindOfChinese );
        Assert.False( LanguageId.Undefined.isKindOfChinese );
        Assert.True( LanguageId.Chinese.isKindOfChinese );
        Assert.True( LanguageId.TraditionalChinese.isKindOfChinese );
        Assert.True( LanguageId.SimplifiedChinese.isKindOfChinese );
        Assert.True( LanguageId.ChineseTaiwan.isKindOfChinese );
        Assert.True( LanguageId.ChineseHongKong.isKindOfChinese );
        Assert.True( LanguageId.ChineseChina.isKindOfChinese );

        Assert.False( LanguageId.English.isUndefined );
        Assert.False( LanguageId.Chinese.isUndefined );
        Assert.True( LanguageId.Undefined.isUndefined );

        // Runtime created

        var german = new LanguageId( "de" );
        var zhMalay = new LanguageId( "ZH-MY" );  // case insensitive

        Assert.False( german.isKindOfChinese );
        Assert.True( zhMalay.isKindOfChinese );

        Assert.False( german.isUndefined );
        Assert.False( german.isUndefined );
    }
}


}  // namespace Meringue

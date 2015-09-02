using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    public struct ValidDocumentationStruct1
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    protected struct ValidDocumentationStruct2
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    internal struct ValidDocumentationStruct3
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    internal protected struct ValidDocumentationStruct4
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    protected internal struct ValidDocumentationStruct5
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    private struct ValidDocumentationStruct6
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    public static struct ValidDocumentationStruct7
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    public sealed struct ValidDocumentationStruct8
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    public unsafe struct ValidDocumentationStruct9
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    public struct ValidDocumentationStruct10 : List<int>, IList
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public struct ValidDocumentationStruct11<S, T>
    {
    }

    /// <summary>This is the summary for the struct.</summary><typeparam name="S">This is the first generic parameter.</typeparam><typeparam name="T">This is the second generic parameter.</typeparam>
    public struct ValidDocumentationStruct12<S, T>
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public struct ValidDocumentationStruct13<S, T> where T : int where S : string
    {
    }

    /// <summary>
    /// This is the summary for the struct.
    /// </summary>
    /// <remarks>Adding a remarks tag.</remarks>
    public struct ValidDocumentationStruct14
    {
    }

    /// <content>
    /// The partial struct uses a content tag.
    /// </content>
    public partial struct ValidDocumentationStruct15
    {
    }

    /// <summary>
    /// The partial struct uses a summary tag.
    /// </summary>
    public partial struct ValidDocumentationStruct16
    {
    }

    /// <summary>
    /// Summary description for struct.
    /// </summary>
    public struct InvalidDocumentationStruct1
    {
    }

    /// <summary>
    /// This struct's xml is invalid. The closing tag is ill-formed.
    /// /summary>
    public struct InvalidDocumentationStruct2
    {
    }

    public struct InvalidDocumentationStruct3
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public struct InvalidDocumentationStruct4
    {
    }

    /// <summary>
    /// Nospaceshereatall.
    /// </summary>
    public struct InvalidDocumentationStruct5
    {
    }

    /// <summary>
    /// Short.
    /// </summary>
    public struct InvalidDocumentationStruct6
    {
    }

    /// <summary>
    /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
    /// </summary>
    public struct InvalidDocumentationStruct7
    {
    }

    /// <summary>
    /// no capital letter.
    /// </summary>
    public struct InvalidDocumentationStruct8
    {
    }

    /// <summary>
    /// No closing period
    /// </summary>
    public struct InvalidDocumentationStruct9
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    public struct InvalidDocumentationStruct10<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct InvalidDocumentationStruct11<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">Nospaceshereatall.</typeparam>
    public struct InvalidDocumentationStruct12<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">Short.</typeparam>
    public struct InvalidDocumentationStruct13<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</typeparam>
    public struct InvalidDocumentationStruct14<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">no capital letter.</typeparam>
    public struct InvalidDocumentationStruct15<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">No closing period</typeparam>
    public struct InvalidDocumentationStruct16<T>
    {
    }

    /// <summary>
    /// This line is copied.
    /// </summary>
    /// <typeparam name="T">This line is copied.</typeparam>
    /// <typeparam name="S">This is the second type param.</typeparam>
    public struct InvalidDocumentationStruct17<T, S>
    {
    }

    /// <summary>
    /// This line is copied.
    /// </summary>
    /// <typeparam name="T">This is the first type param.</typeparam>
    /// <typeparam name="S">This line is copied.</typeparam>
    public struct InvalidDocumentationStruct18<T, S>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This line is copied.</typeparam>
    /// <typeparam name="S">This line is copied.</typeparam>
    public struct InvalidDocumentationStruct19<T, S>
    {
    }

    /// <summary>
    /// The parameters are in the wrong order.
    /// </summary>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="T">This is the first param.</typeparam>
    public struct InvalidDocumentationStruct20<T, S> 
    {
    }

    /// <summary>
    /// Typeparam tag is missing name attribute.
    /// </summary>
    /// <typeparam>This is the first param.</typeparam>
    public struct InvalidDocumentationStruct21<T>
    {
    }

    /// <summary>
    /// Typeparam tag is missing name attribute.
    /// </summary>
    /// <typeparam name="">This is the first param.</typeparam>
    public struct InvalidDocumentationStruct22<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="S">This is the wrong type param.</typeparam>
    public struct InvalidDocumentationStruct23<T>
    {
    }

    internal struct InvalidDocumentationStruct24
    {
    }

    protected struct InvalidDocumentationStruct25
    {
    }

    private struct InvalidDocumentationStruct26
    {
    }

    protected internal struct InvalidDocumentationStruct27
    {
    }

    internal protected struct InvalidDocumentationStruct28
    {
    }

    internal static struct InvalidDocumentationStruct29
    {
    }

    public sealed struct InvalidDocumentationStruct30
    {
    }

    /////// <summary>
    /////// This is the summary.
    /////// </summary>
    /////// <remarks></remarks>
    ////public struct InvalidDocumentationStruct31
    ////{
    ////}

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="W">This is the third param.</typeparam>
    internal struct InvalidDocumentationStruct32<T, S>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam>This is the third param.</typeparam>
    internal struct InvalidDocumentationStruct33<T, S>
    {
    }

    /// <summary>
    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="">This is the third param.</typeparam>
    internal struct InvalidDocumentationStruct34<T, S>
    {
    }

    /// <content>
    /// The struct is not partial, yet it uses a content tag rather than a summary tag.
    /// </content>
    public struct InvalidDocumentationStruct35
    {
    }

    public partial struct InvalidDocumentationStruct36
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public partial struct InvalidDocumentationStruct37
    {
    }

    /// <remarks>These are some remarks.</remarks>
    public partial struct InvalidDocumentationStruct38
    {
    }

    /// <summary>
    /// The typeparam tag are missing from this partial item.
    /// </summary>
    public partial struct InvalidDocumentationStruct39<T>
    {
    }

    /// <summary>
    /// The typeparam tag is missing for the W param.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    public struct InvalidDocumentationStruct40<T, S, W>
    {
    }
}

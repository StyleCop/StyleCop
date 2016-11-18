using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    public interface ValidDocumentationInterface1
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    protected interface ValidDocumentationInterface2
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    internal interface ValidDocumentationInterface3
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    internal protected interface ValidDocumentationInterface4
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    protected internal interface ValidDocumentationInterface5
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    private interface ValidDocumentationInterface6
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    public static interface ValidDocumentationInterface7
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    public sealed interface ValidDocumentationInterface8
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    public unsafe interface ValidDocumentationInterface9
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    public interface ValidDocumentationInterface10 : List<int>, IList
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public interface ValidDocumentationInterface11<S, T>
    {
    }

    /// <summary>This is the summary for the interface.</summary><typeparam name="S">This is the first generic parameter.</typeparam><typeparam name="T">This is the second generic parameter.</typeparam>
    public interface ValidDocumentationInterface12<S, T>
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public interface ValidDocumentationInterface13<S, T> where T : int where S : string
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    /// <remarks>Adding a remarks tag.</remarks>
    public interface ValidDocumentationInterface14
    {
    }

    /// <content>
    /// The partial interface uses a content tag.
    /// </content>
    public partial interface ValidDocumentationInterface15
    {
    }

    /// <summary>
    /// The partial interface uses a summary tag.
    /// </summary>
    public partial interface ValidDocumentationInterface16
    {
    }

    /// <summary>
    /// Summary description for interface.
    /// </summary>
    public interface InvalidDocumentationInterface1
    {
    }

    /// <summary>
    /// This interface's xml is invalid. The closing tag is ill-formed.
    /// /summary>
    public interface InvalidDocumentationInterface2
    {
    }

    public interface InvalidDocumentationInterface3
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public interface InvalidDocumentationInterface4
    {
    }

    /// <summary>
    /// Nospaceshereatall.
    /// </summary>
    public interface InvalidDocumentationInterface5
    {
    }

    /// <summary>
    /// Short.
    /// </summary>
    public interface InvalidDocumentationInterface6
    {
    }

    /// <summary>
    /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
    /// </summary>
    public interface InvalidDocumentationInterface7
    {
    }

    /// <summary>
    /// no capital letter.
    /// </summary>
    public interface InvalidDocumentationInterface8
    {
    }

    /// <summary>
    /// No closing period
    /// </summary>
    public interface InvalidDocumentationInterface9
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    public interface InvalidDocumentationInterface10<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface InvalidDocumentationInterface11<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">Nospaceshereatall.</typeparam>
    public interface InvalidDocumentationInterface12<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">Short.</typeparam>
    public interface InvalidDocumentationInterface13<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</typeparam>
    public interface InvalidDocumentationInterface14<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">no capital letter.</typeparam>
    public interface InvalidDocumentationInterface15<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">No closing period</typeparam>
    public interface InvalidDocumentationInterface16<T>
    {
    }

    /// <summary>
    /// This line is copied.
    /// </summary>
    /// <typeparam name="T">This line is copied.</typeparam>
    /// <typeparam name="S">This is the second type param.</typeparam>
    public interface InvalidDocumentationInterface17<T, S>
    {
    }

    /// <summary>
    /// This line is copied.
    /// </summary>
    /// <typeparam name="T">This is the first type param.</typeparam>
    /// <typeparam name="S">This line is copied.</typeparam>
    public interface InvalidDocumentationInterface18<T, S>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This line is copied.</typeparam>
    /// <typeparam name="S">This line is copied.</typeparam>
    public interface InvalidDocumentationInterface19<T, S>
    {
    }

    /// <summary>
    /// The parameters are in the wrong order.
    /// </summary>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="T">This is the first param.</typeparam>
    public interface InvalidDocumentationInterface20<T, S>
    {
    }

    /// <summary>
    /// Typeparam tag is missing name attribute.
    /// </summary>
    /// <typeparam>This is the first param.</typeparam>
    public interface InvalidDocumentationInterface21<T>
    {
    }

    /// <summary>
    /// Typeparam tag is missing name attribute.
    /// </summary>
    /// <typeparam name="">This is the first param.</typeparam>
    public interface InvalidDocumentationInterface22<T>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="S">This is the wrong type param.</typeparam>
    public interface InvalidDocumentationInterface23<T>
    {
    }

    internal interface InvalidDocumentationInterface24
    {
    }

    protected interface InvalidDocumentationInterface25
    {
    }

    private interface InvalidDocumentationInterface26
    {
    }

    protected internal interface InvalidDocumentationInterface27
    {
    }

    internal protected interface InvalidDocumentationInterface28
    {
    }

    internal static interface InvalidDocumentationInterface29
    {
    }

    public sealed interface InvalidDocumentationInterface30
    {
    }

    /////// <summary>
    /////// This is the summary.
    /////// </summary>
    /////// <remarks></remarks>
    ////public interface InvalidDocumentationInterface31
    ////{
    ////}

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="W">This is the third param.</typeparam>
    internal interface InvalidDocumentationInterface32<T, S>
    {
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam>This is the third param.</typeparam>
    internal interface InvalidDocumentationInterface33<T, S>
    {
    }

    /// <summary>
    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    /// <typeparam name="">This is the third param.</typeparam>
    internal interface InvalidDocumentationInterface34<T, S>
    {
    }

    /// <content>
    /// The interface is not partial, yet it uses a content tag rather than a summary tag.
    /// </content>
    public interface InvalidDocumentationInterface35
    {
    }

    public partial interface InvalidDocumentationInterface36
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public partial interface InvalidDocumentationInterface37
    {
    }

    /// <remarks>These are some remarks.</remarks>
    public partial interface InvalidDocumentationInterface38
    {
    }

    /// <summary>
    /// The typeparam tag are missing from this partial item.
    /// </summary>
    public partial interface InvalidDocumentationInterface39<T>
    {
    }

    /// <summary>
    /// The typeparam tag is missing for the W param.
    /// </summary>
    /// <typeparam name="T">This is the first param.</typeparam>
    /// <typeparam name="S">This is the second param.</typeparam>
    public interface InvalidDocumentationInterface40<T, S, W>
    {
    }

    /// <summary>
    /// This is the summary for the interface.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the second generic parameter.</typeparam>
    public interface ValidDocumentationInterface11<S, T>
    {
    }

    /// <summary>
    /// This is a summary for the interface.
    /// </summary>
    /// <typeparam name="T">This is the first generic parameter.</typeparam>
    public interface ValidCovariantInterface<out T>
    {
    }

    /// <summary>
    /// This is a summary for the interface.
    /// </summary>
    /// <typeparam name="T">This is the first generic parameter.</typeparam>
    public interface ValidContravariantInterface<in T>
    {
    }

    /// <summary>
    /// This is a summary for the interface.
    /// </summary>
    /// <typeparam name="S">This is the first generic parameter.</typeparam>
    /// <typeparam name="T">This is the first second parameter.</typeparam>
    public interface ValidCovariantContravariantInterface<out S, in T>
    {
    }

    /// <summary>
    /// This is a summary for the interface.
    /// </summary>
    public interface InvalidCovariantInterface<out T>
    {
    }

    /// <summary>
    /// This is a summary for the interface.
    /// </summary>
    public interface InvalidContravariantInterface<in T>
    {
    }

    /// <summary>
    /// This is a summary for the interface.
    /// </summary>
    /// <typeparam name="S">This is the first second parameter.</typeparam>
    public interface InvalidCovariantContravariantInterface<out S, in T>
    {
    }
}

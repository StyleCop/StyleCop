<?xml version="1.0"?>
<doc>
    <assembly>
        <name>Microsoft.VisualStudio.Modeling.Sdk</name>
    </assembly>
    <members>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagrams.HslColor">
            <summary>
            HueSatLumColor represents colors by their Hue-Saturation-Luminosity value rather than
            the traditional RGB value.  This class provides conversion methods to go back and
            forth between the HSL and RGB color spaces.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.#ctor(System.Int32,System.Int32,System.Int32)">
            <summary>
            Creates instance of the class with the specified hue, saturation, and luminosity.
            </summary>
            <param name="hue">starting hue value.</param>
            <param name="saturation">starting saturation value.</param>
            <param name="luminosity">starting luminosity value.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.#ctor">
            <summary>
            Default constructor creates an empty instance of the class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.ToRgbColor">
            <summary>
            Converts an HSL color representation to an RGB color representation.
            The algorithm implemented is from the following KnowledgeBase article:
            http://support.microsoft.com/default.aspx?scid=kb%3ben-us%3b29240, and 
            from "Computer Graphics: Principles and Practices" by Foley, vanDam, et.al.,
            pp. 592-596.
            </summary>
            <returns>The converted color in System.Drawing.Color format.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.HueToRgb(System.Int32,System.Int32,System.Int32)">
            <summary>
            Internal method which given the calculated magic numbers and the hue,
            will calculate the appropriate RGB number.
            </summary>
            <param name="m1">first calculated lum/sat mixed value.</param>
            <param name="m2">second calculated lum/sat mixed value.</param>
            <param name="hue">specified hue value.</param>
            <returns>The corresponding RGB value for the hue.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.FromRgbColor(System.Drawing.Color)">
            <summary>
            Converts an RGB color representation to an HSL color representation.
            The algorithm implemented is from the following KnowledgeBase article:
            http://support.microsoft.com/default.aspx?scid=kb%3ben-us%3b29240, and 
            from "Computer Graphics: Principles and Practices" by Foley, vanDam, et.al.,
            pp. 592-596.
            </summary>
            <param name="color">RGB color to convert to HSL representation.</param>
            <returns>Returns newly converted HslColor value.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.Hue">
            <summary>
            Gets or sets the Hue property.
            </summary>
            <value>Must be in the range 0 to 240</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.Saturation">
            <summary>
            Gets or sets the Saturation property.
            </summary>
            <value>Must be in the range 0 to 240</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.Luminosity">
            <summary>
            Gets or sets the Luminosity property.
            </summary>
            <value>Must be in the range 0 to 240</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.Black">
            <summary>
            Pre-defined color.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagrams.HslColor.White">
            <summary>
            Pre-defined color.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagrams.HslColorConverter">
            <summary>
            Provides a type converter to convert HslColor objects to and from other representations.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColorConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
            </summary>
            <param name="context">An ITypeDescriptorContext that provides a format context.</param>
            <param name="sourceType">A Type that represents the type you want to convert from.</param>
            <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColorConverter.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            Returns whether this converter can convert the object to the specified type, using the specified context.
            </summary>
            <param name="context">An ITypeDescriptorContext that provides a format context.</param>
            <param name="destinationType">A Type that represents the type you want to convert to.</param>
            <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColorConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)">
            <summary>
            Converts the given object to the type of this converter, using the specified context and culture information.
            </summary>
            <param name="context">An ITypeDescriptorContext that provides a format context.</param>
            <param name="culture">The CultureInfo to use as the current culture.</param>
            <param name="value">The Object to convert.</param>
            <returns>An Object that represents the converted value.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagrams.HslColorConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)">
            <summary>
            Converts the given value object to the specified type, using the specified context and culture information.
            </summary>
            <param name="context">An ITypeDescriptorContext that provides a format context.</param>
            <param name="culture">A CultureInfo object. If a null reference (Nothing in Visual Basic) is passed, the current culture is assumed.</param>
            <param name="value">The Object to convert.</param>
            <param name="destinationType">The Type to convert the value parameter to.</param>
            <returns>An Object that represents the converted value.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer">
            <summary>
            This is the base class for all generated domain serializers. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.ReadRootElement(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Xml.XmlReader,Microsoft.VisualStudio.Modeling.ISchemaResolver)">
            <summary>
            Public ReadRootElement() method that deserializes a root-level element from XML.
            The difference between root-level element and the rest elements in the XML is that the root may carry additional information like schema, version, etc.
            The default implementation just calls Read() method, it's up to the derived implementations to do any additional checks.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="element">In-memory ModelElement instance that will get the deserialized data.</param>
            <param name="reader">XmlReader to read serialized data from.</param>
            <param name="schemaResolver">An ISchemaResolver that allows the serializer to do schema validation on the root element (and everything inside it).</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.WriteRootElement(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Xml.XmlWriter)">
            <summary>
            Public WriteRootElement() method that serializes a root-level element to XML.
            The difference between root-level element and the rest elements in the XML is that the root may carry additional information like schema, version, etc.
            The default implementation just calls Write() method with no RootElementSettings, it's up to the derived implementations to do any additional checks.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="element">ModelElement instance that will be serialized.</param>
            <param name="writer">XmlWriter to write serialized data to.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.Read(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Xml.XmlReader)">
            <summary>
            Public Read() method that deserializes the given ModelElement instance from XML.
            </summary>
            <remarks>
            When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
            of the element that is about to be deserialized. 
            The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
            or the close tag of the parent element (or EOF).
            </remarks>
            <param name="serializationContext">Serialization context.</param>
            <param name="element">In-memory ModelElement instance that will get the deserialized data.</param>
            <param name="reader">XmlReader to read serialized data from.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.Write(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Xml.XmlWriter)">
            <summary>
            Public Write() method that serializes the ModelElement instance associated with this serializer instance into XML. This method just
            calls Write() with no RootElementSettings.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="element">ModelElement instance that will be serialized.</param>
            <param name="writer">XmlWriter to write serialized data to.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.Write(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Xml.XmlWriter,Microsoft.VisualStudio.Modeling.RootElementSettings)">
            <summary>
            Public Write() method that serializes the ModelElement instance associated with this serializer instance into XML.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="element">ModelElement instance that will be serialized.</param>
            <param name="writer">XmlWriter to write serialized data to.</param>
            <param name="rootElementSettings">
            The root element settings if the passed in element is serialized as a root element in the XML. The root element contains additional
            information like schema target namespace, version, etc.
            This should only be passed for root-level elements. Null should be passed for rest elements (and ideally call the Write() method 
            without this parameter).
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.TryCreateInstance(Microsoft.VisualStudio.Modeling.SerializationContext,System.Xml.XmlReader,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            With the given XmlReader, check if it is currently pointing to a serialized ModelElement instance that this serializer can handle. 
            If so, create an instance of the ModelElement in the given Partition; otherwise return NULL.
            Note: The caller will guarantee that the reader is positioned at open XML tag of the element being read. This method should
            not move the reader; the reader should remain at the same position when this method returns.
            </summary>
            <remarks>
            Note: that this method only tries to create the ModelElement instance, without actually deserializing it. The deserialization 
            will be done by the Read() methods. There are two reasons for this separation:
            1) We may need to link the created ModelElement to its parent element (through embedding relationship) before we can deserializing
               it properly.
            2) The deserialization can be customized.
            </remarks>
            <param name="serializationContext">Serialization context.</param>
            <param name="reader">XmlReader to read from.</param>
            <param name="partition">Partition in which the new element will be created.</param>
            <returns>The created ModelElement instance, or null if the reader is not pointing to a correct serialized instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.TryCreateMonikerInstance(Microsoft.VisualStudio.Modeling.SerializationContext,System.Xml.XmlReader,Microsoft.VisualStudio.Modeling.ModelElement,System.Guid,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            With the given XmlReader, check if it is currently pointing to a monikerized instance of a ModelElement that this serializer can 
            handle. If so, create an Moniker instance in the given Store; otherwise return NULL.
            Note: The caller will guarantee that the reader is positioned at open XML tag of the element moniker being read. This method will
            move the reader (unlike TryCreateInstance() method) because it may needs to read the serialized moniker string. If the reader is moved,
            it should be positioned at the closing tag of the element (so that the caller can call SerializationUtilities.SkipToNextElement() to
            move to the next element).
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="reader">XmlReader to read serialized data from.</param>
            <param name="sourceRolePlayer">The source role-player ModelElement from which the moniker being created is referenced.</param>
            <param name="relDomainClassId">The DomainClass Id of the relationship that connects the sourceRolePlayer to the moniker being created.</param>
            <param name="partition">The new Moniker should be created in the Store associated with this partition.</param>	
            <returns>The created moniker, or null if the reader is not pointing to a correct monikerized instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.WriteMoniker(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Xml.XmlWriter,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer)">
            <summary>
            Public WriteMoniker() method that writes a monikerized ModelElement instance into XML.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="element">Element to be monikerized.</param>
            <param name="writer">XmlWriter to write serialized data to.</param>
            <param name="sourceRolePlayer">Source element that references the element to be monikerized.</param>
            <param name="relSerializer">Serializer that handles the relationship connecting the source element to the element being monikerized.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.CalculateQualifiedName(Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            This method calculates a reference to a handled ModelElement instance.
            </summary>
            <param name="directory">Directory to look up serializer based on model element type.</param>
            <param name="element">ModelElement instance to calculate qualified name for.</param>
            <returns>A fully qualified string reference to the ModelElement instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.GetMonikerQualifier(Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            GetMonikerQualifier returns the long form reference to a model element. The long form reference consists of 
            /Qualifier/short form reference. This method calculates the Qualifier, if it exists.
            </summary>
            <param name="directory">Directory to look up serializer based on model element type.</param>
            <param name="element">ModelElement instance to get moniker qualifier from.</param>
            <returns>Value of this element's moniker qualifier property, if it has one, or the value of the container's moniker qualifier property.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.CreateInstance(Microsoft.VisualStudio.Modeling.SerializationContext,System.Xml.XmlReader,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            With the given XmlReader, create an instance of the ModelElement in the given Partition.
            Note: This method is only called by TryCreateInstance() method once it determines the correct ModelElement instance to create.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="reader">XmlReader to read from.</param>
            <param name="partition">Partition in which the new element will be created.</param>
            <returns>The created ModelElement instance, or null if the reader is not pointing to a correct serialized instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.CreateMonikerInstance(Microsoft.VisualStudio.Modeling.SerializationContext,System.Xml.XmlReader,Microsoft.VisualStudio.Modeling.ModelElement,System.Guid,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            With the given XmlReader, create an Moniker instance in the given Store.
            Note: This method is only called by TryCreateMonikerInstance() method once it determines the correct ModelElement moniker to create.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="reader">XmlReader to read serialized data from.</param>
            <param name="sourceRolePlayer">The source role-player ModelElement from which the moniker being created is referenced.</param>
            <param name="relDomainClassId">The DomainClass Id of the relationship that connects the sourceRolePlayer to the moniker being created.</param>
            <param name="partition">The new Moniker should be created in the Store associated with this partition.</param>	
            <returns>The created moniker, or null if the reader is not pointing to a correct monikerized instance.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.XmlTagName">
            <summary>
            Returns the XML tag name that will be used in serialization.
            If a DomainClass cannot be serialized directly (e.g. abstract class, short-form relationship, etc.), emptry string is returned for this property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.MonikerTagName">
            <summary>
            Returns the XML tag name when serializing the handled ModelElement as a moniker. Note that this tag name is different from
            XmlTagName. This one is for writing a moniker, while XmlTagName is for writing the actual instance of the ModelElement. 
            They need to be different tag names so that the associated schema for the serialized XML is not ambiguous.
            An serializer implementation that overrides MonikerAttributeName should also override MonikerTagName.
            The base implementation returns empty string, meaning that the DomainClass cannot be monikerized.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassXmlSerializer.MonikerAttributeName">
            <summary>
            Returns the XML attribute name that contains the moniker string. For example, a DomainClass Foo may have MonikerTagName "FooMoniker", 
            and MonikerAttributeName "ref", then a serialized moniker of Foo will look like &lt;FooMoniker ref="foo1" &gt;.
            An serializer implementation that overrides MonikerTagName should also override MonikerAttributeName.
            The base implementation returns empty string, meaning that the DomainClass cannot be monikerized.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer">
            <summary>
            This is the base class for all generated domain serializers for domain relationships.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer.TryCreateDerivedInstance(Microsoft.VisualStudio.Modeling.SerializationContext,System.Xml.XmlReader,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            With the given XmlReader, check if it is currently pointing to a serialized instance that derives from the ElementLink this serializer can handle. 
            If so, create an instance of the derived ElementLink instance in the given Partition; otherwise return NULL.
            Note: The caller will guarantee that the reader is positioned at open XML tag of the element being read. This method should
            not move the reader; the reader should remain at the same position when this method returns.
            </summary>
            <remarks>
            Note: that this method only tries to create the derived ElementLink instance, without actually deserializing it. The deserialization 
            will be done by the Read() methods. There are two reasons for this separation:
            1) We may need to link the created link to its source role player before we can deserializing it properly.
            2) The deserialization can be customized.
            </remarks>
            <param name="serializationContext">Serialization context.</param>
            <param name="reader">XmlReader to read from.</param>
            <param name="partition">Partition in which the new link will be created.</param>
            <returns>The created ElementLink instance, or null if the reader is not pointing to a correct serialized instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer.MonikerizeReference(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,System.Guid,System.String,Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Calculates a Moniker, given a reference to a ModelElement.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="sourceElement">Source role-player of the relationship.</param>
            <param name="domainClassId">DomainClassId of the model element that the given moniker string will be resolved to.</param>
            <param name="monikerString">Serialized string reference to an instance of the target role-player.</param>
            <param name="store">Store where the Moniker will be created</param>
            <returns>A Moniker encapsulating the serialized string reference of the target role-player instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer.SerializeReference(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Calculates a monikerized string reference to the given target role-player instance.
            </summary>
            <param name="serializationContext">Serialization context.</param>
            <param name="sourceElement">Source side of reference relationship. The referenced target element will be serialized.</param>
            <param name="targetElement">Target side of relationship that will be serialized.</param>
            <returns>A monikerized string reference to target element.</returns>		
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer.SerializesId">
            <summary>
            Exposes whether serializers derived from this class are serializing Id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipXmlSerializer.UsesFullForm">
            <summary>
            Exposes whether serializers derived from this class are serializing this relationship in full form.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainXmlSerializationBehavior">
            <summary>
            This is the base class for all XmlSerializationBehavior-generated classes. 
            </summary>
            <remarks>
            Each XmlSerializationBehaivor defines a set of behaviors of how to serialize the DomainClasses in the model to XML, which causes
            a set of serializers (all deriving from DomainXmlSerializer) to be generated. The main purpose of the DomainXmlSerializationBehavior
            class is to provide a mapping from DomainClass to its serializer at run-time.
            </remarks>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainXmlSerializationBehavior.AllSerializers">
            <summary>
            This provides a mapping from DomainClass Id to DomainXmlSerializer implementation types.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory">
            <summary>
            This class is meant to be used at runtime to combine all XmlSerializationBehaviors from different DomainModels together. Typically, a
            user will choose more than one models (e.g. one for in-memory model and one for presentation elements). Each model will need an associated
            behavior to get serialized/deserialized properly. Since relationships can connect model elements across domains, it is necessary to have
            a single lookup that maps all used DomainClasses to their serializers.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory.serializerTypes">
            <summary>
            A dictionary that maps DomainClass Id to DomainClassXmlSerializer types.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory.serializers">
            <summary>
            A dictionary that maps DoaminClass Id Guid to DomainClassXmlSerializer instances.
            </summary>
            <remarks>
            The reason that we keep two dictionaries to map DomainClassInfo to both serializer types and instances is that we don't
            want to create all serializer instances at once. The mapping to the types tell what serializers will be created, and once
            they are created on first use, they'll be stored into this second mapping.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory.#ctor">
            <summary>
            Creates a new dictionary with no entries. The entries can be added later by calling AddBehavior() method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory.#ctor(Microsoft.VisualStudio.Modeling.DomainXmlSerializationBehavior[])">
            <summary>
            Creates a new dictionary containing entries from the given serialization behaviors. Just a short-cut for creating
            an empty one and calling AddBehavior() afterwards.
            </summary>
            <param name="serializationBehaviors">Initial list of serialization behaviors that will be included in this dictionary.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory.AddBehavior(Microsoft.VisualStudio.Modeling.DomainXmlSerializationBehavior)">
            <summary>
            Add a serialization behavior to this dictionary, which means adding all mapping entries defined in the behavior, which maps DomainClass Id
            to corresponding serializer.
            </summary>
            <param name="serializationBehavior">Serialization behavior from which the mapping entries will be added.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory.GetSerializer(System.Guid)">
            <summary>
            Get the DomainClassXmlSerializer instance for the given DomainClass Id.
            </summary>
            <param name="domainClassId">DomainClass Id to get DomainClassXmlSerializer instance for.</param>
            <returns>The DomainClassXmlSerializer instance for the given DomainClassInfo, or NULL if no there's no serializer for the given DomainClass Id.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectoryEntry">
            <summary>
            An tuple that wraps one DomainClassId to its DomainClassXmlSerializer type.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectoryEntry.domainClassId">
            <summary>
            DomainClass ID.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectoryEntry.serializerType">
            <summary>
            Type of the DomainClassXmlSerializer for the DomainClass.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectoryEntry.#ctor(System.Guid,System.Type)">
            <summary>
            Constructor
            </summary>
            <param name="domainClassId">DomainClass ID of the entry.</param>
            <param name="serializerType">Corresponding DomainClassXmlSerializer type.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectoryEntry.DomainClassId">
            <summary>
            DomainClass ID.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectoryEntry.SerializerType">
            <summary>
            Type of the DomainClassXmlSerializer for the DomainClass.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RootElementSettings">
            <summary>
            Similar to System.Xml.XmlWriterSettings, this class stores settings that need to be passed to a serializer when
            serializing a root element. Root element has additional information like schema target namespace, versions, etc., so
            additional information may be needed.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.RootElementSettings.schemaTargetNamespace">
            <summary>
            Stores schema target namespace on the root element.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.RootElementSettings.version">
            <summary>
            Stores version on the root element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RootElementSettings.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RootElementSettings.SchemaTargetNamespace">
            <summary>
            Stores schema target namespace on the root element.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RootElementSettings.Version">
            <summary>
            Stores version on the root element.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RootElementSettings.Item(System.String)">
            <summary>
            Gets and Sets additional properties.
            The default generated serialization code doesn't use any additional properties. This is designer
            for customization code to pass additional information, if necessary.
            On get, the given setting name is compared by ordinal, and null is returned if the given setting name doesn't
            match any stored setting value.
            On set, if there's an existing setting with the same name (compared by ordinal), the new value will replace the
            old one with no error. The setting name has to be non-empty.
            </summary>
            <param name="settingName">Name of the setting to lookup.</param>
            <returns>Value of the setting, or null if not found.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SerializationContext">
            <summary>
            This class defines the context of a serialization operation. The context passed to each participating serializers to provide
            information that they may use, and the context stores serialization results collected from each participating serializers.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationContext.directory">
            <summary>
            A serializer instance needs to look up for other serializer instances during serialization/deserialization, so this directory
            provides the lookup service. 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationContext.location">
            <summary>
            In read operation, this is the source's location; in write operation, this is the destination location. Usually this is a file path, but 
            it can be other format as well, depending on the underlying source/destination. It can be null as well if the location is not available, 
            e.g. serializing to a string buffer.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationContext.result">
            <summary>
            This is the SerializationResult collected from all serializers participating in the current serialization operation. 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationContext.writeOptionalPropertiesWithDefaultValue">
            <summary>
            Whether optional properties with default value should be written out during serialization.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationContext.properties">
            <summary>
            This is a generic property bag to pass additional information to serializers during serialization operation.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationContext.#ctor(Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory)">
            <summary>
            Create a serialization context with no source/destination location information.
            </summary>
            <param name="directory">Directory to look up serializers.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationContext.#ctor(Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory,System.String)">
            <summary>
            Create a serialization context with given source/destination location.
            </summary>
            <param name="directory">Directory to look up serializers.</param>
            <param name="location">Source/destination location of this context, it's usually the file path, but it can be any string, including null.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationContext.#ctor(Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory,System.String,Microsoft.VisualStudio.Modeling.SerializationResult)">
            <summary>
            Create a serialization context with given source/destination location and SeralizationResult.
            </summary>
            <param name="directory">Directory to look up serializers, cannot be null.</param>
            <param name="location">Source/destination location of this context, it's usually the file path, but it can be any string, including null.</param>
            <param name="serializationResult">
            SerializationResult to be used by this context. If null is passed, a new SerializationResult will be created.
            </param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationContext.Directory">
            <summary>
            A serializer instance needs to look up for other serializer instances during serialization/deserialization, so this directory
            provides the lookup service. 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationContext.Location">
            <summary>
            In read operation, this is the source's location; in write operation, this is the destination location. Usually this is a file path, but 
            it can be other format as well, depending on the underlying source/destination. It can be null as well if the location is not available, 
            e.g. serializing to a string buffer.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationContext.Result">
            <summary>
            This is the SerializationResult collected from all serializers participating in the current serialization operation. 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationContext.WriteOptionalPropertiesWithDefaultValue">
            <summary>
            Whether optional properties with default value should be written out during serialization.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationContext.Item(System.String)">
            <summary>
            Indexer to access properties stored in this context.
            The property name is compared by case-sensitive ordinal string comparison. If a property already exists in the context, 
            setting it will override the old value with the new value. If a property doesn't exist in the context, getting it will
            return null, therefore setting a property to null will remove it from the context (i.e. null and non-existing values are 
            not distinguishable).
            </summary>
            <param name="propertyName">Name of the property, must by non-empty string.</param>
            <returns>Value of the proeprty, null if the property doesn't exist in current context.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SerializationResult">
            <summary>
            Serialization Result
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationResult.messages">
            <summary>
            Stores the SerializationMessages.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationResult.failed">
            <summary>
            Whether the serialization failed, which means if any of the messages stored has Error kind.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationResult.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationResult.AddMessage(Microsoft.VisualStudio.Modeling.SerializationMessage)">
            <summary>
            Add a message.
            </summary>
            <param name="message">Message to add.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationResult.Append(Microsoft.VisualStudio.Modeling.SerializationResult)">
            <summary>
            Append a serialization result to this one (i.e. copy all messages over).
            </summary>
            <param name="newResult">SerializationResult to append.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationResult.GetEnumerator">
            <summary>
            Gets an enumerator that enumerates all stored SerializationMessages.
            </summary>
            <returns>An enumerator that enumerates all stored SerializationMessages.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationResult.System#Collections#IEnumerable#GetEnumerator">
            <summary>
            Gets an enumerator that enumerates all stored SerializationMessages.
            </summary>
            <returns>An enumerator that enumerates all stored SerializationMessages.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationResult.Failed">
            <summary>
            returns true if the serialization failed, which means at least 1 of the messages has Error kind.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SerializationMessageKind">
            <summary>
            An enum used to decorate messages stored in SerializationResult.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessageKind.Debug">
            <summary>
            The message is for debugging purpose.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessageKind.Info">
            <summary>
            The message is for displaying some information to the user.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessageKind.Warning">
            <summary>
            The message is a warning for possible/non-fatal error.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessageKind.Error">
            <summary>
            The message is for fatal error that can prevent further operations from working properly.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SerializationMessage">
            <summary>
            An object that wraps the information of a serialization message, including message kind, message string, location, etc.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessage.kind">
            <summary>
            Kind of the message.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessage.message">
            <summary>
            Message string.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessage.location">
            <summary>
            The location of the source of this message. Usually a file path, but can be other string (including null) as well.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessage.line">
            <summary>
            Line number of the message.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessage.column">
            <summary>
            Column number of the message.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationMessage.additionalProperties">
            <summary>
            Allow an extensibility point for derived classes to add more properties.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationMessage.#ctor(Microsoft.VisualStudio.Modeling.SerializationMessageKind,System.String,System.String,System.Int32,System.Int32,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])">
            <summary>
            Constructor.
            </summary>
            <param name="kind">Kind of the message.</param>
            <param name="message">Message string.</param>
            <param name="location">The location of the source of this message. Usually a file path, but can be other string (including null) as well.</param>
            <param name="line">Line number of the message.</param>
            <param name="column">Column number of the message.</param>
            <param name="additionalProperties">Any additional properties that will be stored in this message.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationMessage.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationMessage.AddProperty(System.String,System.Object)">
            <summary>
            Add additional properties to the message.
            </summary>
            <remarks>
            The given property name is used as the key to store and retrieve the property value. It is compared by ordinal, and if it collapse with 
            an existing property name, the new value will replace the existing value (no error will be given in this case).
            </remarks>
            <param name="propertyName">Name of the property to add. It is used as the key to store and retrieve the value, so must be non-empty.</param>
            <param name="propertyValue">Value of the property to add. Can be any value, including null.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationMessage.GetProperty(System.String)">
            <summary>
            Gets the value of a property, keyed by the given name.
            </summary>
            <param name="propertyName">Name of the property to look up.</param>
            <returns>The value of the property, or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationMessage.ToString">
            <summary>
            ToString().
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationMessage.Kind">
            <summary>
            Kind of the message.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationMessage.Message">
            <summary>
            Message string.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationMessage.Location">
            <summary>
            The location of the source of this message. Usually a file path, but can be other string (including null) as well.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationMessage.Line">
            <summary>
            Line number of the message.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationMessage.Column">
            <summary>
            Column number of the message.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ISchemaResolver">
            <summary>
            This interface provides a way for the generated serializers to resolve a schema target namespace. 
            Given an XML file using a particular target namespace, it is important to find the schemas that define the namespace, 
            so the generated serializers can do schema validations properly.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ISchemaResolver.ResolveSchema(System.String)">
            <summary>
            This method takes a target namespace string and returns a collection of schema files that define the namespace.
            </summary>
            <param name="targetNamespace">Target namespace to resolve.</param>
            <returns>
            A list of file paths of schemas that define the given target namespace, null or empty list if the given target namespace
            cannot be resolved.
            </returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SerializationUtilities">
            <summary>
            Serialization Utilities
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.TryGetValue``1(System.String,``0@)">
            <summary>
            Try to convert a string into the given type, no exception is thrown.
            </summary>
            <typeparam name="T">Type to convert to.</typeparam>
            <param name="input">Input string to convert.</param>
            <param name="result">Converted result. The value is unspecified if the conversion fails.</param>
            <returns>True if conversion succeeds, false otherwise.</returns>
            <remarks>Changed method behaviour 26 July 07 - now rethrows critical exceptions rather
            than suppressing them.</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.GetValue``1(System.String)">
            <summary>
            Converts a string into the given type
            </summary>
            <typeparam name="T"></typeparam>
            <param name="input"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.TryGetValueFromBinaryForm``1(System.String,``0@)">
            <summary>
            Try to deserialize an input of T type from the given string.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.GetString``1(``0)">
            <summary>
            Converts an object of the given type into a string
            </summary>
            <typeparam name="T"></typeparam>
            <param name="input"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.GetString``1(Microsoft.VisualStudio.Modeling.SerializationContext,``0)">
            <summary>
            Converts an object of the given type into a string
            </summary>
            <typeparam name="T"></typeparam>
            <param name="serializationContext"></param>
            <param name="input"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.Skip(System.Xml.XmlReader)">
            <summary>
            Skip the XmlReader to:
            1) Start tag of the next sibling element.
            2) End tag of the containing parent element.
            3) End of file.
            </summary>
            <param name="reader">The reader to skip.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.GetPositionInfo(System.Xml.XmlReader,System.Int32@,System.Int32@)">
            <summary>
             Get the position information from an XmlReader if available.
            </summary>
            <param name="reader">Reader to get position info from.</param>
            <param name="line">Line of the reader, -1 if not available.</param>
            <param name="column">Column of the reader, -1 if not available.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.SkipToFirstChild(System.Xml.XmlReader)">
            <summary>
            Move the reader to the open tag of the first child element. 
            - If the reader is not on a open tag (including empty tag), the method does nothing (no move).
            - If the reader doesn't have any nested child element, the method will move the reader to the matching close tag.
            </summary>
            <param name="reader">The reader to move.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.SkipToNextElement(System.Xml.XmlReader)">
            <summary>
            Assign the reader to the start tag of the next element. This is usually used after a ReaderInnerXml() call, where
            the reader will be positioned after the close tag of the previous element. Since there may be whitespace or comments
            between the two elements, the reader may not be moved onto the start tag of the next element automatically.
            If the reader is already on a start tag, this method will do nothing. The method will also stop if an end tag is 
            encountered, which means there's no more siblings and the end of the parent element is reached.
            </summary>
            <param name="reader">The reader to skip.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.SkipOneToken(System.Xml.XmlReader)">
            <summary>
            Make the given reader to skip the next token.
            </summary>
            <param name="reader">Reader to skip.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.UnescapeXmlString(System.String)">
            <summary>
            Unescape the characters read from XML, e.g. converting &amp;amp; back to &amp;.
            </summary>
            <param name="input"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.GetElementName(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get the name of a ModelElement for display purpose (e.g. used in error messages).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.AddMessage(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.SerializationMessageKind,System.String,System.Xml.IXmlLineInfo,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])">
            <summary>
            Helper to build a SerializationMessage and store it into the given SerializationContext.
            </summary>
            <param name="serializationContext">SerializationContext in which the new message will be stored.</param>
            <param name="kind">SerializationMessageKind of the message to be built.</param>
            <param name="message">Message text.</param>
            <param name="xmlLineInfo">
            IXmlLineInfo that provides line and column of where the message is raised.
            This parameter can be null, which means the information is not available.
            </param>
            <param name="additionalProperties">Any additional properties to be stored in the message.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.AddMessage(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.SerializationMessageKind,System.String,System.Int32,System.Int32,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])">
            <summary>
            Helper to build a SerializationMessage and store it into the given SerializationContext.
            </summary>
            <param name="serializationContext">SerializationContext in which the new message will be stored.</param>
            <param name="kind">SerializationMessageKind of the message to be built.</param>
            <param name="message">Message text.</param>
            <param name="line">Line number of where the message is raised.</param>
            <param name="column">Column number of where the message is raised.</param>
            <param name="additionalProperties">Any additional properties to be stored in the message.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.AddMessage(Microsoft.VisualStudio.Modeling.SerializationContext,Microsoft.VisualStudio.Modeling.SerializationMessageKind,System.Xml.XmlException,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])">
            <summary>
            Helper to build a SerializationMessage and store it into the given SerializationContext.
            </summary>
            <param name="serializationContext">SerializationContext in which the new message will be stored.</param>
            <param name="kind">SerializationMessageKind of the message to be built.</param>
            <param name="xmlException">XmlException that contains the error information (message, location, etc).</param>
            <param name="additionalProperties">Any additional properties to be stored in the message.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.AddMessage(Microsoft.VisualStudio.Modeling.SerializationResult,System.String,Microsoft.VisualStudio.Modeling.SerializationMessageKind,System.String,System.Int32,System.Int32,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])">
            <summary>
            Helper to build a SerializationMessage and store it into the given SerializationContext.
            </summary>
            <param name="serializationResult">SerializationResult in which the new message will be stored.</param>
            <param name="location">Location of where the message is generated.</param>
            <param name="kind">SerializationMessageKind of the message to be built.</param>
            <param name="message">Message text.</param>
            <param name="line">Line number of where the message is raised.</param>
            <param name="column">Column number of where the message is raised.</param>
            <param name="additionalProperties">Any additional properties to be stored in the message.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationUtilities.AddValidationMessage(Microsoft.VisualStudio.Modeling.SerializationResult,Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Add a validation message as serialization message, which is used to report load-time validation failures.
            </summary>
            <param name="serializationResult">SerializationResult to store the message.</param>
            <param name="validationMessage">ValidationMessage to add.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SerializationException">
            <summary>
            This is used to throw a SerializationResult as an exception.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SerializationException.serializationResult">
            <summary>
            SerialziationResult containing error/warnings for unresolved monikers.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationException.#ctor(Microsoft.VisualStudio.Modeling.SerializationResult)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationException.#ctor(Microsoft.VisualStudio.Modeling.SerializationResult,System.String)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationException.#ctor(Microsoft.VisualStudio.Modeling.SerializationResult,System.String,System.Exception)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationException.#ctor(Microsoft.VisualStudio.Modeling.SerializationResult,System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SerializationException.ToString">
            <summary>
            ToString().
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SerializationException.SerializationResult">
            <summary>
            SerialziationResult containing error/warnings for unresolved monikers.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute">
            <summary>
            Summary description for CategoryAttribute.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute.#ctor(System.String,System.Type)">
            <summary>
            Initializes a new instance of the CategoryAttribute class with the specified category name.
            </summary>
            <param name="displayNameKey">The name of the category</param>
            <param name="type">Type</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute.#ctor(System.String,System.Type,System.String)">
            <summary>
            Initializes a new instance of the CategoryAttribute class with the specified category name.
            </summary>
            <param name="displayNameKey">The name of the category</param>
            <param name="type">Type for this category</param>
            <param name="resourceName">Resource name</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute.GetLocalizedString(System.String)">
            <summary>
            Looks up the localized name of a given category
            </summary>
            <param name="value">The name of the category to look up</param>
            <returns>The localized name of the category, or a null reference (Nothing in Visual Basic) if a localized name does not exist</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute.Type">
            <summary>
            Type for this catetory
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute.ResourceName">
            <summary>
            Resource Name for this category
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.CategoryResourceAttribute.DisplayNameKey">
            <summary>
            Caption Key
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute">
            <summary>
            Attribute to provide property descriptions on domain properties.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute.#ctor(System.String,System.Type)">
            <summary>
            Initializes a new instance of the DescriptionAttribute class with a description
            </summary>
            <param name="descriptionKey">The description text</param>
            <param name="type">Type</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute.#ctor(System.String,System.Type,System.String)">
            <summary>
            Initializes a new instance of the DescriptionAttribute class with a description
            </summary>
            <param name="descriptionKey">The description text</param>
            <param name="type">Type</param>
            <param name="resourceName">Resource name</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute.Type">
            <summary>
            Type identifying resource location.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute.ResourceName">
            <summary>
            Resource name.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute.DescriptionKey">
            <summary>
            Description resource Id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DescriptionResourceAttribute.Description">
            <summary>
             Gets the description stored in this attribute.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute">
            <summary>
            Specifies the display name for a domain property, role or class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute.#ctor(System.String,System.Type)">
            <summary>
            Initializes a new instance of the DisplayNameResourceAttribute class with the specified display name name.
            </summary>
            <param name="displayNameKey">The name of the category</param>
            <param name="type">Type</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute.#ctor(System.String,System.Type,System.String)">
            <summary>
            Initializes a new instance of the DisplayNameResourceAttribute class with the specified display name.
            </summary>
            <param name="displayNameKey">The name of the display name</param>
            <param name="type">Type for this display name</param>
            <param name="resourceName">Resource name</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute.Type">
            <summary>
            Type for this catetory
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute.ResourceName">
            <summary>
            Resource Name for this category
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute.DisplayNameKey">
            <summary>
            Caption Key
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.DisplayNameResourceAttribute.DisplayName">
            <summary>
            Gets the display name for a domain property, role or class.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor">
            <summary>
            Class ElementPropertyDescriptor: This Ims flavored descriptor class allows us to create Ims flavored property descriptor. 
            This class represents a real C# property 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.#ctor(Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Attribute[])">
            <summary>
            The ElementPropertyDescriptor can operate upon a specific element
            passed in to the constructor, or it can accept a null element.
            
            If a specific element is provided, GetValue(), SetValue(), and
            the other methods will ignore the object argument passed in
            and will instead use that specific element.
            
            If a null element is provided, GetValue(), SetValue(), and 
            the other methods will use the object argument passed in.
            </summary>
            <param name="owner">Owner of this object</param>
            <param name="modelElement">ModelElement whose property will be operated upon. This may be null, in which case GetValue() and SetValue() actually use the argument passed in.</param>
            <param name="domainProperty">Property (Required)</param>
            <param name="attributes">Array of Attributes for this property descriptor</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Attribute[])">
            <summary>
            The ElementPropertyDescriptor can operate upon a specific element
            passed in to the constructor, or it can accept a null element.
            
            If a specific element is provided, GetValue(), SetValue(), and
            the other methods will ignore the object argument passed in
            and will instead use that specific element.
            
            If a null element is provided, GetValue(), SetValue(), and 
            the other methods will use the object argument passed in.
            </summary>
            <param name="modelElement">ModelElement whose property will be operated upon. This may be null, in which case GetValue() and SetValue() actually use the argument passed in.</param>
            <param name="domainProperty">Property (Required)</param>
            <param name="attributes">Array of Attributes for this property descriptor</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.GetEditor(System.Type)">
            <summary>
            Gets an editor of the specified type. Override this so we can provide our own FlagEnumerationEditor for bit-wisable enum
            </summary>
            <param name="editorBaseType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.GetValue(System.Object)">
            <summary>
            Get the value of the property...
            </summary>
            <param name="component"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.SetValue(System.Object,System.Object)">
            <summary>
            Sets the value of the property.
            </summary>
            <param name="component"></param>
            <param name="value"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.ResetValue(System.Object)">
            <summary>
            Reset domain propertyvalue to the default based on the default of the domain.
            </summary>
            <param name="component"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.CanResetValue(System.Object)">
            <summary>
            This is not a resettable property.
            </summary>
            <param name="component">the propery object</param>
            <returns>Returns true when DomainProperty has default value and is not read-only.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.ShouldSerializeValue(System.Object)">
            <summary>
            Allow the property to be reported as bold in the property browser
            </summary>
            <param name="component">the property object</param>
            <returns>whether this property is different from its default</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.GetSetValueTransactionName(System.String)">
            <summary>
            Gets a string describing the set field action.
            </summary>
            <param name="caption">Caption to be included in the string</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.IsElementPropertyReadonly(Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor)">
            <summary>
            Internal helper method to determine whether a given ElementPropertyDescriptor is readonly
            </summary>
            <param name="elementProp"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.GetElementPropertyDisplayName(Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor)">
            <summary>
            Method to extract the display name for the given ElementPropertyDescriptor. If there's a 
            [System.ComponentModel.DisplayNameAttribute] on the domain attribute, it return the name. If not, 
            it will return the DomainPropertyInfo.DisplayName.
            </summary>
            <param name="elementProp"></param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.DomainPropertyInfo">
            <summary>
            DomainPropertyInfo for this propery
            </summary>
            <value>DomainPropertyInfo</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.ModelElement">
            <summary>
            returns the element to which this property belongs
            </summary>
            <value>ModelElement</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.DisplayName">
            <summary>
            Gets the name that can be displayed in a window, such as a Properties window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.Converter">
            <summary>
            Gets the type converter of the property descriptor.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.PropertyType">
            <summary>
            Returns the property type.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.ComponentType">
            <summary>
            The type of component the framework expects for this property.  Notice this returns element.GetType().  That is because the 
            object that is being browsed when this property is shown is an ModelElement.  So we are faking the PropertyGrid into thinking 
            this is a property on that type, even though it isn't.
            </summary>	
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.IsReadOnly">
            <summary>
            We have to override all the abstract members.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.Category">
            <summary>
            Gets the name of the category to which the member belongs, as specified in the CategoryAttribute.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor.Description">
            <summary>
            Gets the description of the member, as specified in the DescriptionAttribute.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptionProvider">
            <summary>
            ElementTypeDescriptionProvider provides the wrapper class which encapsulates the ModelElement object. This class is invoked
            when property grid wants to render the ModelElement object.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptionProvider.#ctor">
            <summary>
            Creates a new ElementTypeDescriptionProvider.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptionProvider.GetTypeDescriptor(System.Type,System.Object)">
            <summary>
            Returns the TypeDescriptor for the requesting ModelElement object. 
            </summary>
            <param name="objectType"></param>
            <param name="instance"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptionProvider.CreateTypeDescriptor(System.ComponentModel.ICustomTypeDescriptor,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Overridables for the derived class to provide a custom type descriptor. 
            </summary>
            <param name="parent">Parent custom type descriptor.</param>
            <param name="element">Element to be described.</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor">
            <summary>
            Class for providing ModelElement TypeDesriptor for the propety grid support!
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.selectedElement">
            <summary>
            Object to be wrapped.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.#ctor">
            <summary>
            Hide the default ctor to the externals...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.#ctor(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            ctor for creating the wrapper class which represents the element to be consumed by the property grid.
            </summary>
            <param name="selectedElement"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.#ctor(System.ComponentModel.ICustomTypeDescriptor,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            ctor for creating the wrapper class which represents the element to be consumed by the property grid.
            </summary>
            <param name="parent">Parent custom type descriptor.</param>
            <param name="selectedElement">Selected element to be described.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetComponentName">
            <summary>
            The name of the object, or a null reference (Nothing in Visual Basic) if object does not have a name.
            </summary>
            <returns>The name of the object, or a null reference (Nothing in Visual Basic) if object does not have a name.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetProperties">
            <summary>
            Returns the properties for this instance of a component.
            </summary>
            <returns>A PropertyDescriptorCollection that represents the properties for this component instance.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetProperties(System.Attribute[])">
            <summary>
            Returns the properties for this instance of a component using the attribute array as a filter.
            </summary>
            <param name="attributes">An array of type Attribute that is used as a filter. </param>
            <returns>An array of type Attribute that represents the properties for this component instance that match the given set of attributes.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetDisplayProperties(Microsoft.VisualStudio.Modeling.ModelElement,System.ComponentModel.PropertyDescriptor@)">
            <summary>
            Returns a list of property descriptor for each domain property
            </summary>
            <param name="requestor">ModelElement that is requesting the property value.</param>
            <param name="defaultPropertyDescriptor"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.ShouldCreatePropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo)">
            <summary>
            For a given domain property defined in the requestor model element, ShouldCreatePropertyDescriptor determines whether we should create a property 
            descriptor or not. Note that the selectedElement provides the context where the intended property dsscriptor will be created from.
            </summary>
            <param name="requestor">model elemnt for the given domain property info</param>
            <param name="domainProperty">Domain property of the passed in requestor model element class</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.IncludeOppositeRolePlayerProperties(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            For all the relationships this model element participate, return whether to display the opposite role player's ElementName property if the 
            multiplicity is One/ZeroOne
            </summary>
            <param name="requestor"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.IncludeEmbeddingRelationshipProperties(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            For all the relationships this model element participate, return whether to display DomainProperty defined on the DomainRelationship if 
            this is an embedded model element.
            </summary>
            <param name="requestor"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.ShouldCreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            For the relationship and the instance level role players involved, return whether to create a property descriptor for the opposite role player
            </summary>
            <param name="sourceRolePlayer">Source role player</param>
            <param name="sourceRole">Source role involved</param>
            <returns></returns>
            <remarks>
            Default implementation only creates RolePlayerPropertyDescriptors for reference relationships.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.CreatePropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Attribute[])">
            <summary>
            Method to create a PropertyDescriptor which describes the property to be displayed in the grid.
            </summary>
            <param name="requestor">ModelElement that is requesting the property value.</param>
            <param name="domainPropertyInfo">DomainProperty backing the property descriptor</param>
            <param name="attributes">Attributes</param>
            <returns>ElementPropertyDescriptor</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Attribute[])">
            <summary>
            Method to create a PropertyDescriptor which describes a relationship and role to be displayed in the grid.
            </summary>
            <param name="sourceRolePlayer">ModelElement playing the source role.</param>
            <param name="targetRoleInfo">DomainRoleInfo describing the target role.</param>
            <param name="sourceDomainRoleInfoAttributes">Attributes on the source DomainRoleInfo</param>
            <returns>RolePlayerPropertyDescriptor</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.IsPropertyDescriptorReadOnly(Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor)">
            <summary>
            Returns whether this element property descriptor is read only or not.
            </summary>
            <param name="propertyDescriptor"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetPropertyDescriptorDisplayName(Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor)">
            <summary>
            Returns localized DisplayName for the passed in elementPropertyDescriptor
            </summary>
            <param name="propertyDescriptor"></param>
            <returns>default returns the propert info name</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetCategory(Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor)">
            <summary>
            Returns localized Category for Domain Property
            </summary>
            <param name="propertyDescriptor">PropertyDescriptor</param>
            <returns>category for the given descriptor</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetDescription(Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor)">
            <summary>
            Returns localized Description for Domain Property
            </summary>
            <param name="propertyDescriptor">PropertyDescriptor</param>
            <returns>descriptor for the given descriptor</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetDomainPropertyAttributes(Microsoft.VisualStudio.Modeling.DomainPropertyInfo)">
            <summary>
            Gets an array of custom attributes for the specified DomainProperty.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.GetRolePlayerPropertyAttributes(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Gets an array of custom attributes for the specified DomainRole.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.ModelElement">
            <summary>
            Returns the model element wrapped by this descriptor 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor.ComponentType">
            <summary>
            Returns the component type of the selected model element.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.FlagEnumerationEditor">
            <summary>
            Custom UI type editor for Bitwisable DomainEnumeration editor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.FlagEnumerationEditor.#ctor(System.Collections.Generic.IEnumerable{System.String},System.Char)">
            <summary>
            FlagEnumerationEditor ctor. 
            </summary>
            <param name="enumFields">All enum field names</param>
            <param name="displayDelimiter">The character used to separate the enum values when displayed in a single list</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.FlagEnumerationEditor.#ctor(System.Collections.Generic.IEnumerable{System.String},System.Char,System.Resources.ResourceManager,System.Type,Microsoft.VisualStudio.Modeling.Design.ConvertEnumValueToDisplayString,Microsoft.VisualStudio.Modeling.Design.ConvertEnumDisplayStringToValue)">
            <summary>
            Internal ctor for used with the IMS DominaPropertyInfo of type bit-wisable enum
            </summary>
            <param name="enumFields"></param>
            <param name="flagEnumDelimiter"></param>
            <param name="resourceManager"></param>
            <param name="enumType"></param>
            <param name="convertValueToDisplayString"></param>
            <param name="convertEnumDisplayStringToValue"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.FlagEnumerationEditor.GetEditStyle(System.ComponentModel.ITypeDescriptorContext)">
            <summary>
            return the type of editor
            </summary>
            <param name="context"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.FlagEnumerationEditor.EditValue(System.ComponentModel.ITypeDescriptorContext,System.IServiceProvider,System.Object)">
            <summary>
            Invoked when user clicks the tri-angle button to view the checked list box
            </summary>
            <param name="context"></param>
            <param name="provider"></param>
            <param name="value"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.TypeDescriptionProviderForwarder">
            <summary>
            Delegate to forward one ModelElement to another
            </summary>
            <param name="source"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.ForwardingTypeDescriptionProvider">
            <summary>
            Class to forward one type to another
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.ForwardingTypeDescriptionProvider.forwarder">
            <summary>
            Delegate to forward one ModelElement to another
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ForwardingTypeDescriptionProvider.#ctor(Microsoft.VisualStudio.Modeling.Design.TypeDescriptionProviderForwarder)">
            <summary>
            Constructor
            </summary>
            <param name="forwarder"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ForwardingTypeDescriptionProvider.GetTypeDescriptor(System.Type,System.Object)">
            <summary>
            Returns the custom type descriptor for the given type/instance.
            </summary>
            <returns>TypeDescriptor </returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter">
            <summary>
            ModelingEnumerationConverter: Class to provide the localized enum text from Ims. This is needed since .NET framework provides the list box for  
            listing of all the enum values.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.#ctor(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Char)">
            <summary>
            constructor
            </summary>
            <param name="domainProperty"></param>
            <param name="displayEnumFieldDelimiter"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            Gets a value indicating whether this converter can convert an object in the given source type to an enumeration object using
            the specified context.
            </summary>
            <param name="context"></param>
            <param name="sourceType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            Gets a value indicating whether this converter can convert an object to the given destination type using the context.
            </summary>
            <param name="context"></param>
            <param name="destinationType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)">
            <summary>
            Converts the specified string into the internal enum value
            </summary>
            <param name="context"></param>
            <param name="culture"></param>
            <param name="value"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)">
            <summary>
            Convert from internan enum to the string representation.
            </summary>
            <param name="context"></param>
            <param name="culture"></param>
            <param name="value"></param>
            <param name="destinationType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.GetStandardValues(System.ComponentModel.ITypeDescriptorContext)">
            <summary>
            Gets a collection of standard values for the data type this validator is designed for.
            </summary>
            <param name="context"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext)">
            <summary>
            Gets a value indicating whether the list of standard values returned from GetStandardValues in an exclusive list using the specified context.
            </summary>
            <param name="context"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext)">
            <summary>
            Gets a value indicating whether this object supports a standard set of values that can be picked from a list using the specified context.
            </summary>
            <param name="context"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.GetLoclizedEnumFieldNames(System.Resources.ResourceManager,System.Type)">
            <summary>
            Internal helper method to return the localized field names.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.ConvertEnumValueToDisplayString(System.Resources.ResourceManager,System.Type,System.Object,System.Char)">
            <summary>
            Internal helper method to convert enum value into the display string.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.ConvertEnumDisplayStringToValue(System.Resources.ResourceManager,System.Type,System.String,System.Char)">
            <summary>
            Internal helper method to convert the display string back to the internal enum value
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.ParseLocalizedEnumText(System.String)">
            <summary>
            For the given *localized* text, this method convert to the corresponding enumerated constant in terms of its underlying type.
            </summary>
            <param name="enumValueText"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.GetLocalizedEnumFieldName(System.Resources.ResourceManager,System.Type,System.String)">
            <summary>
            For the given type and the field name, this method returns the localied display field name.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.Values">
            <summary>
            Gets/Sets the collection of values to be displayed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.ResourceManager">
            <summary>
            Returns the resource manager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.Comparer">
            <summary>
            Gets an IComparer interface that can be used to sort the values of the enumerator
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingEnumerationConverter.EnumValueNames">
            <summary>
            Returns a collection of localized enum field names.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem">
            <summary>
            Represents a toolbox item for creating a group of model elements.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.ToolboxContextOrigin">
            <summary>
            Key used with CopyOriginContext to indicate that the copy originated in the Toolbox.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.#ctor(System.String,System.Int32,System.String,System.Drawing.Bitmap,System.String,System.String,System.String,System.String,Microsoft.VisualStudio.Modeling.ElementGroupPrototype,System.Collections.ICollection)">
            <summary>
            Initializes a new instance of the ModelingToolboxItem class.
            </summary>
            <param name="id">A string used to uniquely identify this toolbox item and prevent duplicates.</param>
            <param name="position">An integer used to sort and position the toolbox item in the tab (0 is top).</param>
            <param name="displayName">Name displayed in the toolbox.  Should be localized.</param>
            <param name="bitmap">Bitmap displayed in toolbox.  Must be an 8-bit image.</param>
            <param name="tabNameId">Non-localized Name id of the tab to contain this toolbox item.	 Should be localized.</param>
            <param name="tabName">Name of the tab to contain this toolbox item.	 Should be localized.</param>
            <param name="f1Keyword">The F1 help keyword for this toolbox item</param>
            <param name="tooltip">The tooltip to be shown for this item</param>
            <param name="prototype">The ElementGroupPrototype for this item</param>
            <param name="toolboxFilters">Collection of ToolboxItemFilterAttributes to determine enabled/disabled state of items in the toolbox.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serialization constructor.
            </summary>
            <param name="info">The serialization information.</param>
            <param name="context">The streaming context.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.Serialize(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serializes this instance of the ModelingToolboxItem.
            </summary>
            <param name="info">The serialization information.</param>
            <param name="context">The streaming context.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.Deserialize(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Deserialize this instance of the ModelingToolboxItem.
            </summary>
            <param name="info">The serialization information</param>
            <param name="context">The streaming context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.Equals(System.Object)">
            <summary>
            Determines whether two <see cref="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem"/> instances are equal.
            </summary>
            <param name="obj">The <see cref="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem"/> to compare with the current <see cref="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem"/>.</param>
            <returns>true if the specified <see cref="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem"/> is equal to the current
             <see cref="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem"/>; otherwise, false.
            </returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.GetHashCode">
            <summary>
            Returns the hash code for this instance.
            </summary>
            <returns>
            A hash code for the current <see cref="T:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem"/>.
            </returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.Id">
            <summary>
            Gets the unique identified of this toolbox item.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.Position">
            <summary>
            Gets the suggested position of the toolbox item.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.TabName">
            <summary>
            Gets the name of the toolbox tab to contain this item.  Should be localized.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.TabNameId">
            <summary>
            Gets non-localized name Id of the toolbox tab to contain this item.  Must NOT be localized.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.ContextSensitiveHelpKeyword">
            <summary>
            Gets context sensitive help keyword of the toolbox item.  Should NOT be localized.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.Prototype">
            <summary>
            Gets the ElementGroupPrototype containing toolbox item data.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.ModelingToolboxItem.ComponentType">
            <summary>
            Gets the ComponentType string that is shown in the tooltip for this item.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.SourceRolePlayerMapFunction">
            <summary>
            Delegate to encapsulate a function to allow clients to interpose themselves in the source object for creating a relationship
            where the target role player is being changed from null (no relationship) to being valued (needing new relationship)
            </summary>
            <remarks>
            This is a useful point of extension, because property descriptors are OFTEN returned as fakes descriptors from a chain of objects.
            A useful eample of this is where a PEL defers its propertiues to its underlying MEL.
            In this case the function would map from the PEL to the MEL.
            </remarks>
            <param name="input"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.RolePlayerMenuCommand">
            <summary>
            An abstract command class for that provides a place to store the result of finding a new role player value
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerMenuCommand.#ctor">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerMenuCommand.DoCommand">
            <summary>
            Performs the command.  After this method is called, the Result property
            should return a valid value.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerMenuCommand.ToString">
            <summary>
            Returns the value of the MenuText property.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerMenuCommand.MenuText">
            <summary>
            Specifies the text of the item.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerMenuCommand.Result">
            <summary>
            The result of the command
            </summary>
            <remarks>
            This value will be used as the new value of the role player
            </remarks>
            <value>The result of the command</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor">
            <summary>
            Property descriptor for use with ElementLinks to allow a role player to be visualized as a property in the property grid
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.store">
            <summary>
            The store this descriptor operates across
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.link">
            <summary>
            The relationship instance to display/edit the role player of
            </summary>
            <remarks>
            This can be null, in which case the relationship will be created/deleted as necessary 
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.sourcePlayer">
            <summary>
            Source role player of this propert descriptor
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.domainRole">
            <summary>
            The domain data for the role that is being edited
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.displayName">
            <summary>
            An override of the role name for use in the UI
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.mapSourceRolePlayer">
            <summary>
            A mapping function from the system's idea of the source of a property to the client application's idea of same.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.allowNull">
            <summary>
            Whether null is a valid value for this role player in the circumstances its presented with this descriptor
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.hasTypeConverterAttribute">
            <summary>
            True if there is a custom type converter specified.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.commands">
            <summary>
            List of RolePlayerMenuCommand objects.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Attribute[])">
            <summary>
            Constructor
            </summary>
            <param name="sourcePlayer">Source of this RolePlayerPropertyDescriptor.</param>
            <param name="domainRole">The domain data for the role that is being edited.</param>
            <param name="sourceDomainRoleInfoAttributes">Attributes modifying property descriptor behavior.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.GetValue(System.Object)">
            <summary>
            Get the value of the property...
            </summary>
            <param name="component"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.SetValue(System.Object,System.Object)">
            <summary>
            Sets the value of the property.
            </summary>
            <param name="component"></param>
            <param name="value"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.ResetValue(System.Object)">
            <summary>
            Reset domain propertyvalue to the default based on the default of the domain.
            </summary>
            <param name="component"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.CanResetValue(System.Object)">
            <summary>
            Roles can't be reset as one has no idea what object it would have been.
            </summary>
            <param name="component">the propery object</param>
            <returns>Overrideable.  returns true by default except for read only properties.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.ShouldSerializeValue(System.Object)">
            <summary>
            This property doesn't participate in code generation.
            </summary>
            <param name="component">the property object</param>
            <returns>false by default.  (Overrideable)</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.GetSetFieldString(System.String)">
            <summary>
            Gets a string describing the set field action.
            </summary>
            <param name="caption">Caption to be included in the string</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.DisplayName">
            <summary>
            Gets the name that can be displayed in a window, such as a Properties window.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.Converter">
            <summary>
            Gets the type converter of the property descriptor.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.PropertyType">
            <summary>
            Returns the property type.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.ComponentType">
            <summary>
            The type of component the framework expects for this property.  Notice this returns element.GetType().  That is because the 
            object that is being browsed when this property is shown is an ModelElement.  So we are faking the PropertyGrid into thinking 
            this is a property on that type, even though it isn't.
            </summary>	
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.SourcePlayer">
            <summary>
            Returns sorucePlayer of the RolePlayerPropertyDescriptor
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.IsReadOnly">
            <summary>
            Returns whether this property descriptor is read only or not.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.DomainRoleInfo">
            <summary>
            DomainPropertyInfo for this propery
            </summary>
            <value>DomainPropertyInfo</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.Link">
            <summary>
            returns the element to which this property belongs
            </summary>
            <value>ModelElement</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.Store">
            <summary>
            Returns the Store this descriptor operates across
            </summary>
            <value>ModelElement</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.RelationshipInfo">
            <summary>
            returns the domain data for the relationship
            </summary>
            <value>Domain data</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.MapSourceRolePlayer">
            <summary>
            A mapping function from the system's idea of the source of a property to the client application's idea of same.
            </summary>
            <value>A delegate to the function</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.AllowNull">
            <summary>
            Whether null is a valid value for this role player in the circumstances its presented with this descriptor
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.ElementList">
            <summary>
            List of valid role players for this property value.  By default, this will be all elements
            in the store of the type specified by RoleTypeConstraint.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor.RolePlayerMenuCommands">
            <summary>
            List of RolePlayerMenuCommand objects, which are exposed as items in the drop-down edit list, and
            provide a callback mechanism for specifying the role player instance when the user chooses
            a particular item.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.RolePlayerTypeConverter">
            <summary>
            Class to provide conversion for a domain propertyon a domain class
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerTypeConverter.propertyDescriptor">
            <summary>
            Back pointer to the property descriptor.  This allows us to delay querying for the list
            of model elements until we really need to.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerTypeConverter.propertyInfo">
            <summary>
            domain property used for conversion.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.RolePlayerTypeConverter.modelElements">
            <summary>
            List of model elements to be displayed in the drop-down
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerTypeConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            Indicates conversion can happen from a String.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.RolePlayerTypeConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)">
            <summary>
            Performs conversion from a String to a Guid (ModelElement.Id) or RolePlayerMenuCommand.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.TrackingPropertyDescriptor">
            <summary>
            Property descriptor class that uses a second property to manage whether it is in a calculated or stored state.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.TrackingPropertyDescriptor.#ctor(Microsoft.VisualStudio.Modeling.Design.ElementTypeDescriptor,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Attribute[])">
            <summary>
            The ElementPropertyDescriptor can operate upon a specific element
            passed in to the constructor, or it can accept a null element.
            
            If a specific element is provided, GetValue(), SetValue(), andcool, thaznkl
            the other methods will ignore the object argument passed in
            and will instead use that specific element.
            
            If a null element is provided, GetValue(), SetValue(), and 
            the other methods will use the object argument passed in.
            </summary>
            <param name="owner">Owner of this object</param>
            <param name="modelElement">ModelElement whose property will be operated upon. This may be null, in which case GetValue() and SetValue() actually use the argument passed in.</param>
            <param name="domainProperty">Property (Required)</param>
            <param name="trackingProperty">(Boolean)Property that handles whether this property is tracking.</param>
            <param name="attributes">Array of Attributes for this property descriptor</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.TrackingPropertyDescriptor.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Attribute[])">
            <summary>
            The ElementPropertyDescriptor can operate upon a specific element
            passed in to the constructor, or it can accept a null element.
            
            If a specific element is provided, GetValue(), SetValue(), and
            the other methods will ignore the object argument passed in
            and will instead use that specific element.
            
            If a null element is provided, GetValue(), SetValue(), and 
            the other methods will use the object argument passed in.
            </summary>
            <param name="modelElement">ModelElement whose property will be operated upon. This may be null, in which case GetValue() and SetValue() actually use the argument passed in.</param>
            <param name="domainProperty">Property (Required)</param>
            <param name="trackingProperty">(Boolean)Property that handles whether this property is tracking.</param>
            <param name="attributes">Array of Attributes for this property descriptor</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.TrackingPropertyDescriptor.ResetValue(System.Object)">
            <summary>
            Reset the value of the property to be the calculated value.
            </summary>
            <param name="component"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.TrackingPropertyDescriptor.CanResetValue(System.Object)">
            <summary>
            Can this property be reset to its tracking value
            </summary>
            <param name="component"></param>
            <returns>true if it is not tracking</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.TrackingPropertyDescriptor.ShouldSerializeValue(System.Object)">
            <summary>
            With tracking properties, embolden non-tracked properties.
            </summary>
            <param name="component"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.UserContext">
            <summary>
            Class that represents a collection of help elements
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContext.#ctor">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContext.Add(System.String,System.String,Microsoft.VisualStudio.Modeling.Design.UserContextType)">
            <summary>
            Adds a help element to the collection.
            </summary>
            <param name="name">Name of the filter attribute.  Not used for keywords or F1 keywords.</param>
            <param name="value">Value of the keyword, F1 keyword, or attibute</param>
            <param name="type">Context element type:  keyword, F1 keyword, or attribte</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContext.Add(System.String,System.String)">
            <summary>
            Internal add that deduces the UserContextType from the given name.
            </summary>
            <param name="name">For F1Keywords, this should be "F1Keyword".  For keywords, it should be "Keyword".  For attributes, it should be the name of the attribute.</param>
            <param name="value">Value of the keyword, F1Keyword, or attribute</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContext.#ctor(System.Xml.XmlNodeList)">
            <summary>
            
            </summary>
            <param name="nodeList"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContext.#ctor(System.String)">
            <summary>
            load from a string, as saved by SaveToString
            </summary>
            <param name="resource"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContext.SaveToString">
            <summary>
            serialize to a string: [Name Value][Name Value]...
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.UserContext.F1Keyword">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.UserContext.UserContextElements">
            <summary>
            Returns a read-only collection of context elements
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.UserContext.Empty">
            <summary>
            Represents an empty context bag.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.UserContextType">
            <summary>
            Defines possbile help element types
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.UserContextType.F1Keyword">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.UserContextType.Keyword">
            <summary>
            
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Design.UserContextType.Attribute">
            <summary>
            
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.UserContextElement">
            <summary>
            Class that encapsulates a single help element, which can be a keyword, F1 keyword, or filter attribute
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContextElement.#ctor(System.String,System.String,Microsoft.VisualStudio.Modeling.Design.UserContextType)">
            <summary>
            Create a UserContextElement with the give parameters
            </summary>
            <param name="attributeName">Name of the filter attribute.  Not used for keywords or F1 keywords.</param>
            <param name="value">Value of the keyword, F1 keyword, or attibute</param>
            <param name="type">Context element type:  keyword, F1 keyword, or attribte</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContextElement.#ctor(System.String,System.String)">
            <summary>
            Internal constructor that deduces the UserContextType from the given name.
            </summary>
            <param name="name">For F1Keywords, this should be "F1Keyword".  For keywords, it should be "Keyword".  For attributes, it should be the name of the attribute.</param>
            <param name="value">Value of the keyword, F1Keyword, or attribute</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.UserContextElement.ContextType">
            <summary>
            Returns the type of this element, keyword, F1 keyword, or attribute
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.UserContextElement.Value">
            <summary>
            Returns the value of this element, keyword, or attribute
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Design.UserContextElement.PropertyName">
            <summary>
            Returns the attribute name.  For keyword, this will be "Keyword".  For F1 keywords, it will be "F1Keyword"
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Design.UserContextTypeConverter">
            <summary>
            
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContextTypeConverter.CanConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            
            </summary>
            <param name="context"></param>
            <param name="sourceType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContextTypeConverter.CanConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Type)">
            <summary>
            
            </summary>
            <param name="context"></param>
            <param name="destinationType"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContextTypeConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)">
            <summary>
            
            </summary>
            <param name="context"></param>
            <param name="culture"></param>
            <param name="value"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Design.UserContextTypeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)">
            <summary>
            
            </summary>
            <param name="context"></param>
            <param name="culture"></param>
            <param name="value"></param>
            <param name="destinationType"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.StoreNode">
            <summary>
            Represents the Store in the tree.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode">
            <summary>
            Base class for all model tree nodes.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.NavigateTo(System.Windows.Forms.TreeNode,System.Object)">
            <summary>
            Navigates to a node with given tag.
            </summary>
            <param name="node">Root node to start with.</param>
            <param name="tag">Tag to search for.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.Populate">
            <summary>
            Called to populate child nodes.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.OnAfterExpand">
            <summary>
            Called after the node has been expanded.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.OnAfterCollapse">
            <summary>
            Called after the node has been collapsed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.OnActivated">
            <summary>
            Called when node is double-clicked (activated).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.CreatePropertyItems(System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.Diagnostics.PropertyListItemInfo})">
            <summary>
            Creates property list view items.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewerNode.CreateLinkItems(System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.Diagnostics.LinkListViewItemInfo})">
            <summary>
            Creates link list view items.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.FolderNode">
            <summary>
            Represents a folder node.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.PartitionNode">
            <summary>
            Represents a Partition of a Store in the tree.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.LinksNode">
            <summary>
            Folder node containing all links in a partition.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.ElementNode">
            <summary>
            Represents a ModelElement.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.ElementLinkNode">
            <summary>
            Represents an ElementLink.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.RolePlayerNode">
            <summary>
            Represents a ModelElement playing a role in link.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.ModelingPerformanceCounters">
            <summary>
            Performance counters for the Microsoft.VisualStudio.Modeling namespace.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagnostics.ModelingPerformanceCounters.Enabled">
            <summary>
            Gets or sets whether modeling performance counters are enabled.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagnostics.ModelingPerformanceCounters.ElementCount">
            <summary>
            Gets ElementCount performance counter.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagnostics.ModelingPerformanceCounters.ElementLinkCount">
            <summary>
            Gets ElementLinkCount performance counter.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Diagnostics.ModelingPerformanceCounters.PropertiesInUse">
            <summary>
            Gets PropertiesInUse performance counter.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.PerformanceCountersEventHandler">
            <summary>
            Class to manage posting element creation and deletion events into the appropriate performance counters.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.PerformanceCountersEventHandler.OnElementAdded(System.Object,Microsoft.VisualStudio.Modeling.ElementAddedEventArgs)">
            <summary>
            Element added event handler.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.PerformanceCountersEventHandler.OnElementDeleted(System.Object,Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs)">
            <summary>
            Element deleted event handler.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.DomainDataDirectoryNode">
            <summary>
            Represents DomainDataDirectory of the Store.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.DomainModelNode">
            <summary>
            Represents a DomainModelInfo instance.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.DomainClassNode">
            <summary>
            Represents a DomainClassInfo instance.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.DomainRelationshipNode">
            <summary>
            Represents a DomainRelationshipInfo instance.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.DomainPropertyNode">
            <summary>
            Represents a DomainPropertyInfo instance.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.DomainRoleNode">
            <summary>
            Represents a DomainRoleInfo instance.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.RulesNode">
            <summary>
            A folder node for all rules attached to a DomainModelInfo or DomainClassInfo.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.RuleNode">
            <summary>
            Represents a rule.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer">
            <summary>
            Displays modeling store contents and details in a modal dialog.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.Show(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Shows Store Viewer dialog populated from the given store.
            </summary>
            <param name="store">Store to visualize.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.Show(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Shows Store Viewer dialog populated from the given partition.
            </summary>
            <param name="partition">Partition to visualize.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.Show(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Shows Store Viewer dialog populated from the given element.
            </summary>
            <param name="element">Element to visualize.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.OnKeyDown(System.Windows.Forms.KeyEventArgs)">
            <summary>
            Processes KeyDown event.
            </summary>
            <param name="e">Event arguments.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.contextMenuStrip1_Opening(System.Object,System.ComponentModel.CancelEventArgs)">
            <summary>
            Event handler when menu is about to be shown to the user.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.contextMenuStrip2_Opening(System.Object,System.ComponentModel.CancelEventArgs)">
            <summary>
            Event handler when menu is about to be shown to the user.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.contextMenuStrip3_Opening(System.Object,System.ComponentModel.CancelEventArgs)">
            <summary>
            Event handler when menu is about to be shown to the user.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.viewDomainPropertyToolStripMenuItem_Click(System.Object,System.EventArgs)">
            <summary>
            Eventh handler when user chooses to view the corresponding DomainProperty on a property on ModelElement.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.viewDomainDataDefinitionToolStripMenuItem_Click(System.Object,System.EventArgs)">
            <summary>
            Event handler when user choose the view the domain class
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.navigateToOppositeRolePlayerToolStripMenuItem_Click(System.Object,System.EventArgs)">
            <summary>
            Event handler when user choose the "Navigate to Opposite Role Player" menu.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.viewBaseDomainClassToolStripMenuItem_Click(System.Object,System.EventArgs)">
            <summary>
            Event handler when user chooses to show the DomainClass's base class.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.back_Click(System.Object,System.EventArgs)">
            <summary>
            Event handler when user clicks the "Back" button
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.forward_Click(System.Object,System.EventArgs)">
            <summary>
            Event handler when user clicks the "Forward" button
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.UpdateMoveBackForwardButtonStates">
            <summary>
            Method to disable/enable the MoveBack/Forward button. It will be based where this.historyPointer is among the history list.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.historyComboBox1_SelectedIndexChanged(System.Object,System.EventArgs)">
            <summary>
            Evenet handler when selection is changed in the combo box.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.components">
            <summary>
            Required designer variable.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.Dispose(System.Boolean)">
            <summary>
            Clean up any resources being used.
            </summary>
            <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Diagnostics.StoreViewer.InitializeComponent">
            <summary>
            Required method for Designer support - do not modify
            the contents of this method with the code editor.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.PropertyListItemInfo">
            <summary>
            Stores info for creation of a property list view item.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.LinkListViewItemInfo">
            <summary>
            Stores info for creation of a link list view item.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Diagnostics.Images">
            <summary>
            Images used in the model tree view.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureType">
            <summary>
            Enumeration describing what kind of closure to build
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ClosureType.CopyClosure">
            <summary>
            build a closure that is suitable for copy operations
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ClosureType.CopyShapeClosure">
            <summary>
            build a closure that is suitable for copy shape operations
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ClosureType.DeleteClosure">
            <summary>
            build a closure that is suitable for delete operations
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ClosureType.DeleteShapeClosure">
            <summary>
            build a closure that is suitable for delete shape operations
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementClosureWalker">
            <summary>
            Walker that builds closures on Model Elements
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker">
            <summary>
            Class to enable breadth first traversals of the model starting from a particular
            element or group of elements. This walker also guarantees that roleplayers of relationships
            are visited first before the relationship is visited.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementWalker">
            <summary>
            Class to enable various traversals of the model starting from a particular
            element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter)">
            <summary>
            Constructor that takes an ElementVisitor.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter,System.Boolean)">
            <summary>
            Constructor that takes an ElementVisitor.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
            <param name="includeLinks">request element links be included in the visitation</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.Reset">
            <summary>
            Reset the visitor so that it can start traversing again.  This is necessary
            to clear out the internal list of previously visited elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.MarkVisited(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Mark an element as having been already visited
            </summary>
            <param name="element">the element that was visited</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.Visited(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            determines if the given element has been visited or not
            </summary>
            <param name="element">the element in question</param>
            <returns>true if the element has already been visited</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.ShouldVisitLinkAgain(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            When looking at the related elements of the given currentElement, if we
            find a link that has been enqueued for visiting, this function will tell you if 
            it needs to be visited again. This is if the link has been visited before
            the currentElement (one of its roleplayers) was visited.
            
            For closure walkers, we guarantee that the link will be visited
            only after the roleplayers are visited (technically, we guarantee
            that the InternalElementList will contain the link after the roleplayers). 
            Consider this scenario: We have element A that is a roleplayer for 2 relationships
            AHasBs and CHasAs. During the closure traversal, A is first approached from B through 
            AHasBs. However, it does not have prop-delete on it, so it is not visited but the AHasBs
            is visited. Later in the traversal, A is approached from C via CHasAs. This time, A is 
            visited because it has prop-delete. Now we get a case where AHasBs was visited before
            one of its roleplayers (A) was visited. To fix this, if the walkers find that
            a link has been visited (or rather, been enqueued for visiting) , it should 
            check if it should be visited again (check if it was already visited before currentElement).
            If so, it should remove the link from the InternalElementList using the methods
            MarkForRemovalFromInternalElementList and RemoveMarkedElements, and add it to the 
            queue to be visited again.
            </summary>
            <param name="link">The link that was found to be already enqueued for visiting</param>
            <param name="currentElement">The current element whose related elements we are visiting</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.MarkForRemovalFromInternalElementList(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Mark an element for removal from the InternalElementList. We mark first and remove
            later at the end so that the indices remain valid.
            When marking elements as visited,
            we store an index in the hashtable which tells us the order that the element
            was visited in. If the elements were put into the InternalElementList in that order,
            we can find the element easily using the index. If not a linear search will be used
            to find the element.
            </summary>
            <param name="element"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.RemoveMarkedElements">
            <summary>
            Removes the elements that are marked for removal. Call this
            at the end of the traversal so that the indices in alreadyVisited
            remain valid.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.Traverse(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Traverse the model starting at the specified starting elements.
            </summary>
            <param name="rootElements">ICollection of ModelElements from which to start traversing</param>
            <returns>false if the traversal was terminated prematurely, otherwise true</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.Traverse(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Traverse the model starting at the specified starting element.
            </summary>
            <param name="rootElement">ModelElement from which to start traversing</param>
            <returns>false if the traversal was terminated prematurely, otherwise true</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementWalker.DoTraverse(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Traverse the model starting at the specified starting element.
            </summary>
            <param name="rootElement">ModelElement from which to start traversing</param>
            <returns>
            Returns true if the traversal completed fully.
            Returns false if the traversal was terminated prematurely by the visitor
            </returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementWalker.Visitor">
            <summary>
            Get or set the IElementVisitor for use during traversal
            </summary>
            <value>IElementVisitor</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementWalker.IncludeLinks">
            <summary>
            Returns true if the walker will include element links in calls to the visitor function
            </summary>
            <value>bool</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementWalker.BypassDemandLoading">
            <summary>
            Allows the walker to bypass demand loading while traversing
            </summary>
            <value>bool</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementWalker.Filter">
            <summary>
            Get or set the IElementVisitorFilter for use during traversal
            </summary>
            <value>IElementVisitorFilter</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementWalker.InternalElementList">
            <summary>
            Get the internal list of elements that will be visited
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementWalker.Store">
            <summary>
            Get the internal list of elements that will be visited
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter)">
            <summary>
            Constructor that takes an ElementVisitor.
            This defaults to depth first traversal, pre-Order visitation of the graph with no element links.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter,System.Boolean)">
            <summary>
            Constructor that takes an ElementVisitor.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
            <param name="includeLinks">request element links be included in the visitation</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.DoTraverse(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Traverse the model starting at the specified starting element.
            </summary>
            <param name="rootElement">ModelElement from which to start traversing</param>
            <returns>false if the traversal was terminated prematurely, otherwise true</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.PushElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Add an element to the queue
            </summary>
            <param name="e">the element to push</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.PopElement">
            <summary>
            pop the next element from the queue
            </summary>
            <returns>next element or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.AddElementAndLinks(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            add an element and its children to the list
            </summary>
            <param name="e"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.BreadthFirstRolePlayerFirstElementWalker.GetRelatedElements(Microsoft.VisualStudio.Modeling.ModelElement,System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.ModelElement}@,System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.ElementLink}@)">
            <summary>
            Get the list of related elements
            </summary>
            <param name="e">ModelElement to query for its related elements</param>
            <param name="elements">Elements that are related to e</param>
            <param name="elementLinks">ElementLinks that have e as a roleplayer</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to ignore propagate deleting settings for</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to ignore propagate deleting settings for</param>
            <param name="rootDomainRolesToNotVisit">List of DomainRoles to not visit on root elements. This list can be used to keep relationships from being included in the closure and traversed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Boolean)">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
            <param name="bypassDemandLoading">True to bypass demand-loading.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Boolean,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
            <param name="bypassDemandLoading">True to bypass demand-loading.</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to ignore propagate deleting settings for</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Boolean,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
            <param name="bypassDemandLoading">True to bypass demand-loading.</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to ignore propagate deleting settings for</param>
            <param name="rootDomainRolesToNotVisit">List of DomainRoles to not visit on root elements. This list can be used to keep relationships from being included in the closure and traversed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementClosureWalker.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Boolean,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Constructor that creates an ElementVisitor and calls base.  This results in breadth first traversal, pre-Order visitation of the graph with element links.
            </summary>
            <param name="partition">Partition.</param>
            <param name="type">ClosureType.</param>
            <param name="rootList">RootList.</param>
            <param name="bypassDemandLoading">True to bypass demand-loading.</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to ignore propagate deleting settings for</param>
            <param name="rootDomainRolesToNotVisit">List of DomainRoles to not visit on root elements. This list can be used to keep relationships from being included in the closure and traversed</param>
            <param name="elementsToNotVisit">List of elements to not visit</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementClosureWalker.Context">
            <summary>
            Offer a context object for general use by the closure visitors.  
            Use it to store tag/value pairs while building closures.
            </summary>
            <value>IDictionary</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementClosureWalker.ClosureList">
            <summary>
            Resultant List of elements that form the closure
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.IElementVisitor">
            <summary>
            Subclass this and implement the Visit function 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementVisitor.Visit(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            User defined Visit function. 
            </summary>
            <param name="walker">the walker that is currently traversing the model</param>
            <param name="element">ModelElement being visited</param>
            <returns> The ElementWalker object will continue to process as long
            as this function's return value is true.
            It will stop traversal early if this function's return value is false.
            </returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementVisitor.StartTraverse(Microsoft.VisualStudio.Modeling.ElementWalker)">
            <summary>
            Called when the traversal begins
            </summary>
            <param name="walker">the walker that is currently traversing the model</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementVisitor.EndTraverse(Microsoft.VisualStudio.Modeling.ElementWalker)">
            <summary>
            Called when the traversal is finished
            </summary>
            <param name="walker">the walker that is currently traversing the model</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.IElementVisitorFilter">
            <summary>
            Provides callback mechanism for filtering out which role players and which relationships should 
            be visited during traversal by an ElementWalker
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementVisitorFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element should be included in the traversal
            </summary>
            <param name="walker">the walker that is currently traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
            <param name="targetRelationship">Relationship in question</param>
            <returns>Yes if the relationship should be traversed</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementVisitorFilter.ShouldVisitRolePlayer(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called to ask the filter if a particular role player should be Visited during traversal
            </summary>
            <param name="walker">the walker that is currently traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
            <param name="targetDomainRole">Target domain role.</param>
            <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.VisitorFilterResult">
            <summary>
            VisitorFilterResult
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.VisitorFilterResult.DoNotCare">
            <summary>
            No preference whether the element will be added by others.
            If all visitors respond DoNotCare, then the element will not be visited.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.VisitorFilterResult.Yes">
            <summary>
            The element should be visited, but a Never result by another filter will override a yes
            and the element will be excluded from the closure.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.VisitorFilterResult.Never">
            <summary>
            The element will not be visited.  This value trumps all yes values.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker">
            <summary>
            Class to enable depth first traversals of the model starting from a particular
            element or group of elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter)">
            <summary>
            Constructor that takes an ElementVisitor.
            This defaults to depth first traversal, pre-Order visitation of the graph with no element links.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter,System.Boolean)">
            <summary>
            Constructor that takes an ElementVisitor.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
            <param name="includeLinks">request element links be included in the visitation</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.DoTraverse(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Traverse the model starting at the specified starting element.
            </summary>
            <param name="rootElement">ModelElement from which to start traversing</param>
            <returns>false if the traversal was terminated prematurely, otherwise true</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.GetRelatedElements(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get the list of related elements.  This list will be traversed in a depth-first fashion, 
            starting from the beginning, so the order of elements in the returned list is important.
            Derived classes may override this to specify a different set of related elements, or a different
            ordering within that set.
            
            The default implementation includes all model elements which aren't filtered out, followed by
            all links which aren't filtered out.
            </summary>
            <param name="element">ModelElement to query for its related elements</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.BeginTraverseElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Virtual method indicates the walker is about to traverse into the given element
            </summary>
            <param name="element">Element is about to be traversed.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.EndTraverseElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Virtual method indicates the walker is done with traversing into the given element
            </summary>
            <param name="element">Element which is just been traversed.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.VisitElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Add an element to the queue
            </summary>
            <param name="e">the element to push</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementWalker.VisitElementAndLinks(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            add an element and its children to the list
            </summary>
            <param name="e"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DepthFirstElementAndLinkWalker">
            <summary>
            Class to enable depth first traversals of the model starting from a particular
            element or group of elements.  Guarantees that elements and element links are
            visited in an interleaved fashion.  For instance:
            A
            | B (link)
            C
            | D (link)
            E
            
            would be visited in the order: A, B, C, D, E, assuming IncludeLinks=true.  Note that the
            DepthFirstElementWalker class only makes the depth-first guarantee for elements,
            so any traversal containing the elements A, C, E in order would be valid.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementAndLinkWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter)">
            <summary>
            Constructor that takes an ElementVisitor.
            This defaults to depth first traversal, pre-Order visitation of the graph with no element links.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementAndLinkWalker.#ctor(Microsoft.VisualStudio.Modeling.IElementVisitor,Microsoft.VisualStudio.Modeling.IElementVisitorFilter,System.Boolean)">
            <summary>
            Constructor that takes an ElementVisitor.
            </summary>
            <param name="visitor">IElementVisitor to use when traversing</param>
            <param name="filter">IElementVisitorFilter to use when traversing</param>
            <param name="includeLinks">request element links be included in the visitation</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DepthFirstElementAndLinkWalker.GetRelatedElements(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get the list of related elements
            </summary>
            <param name="element">ModelElement to query for its related elements</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.VisitorFilters">
            <summary>
            Class that returns various standard Visitor Filters
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.VisitorFilters.DefaultVisitorFilter">
            <summary>
            Default Visitor Filter visits everything
            </summary>
            <value>IElementVisitorFilter that will visit everything</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.VisitorFilters.AggregateVisitorFilter">
            <summary>
            Aggregate Visitor Filter visits related elements that are aggregates
            </summary>
            <value>IElementVisitorFilter that will visit aggregates</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.VisitorFilters.AncestorVisitorFilter">
            <summary>
            Ancestor Visitor Filter visits related elements that are Ancestors
            </summary>
            <value>IElementVisitorFilter that will visit Ancestors</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.VisitorFilters.PropagateDeleteVisitorFilter">
            <summary>
            Visitor Filter visits related elements that are require delete propagation
            </summary>
            <value>IElementVisitorFilter that will visit related elements that require</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DefaultVisitorFilter">
            <summary>
            Class that implements a IElementVisitorFilter that visits all aggregate relationships.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DefaultVisitorFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element 
            should be included in the traversal.  By default, return true;
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="sourceRoleInfo">DomainRoleInfo that the source element plays in the relationship</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
            <param name="targetRelationship">Element link that is being considered</param>
            <returns>Yes if the relationship should be traversed</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DefaultVisitorFilter.ShouldVisitRolePlayer(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called to ask the filter if a particular role's counterpart should be Visited during traversal.
            By default, return true;
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
            <param name="targetDomainRole">DomainRoleInfo of the target role</param>
            <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.PropagateDeleteVisitorFilter">
            <summary>
            Class that implements IElementVisitorFilter and visits all PropagateRemove relationships
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PropagateDeleteVisitorFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element is marked PropagateRemove 
            and should be included in the traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
            <param name="targetRelationship">Relationship in question</param>
            <returns>Yes if the relationship should be traversed</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PropagateDeleteVisitorFilter.ShouldVisitRolePlayer(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called to ask the filter if a particular role is marked PropagateRemove and the Role Player
            should be Visited during traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
            <param name="targetDomainRole">DomainRoleInfo of the target role</param>
            <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.AncestorVisitorFilter">
            <summary>
            Class that implements a IElementVisitorFilter that visits all aggregating relationships.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AncestorVisitorFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element is marked
            Aggregate and should be included in the traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
            <param name="targetRelationship">Relationship in question</param>
            <returns>Yes if the relationship should be traversed</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AncestorVisitorFilter.ShouldVisitRolePlayer(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called to ask the filter if a particular role's counterpart is marked Aggregate and the Role Player
            should be Visited during traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
            <param name="targetDomainRole">DomainRoleInfo of the target role</param>
            <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.EmbeddingVisitorFilter">
            <summary>
            Class that implements a IElementVisitorFilter that visits all embedding relationships.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.EmbeddingVisitorFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element is marked
            Aggregate and should be included in the traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
            <param name="targetRelationship">Relationship in question</param>
            <returns>true if the relationship should be traversed</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.EmbeddingVisitorFilter.ShouldVisitRolePlayer(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called to ask the filter if a particular role is marked Aggregate and the Role Player
            should be Visited during traversal
            </summary>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role</param>
            <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
            <param name="targetDomainRole">DomainRoleInfo of the target role</param>
            <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ChainingElementVisitorFilter">
            <summary>
            Standardized chaining visitor filter that takes a list of other filters to work on.
            </summary>
            <remarks>
            Can be used for copy, remove or other visitor filter implementations
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChainingElementVisitorFilter.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChainingElementVisitorFilter.AddFilter(Microsoft.VisualStudio.Modeling.IElementVisitorFilter)">
            <summary>
            Add a filter to the chain
            </summary>
            <param name="filter"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChainingElementVisitorFilter.ShouldVisitRelationship(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Called to ask the filter if a particular relationship from a source element should be included in the traversal.
            </summary>
            <remarks>
            Walk the chain asking each filter in turn until one returns that it cares.
            Generally this means that filters shoudl be added in ascending order of specificity.
            </remarks>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role.</param>
            <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship.</param>
            <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question.</param>
            <param name="targetRelationship">Relationship in question.</param>
            <returns>Yes if the relationship should be traversed, false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChainingElementVisitorFilter.ShouldVisitRolePlayer(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called to ask the filter if a particular role player should be Visited during traversal.
            </summary>
            <remarks>
            Walk the chain asking each filter in turn until one returns that it cares.
            Generally this means that filters shoudl be added in ascending order of specificity.
            </remarks>
            <param name="walker">ElementWalker that is traversing the model</param>
            <param name="sourceElement">Model Element playing the source role.</param>
            <param name="elementLink">Element Link that forms the relationship to the role player in question.</param>
            <param name="targetDomainRole">DomainRoleInfo of the target role.</param>
            <param name="targetRolePlayer">Model Element that plays the target role in the relationship.</param>
            <returns>Yes if the role player should be visited, false otherwise.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ChainingElementVisitorFilter.FilterChain">
            <summary>
            Filter chain
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Partition">
            <summary>
            Partition contains a logical grouping of elements
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
            <param name="store">The owning store</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.Finalize">
            <summary>
            Destructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.Dispose">
            <summary>
            Disposes the state of this object.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.RemoveContext(Microsoft.VisualStudio.Modeling.Context)">
            <summary>
            Method to remove a Context from the Partition
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.AddContext(Microsoft.VisualStudio.Modeling.Context)">
            <summary>
            Add context to partition
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean)">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <param name="bypassDemandLoading"></param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to Not Skip</param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to Not Skip</param>
            <param name="rootDomainRolesToNotVisit">List of DomainRoles to not visit on root elements. This list
            can be used to keep relationships from being included in the closure and traversed</param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <param name="bypassDemandLoading"></param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to Not Skip</param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <param name="bypassDemandLoading"></param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to Not Skip</param>
            <param name="rootDomainRolesToNotVisit">List of DomainRoles to not visit on root elements. This list
            can be used to keep relationships from being included in the closure and traversed</param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosureList(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Gets a closure list of the given type based on the given root element list
            </summary>
            <param name="rootElements">list of root elements that the closure will be based on</param>
            <param name="type">type of closure to form</param>
            <param name="bypassDemandLoading"></param>
            <param name="domainRolesToNotPropagate">List of DomainRoles to Not Skip</param>
            <param name="rootDomainRolesToNotVisit">List of DomainRoles to not visit on root elements. This list
            can be used to keep relationships from being included in the closure and traversed</param>
            <param name="elementsToNotVisit">List of elements to not visit</param>
            <returns>ICollection</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosurePrototypeGroup(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Creates an ElementGroupPrototype of the given closure type based on the given list of root Elements
            </summary>
            <param name="rootElements">collection of root elements</param>
            <param name="type">type of closure to build</param>
            <returns>ICollection that form the closure for copy</returns>
            <remarks>the element group prototype's DistinguishedElements list will be populated with the root elements list</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.GetClosurePrototypeGroup(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean)">
            <summary>
            Creates an ElementGroupPrototype of the given closure type based on the given list of root Elements
            </summary>
            <param name="rootElements">collection of root elements</param>
            <param name="type">type of closure to build</param>
            <param name="bypassDemandLoading">indicates whether to bypass demand loading while forming the closure</param>
            <returns>ICollection that form the closure for copy</returns>
            <remarks>the element group prototype's DistinguishedElements list will be populated with the root elements list</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Partition.FindByAlternateId(Microsoft.VisualStudio.Modeling.Store,System.Object)">
            <summary>
            Find a partition by its AlternateKey
            </summary>
            <param name="store">The store to find the partition</param>
            <param name="alternateId">The AlternateId of the partition</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.Id">
            <summary>
            The Id of this Partition.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.StateId">
            <summary>
            A StateId that defines what state this Partition object is in.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.AlternateId">
            <summary>
            The AlternateId is used in the  
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.DomainDataDirectory">
            <summary>
            Gets domain information directory of the Store this partition belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.ElementFactory">
            <summary>
            The ElementFactory for the model
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.ElementDirectoryImpl">
            <summary>
            Directory of elements contained within partition (internal implementation).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.ElementDirectory">
            <summary>
            Directory of elements contained within partition.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.Contexts">
            <summary>
            The Contexts that are referenced by the Partition.  The Dictionary keys
            are the IDs of the Contexts.  The Dictionary values are the Context instances.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.Store">
            <summary>
            The Store the Partition belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.IsReadOnly">
            <summary>
            Gets whether this partition is read-only.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.IsDirty">
            <summary>
            Indicates true when the Partition is in a dirty state.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Partition.DirtyCount">
            <summary>
            Indicates the number of changes to the Partition.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.PartitionDictionary">
            <summary>
            PartitionDictionary is a Dictionary collection of partitions with the Remove
            method overridden to also remove the partition from the store's PartitionAlternate
            collection.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionDictionary.Remove(System.Guid)">
            <summary>
            Remove method to also remove the partition from the store's PartitionAlternate collection
            </summary>
            <param name="partitionId">PartitionId of the partition being removed.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionDictionary.#ctor">
            <summary>
            Default constructor.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionDictionary.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainClassInfo">
            <summary>
            Represents a domain class.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainObjectInfo">
            <summary>
            Represents an element of domain model.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectInfo.GetAttribute``1">
            <summary>
            Gets attribute of specified type from the object's MemberInfo.
            </summary>
            <typeparam name="T">Type of the attribute to get.</typeparam>
            <returns>Attribute instance of null if not specified.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectInfo.ToString">
            <summary>
            Gets string representing of this object.
            </summary>
            <returns>The name of domain object.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectInfo.Id">
            <summary>
            Gets the ID of this domain object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectInfo.Name">
            <summary>
            Gets the name of this domain object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectInfo.DisplayName">
            <summary>
            Gets display name of this domain object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectInfo.DomainModel">
            <summary>
            Gets domain model this object belongs to.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.AddLocalDescendant(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Adds a class immediately derived from this domain class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.IsDerivedFrom(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Returns true if this domain class is derived from the specified domain class.
            </summary>
            <param name="domainClass">Base domain class in question.</param>
            <returns>True if this domain class is directly or indirectly derived from the specified domain class.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.IsDerivedFrom(System.Guid)">
            <summary>
            Returns true if this domain class is derived from the specified domain class specified.
            </summary>
            <param name="baseDomainClassId">The Id of base domain class in question.</param>
            <returns>True if this domain class is directly or indirectly derived from the specified domain class.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.AddDomainProperty(Microsoft.VisualStudio.Modeling.DomainPropertyInfo)">
            <summary>
            Adds a new domain property to this domain class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.FindDomainProperty(System.String,System.Boolean)">
            <summary>
            Finds a domain property defined in this domain class.
            </summary>
            <param name="propertyName">Property name to look for.</param>
            <param name="includeBaseClasses">Whether to search base classes as well.</param>
            <returns>DomainPropertyInfo if found and null otherwise.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.AddDomainRolePlayed(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Adds a new domain role played by this domain class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.AssignPlayedRoleIndexes">
            <summary>
            Assigns all domain roles played immediately by this domain class indexes
            to be used by RoleLinksCollection to store and find links for this role.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.ResetCachedRoleData(System.Boolean,System.Boolean)">
            <summary>
            Resets any data cached for roles played by this domain class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.FindEmbeddingElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Finds embedding container for this element.
            </summary>
            <returns>Element embedding this element or null if none found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.FindEmbeddingElementLink(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Finds embedding link for this element.
            </summary>
            <returns>Element link embedding this element or null if none found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasNameProperty(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets whether given element has name property defined in its domain class.
            </summary>
            <param name="element">Element to check.</param>
            <returns>True if element's domain class has element name property defined.</returns>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.TryGetName(Microsoft.VisualStudio.Modeling.ModelElement,System.String@)">
            <summary>
            Checks whether element has a name property and returns its value if so.
            </summary>
            <param name="element">Element.</param>
            <param name="name">Name property value.</param>
            <returns>True if element has name property and false otherwise.</returns>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.GetName(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets value of the element name property.
            </summary>
            <param name="element">Element.</param>
            <returns>Value of element name property..</returns>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
            <exception cref="T:System.InvalidOperationException">Element's domain class has no element name property defined.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.SetName(Microsoft.VisualStudio.Modeling.ModelElement,System.String)">
            <summary>
            Sets name property value on the element.
            </summary>
            <param name="element">Element.</param>
            <param name="name">Name property value to set.</param>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
            <exception cref="T:System.InvalidOperationException">Element's domain class has no element name property define;
            Operation is invoked outside of modeling transaction scope or other model constraints are not satisfied.
            </exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.SetUniqueName(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Assigns given element an unique name.
            </summary>
            <param name="element">Element to assign unique name.</param>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
            <exception cref="T:System.InvalidOperationException">Element's domain class has no element name property define;
            Operation is invoked outside of modeling transaction scope or other model constraints are not satisfied.
            </exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassInfo.SetUniqueName(Microsoft.VisualStudio.Modeling.ModelElement,System.String)">
            <summary>
            Assigns given element an unique name.
            </summary>
            <param name="element">Element to assign unique name.</param>
            <param name="baseName">Name to be used as a base for generating unique names.</param>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
            <exception cref="T:System.InvalidOperationException">Element's domain class has no element name property define;
            Operation is invoked outside of modeling transaction scope or other model constraints are not satisfied.
            </exception>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.DomainModel">
            <summary>
            Gets domain model this domain class belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.ImplementationClass">
            <summary>
            Gets implementation type of this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.IsValidationEnabled">
            <summary>
            Gets whether constraint validation is enabled for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.BaseDomainClass">
            <summary>
            Gets domain class this domain class inherits from.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.LocalDescendants">
            <summary>
            Gets a read-only list of domain classes immediately derived from this one.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.AllDescendants">
            <summary>
            Gets a read-only list of all domain classes directly or indirectly derived form this one.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.LocalDomainProperties">
            <summary>
            Gets a read-only list of domain properties declared in this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.AllDomainProperties">
            <summary>
            Gets a read-only list of domain properties declared on this domain class or one of its ascendants.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.DefaultDomainProperty">
            <summary>
            Gets the default property for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.NameDomainProperty">
            <summary>
            Gets element name property for this domain class, if it or one of its ascendants have defined one.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasCustomStoredProperties">
            <summary>
            Gets whether there are any custom stored properties declared in this domain class or one of its ascendants.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.LocalDomainRolesPlayed">
            <summary>
            Gets a read-only list of domain roles played by this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.AllDomainRolesPlayed">
            <summary>
            Gets a read-only list of all the domain roles played by this class or its ascendants.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.AllEmbeddedByDomainRoles">
            <summary>
            Gets a read-only list of domain roles which embed this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.ExternalRolesWereAdded">
            <summary>
            Gets or sets whether there were new roles added to this class during reflection
            of a model which was not reflected together with this class's model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasAddRulesSpecified">
            <summary>
            Gets whether there are any add rules specified for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasDeleteRulesSpecified">
            <summary>
            Gets whether ther eare any delete rules specified for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasDeletingRulesSpecified">
            <summary>
            Gets whether there are any deleting rules specified for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasChangeRulesSpecified">
            <summary>
            Gets whether there are any change rules specified for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.HasMoveRulesSpecified">
            <summary>
            Gets whether there are any move rules specified for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.AddRules">
            <summary>
            Gets a sorted list of add rules for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.DeleteRules">
            <summary>
            Gets a sorted list of delete rules for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.DeletingRules">
            <summary>
            Gets a sorted list of deleting rules for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.ChangeRules">
            <summary>
            Gets a sorted list of change rules for this domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassInfo.MoveRules">
            <summary>
            Gets a sorted list of move rules for this domain class.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainDataDirectory">
            <summary>
            Stores information about domain models loaded into the <see cref="T:Microsoft.VisualStudio.Modeling.Store"/>.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.Add(Microsoft.VisualStudio.Modeling.DomainObjectInfo)">
            <summary>
            Add a domain data object to this directory.
            </summary>
            <param name="domainObject">Domain object to add.</param>
            <exception cref="T:Microsoft.VisualStudio.Modeling.InvalidDomainModelException"/>
            <devdoc>
            Be careful changing this method - it's one of the most often called methods from
            DomainModelReflector and perf hit here will impact perf scenarios involving domain model
            loading/reflection operations.
            </devdoc>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainModel(System.String)">
            <summary>
            Finds domain model by full name.
            </summary>
            <param name="modelFullName">Full name of the model to look for.</param>
            <returns>DomainModelInfo with specified name or null if not found.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainModel(System.String)">
            <summary>
            Gets domain model by full name.
            </summary>
            <param name="modelFullName">Full name of the model to look for.</param>
            <returns>DomainModelInfo with specified name.</returns>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainClass(System.String)">
            <summary>
            Finds a domain class whose full name matches the given name.
            </summary>
            <param name="classFullName">Full name of domain class name to search for.</param>
            <returns>DomainClassInfo or null if not found</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainClass(System.String)">
            <summary>
            Gets domain class by full name.
            </summary>
            <param name="classFullName">Full name of the class to look for.</param>
            <returns>DomainClassInfo with specified name.</returns>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainRelationship(System.String)">
            <summary>
            Finds a domain relationship whose full name matches the given name.
            </summary>
            <param name="relationshipFullName">Full name of domain relationship to search for.</param>
            <returns>DomainRelationshipInfo or null if not found</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainRelationship(System.String)">
            <summary>
            Gets domain relationship by full name.
            </summary>
            <param name="relationshipFullName">Full name of the relationship to look for.</param>
            <returns>DomainRelationshipInfo with specified name.</returns>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainModel(System.Type)">
            <summary>
            Finds domain model by implementation type.
            </summary>
            <param name="type">Implementation type of the model to look for.</param>
            <returns>DomainModelInfo with specified type or null if not found.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainModel(System.Type)">
            <summary>
            Gets domain model by implementation type.
            </summary>
            <param name="type">Implementation type of the model to look for.</param>
            <returns>DomainModelInfo with specified Id.</returns>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainClass(System.Type)">
            <summary>
            Finds domain class by implementation type.
            </summary>
            <param name="type">Implementation type of the class to look for.</param>
            <returns>DomainClassInfo or null if not found.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainClass(System.Type)">
            <summary>
            Gets domain class by implementation type.
            </summary>
            <param name="type">Implementation type of the class to look for.</param>
            <returns>DomainClassInfo.</returns>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainRelationship(System.Type)">
            <summary>
            Finds domain relationship by implementation type.
            </summary>
            <param name="type">Implementation type of the relationship to look for.</param>
            <returns>DomainRelationshipInfo or null if not found.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainRelationship(System.Type)">
            <summary>
            Gets domain relationship by implementation type.
            </summary>
            <param name="type">Implementation type of the relationship to look for.</param>
            <returns>DomainRelationshipInfo.</returns>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.Contains(System.Guid)">
            <summary>
            Returns true when the directory contains an object with specified id.
            </summary>
            <param name="id">Id of the object to look for.</param>
            <returns>True if found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainModel(System.Guid)">
            <summary>
            Finds domain model by Id.
            </summary>
            <param name="id">Id of the model to look for.</param>
            <returns>DomainModelInfo with specified Id or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainModel(System.Guid)">
            <summary>
            Gets domain model by Id.
            </summary>
            <param name="id">Id of the model to look for.</param>
            <returns>DomainModelInfo with specified Id.</returns>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainClass(System.Guid)">
            <summary>
            Find a domain class by Id.
            </summary>
            <param name="id">Id of the class to look for.</param>
            <returns>DomainClassInfo or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainClass(System.Guid)">
            <summary>
            Gets domain class by Id.
            </summary>
            <param name="id">Id of the class to look for.</param>
            <returns>DomainClassInfo with specified Id.</returns>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainRelationship(System.Guid)">
            <summary>
            Find domain relationship by Id.
            </summary>
            <param name="id">Id of the relationship to look for.</param>
            <returns>DomainRelationshipInfo or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainRelationship(System.Guid)">
            <summary>
            Gets domain relationship by Id.
            </summary>
            <param name="id">Id of the relationship to look for.</param>
            <returns>DomainRelationshipInfo with specified Id.</returns>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainProperty(System.Guid)">
            <summary>
            Find domain property by Id.
            </summary>
            <param name="id">Id of the property to look for.</param>
            <returns>DomainPropertyInfo or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainProperty(System.Guid)">
            <summary>
            Gets domain property by Id.
            </summary>
            <param name="id">Id of the property to look for.</param>
            <returns>DomainPropertyInfo with specified Id.</returns>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.FindDomainRole(System.Guid)">
            <summary>
            Finds domain role by Id.
            </summary>
            <param name="id">Id of the role to look for.</param>
            <returns>DomainRoleInfo or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataDirectory.GetDomainRole(System.Guid)">
            <summary>
            Gets domain role by Id.
            </summary>
            <param name="id">Id of the role to look for.</param>
            <returns>DomainRoleInfo with specified Id.</returns>
            <exception cref="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainDataDirectory.DomainModels">
            <summary>
            Gets a read-only list domain models loaded into directory.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainDataDirectory.DomainClasses">
            <summary>
            Gets a read-only list domain classes loaded into directory.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainDataDirectory.DomainObjects">
            <summary>
            Gets a read-only list domain objects loaded into directory.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException">
            <summary>
            The exception that is thrown by the <see cref="T:Microsoft.VisualStudio.Modeling.DomainDataDirectory"/> class
            when domain object with requested identity is not found in the directory.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ModelingException">
            <summary>
            Comomn base class of specific exceptions thrown by the modeling engine.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelingException.#ctor">
            <summary>
            Initializes a new instance of the ModelingException class. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelingException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the ModelingException class with a specified error message. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelingException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the ModelingException class with a specified error message
            and a reference to the inner exception that is the cause of this exception. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
            <param name="innerException">
            The exception that is the cause of the current exception.
            If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. 
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelingException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the ModelingException class with serialized data. 
            </summary>
            <param name="info">The object that holds the serialized object data.</param>
            <param name="context">The contextual information about the source or destination.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException.#ctor">
            <summary>
            Initializes a new instance of the DomainDataNotFoundException class. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the DomainDataNotFoundException class with a specified error message. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the DomainDataNotFoundException class with a specified error message
            and a reference to the inner exception that is the cause of this exception. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
            <param name="innerException">
            The exception that is the cause of the current exception.
            If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. 
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainDataNotFoundException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the DomainDataNotFoundException class with serialized data. 
            </summary>
            <param name="info">The object that holds the serialized object data.</param>
            <param name="context">The contextual information about the source or destination.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainModel">
            <summary>
            Domain model instantiated in a <see cref="T:Microsoft.VisualStudio.Modeling.Store"/>.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.#ctor(Microsoft.VisualStudio.Modeling.Store,System.Guid)">
            <summary>
            Initializes a new instance of DomainModel class.
            </summary>
            <param name="store">The store that contains the domain model.</param>
            <param name="domainModelId">The Id of the domain model.</param>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:System.InvalidOperationException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.CreateElement(Microsoft.VisualStudio.Modeling.Partition,System.Type,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Creates an element of specified type.
            </summary>
            <param name="partition">Partition where element is to be created.</param>
            <param name="elementType">Element type which belongs to this domain model.</param>
            <param name="propertyAssignments">New element property assignments.</param>
            <returns>Created element.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.CreateElementLink(Microsoft.VisualStudio.Modeling.Partition,System.Type,Microsoft.VisualStudio.Modeling.RoleAssignment[],Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Creates an element link of specified type.
            </summary>
            <param name="partition">Partition where element is to be created.</param>
            <param name="elementLinkType">Element link type which belongs to this domain model.</param>
            <param name="roleAssignments">List of relationship role assignments for the new link.</param>
            <param name="propertyAssignments">New element property assignments.</param>
            <returns>Created element link.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetClosureFilter(Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Returns an IElementVisitorFilter that corresponds to the particular closure type.
            </summary>
            <param name="type">closure type</param>
            <param name="rootElements">collection of root elements</param>
            <returns>IElementVisitorFilter or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetClosureVisitor(Microsoft.VisualStudio.Modeling.ClosureType,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Returns an IElementVisitor that corresponds to the particular closure type.
            </summary>
            <param name="type">closure type</param>
            <param name="rootElements">collection of root elements</param>
            <returns>IElementVisitor or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetGeneratedDomainModelTypes">
            <summary>
            Gets the list of generated domain model types (classes, rules, relationships).
            </summary>
            <returns>List of types.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetCustomDomainModelTypes">
            <summary>
            Gets the list of non-generated domain model types.
            </summary>
            <returns>List of types.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetGeneratedDomainProperties">
            <summary>
            Gets the list of generated domain properties.
            </summary>
            <returns>List of property data.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetCustomDomainProperties">
            <summary>
            Gets the list of non-generated domain properties.
            </summary>
            <returns>List of property data.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetGeneratedDomainRoles">
            <summary>
            Gets the list of generated domain roles.
            </summary>
            <returns>List of role data.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetCustomDomainRoles">
            <summary>
            Gets the list of non-generated domain roles.
            </summary>
            <returns>List of role data.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.GetReflectionData(System.Type[]@,Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo[]@,Microsoft.VisualStudio.Modeling.DomainModel.DomainRolePlayerInfo[]@)">
            <summary>
            Gets data for DomainModelReflector to reflect this model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainModelInfo">
            <summary>
            Gets domain model information.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.Store">
            <summary>
            Gets the <see cref="T:Microsoft.VisualStudio.Modeling.Store"/> which contains this instance of domain model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.ResourceManager">
            <summary>
            Gets <see cref="T:System.Resources.ResourceManager"/> associated with this domain model.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo">
            <summary>
            Stores information used by domain model reflector to locate a domain property.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo.#ctor(System.Type,System.String,System.Guid,System.Type)">
            <summary>
            Initializes a new instance of DomainMemberInfo class.
            </summary>
            <param name="domainClassType">Type of the domain class that this field is bound to.</param>
            <param name="propertyName">Name of this field.</param>
            <param name="id">Guid of this field.</param>
            <param name="valueHandlerType">Type of the field handler for this attribute.</param>
            <exception cref="T:System.ArgumentException"/>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo.DomainClassType">
            <summary>
            Get domain class that owns declares the property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo.ValueHandlerType">
            <summary>
            Get the type of value handler for the property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo.Name">
            <summary>
            Get the name of the property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainMemberInfo.Id">
            <summary>
            Get the Id of the property.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainModel.DomainRolePlayerInfo">
            <summary>
            Stores information used by domain model reflector to locate a domain role.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModel.DomainRolePlayerInfo.#ctor(System.Type,System.String,System.Guid)">
            <summary>
            Initializes a new instance of DomainRolePlayerInfo class.
            </summary>
            <param name="relationshipType">Type of the relationship for this roleplayer attribute.</param>
            <param name="propertyName">name of this attribute.</param>
            <param name="id">Guid of this role.</param>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainRolePlayerInfo.DomainRelationshipType">
            <summary>
            Get domain relationship this role belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainRolePlayerInfo.PropertyName">
            <summary>
            Get the name of the property for this role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModel.DomainRolePlayerInfo.Id">
            <summary>
            Get the id of this role.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainModelInfo">
            <summary>
            Represents a domain model definition.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelInfo.AddDomainClass(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Add a new domain class to this domain model.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelInfo.AddDomainRelationship(Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            Add a new domain relationship to this domain model.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelInfo.AddBeginningRule(Microsoft.VisualStudio.Modeling.TransactionBeginningRule)">
            <summary>
            Adds a TransactionBeginningRule to this domain model.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelInfo.AddCommittingRule(Microsoft.VisualStudio.Modeling.TransactionCommittingRule)">
            <summary>
            Adds a TransactionCommittingRule to this domain model.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelInfo.AddRollingBackRule(Microsoft.VisualStudio.Modeling.TransactionRollingBackRule)">
            <summary>
            Adds a TransactionRollingBackRule to this domain model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.ImplementationType">
            <summary>
            Gets implementation type of this domain model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.DomainModel">
            <summary>
            Gets domain model this domain object belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.ExtendedDomainModels">
            <summary>
            Gets a read-only list of domain models this domain model extends.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.MonikerResolver">
            <summary>
            Gets moniker resolver instance for this domain model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.DomainModelInstance">
            <summary>
            Gets or sets the instance of domain model used to initialize resource manager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.DomainClasses">
            <summary>
            Gets a read-only list of domain classes defined in this domain model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.DomainRelationships">
            <summary>
            Gets a read-only list of domain relationships defined in this domain model.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.HasBeginningRules">
            <summary>
            Gets whether this domain model have any TransactionBeginningRules.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.HasCommittingRules">
            <summary>
            Gets whether this domain model have any TransactionCommittingRules.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainModelInfo.HasRollingBackRules">
            <summary>
            Gets whether this domain model have any TransactionRollingBackRules.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainModelReflector">
            <summary>
            Populates domain data directory by analyzing assembly meta-data.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelReflector.ReflectModels(Microsoft.VisualStudio.Modeling.Store,System.Collections.Generic.IEnumerable{System.Type})">
            <summary>
            Analyzes given DomainModel types.
            </summary>
            <param name="store">Store which models are created in.</param>
            <param name="domainModelTypes">List of class types derived from DomainModel class.</param>
            <exception cref="T:System.ArgumentException"/>
            <exception cref="T:System.ArgumentNullException"/>
            <exception cref="T:System.FormatException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.InvalidDomainModelException"/>
            <exception cref="T:Microsoft.VisualStudio.Modeling.InternalModelingErrorException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelReflector.VerifyInvalidEmbedding(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Verifies that each class has no more than one embedding role of mult. 1..1.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainModelReflector.CombineValidationStates(Microsoft.VisualStudio.Modeling.Validation.ValidationStateAttribute[],Microsoft.VisualStudio.Modeling.Validation.ValidationState)">
            <summary>
            Combine multiple ValidationStates
            </summary>
            <param name="stateAttributes"></param>
            <param name="defaultState"></param>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainObjectIdAttribute">
            <summary>
            This attribute is applied to domain model elements (classes, properties etc) to specify their unique ID.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectIdAttribute.#ctor(System.String)">
            <summary>
            Initializes a new instance of DomainObjectIdAttribute class.
            </summary>
            <param name="id">The GUID identifier for the domain object</param>
            <exception cref="T:System.ArgumentException"/>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectIdAttribute.Id">
            <summary>
            Gets the GUID identifier for the domain object.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainPropertyAttribute">
            <summary>
            Attribute class used to mark domain properties of domain classes (optional).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyAttribute.#ctor">
            <summary>
            Initializes a new instance of DomainPropertyAttribute class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyAttribute.Kind">
            <summary>
            Gets or sets domain property kind.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainPropertyInfo">
            <summary>
            Represents a property of a domain class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.SetValue(Microsoft.VisualStudio.Modeling.ModelElement,System.Object)">
            <summary>
            Sets property value on a given model element.
            </summary>
            <param name="element">Element to set value on.</param>
            <param name="value">Property value.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.GetValue(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets property value on a given model element.
            </summary>
            <param name="element">Element to get property on.</param>
            <returns>Property value on given element.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.NotifyValueChange(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Fire notifications (rules, events and OnValueChanging) to
            indicate a change in this value.
            </summary>
            <remarks>
            Only applicable to properties of Kind=Calculated.
            Designed to be used when a tracking property's source data is updated.
            </remarks>
            <param name="element"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.DomainClass">
            <summary>
            Gets domain class this property is declared in.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.DomainModel">
            <summary>
            Gets domain model where domain class of this property is defined.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.PropertyInfo">
            <summary>
            Gets CLR PropertyInfo of this domain property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.PropertyType">
            <summary>
            Gets CLR property type.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.DefaultValue">
            <summary>
            Gets default value of this domain property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.Kind">
            <summary>
            Gets the kind of this property.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.ValueHandler">
            <summary>
            Gets the property value handler for this property.
            </summary>
            <exception cref="T:Microsoft.VisualStudio.Modeling.InternalModelingErrorException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyInfo.ElementNameProvider">
            <summary>
            Gets unique name provider for this domain property or null if not specified.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainPropertyKind">
            <summary>
            Specifies domain property kind.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainPropertyKind.Normal">
            <summary>
            Regular domain property.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainPropertyKind.Calculated">
            <summary>
            Calculated domain property.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainPropertyKind.CustomStorage">
            <summary>
            Custom-stored domain property.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainRelationshipAttribute">
            <summary>
            Attribute class used to mark the domain relationships (optional).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipAttribute.#ctor">
            <summary>
            Initializes a new instance of DomainRelationshipAttribute class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipAttribute.AllowsDuplicates">
            <summary>
            Gets or sets whether domain relationship allows creating multiple instances between the same pair of elements.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipAttribute.IsEmbedding">
            <summary>
            Gets and sets whether domain object in the source role embeds domain objects in the target role.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo">
            <summary>
            Represents a domain relationship.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.AddDomainRole(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Adds a new domain role to this relationship.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.FindDomainRole(System.String)">
            <summary>
            Finds a domain role by its name (searches base relationships as well).
            </summary>
            <param name="roleName">Domain role name.</param>
            <returns>DomainRoleInfo if found and null otherwise.</returns>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.BaseDomainRelationship">
            <summary>
            Gets base domain relationship, if any.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.AllowsDuplicates">
            <summary>
            Gets whether it's allowed to have multiple instances of this domain relationship
            between the same pair of elements.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.IsEmbedding">
            <summary>
            Does the player of the source role logically contain the players of
            the target role in this relationship?
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.ValidateAllowsDuplicates">
            <summary>
            Gets whether explicit validation of AllowsDuplicates should be performed for this relationship.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.AllowsDuplicatesValidationRoot">
            <summary>
            Gets the top most base relationship in inheritance hierarchy which has AllowsDuplicates = false.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.DomainRoles">
            <summary>
            Gets a read-only list of domain roles.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.HasRolePlayerChangeRulesSpecified">
            <summary>
            Gets whether there are any RolePlayerChangeRule-s specified.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.HasRolePlayerPositionChangeRulesSpecified">
            <summary>
            Gets whether there are any RolePlayerPositionChangeRule specified..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.RolePlayerChangeRules">
            <summary>
            Gets a list of RolePlayerChangeRules.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRelationshipInfo.RolePlayerPositionChangeRules">
            <summary>
            Gets a list of RolePlayerPositionChangeRules.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainRoleAttribute">
            <summary>
            Attribute class used to mark the domain roles of a domain relationship.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.#ctor(Microsoft.VisualStudio.Modeling.DomainRoleOrder)">
            <summary>
            Initializes a new instance of DomainRoleAttribute class.
            </summary>
            <param name="order">Order of the role in relationship (Source or Target).</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.PropagatesDelete">
            <summary>
            Gets and sets whether delete operation on the model is propagated through this role to the opposite role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.PropagatesCopy">
            <summary>
            Gets and sets whether copy operation on the model is propagated through this role to the opposite role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.Multiplicity">
            <summary>
            Gets and sets the multiplicity of this role in domain relationship.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.PropertyName">
            <summary>
            Gets or sets name of property generated on the role player to access opposite role players.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.Order">
            <summary>
            Gets the order of domain role in domain relationship.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.RolePlayer">
            <summary>
            Gets or sets domain class playing this role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleAttribute.PropertyDisplayNameKey">
            <summary>
            Gets or sets the PropertyDisplayNameKey. It is used in accessing the resx file to retrieve the locaized string
            for displaying purpose
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainRoleInfo">
            <summary>
            Represents a role of a domain relationship.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IsDerivedFrom(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Gets whether this role is derived from a given domain role.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink,System.Guid)">
            <summary>
            Gets specified role player from a link.
            </summary>
            <param name="link">Element link.</param>
            <param name="domainRoleId">Domain role to get role player for.</param>
            <returns>Role player.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetSourceRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Gets the source role player for the given link
            </summary>
            <param name="link"></param>
            <returns>Source role player</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetTargetRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Gets the target role player for the given link
            </summary>
            <param name="link"></param>
            <returns>Target role player</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Gets link role player corresponding to this role.
            </summary>
            <param name="link">Element link.</param>
            <returns>Role player for this role.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink,System.Guid,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Sets specified role player on a link.
            </summary>
            <param name="link">Element link.</param>
            <param name="domainRoleId">Domain role to set role player for.</param>
            <param name="newRolePlayerElement">New role player.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Sets link role player corresponding to this role.
            </summary>
            <param name="link">Element link.</param>
            <param name="newRolePlayerElement">New role player for this role.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetRolePlayer(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            Internal method called by public SetRolePlayer and LinkedElementCollection indexer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetRolePlayerMoniker(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Gets link role player moniker corresponding to this role.
            </summary>
            <param name="link">Element link.</param>
            <returns>Role player moniker for this role.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetRolePlayerMoniker(Microsoft.VisualStudio.Modeling.ElementLink,System.Guid,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Sets specified role player on a link.
            </summary>
            <param name="link">Element link.</param>
            <param name="domainRoleId">Domain role to set role player for.</param>
            <param name="rolePlayerMoniker">New role player moniker for this role.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetRolePlayerMoniker(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Sets link role player moniker corresponding to this role.
            </summary>
            <param name="link">Element link.</param>
            <param name="rolePlayerMoniker">New role player moniker for this role.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetLinkedElement(Microsoft.VisualStudio.Modeling.ModelElement,System.Guid)">
            <summary>
            Gets the element linked to this element via 1..1 or 0..1 relationship.
            </summary>
            <param name="rolePlayerElement">Element playing a role.</param>
            <param name="domainRoleId">Role played by the element.</param>
            <returns>Element on the other side of relationship.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetLinkedElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets the element linked to this element via 1..1 or 0..1 relationship.
            </summary>
            <param name="rolePlayerElement">Element playing this role.</param>
            <returns>Element on the other side of relationship.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetLinkedElements(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets a list of elements linked to an element playing this role via this role's relationship.
            </summary>
            <param name="rolePlayerElement">Element playing this role.</param>
            <returns>List of elements playing opposite role in links the element partitipates in.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetLinkedElement(Microsoft.VisualStudio.Modeling.ModelElement,System.Guid,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Sets link role player on the other side of relationship.
            </summary>
            <param name="rolePlayerElement">Element playing a role.</param>
            <param name="domainRoleId">Role played by the element.</param>
            <param name="linkedElement">Element on the other side of relationship.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetLinkedElement(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Sets the element on the other side of relationship.
            </summary>
            <param name="rolePlayerElement">Element playing this role.</param>
            <param name="linkedElement">Element playing the opposite role in domain relationship.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetLinkedElement(Microsoft.VisualStudio.Modeling.ModelElement,System.Guid,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Sets link role player on the other side of relationship.
            </summary>
            <param name="rolePlayerElement">Element playing a role.</param>
            <param name="domainRoleId">Role played by the element.</param>
            <param name="moniker">Moniker on the other side of relationship.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.SetLinkedElement(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Sets the element on the other side of relationship.
            </summary>
            <param name="rolePlayerElement">Element playing this role.</param>
            <param name="moniker">Moniker playing the opposite role in domain relationship.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetAllElementLinks(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets a list of all element links given element participates in.
            </summary>
            <param name="rolePlayerElement">Element.</param>
            <returns>List of links connected to the element.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinks(Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            Gets element links where given element plays this role.
            </summary>
            <param name="rolePlayerElement">Element playing this role.</param>
            <param name="excludeDerivedRolesLinks">Whether to exclude links attached to derived role players.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinks(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets element links where given element plays this role.
            </summary>
            <param name="rolePlayerElement">Element playing this role.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinks``1(Microsoft.VisualStudio.Modeling.ModelElement,System.Guid)">
            <summary>
            Gets element links where given element plays a given role.
            </summary>
            <typeparam name="T">Type of link.</typeparam>
            <param name="rolePlayerElement">Element playing the role.</param>
            <param name="domainRoleId">Role played by the element.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinks``1(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets element links where given element plays this role.
            </summary>
            <typeparam name="T">Type of link.</typeparam>
            <param name="rolePlayerElement">Element playing this role.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinks``1(Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            Gets element links where given element plays this role.
            </summary>
            <typeparam name="T">Type of link.</typeparam>
            <param name="rolePlayerElement">Element playing this role.</param>
            <param name="excludeDerivedRolesLinks">Whether to exclude links attached to derived role players.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinksToElement(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get all element links between the given source/target elements, where the source element plays this role. Including links attached to derived role players.
            </summary>
            <param name="sourceRolePlayerElement">Source element playing this role.</param>
            <param name="targetRolePlayerElement">Target element.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinksToElement(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            Get all element links between the given source/target elements, where the source element plays this role.
            </summary>
            <param name="sourceRolePlayerElement">Source element playing this role.</param>
            <param name="targetRolePlayerElement">Target element.</param>
            <param name="excludeDerivedRolesLinks">Whether to exclude links attached to derived role players.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinksToElement``1(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get all element links between the given source/target elements, where the source element plays this role. Including links attached to derived role players.
            </summary>
            <typeparam name="T">Type of link.</typeparam>
            <param name="sourceRolePlayerElement">Source element playing this role.</param>
            <param name="targetRolePlayerElement">Target element.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainRoleInfo.GetElementLinksToElement``1(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            Get all element links between the given source/target elements, where the source element plays this role.
            </summary>
            <typeparam name="T">Type of link.</typeparam>
            <param name="sourceRolePlayerElement">Source element playing this role.</param>
            <param name="targetRolePlayerElement">Target element.</param>
            <param name="excludeDerivedRolesLinks">Whether to exclude links attached to derived role players.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.DomainRelationship">
            <summary>
            Gets the domain relationship that this domain role belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IsSource">
            <summary>
            Returns true if this is the source role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.StorageIndex">
            <summary>
            Gets or sets index of this domain role within domain relationship.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.OppositeDomainRole">
            <summary>
            Gets the domain role opposite this domain role in the domain relationship
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.BaseDomainRole">
            <summary>
            Gets base domain role for this role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.InheritanceDepth">
            <summary>
            Gets the depth of this role in inheritance chain.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IndexAtRolePlayer">
            <summary>
            Gets the index of this role at role player's role links collection.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.DomainModel">
            <summary>
            Gets domain model where domain relationship this role belongs to is defined.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.PropertyDisplayName">
            <summary>
            For the given model element, this method returns the property display name
            </summary>
            <returns>The localized PropertyDisplayName string. Note: null is returned if there's no 
            Named property PropertyDisplayNameKey specified in the DomainRoleAttribute </returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.LinkPropertyInfo">
            <summary>
            Gets the PropertyInfo for this domain role (this is the CLR property info field of this role).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.RolePlayer">
            <summary>
            Gets domain class that plays this role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.PropertyName">
            <summary>
            Gets name of the accessor property for this role on role player domain class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IsEmbedding">
            <summary>
            Does the player of this role logically contain the players of
            the other role(s) in this relationship?
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.PropagatesDelete">
            <summary>
            Gets whether element playing this role in a link will be deleted when the opposite
            role player element or the link itself is deleted.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.PropagatesCopy">
            <summary>
            Gets whether element playing this role in a link will be copied when the opposite
            role player element is copied.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.Multiplicity">
            <summary>
            Gets the multiplicity of this role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IsMany">
            <summary>
            Gets whether multiplicity is either 0..* or 1..*.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IsOne">
            <summary>
            Gets whether multiplicity is either 0..1 or 1..1.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainRoleInfo.IsOptional">
            <summary>
            Gets whether multiplicity is either 0..1 or 0..*.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainRoleOrder">
            <summary>
            Specifies order of a domain role in domain relationship.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainRoleOrder.Source">
            <summary>
            Source domain role.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DomainRoleOrder.Target">
            <summary>
            Target domain role.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ExtendsDomainModelAttribute">
            <summary>
            Attribute class used to specify the domain model the current domain model extends.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExtendsDomainModelAttribute.#ctor(System.String)">
            <summary>
            Initializes a new instance of ExtendsDomainModelAttribute class.
            </summary>
            <param name="extendedModelId">The Id (GUID) of extended domain model.</param>
            <exception cref="T:System.ArgumentException"/>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ExtendsDomainModelAttribute.ExtendedModelId">
            <summary>
            Gets the Id of the extended domain model.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.InvalidDomainModelException">
            <summary>
            The exception that is thrown when there was an error encountered during reflection of a domain model from assembly meta-data.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InvalidDomainModelException.#ctor">
            <summary>
            Initializes a new instance of the InvalidDomainModelException class. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InvalidDomainModelException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the InvalidDomainModelException class with a specified error message. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InvalidDomainModelException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the InvalidDomainModelException class with a specified error message
            and a reference to the inner exception that is the cause of this exception. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
            <param name="innerException">
            The exception that is the cause of the current exception.
            If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. 
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InvalidDomainModelException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the InvalidDomainModelException class with serialized data. 
            </summary>
            <param name="info">The object that holds the serialized object data.</param>
            <param name="context">The contextual information about the source or destination.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Multiplicity">
            <summary>
            Domain role multiplicity.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Multiplicity.ZeroMany">
            <summary>
            0..* multiplicity.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Multiplicity.One">
            <summary>
            1..1 multiplicity.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Multiplicity.ZeroOne">
            <summary>
            0..1 multiplicity.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Multiplicity.OneMany">
            <summary>
            1..* multiplicity.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ReflectionHelper">
            <summary>
            A set of methods to ease the use of .NET reflection API-s.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CalculatedPropertyValueHandler`2">
            <summary>
            Base class for calculated domain property handlers.
            </summary>
            <typeparam name="TElement">Type of element which owns the property.</typeparam>
            <typeparam name="TValue">Type of property value (property type).</typeparam>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2">
            <summary>
            Base class for strongly-typed domain property handlers.
            </summary>
            <typeparam name="TElement">Type of element which owns the property.</typeparam>
            <typeparam name="TValue">Type of property value (property type).</typeparam>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler">
            <summary>
            Base class for domain property value handlers.
            </summary>
            <devdoc>
            Methods on this class are to be used internally *only*.
            Constructor is internal so that nothing outside can inherit directly from here.
            </devdoc>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler.DomainPropertyId">
            <summary>
            Gets the Id of domain property supported by this handler.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.#ctor">
            <summary>
            Creates an instance of the DomainPropertyValueHandler class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.GetValue(`0)">
            <summary>
            Gets value of domain property on specified element.
            </summary>
            <param name="element">Element which owns the property.</param>
            <returns>Property value.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.ValueChanging(`0,`1,`1)">
            <summary>
            Called by SetValue before the value is changed to perform validation and raise OnValueChanging event.
            </summary>
            <param name="element">Element which owns the property.</param>
            <param name="oldValue">Current property value.</param>
            <param name="newValue">New property value.</param>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
            <exception cref="T:System.InvalidOperationException">Operation is invoked outside of modeling transaction scope
            or there was an attempt to set calculated property.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.OnValueChanging(`0,`1,`1)">
            <summary>
            Called when property value is about to change.
            </summary>
            <param name="element">Element which owns the property.</param>
            <param name="oldValue">Old value of the property.</param>
            <param name="newValue">New value of the property.</param>
            <example>
            protected override void OnValueChanging(ElementClassType element, FieldType oldValue, FieldType newValue)
            {
            	// call the base class implementation first
            	base.OnValueChanging(element, oldValue, newValue);
            	if (element.Store.InUndoRedoOrRollback)
            	{
            		// your undo/redo only code goes here
            		// you cannot make model changes here. 
            		// You can only change out-of-model state
            	}
            	else
            	{
            		// your non-undo/redo only code goes here
            		// All your model changes should be done here.
            		// You should not make any out-of-model state changes
            		// here because it will not be in sync after undo/redo
            	}
            	// your other code goes here
            	// you cannot make model changes here. You can only change 
            	// out-of-model state.
            }
            </example>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.SetValue(`0,`1)">
            <summary>
            Sets domain property value on specified element.
            </summary>
            <param name="element">Element which owns the property.</param>
            <param name="newValue">New property value to set.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.ValueChanged(`0,`1,`1)">
            <summary>
            Called by SetValue after the value has been changed to add transaction record and raise OnValueChanged event.
            </summary>
            <param name="element">Element which owns the property.</param>
            <param name="oldValue">Old value of the property.</param>
            <param name="newValue">New value of the property.</param>
            <exception cref="T:System.ArgumentNullException">element is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.OnValueChanged(`0,`1,`1)">
            <summary>
            Called after property value has been changed.
            </summary>
            <param name="element">Element which owns the property.</param>
            <param name="oldValue">Old value of the property.</param>
            <param name="newValue">New value of the property.</param>
            <example>
            protected override void OnValueChanged(ElementClassType element, FieldType oldValue, FieldType newValue)
            {
            	// call the base class implementation first
            	base.OnValueChanged(element, oldValue, newValue);
            	if (element.Store.InUndoRedoOrRollback)
            	{
            		// your undo/redo only code goes here
            		// you cannot make model changes here. 
            		// You can only change out-of-model state
            	}
            	else
            	{
            		// your non-undo/redo only code goes here
            		// All your model changes should be done here.
            		// You should not make any out-of-model state changes
            		// here because it will not be in sync after undo/redo
            	}
            	// your other code goes here
            	// you cannot make model changes here. You can only change 
            	// out-of-model state.
            }
            </example>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainPropertyValueHandler`2.InternalNotifyValueChange(`0,`1,`1)">
            <summary>
            Internal method to notify value change without checking if we're in undo/redo/rollback
            </summary>
            <remarks>
            Used by calculated properties and custom properties being used as tracking properties that are being reset.
            </remarks>
            <param name="element"></param>
            <param name="oldValue"></param>
            <param name="newValue"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CalculatedPropertyValueHandler`2.#ctor">
            <summary>
            Creates a new instance of the CalculatedPropertyValueHandler class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CalculatedPropertyValueHandler`2.SetValue(`0,`1)">
            <summary>
            Sets property value on an element.
            </summary>
            <param name="element">Element which owns the property.</param>
            <param name="newValue">New property value.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CalculatedPropertyValueHandler`2.NotifyValueChange(`0)">
            <summary>
            Fire notifications (rules, events and OnValueChanging) to
            indicate a change in the calculated value. 
            </summary>
            <param name="element"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CopyCommandImpl">
            <summary>
            Implementation of the ModelElement.Copy command.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyCommandImpl.RecursiveCopy(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Copies given element recursively via PropagateCopy settings on domain roles.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyCommandImpl.CreateElementCopy(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Creates a copy of a single element (without going into its links).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyCommandImpl.CreateElementLinkCopy(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a copy of a single element link (without going into its links).
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CoreDomainModel">
            <summary>
            Core domain model containing basic elements such as ModelElement and ElementLink.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.CoreDomainModel.DomainModelId">
            <summary>
            CoreDomainModel domain model Id.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CoreDomainModel.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Initializes a new instance of the CoreDomainModel class.
            </summary>
            <param name="store">Store containing the domain model.</param>
            <exception cref="T:System.ArgumentNullException">store is null.</exception>
            <exception cref="T:System.InvalidOperationException">An instance of this domain model already exists in the store.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CoreDomainModel.GetCustomDomainModelTypes">
            <summary>
            Gets the list of non-generated domain model types.
            </summary>
            <returns>List of types.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteCommandImplBase">
            <summary>
            Base class for delete command implementation.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteCommandImpl">
            <summary>
            Implementation of a regular delete command.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.UndoRedoClosureDeleteCommandImpl">
            <summary>
            Delete command implementation to be used for deleting element closure only in undo/redo context.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoRedoClosureDeleteCommandImpl.DeleteElements(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement},System.Boolean)">
            <summary>
            Deletes given elements and returns list of commands to be added to undo/redo stack/
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SetPropertyValueMode">
            <summary>
            Mode for internal SetValueAsObject method overload.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteState">
            <summary>
            Identifies whether the element is active, in the process of being deleted, or has been deleted.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DeleteState.Active">
            <summary>
            The element is active
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DeleteState.Deleting">
            <summary>
            The element is in the process of being deleted.
            This state is only valid while in the context of firing ElementDeletingRules
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.DeleteState.Deleted">
            <summary>
            The element has been deleted.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ModelElement">
            <summary>
            Base class (root of hierarchy) for all domain model elements.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.IMergeElements">
            <summary>
            Interface to allow ElementOperations classes in derived models to access protected merge functionality on a model element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMergeElements.CanMerge(Microsoft.VisualStudio.Modeling.ProtoElementBase,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Returns a value indicating whether the source element represented by the
            specified root ProtoElement can be added to this element.
            </summary>
            <param name="rootElement">
            The root ProtoElement representing a source element.  This can be null, 
            in which case the ElementGroupPrototype does not contain an ProtoElements
            and the code should inspect the ElementGroupPrototype context information.
            </param>
            <param name="elementGroupPrototype">
            The ElementGroupPrototype that contains the root ProtoElement.
            </param>
            <returns>
            true if the source element represented by the ProtoElement 
            can be added to this target element.
            </returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMergeElements.ChooseMergeTarget(Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Gets the ModelElement to be used as the target for the ElementGroupPrototype merge 
            process.  
            This is called by the merge process when this element is the target of the merge.  
            This provides this element with the opportunity to change the target to something 
            other than itself.
            </summary>
            <param name="elementGroupPrototype">The ElementGroupPrototype that will be reconstituted and merged with the target element.</param>
            <returns>The ModelElement to use as the target for the merge process.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMergeElements.ChooseMergeTarget(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Gets the ModelElement to be used as the target for the ElementGroup merge 
            process.  
            This is called by the merge process when this element is the target of the merge.  
            This provides this element with the opportunity to change the target to something 
            other than itself.
            </summary>
            <param name="elementGroup">The ElementGroup that will be merged with the target element.</param>
            <returns>The ModelElement to use as the target for the merge process.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMergeElements.MergeRelate(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Called by the Merge process to create a relationship between 
            this target element and the specified source element. 
            Typically, a parent-child relationship is established
            between the target element (the parent) and the source element 
            (the child), but any relationship can be established.
            </summary>
            <param name="sourceElement">The element that is to be related to this model element.</param>
            <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
            <remarks>
            Override this method to create the relationship between this
            target element and the specified source element.
            </remarks>
            <remarks>
            The base method does nothing.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMergeElements.MergeDisconnect(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Performs operation opposite to MergeRelate - i.e. disconnects a given
            element from the current one (removes links created by MergeRelate).
            </summary>
            <param name="sourceElement">Element to be unmerged/disconnected.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMergeElements.MergeConfigure(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Called by the Merge process to allow this model element 
            to configure itself immediately after the Merge process
            has related it to the target element.
            </summary>
            <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
            <remarks>
            Override this method to configure the element during
            the Merge process.
            </remarks>
            <remarks>
            The base method does nothing.
            </remarks>
            <remarks>
            The ElementGroupPrototype's Source and Target Context bags are available into the Top-Level Transaction's Context bag when this method is invoked.
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ModelElement.DomainClassId">
            <summary>
            Id of the ModelElement's domain class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Constructor.
            </summary>
            <param name="partition">Partition of the store where element is to be created.</param>
            <param name="propertyAssignments">New element property assignments.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.#ctor(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Internal constructor to be used by ElementLink ONLY.
            </summary>
            <param name="partition">Partition of the store where element is to be created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.GetDomainClass">
            <summary>
            Gets the most-derived domain class for this element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.OnRolePlayerPositionChanging(Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ElementLink,System.Int32,System.Int32)">
            <summary>
            Virtual method for notifying when role player position will be changing.
            </summary>
            <param name="sourceRole">Source role</param>
            <param name="link">Element link</param>
            <param name="oldPosition">old role player position</param>
            <param name="newPosition">new role player position</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.OnRolePlayerPositionChanged(Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ElementLink,System.Int32,System.Int32)">
            <summary>
            Virtual method for notifying when role player position has changed.
            </summary>
            <param name="sourceRole">Source role</param>
            <param name="link">Element link</param>
            <param name="oldPosition">old role player position</param>
            <param name="newPosition">new role player position</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.Delete">
            <summary>
            Deletes the element from the model.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.Delete(System.Guid[])">
            <summary>
            Deletes the element from the model.
            </summary>
            <param name="domainRolesToNotPropagate">A list of domain role ID-s through which delete should not be propagated.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.OnDeleting">
            <summary>
            Called by the model before the element is deleted.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.OnDeleted">
            <summary>
            Called by the model after the element has been deleted.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.Resurrect(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.PropertyAssignment})">
            <summary>
            Undo the deletion of the element.
            </summary>
            <returns>True if element was found and resurrected, false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.OnResurrected">
            <summary>
            Called by the model after the element has been resurrected (placed back into the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.Copy">
            <summary>
            Creates a copy of the element in the model.
            </summary>
            <returns>Copied model element.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.Copy(System.Collections.Generic.IEnumerable{System.Guid})">
            <summary>
            Creates a copy of the element in the model.
            </summary>
            <param name="domainRolesNotToPropagate">A list of domain role ID-s through which copy should not be propagated.</param>
            <returns>Copied model element.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.OnCopy(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called when a copy of the element has been created.
            The method is called on the duplicate element. 
            </summary>
            <param name="sourceElement">Element from which was duplicated.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.CanMerge(Microsoft.VisualStudio.Modeling.ProtoElementBase,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Returns a value indicating whether the source element represented by the
            specified root ProtoElement can be added to this element.
            </summary>
            <param name="rootElement">
            The root ProtoElement representing a source element.  This can be null, 
            in which case the ElementGroupPrototype does not contain an ProtoElements
            and the code should inspect the ElementGroupPrototype context information.
            </param>
            <param name="elementGroupPrototype">
            The ElementGroupPrototype that contains the root ProtoElement.
            </param>
            <returns>
            true if the source element represented by the ProtoElement 
            can be added to this target element.
            </returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.ChooseMergeTarget(Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Gets the ModelElement to be used as the target for the ElementGroupPrototype merge 
            process.  
            This is called by the merge process when this element is the target of the merge.  
            This provides this element with the opportunity to change the target to something 
            other than itself.
            </summary>
            <param name="elementGroupPrototype">The ElementGroupPrototype that will be reconstituted and merged with the target element.</param>
            <returns>The ModelElement to use as the target for the merge process.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.ChooseMergeTarget(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Gets the ModelElement to be used as the target for the ElementGroup merge 
            process.  
            This is called by the merge process when this element is the target of the merge.  
            This provides this element with the opportunity to change the target to something 
            other than itself.
            </summary>
            <param name="elementGroup">The ElementGroup that will be merged with the target element.</param>
            <returns>The ModelElement to use as the target for the merge process.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.MergeRelate(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Called by the Merge process to create a relationship between 
            this target element and the specified source element. 
            Typically, a parent-child relationship is established
            between the target element (the parent) and the source element 
            (the child), but any relationship can be established.
            </summary>
            <param name="sourceElement">The element that is to be related to this model element.</param>
            <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
            <remarks>
            Override this method to create the relationship between this
            target element and the specified source element.
            </remarks>
            <remarks>
            The base method does nothing.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.MergeDisconnect(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Performs operation opposite to MergeRelate - i.e. disconnects a given
            element from the current one (removes links created by MergeRelate).
            </summary>
            <param name="sourceElement">Element to be unmerged/disconnected.</param>
            <remarks>
            This base method does nothing.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelElement.MergeConfigure(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Called by the Merge process to allow this model element 
            to configure itself immediately after the Merge process
            has related it to the target element.
            </summary>
            <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
            <remarks>
            Override this method to configure the element during
            the Merge process.
            </remarks>
            <remarks>
            The base method does nothing.
            </remarks>
            <remarks>
            The ElementGroupPrototype's Source and Target Context bags are available into the Top-Level Transaction's Context bag when this method is invoked.
            </remarks>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelElement.Id">
            <summary>
            Unique identifier of this element.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelElement.Partition">
            <summary>
            Gets or sets the Partition instance that contains this element.	
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelElement.Store">
            <summary>
            Get the Store instance that contains this element.	
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelElement.IsActive">
            <summary>
            Returns true if the Element is currently active within the model,
            false if the element has been deleted or is in the process of being deleted.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelElement.IsDeleted">
            <summary>
            Has the element been deleted from the model.  (Deleted elements are not immediately
            destroyed so that the undo command may undo deleting the element.)
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelElement.IsDeleting">
            <summary>
            Has the element been deleted from the model.  (Deleted elements are not immediately
            destroyed so that the undo command may undo deleting the element.)
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.IElementDirectory">
            <summary>
            Directory of model elements contained within a store or partition.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.ContainsElement(System.Guid)">
            <summary>
            Gets whether element with the given ID present in directory.
            </summary>
            <param name="elementId">The Id of the element to be checked</param>
            <returns>True if the element is in the store, false otherewise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElement(System.Guid)">
            <summary>
            Gets an element with specified ID.
            </summary>
            <param name="elementId">The Id of the element to be retrieved</param>
            <returns>The element or null if it was not found</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.GetElement(System.Guid)">
            <summary>
            Get a particular element.
            </summary>
            <remarks>
            </remarks>
            <param name="elementId">The Id of the element for be retrieved</param>
            <returns>The element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElementLink(System.Guid)">
            <summary>
            Find a particular instance of a domain relationship.
            </summary>
            <remarks>
            </remarks><param name="linkId">The Id of the domain relationship instance</param>
            <returns>The domain relationship instance</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.GetElementLink(System.Guid)">
            <summary>
            Get a particular instance of a domain relationship.
            </summary>
            <param name="linkId">The Id of the domain relationship instance</param>
            <returns>The domain relationship instance</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.GetElements(System.Collections.Generic.IEnumerable{System.Guid})">
            <summary>
            Get the set of elements with ID's in a particular set.  
            </summary>
            <param name="elementIds">The set of ID's whose corresponding elements are to be returned</param>
            <returns>The set of elements</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElements(System.Guid)">
            <summary>
            Finds all elements in directory of specified domain class.
            </summary>
            <param name="domainClassId">Domain class Id.</param>
            <returns>List of elements found (empty list if no elements were found).</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElements(System.Guid,System.Boolean)">
            <summary>
            Finds all elements in directory of specified domain class.
            </summary>
            <param name="domainClassId">Domain class Id.</param>
            <param name="includeDescendants">Whether to include elements of all domain classes derived from given domain class.</param>
            <returns>List of elements found (empty list if no elements were found).</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElements(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Finds all elements in directory of specified domain class.
            </summary>
            <param name="domainClass">Domain class.</param>
            <returns>List of elements found (empty list if no elements were found).</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElements(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Boolean)">
            <summary>
            Finds all elements in directory of specified domain class.
            </summary>
            <param name="domainClass">Domain class.</param>
            <param name="includeDescendants">Whether to include elements of all domain classes derived from given domain class.</param>
            <returns>List of elements found (empty list if no elements were found).</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElements``1">
            <summary>
            Finds all elements in directory of specified type.
            </summary>
            <typeparam name="T">Type of elements.</typeparam>
            <returns>List of elements found (empty list if no elements were found).</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindElements``1(System.Boolean)">
            <summary>
            Finds all elements in directory of specified type.
            </summary>
            <typeparam name="T">Type of elements.</typeparam>
            <param name="includeDescendants">Whether to include elements of all domain classes derived from given domain class.</param>
            <returns>List of elements found (empty list if no elements were found).</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.ContainsDeletedElement(System.Guid)">
            <summary>
            Is the input elementId the id of an element in the set of
            deleted elements.
            </summary>
            <param name="elementId">The Id of to check</param>
            <returns>whether there is an element with that Id in the deleted element set</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.FindDeletedElement(System.Guid)">
            <summary>
            Get a particular element that has been deleted.
            </summary>
            <param name="elementId">The Id of the deleted element to be retrieved</param>
            <returns>the ModelElement or null if it was not found</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IElementDirectory.GetDeletedElement(System.Guid)">
            <summary>
            Get a particular element that has been deleted.
            </summary>
            <param name="elementId">The Id of the deleted element to be retrieved</param>
            <returns>the ModelElement or null if it was not found</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.IElementDirectory.AllElements">
            <summary>
            Gets a read-only collection of all elements in the directory.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.PartitionElementDirectory">
            <summary>
            The directory of the model's elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.Finalize">
            <summary>
            Finalizer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.Dispose">
            <summary>
            Disposes the state of this object.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.DisposeElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Disposes an element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.FindElementsImpl(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Boolean,System.Collections.IList)">
            <summary>
            Implementation of the FindElements method overloads.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.AddElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Adds element to element directory.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.MoveElement(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.PartitionElementDirectory)">
            <summary>
            Moves element to another dictionary.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.DeleteElement(Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>
            Remove the element from the internal collection and add it into the deleted collection.
            </summary>
            <param name="element">Element to be deleted.</param>
            <param name="isResurrectable">Whether element should be stored in deleted elements collection
            so that it can be resurrected later on.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.FindAndDisposeDeletedElement(System.Guid)">
            <summary>
            Disposes a deleted element and extract it from deleted elements collection.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PartitionElementDirectory.ResurrectElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Undo the deletion of an element.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.StoreElementDirectory">
            <summary>
            Element directory for the store.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementFactory">
            <summary>
            A factory of domain model objects.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementFactory.IdPropertyAssignment">
            <summary>
            This Guid is used to construct an Id property assignment which sets the element Id when a new ModelElement is created.
            Note that this property assignment must be the last one in the assignment list, and the value needs to be a valid Guid.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.#ctor(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Creates a new instance of the ElementFactory class.
            </summary>
            <param name="partition">The Partition that contains all the created objects.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElement(System.Guid)">
            <summary>
            Create a new element instance of specified type.
            </summary>
            <param name="domainClassId">Domain class ID of the object to be created.</param>
            <returns>The new element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElement(System.Guid,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Create a new element instance of specified type.
            </summary>
            <param name="domainClassId">Domain class ID of the object to be created.</param>
            <param name="propertyAssignments">List of property assignments to set immediately after element creation.</param>
            <returns>The new element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElement(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Create a new element instance of specified type.
            </summary>
            <param name="domainClass">Domain class of the object to be created.</param>
            <returns>The new element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElement(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Create a new element instance of specified type.
            </summary>
            <param name="domainClass">Domain class of the object to be created.</param>
            <param name="propertyAssignments">List of property assignments to set immediately after element creation.</param>
            <returns>The new element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElement(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.PropertyAssignment[],System.Guid)">
            <summary>
            Create a new element instance of specified type.
            </summary>
            <remarks>
            This version takes more arguments to be used internally in IMS - don't make it public.
            </remarks>
            <param name="domainClass">Domain class of the object to be created.</param>
            <param name="propertyAssignments">List of property assignments to set immediately after element creation.</param>
            <param name="existingId">Existing element ID, if any.</param>
            <returns>The new element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(System.Guid,Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a new element link.
            </summary>
            <param name="domainRelationshipId">Domain relationship ID of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <returns>The new element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(System.Guid,System.Boolean,Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a new element link.
            </summary>
            <param name="domainRelationshipId">Domain relationship ID of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <param name="bypassDemandLoading">Whether to bypass demand loading</param>
            <returns>The new element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(System.Guid,Microsoft.VisualStudio.Modeling.PropertyAssignment[],Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a new element link.
            </summary>
            <param name="domainRelationshipId">Domain relationship ID of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <param name="propertyAssignments">Initial attribute value assignments</param>
            <returns>The new element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a new element link.
            </summary>
            <param name="domainRelationship">Domain relationship of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <returns>The new element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,System.Boolean,Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a new element link.
            </summary>
            <param name="domainRelationship">Domain relationship of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <param name="bypassDemandLoading">Whether to bypass demand loading</param>
            <returns>The new element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.PropertyAssignment[],Microsoft.VisualStudio.Modeling.RoleAssignment[])">
            <summary>
            Creates a new element link.
            </summary>
            <param name="domainRelationship">Domain relationship of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <param name="propertyAssignments">Initial attribute value assignments</param>
            <returns>The new element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementFactory.CreateElementLink(Microsoft.VisualStudio.Modeling.DomainRelationshipInfo,Microsoft.VisualStudio.Modeling.RoleAssignment[],Microsoft.VisualStudio.Modeling.PropertyAssignment[],System.Boolean,System.Guid)">
            <summary>
            Creates a new element link.
            </summary>
            <remarks>
            This version takes more arguments to be used internally in IMS - don't make it public.
            </remarks>
            <param name="domainRelationship">Domain relationship of the link to be created.</param>
            <param name="roleAssignments">The elements playing roles in the domain relationship instance</param>
            <param name="propertyAssignments">Initial attribute value assignments</param>
            <param name="bypassDemandLoading">Whether to bypass demand loading</param>
            <param name="existingId">Existing element ID, if any.</param>
            <returns>The new element link</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementLink">
            <summary>
            Base class for model element links.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementLink.DomainClassId">
            <summary>
            ElementLink DomainClass Id.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLink.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.RoleAssignment[],Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Creates a new instance of the ElementLink class.
            </summary>
            <param name="partition">The Partition instance containing this ElementLink</param>
            <param name="roleAssignments">A set of role assignments for roleplayer initialization</param>
            <param name="propertyAssignments">A set of attribute assignments for attribute initialization</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLink.GetDomainRelationship">
            <summary>
            Gets domain relationship this ElementLink instantiates.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLink.MoveBefore(Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Move this link in the list of relationships contained by the
            element playing a particular role before a particular link
            in that relationship list.
            </summary>
            <param name="domainRole">The role of the element in which to move this link</param>
            <param name="successor">The link that is to follow this link</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLink.MoveToIndex(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Int32)">
            <summary>
            Move this link in the list of relationships contained by the
            element playing a particular role to a specified index
            in that relationship list.
            </summary>
            <param name="domainRole">The role of the element in which to move this link</param>
            <param name="index">The new index</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLink.OnRolePlayerChanging(Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement,System.Int32)">
            <summary>
            Called when the role player will be changing
            </summary>
            <param name="domainRole">DomainRoleInfo of the role that is changing</param>
            <param name="oldPlayer">the old role player</param>
            <param name="newPlayer">the new role player</param>
            <param name="linkIndex">the link index</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLink.OnRolePlayerChanged(Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement,System.Int32)">
            <summary>
            Called when the role player has be changed
            </summary>
            <param name="domainRole">DomainRoleInfo of the role that has changed</param>
            <param name="oldPlayer">the old role player</param>
            <param name="newPlayer">the new role player</param>
            <param name="linkIndex">the link index</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementLink.LinkedElements">
            <summary>
            Gets a read-only collection of elements connected by this element link.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementNameAttribute">
            <summary>
            This attribute is used to mark domain property as the element name property.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameAttribute.#ctor">
            <summary>
            Initializes an new instance of the ElementNameAttribute class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameAttribute.#ctor(System.Type)">
            <summary>
            Creates an instance of the ElementNameAttribute class.
            </summary>
            <param name="elementNameProvider">Type of element name provider class.</param>
            <exception cref="T:System.ArgumentException">elementNameProvider doesn't derive from ElementNameProvider class.</exception>
            <exception cref="T:System.ArgumentNullException">elementNameProvider is null.</exception>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementNameAttribute.ElementNameProvider">
            <summary>
            Gets element name provider type.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementNameProvider">
            <summary>
            Name provider for domain elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.#ctor">
            <summary>
            Initializes an new instance of the ElementNameProvider class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.SetUniqueName(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.String)">
            <summary>
            Sets unique name on an element.
            </summary>
            <param name="element">Element to assign an unique name.</param>
            <param name="container">Container embedding the element.</param>
            <param name="embeddedDomainRole">Role played by the element in embedding relationship.</param>
            <param name="baseName">String from which generated name should be derived.</param>
            <exception cref="T:System.ArgumentNullException">element, container or embeddedDomainRole is a null reference.</exception>
            <exception cref="T:System.InvalidOperationException">When called outside of modeling transaction context,
            name property is calculated or other modeling constraints are not satisfied.</exception>
            <exception cref="T:System.NotSupportedException">There are more than <see cref="F:System.UInt64.MaxValue"/> elements in container.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.GetSiblings(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Get a list of sibling elements for a given container and embedded role ID. It will exclude the excludedElement among the list
            The siblings will only include those elements that posess the name property associated with this element name provider.
            </summary>
            <param name="container">Embedding element.</param>
            <param name="embeddedDomainRole">Domain role played by elements embedded by container.</param>
            <param name="excludedElement">Element to be excluded from the search (can be null).</param>
            <returns>IList of siblings elements</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.GetSiblingLinks(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Gets a list of element links that have the name property associated with this name provider, 
            and which connected at given role to the given role player.
            </summary>
            <param name="rolePlayer">Element links are connected to.</param>
            <param name="domainRole">Role played by the rolePlayer in links.</param>
            <param name="excludedLink">Link to be excluded from the search (can be null).</param>
            <returns>Dictionary where keys are all unique names and values are first found link for a given name.</returns>
            <exception cref="T:System.ArgumentNullException">rolePlayer or domainRole is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.GetElementNames(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets map of all unique element names to elements for a given container and embedded role ID.
            The map will only include elements that have the name property with which this name provider is associated.
            </summary>
            <param name="container">Embedding element.</param>
            <param name="embeddedDomainRole">Domain role played by elements embedded by container.</param>
            <param name="excludedElement">Element to be excluded from the search (can be null).</param>
            <returns>Dictionary where keys are all unique names and values are first found element for a given name.</returns>
            <exception cref="T:System.ArgumentNullException">contianer or embeddedDomainRole is null.</exception>
            <exception cref="T:System.NotSupportedException">GetElementNames only works for DomainProperty is of type string.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.SetUniqueName(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.String)">
            <summary>
            Sets unique name on an element link if it's not already unique (and not the base name)
            </summary>
            <param name="link">Element link to assign an unique name.</param>
            <param name="indexingDomainRole">Domain role at which link names are indexed (unique among sibling links).</param>
            <param name="baseName">String from which generated name should be derived.</param>
            <exception cref="T:System.ArgumentNullException">link or embeddedDomainRole is a null reference.</exception>
            <exception cref="T:System.InvalidOperationException">When called outside of modeling transaction context,
            name property is calculated or other modeling constraints are not satisfied.</exception>
            <exception cref="T:System.NotSupportedException">There are more than <see cref="F:System.UInt64.MaxValue"/> elements in container.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.GetLinkNames(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Gets a map of element link name -&gt; element link for links connected at given role to the given role player.
            The map will only include links that have the name property with which this name provider is associated.
            </summary>
            <param name="rolePlayer">Element links are connected to.</param>
            <param name="domainRole">Role played by the rolePlayer in links.</param>
            <param name="excludedLink">Link to be excluded from the search (can be null).</param>
            <returns>Dictionary where keys are all unique names and values are first found link for a given name.</returns>
            <exception cref="T:System.ArgumentNullException">rolePlayer or domainRole is null.</exception>
            <exception cref="T:System.NotSupportedException">GetLinkNames method only works for DomainProperty is of type string.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementNameProvider.CustomSetUniqueNameCore(Microsoft.VisualStudio.Modeling.ModelElement,System.String,System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Sets unique name on the element given base name and list of sibling model elements. 
            </summary>
            <param name="element">Element to set name for.</param>
            <param name="baseName">Base name from which unique name is to be derived.</param>
            <param name="siblings">List of sibling elements which can be used to make the name unique. The list does not include the passed element.</param>
            <exception cref="T:System.NotSupportedException">DomainProperty is not of type string, please override this method to set unique name on the given model element..</exception>
        </member>
        <!-- Badly formed XML comment ignored for member "M:Microsoft.VisualStudio.Modeling.ElementNameProvider.SetUniqueNameCore(Microsoft.VisualStudio.Modeling.ModelElement,System.String,System.Collections.Generic.IDictionary{System.String,Microsoft.VisualStudio.Modeling.ModelElement})" -->
        <member name="P:Microsoft.VisualStudio.Modeling.ElementNameProvider.DomainProperty">
            <summary>
            Gets element name domain property managed by this ElementNameProvider.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1">
            <summary>
            Strongly typed collection for storing opposite element instances for a relationship
            in which a particular element participates.
            </summary>
            <typeparam name="T">Type type of target (opposite) element of domain relationship.</typeparam>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1">
            <summary>
            Read-only strongly typed collection for storing opposite element instances for a relationship
            in which a particular element participates.
            </summary>
            <typeparam name="T">Type type of target (opposite) element of domain relationship.</typeparam>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,System.Guid)">
            <summary>
            Creates an instance of the LinkedElementCollection class.
            </summary>
            <param name="sourceRolePlayer">Element which holds the links collection.</param>
            <param name="sourceRoleId">Domain role Id of the source element in domain relationship.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.#ctor(Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection{`0})">
            <summary>
            Copy constructor (to be used by ToReadOnly method of LinkedElementCollection).
            </summary>
            <param name="other">Collection to copy settings from.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.#ctor">
            <summary>
            Protected constructor to be used for data binding.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.ToArray">
            <summary>
            Creates an array and copies all role players in collection into it.
            </summary>
            <returns>Array of all role players.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.CheckItemType(System.Object,System.Boolean)">
            <summary>
            Checks that given item is compatible with the type of this collection elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Find(System.Predicate{`0})">
            <summary>
            Finds first element in collection which matches given condition.
            </summary>
            <param name="match">Condition.</param>
            <returns>First element from collection for which predicate returns true or null if no such element exists.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.FindAll(System.Predicate{`0})">
            <summary>
            Finds all elements which satisfy a given condition.
            </summary>
            <param name="match">Condition.</param>
            <returns>List of elements for which predicate returns true.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.FindIndex(System.Predicate{`0})">
            <summary>
            Finds first element which satisfies a given condition.
            </summary>
            <param name="match">Condition.</param>
            <returns>First element in the list for which the predicate returns true or null if none found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Exists(System.Predicate{`0})">
            <summary>
            Returns true if there's at least one element for which a given condition is true.
            </summary>
            <param name="match">Condition.</param>
            <returns>True if there's an element in collection for which predicate returns true.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.TrueForAll(System.Predicate{`0})">
            <summary>
            Retursn true if a given condition is true for all elements in collection.
            </summary>
            <param name="match">Condition.</param>
            <returns>True if predicate returned true for all elements or if collection is empty.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.ForEach(System.Action{`0})">
            <summary>
            Runs specified action on all elements in collection.
            </summary>
            <param name="action">Action.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.IndexOf(`0)">
            <summary>
            Gets the index of a role player inside collection.
            </summary>
            <param name="item">Role player to look for.</param>
            <returns>Index of the role player inside collection or -1 if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Contains(`0)">
            <summary>
            Gets whether a specified role player belongs to the collection.
            </summary>
            <param name="item">Role player to look for.</param>
            <returns>True if role player is found in collection and false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.CopyTo(`0[],System.Int32)">
            <summary>
            Copies all role players to the given array.
            </summary>
            <param name="array">Array to copy to.</param>
            <param name="arrayIndex">Index inside array where first element will be copied.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.GetEnumerator">
            <summary>
            Gets strongly-typed enumerator for this collection.
            </summary>
            <returns>ElementCollection enumerator.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.SourceElement">
            <summary>
            Gets the source role player which originates this collection.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.SourceDomainRole">
            <summary>
            Gets source role of the relationship this collection represents.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.TargetDomainRole">
            <summary>
            Gets taregt role of the relationship this collection represents.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Item(System.Int32)">
            <summary>
            Gets or sets role player at specified index inside collection.
            </summary>
            <param name="index">Index of the role player.</param>
            <returns>Role player at specified index.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Count">
            <summary>
            Gets the number of role players in collection.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Enumerator">
            <summary>
            Strongly-typed enumerator for ElementCollection class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Enumerator.MoveNext">
            <summary>
            Moves to the next role player in collection.
            </summary>
            <returns>True if operation succeeded and false if end of collection has been reached.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Enumerator.Reset">
            <summary>
            Moves enumerator to the beginning of collection.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.Enumerator.Current">
            <summary>
            Gets currently selected role player.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ReadOnlyLinkedElementCollection`1.DebugView">
            <summary>
            Debugger collection visualizer.
            Displays element collection as a plain list of elements in it.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,System.Guid)">
            <summary>
            Creates an instance of the LinkedElementCollection class.
            </summary>
            <param name="sourceRolePlayer">Element which holds the links collection.</param>
            <param name="sourceRoleId">Domain role Id of the source element in domain relationship.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.#ctor">
            <summary>
            Protected constructor to be used for data binding.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.AsReadOnly">
            <summary>
            Gets a read-only collection synchronized to this one.
            </summary>
            <returns>Read-only collection of role players.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Sort">
            <summary>
            Sorts the elements in the entire linked element collection.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Sort(System.Comparison{`0})">
            <summary>
            Sorts the elements in the entire linked element collection using the specified System.Comparison&lt;T&gt;.
            </summary>
            <param name="comparison">The System.Comparison&lt;T&gt; to use when comparing elements.</param>
            <exception cref="T:System.ArgumentNullException">comparison is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Sort(System.Collections.Generic.IComparer{`0})">
            <summary>
            Sorts the elements in the entire linked element collection using the specified comparer.
            </summary>
            <param name="comparer">The System.Collections.Generic.IComparer&lt;T&gt; implementation to use when comparing.
            elements, or null to use the default comparer System.Collections.Generic.Comparer&lt;T&gt;.Default.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Sort(System.Int32,System.Int32,System.Collections.Generic.IComparer{`0})">
            <summary>
            Sorts the elements in a range of the linked element collection using the specified comparer.
            </summary>
            <param name="index">The zero-based starting index of the range to sort.</param>
            <param name="count">The length of the range to sort.</param>
            <param name="comparer">The System.Collections.Generic.IComparer&lt;T&gt; implementation to use when comparing.
            elements, or null to use the default comparer System.Collections.Generic.Comparer&lt;T&gt;.Default.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Sort(System.Int32,System.Int32,Microsoft.VisualStudio.Modeling.LinkedElementCollection{`0}.LinkedElementComparer)">
            <summary>
            Sorts element links in a given range using given linked element comparer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.AddRange(System.Collections.Generic.IEnumerable{`0})">
            <summary>
            Appends a range of elements to the end of collection.
            </summary>
            <param name="collection">Elements to append.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.InsertRange(System.Int32,System.Collections.Generic.IEnumerable{`0})">
            <summary>
            Inserts a range of elements into collection at given index.
            </summary>
            <param name="index">Index of first inserted element.</param>
            <param name="collection">Elements to insert.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.RemoveRange(System.Int32,System.Int32)">
            <summary>
            Removes a range of elements from collection.
            </summary>
            <param name="index">Index of the first element to remove.</param>
            <param name="count">Number of elements to remove.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.ReplaceAt(System.Int32,`0)">
            <summary>
            Replaces a role player at specified index with the given one.
            </summary>
            <param name="index">Index inside collection bounds.</param>
            <param name="item">A new role player to be placed at the given index.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Move(`0,System.Int32)">
            <summary>
            Moves role player to a new position inside the collection.
            </summary>
            <param name="item">Role player to be moved.</param>
            <param name="newIndex">New index of the role player inside collection.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Move(System.Int32,System.Int32)">
            <summary>
            Moves role player to a new position inside the collection.
            </summary>
            <param name="oldIndex">Current index of the role player inside collection.</param>
            <param name="newIndex">New position of the role player inside collection.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Insert(System.Int32,`0)">
            <summary>
            Inserts role player into collection at specified index.
            </summary>
            <param name="index">Index at which role player is to be inserted.</param>
            <param name="item">Role player to be inserted.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.RemoveAt(System.Int32)">
            <summary>
            Removes role player at specified index from collection.
            </summary>
            <param name="index">Index of role player inside collection.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Add(`0)">
            <summary>
            Appends a new role player to the end of collection.
            </summary>
            <param name="item">Role player to append.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Clear">
            <summary>
            Removes all role players from collection.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Remove(`0)">
            <summary>
            Removes specified role player from collection.
            </summary>
            <param name="item">Role player to remove.</param>
            <returns>True if role player was actually found and deleted and 
            false if role player wasn't found in collection.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.Item(System.Int32)">
            <summary>
            Gets or sets role player at specified index inside collection.
            </summary>
            <param name="index">Index of the role player.</param>
            <returns>Role player at specified index.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.LinkedElementCollection`1.LinkedElementComparer">
            <summary>
            Compares element links via comparing elements at target role using given comparison method.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Moniker">
            <summary>
            Moniker contains an expression used to map to its element.
            The MonikerName must be unique and represent only one element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.#ctor(Microsoft.VisualStudio.Modeling.MonikerKey,Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
            <param name="monikerKey">monikerKey used to resolve moniker</param>
            <param name="store">Store that the Moniker is created in</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.#ctor(System.String,System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
            <param name="monikerName">string reference used to resolve moniker</param>
            <param name="domainRelationshipId">Id of the DomainRelationship this moniker will participate in.</param>
            <param name="domainClassId">DomainClassId of the model element this moniker will resolve to.</param>
            <param name="store">Store the Moniker is created in</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.Resurrect">
            <summary>
            Resurrect this moniker.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.Delete">
            <summary>
            Remove the moniker
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.Resolve">
            <summary>
            Resolves the Moniker to its element
            </summary>
            <returns>The element of the Moniker</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.ConnectElement">
            <summary>
            Connects the element represented by this moniker to the element link
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.DisconnectElement">
            <summary>
            Disconnects the element represented by this moniker to the element link
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.CompareTo(Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Compares two Monikers based upon their Id
            </summary>
            <param name="other">Moniker being compared to</param>
            <returns>A 32-bit signed integer that indicates the relative order of the comparands.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Moniker.Equals(Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Compares two Monikers based upon their ID to determine if they are equal
            </summary>
            <param name="moniker">Moniker being compared to</param>
            <returns>Boolean that indicates if the two Monikers are equal.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Id">
            <summary>
            The Id of this Moniker.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Key">
            <summary>
            The key of the Moniker
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.MonikerName">
            <summary>
            The name of the Moniker
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Store">
            <summary>
            The Store that the Moniker is created within.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.DomainModelFullName">
            <summary>
            The name of the DomainModel that the element represented by this Moniker resides in.
            This is used to find the MonikerResolver.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.DomainRelationshipInfo">
            <summary>
            The DomainRelationshipInfo this moniker participates in
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.DomainClassInfo">
            <summary>
            The DomainClassInfo of the DomainClass that this moniker should resolve to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Resolved">
            <summary>
            Set/Get moniker resolve state
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.ModelElement">
            <summary>
            The model element the moniker resolves to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Link">
            <summary>
            Gets or sets the link which contains role player for this moniker.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Location">
            <summary>
            Even though a Moniker is a concept in the model that doesn't tie to a physical location in serialized format, it is usually
            used in serialization/deserialization. The location of the moniker in the serialized format can greatly help analyze problems
            with unresolved monikers, so we store the location of where the moniker is stored in serialized format.
            The location is optional, and can be null if not available (e.g. Moniker created in memory).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Line">
            <summary>
            Even though a Moniker is a concept in the model that doesn't tie to a physical location in serialized format, it is usually
            used in serialization/deserialization. The location of the moniker in the serialized format can greatly help analyze problems
            with unresolved monikers, so we store the line number of where the moniker is stored in serialized format.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Moniker.Column">
            <summary>
            Even though a Moniker is a concept in the model that doesn't tie to a physical location in serialized format, it is usually
            used in serialization/deserialization. The location of the moniker in the serialized format can greatly help analyze problems
            with unresolved monikers, so we store the column number of where the moniker is stored in serialized format.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MonikerKey">
            <summary>
            MonikerKey is a class representing the key of a moniker.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerKey.#ctor(System.String,System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
            <param name="monikerName">MonikerName used to resolve moniker</param>
            <param name="domainRelationshipId">Id of the DomainRelationship this moniker will participate in.</param>
            <param name="domainClassId">Id of the DomainClass of the ModelElement that this moniker will resolve to.</param>
            <param name="store">Store the MonikerKey is created in</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerKey.CompareTo(Microsoft.VisualStudio.Modeling.MonikerKey)">
            <summary>
            Compares two MonikerKeys
            </summary>
            <param name="other">MonikerKey being compared to</param>
            <returns>A 32-bit signed integer that indicates the relative order of the comparands.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerKey.Equals(Microsoft.VisualStudio.Modeling.MonikerKey)">
            <summary>
            Compares two MonikerKeys
            </summary>
            <param name="monikerKey">MonikerKey being compared to</param>
            <returns>Boolean that indicates if the two MonikerKeys are equal.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerKey.MonikerName">
            <summary>
            The name of the Moniker
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerKey.DomainRelationshipId">
            <summary>
            The DomainClassId of the relationship this Moniker participates in.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerKey.DomainClassId">
            <summary>
            The DomainClassId of the element that this Moniker will resolve to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerKey.HumanReadableKey">
            <summary>
            Create a human-readable stringized version of a moniker key
            </summary>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.IMonikerResolver">
            <summary>
            MonikerResolver is used to resolve a Moniker to its element
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMonikerResolver.ResolveMoniker(Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Method to resolve a moniker to one or more elements
            </summary>
            <param name="moniker">Moniker to be resolved</param>
            <returns>Element that the Moniker represents</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMonikerResolver.CreateMoniker(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Method to create a Moniker for an element
            </summary>
            <param name="modelElement">modelElement to be monikerized</param>
            <returns>Moniker representing the element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.IMonikerResolver.CreateMonikerForToken(System.Object)">
            <summary>
            Method to create a Moniker for a given token
            </summary>
            <param name="token">Token to be monikerized</param>
            <returns>Moniker representing the token</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException">
            <summary>
            This exception is thrown during moniker resolution when resolving the moniker causes duplicate element links to
            be created.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.#ctor(System.String)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.#ctor(System.String,System.Exception)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.Add(Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Add a moniker that causes this exception.
            </summary>
            <param name="moniker">Added Moniker</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.Add(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.Moniker})">
            <summary>
            Add monikers that causes this exception.
            </summary>
            <param name="monikers">Added Monikers</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerResolvedToDuplicateLinkException.Monikers">
            <summary>
            Returns the Monikers that casued this exception.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException">
            <summary>
            This exception is thrown when two elements in the store are giving the same moniker.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,System.String)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,System.String,System.String)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,System.String,System.String,System.Exception)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,System.String,System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException.Element">
            <summary>
            Returns ModelElement which current gives the ambiguous moniker.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.AmbiguousMonikerException.Moniker">
            <summary>
            Returns the moniker that is ambiguous.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MonikerRoot">
            <summary>
            MonikerRoot is the object 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerRoot.#ctor(Microsoft.VisualStudio.Modeling.MonikerKey,Microsoft.VisualStudio.Modeling.Store,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Constructor
            </summary>
            <param name="key">MonikerKey used to resolve moniker</param>
            <param name="store">Store that the Moniker is created in</param>
            <param name="moniker">Moniker being initially connected</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerRoot.Resurrect(Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Resurrect a deleted moniker.
            </summary>
            <param name="moniker"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerRoot.ResolveAll">
            <summary>
            Force all Monikers associated with this Moniker Root to resolve.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerRoot.CompareTo(Microsoft.VisualStudio.Modeling.MonikerRoot)">
            <summary>
            Compares two MonikerRoots based upon their key.
            </summary>
            <param name="monikerRoot">MonikerRoot being compared to</param>
            <returns>A 32-bit signed integer that indicates the relative order of the comparands.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MonikerRoot.Equals(Microsoft.VisualStudio.Modeling.MonikerRoot)">
            <summary>
            Compares two MonikerRoots based upon their MonikerName to determine if they are equal
            </summary>
            <param name="monikerRoot">MonikerRoot being compared to</param>
            <returns>Boolean that indicates if the two Monikers are equal.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.Id">
            <summary>
            The Id of this Moniker.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.MonikerName">
            <summary>
            The name of the Moniker
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.Store">
            <summary>
            The Store the Moniker belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.ModelElement">
            <summary>
            The model element the moniker resolves to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.Resolved">
            <summary>
            Set/Get moniker resolve state
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.DomainModelFullName">
            <summary>
            The name of the DomainModel that the element represented by this Moniker resides in.
            This is used to find the MonikerResolver.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.DomainRelationshipInfo">
            <summary>
            The DomainRelationshipInfo this moniker root participates in
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.DomainClassInfo">
            <summary>
            The DomainClassInfo of the DomainClass that this moniker root should resolve to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.Monikers">
            <summary>
            The Monikers that are referenced by the MonikerRoot.  The array is sorted by Moniker ID.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MonikerRoot.MonikerResolver">
            <summary>
            MonikerResolver for the MonikerRoot.
            This is indexed by the domain ModelFullName and kept in the MonikerResolverDirectory in the store.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.PropertyAssignment">
            <summary>
            Represents property assignment pair consisting of property ID and assigned value.
            Use PropertyAssignment in element constructors to initialize element's properties at creation time.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PropertyAssignment.#ctor(System.Guid,System.Object)">
            <summary>
            Initializes a new instance of the PropertyAssignment class.
            </summary>
            <param name="domainPropertyId">ID of the domain property to be assigned.</param>
            <param name="value">Value to be assigned to the property.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PropertyAssignment.GetAssignablePropertyValues(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets an array of property assignments for the current element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PropertyAssignment.GetCustomStoredPropertyValues(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Gets a list of property assignments for custom-stored properties.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.PropertyAssignment.SetPropertyValues(Microsoft.VisualStudio.Modeling.ModelElement,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.PropertyAssignment},Microsoft.VisualStudio.Modeling.SetPropertyValueMode)">
            <summary>
            Internal method to process PropertyAssignments with options for FieldHandler.SetValueAsObject.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.PropertyAssignment.PropertyId">
            <summary>
            Gets ID of the domain property to assign value to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.PropertyAssignment.Value">
            <summary>
            Gets the value to be assigned to the property.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RoleAssignment">
            <summary>
            Provides information required to initialize one side of an <see cref="T:Microsoft.VisualStudio.Modeling.ElementLink"/>.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RoleAssignment.#ctor(System.Guid,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Initializes a new instance of the RoleAssignment class.
            </summary>
            <param name="domainRoleId">The Id of domain role being assigned a role-player</param>
            <param name="rolePlayer">The element playing the role</param>
            <exception cref="T:System.ArgumentNullException">rolePlayer is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RoleAssignment.#ctor(System.Guid,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Initializes a new instance of the RoleAssignment class.
            </summary>
            <param name="domainRoleId">The Id of domain role being assigned a role-player</param>
            <param name="rolePlayer">The Moniker of the element playing the role</param>
            <exception cref="T:System.ArgumentNullException">rolePlayer is null.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RoleAssignment.#ctor(System.Guid,Microsoft.VisualStudio.Modeling.ModelElement,System.Int32)">
            <summary>
            Initializes a new instance of the RoleAssignment class.
            </summary>
            <param name="domainRoleId">The Id of domain role being assigned a role-player</param>
            <param name="rolePlayer">The element playing the role</param>
            <param name="linkIndex">The index of the element link in the role-player' list of links</param>
            <exception cref="T:System.ArgumentNullException">rolePlayer is null.</exception>
            <exception cref="T:System.ArgumentOutOfRangeException">lineIndex is less than -1.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RoleAssignment.#ctor(System.Guid,Microsoft.VisualStudio.Modeling.Moniker,System.Int32)">
            <summary>
            Initializes a new instance of the RoleAssignment class.
            </summary>
            <param name="domainRoleId">The Id of domain role being assigned a role-player</param>
            <param name="rolePlayer">The Moniker of the element playing the role</param>
            <param name="linkIndex">The index of the element link in the role-player' list of links</param>
            <exception cref="T:System.ArgumentNullException">rolePlayer is null.</exception>
            <exception cref="T:System.ArgumentOutOfRangeException">lineIndex is less than -1.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RoleAssignment.#ctor(System.Guid)">
            <summary>
            Special constructor to create a placeholder RoleAssignment. The assignment will contain no valid ModelElement/Moniker.
            It is used in special cases like serialization to create a temporary role assignment, which will then be replaced by
            a valid one later.
            </summary>
            <param name="domainRoleId">The Id of domain role being assigned.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RoleAssignment.CreatePlaceholderRoleAssignment(System.Guid)">
            <summary>
            Special factory method to create a placeholder RoleAssignment. The assignment will contain no valid ModelElement/Moniker.
            It is used in special cases like serialization to create a temporary role assignment, which will then be replaced by
            a valid one later.
            </summary>
            <param name="domainRoleId">The Id of domain role being assigned.</param>
            <returns>The created place-holder RoleAssignment.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RoleAssignment.RolePlayer">
            <summary>
            Gets model element that is playing the role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RoleAssignment.RolePlayerMoniker">
            <summary>
            Gets moniker of the element that is playing the role.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RoleAssignment.DomainRoleId">
            <summary>
            Gets Id of the domain role that the role-player is playing.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RoleAssignment.LinkIndex">
            <summary>
            Gets the index of the element link in the role-player's list of links.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection">
            <summary>
            Holds and manages collection of links attached to a model element.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.ClearRoleLinks">
            <summary>
            Creates all role links from collection.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.FindRoleLinks(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Finds RoleLinks instance for the given domain role.
            Returns null if no RoleLinks was found.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.GetRoleLinks(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Finds or creates a new RoleLinks instance for the given domain role.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.RefreshRoleIndexes(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.DomainRoleInfo})">
            <summary>
            Updated role links collection to accomodate for IndexAtRolePlayer changes
            which is caused by loading a new domain model with relationships to existing elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.GetRoleLinksCapacities">
            <summary>
            Answers the capacities of the RoleLinks collections. This is useful for pre-sizing when reconstituting/copying
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.PreAllocateRoleLinks(System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.DomainRoleInfo},System.Int32[])">
            <summary>
            Pre-create the RoleLinks collections. This is useful when reconstituting from an element group (for example).
            The resulting links collections will be able to hold at least the specified number of links
            This should only be called at initialisation time.
            </summary>
            <param name="sizes"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.GetFirstLink(Microsoft.VisualStudio.Modeling.DomainRoleInfo)">
            <summary>
            Gets first link for the given role or null if no links found.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.GetAllLinks">
            <summary>
            Gets all links from all roles (no duplicates).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.GetLinks``1(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Boolean)">
            <summary>
            Gets all links for a given role and optionally excludes derived roles links.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerLinksCollection.RoleLinks.Preallocate(System.Int32)">
            <summary>
            Ensure the links collection has capacity for at least n entries
            </summary>
            <param name="n"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver">
            <summary>
            A Moniker Resolver that resolves simple string references when the model is serialized usign default xml serialization.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.lookupTable">
            <summary>
            Table containing map of full string references to ModelElement(s).
            When a model element is created during deserialization, we calculate its key and then enter it into this table.
            At end of deserialization, we resolve all monikers by looking them up in this table.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.newElements">
            <summary>
            A list of ModelElement instances that are created during the serialization transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.Finalize">
            <summary>
            Finalizer
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.ResolveMoniker(Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Resolves moniker to one element, moniker was created during Xml deserialization
            </summary>
            <param name="moniker">Moniker to be resolved</param>
            <returns>Element that the Moniker represents</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.CreateMoniker(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Not implemented by the SimpleMonikerResolver. Default Xml serialization creates	the Moniker on the reference relationship class.
            </summary>
            <param name="modelElement"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.CreateMonikerForToken(System.Object)">
            <summary>
            Not implemented by the SimpleMonikerResolver. Default Xml serialization creates	the Moniker on the reference relationship class.
            </summary>
            <param name="token"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.Dispose">
            <summary>
            Dispose unsuscribes from DeserializationBeginning and DeserializationEnding
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.Dispose(System.Boolean)">
            <summary>
            Dispose this moniker resolver.
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.AddNewElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Add a new element during a deserialization transaction.
            </summary>
            <param name="newElement"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnDeserializationBeginning(System.Object,System.EventArgs)">
            <summary>
            Event callback on deserialization beginning.
            </summary>
            <param name="sender"></param>
            <param name="args"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnDeserializationBeginning(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Handles beginning of deserialization transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnTopLevelTransactionBeginning(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Called when the moniker resolver starts to moniter a new top-level transaction.
            Base implementation does nothing.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnDeserializationEnding(System.Object,System.EventArgs)">
            <summary>
            Event callback on deserialization ending. All new ModelElement instances created during the transaction will
            be processed, and then all monikers will be resolved (if possible).
            </summary>
            <param name="sender"></param>
            <param name="args"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnTransactionRollback(System.Object,Microsoft.VisualStudio.Modeling.TransactionRollbackEventArgs)">
            <summary>
            Do some cleanup if the serialization transaction is rolled back
            </summary>
            <param name="sender"></param>
            <param name="args"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnStoreDisposing(System.Object,System.EventArgs)">
            <summary>
            Event callback on store disposing.
            </summary>
            <param name="sender"></param>
            <param name="args"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnMonikerResolutionEnded(System.Object,System.EventArgs)">
            <summary>
            All monikers should have been resolved by this time, so we report any unresolved ones here as warnings/errors.
            </summary>
            <param name="sender"></param>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.DeserializationComplete">
            <summary>
            This method is called when serialization is complete or aborted. Derived classes should perform their own cleanup and 
            then call this base method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.ProcessAddedElement(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            This method is called when an added model element is being processed at the end of deserialization transaction.
            </summary>
            <param name="mel">A model element created during deserialization</param>
            <returns>True if the model element is processed and its moniker is added into the lookup table. This method returns false
            if a moniker has already been recorded for the model element or if it cannot be monikerized.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnUnresolvedMoniker(Microsoft.VisualStudio.Modeling.SerializationResult,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Called at the end of synchronization when they're unresolved monikers.
            Base implementation doesn't do nothing.
            </summary>
            <param name="serializationResult">SerializationResult to store error/warning messages.</param>
            <param name="moniker">Unresolved moniker.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnMonikerResolvedToDuplicateLink(Microsoft.VisualStudio.Modeling.SerializationResult,Microsoft.VisualStudio.Modeling.Moniker)">
            <summary>
            Called when resolving a moniker causes a duplicate link to be created.
            The base implementation deletes the moniker as well as the element link.
            </summary>
            <param name="serializationResult">SerializationResult to store error/warning messages.</param>
            <param name="moniker">Moniker that causes duplicate link to be created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.OnAmbiguousMoniker(Microsoft.VisualStudio.Modeling.SerializationContext,System.String,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Called when two new elements are giving the same moniker, which will cause ambiguity during moniker resolution.
            Note: the base implementation does nothing.
            </summary>
            <param name="context">SerializationContext to store error/warning messages.</param>
            <param name="moniker">Moniker that both elements give.</param>
            <param name="element1">The first element giving the moniker.</param>
            <param name="element2">The second element giving the same moniker.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.CanBeMonikerized(Microsoft.VisualStudio.Modeling.DomainClassInfo)">
            <summary>
            Tells if a DomainClass can be monikerized or not.
            </summary>
            <param name="domainClassInfo">DomainClassInfo of the DomainClass to be checked.</param>
            <returns>True if the DomainClass can be monikerized, false otherwise.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.CalculateQualifiedName(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Calculate the fully qualified monikerized string of the given ModelElement.
            </summary>
            <param name="mel">ModelElement to get moniker from.</param>
            <returns>Calculated moniker string, returns null or empty string is the given ModelElement cannot be monikerized.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.IsFullyQualified(System.String)">
            <summary>
            Is the input string a fully qualified reference, as understood by the SimpleMonikerResolver.
            </summary>
            <param name="reference">A reference persisted by default Xml serialization</param>
            <returns>true if the reference is fully qualified (begins with '/') false otherwise</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.AddToLookupTable(System.String,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Derived classes can call this method to add extra keys to the moniker lookup table used to resolve monikers.
            </summary>
            <param name="monikerName">The name to match against moniker keys</param>
            <param name="mel">The model element to return if keys match</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.IsDisposed">
            <summary>
            Tells if this moniker resolver has been disposed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.SerializationContext">
            <summary>
            Gets or Sets the current serialization context.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.UnresolvedMonikerExceptionMessage">
            <summary>
            Error message for UnresolvedMonikerException.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.LookupTable">
            <summary>
            Lookup table to ncapsulate the process of looking up a moniker to get a mel.
            Several mels may actually have the same full form reference. E.g. (in xpath terms)
            /namespace[@name="A"]/class[@name="B"] and /class[@name="A"]/class[@name="B"]
            could both have moniker references "/A/B".
            We can disambiguate them by observing that the relationship is different in each case - we have a constraint that within a relationship 
            the same reference cannot be used by two different mels.
            So for each reference we stroe either a single mel or a colelction of mels. At resolve time we disambiguate between multiple mels by examining
            which one could play the moniker'd role in the Moniker.Link
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.SimpleMonikerResolver.LookupTable.lookupTable">
            <summary>
            Table containing map of full string references to ModelElement, or a List of ModelElements
            When a model element is created during deserialization, we calculate its key and then enter it into this table.
            At end of deserialization, we resolve all monikers by looking them up in this table.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementDeserializedRule">
            <summary>
            A rule that fires when new ModelElements are created, used by SimpleMonikerResolver to monitor new elements.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.AddRule">
            <summary>
            Base class for registering element added notification rule
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Rule">
            <summary>
            public abstract Rule
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.GetHashCode">
            <summary>
            Get the hash code for this rule
            </summary>
            <returns>int</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.CompareTo(System.Object)">
            <summary>
            Compare this rule object with another object
            </summary>
            <param name="obj">the object to compare it with</param>
            <returns>int</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.CompareTo(Microsoft.VisualStudio.Modeling.Rule)">
            <summary>
            Query whether this rule is less, greater, or equal to another rule instance.
            </summary>
            <param name="other">Rule to compare</param>
            <returns>-1, 0, 1</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.Equals(System.Object)">
            <summary>
            Equals operator
            </summary>
            <param name="obj">object to compare</param>
            <returns>true if the object is equal to this rule</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.Equals(Microsoft.VisualStudio.Modeling.Rule)">
            <summary>
            Equals operator
            </summary>
            <param name="rule">rule to compare</param>
            <returns>true if the object is equal to this rule</returns>
        </member>
        <!-- Badly formed XML comment ignored for member "M:Microsoft.VisualStudio.Modeling.Rule.op_Equality(Microsoft.VisualStudio.Modeling.Rule,Microsoft.VisualStudio.Modeling.Rule)" -->
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.op_Inequality(Microsoft.VisualStudio.Modeling.Rule,Microsoft.VisualStudio.Modeling.Rule)">
            <summary>
            Not Equals operator
            </summary>
            <param name="lhs">left object to compare</param>
            <param name="rhs">right object to compare</param>
            <returns>false if the left object is equal to the right object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.op_LessThan(Microsoft.VisualStudio.Modeling.Rule,Microsoft.VisualStudio.Modeling.Rule)">
            <summary>
            Less Than operator
            </summary>
            <param name="lhs">left object to compare</param>
            <param name="rhs">right object to compare</param>
            <returns>true if the left object is less than the right object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Rule.op_GreaterThan(Microsoft.VisualStudio.Modeling.Rule,Microsoft.VisualStudio.Modeling.Rule)">
            <summary>
            Greater Than operator
            </summary>
            <param name="lhs">left object to compare</param>
            <param name="rhs">right object to compare</param>
            <returns>true if the left object is greater than the right object</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.FireBefore">
            <summary>
            returns true if this rule should be fired inline before the change happens
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.IsEnabled">
            <summary>
            Gets or Sets whether the Rule is enabled.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.FireImmediately">
            <summary>
            returns true if this rule should be fired inline
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.FireOnLocalCommit">
            <summary>
            returns true if this rule should be fired at local commit time
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.FireOnTopLevelCommit">
            <summary>
            returns true if this rule should be fired at top level commit time
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.FireTime">
            <summary>
            Get or set the time to fire this rule
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Rule.Priority">
            <summary>
            Get the priority of this rule
            </summary>
            <value>int</value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddRule.ElementAdded(Microsoft.VisualStudio.Modeling.ElementAddedEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined add rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementDeserializedRule.ElementAdded(Microsoft.VisualStudio.Modeling.ElementAddedEventArgs)">
            <summary>
            Called when a CommentShape is created.
            </summary>
            <param name="e">Argument to event</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DelegateDictionary">
            <summary>
            DelegateDictionary is a collection of event handler delegates intended
            for internal use in the In-Memory Store.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DelegateDictionary.#ctor(System.Int32)">
            <summary>
            Constructor.
            </summary>
            <param name="initialSize">The initial capacity of the dictionary</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DelegateDictionary.Add(Microsoft.VisualStudio.Modeling.DelegateHashKey,System.Delegate)">
            <summary>
            Add a delegate to the dictionary.
            </summary>
            <param name="key">The key to look up the delegate</param>
            <param name="theDelegate">The delegate to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DelegateDictionary.Remove(Microsoft.VisualStudio.Modeling.DelegateHashKey,System.Delegate)">
            <summary>
            Remove a delegate to the dictionary.
            </summary>
            <param name="key">The key to look up the delegate</param>
            <param name="theDelegate">The delegate to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DelegateDictionary.Find(Microsoft.VisualStudio.Modeling.DelegateHashKey)">
            <summary>
            Look up a delegate corresponding to a particular key.
            </summary>
            <param name="key">The key to the delegate</param>
            <returns>The delegate corresponding to the key</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DelegateHashKey">
            <summary>
            The base class for all delegate keys.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainObjectHashKey">
            <summary>
            Keys used to look up event handlers for events associated
            with a domain object
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectHashKey.#ctor(Microsoft.VisualStudio.Modeling.DomainObjectInfo)">
            <summary>
            Constructor
            </summary>
            <param name="domainData">The domain object for which the key is a proxy</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectHashKey.Equals(System.Object)">
            <summary>
            Determines whether the input object is equivalent to this key.
            </summary>
            <param name="obj">The object to compare</param>
            <returns>Whether the input object is equivalent to this key</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectHashKey.GetHashCode">
            <summary>
            Get the hash code for this object
            </summary>
            <returns>The hash code</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectHashKey.DomainObjectId">
            <summary>
            The Id of the domain object
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementHashKey">
            <summary>
            Keys used to look up event handlers associated with a particular
            ModelElement or Transaction instance.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementHashKey.#ctor(System.Guid)">
            <summary>
            Constructor
            </summary>
            <param name="elementId">The Id of the object for which this is a proxy</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementHashKey.Equals(System.Object)">
            <summary>
            Determines whether the input object is equivalent to this key.
            </summary>
            <param name="obj">The object to compare</param>
            <returns>Whether the input object is equivalent to this key</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementHashKey.GetHashCode">
            <summary>
            Gets the hash code for this object
            </summary>
            <returns>The hash code</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementHashKey.ElementId">
            <summary>
            The Id of the ModelElement or Transaction
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MultiGuidHashKey">
            <summary>
            Base class for keys combining multiple Guids
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MultiGuidHashKey.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MultiGuidHashKey.CreateHashCode(System.Guid[])">
            <summary>
            Create the hash code for a combination of Guids.  
            </summary>
            <remarks>
            This is a deterministic function of the input Guids.
            </remarks>
            <param name="guids">Array of guids to combine</param>
            <returns>A hash code</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainObjectElementHashKey">
            <summary>
            Keys used to look up event handlers associated with a particular
            domain object, ModelElement pair.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectElementHashKey.#ctor(Microsoft.VisualStudio.Modeling.DomainObjectInfo,System.Guid)">
            <summary>
            Constructor
            </summary>
            <param name="elementInfo">The domain object</param>
            <param name="elementId">The Id of the element</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectElementHashKey.Equals(System.Object)">
            <summary>
            Determines whether an input object is equivalent to this key.
            </summary>
            <param name="obj">The object to compare</param>
            <returns>Whether the input object is equivalent</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainObjectElementHashKey.GetHashCode">
            <summary>
            Gets the hash code for this object.
            </summary>
            <returns>The hash code</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectElementHashKey.ElementId">
            <summary>
            The Id of the ModelElement associated with this key.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainObjectElementHashKey.DomainObjectId">
            <summary>
            The Id of the domain object associated with this key.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DomainClassDomainPropertyHashKey">
            <summary>
            Keys used to look up event handler delegates for a combination of
            domain class and domain property
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassDomainPropertyHashKey.#ctor(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo)">
            <summary>
            Constructor
            </summary>
            <param name="domainClass">The domain class associated with this key</param>
            <param name="domainProperty">The domain propertyassociated with this key</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassDomainPropertyHashKey.Equals(System.Object)">
            <summary>
            Determines whether an input object is equivalent to this key.
            </summary>
            <param name="obj">The object to compare</param>
            <returns>Whether the input object is equivalent</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DomainClassDomainPropertyHashKey.GetHashCode">
            <summary>
            Gets the hash code for this object.
            </summary>
            <returns>The hash code</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassDomainPropertyHashKey.DomainClassId">
            <summary>
            The Id of the domain class associated with this key
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DomainClassDomainPropertyHashKey.DomainPropertyId">
            <summary>
            The Id of the domain propertyassociated with this key
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ChangeSource">
            <summary>
            Indicates the source of a change made during a transaction
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ChangeSource.Normal">
            <summary>
            Changes that occurr during normal processing
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ChangeSource.Rule">
            <summary>
            Changes that occurred during rule firing
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ChangeSource.Propagate">
            <summary>
            Changes that occurred during delete propagation
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ChangeSource.Other">
            <summary>
            Other changes
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ModelingEventArgs">
            <summary>
            Base class for all IMS event args classes
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventArgs">
            <summary>
            Event arguments marking the beginning of element event notifications
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventArgs.#ctor(Microsoft.VisualStudio.Modeling.TransactionContext)">
            <summary>
            Contructs an eventArgs containing the passed in TrasnactionContext
            </summary>
            <param name="transactionContext"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventArgs.TransactionContext">
            <summary>
            Gets the TransactionContext associated with this EventArgs or null if the EventArgs does not have a transaction context
            </summary>
            <value>string</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventsEndedEventArgs">
            <summary>
            Event arguments marking the end of element event notifications
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventsEndedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.TransactionContext)">
            <summary>
            Contructs an eventArgs containing the passed in TrasnactionContext
            </summary>
            <param name="transactionContext"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventsEndedEventArgs.TransactionContext">
            <summary>
            Gets the TransactionContext associated with this EventArgs or null if the EventArgs does not have a transaction context
            </summary>
            <value>string</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.GenericEventArgs">
            <summary>
            Abstract base class for all event arguments for element events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GenericEventArgs.#ctor(Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="changeSource">change source</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.GenericEventArgs.ChangeSource">
            <summary>
            Get or Set the source of this change
            </summary>
            <value>ChangeSource</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.GenericEventArgs.ElementId">
            <summary>
            Get the Id of the element to which this notification pertains
            </summary>
            <returns>The element ID</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.GenericEventArgs.DomainClass">
            <summary>
            Get the domain class to which this notification pertains
            </summary>
            <returns>The domain class</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.GenericEventArgs.DomainModel">
            <summary>
            Get the domain model to which this notification pertains
            </summary>
            <returns>The domain model</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs">
            <summary>
            Event arguments describing a change of elements playing a role in an ElementLink
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The element directory used to look up the Elements and ModelElement links involved</param>
            <param name="domainRole">The domain role whose role-player changed</param>
            <param name="elementLinkId">The Id of the ElementLink whose role-player changed</param>
            <param name="oldRolePlayerId">The Id of the ModelElement that was playing the role before the change</param>
            <param name="newRolePlayerId">The Id of the ModelElement that is playing the role after the change</param>
            <param name="changeSource">The source of this change</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.DomainRelationship">
            <summary>
            The domain relationship of which the affected ElementLink is an instance
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.Directory">
            <summary>
            Get the ElementDirectory this event args is in.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.DomainRole">
            <summary>
            The domain role whose role-player changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.ElementLinkId">
            <summary>
            The Id of the ElementLink whose role-player changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.OldRolePlayerId">
            <summary>
            The Id of the ModelElement that was playing the role before the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.NewRolePlayerId">
            <summary>
            The Id of the ModelElement that is playing the role after the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.ElementLink">
            <summary>
            The ElementLink whose role-player changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.OldRolePlayer">
            <summary>
            The ModelElement that was playing the role before the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.NewRolePlayer">
            <summary>
            The ModelElement that is playing the role after the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.ElementId">
            <summary>
            Get the Id of the ModelElement to which the notification pertains
            </summary>
            <returns>The ID</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.DomainClass">
            <summary>
            Get the domain class to which the notification pertains
            </summary>
            <returns>The domain class</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs.DomainModel">
            <summary>
            Get the domain model to which the notification pertains
            </summary>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs">
            <summary>
            Event arguments decribing a change to the order of Elements in an ordered relationship
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Int32,System.Int32,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The element directory in which to look up the relevent Elements and ElementLinks</param>
            <param name="sourceElementId">The Id of the source ModelElement</param>
            <param name="sourceDomainRole">The domain role played by the source ModelElement</param>
            <param name="counterpartId">The Id of the ModelElement whose order has changed</param>
            <param name="counterpartRole">The domain role played by the ModelElement whose order has changed</param>
            <param name="oldOrdinal">The ModelElement ordinal before the change</param>
            <param name="newOrdinal">The ModelElement ordinal after the change</param>
            <param name="changeSource">The source for this change</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.DomainRelationship">
            <summary>
            The domain relationship for the reordered Elements
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.Directory">
            <summary>
            Get the ElementDirectory this event args is in.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.SourceDomainRole">
            <summary>
            The domain role played by the source ModelElement
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.CounterpartDomainRole">
            <summary>
            The domain role played by the ModelElement whose order has changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.SourceElementId">
            <summary>
            The Id of the source ModelElement
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.CounterpartRolePlayerId">
            <summary>
            The Id of the ModelElement whose order has changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.SourceElement">
            <summary>
            The source ModelElement
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.CounterpartRolePlayer">
            <summary>
            The ModelElement whose order has changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.OldOrdinal">
            <summary>
            The ordinal of the changed ModelElement before the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.NewOrdinal">
            <summary>
            The ordinal of the changed ModelElement after the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.ElementId">
            <summary>
            Get the Id of the ModelElement to which the notification pertains
            </summary>
            <returns>The ModelElement ID</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.DomainClass">
            <summary>
            Get the domain class to which the notification pertains
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs.DomainModel">
            <summary>
            Get the domain model to which the notification pertains
            </summary>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventArgs">
            <summary>
            Event arguments for notifications associated with an ModelElement
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Guid,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The element directory used to look up the subject ModelElement</param>
            <param name="domainClass">The domain class of the subject ModelElement</param>
            <param name="elementId">The Id of the subject ModelElement</param>
            <param name="changeSource">The source of the change that triggered firing this notification</param>
            [GeMathew] UNDONE: Should this be internal
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventArgs.ModelElement">
            <summary>
            The ModelElement that is the subject of the notification
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventArgs.ElementId">
            <summary>
            Get the Id of the ModelElement to which the notification pertains
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventArgs.DomainClass">
            <summary>
            Get the domain class to which the notification pertains
            </summary>
            <returns>The domain class</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventArgs.DomainModel">
            <summary>
            Get the domain model to which the notification pertains
            </summary>
            <returns>The domain model</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementEventArgs.Directory">
            <summary>
            The directory in which the ModelElement may be found
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementAddedEventArgs">
            <summary>
            Event Arguments for notification of the creation of a new ModelElement
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementAddedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Guid,Microsoft.VisualStudio.Modeling.PropertyAssignment[],Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The directory in which the new ModelElement may be found</param>
            <param name="domainClass">The domain class of the new ModelElement</param>
            <param name="elementId">The Id of the new ModelElement</param>
            <param name="assignments">The attribute assignments for the new model element</param>
            <param name="changeSource">Source of the change</param>
            [GeMathew] UNDONE: Should this be internal
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementAddedEventArgs.GetAssignments">
            <summary>
            Get the attribute assignments used when this element was created
            </summary>
            <value>PropertyAssignment[]</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs">
            <summary>
            Event Arguments for notification of the removal of an ModelElement
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Guid,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The directory in which the deleted ModelElement may be found</param>
            <param name="domainClass">The domain class of the deleted ModelElement</param>
            <param name="elementId">The Id of the deleted ModelElement</param>
            <param name="changeSource">The source of this change</param>
            [GeMathew] UNDONE: Should this be internal
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs.CustomStoredPropertyAssignments">
            <summary>
            Holds list of PropertyAssignments for each custom stored attribute and its current value at the time it was deleted.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs.ModelElement">
            <summary>
            The deleted ModelElement
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementDeletingEventArgs">
            <summary>
            Event Arguments for notification of the pending removal of a ModelElement
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementDeletingEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Guid,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The directory in which the deleted ModelElement may be found</param>
            <param name="domainClass">The domain class of the deleted ModelElement</param>
            <param name="elementId">The Id of the deleted ModelElement</param>
            <param name="changeSource">The source of this change</param>
            [GeMathew] UNDONE: Should this be internal
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementDeletingEventArgs.CustomStoredPropertyAssignments">
            <summary>
            Holds a list of PropertyAssignments for each custom stored attribute
            and its current value at the time it was deleted.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs">
            <summary>
            Event Arguments for notifications that the value of an attribute has changed
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Guid,System.Object,System.Object,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The element directory in which the modified ModelElement may be found</param>
            <param name="domainProperty">The domain propertywhose instance value changed</param>
            <param name="domainClass">The domain class of the ModelElement whose attribute value changed</param>
            <param name="elementId">The Id of the ModelElement whose attribute value changed</param>
            <param name="oldValue">The attribute value before the change</param>
            <param name="newValue">The attribute value after the change</param>
            <param name="changeSource">The source of this change</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs.DomainProperty">
            <summary>
            The domain propertywhose instance value has changed
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs.OldValue">
            <summary>
            The value of the attribute before the change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs.NewValue">
            <summary>
            The value of the attribute after the change
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementMovedEventArgs">
            <summary>
            Event Arguments for notification of the creation of a new ModelElement
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementMovedEventArgs.#ctor(Microsoft.VisualStudio.Modeling.IElementDirectory,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Guid,System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor
            </summary>
            <param name="directory">The directory in which the new ModelElement may be found</param>
            <param name="domainClass">The domain class of the new ModelElement</param>
            <param name="elementId">The Id of the new ModelElement</param>
            <param name="sourcePartitionId">source partition Id</param>
            <param name="destinationPartitionId">destination partition Id</param>
            <param name="changeSource">Source of the change</param>
            [GeMathew] UNDONE: Should this be internal
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementMovedEventArgs.SourcePartitionId">
            <summary>
            Source partititon Id
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementMovedEventArgs.DestinationPartitionId">
            <summary>
            Destination partition Id
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventManager">
            <summary>
            Class that manages Element Events Begun Events
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.GlobalEventManager">
            <summary>
            GlobalEventManager is the base class for all transaction and element event managers.
            GlobalEventManager provides a mechanism for observers to register for and be notified
            of changes within the scope of the store.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManager.Add(System.Delegate)">
            <summary>
            Add an event handler delegate for global event notifications
            </summary>
            <param name="handler">The handler to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManager.Remove(System.Delegate)">
            <summary>
            Remove an event handler delegate for global event notifications
            </summary>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManager.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify all global observers of an event
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The event arguments</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventsEndedEventManager">
            <summary>
            Class that manages Element Events Ended Events
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventManager">
            <summary>
            Abstract Class that serves as a base to manage Element Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManager.Add(Microsoft.VisualStudio.Modeling.DomainModelInfo,System.Delegate)">
            <summary>
            Adds a handler for events at the domain model level
            </summary>
            <param name="domainModel">The domain model for which events are to be handled</param>
            <param name="handler">The event handler</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManager.Add(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Delegate)">
            <summary>
            Adds a handler for events at the domain class or domain relationship level
            </summary>
            <param name="domainClass">
            The domain class or domain relationship for which events are to be handled
            </param>
            <param name="handler">
            The event handler
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainModelInfo,System.Delegate)">
            <summary>
            Removes an event handler for a particular domain model
            </summary>
            <param name="domainModel">The domain model whose event handler is to be removed</param>
            <param name="handler">The event handler</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Delegate)">
            <summary>
            Removes an event handler for a particular domain class or domain relationship
            </summary>
            <param name="domainClass">The domain class whose event handler is to be removed</param>
            <param name="handler">The event handler</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ExistingElementEventManager">
            <summary>
            Abstract Class that serves as a base for managing Element Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManager.Add(System.Guid,System.Delegate)">
            <summary>
            Add a handler for events on a particular ModelElement
            </summary>
            <param name="elementId">The Id of the element</param>
            <param name="handler">The handler to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManager.Remove(System.Guid,System.Delegate)">
            <summary>
            Remove a handler for events on a particular ModelElement
            </summary>
            <param name="elementId">The Id of the element</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementAddedEventManager">
            <summary>
            Class that manages Element Added Events
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManager">
            <summary>
            Class that manages Role Player Changed Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Add an event handler that is called whenever any ModelElement playing a particular
            role in any ElementLink is changed
            </summary>
            <param name="domainRole">The domain role to observe</param>
            <param name="handler">The handler for the notifications</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Add an event handler that is called whenever the ModelElement playing a particular
            role in a particular ElementLink is changed
            </summary>
            <param name="domainRole">The domain role to observe</param>
            <param name="elementLinkId">The Id of the ElementLink to observe</param>
            <param name="handler">The handler for the notifications</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Remove an event handler that is called whenever any ModelElement playing a particular
            role in any ElementLink is changed
            </summary>
            <param name="domainRole">The domain role that is observed</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Remove an event handler that is called whenever the ModelElement playing a particular
            role in a particular ElementLink is changed
            </summary>
            <param name="domainRole">The domain role that is observed</param>
            <param name="elementLinkId">The Id of the ModelElement that is observed</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManager">
            <summary>
            Class that manages Role Player Order Changed Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the order of Elements playing
            a particular domain role has changed for any source ModelElement changes
            </summary>
            <remarks>
            For example, add an event handler that is notified whenever the order of
            child columns is changed for any database table.  In this example, the
            "counterpart domain role" is the child-column role.
            </remarks>
            <param name="counterpartDomainRole">The role played by the elements whose order is changed</param>
            <param name="handler">The delegate that is to be called</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the order of Elements playing a
            particular role in relationships with a particular source ModelElement changes
            </summary>
            <remarks>
            For example, add an event handler that is called whenever the order of the
            columns of the Authors table is changed.  In this example, the "counterpart
            domain role" is the child-column role, while the "source ModelElement" is the 
            Authors table.
            </remarks>
            <param name="counterpartDomainRole">The role played by the elements whose order is changed</param>
            <param name="sourceElementId">The Id of the (parent) ModelElement ordering the (child) counterparts</param>
            <param name="handler">The handler to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the order of Elements playing a
            particular role in relationships with any source ModelElement changes
            </summary>
            <remarks>
            For example, remove an event handler that is notified whenever the order of
            child columns is changed for any database table.  In this example, the
            "counterpart domain role" is the child-column role.
            </remarks>
            <param name="counterpartDomainRole">The domain role played by the Elements whose order is changed</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the order of Elements playing a
            particular role in relationships with a particular source ModelElement changes
            </summary>
            <remarks>
            For example, remove an event handler that is called whenever the order of the
            columns of the Authors table is changed.  In this example, the "counterpart
            domain role" is the child-column role, while the "source ModelElement" is the 
            Authors table.
            </remarks>
            <param name="counterpartDomainRole">The role played by the elements whose order is changed</param>
            <param name="sourceElementId">The Id of the (parent) ModelElement ordering the (child) counterparts</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager">
            <summary>
            Class that manages Element Property Changed Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the value of any instance of 
            a particular domain propertyis changed
            </summary>
            <param name="domainProperty">The domain propertyto observe</param>
            <param name="handler">The handler that is to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Guid,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the value of a particular
            property of a particular ModelElement is changed
            </summary>
            <param name="domainProperty">The property to observe</param>
            <param name="elementId">The Id of the ModelElement to observe</param>
            <param name="handler">The handler that is to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager.Add(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the value of a particular property
            on an instance of a particular domain class (or its subclasses) is changed
            </summary>
            <param name="domainClass">The domain class to observe</param>
            <param name="domainProperty">The domain class to observe</param>
            <param name="handler">The handler that is to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the value of any instance of
            a particular domain propertyis changed
            </summary>
            <param name="domainProperty">The domain propertythat is being observed</param>
            <param name="handler">The handler that is to be removed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Guid,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the value of a particular
            property of a particular ModelElement is changed.
            </summary>
            <param name="domainProperty">The property that is observed</param>
            <param name="elementId">The Id of the ModelElement that is observed</param>
            <param name="handler">The handler that is to be removed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManager.Remove(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the value of a particular property
            on an instance of a particular domain class (or its subclasses) is changed
            </summary>
            <param name="domainClass">The domain class that is observed</param>
            <param name="domainProperty">The domain propertythat is observed</param>
            <param name="handler">The handler that is to be removed</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementDeletedEventManager">
            <summary>
            Class that manages Element Removed Events
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementMovedEventManager">
            <summary>
            Class that manages Element Moved Events
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventManagerImpl">
            <summary>
            Event dispatcher for ModelElement Events Begun events
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl">
            <summary>
            GlobalEventManagerImpl is the base class for all transaction and element event manager implementations.
            GlobalEventManagerImpl provides a mechanism for observers to register for and be notified
            of changes within the scope of the store.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.#ctor(System.Type,System.Type)">
            <summary>
            Constructor
            </summary>
            <param name="eventArgsType">The expected type of the event arguments</param>
            <param name="handlerType">The expected type of the event handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.Add(System.Delegate)">
            <summary>
            Add an event handler delegate for global event notifications
            </summary>
            <param name="handler">The handler to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.Remove(System.Delegate)">
            <summary>
            Remove an event handler delegate for global event notifications
            </summary>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify all global observers of an event
            </summary>
            <param name="sender">The object that initiated the event</param>
            <param name="e">The event arguments</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.CheckArgsType(System.EventArgs)">
            <summary>
            Check whether the input event arguments are the expected type.
            </summary>
            <param name="e">The event arguments to check</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.CheckHandlerType(System.Delegate)">
            <summary>
            Check whether the event handler is the expected type.
            </summary>
            <param name="handler">The event handler to check</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.GlobalEventManagerImpl.CheckWhetherAlreadyRegistered(System.Delegate)">
            <summary>
            Check whether the event handler delegate is already registered to receive
            notifications of global events
            </summary>
            <param name="newHandler">The handler to check</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventsBegunEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventsEndedEventManagerImpl">
            <summary>
            Event dispatcher for ElementEvents Ended events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventsEndedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl">
            <summary>
            Base class for event dispatchers for events associated with Elements.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.#ctor(System.Type,System.Type)">
            <summary>
            Constructor
            </summary>
            <param name="argsType">The type of the event args for the events</param>
            <param name="handlerType">The type of the handlers for the events</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainModelInfo,System.Delegate)">
            <summary>
            Adds a handler for events at the domain model level
            </summary>
            <param name="domainModel">The domain model for which events are to be handled</param>
            <param name="handler">The event handler</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Delegate)">
            <summary>
            Adds a handler for events at the domain class or domain relationship level
            </summary>
            <param name="domainClass">
            The domain class or domain relationship for which events are to be handled
            </param>
            <param name="handler">
            The event handler
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainModelInfo,System.Delegate)">
            <summary>
            Removes an event handler for a particular domain model
            </summary>
            <param name="domainModel">The domain model whose event handler is to be removed</param>
            <param name="handler">The event handler</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainClassInfo,System.Delegate)">
            <summary>
            Removes an event handler for a particular domain class or domain relationship
            </summary>
            <param name="domainClass">The domain class whose event handler is to be removed</param>
            <param name="handler">The event handler</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that an event has occurred
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The event args for the handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyDomainModelObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of the domain model level events that an event has occurred
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The event arguments for the notification</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyDomainClassObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of the domain class or domain relationship level events
            that the event has occurred
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The event arguments for the notification</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyObserversInternal(System.Object,Microsoft.VisualStudio.Modeling.DomainClassInfo,System.EventArgs)">
            <summary>
            Notify domainClass observers
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="domainClass">The domainClass for which notifications are to be made</param>
            <param name="e">The arguments to be passed to the event handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyObserversInternal(System.Object,System.Guid,System.EventArgs)">
            <summary>
            Notify element observers
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="id">The id of the element for which notifications are to be made</param>
            <param name="e">The arguments to be passed to the event handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyObserversInternal(System.Object,Microsoft.VisualStudio.Modeling.DomainObjectInfo,System.EventArgs)">
            <summary>
            Notify domainObject observers
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="domainObject">The domainObject for which notifications are to be made</param>
            <param name="e">The arguments to be passed to the event handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementEventManagerImpl.NotifyObserversInternal(System.Object,Microsoft.VisualStudio.Modeling.DomainObjectInfo,System.Guid,System.EventArgs)">
            <summary>
            Notify observers of a particular domainObject associates with a particular ModelElement
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="domainObject">he domainObject for which notifications are to be made</param>
            <param name="id">The id of the element for which notifications are to be made</param>
            <param name="e">The arguments to be passed to the event handlers</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ExistingElementEventManagerImpl">
            <summary>
            Base class for dispatchers of events for existing elements
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManagerImpl.#ctor(System.Type,System.Type)">
            <summary>
            Constructor
            </summary>
            <param name="argsType">The type of the event arguments for the event</param>
            <param name="handlerType">The type of handlers for this event</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManagerImpl.Add(System.Guid,System.Delegate)">
            <summary>
            Add a handler for events on a particular ModelElement
            </summary>
            <param name="elementId">The Id of the element</param>
            <param name="handler">The handler to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManagerImpl.Remove(System.Guid,System.Delegate)">
            <summary>
            Remove a handler for events on a particular ModelElement
            </summary>
            <param name="elementId">The Id of the element</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that an event has occurred
            </summary>
            <remarks>
            Notifies ModelElement observers, then calls the base class implementation
            to notify domain class, domain model, and store-level observers.
            </remarks>
            <param name="sender">object that initiated the event</param>
            <param name="e">The event arguments for the event</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ExistingElementEventManagerImpl.NotifyElementObservers(System.Object,System.EventArgs)">
            <summary>
            Notify ModelElement observers that an event has occurred
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The event arguments for the event</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementAddedEventManagerImpl">
            <summary>
            The event dispatcher for element added events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementAddedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl">
            <summary>
            Event dispatcher for notifications that the element playing a role
            in an ElementLink has changed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Add an event handler that is called whenever any ModelElement playing a particular
            role in any ElementLink is changed
            </summary>
            <param name="domainRole">The domain role to observe</param>
            <param name="handler">The handler for the notifications</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Add an event handler that is called whenever the ModelElement playing a particular
            role in a particular ElementLink is changed
            </summary>
            <param name="domainRole">The domain role to observe</param>
            <param name="elementLinkId">The Id of the ElementLink to observe</param>
            <param name="handler">The handler for the notifications</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Remove an event handler that is called whenever any ModelElement playing a particular
            role in any ElementLink is changed
            </summary>
            <param name="domainRole">The domain role that is observed</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Remove an event handler that is called whenever the ModelElement playing a particular
            role in a particular ElementLink is changed
            </summary>
            <param name="domainRole">The domain role that is observed</param>
            <param name="elementLinkId">The Id of the ModelElement that is observed</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that a role-player has changed
            </summary>
            <remarks>
            Notifies domain role observers, then observers of the particular
            role-player, then calls the base class to do the higher-scope
            notifications
            </remarks>
            <param name="sender">object that initiated the event</param>
            <param name="e">The RolePlayerChangedEventArgs to pass to the observers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.NotifyDomainRolePlayerObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of the domain role that a role-player has changed
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The RolePlayerChangedEventArgs to pass to the observers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedEventManagerImpl.NotifyRolePlayerObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that the element playing the observed role on the observed
            ElementLink has changed
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The RolePlayerChangedEventArgs to pass to the observers</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl">
            <summary>
            The notification dispatcher for Property Changed Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the value of any instance of 
            a particular domain propertyis changed
            </summary>
            <param name="domainProperty">The domain propertyto observe</param>
            <param name="handler">The handler that is to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Guid,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the value of a particular
            property of a particular ModelElement is changed
            </summary>
            <param name="domainProperty">The property to observe</param>
            <param name="elementId">The Id of the ModelElement to observe</param>
            <param name="handler">The handler that is to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the value of a particular property
            on an instance of a particular domain class (or its subclasses) is changed
            </summary>
            <param name="domainClass">The domain class to observe</param>
            <param name="domainProperty">The domain class to observe</param>
            <param name="handler">The handler that is to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the value of any instance of
            a particular domain propertyis changed
            </summary>
            <param name="domainProperty">The domain propertythat is being observed</param>
            <param name="handler">The handler that is to be removed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Guid,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the value of a particular
            property of a particular ModelElement is changed.
            </summary>
            <param name="domainProperty">The property that is observed</param>
            <param name="elementId">The Id of the ModelElement that is observed</param>
            <param name="handler">The handler that is to be removed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the value of a particular property
            on an instance of a particular domain class (or its subclasses) is changed
            </summary>
            <param name="domainClass">The domain class that is observed</param>
            <param name="domainProperty">The domain propertythat is observed</param>
            <param name="handler">The handler that is to be removed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that an property value has changed
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The ElementPropertyChangedEventArgs for the notification</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.NotifyDomainPropertyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of a particular domain propertythat an instance value has changed
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The ElementPropertyChangedEventArgs for the notification</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.NotifyPropertyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of a particular property of a particular ModelElement that the
            property value has changed
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The ElementPropertyChangedEventArgs for the notification</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventManagerImpl.NotifyDomainClassDomainPropertyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of a particular property on a particular domain class and its
            subclasses that the property value has changed
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The ElementPropertyChangedEventArgs for the notification</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl">
            <summary>
            The notification dispatcher for events where the order of counterpart Elements in 
            ordered binary relationships has changed
            </summary>
            <remarks>
            An example of this would be when the order of child-columns has changed for a
            particular database table
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.#ctor">
            <summary>
            Contructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the order of Elements playing
            a particular domain role has changed for any source ModelElement changes
            </summary>
            <remarks>
            For example, add an event handler that is notified whenever the order of
            child columns is changed for any database table.  In this example, the
            "counterpart domain role" is the child-column role.
            </remarks>
            <param name="counterpartDomainRole">The role played by the elements whose order is changed</param>
            <param name="handler">The delegate that is to be called</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.Add(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Add an event handler that is notified whenever the order of Elements playing a
            particular role in relationships with a particular source ModelElement changes
            </summary>
            <remarks>
            For example, add an event handler that is called whenever the order of the
            columns of the Authors table is changed.  In this example, the "counterpart
            domain role" is the child-column role, while the "source ModelElement" is the 
            Authors table.
            </remarks>
            <param name="counterpartDomainRole">The role played by the elements whose order is changed</param>
            <param name="sourceElementId">The Id of the (parent) ModelElement ordering the (child) counterparts</param>
            <param name="handler">The handler to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the order of Elements playing a
            particular role in relationships with any source ModelElement changes
            </summary>
            <remarks>
            For example, remove an event handler that is notified whenever the order of
            child columns is changed for any database table.  In this example, the
            "counterpart domain role" is the child-column role.
            </remarks>
            <param name="counterpartDomainRole">The domain role played by the Elements whose order is changed</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.Remove(Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Delegate)">
            <summary>
            Remove an event handler that is notified whenever the order of Elements playing a
            particular role in relationships with a particular source ModelElement changes
            </summary>
            <remarks>
            For example, remove an event handler that is called whenever the order of the
            columns of the Authors table is changed.  In this example, the "counterpart
            domain role" is the child-column role, while the "source ModelElement" is the 
            Authors table.
            </remarks>
            <param name="counterpartDomainRole">The role played by the elements whose order is changed</param>
            <param name="sourceElementId">The Id of the (parent) ModelElement ordering the (child) counterparts</param>
            <param name="handler">The handler to remove</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that the order of Elements in an ordered relationship has changed
            </summary>
            <remarks>
            Notifies observers of the reodered domain role, then observers of the particular 
            source ModelElement/reordered domain role combination, then calls the base class implementation
            to notify observer of the domain relationship, domain model, and store.
            </remarks>
            <param name="sender">object that initiated the event</param>
            <param name="e">The RolePlayerOrderChangedEventArgs to pass to the observers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.NotifyDomainRolePlayerObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of a change in the order of Elements playing a particular domain role
            in relationships with any source ModelElement
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The RolePlayerOrderChangedEventArgs to pass to the observers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventManagerImpl.NotifyRolePlayerObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of a change in the order of Elements playing a particular domain role
            in relationships with a particular ModelElement
            </summary>
            <param name="sender">object that initiated the event</param>
            <param name="e">The RolePlayerOrderChangedEventArgs to pass to the observers</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementDeletedEventManagerImpl">
            <summary>
            Notification dispatcher for ModelElement Removed Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementDeletedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementMovedEventManagerImpl">
            <summary>
            Notification dispatcher for ModelElement Moved Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementMovedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.EventManagerDirectory">
            <summary>
            Summary description for EventManagerDirectory.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.EventManagerDirectory.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.EventManagerDirectory.OnDeserializationBeginning(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Notifies that deserialization has begun
            </summary>
            <param name="t">Serialization transaction</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.EventManagerDirectory.OnDeserializationEnding(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.DeserializationEndingEventArgs)">
            <summary>
            Notifies that deserialization has ended
            </summary>
            <param name="t">Serialization transaction</param>
            <param name="e">DeserializationEnding event args that contains completion status</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.EventManagerDirectory.OnMonikerResolutionEnded(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Notifies that element events are ending (transaction committing).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.TransactionBeginning">
            <summary>
            Event manager that handles TransactionBeginning events
            </summary>
            <value>TransactionBeginningEventManager</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.TransactionCommitted">
            <summary>
            Event manager that handles TransactionCommitted events
            </summary>
            <value>TransactionCommittedEventManager</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.TransactionRolledBack">
            <summary>
            Event manager that handles TransactionRolledBack events
            </summary>
            <value>TransactionRolledBackEventManager</value>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.EventManagerDirectory.DeserializationBeginning">
            <summary>
            Allows clients to receive DeserializationBeginning events
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.EventManagerDirectory.DeserializationEnding">
            <summary>
            Allows clients to receive DeserializationEnding events
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.ElementEventsBegun">
            <summary>
            Event manager that handles ElementEventsBegun events
            </summary>
            <value>ElementEventsBegunEventManager</value>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.EventManagerDirectory.MonikerResolutionEnded">
            <summary>
            Fired during top-level transaction commit to signal the ending of moniker resolution. Any remaining moniker should be
            considered unresolved.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.ElementEventsEnded">
            <summary>
            Event manager that handles ElementEventsEnded events
            </summary>
            <value>ElementEventsEndedEventManager</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.ElementAdded">
            <summary>
            Event manager that handles ElementAdded events
            </summary>
            <value>ElementAddedEventManager</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.ElementDeleted">
            <summary>
            Event manager that handles ElementRemoved events
            </summary>
            <value>ElementRemovedEventManager</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.ElementMoved">
            <summary>
            Event manager that handles ElementMoved events
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.ElementPropertyChanged">
            <summary>
            Event manager that handles ElementPropertyChanged events
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.RolePlayerChanged">
            <summary>
            Event manager that handles RolePlayerChanged events
            </summary>
            <value>RolePlayerChangedEventManager</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.EventManagerDirectory.RolePlayerOrderChanged">
            <summary>
            Event manager that handles RolePlayerOrderChanged events
            </summary>
            <value>RolePlayerOrderChangedEventManager</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeserializationEndingEventArgs">
            <summary>
            DeserializationEndingEventArgs - used to notify that Deserialization has ended
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeserializationEndingEventArgs.#ctor(Microsoft.VisualStudio.Modeling.CompletionStatus)">
            <summary>
            Sent when deserialization has completed
            </summary>
            <param name="status"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DeserializationEndingEventArgs.Status">
            <summary>
            completion status of the transaction
            </summary>
            <value>CompletionStatus</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.NotificationDispatcher">
            <summary>
            Notification dispatcher abstracts the operations of adding and deleting event handlers
            and for notifying observers of events.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.#ctor(System.Type,System.Type)">
            <summary>
            Constructor
            </summary>
            <param name="eventArgsType">The expected type of event arguments</param>
            <param name="handlerType">The expected type of event handler delegate</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.Add(Microsoft.VisualStudio.Modeling.DelegateHashKey,System.Delegate)">
            <summary>
            Add an event handler delegate for the events identified by a particular key
            </summary>
            <param name="key">The key for the event handler</param>
            <param name="handler">The event handler delegate</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.Remove(Microsoft.VisualStudio.Modeling.DelegateHashKey,System.Delegate)">
            <summary>
            Remove an event handler delegate for the events identified by a particular key
            </summary>
            <param name="key">The key for the event handler</param>
            <param name="handler">The event handler delegate</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.RemoveAllHandlers(Microsoft.VisualStudio.Modeling.DelegateHashKey)">
            <summary>
            Remove all event handlers for the events identified by a particular key
            </summary>
            <param name="key">The key for the event handler</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.HandlerAlreadyRegistered(Microsoft.VisualStudio.Modeling.DelegateHashKey,System.Delegate)">
            <summary>
            Is the input handler already registered for the events identified by
            the input key?
            </summary>
            <param name="key">The key for the event handler</param>
            <param name="handler">The event handler delegate</param>
            <returns>Whether the handler is already registered</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.NotifyObservers(System.Object,Microsoft.VisualStudio.Modeling.DelegateHashKey,System.EventArgs)">
            <summary>
            Notify observers of an event identified by a particular key that the
            event has occurred
            </summary>
            <param name="sender">The object that initiated the notification</param>
            <param name="key">The key identifying the event</param>
            <param name="e">The event arguments to be passed to the observers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.CheckArgsType(System.EventArgs)">
            <summary>
            Check whether the input event arguments are the expected type.
            </summary>
            <param name="e">The event arguments to check</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.CheckHandlerType(System.Delegate)">
            <summary>
            Check whether the event handler is the expected type.
            </summary>
            <param name="handler">The event handler to check</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.NotificationDispatcher.HandlerAlreadyRegistered(System.Delegate,System.Delegate)">
            <summary>
            Is the new handler already contained in the existing handler?
            </summary>
            <param name="existingHandler">The existing composite handler</param>
            <param name="newHandler">The handler we are checking</param>
            <returns>Whether the new handler is already contained in the existing handler</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.NotificationDispatcher.EventArgsType">
            <summary>
            The expected type of event arguments associated with this dispatcher
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.NotificationDispatcher.EventHandlerType">
            <summary>
            The expected type of event handler delegate associated with this dispatcher
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionEventArgs">
            <summary>
            Base class for transaction event arguments
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventArgs.#ctor(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Constructor
            </summary>
            <param name="transaction">The transaction for which the notification is being made</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionEventArgs.Transaction">
            <summary>
            The transaction for which the notification is being made.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionEventArgs.ElementId">
            <summary>
            Get the Id of the element to which this notification pertains
            </summary>
            <returns>empty guid</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionEventArgs.DomainClass">
            <summary>
            Get the domain class to which this notification pertains
            </summary>
            <returns>The domain class</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionEventArgs.DomainModel">
            <summary>
            Get the domain model to which this notification pertains
            </summary>
            <returns>The domain model</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs">
            <summary>
            Event arguments for begin-transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs.#ctor(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Constructor
            </summary>
            <param name="transaction">The transaction for which the notification is being made</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs">
            <summary>
            Event arguments for commit-transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs.#ctor(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Constructor
            </summary>
            <param name="transaction">The transaction for which the notification is being made</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionRollbackEventArgs">
            <summary>
            Event arguments for rollback-transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionRollbackEventArgs.#ctor(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Constructor
            </summary>
            <param name="transaction">The transaction for which the notification is being made</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionEventManager">
            <summary>
            abstract base class for managing Transaction Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManager.Add(System.Guid,System.Delegate)">
            <summary>
            Add an event handler for events on a particular transaction.
            </summary>
            <param name="transactionId">The Id of the transaction</param>
            <param name="handler">The event handler delegate</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManager.Remove(System.Guid,System.Delegate)">
            <summary>
            Remove an event handler for events on a particular transaction.
            </summary>
            <param name="transactionId">The Id of the transaction</param>
            <param name="handler">The event handler delegate</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionBeginningEventManager">
            <summary>
            Class that manages Transaction Beginning Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionBeginningEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionCommittedEventManager">
            <summary>
            Class that manages Transaction Committed Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionCommittedEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionRolledBackEventManager">
            <summary>
            Class that manages Transaction Rolled Back Events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionRolledBackEventManager.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionEventManagerImpl">
            <summary>
            The base class for managers of events associated with transactions.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManagerImpl.#ctor(System.Type,System.Type)">
            <summary>
            Constructor
            </summary>
            <param name="eventArgsType">The type of the event args for event handlers</param>
            <param name="delegateType">The type of the event handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManagerImpl.Add(System.Guid,System.Delegate)">
            <summary>
            Add an event handler for events on a particular transaction.
            </summary>
            <param name="transactionId">The Id of the transaction</param>
            <param name="handler">The event handler delegate</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManagerImpl.Remove(System.Guid,System.Delegate)">
            <summary>
            Remove an event handler for events on a particular transaction.
            </summary>
            <param name="transactionId">The Id of the transaction</param>
            <param name="handler">The event handler delegate</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManagerImpl.NotifyObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers that an event has occurred
            </summary>
            <param name="sender">The object that initiated the event</param>
            <param name="e">The event args for the handlers</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionEventManagerImpl.NotifyTransactionObservers(System.Object,System.EventArgs)">
            <summary>
            Notify observers of the particular transaction
            </summary>
            <param name="sender">The object that initiated the event</param>
            <param name="e">The event arguments passed to the event handlers</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionBeginningEventManagerImpl">
            <summary>
            The manager for begin-transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionBeginningEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionCommittedEventManagerImpl">
            <summary>
            The manager for commit-transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionCommittedEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionRolledBackEventManagerImpl">
            <summary>
            The manager for rollback-transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionRolledBackEventManagerImpl.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureContextHelper">
            <summary>
            Provides methods to add and retrieve closure context 
            information to and from a particular element walker context.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.#ctor(Microsoft.VisualStudio.Modeling.ElementWalker)">
            <summary>
            Constructor that binds to an ElementWalker 
            </summary>
            <param name="walker">the walker to bind to</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.#ctor(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Constructor that binds to an element group
            </summary>
            <param name="targetGroup">the element group</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.GetContextData(System.Object)">
            <summary>
            Get the ContextData for a single key
            </summary>
            <param name="key">the key to search for</param>
            <returns>object found or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.SetContextData(System.Object,System.Object)">
            <summary>
            Sets the data in the walker's context object for a particular key
            </summary>
            <param name="key">the key to set</param>
            <param name="value">the value to set</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.AddContextListData(System.Object,System.Object)">
            <summary>
            Adds the data to the list in the walker's context object for a particular key.
            This will create the list if it doesn't exist.
            </summary>
            <param name="key">the key of the list</param>
            <param name="value">the value to add to the list</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.GetClosureContext(Microsoft.VisualStudio.Modeling.ElementWalker)">
            <summary>
            used to get the closure context from the element walker
            </summary>
            <param name="walker">the walker that holds the closure context</param>
            <returns>IDictionary</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.GetContextData(Microsoft.VisualStudio.Modeling.ElementWalker,System.Object)">
            <summary>
            Get the ContextData for a single key
            </summary>
            <param name="walker">the walker that holds the context data</param>
            <param name="key">the key to search for</param>
            <returns>object found or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.SetContextData(Microsoft.VisualStudio.Modeling.ElementWalker,System.Object,System.Object)">
            <summary>
            Sets the data in the walker's context object for a particular key
            </summary>
            <param name="walker">the walker that will hold the context data</param>
            <param name="key">the key to set</param>
            <param name="value">the value to set</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.AddContextListData(Microsoft.VisualStudio.Modeling.ElementWalker,System.Object,System.Object)">
            <summary>
            Adds the data to the list in the walker's context object for a particular key.
            This will create the list if it doesn't exist.
            </summary>
            <param name="walker">the walker that will hold the context data</param>
            <param name="key">the key of the list</param>
            <param name="value">the value to add to the list</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.GetClosureContext(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            used to get the closure context from the element walker
            </summary>
            <param name="elementGroup">The element group that holds the closure context</param>
            <returns>IDictionary</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.GetContextData(Microsoft.VisualStudio.Modeling.ElementGroup,System.Object)">
            <summary>
            Get the ContextData for a single key
            </summary>
            <param name="elementGroup">the elementGroup that will hold the context data</param>
            <param name="key">the key to search for</param>
            <returns>object found or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.SetContextData(Microsoft.VisualStudio.Modeling.ElementGroup,System.Object,System.Object)">
            <summary>
            Sets the data in the walker's context object for a particular key
            </summary>
            <param name="elementGroup">the elementGroup that will hold the context data</param>
            <param name="key">the key to set</param>
            <param name="value">the value to set</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.AddContextListData(Microsoft.VisualStudio.Modeling.ElementGroup,System.Object,System.Object)">
            <summary>
            Adds the data to the list in the walker's context object for a particular key.
            This will create the list if it doesn't exist.
            </summary>
            <param name="elementGroup">the elementGroup that will hold the context data</param>
            <param name="key">the key of the list</param>
            <param name="value">the value to add to the list</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.AddClosureElementOperation(Microsoft.VisualStudio.Modeling.ElementWalker,Microsoft.VisualStudio.Modeling.ClosureElementOperation)">
            <summary>
            Add an element closure element operation to the walker's context
            </summary>
            <param name="walker">the walker</param>
            <param name="operation">the operation to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.AddClosureElementOperation(Microsoft.VisualStudio.Modeling.ElementGroup,Microsoft.VisualStudio.Modeling.ClosureElementOperation)">
            <summary>
            Add an element closure element operation to the group's context
            </summary>
            <param name="group">the Element group</param>
            <param name="operation">the operation to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.AddClosureElementOperation(Microsoft.VisualStudio.Modeling.ClosureElementOperation)">
            <summary>
            Add an element closure element operation to the associated context
            </summary>
            <param name="operation">the operation to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureContextHelper.Resolve(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Called to resolve the operation
            </summary>
            <param name="targetPartition">the containing partition</param>
            <returns>true when successful, false otherwise</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureContextHelper.ClosureContext">
            <summary>
            Get all the Context object from the walker
            </summary>
            <value>IDictionary</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureElementOperation">
            <summary>
            Base closure element operation
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ClosureElementOperation.ClosureElementOperationList">
            <summary>
            The key to which closure element operations context info is bound
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureElementOperation.#ctor">
            <summary>
            Default constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureElementOperation.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureElementOperation.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populates a SerializationInfo with the data needed to serialize the target object.
            This method is executed during serialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamingContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureElementOperation.Resolve(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Performs target resolution of this operation
            </summary>
            <param name="targetPartition">the target partition</param>
            <param name="group">the element group</param>
            <returns>true if successful, false otherwise</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation">
            <summary>
            Closure operation that is used to mark a find target element operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.#ctor">
            <summary>
            Default constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.#ctor(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Constructor
            </summary>
            <param name="sourceElement">model element from the source store</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populates a SerializationInfo with the data needed to serialize the target object.
            This method is executed during serialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamingContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.Matches(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            abstract method to determine that an element matches the one described by this find operation
            </summary>
            <param name="element">the target element to compare</param>
            <returns>true if the element matches</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.FindElement(System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.Store,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            default brute force search operation
            </summary>
            <param name="elementId">Id of the source element to search for</param>
            <param name="domainClassId">Id of the class to search for</param>
            <param name="elementGroup">Containing Element Group</param>
            <param name="targetStore">Store to search</param>
            <returns>The found element or null if not found</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.Resolve(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Performs target resolution of this operation
            </summary>
            <param name="targetPartition">the target partition</param>
            <param name="group">the element group</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.SourceElementId">
            <summary>
            Id of the element in the source store
            </summary>
            <value>Guid</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.SourceElementDomainClassId">
            <summary>
            Id of the domain class of the element
            </summary>
            <value>Guid</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.TargetElementId">
            <summary>
            Id of the element as found in the target store
            </summary>
            <value>Guid</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindElementOperation.TargetElement">
            <summary>
            The element as found in the target store
            </summary>
            <value>ModelElement</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation">
            <summary>
            Closure operation that is used to mark a find or create target element operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation.#ctor">
            <summary>
            Default Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation.#ctor(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Constructor
            </summary>
            <param name="sourceElement"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populates a SerializationInfo with the data needed to serialize the target object.
            This method is executed during serialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamingContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation.FindOrCreateElement(System.Guid,System.Guid,Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Used to find an element in the target store or create it if it doesn't exist
            </summary>
            <param name="targetPartition">the parttion to search or create the new element</param>
            <param name="sourceElementId">Id of the source element to find or create</param>
            <param name="domainClassId">Id of the domain class for the element</param>
            <param name="elementGroup">Element group</param>
            <returns>the existing ModelElement or the newly created one if no existing match was found</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateElementOperation.Resolve(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Performs target resolution of this operation
            </summary>
            <param name="targetPartition">the target Partition</param>
            <param name="group">the element group</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation">
            <summary>
            Closure operation that is used to mark a find or create target element operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.#ctor">
            <summary>
            Default Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            Constructor
            </summary>
            <param name="copiedSourceElement">The element that will be copied into the target store</param>
            <param name="copiedSourceRoleInfo">The Role of the copied element in the relationship</param>
            <param name="foundElement">The element that must be searched for and found in the target.</param>
            <param name="foundDomainRole">The Role of the foundElement in the relationship</param>
            <param name="domainRelationship">The relationship that must be created</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populates a SerializationInfo with the data needed to serialize the target object.
            This method is executed during serialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamingContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.ResolveCopiedTargetElement(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Resolves the target element that was copied to the Partition
            </summary>
            <param name="targetPartition">Target Partition</param>
            <param name="group">element group for this operation</param>
            <returns>ModelElement or null if not copied</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.ResolveDomainRelationship(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Gets the DomainRelationshipInfo for the DomainClassId
            </summary>
            <param name="targetPartition">Partition to use for getting the meta data</param>
            <returns>DomainRelationshipInfo or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.ResolveFindElement(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Resolve searching for an element in an existing store
            </summary>
            <param name="targetPartition">the target partition to search</param>
            <param name="group">the associated element group</param>
            <returns>ModelElement or null</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.ResolveCreateElementLink(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Resolves creating an element link in the target store
            </summary>
            <param name="targetPartition">the Partition in which to create the element link</param>
            <returns>the created element link</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.Resolve(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Performs target resolution of this operation
            </summary>
            <param name="targetPartition">the target partition</param>
            <param name="group">the element group</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.CopiedTargetElement">
            <summary>
            The copied element as found in the target store
            </summary>
            <value>ModelElement</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.CopiedRoleId">
            <summary>
            The id of the domainRole that the copied source object plays in the relationship
            </summary>
            <value>Guid</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.FoundRoleId">
            <summary>
            The id of the domainRole that the found target element plays in the relationship
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateElementOperation.TargetDomainRelationshipId">
            <summary>
            The id of the domain relationship to create
            </summary>
            <value>Guid</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateOrDeleteCopiedElementOperation">
            <summary>
            Closure operation that is used to find and relate to an element or delete the
            copied element if the target is not found
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateOrDeleteCopiedElementOperation.#ctor">
            <summary>
            Default Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateOrDeleteCopiedElementOperation.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            Constructor
            </summary>
            <param name="copiedSourceElement">The element that will be copied into the target store or deleted if the target is not found</param>
            <param name="copiedSourceRoleInfo">The Role of the copied element in the relationship</param>
            <param name="foundElement">The element that must be searched for and found in the target.</param>
            <param name="foundRoleInfo">The Role of the foundElement in the relationship</param>
            <param name="domainRelationshipInfo">The relationship that must be created if the target is found</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateOrDeleteCopiedElementOperation.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindAndRelateOrDeleteCopiedElementOperation.Resolve(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Performs target resolution of this operation
            </summary>
            <param name="targetPartition">the target partition</param>
            <param name="group">the element group</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateAndRelateElementOperation">
            <summary>
            Closure operation that is used to mark a find or create target element operation
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateAndRelateElementOperation.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainRoleInfo,Microsoft.VisualStudio.Modeling.DomainRelationshipInfo)">
            <summary>
            Constructor
            </summary>
            <param name="copiedSourceElement">The element that will be copied into the target store</param>
            <param name="copiedSourceRoleInfo">The Role of the copied element in the relationship</param>
            <param name="foundElement">The element that must be searched for and found in the target.</param>
            <param name="foundRoleInfo">The Role of the foundElement in the relationship</param>
            <param name="domainRelationshipInfo">The relationship that must be created</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateAndRelateElementOperation.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Protected constructor.
            It is executed during deserialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateAndRelateElementOperation.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populates a SerializationInfo with the data needed to serialize the target object.
            This method is executed during serialization.
            </summary>
            <param name="info">SerializationInfo</param>
            <param name="context">StreamingContext</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateAndRelateElementOperation.ResolveCreateElement(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Resolves creating a new element in the target partition
            </summary>
            <param name="targetPartition">the partition in which to create the new element</param>
            <returns>the new ModelElement</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ClosureFindOrCreateAndRelateElementOperation.Resolve(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Perform resolution on this operation
            </summary>
            <param name="targetPartition">the target partition</param>
            <param name="group"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CopyOriginContext">
            <summary>
            Provides information regarding the origin of the
            ElementGroupPrototype.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the CopyOriginContext class.
            This is used for deserialization.
            </summary>
            <param name="info">The SerializationInfo that contains the serialized data with which to initialize this instance.</param>
            <param name="context">The destination (see StreamingContext) for this serialization.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populates a SerializationInfo with the data needed to serialize this object.
            </summary>
            <param name="info">The SerializationInfo to populate with data.</param>
            <param name="context">The destination (see StreamingContext) for this serialization.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.Set(Microsoft.VisualStudio.Modeling.ElementGroupPrototype,System.String)">
            <summary>
            Adds the ElementGroupPrototype origin information to the ElementGroupPrototype.
            </summary>
            <param name="elementGroupPrototype">The ElementGroupPrototype to save the origin context information to.</param>
            <param name="copyOrigin">The text that represents the origin of the ElementGroupPrototype.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.HasContext(Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Returns true if the elementGroupPrototype's SourceContext has a CopyOriginContext.
            </summary>
            <param name="elementGroupPrototype">The elementGroupPrototype to inspect.</param>
            <returns>True if the elementGroupPrototype's SourceContext has a CopyOriginContext.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.HasContext(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Returns true if the transaction's ContextInfo has a CopyOriginContext.
            </summary>
            <param name="transaction">The transaction to inspect.</param>
            <returns>True if the transaction's ContextInfo has a CopyOriginContext.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.GetCopyOrigin(Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Returns the text that represents the origin of the ElementGroupPrototype, or String.Empty if not found.
            </summary>
            <param name="elementGroupPrototype">The ElementGroupPrototype where the CopyOriginContext has been saved to.</param>
            <returns>The text that represents the origin of the ElementGroupPrototype, or String.Empty if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.GetCopyOrigin(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Returns the text that represents the origin of the ElementGroupPrototype, or String.Empty if none exists.
            </summary>
            <param name="elementGroup">The ElementGroup where the CopyOriginContext has been saved to.</param>
            <returns>The text that represents the origin of the ElementGroupPrototype, or String.Empty if none exists.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CopyOriginContext.GetCopyOrigin(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Returns the text that represents the origin of the ElementGroupPrototype that is being merged during the specified transaction,
            or String.Empty if none exists.
            </summary>
            <param name="transaction">The transaction in which the ElementGroupPrototype's CopyOriginContext was copied.</param>
            <returns>
            The text that represents the origin of the ElementGroupPrototype that is being merged during the specified transaction,
            or String.Empty if none exists.
            </returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.CopyOriginContext.Origin">
            <summary>
            Gets a string that describes the 
            origin of the ElementGroupPrototype.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementGroup">
            <summary>
            ElementGroup provides a way to collect elements and element links.
            </summary>
            <remarks>
            ElementGroup is intended to facilitate serialization of groups of 
            elements from one store to another.
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroup.ElementGroupIdDictionary">
            <summary>
            Key used in the TargetContext ElementGroupContext for the Element Id dictionary.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
            <param name="store">The store that contains the elements in the group.  Will go to the default partition</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.#ctor(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Constructor
            </summary>
            <param name="partition">The partition that contains the elements in the group</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.Add(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Add a single element to the group.  If the element is related to other
            elements already in the group, the element links between the related
            elements are added as well.
            </summary>
            <param name="element">The element to add to the group</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.AddRange(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Adds a collection of model elements to the group.
            </summary>
            <param name="modelElements">Collection of elements to be added to the group.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.MarkAsRoot(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Marks an element in the group as a root element.
            </summary>
            <param name="rootElement"></param>
            <exception cref="T:System.ArgumentException">Thrown if the given element is not a member of the group.</exception>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.AddGraph(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>	
            Add an element and its children to the group
            </summary>
            <param name="element">The element to add</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.AddGraph(Microsoft.VisualStudio.Modeling.ModelElement,System.Boolean)">
            <summary>	
            Add an element and its children to the group
            </summary>
            <param name="element">The element to add</param>
            <param name="isRootElement">True if element should also be a root, false otherwise.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.GetElements">
            <summary>
            Get the set of elements contained by this group.  This does not
            include the set of elements contained by child subgroups.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.GetElements(System.Guid)">
            <summary>
            Get the set of element instances of a particular domain class that
            are contained in this group.  This does not include the set of
            elements contained by child subgroups.
            </summary>
            <param name="domainClassId">The Id of the domain class of the elements we are looking for</param>
            <returns>The set of contained elements</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroup.CreatePrototype">
            <summary>
            Create a prototype for this element group
            </summary>
            <returns>the newly created prototype</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.Partition">
            <summary>
            The Partition the group was created for.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.Id">
            <summary>
            The Id of the group
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.UserData">
            <summary>
            The user defined serializable data object
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.SourceContext">
            <summary>
            Returns this ElementGroup's source ElementGroup context object
            </summary>
            <value>Source ElementGroupContext object for this element group</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.TargetContext">
            <summary>
            Returns this ElementGroup's target ElementGroup context object
            </summary>
            <value>Target ElementGroupContext object for this element group</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.RootElements">
            <summary>
            The distinguished element of the group (e.g. the root of a tree, head of a list, etc.)
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.ElementLinks">
            <summary>
            Get the set of element links contained by this group.  THis does not
            include the element links contained by child subgroups.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.ElementIds">
            <summary>
            Get a list of the Id's of the elements contained in this group
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.ElementLinkIds">
            <summary>
            Get a list of the Id's of the element links contained in this group
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.RootElementIds">
            <summary>
            Get a list of the Ids of the element links contained in this group
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroup.ModelElements">
            <summary>
            Get a list of all the elements contained by this
            element group and all child element groups
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementGroupContext">
            <summary>
            Stores context information about an element group.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupContext.#ctor">
            <summary>
            Creates an instance of the ElementGroupContext class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupContext.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serialization constructor
            </summary>
            <param name="info">The serialization information</param>
            <param name="context">The streaming context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupContext.System#Runtime#Serialization#IDeserializationCallback#OnDeserialization(System.Object)">
            <summary>
            Reconstruct the table here, when the entire object graph has been deserialized.
            </summary>
            <param name="sender"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupContext.System#Runtime#Serialization#ISerializable#GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populate the serialization info with this object's data.
            </summary>
            <param name="info">The serialization info object.</param>
            <param name="context">The streaming context.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupContext.CopyFrom(Microsoft.VisualStudio.Modeling.ElementGroupContext)">
            <summary>
            Internal copy constructor to create a clone.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupContext.ContextInfo">
            <summary>
            Context information.  Used to hold tag/value pairs
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementGroupPrototype">
            <summary>
            ElementGroupPrototype contains the information necessary to
            recreate an ElementGroup in any store.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.CreatingKey">
            <summary>
            Key for context info search
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ElementGroupIdDictionary">
            <summary>
            Key used in the TargetContext ElementGroupContext for the Element Id dictionary
            and root element (Id) lists.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.RootElementIdList">
            <summary>
            Key used in the Source and Target Context ElementGroupContext for the RootElement Id list
            and root element (Id) lists.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.RootElementList">
            <summary>
            Key used in the Source and Target Context ElementGroupContext for the RootElement list
            and root element lists.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.egpPrototypeMode">
            <summary>
            This is the mode for recording whether we're in the regular object instance mode or DomainClassType model. 
            Normally, an egp contains ModelElement for merging. In the *special* DomainClassType mode, we only need
            the doamin class ID to determine if it can be merged under another model element (This mode is mainly used 
            by ElementOperation.CanMergeElementGroupPrototype APIs
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.serializationInfo">
            <summary>
            Store for serialialization info between the time this element is deserializaed and the callback when its properties are deserializaed.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.DefaultDataFormatName">
            <summary>
            The default data format name for the ElementGroupPrototype.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.#ctor(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Creates an instance of ElementGroupPrototype class.
            </summary>
            <param name="group">The element group that is to be recreated</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid)">
            <summary>
            Constructor for taking a rool domain class Id. This is used to determine whether an element can be 
            merged under an parent element.
            </summary>
            <param name="partition">partition this rootElementDomainClassId resides</param>
            <param name="rootElementDomainClassId">represents domain class Id of the single root element</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.#ctor(Microsoft.VisualStudio.Modeling.ElementGroup,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Constructor
            </summary>
            <param name="group">The element group that is to be recreated</param>
            <param name="rootElements">ICollection of the root elements for this group</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Constructor
            </summary>
            <param name="partition">partition for this element group prototype</param>
            <param name="rootElements">collection of root elements</param>
            <param name="closureGroup">element group containing the closure</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serialization constructor
            </summary>
            <param name="info">The serialization information</param>
            <param name="context">The streaming context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.System#Runtime#Serialization#IDeserializationCallback#OnDeserialization(System.Object)">
            <summary>
            Deserialize the object when the graph is fully loaded
            </summary>
            <param name="sender"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populate the serialization info with the data necessary to serialize this object.
            </summary>
            <param name="info">The serialization information</param>
            <param name="context">The streaming context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.IsInRole(Microsoft.VisualStudio.Modeling.ProtoElementBase,System.Guid)">
            <summary>
            Returns true if the passed ProtoElementBase plays in the passed role in this ElementGroupPrototype.
            </summary>
            <param name="protoElementBase">The ProtoElementBase to test.</param>
            <param name="domainRoleId">The Guid of the DomainRoleId to test.</param>
            <returns>true if the passed ProtoElementBase plays in the passed role in this ElementGroupPrototype.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.GetProtoLinks(Microsoft.VisualStudio.Modeling.ProtoElementBase,System.Guid)">
            <summary>
            Returns an IList of ProtoLink objects that contain the passed ProtoElementBase playing in the passed DomainRoleId.
            </summary>
            <param name="protoElementBase">The ProtoElement to use.</param>
            <param name="domainRoleId">The Guid of the DomainRoleId to use.</param>
            <returns>An IList of ProtoLink objects that contain the passed ProtoElementBase playing in the passed DomainRoleId.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ResolveProtoLinks(System.Collections.ObjectModel.Collection{Microsoft.VisualStudio.Modeling.ProtoLink},System.Guid)">
            <summary>
            Resolves the passed IList of ProtoLinks into the ProtoElements that play in the passed DomainRoleId.
            </summary>
            <param name="protoLinksToResolve">An IList of ProtoLinks to resolve.</param>
            <param name="domainRoleId">The Guid DomainRoleId to resolve.</param>
            <returns>An IList of ProtoElements that are playing in the passed DomainRoleId.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.GetProtoElement(System.Guid)">
            <summary>
            Get the ProtoElement corresponding to the specified id.
            </summary>
            <param name="id">The id of the source ProtoElement.</param>
            <returns>The ProtoElement corresponding to the specified id; null if the ProtoElement was not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.CanCreateElementGroup(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Can this prototype element group create a clone of the progenitor
            element group in the indicated store?
            </summary>
            <remarks>
            This is a two part check:
            	(1) Is the input stores version the same or later than the progenitor store's version
            	(2) Are all the domain classes required to create the Elements and ElementLinks present in the store
            </remarks>
            <param name="store">The store in which to create the clone ElementGroup</param>
            <returns>Whether the clone can be created</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.CanCreateElementGroup(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Can this prototype element group create a clone of the progenitor
            element group in the indicated partition?
            </summary>
            <remarks>
            This is a two part check:
            	(1) Is the input stores version the same or later than the progenitor store's version
            	(2) Are all the domain classes required to create the Elements and ElementLinks present in the store
            </remarks>
            <param name="partition">The partition in which to create the clone ElementGroup</param>
            <returns>Whether the clone can be created</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.CreateElementGroup(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Create a clone of the progenitor element group
            </summary>
            <param name="store">The store in which to create the clone</param>
            <returns>The clone element group</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.CreateElementGroup(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Create a clone of the progenitor element group
            </summary>
            <param name="partition">The partition in which to create the clone</param>
            <returns>The clone element group</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.GetReconstitutedElement(Microsoft.VisualStudio.Modeling.Transaction,System.Guid)">
            <summary>
            Returns the reconstituted ModelElement given the guid of the source ModelElement.
            </summary>
            <param name="transaction">The transaction in which the elements were reconstituted from the ElementGroupPrototype.</param>
            <param name="sourceElementId">The id of the source ModelElement</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.CreateIdDictionary(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Create a map from the Id's of the progenitor Elements to new Id's for the clone Elements
            </summary>
            <param name="partition">The partition in which we are creating the clones</param>
            <returns>The Id map</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.GetSourceRootElementId(System.Guid)">
            <summary>
            Gets the id of the source root ModelElement that corresponds to 
            the specified target root ModelElement id.  If it was not found,
            Guid.Empty is returned.
            </summary>
            <param name="targetRootElementId">The id of the target root ModelElement.</param>
            <returns>The id of the source root ModelElement that corresponds to the specified target root ModelElement id.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ReconstituteElements(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Create clones of all the progenitor Elements
            </summary>
            <param name="idDictionary">The Id map for the clones</param>
            <param name="partition">The partition in which to create the clones</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ReconstitutedRootElementIdList(System.Collections.Generic.Dictionary{System.Guid,System.Guid})">
            <summary>
            Build a list of the new id's of the root elements based on the old id's
            </summary>
            <param name="idDictionary">The Id map for the clones</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ReconstituteLinks(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Create clones of all the progenitor ElementLinks
            </summary>
            <param name="idDictionary">The Id map for the clones</param>
            <param name="partition">The partition in which to create the clones</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ToString(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Dumps out the names of the Elements and ElementLinks in this ElementGroupPrototype, given the
            DomainClass definitions in the provided partition.
            </summary>
            <param name="partition">The partition is used to look up the DomainClass definitions for the elements in this ElementGroupPrototype.</param>
            <returns>A list of the Elements and ElementLinks.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.SourceContext">
            <summary>
            Returns this ElementGroupPrototype's source ElementGroupContext object
            </summary>
            <value>Source ElementGroupContext object for this element group prototype</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.TargetContext">
            <summary>
            Returns this ElementGroupPrototype's target ElementGroupContext object
            </summary>
            <value>Target ElementGroupContext object for this element group prototype</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.UserData">
            <summary>
            The user-defined data object from the outer-most element group
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ProtoElements">
            <summary>
            Gets collection of all ProtoElements contained in the ElementGroupPrototype.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.ProtoElementLinks">
            <summary>
            Gets collection of all ProtoElementLinks contained in the ElementGroupPrototype.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.SourceRootElementIds">
            <summary>
            returns a read-only list of root element ids from the source context
            </summary>
            <value>Read-only IList</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.TargetRootElementIds">
            <summary>
            returns a read-only list of root element ids from the target context
            </summary>
            <value>Read-only IList</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.RootProtoElements">
            <summary>
            Gets collection of all root ProtoElements contained in the ElementGroupPrototype.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementGroupPrototype.EgpPrototypeMode">
            <summary>
            private enum to determine which mode this EGP is. In the InDomainClassType mode, all we have in the EGP is the domain class ID for
            determine whether the domain class can be merged under a parent element.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementOperations">
            <summary>
            The class used to provide common operations that 
            act upon a collection of ModelElements.
            </summary>
            <remarks>
            Derive from this class to create custom data formats 
            for copy and paste operations.
            </remarks>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ElementOperations.cachedPrototype">
            <summary>
            A cached ElementGroupPrototype from the last IDataObject seen.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.#ctor(System.IServiceProvider)">
            <summary>
            Initializes a new instance of the ElementOperations class.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Initializes a new instance of the ElementOperations class.
            </summary>
            <param name="serviceProvider">The service provider to use.</param>
            <param name="partition">The partition that the ModelElements belong to.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.#ctor(System.IServiceProvider,Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Initializes a new instance of the ElementOperations class.
            </summary>
            <param name="serviceProvider">The service provider to use.</param>
            <param name="store">The store that the ModelElements belong to.  Uses the store's default partition</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanMove(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Gets a value indicating whether the collection of ModelElements can be moved.
            </summary>
            <param name="elements">The collection of ModelElements to move.</param>
            <returns>true if the collection of ModelElements can be moved.</returns>
            <remarks>By default, this has the same implementation as CanCopy.</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanCopy(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Gets a value indicating whether the collection of ModelElements can be copied
            to an IDataObject.
            </summary>
            <param name="elements">The collection of ModelElements to copy.</param>
            <returns>true if the collection of ModelElements can be copied
            to an IDataObject.</returns>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
            <remarks>
            The assumed closure type is the ClosureType.CopyClosure.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanCopy(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Gets a value indicating whether the collection of ModelElements can be copied
            to an IDataObject.
            Calls CanCopyCore to do the work.
            </summary>
            <param name="elements">The collection of ModelElements to copy.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <returns>true if the collection of ModelElements can be copied
            to an IDataObject.</returns>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanCopyCore(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Gets a value indicating whether the collection of ModelElements can be copied
            to an IDataObject.
            This is implemented outside of CanCopy, so that subclasses can
            override the public CanCopy and CanMove methods independently. If
            subclasses want to have the same behavior for both CanCopy and
            CanMove, they can just override this method.  (Before this method
            existed, overriding only CanCopy led to the side effect of
            changing the CanMove behavior.)
            </summary>
            <param name="elements">The collection of ModelElements to copy.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <returns>true if the collection of ModelElements can be copied
            to an IDataObject.</returns>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.Copy(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Copies the collection of ModelElements to the specified IDataObject in 
            one or more data formats.
            </summary>
            <param name="data">The IDataObject to add the data formats to.</param>
            <param name="elements">The collection of ModelElements to copy.</param>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
            <remarks>
            The assumed closure type is the ClosureType.CopyClosure.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.Copy(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},System.Drawing.PointF)">
            <summary>
            Copies the collection of ModelElements to the specified IDataObject in 
            one or more data formats.
            </summary>
            <param name="data">The IDataObject to add the data formats to.</param>
            <param name="elements">The collection of ModelElements to copy.</param>
            <param name="sourcePosition">The mouse position where the drop occured, PointF.Empty if not a drag/drop operation.</param>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
            <remarks>
            The assumed closure type is the ClosureType.CopyClosure.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.Copy(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Copies the collection of ModelElements to the specified IDataObject in 
            one or more data formats.
            </summary>
            <param name="data">The IDataObject to add the data formats to.</param>
            <param name="elements">The collection of ModelElements to copy.</param>
            <param name="closureType">The closure of ModelElements to copy.</param>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.Copy(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Drawing.PointF)">
            <summary>
            Copies the collection of ModelElements to the specified IDataObject in 
            one or more data formats.
            </summary>
            <param name="data">The IDataObject to add the data formats to.</param>
            <param name="elements">The collection of ModelElements to copy.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <param name="sourcePosition">The mouse position where the drop occured, PointF.Empty if not a drag/drop operation.</param>
            <remarks>
            The supported formats:
            (1) ElementGroupPrototype, and
            (2) custom formats
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanMerge(Microsoft.VisualStudio.Modeling.ModelElement,System.Windows.Forms.IDataObject)">
            <summary>
            Returns a value indicating whether the ElementGroupPrototype from
            the IDataObject can be merged (i.e., pasted or dropped) into the
            target ModelElement.
            </summary>
            <param name="targetElement">The ModelElement that is the target for the ElementGroupPrototype.</param>
            <param name="data">The IDataObject potentially containing the ElementGroupPrototype.</param>
            <returns>true if the ElementGroupPrototype from the IDataObject can be merged into the target ModelElement. Otherwise, false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanMergeElementGroupPrototype(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Returns a value indicating whether MergeElementGroupPrototype can be performed.
            </summary>
            <param name="targetElement">
            The ModelElement that will serve as the target for the reconstituted elements 
            from the ElementGroupPrototype.
            </param>
            <param name="elementGroupPrototype">
            The ElementGroupPrototype that will be reconstituted in the target element's store.
            </param>
            <returns>A value indicating whether MergeElementGroupPrototype can be performed.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanMergeElementGroupPrototype(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ProtoElementBase,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Gets a value indicating whether MergeElementGroupPrototype can be performed 
            given the particular hoist and element group prototype.
            The CanMergeElementGroupPrototype process calls this overload for each root 
            ProtoElement in the ElementGroupPrototype to determine if either the target  
            element or the target's associated model element (if applicable) can serve 
            as the target of the element represented by the ProtoElement.
            </summary>
            <param name="targetElement">
            The ModelElement that will serve as the target for the reconstituted elements 
            from the ElementGroupPrototype.
            </param>
            <param name="toMergeProtoElement">
            A root ProtoElement in the ElementGroupPrototype that, when reconstituted, 
            will become merged into the target element.
            This parameter can be null, in which case the ElementGroupPrototype does 
            not contain any ProtoElements.
            </param>
            <param name="elementGroupPrototype">
            The ElementGroupPrototype containing the root ProtoElements.
            </param>
            <returns>a value indicating whether MergeElementGroupPrototype can be performed given the particular target and child.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.Merge(Microsoft.VisualStudio.Modeling.ModelElement,System.Windows.Forms.IDataObject)">
            <summary>
            Merges (i.e., pastes or drops) the ElementGroupPrototype from the IDataObject
            to the target ModelElement.
            </summary>
            <param name="targetElement">The ModelElement that is the target for the ElementGroupPrototype.</param>
            <param name="data">The IDataObject potentially containing the ElementGroupPrototype.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.MergeCore(Microsoft.VisualStudio.Modeling.ModelElement,System.Windows.Forms.IDataObject)">
            <summary>
            Core merge code. 
            </summary>
            <param name="targetElement">The ModelElement that is the target for the ElementGroupPrototype.</param>
            <param name="data">The IDataObject potentially containing the ElementGroupPrototype.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.MergeElementGroupPrototype(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Merges the source ElementGroupPrototype with the specified target ModelElement.
            This method performs the following:
              (1) reconstitutes the elements from the ElementGroupPrototype, 
              (2) calls OnElementsReconstituted to provide any ElementOperations-derived
                  class the opportunity to plug in custom processing,
              (3) calls the target element's MergeRelate virtual method for each 
                  reconstituted root element to provide the target with the opportunity 
                  to connect a root element to itself,
              (4) calls the virtual method MergeConfigure on the reconstituted root element 
                  immediately after calling MergeRelate to provide the root element with an 
                  opportunity to configure itself, and
              (5) calls OnMerged to provide any ElementOperations-derived class the
                  opportunity to plug in custom processing.
            </summary>
            <param name="targetElement">The target element which will serve as the parent of the reconstituted elements.</param>
            <param name="elementGroupPrototype">The source ElementGroupPrototype.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.MergeElementGroup(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Merges the source ElementGroup with the specified target ModelElement.
            This method is intended for use when an ElementGroupPrototype is not available, that is,
            when a collection of actual ModelElements should be merged.  If an ElementGroupPrototype is 
            available (e.g., clipboard scenarios), call MergeElementGroupProtoype instead.
            This method performs the following:
              (1) calls the target element's MergeRelate virtual method for each 
                  root element in the group to provide the target with the opportunity 
                  to connect a root element to itself,
              (2) calls the virtual method MergeConfigure on the root element 
                  immediately after calling MergeRelate to provide the root element with an 
                  opportunity to configure itself, and
              (3) calls OnMerged to provide any ElementOperations-derived class the
                  opportunity to plug in custom processing.
            </summary>
            <param name="targetElement">The target element which will serve as the parent of the reconstituted elements.</param>
            <param name="elementGroup">The source ElementGroup.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.ChooseMergeTarget(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Gets the target element for the merge, given the proposed targetElement.
            This gives the ElementOperations the chance to change the 
            intended target for the merge.  By default, this method will
            give the target element the chance to change the intended target.
            </summary>
            <param name="proposedTargetElement">The proposed target element for the merge.</param>
            <param name="elementGroup">The ElementGroup that will be connected into the target's store during the merge.</param>
            <returns>The target element for the merge.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.ChooseMergeTarget(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Gets the target element for the merge, given the proposed targetElement.
            This gives the ElementOperations the chance to change the 
            intended target for the merge.  By default, this method will
            give the target element the chance to change the intended target.
            </summary>
            <param name="proposedTargetElement">The proposed target element for the merge.</param>
            <param name="elementGroupPrototype">The ElementGroupPrototype that will be reconstituted in the target's store during the merge.</param>
            <returns>The target element for the merge.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.OnMerging(Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs)">
            <summary>
            Called by MergeElementGroupPrototype immediately after the target element
            has been chosen, but before the elements from the ElementGroupPrototype have 
            been reconstituted.
            </summary>
            <param name="e">A MergeElementGroupEventArgs that contains event data.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.OnElementsReconstituted(Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs)">
            <summary>
            Called by MergeElementGroupPrototype immediately after the elements from 
            the ElementGroupPrototype have been reconstituted, but before they are 
            connected to the rest of the model.
            </summary>
            <param name="e">A MergeElementGroupEventArgs that contains event data.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.OnMerged(Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs)">
            <summary>
            Called by MergeElementGroupPrototype immediately before the local transaction 
            is committed.  The rules are queued during the local transaction and fired 
            when the transaction commits.  The local transaction wraps reconstituting and
            connecting elements.
            </summary>
            <param name="e">A MergeElementGroupEventArgs that contains event data.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanAddElementGroupFormat(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Returns a value indicating whether the ModelElement collection
            can be used to create an ElementGroupPrototype format.
            </summary>
            <param name="elements">The collection of ModelElements.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <returns>true if the ModelElement collection can be used to create
            an ElementGroupPrototype format; otherwise, false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.AddElementGroupFormat(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Adds the ElementGroupPrototype format to the specified IDataObject using
            the specified collection of ModelElements.
            </summary>
            <param name="data">The IDataObject to add the ElementGroupPrototype data format to.</param>
            <param name="elements">The collection of ModelElements.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <remarks>
            The data format name is assumed to be typeof(ElementGroupPrototype).FullName.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.AddElementGroupFormat(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean)">
            <summary>
            Adds the ElementGroupPrototype format to the specified IDataObject using
            the specified collection of ModelElements.
            Can be called from derived classes to force demand load of element links in order to create the collection of model elements.
            </summary>
            <param name="data">The IDataObject to add the ElementGroupPrototype data format to.</param>
            <param name="elements">The collection of ModelElements.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <param name="bypassDemandLoading">Whether or not element links should be demand loaded in order to create the collection of model elements.</param>
            <remarks>
            The data format name is assumed to be typeof(ElementGroupPrototype).FullName.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CanAddCustomFormat(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Returns a value indicating whether the ModelElement collection
            can be used to create a custom format.
            </summary>
            <param name="elements">The collection of ModelElements.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <returns>true if the ModelElement collection can be used to create a custom format; otherwise, false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.AddCustomFormat(System.Windows.Forms.IDataObject,System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Drawing.PointF)">
            <summary>
            Adds one or more custom data formats to the specified IDataObject using the
            specified collection of ModelElements.
            </summary>
            <param name="data">The IDataObject to add the custom data formats to.</param>
            <param name="elements">The collection of ModelElements.</param>
            <param name="closureType">The type of closure to use to filter the elements.</param>
            <param name="sourcePosition">The positions of the ModelElements in the source</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.GetElementGroupPrototype(System.IServiceProvider,System.Windows.Forms.IDataObject)">
            <summary>
            Gets the ElementGroupPrototype from the DataObject if it exists.
            </summary>
            <param name="serviceProvider">The service provider to use for retrieving the IToolboxService.</param>
            <param name="data">The IDataObject to retrieve the ElementGroupPrototype from.</param>
            <returns>The ElementGroupPrototype from the DataObject.</returns>
            <remarks>
            The data format name is assumed to be ElementGroupPrototype.DefaultDataFormatName.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.IsElementGroupPrototypeFormatAvailable">
            <summary>
            Returns true if the ElementGroupPrototype clipboard format is available on the clipboard, otherwise false.
            </summary>
            <returns>True if the ElementGroupPrototype clipboard format is available on the clipboard, otherwise false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.GetClipboardDataObject">
            <summary>
            Returns an IDataObject from the Clipboard if it contains our ElementGroupPrototype format, otherwise null.
            </summary>
            <returns>An IDataObject from the Clipboard if it contains our ElementGroupPrototype format, otherwise null.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.GetModelingToolboxItemDisplayName(System.IServiceProvider,System.Windows.Forms.IDataObject)">
            <summary>
            If the IDataObject contains a ModelingToolboxItem, this returns its DisplayName, otherwise null.
            </summary>
            <param name="serviceProvider">The service provider to use for retrieving the IToolboxService.</param>
            <param name="data">The IDataObject to retrieve the ModelingToolboxItem data from.</param>
            <returns>A ModelingToolboxItem.DisplayName if it exists, otherwise null.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.GetModelingToolboxItem(System.IServiceProvider,System.Windows.Forms.IDataObject)">
            <summary>
            Returns a ModelingToolboxItem from the DataObject if it exists, otherwise null.
            </summary>
            <param name="serviceProvider">The service provider to use for retrieving the IToolboxService.</param>
            <param name="data">The IDataObject to retrieve the ModelingToolboxItem data from.</param>
            <returns>A ModelingToolboxItem from the DataObject if it exists, otherwise null.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.PropagateElementGroupContextToTransaction(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroup,Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Propagates the context present in the element group to the currently active top-level transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementOperations.Partition">
            <summary>
            Gets the partition that the ModelElements belong to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementOperations.Store">
            <summary>
            Gets the store that the ModelElements belong to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementOperations.ServiceProvider">
            <summary>
            Gets the IServiceProvider.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.ElementOperations.Merging">
            <summary>
            Called by MergeElementGroupPrototype immediately after the target element
            has been chosen, but before the elements from the ElementGroupPrototype have 
            been reconstituted.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.ElementOperations.ElementsReconstituted">
            <summary>
            Called by MergeElementGroupPrototype immediately after the elements from 
            the ElementGroupPrototype have been reconstituted, but before they are 
            connected to the rest of the model.
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.ElementOperations.Merged">
            <summary>
            Called by MergeElementGroupPrototype immediately before the local transaction 
            is committed.  The rules are queued during the local transaction and fired 
            when the transaction commits.  The local transaction wraps reconstituting and
            connecting elements.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementOperations.ElementGroupPrototypeClipboardFormatId">
            <summary>
            The clipboard format Id for ElementGroupPrototype.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementOperations.CachedElementGroupPrototype">
            <remarks>
            A class to cache an ElementGroupPrototype with a Guid instance ID.
            </remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementOperations.CachedElementGroupPrototype.#ctor(System.Guid,Microsoft.VisualStudio.Modeling.ElementGroupPrototype)">
            <summary>
            Constructs a CachedElementGroupPrototype.
            </summary>
            <param name="instanceID">The Guid instance Id of the cached ElementGroupPrototype.</param>
            <param name="prototype">The cached ElementGroupPrototype.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementOperations.CachedElementGroupPrototype.InstanceId">
            <summary>
            Gets the Guid instance Id of the cached ElementGroupPrototype.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementOperations.CachedElementGroupPrototype.Prototype">
            <summary>
            Gets the cached ElementGroupPrototype.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementOperations.NativeMethods">
            <summary>
            Native methods for interacting with the clipboard.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs">
            <summary>
            Arguments for merge events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.#ctor(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroupPrototype,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Initializes a new instance of the MergeEventArgs class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.TargetElement">
            <summary>
            Gets the target element that will serve as the parent element of the reconstituted elements.
            </summary>
            <value>The target element that will serve as the parent element of the reconstituted elements.</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.ElementGroupPrototype">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.ElementGroup">
            <summary>
            
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.TopLevelTransaction">
            <summary>
            Gets the top-level transaction.
            </summary>
            <value>The top-level transaction.</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.CurrentTransaction">
            <summary>
            Gets the current transaction.
            </summary>
            <value>The current transaction.</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MergeElementGroupEventArgs.MergeCompleted">
            <summary>
            Gets or sets a value indicating whether the Merge
            process is complete and requires no further processing.
            </summary>
            <value>true if no further processing is required.</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MergeAbortedException">
            <summary>
            The exception that is thrown when merge operation on a domain model is aborted by the user.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeAbortedException.#ctor">
            <summary>
            Initializes a new instance of the MergeAbortedException class. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeAbortedException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the MergeAbortedException class with a specified error message. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeAbortedException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the MergeAbortedException class with a specified error message
            and a reference to the inner exception that is the cause of this exception. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
            <param name="innerException">
            The exception that is the cause of the current exception.
            If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. 
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeAbortedException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the MergeAbortedException class with serialized data. 
            </summary>
            <param name="info">The object that holds the serialized object data.</param>
            <param name="context">The contextual information about the source or destination.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MergeContext">
            <summary>
            Provides merge (i.e., drop/paste) information which is 
            initially set by the merge process when the ElementGroupPrototype's
            objects are reconstituted into the target store.
            The merge information is subsequently used
            throughout the merge process and the fixup phase.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.MergeContext.PreMergeKey">
            <summary>
            When this key is present in an ElementGroup's context, the merge process will
            call PreMergeSelf() on every root element in the ElementGroup at the beginning of merge.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeContext.Set(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Adds the MergeContext information to the specified transaction.
            </summary>
            <param name="transaction">The transaction where the MergeContext will be saved to.</param>
            <param name="targetElement">The target ModelElement of the merge operation.</param>
            <param name="elementGroup">The ElementGroup that was reconstituted into the target store.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeContext.HasContext(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Returns true if the transaction contains MergeContext info, otherwise false.
            </summary>
            <param name="transaction">The transaction to check to see if it contains MergeContext info.</param>
            <returns>True if the transaction contains MergeContext info, otherwise false.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeContext.GetTargetElement(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Returns the target ModelElement of the merge operation.
            </summary>
            <param name="transaction">The transaction containing the saved MergeContext. This is typically the top-level transaction.</param>
            <returns>The target ModelElement of the merge operation.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeContext.GetElementGroup(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Returns the ElementGroup that was reconstituted into the target store.
            </summary>
            <param name="transaction">The transaction containing the saved MergeContext. This is typically the top-level transaction.</param>
            <returns>The ElementGroup that was reconstituted into the target store.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeContext.GetRootModelElements(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Returns the collection of ModelElements (non-PresentationElements) 
            that serve as the root elements in the reconstituted ElementGroup.
            </summary>
            <param name="transaction">
            The transaction containing the saved MergeContext. 
            This is typically the top-level transaction.
            </param>
            <returns>
            The collection of ModelElements (non-PresentationElements) 
            that serve as the root elements in the reconstituted ElementGroup.
            </returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MergeContext.AddRootModelElement(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Adds the modelElement to the transaction's MergeContext's RootMel collection.
            </summary>
            <param name="transaction">
            The transaction containing the saved MergeContext. 
            This is typically the top-level transaction.
            </param>
            <param name="modelElement">The model element to add to the RootMel collection.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ProtoElementBase">
            <summary>
            ProtoElementBase contains the information needed to create an element in any store.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.#ctor(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Creates an instance of the ProtoElementBase class.
            </summary>
            <param name="element">The element for which the prototype is being created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.#ctor(System.Guid)">
            <summary>
            Creates an instance of the ProtoElementBase class for a given domainClassId. This mode is used to determine whether the given 
            DomainClassInfo type can be merged under any given model element.
            </summary>
            <param name="domainClassId">The DomainClassInfo Id of ModelElement for which the prototype is being created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Creates an instance of the ProtoElementBase class.
            </summary>
            <param name="info">Contains the serialized ProtoElementBase data</param>
            <param name="context">Serialization context hint</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serializes object data into the SerializationInfo object.
            </summary>
            <param name="info">Contains the serialized ProtoElementBase data</param>
            <param name="context">Serialization context hint</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.ReconstituteObject(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Creates an element in the partition with the same attributes as the progenitor element
            </summary>
            <param name="idDictionary">Map from the old IDs to the IDs that clones should have</param>
            <param name="partition">The partition in which the clone is to be created</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.GetPropertyAssignments(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Get the AttributeAssignements for the progenitor element's attributes
            </summary>
            <param name="partition">The partition to create the PropertyAssignments in.</param>
            <returns>The PropertyAssignment array for the element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElementBase.GetPropertyValue(System.Guid)">
            <summary>
            Gets the value of the specified domain property.
            </summary>
            <param name="domainPropertyId">The Guid id of the domain property to inspect.</param>
            <returns>The value of the specified domain property. null if not found.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoElementBase.ElementId">
            <summary>
            Get the Id of the prototype element.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoElementBase.DomainClassId">
            <summary>
            Get the Id of the domain class for this prototype element.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ProtoElement">
            <summary>
            Prototype class for an element
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElement.#ctor(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Creates an instance of the ProtoElement class.
            </summary>
            <param name="element">element that this proto element represents</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElement.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Creates an instance of the ProtoElement class.
            </summary>
            <param name="info">Serialization info.</param>
            <param name="context">Serialization context.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElement.#ctor(System.Guid)">
            <summary>
            Creates an instance of the ProtoElementBase class 
            </summary>
            <param name="domainClassId">The DomainClassInfo Id of ModelElement for which the prototype is being created.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElement.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serializes object data into the SerializationInfo object.
            </summary>
            <param name="info">Contains the serialized ProtoElementBase data</param>
            <param name="context">Serialization context hint</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoElement.ReconstituteObject(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Creates an element in the partition with the same attributes as the progenitor element
            </summary>
            <param name="idDictionary">Map from the old IDs to the IDs that clones should have</param>
            <param name="partition">The partition in which the clone is to be created</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ProtoGroup">
            <summary>
            ProtoGroups contain the information to recreate an ElementGroup
            in the context of any store given that the Elements and ElementLinks
            in the group have already been created in the store by the parent
            ElementGroupPrototype.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoGroup.#ctor(Microsoft.VisualStudio.Modeling.ElementGroup)">
            <summary>
            Creates an instance of the ProtoGroup class.
            </summary>
            <param name="elementGroup">The element group we are creating a prototype for</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoGroup.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Creates an instance of the ProtoGroup class.
            </summary>
            <param name="info">The serialization info object</param>
            <param name="context">The streaming context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoGroup.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Populate the serialization info with this object's data.
            </summary>
            <param name="info">The serialization info object.</param>
            <param name="context">The streaming context.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoGroup.ReconstituteGroup(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Create a clone of this prototype's progenitor ElementGroup in the input partition.
            </summary>
            <remarks>
            This method assumes that the clone Elements and ElementLinks have already 
            been created in the partition.
            </remarks>
            <param name="idDictionary">Map from the progenitor ID's to the clone ID's</param>
            <param name="partition">The partition in which to create the clone ElementGroup</param>
            <returns>The clone</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoGroup.PopulateCloneElementList(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementGroup,System.Collections.Generic.List{System.Guid})">
            <summary>
            Adds clone Elements to the clone ElementGroup
            </summary>
            <remarks>
            Note that the ID's passed in can be either ModelElement ID's or ElementLink ID's.
            </remarks>
            <param name="idDictionary">Map from progenitor ModelElement ID's to clone ModelElement ID's</param>
            <param name="partition">The partition that contains the clone objects</param>
            <param name="clone">The newly created clone ElementGroup</param>
            <param name="ids">The ID's of the progenitor Elements whose clones are to be added to the clone group</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ProtoLink">
            <summary>
            ProtoLink contains the information needed to recreate an ElementLink in any Store
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.ProtoLink.serializationInfo">
            <summary>
            Store for serialialization info between the time this element is deserializaed and the callback when its properties are deserializaed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.#ctor(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Creates an instance of the ProtoLink class.
            </summary>
            <param name="link">The ElementLink to prototype.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Creates an instance of the ProtoLink class.
            </summary>
            <param name="info">The serialization data transfer object</param>
            <param name="context">The serialization context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.System#Runtime#Serialization#IDeserializationCallback#OnDeserialization(System.Object)">
            <summary>
            Deserialize the object when the graph is fully loaded
            </summary>
            <param name="sender"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Puts object data into the serialization data transfer object
            </summary>
            <param name="info">The serialization data transfer object</param>
            <param name="context">The serialization context</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.ReconstituteObject(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Recreate the ElementLink in the indicated store
            </summary>
            <param name="idDictionary">Map from original ModelElement ID's to new ModelElement ID's</param>
            <param name="partition">The partition in which to reconstitute the ElementLink</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.GetRoleAssignments(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Get a set of RoleAssignments for the ElementLink
            </summary>
            <param name="idDictionary">Map from original ModelElement ID's to new ModelElement ID's</param>
            <param name="partition">The partition in which to reconstitute the ElementLink</param>
            <returns>The role assignments</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.GetRolePlayerId(System.Guid)">
            <summary>
            Gets the Guid idenitifier of the ProtoElement playing the specified domain role in this ProtoLink.
            </summary>
            <param name="domainRoleId">The Guid of the domain role to locate.</param>
            <returns>The Guid idenitifier of the ProtoElement playing the specified domain role in this ProtoLink.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoLink.GetRolePlayerMonikerId(System.Guid)">
            <summary>
            Gets the Guid idenitifier of the moniker playing the specified domain role in this ProtoLink.
            </summary>
            <param name="domainRoleId">The Guid of the domain role to locate.</param>
            <returns>The Guid idenitifier of the moniker playing the specified domain role in this ProtoLink.</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ProtoPropertyValue">
            <summary>
            ProtoPropertyValue contains the information necessary 
            to populate an attribute value for a particular ModelElement.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.#ctor(Microsoft.VisualStudio.Modeling.PropertyAssignment)">
            <summary>
            Creates an instance of the ProtoPropertyValue class.
            </summary>
            <param name="assignment">PropertyAssignment containing the data for the property</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.#ctor(System.Guid,System.Object)">
            <summary>
            Creates an instance of the ProtoPropertyValue class.
            </summary>
            <param name="domainPropertyId">The domain propertyId of the property.</param>
            <param name="propertyValue">The value of the property.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Serialization constructor
            </summary>
            <param name="info">Object containing the information</param>
            <param name="context">Serialization context hint</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Renders ProtoPropertyValue data for serialization.
            </summary>
            <param name="info">Object containing the information</param>
            <param name="context">Serialization context hint</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.CreatePropertyAssignment(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Creates an PropertyAssignment object for the property
            </summary>
            <param name="partition">The Partition to create the PropertyAssignment in.</param>
            <returns>The PropertyAssignment object</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.DomainPropertyId">
            <summary>
            Gets the Domain Property Id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoPropertyValue.PropertyValue">
            <summary>
            Gets the property value.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ProtoRolePlayer">
            <summary>
            ProtoRolePlayer contains the data necessary to set the rolePlayer data on an ElementLink
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.#ctor(System.Guid,System.Guid,System.Guid,System.Int32[])">
            <summary>
            Constructor
            </summary>
            <param name="domainRoleId">Guid of the DomainRole that this role player plays</param>
            <param name="rolePlayerId">Guid of the role player itself</param>
            <param name="rolePlayerMonikerId">Guid of the role player moniker</param>
            <param name="ordinals">ordinals of the role with the element link</param>
            [GeMathew] UNDONE: Many items in the ElementGroupPrototype classes could be made internal.
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Creates an instance of the ProtoRolePlayer class.
            </summary>
            <param name="info">The serialization data transfer object.</param>
            <param name="context">The serialization context.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Renders ProtoRolePlayer data for serialization
            </summary>
            <param name="info">Object containing the information</param>
            <param name="context">Serialization context hint</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.CreateRoleAssignment(System.Collections.Generic.Dictionary{System.Guid,System.Guid},Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Creates a RoleAssignment for the rolePlayer in the link that is being created
            </summary>
            <param name="idDictionary">Map from the original element ID's to the clone element ID's</param>
            <param name="partition">The partition containing the clone rolePlayer elements</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.DomainRoleId">
            <summary>
            Gets the DomainRoleId Guid.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.RolePlayerId">
            <summary>
            Gets the RolePlayerId Guid.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.RolePlayerMonikerId">
            <summary>
            Gets the RolePlayerMonikerId Guid.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ProtoRolePlayer.Ordinals">
            <summary>
            Gets the int Ordinal.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Resources">
            <summary>
              A strongly-typed resource class, for looking up localized strings, etc.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ResourceManager">
            <summary>
              Returns the cached ResourceManager instance used by this class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.Culture">
            <summary>
              Overrides the current thread's CurrentUICulture property for all
              resource lookups using this strongly typed resource class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.AllowsDuplicatesIsTrueOnEmbeddingRelationship">
            <summary>
              Looks up a localized string similar to Embedding relationship must have AllowsDuplicates option set to false: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.AllowsDuplicatesMustMatchBaseRelationship">
            <summary>
              Looks up a localized string similar to AllowsDuplicates option of relationship derived from a base relationship with AllowsDuplicates set to false must be false: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.AllowsDuplicatesNotAllowedOnOneRelationship">
            <summary>
              Looks up a localized string similar to AllowsDuplicates option must be set to false on domain relationship which have at least one role of multiplicity 0..1 or 1..1: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentDuplicateDictionaryKey">
            <summary>
              Looks up a localized string similar to Dictionary already contains a key/value pair with specified key..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentGuidArrayTooShort">
            <summary>
              Looks up a localized string similar to The list of GUID-s passed should contain at least 2 elements..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentGuidEmpty">
            <summary>
              Looks up a localized string similar to Argument cannot be empty GUID: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentInvalid">
            <summary>
              Looks up a localized string similar to Argument value is invalid..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentInvalidType">
            <summary>
              Looks up a localized string similar to Argument value must of type {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentInvalidUniqueNameProvider">
            <summary>
              Looks up a localized string similar to Element name provider type must either be ElementNameProvider or inherit from it..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentNotSerializable">
            <summary>
              Looks up a localized string similar to Argument value must be of serializable type..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArgumentStringNullOrEmpty">
            <summary>
              Looks up a localized string similar to Argument cannot be null or empty string: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArrayIsTooShort">
            <summary>
              Looks up a localized string similar to Array specified to copy collection is too short to fit the whole collection..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ArrayTypeMismatch">
            <summary>
              Looks up a localized string similar to Elements contained within this collection cannot be stored in array of this type..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.AttemptToResolveUnresolvableLink">
            <summary>
              Looks up a localized string similar to Link moniker cannot be resolved: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.BaseDerivedRoleSettingsMismatch">
            <summary>
              Looks up a localized string similar to IsEmbedding setting must match on base and derived relationships except when embedding relationship inherits from an abstract non-embedding one: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotDeleteExistingLink">
            <summary>
              Looks up a localized string similar to Unable to delete the existing link, because it would cause the target element to be deleted also..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotMoveDeletedElement">
            <summary>
              Looks up a localized string similar to Cannot change partition of a deleted element..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotMoveElement">
            <summary>
              Looks up a localized string similar to Cannot move element {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotRedo">
            <summary>
              Looks up a localized string similar to Cannot redo..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotRedoDeleteElement">
            <summary>
              Looks up a localized string similar to Cannot redo delete element because element with ID {0} was not found..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotRedoMoveElement">
            <summary>
              Looks up a localized string similar to Cannot redo move element because element with ID {0} was not found or move failed..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotRedoResurrectElement">
            <summary>
              Looks up a localized string similar to Cannot redo resurrect element because deleted element with ID {0} was not found..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotResolveMonikerOrRolePlayer">
            <summary>
              Looks up a localized string similar to Cannot resolve moniker or role player..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotResolveTargetRolePlayer">
            <summary>
              Looks up a localized string similar to Cannot resolve moniker target role player: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotSetPropertyOnDeletedElement">
            <summary>
              Looks up a localized string similar to Cannot set property value on a deleted element..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotSetValueOfCalculatedProperty">
            <summary>
              Looks up a localized string similar to The value of calculated property {0} of {1} cannot be set because this property is read-only..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotTraverseWithNullProperty">
            <summary>
              Looks up a localized string similar to Property {0} of the ElementVisitor must be set to an object instance before traversal..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotUndo">
            <summary>
              Looks up a localized string similar to Cannot undo..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotUndoAddElement">
            <summary>
              Looks up a localized string similar to Cannot undo add element because element with ID {0} was not found..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotUndoAddElementLink">
            <summary>
              Looks up a localized string similar to Cannot undo add element link because deleted link with ID {0} was not found..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotUndoChangeElement">
            <summary>
              Looks up a localized string similar to Cannot undo change element because element with ID {0} was not found..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotUndoDeleteElement">
            <summary>
              Looks up a localized string similar to Cannot undo delete element because deleted element with ID {0} was not found..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CannotUndoMoveElement">
            <summary>
              Looks up a localized string similar to Cannot undo move element because element with ID {0} was not found or move failed..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CircularInheritance">
            <summary>
              Looks up a localized string similar to Circular inheritance (object directly or indirectly inheriting from itself) has been detected involving {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CollectionWasModifiedDuringEnumeration">
            <summary>
              Looks up a localized string similar to Collection has been modified since enumeration was started..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.CommitNestedBeforeParent">
            <summary>
              Looks up a localized string similar to Commit cannot be performed while there are active nested transactions..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ContextStackIsEmpty">
            <summary>
              Looks up a localized string similar to Context stack is empty..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DeletedElementNotFound">
            <summary>
              Looks up a localized string similar to Cannot find element with ID {0} among deleted elements in directory..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DifferentEventHandlersForSingleEvent">
            <summary>
              Looks up a localized string similar to Cannot combine different types of event handlers for a single event..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainIdNotRelationship">
            <summary>
              Looks up a localized string similar to Domain id parameter &apos;{0}&apos; does not refer to a DomainRelationship. .
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainModelNotLoaded">
            <summary>
              Looks up a localized string similar to Specified domain model hasn&apos;t been loaded into the store: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainObjectNotFoundInDirectory">
            <summary>
              Looks up a localized string similar to Domain object with identity {0} was not found in directory..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainPropertyMustBelongToDomainClass">
            <summary>
              Looks up a localized string similar to Implementation type of domain property {0} must be a domain class: {1}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainRelationshipIdNotDomainRelationshipInfo">
            <summary>
              Looks up a localized string similar to DomainRelationship id parameter &apos;{0}&apos; does not refer to a DomainRelationshipInfo. .
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainRoleDoesNotMatchDomainRelationship">
            <summary>
              Looks up a localized string similar to Domain role must belong to domain relationship {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainRoleMustBeDefinedOnRelationship">
            <summary>
              Looks up a localized string similar to Implementation class where domain role {0} is defined must be a domain relationship: {1}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DomainRoleRolePlayerTypeMistach">
            <summary>
              Looks up a localized string similar to RolePlayer argument on role {0} of {1} must be a subclass of role&apos;s property type..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DropItems">
            <summary>
              Looks up a localized string similar to Drop items.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateBaseDomainModelId">
            <summary>
              Looks up a localized string similar to Domain model with ID {0} is specified more than once in the list of domain models extended by domain model with ID {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateDomainModel">
            <summary>
              Looks up a localized string similar to Domain model {0} has already been registered..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateDomainObjectFullName">
            <summary>
              Looks up a localized string similar to Domain object with the same full name as {0} has already been defined in this or another domain model..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateDomainObjectId">
            <summary>
              Looks up a localized string similar to Domain object with ID {0} has already been defined in this or another domain model..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateElementId">
            <summary>
              Looks up a localized string similar to Element with ID {0} already exists in element directory..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateEmbeddingRole">
            <summary>
              Looks up a localized string similar to Domain relationship {0} contains more than one embedding role where at most one is allowed..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateLink">
            <summary>
              Looks up a localized string similar to Cannot establish a link of type {0} between elements {1} and {2} since there is already a link of this type between these elements and link&apos;s domain relationship has AllowsDuplicates=false..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateNameProperty">
            <summary>
              Looks up a localized string similar to Domain class {0} defines a duplicate element name property..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.DuplicateRule">
            <summary>
              Looks up a localized string similar to Rule {0} has already been registered with the store..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ElementCount">
            <summary>
              Looks up a localized string similar to Element Count.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ElementGroupAlreadyHasAParent">
            <summary>
              Looks up a localized string similar to Element group is already contained within another group..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ElementLinkCount">
            <summary>
              Looks up a localized string similar to Element Link Count.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ElementLinkNotFound">
            <summary>
              Looks up a localized string similar to Element link with ID {0} was not found in directory..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ElementNameNotSupported">
            <summary>
              Looks up a localized string similar to Domain class {0} does not specify an element name property..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ElementNotFound">
            <summary>
              Looks up a localized string similar to Element with identity {0} was not found in element directory..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ErrorGettingContextHelpFromResource">
            <summary>
              Looks up a localized string similar to Unable to retrieve context-sensitive help resource {0} from domain model {1}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.EventHandlerAlreadyRegistered">
            <summary>
              Looks up a localized string similar to Specified event handler is already registered..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ExistingRolePlayer">
            <summary>
              Looks up a localized string similar to Changing the value of this property will delete an existing link.  Are you sure you want to continue?.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ExistingRolePlayerWithNames">
            <summary>
              Looks up a localized string similar to Changing the value of this property will delete the existing link between {0} and {1}.  Are you sure you want to continue?.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.FailedParseTextFormatHueSaturationLuminosityText">
            <summary>
              Looks up a localized string similar to Failed to parse text. Expected text in the format: Hue, Saturation, Luminosity..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.GetElementLinksMultipleRolesError">
            <summary>
              Looks up a localized string similar to The domain class of this element plays more than one role in given relationship. The role to get links for must be specified..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.GetElementLinksNoRolesError">
            <summary>
              Looks up a localized string similar to The domain class of this element doesn&apos;t play any role in given relationship..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.GetElementNamesNotSupportedEx">
            <summary>
              Looks up a localized string similar to GetElementNames method is only used for DomainProperty of type string..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.GetLinkedElementManyError">
            <summary>
              Looks up a localized string similar to Getting single linked element for a role with multiplicity 0..* or 1..* is not supported..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.GetLinkNamesNotSupportedEx">
            <summary>
              Looks up a localized string similar to GetLinkNames method is only used for DomainProperty of type string..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.IncompatibleDomainRoles">
            <summary>
              Looks up a localized string similar to Domain roles {0} and {1} must belong to the same domain relationship..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidBaseDomainRole">
            <summary>
              Looks up a localized string similar to Domain role player must be same or derived domain class as base domain role player: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidCollectionItemType">
            <summary>
              Looks up a localized string similar to Invalid type of the &apos;item&apos; argument - must of type {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidCommandInHiddenTransaction">
            <summary>
              Looks up a localized string similar to Only additive operations (add element/link) can participate in a hidden transaction..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidDerivedRoleMultiplicityMany">
            <summary>
              Looks up a localized string similar to The multiplicity of a derived role cannot be ZeroMany or OneMany if the multiplicity of the base role is ZeroOne or One: {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidDerivedRoleMultiplicityOne">
            <summary>
              Looks up a localized string similar to A base role with multiplicity One cannot have derived roles with multiplicity One that share the same role player: {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidDistinguishedElement">
            <summary>
              Looks up a localized string similar to Element group root elements must be one of the elements/links contained within the group..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidDomainClassBase">
            <summary>
              Looks up a localized string similar to Domain class {0} must directly or indirectly inherit from {1} class..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidDomainModelBase">
            <summary>
              Looks up a localized string similar to Domain model class {0} must directly or indirectly inherit from {1} class..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidDomainObjectType">
            <summary>
              Looks up a localized string similar to Type is not recognized as one of supported domain model object types: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidElementDomainClass">
            <summary>
              Looks up a localized string similar to Element must be of type {0} or derived from it..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidElementLinkSubclass">
            <summary>
              Looks up a localized string similar to Domain relationship specified domain role belongs to doesn&apos;t match the type of link requested..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidElementNamePropertyType">
            <summary>
              Looks up a localized string similar to ElementNameAttribute is applied to a domain property of type other than System.String: {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidEmbeddingRoleMultiplicity">
            <summary>
              Looks up a localized string similar to Embedding domain role {0} of {1} (IsEmbedding = true) must have multiplicity of 1 or 0..1..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidEmbeddingTargetRolePlayerType">
            <summary>
              Looks up a localized string similar to Embedding relationship cannot have relationship class {0} as its embedded role player..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidEnumeratorCurrentState">
            <summary>
              Looks up a localized string similar to Enumeration either finished or hasn&apos;t been started..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidMultipleEmbeddedRoles">
            <summary>
              Looks up a localized string similar to A domain class can have at most one role which embeds it with multiplicity 1..1 attached to it:{0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidNumberOfDomainRoles">
            <summary>
              Looks up a localized string similar to Domain relationship {0} must have exactly 2 domain roles defined locally or in one of the base relationships..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidOperationInTransaction">
            <summary>
              Looks up a localized string similar to This operation cannot be performed within the context of a modeling transaction..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidOperationOutsideTransaction">
            <summary>
              Looks up a localized string similar to This operation can only be performed within the context of a modeling transaction..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidPropertyValueHandlerType">
            <summary>
              Looks up a localized string similar to Domain property value type {0} must inherit from DomainPropertyValueHandler and provide a static singleton Instance property..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidRedoTransaction">
            <summary>
              Looks up a localized string similar to Invalid redo transaction..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidRoleAssigments">
            <summary>
              Looks up a localized string similar to ElementLink constructor must be given exactly 2 role assignments corresponding to link&apos;s domain relationship roles..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidRolePlayer">
            <summary>
              Looks up a localized string similar to Role player must be of type {0} or derived from it..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidRuleType">
            <summary>
              Looks up a localized string similar to The rule type {0} is not recognized as one of supported rule types..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidSourceRolePlayerType">
            <summary>
              Looks up a localized string similar to Source role player must be of type {0} or derived from it..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidSuccessorLink">
            <summary>
              Looks up a localized string similar to Successor link must be attached to the same role player and be of compatible relationship type..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidTargetForRolePlayerRule">
            <summary>
              Looks up a localized string similar to The target of role player rule {0} must be a domain relationship class..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidTargetRolePlayerType">
            <summary>
              Looks up a localized string similar to Target role player type {0} must be {1} or derive from it..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidToolboxResourceId">
            <summary>
              Looks up a localized string similar to A required toolbox item resource with ID {0} could not be found.  Ensure that this resource has been included in {1}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidTransactionContext">
            <summary>
              Looks up a localized string similar to Invalid transaction context..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.InvalidUndoTransaction">
            <summary>
              Looks up a localized string similar to Invalid undo transaction..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.LocalMergeTransaction">
            <summary>
              Looks up a localized string similar to Local Merge Transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MissingDomainObjectIdAttribute">
            <summary>
              Looks up a localized string similar to Type or member representing a domain element must specify {0} DomainObjectIdAttribute and provide an unique ID..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MissingMoniker">
            <summary>
              Looks up a localized string similar to Cannot find moniker for {0}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MissingPropertyInfoForDomainProperty">
            <summary>
              Looks up a localized string similar to Property {0} representing corresponding domain property of {1} was not found in reflected assembly..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MissingPropertyInfoForDomainRole">
            <summary>
              Looks up a localized string similar to Property {0} representing corresponding domain role of {1} was not found in reflected assembly..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MissingRuleOnAttribute">
            <summary>
              Looks up a localized string similar to Rule class {0} must specify a RuleOnAttribute..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MissingSetValueForCustomStoredProperty">
            <summary>
              Looks up a localized string similar to Custom stored property {0} is not handled by the SetValueForCustomStoredProperty method of {1} or one of its base classes..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.MultipleLinksNotAllowed">
            <summary>
              Looks up a localized string similar to Domain role with multiplicity 0..1 or 1 can hold at most 1 link: {0} of {1}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.NewTransactionInUndoRedo">
            <summary>
              Looks up a localized string similar to New transaction cannot be started while undo or redo operation is in progress..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.NotifyValueChangeNotAllowed">
            <summary>
              Looks up a localized string similar to NotifyValueChange is not allowed for property &apos;{0}&apos; as its Kind is not CustomStorage or Calculated..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.PerfCountersCategoryHelp">
            <summary>
              Looks up a localized string similar to Modeling Framework Counters.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.PerfCountersCategoryName">
            <summary>
              Looks up a localized string similar to Modeling Counters.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.PropertiesInUseCount">
            <summary>
              Looks up a localized string similar to Properties In Use Count.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.PropertyNotFound">
            <summary>
              Looks up a localized string similar to Property {0} was not found in {1} class information reflected from assembly..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RedoStackIsEmpty">
            <summary>
              Looks up a localized string similar to Redo stack is empty..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ResetField">
            <summary>
              Looks up a localized string similar to Reset {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RoleLinkIndexOutOfRange">
            <summary>
              Looks up a localized string similar to Link index {0} is outside of links collection index range while assigning role {1} of {2}..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerMissingName">
            <summary>
              Looks up a localized string similar to The domain class for the target role player must have a domain property marked IsElementName=&apos;true&apos;..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerMultiplicity">
            <summary>
              Looks up a localized string similar to The multiplicity of the source role used by the RolePlayerPropertyDescriptor must be 0 or 1..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerPropertyDescriptorConstraintTypeMismatch">
            <summary>
              Looks up a localized string similar to Parameter roleTypeConstraint must be a subtype of the implementation type for the role player..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerPropertyDescriptorRelMismatch">
            <summary>
              Looks up a localized string similar to Parameters relationship and relationshipInfo must match..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerPropertyDescriptorRelNull">
            <summary>
              Looks up a localized string similar to Must specify one or both of relationship and relationshipInfo..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerTypeConverterNullValue">
            <summary>
              Looks up a localized string similar to (none).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RolePlayerTypeNotValid">
            <summary>
              Looks up a localized string similar to The Type of the role player provided in the DomainRoleAttribute for DomainRole &apos;{0}&apos; on DomainRelationship &apos;{1}&apos; is not a valid DomainClass. The Type provided is &apos;{2}&apos;. If this DomainClass is defined in another DomainModel, make sure that DomainModel is loaded first. .
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RollbackNestedBeforeParent">
            <summary>
              Looks up a localized string similar to Rollback cannot be performed while there are active nested transactions..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.RootElementIdListNotSet">
            <summary>
              Looks up a localized string similar to TargetContext[&quot;&quot;RootElementIdList&quot;&quot;] must be set on elementGroup before calling MergeContext.Set..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.SetField">
            <summary>
              Looks up a localized string similar to Set {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.SetLinkedElementManyError">
            <summary>
              Looks up a localized string similar to Setting single linked element for a role with multiplicity 0..* or 1..* is not supported..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.SetUniqueNameCoreNotImplementedEx">
            <summary>
              Looks up a localized string similar to DomainProperty {0}.{1} is not of type string, please override this method to set unique name for the given model element..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.StoreViewerExceptionError">
            <summary>
              Looks up a localized string similar to Exception: {0}.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.StoreViewerLinksNodeText">
            <summary>
              Looks up a localized string similar to Links.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.StoreViewerPopulating">
            <summary>
              Looks up a localized string similar to Populating....
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.StoreViewerRulesNodeText">
            <summary>
              Looks up a localized string similar to Rules.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.TransactionIsNotActive">
            <summary>
              Looks up a localized string similar to This operation can only be performed when a modeling transaction is active..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.UndoCanceledException">
            <summary>
              Looks up a localized string similar to Undo was canceled..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.UndoStackIsEmpty">
            <summary>
              Looks up a localized string similar to Undo stack is empty..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Resources.ValueIsNotOfEnumType">
            <summary>
              Looks up a localized string similar to Parameter must of be enumeration type..
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RuleManager">
            <summary>
            Rule Manager class
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            RuleManager Constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.RegisterRule(Microsoft.VisualStudio.Modeling.Rule)">
            <summary>
            Register the Rule with the RuleManager.
            </summary>
            <param name="rule">The rule to Register.</param>
            <remarks>Used to maintain a list of rules so users can enable/disable them.</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.DisableRule(System.Type)">
            <summary>
            Disables the Rule of the particular Type from firing.
            </summary>
            <param name="ruleType">The Type of Rule to disable.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.EnableRule(System.Type)">
            <summary>
            Enables the Rule of the particular Type to fire.
            </summary>
            <param name="ruleType">The Type of Rule to enable.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.SuspendRuleNotification">
            <summary>
            Suspend rule notification to the client
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ResumeRuleNotification">
            <summary>
            Resume rule notification to the client
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementAdded(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.AddElementCommand)">
            <summary>
            When a new AddElementCommand is created, we need to call RuleManager.ElementAdded method. This method will be responsible for firing rule
            to the client who has a user-defined rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element is being added</param>
            <param name="addCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementAdded(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.AddElementLinkCommand)">
            <summary>
            When a new AddElementCommand is created, we need to call RuleManager.ElementAdded method. This method will be responsible for firing rule
            to the client who has a user-defined rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element link is being added</param>
            <param name="addLinkCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementDeleting(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.DeletingElementCommand)">
            <summary>
            When a new DeletingElementCommand is created, we need to call RuleManager.ElementDeleting method. This method will be responsible for firing rule
            to the client who has a user-defined deleting rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element is about to be deleted</param>
            <param name="deletingCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementDeleted(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.DeleteElementCommand)">
            <summary>
            When a new DeleteElementCommand is created, we need to call RuleManager.ElementRemoved method. This method will be responsible for firing rule
            to the client who has a user-defined remove rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element is being deleted</param>
            <param name="deleteCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementDeleting(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand)">
            <summary>
            When a new DeletingElementLinkCommand is created, we need to call RuleManager.ElementDeleting method.
            This method will be responsible for firing rule to the client who has a user-defined remove rule in
            the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element link is about to be deleted</param>
            <param name="deletingLinkCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementDeleted(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand)">
            <summary>
            When a new DeleteElementLinkCommand is created, we need to call RuleManager.ElementRemoved method. This method will be responsible for firing rule
            to the client who has a user-defined remove rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element link is being deleted</param>
            <param name="deleteLinkCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementChanged(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ChangeElementCommand)">
            <summary>
            When a new ChangeElementCommand is created, we need to call RuleManager.ElementChanged method. This method will be responsible for firing rule
            to the client who has a user-defined change rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element is being changed</param>
            <param name="changeElemCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.ElementMoved(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.MoveElementCommand)">
            <summary>
            When a new MoveElementCommand is created, we need to call RuleManager.ElementMoved method. This method will be responsible for firing rule
            to the client who has a user-defined move rule in the domain model definition.
            </summary>
            <param name="txn">Transaction in which the element link is being moved</param>
            <param name="moveElementCmd"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.TransactionBeginning(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            When a transaction is Committed, we need to call the RuleManager.BeforeTransactionCommitted method.
            This method will be responsible for firing rules
            to the client who has a user-defined rule in the domain model definition.
            </summary>
            <param name="txn">Transaction that is being started</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.TransactionCommitting(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            When a transaction is Committed, we need to call the RuleManager.BeforeTransactionCommitted method.
            This method will be responsible for firing rules
            to the client who has a user-defined rule in the domain model definition.
            </summary>
            <param name="txn">Transaction that is being committed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.TransactionRollingBack(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            When a transaction is Rolled Back, we need to call the RuleManager.BeforeTransactionRolledBack method.
            This method will be responsible for firing rules
            to the client who has a user-defined rule in the domain model definition.
            </summary>
            <param name="txn">Transaction that is being rolled back</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireChangeRule(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs)">
            <summary>
            Method to find the domain class, iterate thru the DeleteRuleNotificaiton object array and fire each rule.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireMoveRule(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ElementMovedEventArgs)">
            <summary>
            Method to find the domain class, iterate thru the AddRuleNotificaiton object array and fire each rule.
            </summary>
            <param name="txn">Transaction for which the rule is firing</param>
            <param name="eventArgs">ElementMovedEventArgs</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.RolePlayerChanged(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand)">
            <summary>
            When a new RolePlayerChangedCommand is created, we need to call RuleManager.RolePlayerChanged method. This method will be responsible for firing rule
            to the client who has a user-defined role player change rule in the domain model definition.
            </summary>
            <param name="txn">Transaction for which the rule is firing</param>
            <param name="rolePlayerChanged"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.RolePlayerPositionChanged(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand)">
            <summary>
            When a new RolePlayerPositionChangedCommand is created, we need to call RuleManager.RolePlayerPositionChanged method. This method will be responsible for firing rule
            to the client who has a user-defined role player position change rule in the domain model definition.
            </summary>
            <param name="txn">Transaction for which the rule is firing</param>
            <param name="rolePlayerPosChanged"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FindDeleteRule(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs)">
            <summary>
            Method to find the domain class, iterate thru the DeleteRuleNotificaiton object array and fire each rule.
            </summary>
            <param name="txn">Transaction for which the rule is firing</param>
            <param name="deleteEventArgs">event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireDeletingRule(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ElementDeletingEventArgs)">
            <summary>
            Method to find the domain class, iterate thru the DeletingRuleNotificaiton object array and fire each rule.
            </summary>
            <param name="txn">Transaction for which the rule is firing</param>
            <param name="deleteEventArgs">event args</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireAddRule(Microsoft.VisualStudio.Modeling.Transaction,Microsoft.VisualStudio.Modeling.ElementAddedEventArgs)">
            <summary>
            Method to find the domain class, iterate thru the AddRuleNotificaiton object array and fire each rule.
            </summary>
            <param name="txn">Transaction for which the rule is firing</param>
            <param name="eventArgs">ElementAddedEventArgs</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireBeginningRules(Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs)">
            <summary>
            Fire all TransactionBeginning Rules
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireCommittingRules(Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs)">
            <summary>
            Fire all TransactionCommitting Rules
            </summary>
            <param name="e"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleManager.FireRollingBackRules(Microsoft.VisualStudio.Modeling.TransactionRollbackEventArgs)">
            <summary>
            Fire all TransactionRollingBack Rules
            </summary>
            <param name="e"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleManager.IsRuleSuspended">
            <summary>
            Gets the suspension state of the rule manager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleNotification.Rule">
            <summary>
            Gets the Rule object for the rule notification.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleNotification.EventArgs">
            <summary>
            Gets the argument associate with the rule to be fired.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleNotification.FireTime">
            <summary>
            Gets the fire immediately rule flag
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleNotification.SequenceNumber">
            <summary>
            Gets the sequence number of this rule notification
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.AddRuleNotification">
            <summary>
            Internal class for firing the rules for the client.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteRuleNotification">
            <summary>
            Internal class for firing the rules for the client.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeletingRuleNotification">
            <summary>
            Internal class for firing the rules for the client.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ChangeRuleNotification">
            <summary>
            Internal class for firing the rules for the client.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MoveRuleNotification">
            <summary>
            Internal class for firing the rules for the client.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerChangeRuleNotification">
            <summary>
            Internal class for firing the rules for the client.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RuleOnAttribute">
            <summary>
            Class definition for C# custom attribute RuleOn. This is used for IMS rule notification.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleOnAttribute.#ctor(System.Type)">
            <summary>
            Constructor for class RuleOn. Specify which domain type this rule attachs to.
            </summary>
            <param name="attachDomainType">Domain type this rule attaches to.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RuleOnAttribute.#ctor(System.String)">
            <summary>
            Constructor for class RuleOn. Specify which domain type (in Guid form) this rule attachs to.
            </summary>
            <param name="attachDomainTypeId">ID (GUID) of the type this rule attaches to.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleOnAttribute.FireTime">
            <summary>
            Gets/Sets the FireTime property
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleOnAttribute.AttachDomainType">
            <summary>
            Type of the class that this rule is attached to
            </summary>
            <value>System.Type</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleOnAttribute.AttachDomainTypeId">
            <summary>
            Id of the domain type that this rule is attached to 
            </summary>
            <value>Guid</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleOnAttribute.Priority">
            <summary>
            Priority order for the rules to determinine rule firing order.
            Lower (including negative) numbers fire before higher numbers.
            Default is 0
            </summary>
            <value>int</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RuleOnAttribute.InitiallyDisabled">
            <summary>
            Flag indicating that the rule should be initially disabled when the domain model is loaded.
            Disabled rules can be enabled by calling RuleManager.EnableRule.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ChangeRule">
            <summary>
            Base class for registering element property changed notification rule
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeRule.ElementPropertyChanged(Microsoft.VisualStudio.Modeling.ElementPropertyChangedEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined change rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MoveRule">
            <summary>
            Base class for registering element moved notification rule
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveRule.ElementMoved(Microsoft.VisualStudio.Modeling.ElementMovedEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined move rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteRule">
            <summary>
            Base class for registering element deleted notification rule
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteRule.ElementDeleted(Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined delete rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeletingRule">
            <summary>
            Base class for registering element deleting pre-notification rules
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingRule.ElementDeleting(Microsoft.VisualStudio.Modeling.ElementDeletingEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined delete rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.DeletingRule.FireBefore">
            <summary>
            Override the FireBefore flag to always return true
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerChangeRule">
            <summary>
            Base class for registering elementlink roleplayer changed notification rule
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangeRule.RolePlayerChanged(Microsoft.VisualStudio.Modeling.RolePlayerChangedEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined role player rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangeRule">
            <summary>
            Base class for registering elementlink roleplayer position changed notification rule 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangeRule.RolePlayerPositionChanged(Microsoft.VisualStudio.Modeling.RolePlayerOrderChangedEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined role player position change rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionBeginningRule">
            <summary>
            Base class for registering Transaction Beginning  notification rules
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionBeginningRule.TransactionBeginning(Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined transaction beginning rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionCommittingRule">
            <summary>
            Base class for registering Transaction committed notification rules
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionCommittingRule.TransactionCommitting(Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined before transaction committed rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionRollingBackRule">
            <summary>
            Base class for registering Transaction rolled back notification rules
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionRollingBackRule.TransactionRollingBack(Microsoft.VisualStudio.Modeling.TransactionRollbackEventArgs)">
            <summary>
            public virtual method for the client to have his own user-defined before transaction rolledback rule class
            </summary>
            <param name="e"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TimeToFire">
            <summary>
            Enumeration that identifies firing time of a rule
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.TimeToFire.Inline">
            <summary>
            Rule will be fired Inline
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.TimeToFire.LocalCommit">
            <summary>
            Rule will be fired when the transaction in which the change occurred commits
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.TimeToFire.TopLevelCommit">
            <summary>
            Rule will be fired when the top level transaction in which the change occurred commits
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Store">
            <summary>
            Store is a complete model.  Stores contain both the domain data
            and the model data for all the domain models in a model.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Store.serviceProvider">
            <summary>
            This service provider is specified during construction.  Store's 
            implementation of IServiceProvider delegates to this service provider.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.#ctor(System.Type[])">
            <summary>
            Creates an instance of the Store class.
            </summary>
            <param name="domainModelTypes">List of domain models to be loaded.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.#ctor(System.IServiceProvider,System.Type[])">
            <summary>
            Creates an instance of the Store class which delegates IServiceProvider implementation to the given serviceProvider.
            </summary>
            <param name="serviceProvider">the service provider delegated to by this Store's IServiceProvider implementation.</param>
            <param name="domainModelTypes">List of domain models to be loaded.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.Dispose">
            <summary>
            Dispose method
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.GetService(System.Type)">
            <summary>
            Get Service.
            </summary>
            <param name="serviceType">ServiceType.</param>
            <returns>Object.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.FindDomainModel(System.Guid)">
            <summary>
            Finds domain model by Id.
            </summary>
            <param name="domainModelId">The Id of domain model.</param>
            <returns>DomainModel instance or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.GetDomainModel(System.Guid)">
            <summary>
            Gets domain model by its Id.
            This method will throw if domain model if not found.
            </summary>
            <param name="domainModelId">Domain model Id to look for.</param>
            <returns>DomainModel instance.</returns>
            <exception cref="T:System.ArgumentException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.GetDomainModel``1">
            <summary>
            Gets domain model instance of specified type.
            </summary>
            <typeparam name="T">Domain model type.</typeparam>
            <returns>Instance of domain model.</returns>
            <exception cref="T:System.InvalidOperationException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.AddDomainModel(Microsoft.VisualStudio.Modeling.DomainModel)">
            <summary>
            Add a DomainModel to the collection of DomainModels
            </summary>
            <param name="domainModel">The DomainModel</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.LoadDomainModels(System.Type[])">
            <summary>
            Create all the domain-data for the domain models contained in the passed DomainModels.
            </summary>
            <param name="domainModelTypes">A Type [] of DomainModels to be loaded.</param>
            <exception cref="T:System.ArgumentNullException"/>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.RemoveLinkFromAvoidDuplicates(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Unregisters link from avoid duplicates hashtable.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.AddLinkToAvoidDuplicates(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Registers link in avoid duplicates hashtable.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.TryAddLinkToAvoidDuplicates(Microsoft.VisualStudio.Modeling.ElementLink)">
            <summary>
            Tries to register link in avoid duplicates hashtable. If the result will cause duplicate, the method returns false and 
            does not change the hashtable; otherwise the link will be added into the hashtable and the method returns true.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.PushContext(Microsoft.VisualStudio.Modeling.Context)">
            <summary>
            Push new Context on top of store context stack
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.PopContext">
            <summary>
            Pop current context off the top of the stack
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.InternalPopContext">
            <summary>
            Internal method to pop the last context off the stack.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.OnStoreDisposing">
            <summary>
            Notify that the store is being disposed
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.CheckDisposed">
            <summary>
            indicates true when the store has been disposed
            </summary>
            <value>bool</value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.GetClosurePrototypeGroup(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType)">
            <summary>
            Creates an ElementGroupPrototype in the DefaultPartition of the given closure type based on the given list of root Elements
            </summary>
            <param name="rootElements">collection of root elements</param>
            <param name="type">type of closure to build</param>
            <returns>ICollection that form the closure for copy</returns>
            <remarks>the element group prototype's DistinguishedElements list will be populated with the root elements list</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.GetClosurePrototypeGroup(System.Collections.Generic.ICollection{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.ClosureType,System.Boolean)">
            <summary>
            Creates an ElementGroupPrototype in the DefaultPartition of the given closure type based on the given list of root Elements
            </summary>
            <param name="rootElements">collection of root elements</param>
            <param name="type">type of closure to build</param>
            <param name="bypassDemandLoading">indicates whether to bypass demand loading while forming the closure</param>
            <returns>ICollection that form the closure for copy</returns>
            <remarks>the element group prototype's DistinguishedElements list will be populated with the root elements list</remarks>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.NotifyTransactionLogs(Microsoft.VisualStudio.Modeling.GenericEventArgs)">
            <summary>
            Notifies Store's TransactionLogs of an event
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.UnNotifyTransactionLogs(System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.ModelingEventArgs})">
            <summary>
            Removes Store's TransactionLogs of an event during rollback
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.RegisterTransactionLog(Microsoft.VisualStudio.Modeling.TransactionLog)">
            <summary>
            Allows a client to register a transaction log that will be notified of events
            on this store
            </summary>
            <param name="log">the log that this store will notify</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.UnregisterTransactionLog(Microsoft.VisualStudio.Modeling.TransactionLog)">
            <summary>
            Allows a client to unregister a transaction log from being notified of events on this store
            </summary>
            <param name="log">the log that will be unregistered</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.FindMonikerResolver(System.Guid)">
            <summary>
            Gets the IMonikerResolver registered for the given DomainModel. Returns null if no IMonikerResolver is
            registered with this model.
            </summary>
            <param name="domainModelId">Id of the DomainModel to search for.</param>
            <returns>The registered IMonikerResolver, or null if not found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Store.AddMonikerResolver(System.Guid,Microsoft.VisualStudio.Modeling.IMonikerResolver)">
            <summary>
            Register a new IMonikerResolver for the given DomainModel. If there's an old resolver registered for this 
            DomainModel, it will be replaced by the new one. Setting the IMonikerResolver to null will remove the resolver
            associated with the given DomainModel.
            </summary>
            <param name="domainModelId">Id of the DomainModel that will get the new IMonikerResolver.</param>
            <param name="monikerResolver">IMonikerResolver instance for the given DomainModel.</param>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.Store.StoreDisposing">
            <summary>
            Allows clients to receive StoreDisposing events
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.MonikerRootDirectory">
            <summary>
            Collection of Moniker objects used in Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.MonikerResolverDirectory">
            <summary>
            Collection of MonikerResolver objects used in Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.Contexts">
            <summary>
            Collection of Context objects used in Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.Partitions">
            <summary>
            Collection of Partition objects used in Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.PartitionsAlternate">
            <summary>
            List of Partition objects (that use the AlternateKey) used in Store.  This
            collection is maintained by setting the property on the AlternateKey value of
            the partition object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.DefaultPartition">
            <summary>
            The default Partition for the Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.ShuttingDown">
            <summary>
            indicates that the store will be shutting down.
            </summary>
            <value>bool</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.Version">
            <summary>
            The version of the Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.ElementFactory">
            <summary>
            The ElementFactory for the model
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.ElementDirectory">
            <summary>
            Gets directory of elements contained within the store.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.DomainDataDirectory">
            <summary>
            Gets domain information directory of the store.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.DomainModels">
            <summary>
            Gets a collection of domain models in this store.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.TransactionManager">
            <summary>
            The TransactionManager for the model
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.EventManagerDirectory">
            <summary>
            The EventManagerDirectory for the model
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.RuleManager">
            <summary>
            Gets the rule manager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.Id">
            <summary>
            Gets the Id of this store.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.TransactionLogs">
            <summary>
            get the current list of transaction logs for this store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.PropertyBag">
            <summary>
            Get the property bag for this store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.InUndo">
            <summary>
            Reports whether the Store's current context is in undo
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.InRedo">
            <summary>
            Reports whether the Store's current context is in undo
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.InUndoRedoOrRollback">
            <summary>
            Reports whether the Store's current context is in undo, redo or rollback
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.UndoManager">
            <summary>
            The UndoManager for the Default Context.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.DemandLoading">
            <summary>
            Tells if the store is currently demand loading a relationship
            </summary>
            <value>true if the store is currently demand loading</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.TransactionActive">
            <summary>
            Indicates that the store has a currently active transaction.  This is true when a transaction is open through
            the time all events have finished firing. 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.ChangeSource">
            <summary>
            The current change source for operations in this store
            </summary>
            <value>ChangeSource</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.CurrentContext">
            <summary>
            Get current Context of the Store
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.Disposed">
            <summary>
            indicates true when the store has been disposed
            </summary>
            <value>bool</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Store.InMonikerResolver">
            <summary>
            Return moniker resolve state
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementCommand">
            <summary>
            Summary description for ElementCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.#ctor(Microsoft.VisualStudio.Modeling.Store,System.EventArgs)">
            <summary>
            Constructor.
            </summary>
            <param name="store">The store which owns this command</param>
            <param name="eventArgs">the event arguments for this command</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.Undo">
            <summary>
            abstract method to perform undo of a command
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.Redo">
            <summary>
            abstract method to perform redo of a command
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.NotifyRule">
            <summary>
            abstract method to perform rule notification of a command
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Virtual method to update partition states.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.CanUndo(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Returns true if command in a transaction can be undone
            </summary>
            <param name="transactionItem"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.CanRedo(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Returns true if command in a transaction can be redone
            </summary>
            <param name="transactionItem"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.NotifyObservers">
            <summary>
            abstract method to notify event observers of the command
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.NotifyObserversForUndo">
            <summary>
            abstract method to notify event observers of undo of the command
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ModelCommand.NotifyTransactionLogsDuringRedo">
            <summary>
            Used by sub-classes of ModelCommand to notify the transaction logs of the event.
            This is only needed during redo. In normal operations the tlogs are notified when the command
            is added. During Undo the tlogs are notified in NotifyObserversForUndo.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelCommand.Store">
            <summary>
            Return the Store instance that this Command object is part of.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelCommand.Context">
            <summary>
            Return the Context instance this Command object is part of.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelCommand.EventArgs">
            <summary>
            Return the Event Args instance for this Command.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelCommand.IsHidden">
            <summary>
            Whether or not this command was added within a hidden transaction
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ModelCommand.UndoSucceeded">
            <summary>
            Get/Set UndoSucceeded status.
            </summary>
            <value></value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,System.EventArgs)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="elementId">The id of the element that was affected</param>
            <param name="commandEventArgs">The eventArgs for this command</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementCommand.CanUndo(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Check if the supplied transaction can be undone.
            </summary>
            <param name="transactionItem"></param>
            <returns>true if transaction can be undone</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementCommand.CanRedo(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Check if the supplied transaction can be redone.
            </summary>
            <param name="transactionItem"></param>
            <returns>true if transaction can be undone</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementCommand.SavePartitionState(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Save the partition's old state and set the state to the the NewPartitionState of the ElementCommand,
            and increment the DirtyCount on the partition.
            </summary>
            <param name="changedPartition"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementCommand.RestorePartitionState(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Restore the partition's state to the old state and decrement the partition's dirty count.
            </summary>
            <param name="changedPartition"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementCommand.Partition">
            <summary>
            Return the Partition instance that this Command object is part of.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementCommand.OldPartitionStates">
            <summary>
            Previous partition states
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementCommand.NewPartitionState">
            <summary>
            New partition state
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementCommand.ElementId">
            <summary>
            Return the id of the element that was affected.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementCommand.Partitions">
            <summary>
            Return list of partitions referenced by this command.
            </summary>
            <value></value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="elementId">The id of the element that was affected</param>
            <param name="domainClass">Domain class of the element.</param>
            <param name="assignments">The array of attrubute assignments associated with the creation of this element</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.Undo">
            <summary>
            Undo the Add ModelElement operation (delete it from the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.Redo">
            <summary>
            Redo the Add ModelElement operation (add it back into the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementAddedEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo an element add event.
            In this case, we will have to do a notification of ElementRemoved...
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.AddElementLinkCommand">
            <summary>
            Summary description for AddElementLinkCommand. 
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementLinkCommand">
            <summary>
            Summary description for ElementLinkCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLinkCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementLink,System.EventArgs,System.Boolean)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="link">The element link that was affected</param>
            <param name="commandEventArgs">The event args for this command</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLinkCommand.ResurrectLink(System.Boolean)">
            <summary>
            undo the Remove ModelElement operation (add it back into the store).
            </summary>
            <param name="undo">true if doing undo, false if doing redo</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLinkCommand.DeleteLink(System.Boolean)">
            <summary>
            Redo the Remove ModelElement operation (delete it from the store).
            </summary>
            <param name="undo">true if doing undo, false if doing redo</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ElementLinkCommand.CanUndo(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Return true if the transaction can be undone.
            </summary>
            <param name="transactionItem"></param>
            <returns>true if transaction can be undone</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementLinkCommand.BypassDemandLoading">
            <summary>
            Bypass Demand Loading.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ElementLinkCommand.Partitions">
            <summary>
            Return list of partitions referenced by this command.
            </summary>
            <value></value>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="link">The element link that was affected</param>
            <param name="domainClass">The domain class info of the element link that was affected</param>
            <param name="assignments">the attribute assignments used when creating this element</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.Undo">
            <summary>
            Undo the Add ElementLink operation (delete it from the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.Redo">
            <summary>
            Redo the Add ElementLink operation (add it back to the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementAddedEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.AddElementLinkCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo an element add. In this case, we will have to
            do a element delete notification
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Object,System.Object)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="elementId">The id of the element that was affected</param>
            <param name="domainProperty">domain property info of the attribute that was affected</param>
            <param name="domainClass">Domain class of the element.</param>
            <param name="oldValue">value of the attribute before the change</param>
            <param name="newValue">value of the attribute after the change</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.Undo">
            <summary>
            Undo the Change ModelElement operation (set the attribute value back to the old value).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.Redo">
            <summary>
            Redo the Change ModelElement operation (set the attribute value back to the new value).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementChangedEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.ChangeElementCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo an element change. In this case, we will have to
            reverse the event args.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ChangeElementCommand.PropertyId">
            <summary>
            Return the id of the property that was modified.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ChangeElementCommand.DomainProperty">
            <summary>
            Return the DomainPropertyInfo of the attribute that was modified.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ChangeElementCommand.OldValue">
            <summary>
            Return the the attribute's old value.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.ChangeElementCommand.NewValue">
            <summary>
            Return the the attribute's new value.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CommandFactory">
            <summary>
            Command factory is a factory class which allows one to create various type of ElementCommands. It includes AddElementCommand, DeleteElementCommand,
            ChangeElementCommand, RolePlayerChangeCommand and RolePlayerPositionChangeCommand
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.CommandFactory.UpdateAllReferences">
            <summary>
            Controls how partition states are updated (testing only).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateAddElementCommand(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Factory method to creates a AddElementCommand object.
            </summary>
            <param name="element">ModelElement to which this command applies</param>
            <param name="assignments">the attribute assignements for this element</param>
            <returns>ElementCommand object for the given element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateAddElementLinkCommand(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.PropertyAssignment[])">
            <summary>
            Factory method to creates a AddElementLinkCommand object.
            </summary>
            <param name="link">ElementLink to which this command applies</param>
            <param name="assignments">the attribute assignements for this element link</param>
            <returns>ElementLinkCommand object for the given element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateDeleteElementCommand(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ChangeSource,System.Boolean)">
            <summary>
            Factory method to create a DeleteElementCommand.
            </summary>
            <param name="element">ModelElement to be deleted</param>
            <param name="changeSource">the source of this command</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
            <returns>ElementCommand object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateDeletingElementCommand(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.ChangeSource,System.Boolean)">
            <summary>
            Factory method to create a DeletingElementCommand.
            </summary>
            <param name="element">ModelElement to be deleted</param>
            <param name="changeSource">the source of the change</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
            <returns>ElementCommand object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateDeleteElementLinkCommand(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.ChangeSource,System.Boolean)">
            <summary>
            Factory method to create a DeleteElementLinkCommand.
            </summary>
            <param name="link">ElementLink to be deleted</param>
            <param name="changeSource">source of this change</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
            <returns>ElementLinkCommand object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateDeletingElementLinkCommand(Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.ChangeSource,System.Boolean)">
            <summary>
            Factory method to create a DeletingElementLinkCommand.
            </summary>
            <param name="link">ElementLink to be deleted</param>
            <param name="changeSource">indicates the source of the change</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
            <returns>ElementLinkCommand object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateChangeElementCommand(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.DomainPropertyInfo,System.Object,System.Object)">
            <summary>
            Factory method to creates a ChangeElementCommand.
            </summary>
            <param name="partition">partition for the element</param>
            <param name="element">the element</param>
            <param name="domainProperty">attribute that is changing</param>
            <param name="oldValue">old value before the change</param>
            <param name="newValue">new value after the change</param>
            <returns>ElementCommand object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateMoveElementCommand(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Factory method to creates a MoveElementCommand object.
            </summary>
            <param name="element">ModelElement to which this command applies</param>
            <param name="sourcePartition">the original partition for this element</param>
            <returns>ElementCommand object for the given element</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateRolePlayerChangedCommand(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Int32,System.Guid,System.Int32)">
            <summary>
            Factory method to creates a RolePlayerChangeCommand
            </summary>
            <param name="partition">partition for the element</param>
            <param name="elementId">instance Id of the element</param>
            <param name="domainRole">role that is changing</param>
            <param name="oldRolePlayerId">id of the old role player</param>
            <param name="oldRolePlayerPos">position of the old role player</param>
            <param name="newRolePlayerId">id of the new role player</param>
            <param name="newRolePlayerPos">position of the new role player</param>
            <returns>ElementCommand object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CommandFactory.CreateRolePlayerPositionChangedCommand(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Int32,System.Int32,System.Guid)">
            <summary>
            Factory method to creates a RolePlayerPositionChangeCommand
            </summary>
            <param name="partition">partition for the element</param>
            <param name="sourceElementId">Id of the source element</param>
            <param name="sourceRole">role of the source element</param>
            <param name="targetElementId">Id of the target element</param>
            <param name="targetRole">role of the target element</param>
            <param name="oldPos">old position of the role player</param>
            <param name="newPos">new position of the role player</param>
            <param name="linkToMove">id of the element link that is moving</param>
            <returns>ElementCommand object</returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Context">
            <summary>
            Context contains the mapping of transactions to partitions
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Context.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            Constructor
            </summary>
            <param name="store">The owning store</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Context.Finalize">
            <summary>
            Finalizer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Context.Dispose">
            <summary>
            Disposes the state of this object.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Context.AddPartition(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Add new partition to context.
            </summary>
            <param name="partition">partition to be added</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Context.RemovePartition(Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Remove partition from context.
            </summary>
            <param name="partition">partition to be removed</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Context.Delete">
            <summary>
            Method to delete a Partition from the Context
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.DeleteState">
            <summary>
            Defines state of this Context object.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.Id">
            <summary>
            The Id of this Context.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.Store">
            <summary>
            The Store the Context belongs to.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.Partitions">
            <summary>
            The Partitions that are used by the Context.  The Dictionary keys
            are the IDs of the Partitions.  The Dictionary values are the Partition instances.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.UndoManager">
            <summary>
            The UndoManager for the Context.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.InUndo">
            <summary>
            Returns true if the context is in the middle of an undo. 
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.InRedo">
            <summary>
            Returns true if the context is in the middle of an redo. 
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Context.InUndoRedoOrRollback">
            <summary>
            Returns true if the context is in the middle of an undo, redo or rollback. 
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteElementCommand">
            <summary>
            Summary description for DeleteElementCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="elementId">The id of the element that was affected</param>
            <param name="domainClass">The domain class info of the element that was affected</param>
            <param name="changeSource">the source of this change</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.Undo">
            <summary>
            undo the Remove ModelElement operation (add it back into the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.Redo">
            <summary>
            Redo the Remove ModelElement operation (delete it from the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element">Element to be deleted</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementRemovedEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo an element delete. In this case, we will have to
            do a notification of ElementAdded...
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand">
            <summary>
            Summary description for DeleteElementLinkCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.ChangeSource,System.Boolean)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="link">The elementLink that was affected</param>
            <param name="domainClass">The domain class info of the element that was affected</param>
            <param name="changeSource">the source of this change</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.Undo">
            <summary>
            undo the Remove ModelElement operation (add it back into the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.Redo">
            <summary>
            Redo the Remove ModelElement operation (delete it from the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element">Element to be deleted</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementRemovedEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeleteElementLinkCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo an element delete. In this case, we will have to
            do a element add notification
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeletingElementCommand">
            <summary>
            Summary description for DeleteElementCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.ChangeSource)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="elementId">The id of the element that was affected</param>
            <param name="domainClass">The domain class info of the element that was affected</param>
            <param name="changeSource">the source of this change</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementCommand.Undo">
            <summary>
            undo the Deleting ModelElement operation (add it back into the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementCommand.Redo">
            <summary>
            Redo the Deleting ModelElement operation (delete it from the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementDeletingEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementCommand.NotifyObserversForUndo">
            <summary>
            Create the EventArgs for this command and call the ElementDeletingEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand">
            <summary>
            Summary description for DeleteElementLinkCommand.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.ElementLink,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.ChangeSource,System.Boolean)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="link">The elementLink that was affected</param>
            <param name="domainClass">The domain class info of the element that was affected</param>
            <param name="bypassDemandLoading">Bypass Demand Loading.</param>
            <param name="changeSource">the source of the change</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand.Undo">
            <summary>
            undo the Remove ModelElement operation (add it back into the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand.Redo">
            <summary>
            Redo the Remove ModelElement operation (delete it from the store).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the ElementRemovedEventManager's NotifyObservers method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.DeletingElementLinkCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo an element delete. In this case, we will have to
            do a element add notification
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.MoveElementCommand">
            <summary>
            Move element from one partition to another.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainClassInfo,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Cosntructor
            </summary>
            <param name="partition"></param>
            <param name="elementId"></param>
            <param name="domainClass"></param>
            <param name="destinationPartition"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.Undo">
            <summary>
            Undo move
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.Redo">
            <summary>
            Redo move
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.NotifyRule">
            <summary>
            Notify rule
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.NotifyObservers">
            <summary>
            Notify observers
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.NotifyObserversForUndo">
            <summary>
            Notify observers for undo.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.MoveElementCommand.CanMoveElement(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.Partition)">
            <summary>
            Check if an element can be moved to a partition.
            </summary>
            <param name="element"></param>
            <param name="targetPartition"></param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.MoveElementCommand.Partitions">
            <summary>
            Return list of partitions referenced by this command.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand">
            <summary>
            Summary description for RolePlayerChangedCommand .
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,System.Int32,System.Guid,System.Int32)">
            <summary>
            Constructor.
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="elementId">The id of the element that was affected</param>
            <param name="domainRole">the domain role info of the element that was affected</param>
            <param name="oldRolePlayerId">id of the old role player element</param>
            <param name="oldRolePlayerPos">0-based position of the old role player</param>
            <param name="newRolePlayerId">id of the new role player element</param>
            <param name="newRolePlayerPos">0-based position of the new role player</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.Undo">
            <summary>
            Undo the Change RolePlayer operation (set the old RolePlayer back).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.Redo">
            <summary>
            Redo the Change RolePlayer operation (set the new RolePlayer back).
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command.
            </summary>
            <param name="element">ElementLink</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the RolePlayerChangedEventManager's NotifyObservers
            method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo a roleplayer change. In this case, we will have to
            do reverse the player info.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.OldRolePlayerId">
            <summary>
            Return the the domain role's old role player id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.NewRolePlayerId">
            <summary>
            Return the the domain role's new role player id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerChangedCommand.DomainRole">
            <summary>
            Return the the domain role whose role player was changed.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.#ctor(Microsoft.VisualStudio.Modeling.Partition,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Guid,Microsoft.VisualStudio.Modeling.DomainRoleInfo,System.Int32,System.Int32,System.Guid)">
            <summary>
            Constructor
            </summary>
            <param name="partition">The partition that this command is part of</param>
            <param name="sourceElementId">The id of the element that was affected</param>
            <param name="sourceRole">Source role that is moving</param>
            <param name="targetElementId">Id of the target role player</param>
            <param name="targetRole">Role of the target role player</param>
            <param name="oldPos">0-based old position of the target role player</param>
            <param name="newPos">0-based new position of hte target role player</param>
            <param name="linkToMove">Id of the ElementLink object to move</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.NotifyRule">
            <summary>
            Notify rule manager for rule notification...
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.Undo">
            <summary>
            Undo method
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.Redo">
            <summary>
            Redo method
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.UpdateState(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Update the state of partitions affected by this command
            </summary>
            <param name="element">Source element (see constructor)</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.NotifyObservers">
            <summary>
            Create the EventArgs for this command and call the RolePlayerPositionChangedEventManager's NotifyObservers
            method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.NotifyObserversForUndo">
            <summary>
            This is doing the opposite of NotifyObservers(). This method is used when we undo a roleplayer position change. In this case, we will have to
            do reverse the player position.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.OldPosition">
            <summary>
            Return the the role's old position.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.RolePlayerPositionChangedCommand.NewPosition">
            <summary>
            Return the the role's new position.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CompletionStatus">
            <summary>
            Transaction CompletionStatus
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.CompletionStatus.RolledBack">
            <summary>
            indicates that the transaction completed by rollback
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.CompletionStatus.Committed">
            <summary>
            indicates that the transaction completed commit
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionContext">
            <summary>
            Context object that allows clients to append user data to the transaction
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionContext.#ctor">
            <summary>
            Constructor
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionContext.ContextInfo">
            <summary>
            Context information.  Used to hold tag/value pairs
            </summary>
            <value>object</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Transaction">
            <summary>
            The Transaction object allows grouping of changes made to the store.  It ensures that the
            changes made are atomic and consistent.  It also keeps track of the actions performed so
            that they can be undone at a later stage.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.#ctor(System.Guid,Microsoft.VisualStudio.Modeling.Store,System.String,Microsoft.VisualStudio.Modeling.Transaction,System.Int64,System.Boolean,System.Boolean)">
            <summary>
            Construc a new transaction
            </summary>
            <param name="id">The id of this transaction</param>
            <param name="store">The store that this transaction is part of</param>
            <param name="name">The name of this transaction</param>
            <param name="parent">This transaction's parent</param>
            <param name="sequenceNumber">This transaction's sequence number</param>
            <param name="isSerializing">Indicates the deserialization form of this transaction</param>
            <param name="isHidden">Indicates if this transaction should be shown on the undo stack or not</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.Dispose">
            <summary>
            Disposes the state of this object.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.Finalize">
            <summary>
            Finalizer.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.Dispose(System.Boolean)">
            <summary>
            Private implementation of Dispose per the pattern.
            </summary>
            <param name="disposing">True when called from Dispose(), false otherwise.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.Commit">
            <summary>
            Commit the transaction - persist all the changes and notify listeners.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.Rollback">
            <summary>
            Abort the transaction - rollback all the changes that have been made so far in this transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.AddCommand(Microsoft.VisualStudio.Modeling.ModelCommand)">
            <summary>
            Add a command object to our list of command objects.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.AppendCommands(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelCommand})">
            <summary>
            Append a list of command objects to our list of command objects.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.AppendTopLevelCommitTimeRules(Microsoft.VisualStudio.Modeling.SortedRuleNotificationList)">
            <summary>
            Append a list of TopLevelCommitTimeRules to our list of TopLevelCommitTimeRules
            </summary>
            <param name="commitTimeRulesToAppend"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Transaction.AppendLocalCommitTimeRules(Microsoft.VisualStudio.Modeling.SortedRuleNotificationList)">
            <summary>
            Append a list of LocalCommitTimeRules to our list of LocalCommitTimeRules
            </summary>
            <param name="commitTimeRulesToAppend"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.IsSerializing">
            <summary>
            Indicates that the transaction is currently serializing
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Id">
            <summary>
            Return this transaction's id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.SequenceNumber">
            <summary>
            Return this transactions sequence number
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.PartitionStates">
            <summary>
            Return partition state collection
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Context">
            <summary>
            Returns this transaction's transaction context object
            </summary>
            <value>Transaction Context object for this transaction</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.IsActive">
            <summary>
            Return true if this transaction is active (started but not committed or rolled back).
            Return false otherwise.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.InRollback">
            <summary>
            Returns true if this transaction is beign rolled back
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Store">
            <summary>
            Return the Store instance that this Transaction is part of.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.ContextInstance">
            <summary>
            Return the Context instance that this Transaction is part of.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Hidden">
            <summary>
            Get/Set transaction hidden property. Hidden transaction commands
            are not added to undo stack during commit.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.HasPendingChanges">
            <summary>
            Returns true if changes have been made during this transaction
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Name">
            <summary>
            The Name property of this transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.TopLevelTransaction">
            <summary>
            return a reference to the top level transaction that nests this transaction
            </summary>
            <value>Transaction</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Parent">
            <summary>
            return the parent of this transaction
            </summary>
            <value>Transaction</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.TransactionDepth">
            <summary>
            Return the nesting depth of this transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.IsNested">
            <summary>
            Indicates that a transaction is nested within another transaction
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.IsHidden">
            <summary>
            Indicates that a transaction is hidden, and no rules will fire, and 
            it will not go on the undo stack.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.Commands">
            <summary>
            Return a readonly copy of the list of command objects.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Transaction.ForceAllRulesToCommitTime">
            <summary>
            Get or set a flag that forces all inline rules to fire at LocalCommit time for the current transaction.
            </summary>
            <value>bool</value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionItem">
            <summary>
            TransactionItem class
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionItem.#ctor(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Creates a new instance of the TransactionItem class.
            </summary>
            <param name="transaction">The transaction.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionItem.AddCommands(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelCommand},System.Int32)">
            <summary>
            add a list of commands to this transactionitem at the specified index
            </summary>
            <param name="commandsToAdd"></param>
            <param name="index"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.Id">
            <summary>
            Return this transaction item's id.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.Context">
            <summary>
            Returns this transaction's transaction context object
            </summary>
            <value>Transaction Context object for this transaction</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.Store">
            <summary>
            Return the Store instance that this Transaction is part of.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.ContextInstance">
            <summary>
            Return the Context instance that this Transaction is part of.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.Name">
            <summary>
            The Name property of this transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.Commands">
            <summary>
            Return a readonly copy of the list of command objects.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.PartitionStates">
            <summary>
            Return the partition state collection
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionItem.SequenceNumber">
            <summary>
            Return transaction sequence number.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionLog">
            <summary>
            Class for handling transaction events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionLog.#ctor">
            <summary>
            Constructor.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CanCommitCallback">
            <summary>
            Callback for querying if transaction commit can proceed based on external criteria.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.TransactionManager">
            <summary>
            The TransactionManager class is responsible for creating Transaction objects and
            keeping track of the current active transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            constructor.
            </summary>
            <param name="store">The store that this transaction manager is part of</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginTransaction">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginTransaction(System.String)">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <param name="name">The transaction's name</param>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginHiddenTransaction(System.String)">
            <summary>
            Create a new hidden transaction
            </summary>
            <param name="name">The name of the transaction</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginTransaction(System.String,System.Boolean)">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <param name="name">The transaction's name</param>
            <param name="isSerializing">when true, the transaction will notify that deserialization is taking place</param>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginTransaction(System.String,System.Boolean,Microsoft.VisualStudio.Modeling.TransactionContext)">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <param name="name">The transaction's name</param>
            <param name="isSerializing">when true, the transaction will notify that deserialization is taking place</param>
            <param name="context">context object that allows clients to append user data to the transaction</param>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginTransaction(System.String,System.Boolean,System.Boolean)">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <param name="name">The transaction's name</param>
            <param name="isSerializing">when true, the transaction will notify that deserialization is taking place</param>
            <param name="isHidden">indicates that this transaction should suppress rules and events and not appear on the undo stack</param>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.BeginTransaction(System.String,System.Boolean,System.Boolean,Microsoft.VisualStudio.Modeling.TransactionContext)">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <param name="name">The transaction's name</param>
            <param name="isSerializing">when true, the transaction will notify that deserialization is taking place</param>
            <param name="isHidden">indicates that this transaction should suppress rules and events and not appear on the undo stack</param>
            <param name="context">context object that allows clients to append user data to the transaction</param>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.InternalBeginTransaction(System.String,System.Boolean,System.Boolean,Microsoft.VisualStudio.Modeling.TransactionContext)">
            <summary>
            Creates a new transaction object and returns a reference to it.
            </summary>
            <param name="name">The transaction's name</param>
            <param name="isSerializing">indicates that this transaction wraps deserialization</param>
            <param name="isHidden">indicates that this transaction should suppress rules and events and not appear on the undo stack</param>
            <param name="context">context object that allows clients to append user data to the transaction</param>
            <returns>The Transaction object</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.setTransaction(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Set the current active transaction.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.AddCanCommitCallback(Microsoft.VisualStudio.Modeling.CanCommitCallback)">
            <summary>
            Add CanCommit voter.
            </summary>
            <param name="canCommitCallback">CanCommit voter.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.TransactionManager.RemoveCanCommitCallback(Microsoft.VisualStudio.Modeling.CanCommitCallback)">
            <summary>
            Remove CanCommit voter.
            </summary>
            <param name="canCommitCallback">CanCommit voter.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionManager.Store">
            <summary>
            Return the Store that this TransactionManager is part of.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionManager.CurrentTransaction">
            <summary>
            Return the current active transaction.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionManager.InTransaction">
            <summary>
            Return whether are not the Store is in the middle of a transaction or not.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionManager.TransactionDepth">
            <summary>
            Return the depth of the nested transactions.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionManager.CommandFactory">
            <summary>
            Gets the CommandFactory object for creating the various type of ElementCommand objects.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.TransactionManager.CanCommitCallbacks">
            <summary>
            CanCommit voters.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.CanUndoRedoCallback">
            <summary>
            Callback for querying if Undo/Redo can proceed based on external criteria.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.UndoState">
            <summary>
            UndoState enumeration describes state of Undo in the Undo Manager
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.UndoState.Enabled">
            <summary>
            Undo is enabled
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.UndoState.Disabled">
            <summary>
            Undo is enabled
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.UndoState.DisabledNoFlush">
            <summary>
            UNDONE: mattcur: Use this value at your own peril. Disabling the
            undo stack without flushing it is extremely dangerous and can
            leave the internal model inconsistent. However, there is no real
            alternative for keeping files from dirtying in response to
            changes that affect the UI and internal state but not the document
            files. DisabledNoFlush will be marked as obsolete as soon as possible.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.UndoManager">
            <summary>
            Summary description for UndoManager.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.AddCanUndoRedoCallback(Microsoft.VisualStudio.Modeling.CanUndoRedoCallback)">
            <summary>
            Add CanUndoRedo voter.
            </summary>
            <param name="canUndoRedoCallback">CanUndoRedo voter.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.RemoveCanUndoRedoCallback(Microsoft.VisualStudio.Modeling.CanUndoRedoCallback)">
            <summary>
            Remove CanUndoRedo voter.
            </summary>
            <param name="canUndoRedoCallback">CanUndoRedo voter.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.#ctor(Microsoft.VisualStudio.Modeling.Context)">
            <summary>
            constructor.
            </summary>
            <param name="context">The context that this undo manager is part of</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.#ctor(Microsoft.VisualStudio.Modeling.Store)">
            <summary>
            constructor.
            </summary>
            <param name="store">The store that the undo manager is attached to</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Finalize">
            <summary>
            Finalizer
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Dispose">
            <summary>
            Dispose method
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.AddUndoableAction(Microsoft.VisualStudio.Modeling.Transaction)">
            <summary>
            Add an undoable action to the undo stack.  This will clear the redo stack.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Undo">
            <summary>
            Undo the actions of the topmost transaction on undo stack.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Undo(System.Guid)">
            <summary>
            Undo the actions committed in the transaction whose id is passed in.  Make sure the id passed in
            is the transaction that is on top of the stack.  Otherwise throw an exception.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.UndoAllPossible">
            <summary>
            Undo all transactions in undo stack that can be undone.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Redo">
            <summary>
            Redo the actions of the topmost transaction on the redo stack.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.DeleteClosureForUndoRedo(Microsoft.VisualStudio.Modeling.ElementCommand,Microsoft.VisualStudio.Modeling.TransactionItem,System.Int32,System.Boolean)">
            <summary>
            Calculates the delete closure for an add command (during undo) or a
            delete command (during redo) and removes the elements. 
            The caller is responsible for ensuring that
            only an add/delete command is passed to this function. 
            We need to calculate the delete closure during undo/redo because
            demand loading could have occured, and we need to delete the demand loaded
            children when the parent is deleted.
            </summary>
            <param name="cmd"></param>
            <param name="t"></param>
            <param name="index">Index of the command that we're currently processing</param>
            <param name="inUndo">true if this is called from an undo. False if it's called from a redo</param>
            <returns>The number of new commands that were added to t as a result of deleting the closure</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Redo(System.Guid)">
            <summary>
            Redo the actions committed in the transaction whose id is passed in.  Make sure the id passed in
            is the transaction that is on top of the stack.  Otherwise throw an exception.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.RedoAllPossible">
            <summary>
            Redo all possible transactions on redo stack.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.Flush">
            <summary>
            Flush the undo and redo stacks.  If we are in the middle of a transaction, throw an exception.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.OnUndoStackFlushed">
            <summary>
            Notifies that undo stack has been flushed
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.OnUndoItemAdded(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Notifies that undo item has been added
            </summary>
            <param name="t"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoManager.OnUndoItemDiscarded(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Notifies that undo item has been discarded
            </summary>
            <param name="t"></param>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.UndoManager.UndoStackFlushed">
            <summary>
            Allows clients to receive an event when the undo stack is flushed
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.UndoManager.UndoItemAdded">
            <summary>
            Event that is fired every time an undo item is added to the undo stack
            </summary>
        </member>
        <member name="E:Microsoft.VisualStudio.Modeling.UndoManager.UndoItemDiscarded">
            <summary>
            Event that is fired every time an undo item is discarded from the
            undo stack because the stack size exceeded the maximum number of
            undo items permitted.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.CanUndoRedoCallbackCollection">
            <summary>
            CanUndoRedo voters.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.Store">
            <summary>
            The Store that contains the UndoManager
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.Context">
            <summary>
            The Context that contains the UndoManager
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.InUndo">
            <summary>
            Return whether are not the undo manager is in the middle of an undo or not.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.InRedo">
            <summary>
            Return whether are not the undo manager is in the middle of a redo or not.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.UndoState">
            <summary>
            The state of Undo.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.UndoCount">
            <summary>
            Number of items in undo stack.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.RedoCount">
            <summary>
            Number of items in redo stack
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.UndoableTransactions">
            <summary>
            List of undoable TransactionItems maintained by the UndoManager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.RedoableTransactions">
            <summary>
            List of redoable TransactionItems maintained by the UndoManager.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.LastOverflowSequenceNumber">
            <summary>
            Return the sequence number of the last transaction dropped from the
            bottom of the undostack
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.OverflowPartitions">
            <summary>
            Return a collection of partitions touched by overflowed transactions.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.UndoStackOverflow">
            <summary>
            Return true if undo stack has overflowed.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.MaxUndoableTransactions">
            <summary>
            Maximum number of undo items visible on the undo stack
            </summary>
            <value>int</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoManager.TopmostUndoableTransaction">
            <summary>
            Return topmost transaction ID in undo stact
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.UndoItemEventArgs">
            <summary>
            Event args for the UndoItemAdded and UndoItemDiscarded events
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoItemEventArgs.#ctor(Microsoft.VisualStudio.Modeling.TransactionItem)">
            <summary>
            Cunstructor
            </summary>
            <param name="transactionItem"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.UndoItemEventArgs.TransactionItem">
            <summary>
            The transaction item for the undo item
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.UndoRedoCanceledException">
            <summary>
            The exception that is thrown when an undo or redo operation has been cancelled.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoRedoCanceledException.#ctor">
            <summary>
            Initializes a new instance of the OperationCancelledException class. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoRedoCanceledException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the OperationCancelledException class with a specified error message. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoRedoCanceledException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the OperationCancelledException class with a specified error message
            and a reference to the inner exception that is the cause of this exception. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
            <param name="innerException">
            The exception that is the cause of the current exception.
            If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. 
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.UndoRedoCanceledException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the OperationCancelledException class with serialized data. 
            </summary>
            <param name="info">The object that holds the serialized object data.</param>
            <param name="context">The contextual information about the source or destination.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper">
            <summary>
            Class to call to provide implementations for supporting constraint validation logic
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.validationMap">
            <summary>
            Dictionary mapping a type to validate to a list of all the validatin methods defined within the the type.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.validationAttributeMap">
            <summary>
            Keep the map from MethodInfo to the ValidationMethodAttribute. This allows us to increase perf a little bit.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.InternalValidate(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Perform in-memory validate of the model.
            </summary>
            <remarks>
            Note that this does not necessarily perform all possible validation checks, just those that can easily be performed over the in-memory model.
            Apply all methods on this class which are marked with the Validation custom attribute
            </remarks>
            <param name="element">The element to validate</param>
            <param name="context">The context of this validation.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.InvokeValidationMethods(Microsoft.VisualStudio.Modeling.ModelElement,System.Collections.Generic.IList{System.Reflection.MethodInfo},Microsoft.VisualStudio.Modeling.Validation.ValidationContext,System.Collections.Generic.List{System.String})">
            <summary>
            For the given element and the methodInfo collection, this method will invoke the validation method based on the context
            </summary>
            <param name="element">element which we will invoke the the method against</param>
            <param name="methods">Method to be invoked</param>
            <param name="context">validation context</param>
            <param name="methodsCalled">Remember the methods being called so far. This allows us to NOT called the same method in the parent class</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.FetchValidationMethods(Microsoft.VisualStudio.Modeling.Store,System.Type)">
            <summary>
            Method to use the reflection to fetch all the validation methods defined thru out the inheritance chain. This method will also weed out the 
            dup entries (e.g. Both the child and parent meta-classes have the same test methods with the same signature.).
            </summary>
            <param name="store">Store which this type resides</param>
            <param name="elementType"></param>
            <returns>A collection of callable validation method for this given type</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.FetchTypeValidationMethods(System.Type)">
            <summary>
            Method to use the reflection to fetch all the validation methods defined thru out the inheritance chain. This method will also weed out the 
            dup entries (e.g. Both the child and parent meta-classes have the same test methods with the same signature.).
            </summary>
            <param name="elementType"></param>
            <returns>A collection of callable validation method for this given type</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregateAttributes(System.Object[])">
            <summary>
            Aggregate the validation method attribute(s), create an object and return it.
            </summary>
            <param name="attributes"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregatedValidationMethodAttributes">
            <summary>
            private class for holding the aggregated ValiationMethodAttribute(s) attached to the method.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregatedValidationMethodAttributes.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            ctor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregatedValidationMethodAttributes.AddCategory(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Adds the encountered category into the collection.
            </summary>
            <param name="categories"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregatedValidationMethodAttributes.AddCategory(System.String)">
            <summary>
            Adds the encountered custom string into the collection.
            </summary>
            <param name="custom"></param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregatedValidationMethodAttributes.Categories">
            <summary>
            Returns the bit-wised categories 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.SupportValidationHelper.AggregatedValidationMethodAttributes.AggregatedCustoms">
            <summary>
            returns the custom string staged..
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationContext">
            <summary>
            Context for validating model elements. The constructor will take a collection of model elements intended to be validated.
            Once the validaiton is done, the validation message will be staged in the CurrentViolations property.
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.subjects">
            <summary>
            Internal store of the subject of the validation
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.collectedViolations">
            <summary>
            Holds the collection of validations encountered during the current context
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.categories">
            <summary>
            ValidationCategories to be tested....
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.customCategories">
            <summary>
            Custom categories string. This allows the user to invoke ValiationController.ValidateCustom( elements, "myCustomString" );
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.cache">
            <summary>
            Cache allows users to cache an arbitrary set of objects, making validations more efficient.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.TryGetCacheValue``1(System.String,``0@)">
            <summary>
            Returns whether the cached object associated with the name exist or not
            </summary>
            <param name="name">Name of the cache</param>
            <returns>An object of the given type.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.SetCacheValue``1(System.String,``0)">
            <summary>
            Set the cached object associated with the name
            </summary>
            <typeparam name="T">A class with a parameterless constructor</typeparam>
            <param name="name">Name of the cache</param>
            <param name="cacheObject">cached object to be associated with the given name</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.GetCache``1(System.String)">
            <summary>
            Get a Cache object of a given class and name.
            Constructs an object if none already exists in this ValidationContext.
            </summary>
            <typeparam name="T">A class with a parameterless constructor</typeparam>
            <param name="name">Name of the cache</param>
            <returns>An object of the given type.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.GetCache``1">
            <summary>
            Get the Cache object of a given class.
            Constructs an object if none already exists in this ValidationContext.
            </summary>
            <typeparam name="T">A class with a parameterless constructor</typeparam>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.#ctor(System.String[],Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Ctor for creating a custom validation context. The validation can then be called from ValidationController.Validate
            with this context object.
            </summary>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <param name="subject">root object to be validated</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.#ctor(System.String[],System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Ctor
            </summary>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <param name="subjects">object to be validated</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Constructor
            </summary>
            <param name="categories"></param>
            <param name="subject">root object to be validated</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Constructor
            </summary>
            <param name="categories"></param>
            <param name="subjects">object to be validated</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories,System.String[])">
            <summary>
            private ctor to stage private variables...
            </summary>
            <param name="categories"></param>
            <param name="customCategories"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.LogViolation(Microsoft.VisualStudio.Modeling.Validation.ViolationType,System.String,System.String,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Create a new validation error, message or warning based on passed in violationType enum value. 
            The validation message into the collection maintained by the validation context
            </summary>
            <param name="violationType"></param>
            <param name="description"></param>
            <param name="code"></param>
            <param name="elements"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.LogFatal(System.String,System.String,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Create a new validation fatal error and log a message into the collection maintained by the validation context
            </summary>
            <param name="description"></param>
            <param name="code"></param>
            <param name="elements"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.LogError(System.String,System.String,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Create a new validation error and log a message into the collection maintained by the validation context
            </summary>
            <param name="description"></param>
            <param name="code"></param>
            <param name="elements"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.LogWarning(System.String,System.String,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Create a new validation warning and log a message into the collection maintained by the validation context
            </summary>
            <param name="description"></param>
            <param name="code"></param>
            <param name="elements"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.LogMessage(System.String,System.String,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Create a new validation information and log a message into the collection maintained by the validation context
            </summary>
            <param name="description"></param>
            <param name="code"></param>
            <param name="elements"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.ConstructValidationMessage(System.String,System.String,Microsoft.VisualStudio.Modeling.Validation.ViolationType,Microsoft.VisualStudio.Modeling.ModelElement[])">
            <summary>
            Construct a validation message. Override this method to construct a custom validation message.
            </summary>
            <param name="description">message description</param>
            <param name="code">message code</param>
            <param name="violationType">type of message (error, warning or informational message)</param>
            <param name="elements">elements that the message applies to</param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.GetNavigationProxyModelElements(Microsoft.VisualStudio.Modeling.ModelElement)">
            <summary>
            Returns the substitutes model element for the passed in model element. Consider the case where the *viewed* presentation model 
            element(s) (PELs) represents the model element(s) which are proxies to the actual offending model element reported during
            the model validation.
            </summary>
            <param name="fromElement">the reported offending model element</param>
            <returns>A readonly collection of all all the proxy elements which represents the passed in model element.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.ValidationSubjects">
            <summary>
            Get the read only collection of ModelElements to be validated.
            </summary>
            <returns>A readonly list of the model elements to be validated</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.CurrentViolations">
            <summary>
            Returns the readonly collection of reported validation messages.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.CollectedViolations">
            <summary>
            Returns the current offending violations 
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.Categories">
            <summary>
            Returns the validation context.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationContext.CustomCategories">
            <summary>
            Returns the custom validation strings user specified via ValidationController.ValidateCustom API
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationController">
            <summary>
            groups logic for sdm model validtion.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.#ctor">
            <summary>
            constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.Validate(Microsoft.VisualStudio.Modeling.ModelElement,Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Do validation for a single element
            </summary>
            <param name="subject">The subject to validate</param>
            <param name="categories"></param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.Validate(Microsoft.VisualStudio.Modeling.Store,Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Validate the whole store
            </summary>
            <param name="store"></param>
            <param name="categories"></param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.Validate(Microsoft.VisualStudio.Modeling.Partition,Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Validate the whole store
            </summary>
            <param name="partition"></param>
            <param name="categories"></param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.Validate(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Do validation for a set of elements based on the validation categories
            </summary>
            <param name="subjects">The list of subjects to validate</param>
            <param name="categories"></param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ValidateCustom(Microsoft.VisualStudio.Modeling.ModelElement,System.String[])">
            <summary>
            Do validation for a single element
            </summary>
            <param name="subject">The subject to validate</param>
            <param name="customCategories">
            A list of custom specified strings. This allows the validation method with the given strings to be validated.
            Note: At least one custom string needs to be specified, or exception will be thrown.
            </param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ValidateCustom(Microsoft.VisualStudio.Modeling.Store,System.String[])">
            <summary>
            Validate the whole store
            </summary>
            <param name="store">Store to be validated</param>
            <param name="customCategories">
            A list of custom specified strings. This allows the validation method with the given strings to be validated.
            Note: At least one custom string needs to be specified, or exception will be thrown.
            </param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ValidateCustom(Microsoft.VisualStudio.Modeling.Partition,System.String[])">
            <summary>
            Validate the whole partition
            </summary>
            <param name="partition">Partition to be validated</param>
            <param name="customCategories">
            A list of custom specified strings. This allows the validation method with the given strings to be validated.
            Note: At least one custom string needs to be specified, or exception will be thrown.
            </param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ValidateCustom(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.String[])">
            <summary>
            Do validation for a set of elements based on the customCategories specified strings
            </summary>
            <param name="subjects">Subjects to be validated.</param>
            <param name="customCategories">
            A list of custom specified strings. This allows the validation method with the given strings to be validated.
            Note: At least one custom string needs to be specified, or exception will be thrown.
            </param>
            <returns>Returns true if no error/warning/message are found.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.AddObserver(Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver)">
            <summary>
            Add observer to validation message updates...
            </summary>
            <param name="observer"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.RemoveObserver(Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver)">
            <summary>
            Remove observer to validation message updates...
            </summary>
            <param name="observer"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.Validate(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Perform constraint validation with the given context object. It goes thru all the model elements in the context and
            calls ValiationMethod associated with each model element. When it finishes, ValidationMessages property contains 
            all the validation messages
            </summary>
            <returns>return true if there is no errors/warnings/messages encountered</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ResetValidationMessages(Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary)">
            <summary>
            Reset and stage the encountered validaton messages from the given emissary. It will upate the 
            currentValidationMessages private data members
            </summary>
            <param name="emissary">Validation emissary which controls access to the actual list of messages.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ClearMessages">
            <summary>
            clears all messages an notifies observers
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.CollectMessages(Microsoft.VisualStudio.Modeling.Validation.ViolationType)">
            <summary>
            private helper function to go thru the msg collection to collect msgs with the designated type.
            </summary>
            <param name="searchTypes"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.UpdateValidationMessages(Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary)">
            <summary>
            For the given emissary (contains the offending messages), this method will sort thru the list from the previous list
            to figure out what is newly added/removed message. It will then notify all the observers (if there's any).
            </summary>
            <param name="emissary">emissary contains all the validation messages</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.DoValidation(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            do validation
            </summary>
            <param name="validationContext">the context of the validation request</param>
            <returns>updated list of validation messages, give the supplied context</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.CreateValidationContext(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Provide a context class for the validation
            </summary>
            <param name="subjects"></param>
            <param name="categories"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationController.CreateValidationContext(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement},System.String[])">
            <summary>
            Provide a context class for the validation
            </summary>
            <param name="subjects"></param>
            <param name="customCategories">A list of custom specified string. This allows the validation method with the given string to be validated.</param>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationController.HasObserversRegistered">
            <summary>
            Returns whether there's any observer added/registered for notification
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ValidationMessages">
            <summary>
            gets a copy of all the active error/warning/message messages.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationController.ErrorMessages">
            <summary>
            gets a copy of all the active error and fatal messages.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationController.WarningMessages">
            <summary>
            gets a copy of all the active warning messages.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationController.InformationalMessages">
            <summary>
            gets a copy of all the active informational messages.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationController.FatalMessages">
            <summary>
            gets a copy of all the active fatal messages.
            </summary>
            <returns></returns>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary">
            <summary>
            ValidationEmissary maintains a collection of validation messages generated by the user's valiation method. 
            It's being passed around between ValidationContext and ValidationController classes.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            constructor
            </summary>
            <param name="context">context of any validation messages handled by this emissary.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary.ResetValidationMessages(System.Collections.Generic.List{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage})">
            <summary>
            (Re)Sets the messages
            </summary>
            <param name="newMessages">A list of violiations, an empty list or a null value will clear previosly identified messages.</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary.Context">
            <summary>
            data passed in with the validation request.
            </summary>
            <value>data passed in with the validtion request, can be null</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationEmissary.ValidationMessages">
            <summary>
            Returns the list of ValidationMessages reported by user defined ValiationMethods.
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ViolationType">
            <summary>
            Enum to show the violation type of the message
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ViolationType.Error">
            <summary>
            marks an Error message
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ViolationType.Warning">
            <summary>
            marks a Warning message
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ViolationType.Message">
            <summary>
            Marks a Information message
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ViolationType.Fatal">
            <summary>
            Marks a Fatal message, that should prevent opening
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage">
            <summary>
            ValidationMessage is used to carry validation messages that can be picked up by ValidationMessageObserver class.
            ValidationMessage are created from within user defined validation mehod. The actual creation is done via the virtual
            method ValidationContext.ConstructValidationMessage. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationContext,System.String)">
            <summary>
            constructor
            </summary>
            <param name="context"></param>
            <param name="description">problem description (this text will be surfaced to the UI)</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationContext,System.String,System.Int32,System.Int32)">
            <summary>
            ctor
            </summary>
            <param name="context"></param>
            <param name="description"></param>
            <param name="line"></param>
            <param name="column"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationContext,System.String,System.String,Microsoft.VisualStudio.Modeling.Validation.ViolationType)">
            <summary>
            constructor
            </summary>
            <param name="context"></param>
            <param name="description">problem description (displayed to the user)</param>
            <param name="code">message code</param>
            <param name="type"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.ToString">
            <summary>
            
            </summary>
            <returns></returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.UpdateReferencedModelElements(System.Collections.Generic.IEnumerable{Microsoft.VisualStudio.Modeling.ModelElement})">
            <summary>
            Update the referenced model elements
            </summary>
            <param name="modelElements"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.UpdateFileReferences(System.String)">
            <summary>
            
            </summary>
            <param name="referencedFile"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.UpdateFileReferences(System.Collections.Generic.IEnumerable{System.String})">
            <summary>
            Update the related files.
            </summary>
            <param name="updateReferencedFiles"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Equals(System.Object)">
            <summary>
            define equality between two ValidationMessages.
            Override in base class if this definition is not sufficient.
            </summary>
            <param name="obj">the object to compare this one to</param>
            <returns>true if they are equal</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.GetHashCode">
            <summary>
            reuse description text's has code.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Line">
            <summary>
            line number within the file 
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Column">
            <summary>
            column within line of text where error occurs.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Code">
            <summary>
            Error or warning code
            </summary>
            <value>error or warning code</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Type">
            <summary>
            The type of message: e.g. Error or Warning
            </summary>
            <value>message type</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Context">
            <summary>
            context against which this validation message was generated.
            </summary>
            <value>context in which this message was generated</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.Description">
            <summary>
            Problem descrription.
            </summary>
            <value>Problem description for this message.</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.ReferencedModelElements">
            <summary>
            model elements referenced by this message.
            </summary>
            <value>zero or more model elements involved with this error or warning</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.ReferencedFiles">
            <summary>
            Update the related files.
            </summary>
            <value>Zero or more referenced files involved with this error or warning.</value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.File">
            <summary>
            return the name of the first referenced file, if one exists, otherwise null.
            </summary>
            <value></value>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessage.HelpKeyword">
            <summary>
            the help keyword is the validation's error code
            </summary>
            <value></value>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates">
            <summary>
            event arguments for the ValidationMessagesChangedEvent
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates.#ctor(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage})">
            <summary>
            constructor
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates.GetMessagesNotIn(System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.Generic.IList{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage})">
            <summary>
            Find the messages in this list which are not in the supplied list.
            Use: given the messages before an event and after an event, this method can be 
            used to determine the messages that are being added and those that are being removed:
            </summary>
            <param name="currentCollection">a list of messages in the current collection</param>
            <param name="theirMessages">a list of messages to compare with our list</param>
            <returns>the messages that are not in the current list</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates.MessagesBeforeUpdate">
            <summary>
            the complete list of messages prior to this change.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates.MessagesAfterUpdate">
            <summary>
            the complete list of messages after this change.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates.MessagesRemoved">
            <summary>
            the list of messages being removed with this change
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates.MessagesAdded">
            <summary>
            the list of messages being added with this change
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver">
            <summary>
            ValidationMessageObserver reports errors/messages/warnings generated from validation methods. 
            A ValidationMessageObserver is created with a given ValidationController as the ctor parameter. 
            Once all the validation methods have been invoked, the observer picks up the messages being added/removed 
            during the validation process and notify the user (via virturl overridable methods). 
            This class also provides virtual method OnValidationBeginning and OnValidationEnded. 
            This allows the derived class to know when the validation starts and ended.
            
            The method will be called in the following order 
            1. OnValidationBeginning
            2. OnValidationMessagesChanging
            3. OnValidationMessageRemoved - called once for each message removed.
            4. OnValidationMessageAdded - called once for each message added.
            5. OnValidationMessagesChangedSummary
            5. OnValidationEnded 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.NotifyValidationBegin(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Handles the validation begin event. This will call the virtual method OnValidationBeginning
            and the derived class can use the info if they want to.
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.NotifyValidationEnd(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Handles the validation end event. This will call the virtual method OnValidationEnded 
            and the derived class can use the info if they want to.
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.NotifyValidationMessagesChanged(Microsoft.VisualStudio.Modeling.Validation.ValidationMessageUpdates)">
            <summary>
            Handle notifications of changes from the given ValidationMessageUpdates. It goes thru 
            the removed/added message and invoke the OnValidationMessageRemoved/OnValidationMessageAdded virtual methods.
            At the end, it calls OnValidationMessagesChangedSummary virtual method with the removed/added message. 
            The child class can override OnValidationMessagesChangedSummary if needed.
            </summary>
            <param name="updates"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.OnValidationBeginning(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Overriddable method to capture the validation beginning stats
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.OnValidationEnded(Microsoft.VisualStudio.Modeling.Validation.ValidationContext)">
            <summary>
            Overriddable method to capture the validation ended notification.
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.OnValidationMessagesChanging(System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage})">
            <summary>
            Override to process a change to the message collection.
            </summary>
            <remarks>
            methods are called in this order:
            1. OnValidationMessagesChanging
            2. OnValidationMessageRemoved - called once for each message removed.
            3. OnValidationMessageAdded - called once for each message added.
            4. OnValidationMessagesChangedSummary
            </remarks>
            <param name="messagesBeforeUpdate"></param>
            <param name="messagesRemoved"></param>
            <param name="messagesAdded"></param>
            <param name="messagesAfterUpdate"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.OnValidationMessageRemoved(Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Override to process each message removed after the controller finishes the constraint validation.
            </summary>
            <param name="removedMessage"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.OnValidationMessageAdded(Microsoft.VisualStudio.Modeling.Validation.ValidationMessage)">
            <summary>
            Override to process each message added after the controller finishes the constraint validation.
            </summary>
            <remarks>
            methods are called in this order:
            1. OnValidationMessagesChanging
            2. OnValidationMessageRemoved - called once for each message removed.
            3. OnValidationMessageAdded - called once for each message added.
            4. OnValidationMessagesChangedSummary
            </remarks>
            <param name="addedMessage"></param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMessageObserver.OnValidationMessagesChangedSummary(System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage},System.Collections.ObjectModel.ReadOnlyCollection{Microsoft.VisualStudio.Modeling.Validation.ValidationMessage})">
            <summary>
            Override to process a summary of the the change to the message collection.
            </summary>
            <remarks>
            methods are called in this order:
            1. OnValidationMessagesChanging
            2. OnValidationMessageRemoved - called once for each message removed.
            3. OnValidationMessageAdded - called once for each message added.
            4. OnValidationMessagesChangedSummary
            </remarks>
            <param name="messagesBeforeUpdate"></param>
            <param name="messagesAfterUpdate"></param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationCategories">
            <summary>
            Flavor of the validaton categories...
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationCategories.Menu">
            <summary>
            Validation method to be invoked when user choose from the menu
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationCategories.Open">
            <summary>
            Validation method to be invoked when file is opened
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationCategories.Save">
            <summary>
            Validation method to be invoked when file is closed
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationCategories.Custom">
            <summary>
            /// Custom validation method
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationCategories.Load">
            <summary>
            Invoked immediately after file is loaded, before fixups
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationMethodAttribute">
            <summary>
            Class definition for C# custom attribute ValidationMethod.
            This is used for marking methnods as Validator functions
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMethodAttribute.#ctor">
            <summary>
            Constructor for class ValidationMethodAttribute. Specifies a user-validation method by default
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationMethodAttribute.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationCategories)">
            <summary>
            Constructor for class ValidationMethodAttribute. Specifies a user-validation method by default
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMethodAttribute.Categories">
            <summary>
            The category of this method
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationMethodAttribute.CustomCategory">
            <summary>
            Get/Set custom string to support custom validation.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationState">
            <summary>
            ValidationState to indicate whether the constraint validation will be enabled for meta-class 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationState.Disabled">
            <summary>
            Disable the contraint validation 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationState.Enabled">
            <summary>
            Enable the contraint validation 
            </summary>
        </member>
        <member name="F:Microsoft.VisualStudio.Modeling.Validation.ValidationState.Inherited">
            <summary>
            Will assume the constraint validation status from the parent meta class 
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationStateAttribute">
            <summary>
            Attribute class used to mark meta-classes. A valid meta-class should have both [MetaObject] and [MetaClass] defined.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.Validation.ValidationStateAttribute.#ctor(Microsoft.VisualStudio.Modeling.Validation.ValidationState)">
            <summary>
            Initializes a new instance of ValidationStateAttribute class.
            </summary>
            <param name="validationState">Constraint validation behavior flag</param>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStateAttribute.ValidationState">
            <summary>
            Gets the constraint validation flag for the meta-class custom attribute.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings">
            <summary>
              A strongly-typed resource class, for looking up localized strings, etc.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.ResourceManager">
            <summary>
              Returns the cached ResourceManager instance used by this class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.Culture">
            <summary>
              Overrides the current thread's CurrentUICulture property for all
              resource lookups using this strongly typed resource class.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0101">
            <summary>
              Looks up a localized string similar to Invoke validation method &apos;{0}&apos; failed due to mismatched method parameter count.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0102">
            <summary>
              Looks up a localized string similar to Invoke validation method &apos;{0}&apos; failed due to method contains incorrect parameter type(s).
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0103">
            <summary>
              Looks up a localized string similar to Invoke validation method &apos;{0}&apos; failed.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0104">
            <summary>
              Looks up a localized string similar to AddObserver operation failed: The observer has been registered previously..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0105">
            <summary>
              Looks up a localized string similar to RemoveObserver operation failed: Either the observer has been un-registered or it has not been registered previously..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0106">
            <summary>
              Looks up a localized string similar to Invoke validation method &apos;{0}&apos; failed due to a null reference being accessed..
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.Validation.ValidationStrings.MVE0107">
            <summary>
              Looks up a localized string similar to Incorrect Validate method usage: Argument category should not contain ValidationCategory.Custom enum value. Use ValidateCustom method to perform the custom validation..
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.AvoidDuplicateLinksComparer">
            <summary>
            Comparer for duplicate links set.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ElementIdComparer">
            <summary>
            Equality comparer for ModelElement which Equals and GetHashCode use
            element ID to calcuate their respective results.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ErrorHandler">
            <summary>
            Helper class to throw exceptions and assert certain conditions in domain modeling code.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.HashCodeUtility">
            <summary>
            Utility to calculate CRC values.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.HashCodeUtility.Add(System.String)">
            <summary>
            Accumulates a CRC on a string.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.HashCodeUtility.Add(System.Single)">
            <summary>
            Accumulates a CRC on a 32 bit float.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.HashCodeUtility.Add(System.Int32)">
            <summary>
            Accumulates a CRC on a 32 bit Int32.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.HashCodeUtility.Add(System.Char)">
            <summary>
            Accumulates a CRC on a 16 bit Char.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.HashCodeUtility.Add(System.Guid)">
            <summary>
            Accumulates a CRC on a Guid.
            </summary>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.HashCodeUtility.Value">
            <summary>
            Gets the value of the CRC that has been accumulated up to this point.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.InternalModelingErrorException">
            <summary>
            The exception that is thrown when an internal error occus inside the modeling engine.
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InternalModelingErrorException.#ctor">
            <summary>
            Initializes a new instance of the InternalModelingErrorException class. 
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InternalModelingErrorException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the InternalModelingErrorException class with a specified error message. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InternalModelingErrorException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the InternalModelingErrorException class with a specified error message
            and a reference to the inner exception that is the cause of this exception. 
            </summary>
            <param name="message">The error message that explains the reason for the exception. </param>
            <param name="innerException">
            The exception that is the cause of the current exception.
            If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. 
            </param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.InternalModelingErrorException.#ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)">
            <summary>
            Initializes a new instance of the InternalModelingErrorException class with serialized data. 
            </summary>
            <param name="info">The object that holds the serialized object data.</param>
            <param name="context">The contextual information about the source or destination.</param>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.ResourceManagerCache">
            <summary>
            A helper class to find and cache resource manager instance based on resource type and name.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.Set`1">
            <summary>
            Generic collection class representing a set of unique elements.
            </summary>
            <typeparam name="T">Type of element</typeparam>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CriticalException.IsCriticalException(System.Exception)">
            <summary>
            	Gets whether exception is a critical one and can't be ignored with corrupting
            	AppDomain state.
            </summary>
            <param name="ex">Exception to test.</param>
            <returns>True if exception should not be swallowed.</returns>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.CriticalException.ThrowOrShow(System.IServiceProvider,System.Exception)">
            <summary>
            	Shows non-critical exceptions to the user and returns false or
            	returns true for critical exceptions.
            </summary>
            <param name="serviceProvider">Service provider to use to display error message.</param>
            <param name="ex">Exception to handle.</param>
            <returns>True if exception is critical and can't be ignored.</returns>
        </member>
        <member name="P:Microsoft.VisualStudio.Modeling.CriticalException.DisableExceptionFilter">
            <summary>
            	Gets whether exception filtering is disabled base on registry settings.
            </summary>
        </member>
        <member name="T:Microsoft.VisualStudio.Modeling.SafeWindowTarget">
            <summary>
            Exception hardening work.  This class can be used to filter messages sent to a control,
            and catch/display all non-critical exceptions.  Otherwise, Watson will
            be invoked and will take down the process, potentially resulting in data loss.  See
            document referenced in bug 427820 for more details.	 Use this class to wrap an existing 
            IWindowTarget as follows (c is a Control):
            
            c.WindowTarget = new SafeWindowTarget(c.WindowTarget);
            </summary>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SafeWindowTarget.System#Windows#Forms#IWindowTarget#OnMessage(System.Windows.Forms.Message@)">
            <devdoc>
            The main wndproc for the control.  Wrapped to display non-critical exceptions to the user.
            </devdoc>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SafeWindowTarget.ReplaceWindowTargetRecursive(System.IServiceProvider,System.Collections.ICollection)">
            <summary>
            Replaces the WindowTarget for all child controls of the specified collection.
            In Debug builds, this will assert that any child controls added after this call must have their WindowTarget replaced as well.
            </summary>
            <param name="serviceProvider">The ServiceProvider.</param>
            <param name="controls">The collection of controls to recurse through and replace their target.</param>
        </member>
        <member name="M:Microsoft.VisualStudio.Modeling.SafeWindowTarget.ReplaceWindowTargetRecursive(System.IServiceProvider,System.Collections.ICollection,System.Boolean)">
            <summary>
            Replaces the WindowTarget for all child controls of the specified collection.
            </summary>
            <param name="serviceProvider">The ServiceProvider.</param>
            <param name="controls">The collection of controls to recurse through and replace their target.</param>
            <param name="checkControlAdded">If true, in Debug builds, this will assert that any controls 
            added after this call must have their WindowTarget replaced as well.</param>
        </member>
    </members>
</doc>

//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
//<StyleCopExclude RulesGroup='Oslo File Naming Rules'/>

namespace Tests.Repository.Uml2.Loader
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class UmlModelHelper
    {
        void CompareAssociationClasses(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from a in elements
                           where a.Name == "packagedElement" && GetXmiType(a) == "uml:AssociationClass"
                           let Name = GetName(a)
                           orderby Name
                           select new
                           {
                               Name,
                               IsAbstract = GetIsAbstract(a),
                               IsActive = GetIsActive(a),
                               IsDerived = GetIsDerived(a),
                               IsLeaf = GetIsLeaf(a),
                               Visibility = GetVisibility(a),
                           };
                },
                folderClause =>
                {
                    return string.Format(@"select Name, IsAbstract, IsActive, IsDerived, IsLeaf, Visibility
                                          from [Microsoft.Uml2].[AssociationClasses] i
                                          join [Microsoft.Uml2].[UmlResources] ur on ur.Id = i.ResourceId 
					  join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                                          where {0}
                                          order by Name",
                                        folderClause);
                });
        }

        void CompareAssociations(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from a in elements
                           where a.Name == "packagedElement" &&
                                   (GetXmiType(a) == "uml:Association" ||
                                     GetXmiType(a) == "uml:AssociationClass")
                           let Name = GetName(a)
                           orderby Name
                           select new
                           {
                               Name,
                               ElementKind = (GetXmiType(a) == "uml:Association") ? "Association" : "AssociationClass",
                               IsAbstract = GetIsAbstract(a),
                               IsDerived = GetIsDerived(a),
                               IsLeaf = GetIsLeaf(a),
                               Visibility = GetVisibility(a),
                           };
                },
                folderClause =>
                {
                    return string.Format(@"select Name, IsAbstract, IsDerived, IsLeaf, ElementKind, Visibility
                                          from [Microsoft.Uml2].[Associations] i
                                          join [Microsoft.Uml2].[UmlResources] ur on ur.Id = i.ResourceId 
					  join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                                          where {0} and ElementKind in ('Association', 'AssociationClass')
                                          order by Name",
                                        folderClause);
                });
        }

        void CompareAssociationMemberEnds(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from a in elements
                           where a.Name == "packagedElement" &&
                                 (GetXmiType(a) == "uml:Association" || GetXmiType(a) == "uml:AssociationClass")
                           let MemberEnds = a.Attributes("memberEnd").Any() ?
                                            a.Attribute("memberEnd").Value.Split(' ') :
                                            from d in a.Descendants("memberEnd")
                                            select GetXmiIdRef(d)
                           from m in
                               (from p in elements
                                where p.Name == "ownedEnd" || GetXmiType(p) == "uml:Property" || p.Name == "ownedAttribute"
                                select p)
                           where MemberEnds.Contains(GetXmiId(m))
                           let Name = GetName(a)
                           let MemberName = GetName(m)
                           orderby MemberName, Name
                           select new { Name, MemberName };
                },
                folderClause =>
                {
                    return string.Format(@"select a.Name as Name, p.Name as MemberName
                                          from [Microsoft.Uml2].[Associations] as a left join
                    		                   [Microsoft.Uml2].[Properties] as p on (p.Association = a.ResourceId And p.Folder = a.Folder)
                                          join [Microsoft.Uml2].[UmlResources] ur on ur.Id = a.ResourceId 
					  join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                                          where p.ElementKind='Property' and a.{0} 
                                                and a.ElementKind in ('Association', 'AssociationClass')
                                          order by MemberName, Name",
                                        folderClause);
                });
        }

        void CompareClasses(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    XName umlPackage = elements.First().GetNamespaceOfPrefix("uml").GetName("Package");
                    XName umlModel = elements.First().GetNamespaceOfPrefix("uml").GetName("Model");

                    var allClassElements = from c in elements
                                           let Href = GetAttributeValue(c, "href", string.Empty)
                                           where c.Name != "nestedClassifier" && (GetXmiType(c) == "uml:Class" || GetXmiType(c) == "uml:AssociationClass") && string.IsNullOrEmpty(Href)
                                           let Name = string.IsNullOrEmpty(Href) ? GetName(c) : Href.Split(new char[] { '#' }).Last()
                                           let OwningPackageName = GetOwningPackageName(c)
                                           orderby OwningPackageName, Name
                                           select new
                                           {
                                               Name,
                                               ElementKind = (GetXmiType(c) == "uml:Class") ? "Class" : "AssociationClass",
                                               Href,
                                               Visibility = GetVisibility(c),
                                               IsAbstract = GetIsAbstract(c),
                                               IsActive = GetIsActive(c),
                                               IsLeaf = GetIsLeaf(c),
                                               OwningPackageName
                                           };

                    return from e in allClassElements.Distinct()
                           select new
                           {
                               e.Name,
                               e.ElementKind,
                               e.Visibility,
                               e.IsAbstract,
                               e.IsActive,
                               e.IsLeaf,
                               e.OwningPackageName,
                           };
                },
                folderClause =>
                {
                    return string.Format(@"select c.Name, c.IsAbstract, c.IsActive, c.IsLeaf, c.ElementKind,
                                                  c.Visibility, p.Name as OwningPackageName
                                           from [Microsoft.Uml2].[Classes] as c left join
                                                [Microsoft.Uml2].[Packages] as p on c.OwningPackage = p.Id And c.Folder = p.Folder
                                           join [Microsoft.Uml2].[UmlResources] ur on ur.Id = c.ResourceId 
					   join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                                           where (c.ElementKind='Class' or c.ElementKind='AssociationClass') and c.{0} and c.Class is Null
                                           order by OwningPackageName, c.Name",
                                           folderClause);
                });
        }


        public void CompareClassModel(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            CompareAssociationClasses(compare);
            CompareAssociations(compare);
            CompareAssociationMemberEnds(compare);
            CompareClasses(compare);
            CompareComments(compare);
            // CompareConstraints(compare);
            CompareDataTypes(compare);
            CompareEnumerations(compare);
            CompareGeneralizations(compare);
            CompareGeneralizationSets(compare);
            CompareInterfaces(compare);
            CompareInterfaceRealizations(compare);
            CompareOperations(compare);
            ComparePackages(compare);
            CompareParameters(compare);
            CompareProperties(compare);
            CompareTemplateSignatures(compare);
        }


        void CompareComments(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from p in elements
                           where p.Name == "ownedComment"
                           let Body = p.Descendants("body").Any() ?
                                      p.Descendants("body").First().Value :
                                      p.Attributes("body").Any() ?
                                      p.Attribute("body").Value :
                                      string.Empty
                           orderby Body
                           select new { Body };
                },
                folderClause =>
                {

                    return string.Format(@"select Body from [Microsoft.Uml2].[Comments] i 
			    join [Microsoft.Uml2].[UmlResources] ur on ur.Id = i.ResourceId 
			    join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id where {0} order by Body", folderClause);
                });
        }

        void CompareConstraints(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from c in elements.Where(e => e.Name == "ownedRule" && GetXmiType(e) == "uml:Constraint")
                           from ce in GetConstrainedElements(elements, c).DefaultIfEmpty()
                           let Name = GetName(c)
                           let ConstrainedElementName = (ce == default(XElement)) ? string.Empty : GetName(ce)
                           orderby Name, ConstrainedElementName
                           select new
                           {
                               Name,
                               ConstrainedElementName,
                               Visibility = GetVisibility(c)
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                         select c.Name, c.Visibility,
                        	ISNULL(pe.Name, ISNULL(re.Name, p.Name)) as ConstrainedElementName
                         from [Microsoft.Uml2].[Constraints] as c left join
                        	  [Microsoft.Uml2].[A_ConstrainedElement_Constraint] as ce on ce.[ConstraintId] = c.Id left join
                              [Microsoft.Uml2].[PackageableElements] as pe on pe.ResourceId=ce.ConstrainedElement And pe.Folder = ce.Folder left join
                              [Microsoft.Uml2].[TemplateSignatures] as ts on ts.ResourceId=ce.ConstrainedElement And ts.Folder = ce.Folder left join
                              [Microsoft.Uml2].[RedefinableElements] as re on re.ResourceId=ce.ConstrainedElement And re.Folder = ce.Folder left join
                              [Microsoft.Uml2].[Parameters] as p on p.ResourceId=ce.ConstrainedElement and p.Folder = ce.Folder
                          join [Microsoft.Uml2].[UmlResources] ur on ur.Id = c.ResourceId 
			  join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                         where c.{0}
                         order by c.Name, ConstrainedElementName",
                         folderClause);
                });
        }

        void CompareDataTypes(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    XName umlPackage = elements.First().GetNamespaceOfPrefix("uml").GetName("Package");
                    XName umlModel = elements.First().GetNamespaceOfPrefix("uml").GetName("Model");

                    var allTypeElements = from d in elements
                                          let Href = GetAttributeValue(d, "href", string.Empty).ToLowerInvariant()
                                          where (GetXmiType(d) == "uml:DataType" || GetXmiType(d) == "uml:PrimitiveType") &&
                                              // Ignore references to types defined elsewhere
                                                (string.IsNullOrEmpty(Href))
                                          let Name = GetName(d).ToLower()
                                          let ElementKind = GetXmiType(d).Substring(4)
                                          let OwningPackageName = GetOwningPackageName(d)
                                          orderby Name, ElementKind, Href, OwningPackageName
                                          select new
                                          {
                                              Name,
                                              ElementKind,
                                              Href,
                                              IsAbstract = GetIsAbstract(d),
                                              IsLeaf = GetIsLeaf(d),
                                              OwningPackageName,
                                              Visibility = GetVisibility(d)
                                          };

                    return from e in allTypeElements.Distinct()
                           select new
                           {
                               e.Name,
                               e.ElementKind,
                               e.IsAbstract,
                               e.IsLeaf,
                               e.OwningPackageName,
                               e.Visibility,
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                         select lower(d.Name) as Name, d.ElementKind, d.IsAbstract, d.IsLeaf, d.Visibility,
                                p.Name as OwningPackageName
                         from [Microsoft.Uml2].[DataTypes] as d left join
                              [Microsoft.Uml2].[Packages] as p on p.Id = d.OwningPackage And p.Folder = d.Folder left join
                              -- [Microsoft.Uml2].[UmlResourceReferences] as urr on urr.Element = d.Id left join
                              [Microsoft.Uml2].[UmlResources] as ur on ur.Id = d.ResourceId 
			  join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                         where (d.ElementKind='DataType' or d.ElementKind='PrimitiveType') and d.{0} 
                         order by d.Name, d.ElementKind, OwningPackageName",
                         folderClause);
                });
        }

        void CompareEnumerations(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    XName umlPackage = elements.First().GetNamespaceOfPrefix("uml").GetName("Package");
                    XName umlModel = elements.First().GetNamespaceOfPrefix("uml").GetName("Model");

                    return from e in elements
                           where GetXmiType(e) == "uml:Enumeration" && e.Name != "references"
                           join l in
                               (from x in elements
                                where x.Name == "ownedLiteral" &&
                                      GetXmiType(x) == "uml:EnumerationLiteral"
                                select x) on e equals l.Parent into literals
                           from literal in literals.DefaultIfEmpty()
                           let Name = GetName(e)
                           let LiteralName = (literal == default(XElement)) ? string.Empty : GetName(literal)
                           let LiteralVisibility = (literal == default(XElement)) ? string.Empty : GetVisibility(literal)
                           let OwningPackageName = GetOwningPackageName(e)
                           orderby Name, LiteralName
                           select new
                           {
                               Name,
                               LiteralName,
                               LiteralVisibility,
                               OwningPackageName,
                               Visibility = GetVisibility(e)
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                         select e.Name, e.Visibility, p.Name as OwningPackageName, 
                                l.Name as LiteralName, l.Visibility as LiteralVisibility
                         from [Microsoft.Uml2].[Enumerations] as e left join
                              [Microsoft.Uml2].[Packages] as p on p.Id = e.OwningPackage And p.Folder = e.Folder left join
                              [Microsoft.Uml2].EnumerationLiterals as l on l.Enumeration = e.Id And l.Folder = e.Folder
                         join [Microsoft.Uml2].[UmlResources] ur on ur.Id = e.ResourceId 
			 join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                         where e.{0}
                         order by e.Name, LiteralName",
                         folderClause);
                });
        }


        void CompareGeneralizations(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from g in elements
                           let GeneralName = GetGeneralElementName(elements, g)
                           let SpecificName = (g.Parent != null) ? GetName(g.Parent) : string.Empty
                           where g.Name == "generalization"
                           orderby GeneralName, SpecificName
                           select new
                           {
                               GeneralName,
                               IsSubstitutable = GetIsSubstitutable(g),
                               SpecificName,
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                             select g.IsSubstitutable, gc.Name as GeneralName, sc.Name as SpecificName 
                             from [Microsoft.Uml2].[Generalizations] as g left join
                                    	             [Microsoft.Uml2].[Classifiers] as gc on gc.ResourceId = g.General And gc.Folder = g.Folder left join
                                    	             [Microsoft.Uml2].[Classifiers] as sc on sc.Id = g.Specific And sc.Folder = g.Folder
                             join [Microsoft.Uml2].[UmlResources] ur on ur.Id = g.ResourceId 
			     join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                             where g.{0}
                             order by GeneralName, SpecificName",
                             folderClause);
                });
        }

        void CompareGeneralizationSets(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from e in elements
                           where GetXmiType(e) == "uml:GeneralizationSet"
                           let Name = GetName(e)
                           let XmiId = GetXmiId(e)
                           let Powertype = e.Attributes("powertype").Any() ?
                                            GetName(GetReferencedElement(elements, e.Attribute("powertype").Value)) :
                                            (from c in elements
                                             where c.Attributes("powertypeExtent").Any() && c.Attribute("powertypeExtent").Value.Contains(XmiId)
                                             select GetName(c)).FirstOrDefault()
                           from g in e.Attributes("generalization").Any() ?
                                     e.Attribute("generalization").Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) :
                                     elements.Where(el => el.Attributes("generalizationSet").Any() &&
                                                          el.Attribute("generalizationSet").Value == XmiId).Select(f => GetXmiId(f))
                           let Generalization = GetReferencedElement(elements, g)
                           let GeneralName = GetGeneralElementName(elements, Generalization)
                           let SpecificName = (Generalization.Parent != null) ? GetName(Generalization.Parent) : string.Empty
                           orderby Name, Powertype, GeneralName, SpecificName
                           select new
                           {
                               Name,
                               Powertype,
                               GeneralName,
                               SpecificName
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                        select gs.Name, pc.Name as Powertype, gc.Name as GeneralName, sc.Name as SpecificName
                        from [Microsoft.Uml2].[GeneralizationSets] as gs left join
                             [Microsoft.Uml2].[Classifiers] as pc on pc.ResourceId = gs.Powertype And pc.Folder = gs.Folder left join 
                             [Microsoft.Uml2].[A_GeneralizationSet_Generalization] as agg on agg.GeneralizationSet = gs.ResourceId And agg.Folder = gs.Folder left join
                             [Microsoft.Uml2].[Generalizations] as g on g.ResourceId = agg.Generalization And g.Folder = agg.Folder left join
                             [Microsoft.Uml2].[Classifiers] as gc on gc.ResourceId = g.General And gc.Folder = g.Folder left join
                             [Microsoft.Uml2].[Classifiers] as sc on sc.Id = g.Specific
                         join [Microsoft.Uml2].[UmlResources] ur on ur.Id = gs.ResourceId 
			 join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                        where gs.{0}
                        order by  Name, Powertype, GeneralName, SpecificName",
                        folderClause);
                });
        }

        void CompareInterfaces(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    XName umlPackage = elements.First().GetNamespaceOfPrefix("uml").GetName("Package");
                    XName umlModel = elements.First().GetNamespaceOfPrefix("uml").GetName("Model");

                    return from i in elements
                           where GetXmiType(i) == "uml:Interface"
                           let Name = GetName(i)
                           orderby Name
                           select new
                           {
                               Name,
                               IsAbstract = GetIsAbstract(i),
                               IsLeaf = GetIsLeaf(i),
                               OwningPackageName = GetOwningPackageName(i),
                               Visibility = GetVisibility(i)
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                             select i.Name, i.IsAbstract, i.IsLeaf, i.Visibility, p.Name as OwningPackageName
                             from [Microsoft.Uml2].[Interfaces] as i left join
                                  [Microsoft.Uml2].[Packages] as p on p.Id = i.OwningPackage And p.Folder = i.Folder
                             join [Microsoft.Uml2].[UmlResources] ur on ur.Id = i.ResourceId 
			     join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                             where i.{0}
                             order by i.Name",
                             folderClause);
                });
        }

        void CompareInterfaceRealizations(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from e in elements
                           where GetXmiType(e) == "uml:InterfaceRealization" || e.Name == "interfaceRealization"
                           let SupplierName = e.Attributes("supplier").Any() ?
                                             GetName(GetReferencedElement(elements, e.Attribute("supplier").Value)) :
                                             e.Descendants("supplier").Any() ?
                                             GetName(GetReferencedElement(elements, GetXmiIdRef(e.Descendants("supplier").First()))) :
                                             e.Attributes("contract").Any() ?
                                             GetName(GetReferencedElement(elements, e.Attribute("contract").Value)) :
                                             e.Descendants("contract").Any() ?
                                             GetName(GetReferencedElement(elements, GetXmiIdRef(e.Descendants("contract").First()))) :
                                             string.Empty
                           let ClientName = e.Attributes("client").Any() ?
                                             GetName(GetReferencedElement(elements, e.Attribute("client").Value)) :
                                             e.Descendants("client").Any() ?
                                             GetName(GetReferencedElement(elements, GetXmiIdRef(e.Descendants("client").First()))) :
                                             string.Empty
                           orderby SupplierName, ClientName
                           select new
                           {
                               Name = GetName(e),
                               ClientName,
                               SupplierName,
                               Visibility = GetVisibility(e),
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                        select ir.Name, i.Name as SupplierName, ir.Visibility, c.Name as ClientName
                        from [Microsoft.Uml2].[InterfaceRealizations] as ir left join
                             [Microsoft.Uml2].[Interfaces] as i on i.ResourceId = ir.Contract And i.Folder = ir.Folder left join
                             [Microsoft.Uml2].[Classifiers] as c on c.Id = ir.ImplementingClassifier And c.Folder = ir.Folder 
                        join [Microsoft.Uml2].[UmlResources] ur on ur.Id = ir.ResourceId 
			join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                        where ir.{0}
                        order by SupplierName, ClientName",
                        folderClause);
                });
        }

        void CompareOperations(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    XName xmiId = elements.First().GetNamespaceOfPrefix("xmi").GetName("id");

                    return from o in elements
                           where (GetXmiType(o) == "uml:Operation") || o.Name.LocalName == "ownedOperation"
                           let Name = GetName(o)
                           let c = o.Attributes("class").Any() ? o.Attribute("class").Value :
                                   o.Attributes("interface").Any() ? o.Attribute("interface").Value :
                                   null
                           let ClassifierName = (c != null) ?
                              GetName(elements.Where(e => e.Attributes(xmiId).Any() && e.Attribute(xmiId).Value == c).First()) :
                              GetName(o.Parent)
                           orderby ClassifierName, Name
                           select new
                           {
                               Name,
                               Visibility = GetVisibility(o),
                               IsAbstract = GetIsAbstract(o),
                               IsLeaf = GetIsLeaf(o),
                               IsQuery = GetIsQuery(o),
                               IsStatic = GetIsStatic(o),
                               ClassifierName
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                             select o.Name, o.IsAbstract, o.IsLeaf, o.IsQuery, o.IsStatic, o.Visibility,
                                    ISNULL(c.Name, ISNULL(i.Name, d.Name)) as ClassifierName 
                             from [Microsoft.Uml2].[Operations] as o left join
                                  [Microsoft.Uml2].[Classes] as c on o.Class = c.Id And o.Folder = c.Folder left join
                                  [Microsoft.Uml2].[Interfaces] as i on o.Interface = i.Id And o.Folder = i.Folder left join
                                  [Microsoft.Uml2].[DataTypes] as d on o.Datatype = d.Id And d.Folder = o.Folder
                              join [Microsoft.Uml2].[UmlResources] ur on ur.Id = o.ResourceId 
			      join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                             where o.{0}
                             order by ClassifierName, o.Name",
                             folderClause);
                });
        }

        void ComparePackages(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    XNamespace umlNamespace = elements.First().GetNamespaceOfPrefix("uml");
                    XName umlPackage = umlNamespace.GetName("Package");

                    return from p in elements
                           where (p.Name == "packagedElement" && GetXmiType(p) == "uml:Package") ||
                                  p.Name == umlPackage
                           let Name = GetName(p)
                           let ParentName = p.Parent != null ? GetName(p.Parent) : string.Empty
                           orderby ParentName, Name
                           select new
                           {
                               Name,
                               Visibility = GetVisibility(p),
                               ParentName
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                                select p1.Name, p2.Name as ParentName, p1.Visibility
                                from [Microsoft.Uml2].[Packages] as p1 left join
                                     [Microsoft.Uml2].[Packages] as p2 on p2.Id = p1.OwningPackage And p1.Folder = p2.Folder 
                                join [Microsoft.Uml2].[UmlResources] ur on ur.Id = p1.ResourceId 
				join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                                where p1.ElementKind='Package' and p1.{0} -- and p1.IsReference='false' 
                                order by ParentName, p1.Name",
                                folderClause);
                });
        }

        void CompareParameters(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from p in elements
                           where (p.Name == "ownedParameter" || GetXmiType(p) == "uml:Parameter") &&
                                  GetXmiType(p) != "uml:OperationTemplateParameter" &&
                                  GetXmiType(p) != "uml:ClassifierTemplateParameter" &&
                                  GetXmiType(p) != "uml:ConnectableElementTemplateParameter"
                           let Name = GetName(p)
                           let OperationParentName = p.Parent != null && GetXmiType(p.Parent) != "uml:Activity" ? GetName(p.Parent) : string.Empty
                           let Direction = GetAttributeValue(p, "direction", "in")
                           let TypeName = GetParameterTypeName(elements, p)
                           orderby OperationParentName, TypeName, Direction, Name
                           select new
                           {
                               Name,
                               Direction,
                               IsException = GetIsException(p),
                               IsOrdered = GetIsOrdered(p),
                               IsStream = GetIsStream(p),
                               IsUnique = GetIsUnique(p),
                               OperationParentName = OperationParentName,
                               TypeName,
                               Visibility = GetVisibility(p)
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                             select p.Name, p.Direction, p.IsException, p.IsOrdered, p.IsStream,
                                    p.IsUnique, p.Visibility, o.Name as OperationParentName, c.Name as TypeName
                             from [Microsoft.Uml2].[Parameters] as p left join
                                  [Microsoft.Uml2].[Operations] as o on o.Id = p.Operation left join
                                  [Microsoft.Uml2].[Classifiers] as c on c.ResourceId = p.[Type] And c.Folder = p.Folder
                              join [Microsoft.Uml2].[UmlResources] ur on ur.Id = p.ResourceId 
			      join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                             where p.{0}
                             order by OperationParentName, TypeName, Direction, p.Name",
                             folderClause);
                });
        }

        void CompareProperties(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from p in elements
                           let ElementType = GetXmiType(p)
                           where (p.Name == "ownedAttribute" ||
                                 p.Name == "ownedEnd" ||
                                 ElementType == "uml:Property" ||
                                 ElementType == "uml:ExtensionEnd") &&
                                 GetHref(p) == string.Empty
                           let Name = GetName(p)
                           let ClassifierName = GetName(p.Parent)
                           let ElementKind = string.IsNullOrEmpty(ElementType) ? "Property" : ElementType.Substring(4)
                           orderby ClassifierName, Name
                           select new
                           {
                               Name,
                               ElementKind,
                               Visibility = GetVisibility(p),
                               Aggregation = GetAggregation(p),
                               IsDerived = GetIsDerived(p),
                               IsDerivedUnion = GetIsDerivedUnion(p),
                               IsLeaf = GetIsLeaf(p),
                               IsOrdered = GetIsOrdered(p),
                               IsReadOnly = GetIsReadOnly(p),
                               IsStatic = GetIsStatic(p),
                               IsUnique = GetIsUnique(p),
                               ClassifierName
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                             select p.Name, p.ElementKind, p.Aggregation, p.IsDerived, p.IsDerivedUnion, 
                                    p.IsLeaf, p.IsOrdered, p.IsReadOnly, p.IsStatic, p.IsUnique, p.Visibility,
                                    ISNULL(c.Name, ISNULL(i.Name, ISNULL(d.Name, ISNULL(a.Name, me.Name)))) as ClassifierName 
                              from [Microsoft.Uml2].[Properties] as p 
                                   left join (select Id, Name from [Microsoft.Uml2].[Classes] 
                                                union select Id, Name from [Microsoft.Uml2].[Collaborations]) c on p.Class = c.Id left join
                                   [Microsoft.Uml2].[Interfaces] as i on p.Interface = i.Id left join
                                   [Microsoft.Uml2].[DataTypes] as d on p.Datatype = d.Id left join
                                   [Microsoft.Uml2].[Associations] as a on p.Association = a.ResourceId And p.Folder = a.Folder left join
                                   [Microsoft.Uml2].[Properties] as me on p.AssociationEnd = me.Id
                              join [Microsoft.Uml2].[UmlResources] ur on ur.Id = p.ResourceId 
			      join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                              where p.{0} 
                              order by ClassifierName, p.Name",
                            folderClause);
                });
        }

        void CompareTemplateSignatures(Action<Func<IEnumerable<XElement>, IEnumerable<object>>, Func<string, string>> compare)
        {
            compare(
                elements =>
                {
                    return from e in elements
                           let XmiType = GetXmiType(e)
                           where XmiType == "uml:RedefinableTemplateSignature" ||
                                 XmiType == "uml:TemplateSignature" ||
                                 e.Name == "ownedTemplateSignature"
                           from p in e.Descendants("ownedParameter")
                           where GetXmiType(p) == "uml:OperationTemplateParameter" ||
                                 GetXmiType(p) == "uml:ClassifierTemplateParameter" ||
                                 GetXmiType(p) == "uml:ConnectableElementTemplateParameter"
                           let OwningClassifierName = IsClassifier(e.Parent) || e.Parent.Name == "ownedOperation" ?
                                                      GetName(e.Parent) :
                                                      string.Empty
                           let ParameterKind = GetXmiType(p).Substring(4)
                           let ParameterName = p.Descendants("ownedParameteredElement").Any() ?
                                               GetName(p.Descendants("ownedParameteredElement").First()) :
                                               GetName(p)
                           let Name = GetName(e)
                           orderby Name, ParameterName, OwningClassifierName
                           select new
                           {
                               Name,
                               ParameterName,
                               ParameterKind,
                               OwningClassifierName,
                               IsLeaf = GetIsLeaf(e),
                               ElementKind = string.IsNullOrEmpty(XmiType) ? "TemplateSignature" : XmiType.Substring(4),
                               Visibility = GetVisibility(e)
                           };
                },
                folderClause =>
                {
                    return string.Format(@"
                        select * from
                            ( select ts.Name, ts.IsLeaf, c.Name as OwningClassifierName, 
                                   tp.ElementKind as ParameterKind,
                                   ISNULL(cl.Name, ISNULL(o.Name, ISNULL(p.Name, i.Name))) as ParameterName,
                                   ts.ElementKind, ts.Visibility
                            from [Microsoft.Uml2].[RedefinableTemplateSignatures] as ts left join
                                 [Microsoft.Uml2].[Classifiers] as c on c.Id = ts.Classifier left join
                                 [Microsoft.Uml2].[TemplateParameters] as tp on tp.Signature = ts.Id left join
                                 [Microsoft.Uml2].[Classes] as cl on cl.OwningTemplateParameter = tp.Id left join
                                 [Microsoft.Uml2].[Operations] as o on o.OwningTemplateParameter = tp.Id left join
                                 [Microsoft.Uml2].[Properties] as p on p.OwningTemplateParameter = tp.Id left join
                                 [Microsoft.Uml2].[Interfaces] as i on i.OwningTemplateParameter = tp.Id
                            join [Microsoft.Uml2].[UmlResources] ur on ur.Id = ts.ResourceId 
			    join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                            where ts.{0}
                            union all
                            select NULL as Name, 0 as IsLeaf,  
                                   ISNULL(c.Name, op.Name) as OwningClassifierName,
                                   tp.ElementKind as ParameterKind,
                                   ISNULL(cl.Name, ISNULL(o.Name, ISNULL(p.Name, i.Name))) as ParameterName,
                                   ts.ElementKind, NULL as Visibility
                            from [Microsoft.Uml2].[TemplateSignatures] as ts left join
                                 [Microsoft.Uml2].[Classifiers] as c on c.Id = ts.Template left join
                                 [Microsoft.Uml2].[Operations] as op on op.Id=ts.Template left join
                                 [Microsoft.Uml2].[TemplateParameters] as tp on tp.Signature = ts.Id left join
                                 [Microsoft.Uml2].[Classes] as cl on cl.OwningTemplateParameter = tp.Id left join
                                 [Microsoft.Uml2].[Operations] as o on o.OwningTemplateParameter = tp.Id left join
                                 [Microsoft.Uml2].[Properties] as p on p.OwningTemplateParameter = tp.Id left join
                                [Microsoft.Uml2].[Interfaces] as i on i.OwningTemplateParameter = tp.Id
                            join [Microsoft.Uml2].[UmlResources] ur on ur.Id = ts.ResourceId 
			    join [Microsoft.Uml2].[UmlResourceStems] us on ur.Stem = us.Id
                            where ts.ElementKind='TemplateSignature' and ts.{0} ) as results
                        order by Name, ParameterName, OwningClassifierName",
                        folderClause);
                });
        }
    }
}


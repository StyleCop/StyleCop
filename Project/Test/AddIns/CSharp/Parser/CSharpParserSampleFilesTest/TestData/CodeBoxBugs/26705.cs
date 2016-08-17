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
    }
}


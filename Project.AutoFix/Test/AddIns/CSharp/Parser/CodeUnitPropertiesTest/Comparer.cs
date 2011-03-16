//-----------------------------------------------------------------------
// <copyright file="Comparer.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StyleCop.CSharp.CodeModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeUnitPropertiesTest
{
    internal class Comparer
    {
        private delegate void TestHandler<T>(T c1, T c2);

        public void AreEqual(CodeUnit c1, CodeUnit c2)
        {
            if (TestForNull(c1, c2))
            {
                TestCodeUnit(c1, c2);

                AreEqual(c1.LinkNode.Next, c2.LinkNode.Next);
                AreEqual(c1.FindFirstChild<CodeUnit>(), c2.FindFirstChild<CodeUnit>());
            }
        }

        private void TestCodeUnit(CodeUnit c1, CodeUnit c2)
        {
            if (TestForNull(c1, c2))
            {
                Assert.AreEqual(c1.FundamentalType, c2.FundamentalType);
                Assert.AreEqual(c1.Children.Count, c2.Children.Count);
                TestProperty(c1.Parent, c2.Parent);
                TestProperty(c1.Location, c2.Location);
                TestProperty(c1.LineNumber, c2.LineNumber);
                TestProperty(c1.Document, c2.Document);

                switch (c1.CodeUnitType)
                {
                    case CodeUnitType.Argument:
                        TestArgument((Argument)c1, (Argument)c2);
                        break;
                    case CodeUnitType.ArgumentList:
                        TestArgumentList((ArgumentList)c1, (ArgumentList)c2);
                        break;
                    case CodeUnitType.Attribute:
                        TestAttribute((StyleCop.CSharp.CodeModel.Attribute)c1, (StyleCop.CSharp.CodeModel.Attribute)c2);
                        break;
                    case CodeUnitType.Element:
                        TestElement((Element)c1, (Element)c2);
                        break;
                    case CodeUnitType.Expression:
                        TestExpression((Expression)c1, (Expression)c2);
                        break;
                    case CodeUnitType.FileHeader:
                        TestFileHeader((FileHeader)c1, (FileHeader)c2);
                        break;
                    case CodeUnitType.LexicalElement:
                        TestLexicalElement((LexicalElement)c1, (LexicalElement)c2);
                        break;
                    case CodeUnitType.Parameter:
                        TestParameter((Parameter)c1, (Parameter)c2);
                        break;
                    case CodeUnitType.ParameterList:
                        TestParameterList((ParameterList)c1, (ParameterList)c2);
                        break;
                    case CodeUnitType.QueryClause:
                        TestQueryClause((QueryClause)c1, (QueryClause)c2);
                        break;
                    case CodeUnitType.Statement:
                        TestStatement((Statement)c1, (Statement)c2);
                        break;
                    case CodeUnitType.TypeParameterConstraintClause:
                        TestTypeParameterConstraintClause((TypeParameterConstraintClause)c1, (TypeParameterConstraintClause)c2);
                        break;
                    case CodeUnitType.ElementHeader:
                        TestXmlHeader((ElementHeader)c1, (ElementHeader)c2);
                        break;
                    case CodeUnitType.GenericTypeParameter:
                        TestGenericTypeParameter((GenericTypeParameter)c1, (GenericTypeParameter)c2);
                        break;
                    case CodeUnitType.GenericTypeParameterList:
                        TestGenericTypeParameterList((GenericTypeParameterList)c1, (GenericTypeParameterList)c2);
                        break;
                }
            }
        }

        private void TestArgument(Argument c1, Argument c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Expression, c2.Expression);
                this.TestProperty(c1.Modifiers, c2.Modifiers);
            }
        }

        private void TestArgumentList(ArgumentList c1, ArgumentList c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Arguments, c2.Arguments);
            }
        }

        private void TestAttribute(StyleCop.CSharp.CodeModel.Attribute c1, StyleCop.CSharp.CodeModel.Attribute c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.AttributeExpressions, c2.AttributeExpressions);
            }
        }

        private void TestElement(Element c1, Element c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.FullyQualifiedName, c2.FullyQualifiedName);
                this.TestProperty(c1.AccessModifierType, c2.AccessModifierType);
                this.TestProperty(c1.ActualAccessLevel, c2.ActualAccessLevel);
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.FriendlyTypeText, c2.FriendlyTypeText);
                this.TestProperty(c1.FriendlyPluralTypeText, c2.FriendlyPluralTypeText);
                this.TestProperty(c1.DeclaresAccessModifier, c2.DeclaresAccessModifier);
                this.TestProperty(c1.Attributes, c2.Attributes);
                this.TestProperty(c1.Unsafe, c2.Unsafe);
                this.TestProperty(c1.Name, c2.Name);
                this.TestProperty(c1.FirstDeclarationToken, c2.FirstDeclarationToken);
                this.TestProperty(c1.LastDeclarationToken, c2.LastDeclarationToken);
                this.TestProperty(c1.Header, c2.Header);

                if (c1 is ClassBase)
                {
                    this.TestClassBase((ClassBase)c1, (ClassBase)c2);
                }

                switch (c1.ElementType)
                {
                    case ElementType.Accessor:
                        TestAccessor((Accessor)c1, (Accessor)c2);
                        break;
                    case ElementType.Constructor:
                        TestConstructor((Constructor)c1, (Constructor)c2);
                        break;
                    case ElementType.Delegate:
                        TestDelegate((StyleCop.CSharp.CodeModel.Delegate)c1, (StyleCop.CSharp.CodeModel.Delegate)c2);
                        break;
                    case ElementType.Destructor:
                        TestDestructor((Destructor)c1, (Destructor)c2);
                        break;
                    case ElementType.Document:
                        TestDocument((CsDocument)c1, (CsDocument)c2);
                        break;
                    case ElementType.Enum:
                        TestEnum((StyleCop.CSharp.CodeModel.Enum)c1, (StyleCop.CSharp.CodeModel.Enum)c2);
                        break;
                    case ElementType.EnumItem:
                        TestEnumItem((EnumItem)c1, (EnumItem)c2);
                        break;
                    case ElementType.Event:
                        TestEvent((Event)c1, (Event)c2);
                        break;
                    case ElementType.ExternAliasDirective:
                        TestExternAliasDirective((ExternAliasDirective)c1, (ExternAliasDirective)c2);
                        break;
                    case ElementType.Field:
                        TestField((Field)c1, (Field)c2);
                        break;
                    case ElementType.Indexer:
                        TestIndexer((Indexer)c1, (Indexer)c2);
                        break;
                    case ElementType.Method:
                        TestMethod((Method)c1, (Method)c2);
                        break;
                    case ElementType.Property:
                        TestPropertyElement((Property)c1, (Property)c2);
                        break;
                    case ElementType.UsingDirective:
                        TestUsingDirective((UsingDirective)c1, (UsingDirective)c2);
                        break;
                }
            }
        }

        private void TestAccessor(Accessor c1, Accessor c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.ReturnType, c2.ReturnType);
            }
        }

        private void TestClassBase(ClassBase c1, ClassBase c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.ImplementedInterfaces, c2.ImplementedInterfaces);
                this.TestProperty(c1.BaseClass, c2.BaseClass);
                this.TestProperty(c1.TypeConstraints, c2.TypeConstraints);
            }
        }

        private void TestConstructor(Constructor c1, Constructor c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.FullyQualifiedName, c2.FullyQualifiedName);
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.Initializer, c2.Initializer);
                this.TestProperty((CodeUnit)c1.ParameterList, c2.ParameterList);
            }
        }

        private void TestDelegate(StyleCop.CSharp.CodeModel.Delegate c1, StyleCop.CSharp.CodeModel.Delegate c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.FullyQualifiedName, c2.FullyQualifiedName);
                this.TestProperty(c1.ReturnType, c2.ReturnType);
                this.TestProperty((CodeUnit)c1.ParameterList, c2.ParameterList);
                this.TestProperty(c1.TypeConstraints, c2.TypeConstraints);
            }
        }

        private void TestDestructor(Destructor c1, Destructor c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
            }
        }

        private void TestDocument(CsDocument c1, CsDocument c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.FileHeader, c2.FileHeader);
                this.TestProperty(c1.Path, c2.Path);
            }
        }

        private void TestEnum(StyleCop.CSharp.CodeModel.Enum c1, StyleCop.CSharp.CodeModel.Enum c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.BaseType, c2.BaseType);
                this.TestProperty(c1.Items, c2.Items);
            }
        }

        private void TestEnumItem(EnumItem c1, EnumItem c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Initialization, c2.Initialization);
            }
        }

        private void TestEvent(Event c1, Event c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.EventHandlerType, c2.EventHandlerType);
                this.TestProperty(c1.Declarators, c2.Declarators);
                this.TestProperty(c1.AddAccessor, c2.AddAccessor);
                this.TestProperty(c1.RemoveAccessor, c2.RemoveAccessor);
            }
        }

        private void TestExternAliasDirective(ExternAliasDirective c1, ExternAliasDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Identifier, c2.Identifier);
            }
        }

        private void TestField(Field c1, Field c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Const, c2.Const);
                this.TestProperty(c1.Readonly, c2.Readonly);
                this.TestProperty(c1.FieldType, c2.FieldType);
                this.TestProperty(c1.VariableDeclarationStatement, c2.VariableDeclarationStatement);
            }
        }

        private void TestIndexer(Indexer c1, Indexer c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.FullyQualifiedName, c2.FullyQualifiedName);
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.ReturnType, c2.ReturnType);
                this.TestProperty((CodeUnit)c1.ParameterList, c2.ParameterList);
                this.TestProperty(c1.GetAccessor, c2.GetAccessor);
                this.TestProperty(c1.SetAccessor, c2.SetAccessor);
            }
        }

        private void TestMethod(Method c1, Method c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.ReturnType, c2.ReturnType);
                this.TestProperty((CodeUnit)c1.ParameterList, c2.ParameterList);
                this.TestProperty(c1.TypeConstraints, c2.TypeConstraints);
                this.TestProperty(c1.IsExtensionMethod, c2.IsExtensionMethod);
            }
        }

        private void TestPropertyElement(Property c1, Property c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.ReturnType, c2.ReturnType);
                this.TestProperty(c1.GetAccessor, c2.GetAccessor);
                this.TestProperty(c1.SetAccessor, c2.SetAccessor);
            }
        }

        private void TestUsingDirective(UsingDirective c1, UsingDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Alias, c2.Alias);
                this.TestProperty(c1.NamespaceType, c2.NamespaceType);

            }
        }

        private void TestExpression(Expression c1, Expression c2)
        {
            if (TestForNull(c1, c2))
            {
                if (c1 is ExpressionWithParameters)
                {
                    TestExpressionWithParameters((ExpressionWithParameters)c1, (ExpressionWithParameters)c2);
                }

                switch (c1.ExpressionType)
                {
                    case ExpressionType.Arithmetic:
                        TestArithmeticExpression((ArithmeticExpression)c1, (ArithmeticExpression)c2);
                        break;
                    case ExpressionType.ArrayAccess:
                        TestArrayAccessExpression((ArrayAccessExpression)c1, (ArrayAccessExpression)c2);
                        break;
                    case ExpressionType.ArrayInitializer:
                        TestArrayInitializer((ArrayInitializerExpression)c1, (ArrayInitializerExpression)c2);
                        break;
                    case ExpressionType.As:
                        TestAsExpression((AsExpression)c1, (AsExpression)c2);
                        break;
                    case ExpressionType.Assignment:
                        TestAssignmentExpression((AssignmentExpression)c1, (AssignmentExpression)c2);
                        break;
                    case ExpressionType.Attribute:
                        TestAttributeExpression((AttributeExpression)c1, (AttributeExpression)c2);
                        break;
                    case ExpressionType.Cast:
                        TestCastExpression((CastExpression)c1, (CastExpression)c2);
                        break;
                    case ExpressionType.Checked:
                        TestCheckedExpression((CheckedExpression)c1, (CheckedExpression)c2);
                        break;
                    case ExpressionType.CollectionInitializer:
                        TestCollectionInitializerExpression((CollectionInitializerExpression)c1, (CollectionInitializerExpression)c2);
                        break;
                    case ExpressionType.Conditional:
                        TestConditionalExpression((ConditionalExpression)c1, (ConditionalExpression)c2);
                        break;
                    case ExpressionType.ConditionalLogical:
                        TestConditionalLogicalExpression((ConditionalLogicalExpression)c1, (ConditionalLogicalExpression)c2);
                        break;
                    case ExpressionType.Decrement:
                        TestDecrementExpression((DecrementExpression)c1, (DecrementExpression)c2);
                        break;
                    case ExpressionType.DefaultValue:
                        TestDefaultValueExpression((DefaultValueExpression)c1, (DefaultValueExpression)c2);
                        break;
                    case ExpressionType.EventDeclarator:
                        TestEventDeclaratorExpression((EventDeclaratorExpression)c1, (EventDeclaratorExpression)c2);
                        break;
                    case ExpressionType.Increment:
                        TestIncrementExpression((IncrementExpression)c1, (IncrementExpression)c2);
                        break;
                    case ExpressionType.Is:
                        TestIsExpression((IsExpression)c1, (IsExpression)c2);
                        break;
                    case ExpressionType.Lambda:
                        TestLambdaExpression((LambdaExpression)c1, (LambdaExpression)c2);
                        break;
                    case ExpressionType.Literal:
                        TestLiteralExpression((LiteralExpression)c1, (LiteralExpression)c2);
                        break;
                    case ExpressionType.Logical:
                        TestLogicalExpression((LogicalExpression)c1, (LogicalExpression)c2);
                        break;
                    case ExpressionType.MemberAccess:
                    case ExpressionType.PointerAccess:
                    case ExpressionType.QualifiedAlias:
                        TestChildAccessExpression((ChildAccessExpression)c1, (ChildAccessExpression)c2);
                        break;
                    case ExpressionType.MethodInvocation:
                        TestMethodInvocationExpression((MethodInvocationExpression)c1, (MethodInvocationExpression)c2);
                        break;
                    case ExpressionType.New:
                        TestNewExpression((NewExpression)c1, (NewExpression)c2);
                        break;
                    case ExpressionType.NewArray:
                        TestNewArrayExpression((NewArrayExpression)c1, (NewArrayExpression)c2);
                        break;
                    case ExpressionType.NullCoalescing:
                        TestNullCoalescingExpression((NullCoalescingExpression)c1, (NullCoalescingExpression)c2);
                        break;
                    case ExpressionType.ObjectInitializer:
                        TestObjectInitializerExpression((ObjectInitializerExpression)c1, (ObjectInitializerExpression)c2);
                        break;
                    case ExpressionType.Parenthesized:
                        TestParenthesizedExpression((ParenthesizedExpression)c1, (ParenthesizedExpression)c2);
                        break;
                    case ExpressionType.Query:
                        TestQueryExpression((QueryExpression)c1, (QueryExpression)c2);
                        break;
                    case ExpressionType.Relational:
                        TestRelationalExpression((RelationalExpression)c1, (RelationalExpression)c2);
                        break;
                    case ExpressionType.Sizeof:
                        TestSizeofExpression((SizeofExpression)c1, (SizeofExpression)c2);
                        break;
                    case ExpressionType.Stackalloc:
                        TestStackallocExpression((StackallocExpression)c1, (StackallocExpression)c2);
                        break;
                    case ExpressionType.Typeof:
                        TestTypeofExpression((TypeofExpression)c1, (TypeofExpression)c2);
                        break;
                    case ExpressionType.Unary:
                        TestUnaryExpression((UnaryExpression)c1, (UnaryExpression)c2);
                        break;
                    case ExpressionType.Unchecked:
                        TestUncheckedExpression((UncheckedExpression)c1, (UncheckedExpression)c2);
                        break;
                    case ExpressionType.UnsafeAccess:
                        TestUnsafeAccessExpression((UnsafeAccessExpression)c1, (UnsafeAccessExpression)c2);
                        break;
                    case ExpressionType.VariableDeclaration:
                        TestVariableDeclarationExpression((VariableDeclarationExpression)c1, (VariableDeclarationExpression)c2);
                        break;
                    case ExpressionType.VariableDeclarator:
                        TestVariableDeclaratorExpression((VariableDeclaratorExpression)c1, (VariableDeclaratorExpression)c2);
                        break;
                }
            }
        }

        private void TestExpressionWithParameters(ExpressionWithParameters c1, ExpressionWithParameters c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty((CodeUnit)c1.ParameterList, c2.ParameterList);
                this.TestProperty(c1.Variables, c2.Variables);
            }
        }

        private void TestArithmeticExpression(ArithmeticExpression c1, ArithmeticExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.ArithmeticExpressionType, c2.ArithmeticExpressionType);
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestArrayAccessExpression(ArrayAccessExpression c1, ArrayAccessExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Array, c2.Array);
                this.TestProperty(c1.Arguments, c2.Arguments);
            }
        }

        private void TestArrayInitializer(ArrayInitializerExpression c1, ArrayInitializerExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Initializers, c2.Initializers);
            }
        }

        private void TestAsExpression(AsExpression c1, AsExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Value, c2.Value);
                this.TestProperty(c1.Type, c2.Type);
            }
        }

        private void TestAssignmentExpression(AssignmentExpression c1, AssignmentExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.AssignmentExpressionType, c2.AssignmentExpressionType);
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestAttributeExpression(AttributeExpression c1, AttributeExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Target, c2.Target);
                this.TestProperty(c1.Initialization, c2.Initialization);
                this.TestProperty(c1.IsAssemblyAttribute, c2.IsAssemblyAttribute);
            }
        }

        private void TestCastExpression(CastExpression c1, CastExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
                this.TestProperty(c1.CastedExpression, c2.CastedExpression);
            }
        }

        private void TestCheckedExpression(CheckedExpression c1, CheckedExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.InternalExpression, c2.InternalExpression);
            }
        }

        private void TestCollectionInitializerExpression(CollectionInitializerExpression c1, CollectionInitializerExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Initializers, c2.Initializers);
            }
        }

        private void TestConditionalExpression(ConditionalExpression c1, ConditionalExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Condition, c2.Condition);
                this.TestProperty(c1.TrueExpression, c2.TrueExpression);
                this.TestProperty(c1.FalseExpression, c2.FalseExpression);
            }
        }

        private void TestConditionalLogicalExpression(ConditionalLogicalExpression c1, ConditionalLogicalExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.ConditionalLogicalExpressionType, c2.ConditionalLogicalExpressionType);
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestDecrementExpression(DecrementExpression c1, DecrementExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.DecrementExpressionType, c2.DecrementExpressionType);
                this.TestProperty(c1.Value, c2.Value);
            }
        }

        private void TestDefaultValueExpression(DefaultValueExpression c1, DefaultValueExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
            }
        }

        private void TestEventDeclaratorExpression(EventDeclaratorExpression c1, EventDeclaratorExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Identifier, c2.Identifier);
                this.TestProperty(c1.Initializer, c2.Initializer);
            }
        }

        private void TestIncrementExpression(IncrementExpression c1, IncrementExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.IncrementExpressionType, c2.IncrementExpressionType);
                this.TestProperty(c1.Value, c2.Value);
            }
        }

        private void TestIsExpression(IsExpression c1, IsExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Value, c2.Value);
                this.TestProperty(c1.Type, c2.Type);
            }
        }

        private void TestLambdaExpression(LambdaExpression c1, LambdaExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.AnonymousFunctionBody, c2.AnonymousFunctionBody);
            }
        }

        private void TestLiteralExpression(LiteralExpression c1, LiteralExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Token, c2.Token);
                this.TestProperty(c1.Text, c2.Text);
            }
        }

        private void TestLogicalExpression(LogicalExpression c1, LogicalExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.LogicalExpressionType, c2.LogicalExpressionType);
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestChildAccessExpression(ChildAccessExpression c1, ChildAccessExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestMethodInvocationExpression(MethodInvocationExpression c1, MethodInvocationExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Name, c2.Name);
                this.TestProperty((CodeUnit)c1.ArgumentList, c2.ArgumentList);
            }
        }

        private void TestNewExpression(NewExpression c1, NewExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.TypeCreationExpression, c2.TypeCreationExpression);
                this.TestProperty(c1.InitializerExpression, c2.InitializerExpression);
            }
        }

        private void TestNewArrayExpression(NewArrayExpression c1, NewArrayExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
                this.TestProperty(c1.Initializer, c2.Initializer);
            }
        }

        private void TestNullCoalescingExpression(NullCoalescingExpression c1, NullCoalescingExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestObjectInitializerExpression(ObjectInitializerExpression c1, ObjectInitializerExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Initializers, c2.Initializers);
            }
        }

        private void TestParenthesizedExpression(ParenthesizedExpression c1, ParenthesizedExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.InnerExpression, c2.InnerExpression);
            }
        }

        private void TestQueryExpression(QueryExpression c1, QueryExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.QueryClauses, c2.QueryClauses);
            }
        }

        private void TestRelationalExpression(RelationalExpression c1, RelationalExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.RelationalExpressionType, c2.RelationalExpressionType);
                this.TestProperty(c1.LeftHandSide, c2.LeftHandSide);
                this.TestProperty(c1.RightHandSide, c2.RightHandSide);
            }
        }

        private void TestSizeofExpression(SizeofExpression c1, SizeofExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
            }
        }

        private void TestStackallocExpression(StackallocExpression c1, StackallocExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
            }
        }

        private void TestTypeofExpression(TypeofExpression c1, TypeofExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
            }
        }

        private void TestUnaryExpression(UnaryExpression c1, UnaryExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.UnaryExpressionType, c2.UnaryExpressionType);
                this.TestProperty(c1.Value, c2.Value);
            }

        }

        private void TestUncheckedExpression(UncheckedExpression c1, UncheckedExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.InternalExpression, c2.InternalExpression);
            }
        }

        private void TestUnsafeAccessExpression(UnsafeAccessExpression c1, UnsafeAccessExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.UnsafeAccessExpressionType, c2.UnsafeAccessExpressionType);
                this.TestProperty(c1.Value, c2.Value);
            }
        }

        private void TestVariableDeclarationExpression(VariableDeclarationExpression c1, VariableDeclarationExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
                this.TestProperty((IEnumerable<CodeUnit>)c1.Declarators, (IEnumerable<CodeUnit>)c2.Declarators);
                this.TestProperty(c1.Variables, c2.Variables);
            }
        }

        private void TestVariableDeclaratorExpression(VariableDeclaratorExpression c1, VariableDeclaratorExpression c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Identifier, c2.Identifier);
                this.TestProperty(c1.Initializer, c2.Initializer);
            }
        }


        private void TestFileHeader(FileHeader c1, FileHeader c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.HeaderLines, c2.HeaderLines);
                this.TestProperty(c1.IsEmpty, c2.IsEmpty);
                this.TestProperty(c1.HeaderXml, c2.HeaderXml);
                this.TestProperty(c1.FormattedHeaderXml, c2.FormattedHeaderXml);
            }
        }

        private void TestLexicalElement(LexicalElement c1, LexicalElement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Text, c2.Text);

                if (c1 is SimpleLexicalElement)
                {
                    TestSimpleLexicalElement((SimpleLexicalElement)c1, (SimpleLexicalElement)c2);
                }

                switch (c1.LexicalElementType)
                {
                    case LexicalElementType.Comment:
                        TestComment((Comment)c1, (Comment)c2);
                        break;
                    case LexicalElementType.EndOfLine:
                        TestEndOfLine((EndOfLine)c1, (EndOfLine)c2);
                        break;
                    case LexicalElementType.PreprocessorDirective:
                        TestPreprocessorDirective((PreprocessorDirective)c1, (PreprocessorDirective)c2);
                        break;
                    case LexicalElementType.Token:
                        TestToken((Token)c1, (Token)c2);
                        break;
                    case LexicalElementType.WhiteSpace:
                        TestWhitespace((Whitespace)c1, (Whitespace)c2);
                        break;
                }
            }
        }

        private void TestSimpleLexicalElement(SimpleLexicalElement c1, SimpleLexicalElement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Location, c2.Location);
                this.TestProperty(c1.LineNumber, c2.LineNumber);
                this.TestProperty(c1.Generated, c2.Generated);
            }
        }

        private void TestComment(Comment c1, Comment c2)
        {
            if (TestForNull(c1, c2))
            {
            }
        }

        private void TestEndOfLine(EndOfLine c1, EndOfLine c2)
        {
            if (TestForNull(c1, c2))
            {
            }
        }

        private void TestPreprocessorDirective(PreprocessorDirective c1, PreprocessorDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                if (c1 is SimplePreprocessorDirective)
                {
                    TestSimplePreprocessorDirective((SimplePreprocessorDirective)c1, (SimplePreprocessorDirective)c2);
                }
                else if (c1 is ConditionalCompilationDirective)
                {
                    TestConditionalCompiliationDirective((ConditionalCompilationDirective)c1, (ConditionalCompilationDirective)c2);
                }

                if (c1 is RegionDirective)
                {
                    TestRegionDirective((RegionDirective)c1, (RegionDirective)c2);
                }
                else if (c1 is EndRegionDirective)
                {
                    TestEndRegionDirective((EndRegionDirective)c1, (EndRegionDirective)c2);
                }
            }
        }

        private void TestSimplePreprocessorDirective(SimplePreprocessorDirective c1, SimplePreprocessorDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Location, c2.Location);
                this.TestProperty(c1.LineNumber, c2.LineNumber);
                this.TestProperty(c1.Generated, c2.Generated);

            }
        }

        private void TestConditionalCompiliationDirective(ConditionalCompilationDirective c1, ConditionalCompilationDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestRegionDirective(RegionDirective c1, RegionDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Partner, c2.Partner);
                this.TestProperty(c1.IsGeneratedCodeRegion, c2.IsGeneratedCodeRegion);
            }
        }

        private void TestEndRegionDirective(EndRegionDirective c1, EndRegionDirective c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Partner, c2.Partner);
            }
        }

        private void TestToken(Token c1, Token c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.IsComplexToken, c2.IsComplexToken);

                if (c1 is OperatorSymbolToken)
                {
                    TestOperatorSymbolToken((OperatorSymbolToken)c1, (OperatorSymbolToken)c2);
                }

                if (c1 is SimpleToken)
                {
                    TestSimpleToken((SimpleToken)c1, (SimpleToken)c2);
                }

                if (c1 is GenericTypeToken)
                {
                    TestGenericTypeToken((GenericTypeToken)c1, (GenericTypeToken)c2);
                }

                if (c1 is BracketToken)
                {
                    TestBracketToken((BracketToken)c1, (BracketToken)c2);
                }
            }
        }

        private void TestBracketToken(BracketToken c1, BracketToken c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.MatchingBracket, c2.MatchingBracket);
            }
        }

        private void TestOperatorSymbolToken(OperatorSymbolToken c1, OperatorSymbolToken c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Category, c2.Category);
            }
        }

        private void TestSimpleToken(SimpleToken c1, SimpleToken c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.Location, c1.Location);
                TestProperty(c1.Generated, c2.Generated);
                TestProperty(c1.LineNumber, c2.LineNumber);
            }
        }

        private void TestWhitespace(Whitespace c1, Whitespace c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.TabCount, c2.TabCount);
                this.TestProperty(c1.SpaceCount, c2.SpaceCount);
            }
        }

        private void TestGenericTypeToken(GenericTypeToken c1, GenericTypeToken c2)
        {
            this.TestProperty(c1.GenericTypes, c2.GenericTypes);
        }

        private void TestParameter(Parameter c1, Parameter c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Name, c2.Name);
                this.TestProperty(c1.NameToken, c2.NameToken);
                this.TestProperty(c1.ParameterType, c2.ParameterType);
                this.TestProperty(c1.ParameterTypeToken, c2.ParameterTypeToken);
                this.TestProperty(c1.Modifiers, c2.Modifiers);
            }
        }

        private void TestParameterList(ParameterList c1, ParameterList c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty((IEnumerable<ParameterList>)c1.Parameters, (IEnumerable<ParameterList>)c2.Parameters);
            }
        }

        private void TestGenericTypeParameter(GenericTypeParameter c1, GenericTypeParameter c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
                this.TestProperty(c1.Modifiers, c2.Modifiers);
            }
        }

        private void TestGenericTypeParameterList(GenericTypeParameterList c1, GenericTypeParameterList c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Parameters, c2.Parameters);
            }
        }

        private void TestQueryClause(QueryClause c1, QueryClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);

                switch (c1.QueryClauseType)
                {
                    case QueryClauseType.Continuation:
                        TestQueryContinuationClause((QueryContinuationClause)c1, (QueryContinuationClause)c2);
                        break;
                    case QueryClauseType.From:
                        TestQueryFromClause((QueryFromClause)c1, (QueryFromClause)c2);
                        break;
                    case QueryClauseType.Group:
                        TestQueryGroupClause((QueryGroupClause)c1, (QueryGroupClause)c2);
                        break;
                    case QueryClauseType.Join:
                        TestQueryJoinClause((QueryJoinClause)c1, (QueryJoinClause)c2);
                        break;
                    case QueryClauseType.Let:
                        TestQueryLetClause((QueryLetClause)c1, (QueryLetClause)c2);
                        break;
                    case QueryClauseType.OrderBy:
                        TestQueryOrderByClause((QueryOrderByClause)c1, (QueryOrderByClause)c2);
                        break;
                    case QueryClauseType.Select:
                        TestQuerySelectClause((QuerySelectClause)c1, (QuerySelectClause)c2);
                        break;
                    case QueryClauseType.Where:
                        TestQueryWhereClause((QueryWhereClause)c1, (QueryWhereClause)c2);
                        break;
                }
            }
        }

        private void TestQueryContinuationClause(QueryContinuationClause c1, QueryContinuationClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.Variable, c2.Variable);
                this.TestProperty(c1.ChildClauses, c2.ChildClauses);
            }
        }

        private void TestQueryFromClause(QueryFromClause c1, QueryFromClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.Expression, c2.Expression);
                this.TestProperty(c1.RangeVariable, c2.RangeVariable);
            }
        }

        private void TestQueryGroupClause(QueryGroupClause c1, QueryGroupClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.GroupByExpression, c2.GroupByExpression);
                this.TestProperty(c1.Expression, c2.Expression);
            }
        }

        private void TestQueryJoinClause(QueryJoinClause c1, QueryJoinClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.InExpression, c2.InExpression);
                this.TestProperty(c1.OnKeyExpression, c2.OnKeyExpression);
                this.TestProperty(c1.EqualsKeyExpression, c2.EqualsKeyExpression);
                this.TestProperty(c1.IntoVariable, c2.IntoVariable);
                this.TestProperty(c1.RangeVariable, c2.RangeVariable);
            }
        }

        private void TestQueryLetClause(QueryLetClause c1, QueryLetClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.Expression, c2.Expression);
                this.TestProperty(c1.RangeVariable, c2.RangeVariable);
            }
        }

        private void TestQueryOrderByClause(QueryOrderByClause c1, QueryOrderByClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Orderings, c2.Orderings);
            }
        }

        private void TestQueryOrderByOrdering(QueryOrderByOrdering o1, QueryOrderByOrdering o2)
        {
            this.TestProperty(o1.Direction, o2.Direction);
            this.TestProperty(o1.Expression, o2.Expression);
        }

        private void TestQuerySelectClause(QuerySelectClause c1, QuerySelectClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Expression, c2.Expression);
            }
        }

        private void TestQueryWhereClause(QueryWhereClause c1, QueryWhereClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Expression, c2.Expression);
            }
        }

        private void TestStatement(Statement c1, Statement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.AttachedStatements, c2.AttachedStatements);
                this.TestProperty(c1.Variables, c2.Variables);

                switch (c1.StatementType)
                {
                    case StatementType.Block:
                        TestBlockStatement((BlockStatement)c1, (BlockStatement)c2);
                        break;
                    case StatementType.Catch:
                        TestCatchStatement((CatchStatement)c1, (CatchStatement)c2);
                        break;
                    case StatementType.Checked:
                        TestCheckedStatement((CheckedStatement)c1, (CheckedStatement)c2);
                        break;
                    case StatementType.ConstructorInitializer:
                        TestConstructorInitializerStatement((ConstructorInitializerStatement)c1, (ConstructorInitializerStatement)c2);
                        break;
                    case StatementType.DoWhile:
                        TestDoWhileStatement((DoWhileStatement)c1, (DoWhileStatement)c2);
                        break;
                    case StatementType.Else:
                        TestElseStatement((ElseStatement)c1, (ElseStatement)c2);
                        break;
                    case StatementType.Expression:
                        TestExpressionStatement((ExpressionStatement)c1, (ExpressionStatement)c2);
                        break;
                    case StatementType.Finally:
                        TestFinallyStatement((FinallyStatement)c1, (FinallyStatement)c2);
                        break;
                    case StatementType.Fixed:
                        TestFixedStatement((FixedStatement)c1, (FixedStatement)c2);
                        break;
                    case StatementType.For:
                        TestForStatement((ForStatement)c1, (ForStatement)c2);
                        break;
                    case StatementType.Foreach:
                        TestForeachStatement((ForeachStatement)c1, (ForeachStatement)c2);
                        break;
                    case StatementType.Goto:
                        TestGotoStatement((GotoStatement)c1, (GotoStatement)c2);
                        break;
                    case StatementType.If:
                        TestIfStatement((IfStatement)c1, (IfStatement)c2);
                        break;
                    case StatementType.Label:
                        TestLabelStatement((LabelStatement)c1, (LabelStatement)c2);
                        break;
                    case StatementType.Lock:
                        TestLockStatement((LockStatement)c1, (LockStatement)c2);
                        break;
                    case StatementType.Return:
                        TestReturnStatement((ReturnStatement)c1, (ReturnStatement)c2);
                        break;
                    case StatementType.Switch:
                        TestSwitchStatement((SwitchStatement)c1, (SwitchStatement)c2);
                        break;
                    case StatementType.SwitchCase:
                        TestSwitchCaseStatement((SwitchCaseStatement)c1, (SwitchCaseStatement)c2);
                        break;
                    case StatementType.Throw:
                        TestThrowStatement((ThrowStatement)c1, (ThrowStatement)c2);
                        break;
                    case StatementType.Try:
                        TestTryStatement((TryStatement)c1, (TryStatement)c2);
                        break;
                    case StatementType.Unchecked:
                        TestUncheckedStatement((UncheckedStatement)c1, (UncheckedStatement)c2);
                        break;
                    case StatementType.Unsafe:
                        TestUnsafeStatement((UnsafeStatement)c1, (UnsafeStatement)c2);
                        break;
                    case StatementType.Using:
                        TestUsingStatement((UsingStatement)c1, (UsingStatement)c2);
                        break;
                    case StatementType.VariableDeclaration:
                        TestVariableDeclarationStatement((VariableDeclarationStatement)c1, (VariableDeclarationStatement)c2);
                        break;
                    case StatementType.While:
                        TestWhileStatement((WhileStatement)c1, (WhileStatement)c2);
                        break;
                    case StatementType.Yield:
                        TestYieldStatement((YieldStatement)c1, (YieldStatement)c2);
                        break;
                }
            }
        }

        private void TestBlockStatement(BlockStatement c1, BlockStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
            }
        }

        private void TestCatchStatement(CatchStatement c1, CatchStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.TryStatement, c2.TryStatement);
                this.TestProperty(c1.ExceptionType, c2.ExceptionType);
                this.TestProperty(c1.Identifier, c2.Identifier);
                this.TestProperty(c1.CatchExpression, c2.CatchExpression);
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestCheckedStatement(CheckedStatement c1, CheckedStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestConstructorInitializerStatement(ConstructorInitializerStatement c1, ConstructorInitializerStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Expression, c2.Expression);
            }
        }

        private void TestDoWhileStatement(DoWhileStatement c1, DoWhileStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.Condition, c2.Condition);
                TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestElseStatement(ElseStatement c1, ElseStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Condition, c2.Condition);
                this.TestProperty(c1.Body, c2.Body);
                this.TestProperty(c1.AttachedElseStatement, c2.AttachedElseStatement);
            }
        }

        private void TestEmptyStatement(EmptyStatement c1, EmptyStatement c2)
        {
            if (TestForNull(c1, c2))
            {
            }
        }

        private void TestExpressionStatement(ExpressionStatement c1, ExpressionStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Expression, c2.Expression);
            }
        }

        private void TestFinallyStatement(FinallyStatement c1, FinallyStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.TryStatement, c2.TryStatement);
                this.TestProperty(c1.Body, c2.Body);

            }
        }

        private void TestFixedStatement(FixedStatement c1, FixedStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.FixedVariable, c2.FixedVariable);
                this.TestProperty(c1.Body, c2.Body);

            }
        }

        private void TestForStatement(ForStatement c1, ForStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.Initializers, c2.Initializers);
                this.TestProperty(c1.Condition, c2.Condition);
                this.TestProperty(c1.Iterators, c2.Iterators);
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestForeachStatement(ForeachStatement c1, ForeachStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Variables, c2.Variables);
                this.TestProperty(c1.IterationVariable, c2.IterationVariable);
                this.TestProperty(c1.Collection, c2.Collection);
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestGotoStatement(GotoStatement c1, GotoStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Identifier, c2.Identifier);
            }
        }

        private void TestIfStatement(IfStatement c1, IfStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Condition, c2.Condition);
                this.TestProperty(c1.Body, c2.Body);
                this.TestProperty(c1.AttachedElseStatement, c2.AttachedElseStatement);
            }
        }

        private void TestLabelStatement(LabelStatement c1, LabelStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Identifier, c2.Identifier);
            }
        }

        private void TestLockStatement(LockStatement c1, LockStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.LockObject, c2.LockObject);
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestReturnStatement(ReturnStatement c1, ReturnStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.ReturnValue, c2.ReturnValue);
            }
        }

        private void TestSwitchStatement(SwitchStatement c1, SwitchStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.SwitchExpression, c2.SwitchExpression);
                TestProperty(c1.CaseStatements, c2.CaseStatements);
                TestProperty(c1.DefaultStatement, c2.DefaultStatement);
            }
        }

        private void TestSwitchCaseStatement(SwitchCaseStatement c1, SwitchCaseStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.Identifier, c2.Identifier);

            }
        }

        private void TestSwitchDefaultStatement(SwitchDefaultStatement c1, SwitchDefaultStatement c2)
        {
            if (TestForNull(c1, c2))
            {
            }
        }

        private void TestThrowStatement(ThrowStatement c1, ThrowStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.ThrownExpression, c2.ThrownExpression);
            }
        }

        private void TestTryStatement(TryStatement c1, TryStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Body, c2.Body);
                this.TestProperty(c1.FinallyStatement, c2.FinallyStatement);
                this.TestProperty(c1.CatchStatements, c2.CatchStatements);
            }
        }

        private void TestUncheckedStatement(UncheckedStatement c1, UncheckedStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestUnsafeStatement(UnsafeStatement c1, UnsafeStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Body, c2.Body);
            }
        }

        private void TestUsingStatement(UsingStatement c1, UsingStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.Resource, c2.Resource);
                TestProperty(c1.Body, c2.Body);
                TestProperty(c1.Variables, c2.Variables);
            }
        }

        private void TestVariableDeclarationStatement(VariableDeclarationStatement c1, VariableDeclarationStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.Variables, c2.Variables);
                TestProperty(c1.Constant, c2.Constant);
                TestProperty(c1.InnerExpression, c2.InnerExpression);
                TestProperty(c1.Type, c2.Type);
                TestProperty((IEnumerable<CodeUnit>)c1.Declarators, c2.Declarators);
            }
        }

        private void TestWhileStatement(WhileStatement c1, WhileStatement c2)
        {
            if (TestForNull(c1, c2))
            {
            }
        }

        private void TestYieldStatement(YieldStatement c1, YieldStatement c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.YieldType, c2.YieldType);
                this.TestProperty(c1.ReturnValue, c2.ReturnValue);
            }
        }

        private void TestTypeParameterConstraintClause(TypeParameterConstraintClause c1, TypeParameterConstraintClause c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.Type, c2.Type);
                this.TestProperty(c1.Constraints, c2.Constraints);
            }
        }

        private void TestXmlHeader(ElementHeader c1, ElementHeader c2)
        {
            if (TestForNull(c1, c2))
            {
                this.TestProperty(c1.HeaderLines, c2.HeaderLines);
                this.TestProperty(c1.IsEmpty, c2.IsEmpty);
                this.TestProperty(c1.HeaderXml, c2.HeaderXml);
                this.TestProperty(c1.HeaderXmlWithNewlines, c2.HeaderXmlWithNewlines);
            }
        }

        private void TestProperty(CodeLocation c1, CodeLocation c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.StartPoint.Index, c2.StartPoint.Index);
                TestProperty(c1.StartPoint.IndexOnLine, c2.StartPoint.IndexOnLine);
                TestProperty(c1.StartPoint.LineNumber, c2.StartPoint.LineNumber);
                TestProperty(c1.EndPoint.Index, c2.EndPoint.Index);
                TestProperty(c1.EndPoint.IndexOnLine, c2.EndPoint.IndexOnLine);
                TestProperty(c1.EndPoint.LineNumber, c2.EndPoint.LineNumber);
                TestProperty(c1.LineNumber, c2.LineNumber);
                TestProperty(c1.LineSpan, c2.LineSpan);
            }
        }

        private void TestProperty(IVariable v1, IVariable v2)
        {
            if (TestForNull(v1, v2))
            {
                TestProperty(v1.VariableName, v2.VariableName);
                TestProperty(v1.VariableType, v2.VariableType);
                Assert.AreEqual(v1.VariableModifiers, v2.VariableModifiers);
                TestProperty(v1.Location, v2.Location);
                TestProperty(v1.Generated, v2.Generated);
            }
        }

        private void TestProperty(System.Enum e1, System.Enum e2)
        {
            Assert.AreEqual(e1, e2);
        }

        private void TestProperty(CodeUnit c1, CodeUnit c2)
        {
            if (TestForNull(c1, c2))
            {
                TestProperty(c1.ToString(), c2.ToString());
            }
        }

        private void TestProperty(IEnumerable<string> s1, IEnumerable<string> s2)
        {
            this.TestCollection<string>(s1, s2, this.TestProperty);
        }

        private void TestProperty(IEnumerable<IVariable> v1, IEnumerable<IVariable> v2)
        {
            this.TestCollection<IVariable>(v1, v2, this.TestProperty);
        }

        private void TestProperty(IEnumerable<QueryOrderByOrdering> c1, IEnumerable<QueryOrderByOrdering> c2)
        {
            this.TestCollection<QueryOrderByOrdering>(c1, c2, this.TestQueryOrderByOrdering);
        }

        private void TestProperty(IEnumerable<CodeUnit> c1, IEnumerable<CodeUnit> c2)
        {
            this.TestCollection<CodeUnit>(c1, c2, this.TestProperty);
        }

        private void TestCollection<T>(IEnumerable<T> c1, IEnumerable<T> c2, TestHandler<T> test)
        {
            // CodeUnit collection properties should never be null.
            Assert.IsNotNull(c1);
            Assert.IsNotNull(c2);

            List<T> list1 = new List<T>(c1);
            List<T> list2 = new List<T>(c2);
            Assert.AreEqual(list1.Count, list2.Count);
            for (int i = 0; i < list1.Count; ++i)
            {
                test(list1[i], list2[i]);
            }
        }

        private bool TestForNull(object c1, object c2)
        {
            if (c1 == null || c2 == null)
            {
                Assert.AreEqual(c1, c2);
                return false;
            }

            return true;
        }

        private void TestProperty(string s1, string s2)
        {
            Assert.AreEqual(s1, s2);
        }

        private void TestProperty(bool b1, bool b2)
        {
            Assert.AreEqual(b1, b2);
        }

        private void TestProperty(int i1, int i2)
        {
            Assert.AreEqual(i1, i2);
        }
    }
}

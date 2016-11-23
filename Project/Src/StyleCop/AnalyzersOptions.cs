// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalyzersOptions.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Options dialog to choose which analyzers to run for the solution.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Options dialog to choose which analyzers to run for the solution.
    /// </summary>
    internal class AnalyzersOptions : UserControl, IPropertyControlPage
    {
        #region Constants

        /// <summary>
        /// The name of an analyzer node.
        /// </summary>
        private const string AnalyzerNode = "AnalyzerNode";

        /// <summary>
        /// The name of a parser node.
        /// </summary>
        private const string ParserNode = "ParserNode";

        /// <summary>
        /// The name of a rule group node.
        /// </summary>
        private const string RuleGroupNode = "RuleGroupNode";

        /// <summary>
        /// The name of a rule node.
        /// </summary>
        private const string RuleNode = "RuleNode";

        #endregion

        #region Fields

        /// <summary>
        /// Stores the properties for each analyzer and parser.
        /// </summary>
        private readonly Dictionary<StyleCopAddIn, ICollection<BooleanProperty>> properties = new Dictionary<StyleCopAddIn, ICollection<BooleanProperty>>();

        /// <summary>
        /// The enabled analyzers tree.
        /// </summary>
        private TreeView analyzeTree;

        /// <summary>
        /// The components container for the control.
        /// </summary>
        private IContainer components;

        /// <summary>
        /// The description text box.
        /// </summary>
        private TextBox description;

        /// <summary>
        /// The details tree.
        /// </summary>
        private TreeView detailsTree;

        /// <summary>
        /// Indicates whether the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// Initiates search for a rule.
        /// </summary>
        private Button findRule;

        /// <summary>
        /// Text string to match against rules for search.
        /// </summary>
        private TextBox findRuleId;

        /// <summary>
        /// Stores the form's accept button while focus is on the find rule ID textbox.
        /// </summary>
        private IButtonControl formAcceptButton;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label1;

        /// <summary>
        /// A tree label.
        /// </summary>
        private Label label2;

        /// <summary>
        /// A tree label.
        /// </summary>
        private Label label3;

        /// <summary>
        /// Find label.
        /// </summary>
        private Label label4;

        /// <summary>
        /// List of images on for tree nodes.
        /// </summary>
        private ImageList nodeImages;

        /// <summary>
        /// Indicates whether the tree is currently being refreshed.
        /// </summary>
        private bool refreshing;

        /// <summary>
        /// The table layout panel 1.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
        /// The table layout panel 2.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel2;

        /// <summary>
        /// The tab control hosting this page.
        /// </summary>
        private PropertyControl tabControl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the AnalyzersOptions class.
        /// </summary>
        public AnalyzersOptions()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Handler for matching nodes in the rules tree while searching for a node.
        /// </summary>
        /// <param name="node">The node to match against.</param>
        /// <param name="searchText">The search text to match against.</param>
        /// <returns>Returns true if the node matches the given text; false otherwise.</returns>
        private delegate bool MatchRuleHandler(TreeNode node, string searchText);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the pages are dirty.
        /// </summary>
        public bool Dirty
        {
            get
            {
                return this.dirty;
            }

            set
            {
                Param.Ignore(value);

                if (this.dirty != value)
                {
                    this.dirty = value;
                    this.tabControl.DirtyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the value to place on the page tab.
        /// </summary>
        public string TabName
        {
            get
            {
                return Strings.AnalyzersTab;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the page is activated.
        /// </summary>
        /// <param name="activated">
        /// Indicates whether the is being activated or deactivated..
        /// </param>
        public void Activate(bool activated)
        {
            Param.Ignore(activated);
        }

        /// <summary>
        /// Saves the data and clears the dirty flag.
        /// </summary>
        /// <returns>Returns true if the data was saved, false if not.</returns>
        public bool Apply()
        {
            // Iterate through each of the analyzers in the tree.
            foreach (TreeNode parserNode in this.analyzeTree.Nodes)
            {
                SourceParser parser = (SourceParser)parserNode.Tag;
                this.ApplyProperties(parser);

                foreach (TreeNode analyzerNode in parserNode.Nodes)
                {
                    SourceAnalyzer analyzer = (SourceAnalyzer)analyzerNode.Tag;

                    this.ApplyProperties(analyzer);

                    this.ApplyRules(analyzer, analyzerNode);
                }
            }

            this.dirty = false;
            this.tabControl.DirtyChanged();

            return true;
        }

        /// <summary>
        /// Initializes the page.
        /// </summary>
        /// <param name="propertyControl">
        /// The tab control object.
        /// </param>
        public void Initialize(PropertyControl propertyControl)
        {
            Param.AssertNotNull(propertyControl, "tabControl");

            this.tabControl = propertyControl;

            // Adds the parsers and analyzers to the tree.
            this.FillAnalyzerTree();

            // Select the first node in the tree.
            if (this.analyzeTree.Nodes.Count > 0)
            {
                this.analyzeTree.SelectedNode = this.analyzeTree.Nodes[0];
            }

            // Reset the dirty flag to false now.
            this.dirty = false;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Called after all pages have been applied.
        /// </summary>
        /// <param name="wasDirty">
        /// The dirty state of the page before it was applied.
        /// </param>
        public void PostApply(bool wasDirty)
        {
            Param.Ignore(wasDirty);
        }

        /// <summary>
        /// Called before all pages are applied.
        /// </summary>
        /// <returns>Returns false if no pages should be applied.</returns>
        public bool PreApply()
        {
            return true;
        }

        /// <summary>
        /// Refreshes the bold state for all analyzers.
        /// </summary>
        public void RefreshSettingsOverrideState()
        {
            this.refreshing = true;

            try
            {
                // Iterate through each of the analyzers in the tree.
                foreach (TreeNode root in this.analyzeTree.Nodes)
                {
                    foreach (TreeNode analyzerNode in root.Nodes)
                    {
                        foreach (TreeNode ruleNode in analyzerNode.Nodes)
                        {
                            Rule rule = ruleNode.Tag as Rule;
                            if (rule == null)
                            {
                                // This is a rule group.
                                foreach (TreeNode ruleInGroup in ruleNode.Nodes)
                                {
                                    rule = ruleInGroup.Tag as Rule;
                                    Debug.Assert(rule != null, "All children of a rule group should be a rule.");
                                    this.InitializeRuleCheckedState(rule, ruleInGroup);
                                }
                            }
                            else
                            {
                                this.InitializeRuleCheckedState(rule, ruleNode);
                            }
                        }
                    }
                }

                this.FillDetailsTree();
            }
            finally
            {
                this.refreshing = false;
                this.AdjustBoldState();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// Dispose parameter.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Searches the given node collection to find a rule group node matching the given name.
        /// </summary>
        /// <param name="nodes">
        /// The nodes collection.
        /// </param>
        /// <param name="ruleGroup">
        /// The name of the rule group.
        /// </param>
        /// <returns>
        /// Returns the rule group node or null if there is none.
        /// </returns>
        private static TreeNode FindMatchingRuleGroupNode(TreeNodeCollection nodes, string ruleGroup)
        {
            Param.AssertNotNull(nodes, "nodes");
            Param.AssertValidString(ruleGroup, "ruleGroup");

            foreach (TreeNode node in nodes)
            {
                // Rule group nodes have no tag set.
                if (node.Tag == null)
                {
                    if (string.Equals(node.Text, ruleGroup, StringComparison.Ordinal))
                    {
                        return node;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Inserts a nodes into a nodes collection, sorted by name.
        /// </summary>
        /// <param name="nodes">
        /// The collection of nodes to insert into.
        /// </param>
        /// <param name="nodeToInsert">
        /// The node to insert.
        /// </param>
        private static void InsertIntoSortedTree(TreeNodeCollection nodes, TreeNode nodeToInsert)
        {
            Param.AssertNotNull(nodes, "nodes");
            Param.AssertNotNull(nodeToInsert, "nodeToInsert");

            int index = 0;
            for (; index < nodes.Count; ++index)
            {
                if (string.Compare(nodes[index].Text, nodeToInsert.Text, StringComparison.Ordinal) > 0)
                {
                    break;
                }
            }

            Debug.Assert(index <= nodes.Count, "The algoritm did not find a valid insertion position.");
            nodes.Insert(index, nodeToInsert);
        }

        /// <summary>
        /// Sets the bold state of the given node.
        /// </summary>
        /// <param name="item">
        /// The node to set.
        /// </param>
        /// <param name="bolded">
        /// Indicates whether the item should be bolded.
        /// </param>
        /// <param name="tree">
        /// The tree that contains the item.
        /// </param>
        private static void SetBoldState(TreeNode item, bool bolded, TreeView tree)
        {
            Param.AssertNotNull(item, "item");
            Param.Ignore(bolded);
            Param.AssertNotNull(tree, "tree");

            if (bolded)
            {
                if (item.NodeFont == null)
                {
                    // Make the item bold.
                    item.NodeFont = new Font(tree.Font, FontStyle.Bold);
                }
                else if (!item.NodeFont.Bold)
                {
                    // Make the item bold.
                    item.NodeFont = new Font(item.NodeFont, FontStyle.Bold);
                }
            }
            else
            {
                if (item.NodeFont != null && item.NodeFont.Bold)
                {
                    // Make the item not bold.
                    item.NodeFont = new Font(item.NodeFont, FontStyle.Regular);
                }
            }

            // This forces the tree to redraw the bolded nodes.
            tree.BeginUpdate();
            tree.EndUpdate();
        }

        /// <summary>
        /// Adjusts the bold state of all nodes in the analyzer tree.
        /// </summary>
        private void AdjustBoldState()
        {
            this.analyzeTree.BeginUpdate();

            try
            {
                // Loop through each of the root parser nodes.
                foreach (TreeNode parserNode in this.analyzeTree.Nodes)
                {
                    // Loop through each analyzer in the parser and keep track of whether any analzer node is bold.
                    bool boldAnalyzer = false;
                    foreach (TreeNode analyzerNode in parserNode.Nodes)
                    {
                        // Loop through each rule in the analyzer and keep track of whether any rule node is bold.
                        bool boldRule = false;
                        foreach (TreeNode ruleNode in analyzerNode.Nodes)
                        {
                            // Determine whether this is a rule node or a rule group node.
                            if (ruleNode.Tag == null)
                            {
                                // This is actually a rule group node. Loop through each rule in the rule group
                                // and keep track of whether any rule node is bold.
                                bool boldRuleInGroup = false;
                                foreach (TreeNode ruleInGroup in ruleNode.Nodes)
                                {
                                    boldRuleInGroup |= this.DetectBoldStateForRule(ruleInGroup);
                                }

                                // Set the rule group node bold if there are any bold nodes in the group.
                                boldRule |= boldRuleInGroup;
                                SetBoldState(ruleNode, boldRuleInGroup, this.analyzeTree);
                            }
                            else
                            {
                                // This is a rule node, not a group.
                                boldRule |= this.DetectBoldStateForRule(ruleNode);
                            }
                        }

                        // Set the analyzer node bold if there are any bold nodes under the analyzer.
                        boldAnalyzer |= boldRule;
                        SetBoldState(analyzerNode, boldRule, this.analyzeTree);
                    }

                    // Set the parser node bold if there are any bold nodes under the parser.
                    SetBoldState(parserNode, boldAnalyzer, this.analyzeTree);
                }
            }
            finally
            {
                this.analyzeTree.EndUpdate();
            }
        }

        /// <summary>
        /// Event handler that is called when the user checks or un-checks an item in the list.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AnalyzeTreeAfterCheck(object sender, TreeViewEventArgs e)
        {
            Param.Ignore(sender, e);
            this.dirty = true;
            this.tabControl.DirtyChanged();

            // Unsubscribe to this event temporarily.
            this.analyzeTree.AfterCheck -= this.AnalyzeTreeAfterCheck;

            // Check or uncheck all of the child nodes under this node.
            this.CheckAllChildNodes(e.Node, e.Node.Checked);

            TreeNode parentNode = e.Node.Parent;
            while (parentNode != null)
            {
                if (e.Node.Checked)
                {
                    // When a node is checked, make sure that all items above this rule are also checked.
                    parentNode.Checked = true;
                }
                else
                {
                    // When a node is unchecked, uncheck the parent if all of its children are unchecked.
                    bool somethingChecked = false;
                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            somethingChecked = true;
                            break;
                        }
                    }

                    if (!somethingChecked)
                    {
                        parentNode.Checked = false;
                    }
                }

                parentNode = parentNode.Parent;
            }

            // Resubscribe to the event.
            this.analyzeTree.AfterCheck += this.AnalyzeTreeAfterCheck;

            if (!this.refreshing)
            {
                // Adjust the bold state of items in the tree now.
                this.AdjustBoldState();

                // Set the current selection to the node that was checked or unchecked.
                this.analyzeTree.SelectedNode = e.Node;
            }
        }

        /// <summary>
        /// Called after a node is selected.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AnalyzeTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.Node == null)
            {
                this.description.Clear();
            }
            else
            {
                StyleCopAddIn addIn = e.Node.Tag as StyleCopAddIn;
                if (addIn != null)
                {
                    this.description.Text = addIn.Description;
                }
                else
                {
                    Rule rule = e.Node.Tag as Rule;
                    if (rule != null)
                    {
                        this.description.Text = rule.Description;
                    }
                    else
                    {
                        this.description.Clear();
                    }
                }

                // Fill the details tree.
                this.FillDetailsTree();
            }
        }

        /// <summary>
        /// Called when a tree node is about to be collapsed.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AnalyzeTreeBeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            Param.Ignore(sender);
            Param.AssertNotNull(e, "e");

            if (e.Node.Tag is SourceParser)
            {
                // Do not allow the parser nodes to become collapsed.
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Applies the properties for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in.
        /// </param>
        private void ApplyProperties(StyleCopAddIn addIn)
        {
            Param.AssertNotNull(addIn, "addIn");

            ICollection<BooleanProperty> addInProperties = null;

            if (this.properties.TryGetValue(addIn, out addInProperties))
            {
                foreach (BooleanProperty property in addInProperties)
                {
                    addIn.SetSetting(this.tabControl.LocalSettings, property);
                }
            }
        }

        /// <summary>
        /// Applies settings for rules under the given node.
        /// </summary>
        /// <param name="addIn">
        /// The addin owning the rules.
        /// </param>
        /// <param name="parentNode">
        /// The parent node of the rules.
        /// </param>
        private void ApplyRules(StyleCopAddIn addIn, TreeNode parentNode)
        {
            Param.AssertNotNull(addIn, "addIn");
            Param.AssertNotNull(parentNode, "parentNode");

            foreach (TreeNode node in parentNode.Nodes)
            {
                Rule rule = node.Tag as Rule;
                if (rule == null)
                {
                    this.ApplyRules(addIn, node);
                }
                else
                {
                    addIn.SetSetting(this.tabControl.LocalSettings, new BooleanProperty(addIn, rule.Name + "#Enabled", node.Checked));
                }
            }
        }

        /// <summary>
        /// Checks or un-checks all nodes beneath the given node.
        /// </summary>
        /// <param name="node">
        /// The node to check or un-check.
        /// </param>
        /// <param name="checked">
        /// Indicates whether to check or un-check the nodes.
        /// </param>
        private void CheckAllChildNodes(TreeNode node, bool @checked)
        {
            Param.AssertNotNull(node, "node");
            Param.Ignore(@checked);

            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = @checked;

                if (child.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(child, @checked);
                }
            }
        }

        /// <summary>
        /// Event handler that is called when the user checks or un-checks an item in the list.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void DetailsTreeAfterCheck(object sender, TreeViewEventArgs e)
        {
            Param.Ignore(sender, e);
            this.dirty = true;
            this.tabControl.DirtyChanged();

            this.DetectBoldStateForDetails(e.Node);

            if (!this.refreshing)
            {
                // Set the current selection to the node that was checked or unchecked.
                this.detailsTree.SelectedNode = e.Node;
            }

            PropertyAddInPair propertyAddInPair = (PropertyAddInPair)e.Node.Tag;
            propertyAddInPair.Property.Value = e.Node.Checked;
        }

        /// <summary>
        /// Called after a node is selected in the details tree.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void DetailsTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.Node == null)
            {
                this.description.Clear();
            }
            else
            {
                PropertyAddInPair propertyAddInPair = (PropertyAddInPair)e.Node.Tag;
                this.description.Text = propertyAddInPair.Property.Description;
            }
        }

        /// <summary>
        /// Sets the bold state of the given properties node based on its current status.
        /// </summary>
        /// <param name="propertyNode">
        /// The node containing the properties.
        /// </param>
        private void DetectBoldStateForDetails(TreeNode propertyNode)
        {
            Param.AssertNotNull(propertyNode, "propertyNode");

            PropertyAddInPair propertyAddInPair = (PropertyAddInPair)propertyNode.Tag;

            bool overriden = false;

            // Create a property representing the current value of the selection.
            BooleanProperty localValue = new BooleanProperty((PropertyDescriptor<bool>)propertyAddInPair.Property.PropertyDescriptor, propertyNode.Checked);

            // Compare this with the parent value.
            overriden = this.tabControl.SettingsComparer.IsAddInSettingOverwritten(propertyAddInPair.AddIn, propertyAddInPair.Property.PropertyName, localValue);

            // Set the bold state depending upon whether the setting is overriden.
            SetBoldState(propertyNode, overriden, this.detailsTree);
        }

        /// <summary>
        /// Sets the bold state of the given rule item based on it current status.
        /// </summary>
        /// <param name="ruleNode">
        /// The node containing the rule to set.
        /// </param>
        /// <returns>
        /// Returns true if the item is bolded, false otherwise.
        /// </returns>
        private bool DetectBoldStateForRule(TreeNode ruleNode)
        {
            Param.AssertNotNull(ruleNode, "ruleNode");

            // Extract the analyzer from the parent of this rule.
            SourceAnalyzer analyzer = null;
            TreeNode analyzerNode = ruleNode.Parent;
            while (analyzerNode != null)
            {
                analyzer = analyzerNode.Tag as SourceAnalyzer;
                if (analyzer != null)
                {
                    break;
                }

                analyzerNode = analyzerNode.Parent;
            }

            Debug.Assert(analyzer != null, "The rule node does not have a parent analyzer node.");

            Rule rule = ruleNode.Tag as Rule;
            bool overridden = false;

            if (analyzer != null)
            {
                // Create a property representing the current value of the selection.
                string propertyName = rule.Name + "#Enabled";
                BooleanProperty localValue = new BooleanProperty(analyzer, propertyName, ruleNode.Checked);

                // Compare this with the parent value.
                overridden = this.tabControl.SettingsComparer.IsAddInSettingOverwritten(analyzer, propertyName, localValue);
            }

            // Set the bold state depending upon whether the setting is overriden.
            SetBoldState(ruleNode, overridden, this.analyzeTree);

            return overridden;
        }

        /// <summary>
        /// Adds nodes for an analyzer's rules to the tree.
        /// </summary>
        /// <param name="analyzer">
        /// The analyzer.
        /// </param>
        /// <param name="analyzerNode">
        /// The parent node for the analyzer.
        /// </param>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "System.Windows.Forms.TreeNode.set_SelectedImageKey(System.String)", Justification = "This is not a user-visible value.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "System.Windows.Forms.TreeNode.set_ImageKey(System.String)", Justification = "This is not a user-visible value.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "System.Windows.Forms.TreeNode.#ctor(System.String)", Justification = "This is not a user-visible value.")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "RuleNode", Justification = "This is not a user-visible value.")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "RuleGroupNode", 
            Justification = "This is not a user-visible value.")]
        private void FillAnalyzerRules(SourceAnalyzer analyzer, TreeNode analyzerNode)
        {
            Param.AssertNotNull(analyzer, "analyzer");
            Param.AssertNotNull(analyzerNode, "analyzerNode");

            // Iterate through each rule in the analyzer and add a checkbox for each.
            foreach (Rule rule in analyzer.AddInRules)
            {
                // Only show rules which can be disabled.
                if (rule.CanDisable)
                {
                    // Get or create the rule group node for this rule, if necessary.
                    TreeNode ruleParentNode = analyzerNode;
                    if (!string.IsNullOrEmpty(rule.RuleGroup))
                    {
                        ruleParentNode = FindMatchingRuleGroupNode(analyzerNode.Nodes, rule.RuleGroup);
                        if (ruleParentNode == null)
                        {
                            ruleParentNode = new TreeNode(rule.RuleGroup);
                            ruleParentNode.ImageKey = ruleParentNode.SelectedImageKey = RuleGroupNode;

                            InsertIntoSortedTree(analyzerNode.Nodes, ruleParentNode);
                        }
                    }

                    // Create a node for this rule.
                    TreeNode ruleNode = new TreeNode(string.Concat(rule.CheckId, ": ", rule.Name));
                    ruleNode.ImageKey = ruleNode.SelectedImageKey = RuleNode;
                    ruleNode.Tag = rule;
                    InsertIntoSortedTree(ruleParentNode.Nodes, ruleNode);

                    this.InitializeRuleCheckedState(rule, ruleNode);
                }
            }
        }

        /// <summary>
        /// Fills in the analyzer tree.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ParserNode", Justification = "This is not a user-visible value.")
        ]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "AnalyzerNode", 
            Justification = "This is not a user-visible value.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "System.Windows.Forms.TreeNode.set_SelectedImageKey(System.String)", Justification = "This is not a user-visible value.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "System.Windows.Forms.TreeNode.set_ImageKey(System.String)", Justification = "This is not a user-visible value.")]
        private void FillAnalyzerTree()
        {
            // Add each of the parsers and analyzers to the tree.
            foreach (SourceParser parser in this.tabControl.Core.Parsers)
            {
                TreeNode parserNode = new TreeNode(parser.Name);
                parserNode.ImageKey = parserNode.SelectedImageKey = ParserNode;
                parserNode.Tag = parser;
                InsertIntoSortedTree(this.analyzeTree.Nodes, parserNode);

                // Add each of the boolean properties exposed by the parser.
                this.StoreAddinProperties(parser);

                this.refreshing = true;

                try
                {
                    // Iterate through each of the analyzers and add a checkbox for each.
                    foreach (SourceAnalyzer analyzer in parser.Analyzers)
                    {
                        // Create a node for this analyzer.
                        TreeNode analyzerNode = new TreeNode(analyzer.Name);
                        analyzerNode.ImageKey = analyzerNode.SelectedImageKey = AnalyzerNode;
                        analyzerNode.Tag = analyzer;
                        InsertIntoSortedTree(parserNode.Nodes, analyzerNode);

                        // Add each of the boolean properties exposed by the analyzer.
                        this.StoreAddinProperties(analyzer);

                        this.FillAnalyzerRules(analyzer, analyzerNode);
                    }
                }
                finally
                {
                    this.refreshing = false;
                    this.AdjustBoldState();
                }

                // Expand the parser node.
                parserNode.Expand();
            }
        }

        /// <summary>
        /// Fills the contents of the details tree.
        /// </summary>
        private void FillDetailsTree()
        {
            this.detailsTree.Nodes.Clear();

            // Get the selected item in the analyzer tree.
            if (this.analyzeTree.SelectedNode != null)
            {
                StyleCopAddIn addIn = this.analyzeTree.SelectedNode.Tag as StyleCopAddIn;
                if (addIn != null)
                {
                    // Get the properties for this addin.
                    ICollection<BooleanProperty> addInProperties = null;
                    if (this.properties.TryGetValue(addIn, out addInProperties))
                    {
                        foreach (BooleanProperty property in addInProperties)
                        {
                            PropertyAddInPair propertyAddInPair = new PropertyAddInPair();
                            propertyAddInPair.Property = property;
                            propertyAddInPair.AddIn = addIn;

                            TreeNode propertyNode = new TreeNode(property.FriendlyName);
                            propertyNode.Checked = property.Value;
                            propertyNode.Tag = propertyAddInPair;
                            this.detailsTree.Nodes.Add(propertyNode);

                            this.DetectBoldStateForDetails(propertyNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when the file rule button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void FindRuleClick(object sender, EventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            string searchText = this.findRuleId.Text.Trim();

            if (searchText.Length > 0)
            {
                this.SearchForRule(searchText);
            }
        }

        /// <summary>
        /// Called when the formRuleId TextBox receives the input focus.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void FindRuleIdGotFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Save the current form accept button, and then clear it. This will allow
            // the formRuleId textbox to capture the return key.
            this.formAcceptButton = this.ParentForm.AcceptButton;
            this.ParentForm.AcceptButton = null;
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the find rule textbox.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void FindRuleIdKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Return)
            {
                string searchText = this.findRuleId.Text.Trim();

                if (searchText.Length > 0)
                {
                    this.SearchForRule(searchText);
                }
            }
        }

        /// <summary>
        /// Called when the formRuleId TextBox loses the input focus.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void FindRuleIdLostFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Reset the form accept button now that the formRuleId textbox no longer has the input focus.
            if (this.formAcceptButton != null)
            {
                this.ParentForm.AcceptButton = this.formAcceptButton;
                this.formAcceptButton = null;
            }
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AnalyzersOptions));
            this.label1 = new Label();
            this.description = new TextBox();
            this.label2 = new Label();
            this.analyzeTree = new TreeView();
            this.nodeImages = new ImageList(this.components);
            this.label3 = new Label();
            this.detailsTree = new TreeView();
            this.findRule = new Button();
            this.findRuleId = new TextBox();
            this.label4 = new Label();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();

            // label1
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";

            // description
            resources.ApplyResources(this.description, "description");
            this.tableLayoutPanel1.SetColumnSpan(this.description, 4);
            this.description.Name = "description";
            this.description.ReadOnly = true;

            // label2
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";

            // analyzeTree
            resources.ApplyResources(this.analyzeTree, "analyzeTree");
            this.analyzeTree.CheckBoxes = true;
            this.analyzeTree.HideSelection = false;
            this.analyzeTree.ImageList = this.nodeImages;
            this.analyzeTree.Name = "analyzeTree";
            this.analyzeTree.ShowRootLines = false;
            this.analyzeTree.AfterCheck += new TreeViewEventHandler(this.AnalyzeTreeAfterCheck);
            this.analyzeTree.BeforeCollapse += new TreeViewCancelEventHandler(this.AnalyzeTreeBeforeCollapse);
            this.analyzeTree.AfterSelect += new TreeViewEventHandler(this.AnalyzeTreeAfterSelect);

            // nodeImages
            this.nodeImages.ImageStream = (ImageListStreamer)resources.GetObject("nodeImages.ImageStream");
            this.nodeImages.TransparentColor = Color.Magenta;
            this.nodeImages.Images.SetKeyName(0, ParserNode);
            this.nodeImages.Images.SetKeyName(1, AnalyzerNode);
            this.nodeImages.Images.SetKeyName(2, RuleGroupNode);
            this.nodeImages.Images.SetKeyName(3, RuleNode);

            // label3
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";

            // detailsTree
            resources.ApplyResources(this.detailsTree, "detailsTree");
            this.detailsTree.CheckBoxes = true;
            this.detailsTree.HideSelection = false;
            this.detailsTree.Name = "detailsTree";
            this.detailsTree.ShowLines = false;
            this.detailsTree.ShowRootLines = false;
            this.detailsTree.AfterCheck += new TreeViewEventHandler(this.DetailsTreeAfterCheck);
            this.detailsTree.AfterSelect += new TreeViewEventHandler(this.DetailsTreeAfterSelect);

            // findRule
            resources.ApplyResources(this.findRule, "findRule");
            this.findRule.Name = "findRule";
            this.findRule.UseVisualStyleBackColor = true;
            this.findRule.Click += new EventHandler(this.FindRuleClick);

            // findRuleId
            resources.ApplyResources(this.findRuleId, "findRuleId");
            this.findRuleId.Name = "findRuleId";
            this.findRuleId.GotFocus += new EventHandler(this.FindRuleIdGotFocus);
            this.findRuleId.KeyDown += new KeyEventHandler(this.FindRuleIdKeyDown);
            this.findRuleId.LostFocus += new EventHandler(this.FindRuleIdLostFocus);

            // label4
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";

            // tableLayoutPanel1
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.description, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.findRuleId, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.findRule, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";

            // tableLayoutPanel2
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.Controls.Add(this.detailsTree, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.analyzeTree, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";

            // AnalyzersOptions
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AnalyzersOptions";
            resources.ApplyResources(this, "$this");
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Sets the check state for the given property.
        /// </summary>
        /// <param name="addIn">
        /// The addin that owns the property.
        /// </param>
        /// <param name="property">
        /// The property.
        /// </param>
        private void InitializePropertyState(StyleCopAddIn addIn, BooleanProperty property)
        {
            Param.AssertNotNull(addIn, "addIn");
            Param.AssertNotNull(property, "property");

            BooleanProperty mergedProperty = addIn.GetSetting(this.tabControl.MergedSettings, property.PropertyName) as BooleanProperty;
            if (mergedProperty == null)
            {
                property.Value = property.DefaultValue;
            }
            else
            {
                property.Value = mergedProperty.Value;
            }
        }

        /// <summary>
        /// Initializes the checked state of the given rule.
        /// </summary>
        /// <param name="rule">
        /// The rule to check.
        /// </param>
        /// <param name="ruleNode">
        /// The node representing the rule.
        /// </param>
        private void InitializeRuleCheckedState(Rule rule, TreeNode ruleNode)
        {
            Param.AssertNotNull(rule, "rule");
            Param.AssertNotNull(ruleNode, "ruleNode");

            // Extract the analyzer from the parent of this rule.
            SourceAnalyzer analyzer = null;
            TreeNode analyzerNode = ruleNode.Parent;
            while (analyzerNode != null)
            {
                analyzer = analyzerNode.Tag as SourceAnalyzer;
                if (analyzer != null)
                {
                    break;
                }

                analyzerNode = analyzerNode.Parent;
            }

            Debug.Assert(analyzer != null, "The rule node does not have a parent analyzer node.");

            BooleanProperty enabledDisabledSetting = analyzer.GetRuleSetting(this.tabControl.MergedSettings, rule.Name, "Enabled") as BooleanProperty;
            if (enabledDisabledSetting == null)
            {
                ruleNode.Checked = rule.EnabledByDefault;
            }
            else
            {
                ruleNode.Checked = enabledDisabledSetting.Value;
            }
        }

        /// <summary>
        /// Iterates through all nodes in the analyzer rules tree to try to find a matching node.
        /// </summary>
        /// <param name="nodes">
        /// The collection of nodes to iterate.
        /// </param>
        /// <param name="searchText">
        /// The search text to match against.
        /// </param>
        /// <param name="matchHandler">
        /// Performs node matching.
        /// </param>
        /// <returns>
        /// Returns the matching node, or null if none was found.
        /// </returns>
        private TreeNode IterateAndFindRule(TreeNodeCollection nodes, string searchText, MatchRuleHandler matchHandler)
        {
            Param.AssertNotNull(nodes, "nodes");
            Param.AssertNotNull(searchText, "searchText");
            Param.AssertNotNull(matchHandler, "matchHandler");

            foreach (TreeNode node in nodes)
            {
                if (matchHandler(node, searchText))
                {
                    return node;
                }

                TreeNode child = this.IterateAndFindRule(node.Nodes, searchText, matchHandler);
                if (child != null)
                {
                    return child;
                }
            }

            return null;
        }

        /// <summary>
        /// Searches for a rule with the given ID or name. If found, selects and shows the rule.
        /// </summary>
        /// <param name="searchText">
        /// The text to search for.
        /// </param>
        private void SearchForRule(string searchText)
        {
            Param.AssertNotNull(searchText, "searchText");

            TreeNode match = this.SearchForRuleByCategories(searchText);
            if (match != null)
            {
                match.EnsureVisible();
                this.analyzeTree.SelectedNode = match;
            }
        }

        /// <summary>
        /// Searches for a rule with the given ID or name, searching through various categories of information on the rule.
        /// </summary>
        /// <param name="searchText">
        /// The text to search for.
        /// </param>
        /// <returns>
        /// Returns the tree node representing the rule, or null if no node could be found.
        /// </returns>
        private TreeNode SearchForRuleByCategories(string searchText)
        {
            Param.AssertNotNull(searchText, "searchText");

            // Try to match by the checkid.
            TreeNode match = this.IterateAndFindRule(
                this.analyzeTree.Nodes, 
                searchText, 
                delegate(TreeNode node, string text)
                    {
                        Rule rule = node.Tag as Rule;
                        if (rule != null)
                        {
                            return string.Equals(text, rule.CheckId, StringComparison.OrdinalIgnoreCase);
                        }

                        return false;
                    });

            if (match == null)
            {
                // Try to match by the rule name.
                match = this.IterateAndFindRule(
                    this.analyzeTree.Nodes, 
                    searchText, 
                    delegate(TreeNode node, string text)
                        {
                            Rule rule = node.Tag as Rule;
                            if (rule != null)
                            {
                                return string.Equals(text, rule.Name, StringComparison.OrdinalIgnoreCase);
                            }

                            return false;
                        });
            }

            if (match == null)
            {
                // Try to match by the beginning of the rule name.
                match = this.IterateAndFindRule(
                    this.analyzeTree.Nodes, 
                    searchText, 
                    delegate(TreeNode node, string text)
                        {
                            Rule rule = node.Tag as Rule;
                            if (rule != null)
                            {
                                return rule.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase);
                            }

                            return false;
                        });
            }

            return match;
        }

        /// <summary>
        /// Stores the properties for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in.
        /// </param>
        private void StoreAddinProperties(StyleCopAddIn addIn)
        {
            Param.AssertNotNull(addIn, "addIn");

            ICollection<PropertyDescriptor> addInPropertyDescriptors = addIn.PropertyDescriptors;
            if (addInPropertyDescriptors != null && addInPropertyDescriptors.Count > 0)
            {
                List<BooleanProperty> storedProperties = new List<BooleanProperty>(addInPropertyDescriptors.Count);

                foreach (PropertyDescriptor propertyDescriptor in addInPropertyDescriptors)
                {
                    if (propertyDescriptor.PropertyType == PropertyType.Boolean && propertyDescriptor.DisplaySettings)
                    {
                        PropertyDescriptor<bool> booleanPropertyDescriptor = (PropertyDescriptor<bool>)propertyDescriptor;

                        // Ensure that the property has a friendly name and a description.
                        if (string.IsNullOrEmpty(propertyDescriptor.FriendlyName))
                        {
                            throw new ArgumentException(Strings.PropertyFriendlyNameNotSet);
                        }

                        if (string.IsNullOrEmpty(propertyDescriptor.Description))
                        {
                            throw new ArgumentException(Strings.PropertyDescriptionNotSet);
                        }

                        BooleanProperty storedProperty = new BooleanProperty(booleanPropertyDescriptor, booleanPropertyDescriptor.DefaultValue);

                        this.InitializePropertyState(addIn, storedProperty);

                        storedProperties.Add(storedProperty);
                    }
                }

                this.properties.Add(addIn, storedProperties.ToArray());
            }
        }

        #endregion

        /// <summary>
        /// A property addin pair.
        /// </summary>
        private struct PropertyAddInPair
        {
            #region Fields

            /// <summary>
            /// The add-in.
            /// </summary>
            public StyleCopAddIn AddIn;

            /// <summary>
            /// The property.
            /// </summary>
            public BooleanProperty Property;

            #endregion
        }
    }
}
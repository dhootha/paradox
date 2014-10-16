﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Collections.Generic;

namespace SiliconStudio.Shaders.Ast
{
    /// <summary>
    /// A reference to a variable.
    /// </summary>
    public class VariableReferenceExpression : Expression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableReferenceExpression"/> class.
        /// </summary>
        public VariableReferenceExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableReferenceExpression"/> class.
        /// </summary>
        /// <param name="variable">The variable.</param>
        public VariableReferenceExpression(Variable variable)
        {
            Name = variable.Name;
            TypeInference.TargetType = variable.Type.ResolveType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableReferenceExpression"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public VariableReferenceExpression(Identifier name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public Identifier Name { get; set; }

        ///// <summary>
        ///// Gets or sets the variable.
        ///// </summary>
        ///// <value>
        ///// The variable.
        ///// </value>
        //[VisitorIgnore]
        //public Variable Variable
        //{
        //    get
        //    {
        //        return (Variable)TypeInference.Declaration;
        //    }
        //    set
        //    {
        //        TypeInference.Declaration = value;
        //    }
        //}

        /// <inheritdoc/>
        public override IEnumerable<Node> Childrens()
        {
            ChildrenList.Clear();
            ChildrenList.Add(Name);
            return ChildrenList;
        }

        /// <summary>
        /// Gets a name of the variable referenced by an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>Name of the variable referenced. If the expression is not a VariableReferenceExpression, returns null</returns>
        public static string GetVariableName(Expression expression)
        {
            var variableReferenceExpression = expression as VariableReferenceExpression;
            return variableReferenceExpression == null ? null : variableReferenceExpression.Name.Text;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name;
        }
    }
}
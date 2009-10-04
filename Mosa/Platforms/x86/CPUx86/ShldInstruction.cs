﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (<mailto:sharpos@michaelruck.de>)
 */

using System;
using Mosa.Runtime.CompilerFramework;

namespace Mosa.Platforms.x86.CPUx86
{
    /// <summary>
    /// Intermediate representation of the x86 shrd instruction.
    /// </summary>
    public class ShldInstruction : ThreeOperandInstruction
    {
        #region Data Members
        private static readonly OpCode Register = new OpCode(new byte[] { 0x0F, 0xA5 }, 4);
        private static readonly OpCode Constant = new OpCode(new byte[] { 0x0F, 0xA4 }, 4);
        #endregion // Construction

        #region ThreeOperandInstruction Overrides

		/// <summary>
		/// Computes the op code.
		/// </summary>
		/// <param name="destination">The destination operand.</param>
		/// <param name="source">The source operand.</param>
		/// <param name="third">The third operand.</param>
		/// <returns></returns>
        protected override OpCode ComputeOpCode(Operand destination, Operand source, Operand third)
        {
			if (third is RegisterOperand)
                return Register;
			if (third is ConstantOperand)
                return Constant;
            throw new ArgumentException(@"No opcode for operand type.");
        }

        /// <summary>
        /// Returns a string representation of the instruction.
        /// </summary>
        /// <returns>
        /// A string representation of the instruction in intermediate form.
        /// </returns>
        public override string ToString(Context context)
        {
            return String.Format(@"x86.shld {0}, {1}, {2}", context.Operand1, context.Operand2, context.Operand2);
        }

        /// <summary>
        /// Allows visitor based dispatch for this instruction object.
        /// </summary>
        /// <param name="visitor">The visitor object.</param>
        /// <param name="context">The context.</param>
        public override void Visit(IX86Visitor visitor, Context context)
        {
            visitor.Shrd(context);
        }

        #endregion // ThreeOperandInstruction Overrides
    }
}
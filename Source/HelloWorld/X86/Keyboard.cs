﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using Mosa.Platforms.x86;

namespace Mosa.Kernel.X86
{
	/// <summary>
	/// 
	/// </summary>
	public static class Keyboard
	{
		/// <summary>
		/// Reads the scan code from the device
		/// </summary>
		/// <returns></returns>
		public static byte ReadScanCode()
		{
			return Native.In8(0x60);
		}

	}
}

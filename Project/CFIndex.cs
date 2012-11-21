// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFoundation
{
    public class CFIndex 
    {
        internal IntPtr theIndex;

        public CFIndex() { }
        public CFIndex(IntPtr Index) { this.theIndex = Index; }
        /// <summary>
        /// Returns the CFIndex object as a Int32
        /// </summary>
        /// <returns></returns>
        public int ToInteger()
        {
            return System.Runtime.InteropServices.Marshal.ReadInt32(theIndex);
        }

        public static implicit operator CFIndex(IntPtr Index)
        {
            return new CFIndex(Index);
        }
    }
}

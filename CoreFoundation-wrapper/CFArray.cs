// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CoreFoundation
{
    public class CFArray : CFType
    {
        public CFArray() { }
        public CFArray(IntPtr Number)
            : base(Number)
        {
        }
        public CFArray(IntPtr[] values)
        {
            try
            {
                typeRef = CFLibrary.CFArrayCreate(IntPtr.Zero, values, values.Length, IntPtr.Zero);
            }
            catch (Exception Ex)
            {
                typeRef = IntPtr.Zero;
            }
        }
        /// <summary>
        /// Returns the number of values currently in an array
        /// </summary>
        /// <returns></returns>
        public int GetCount
        {
            get
            {
                return CFLibrary.CFArrayGetCount(typeRef);
            }
        }

        /// <summary>
        /// Retrieves a value at a given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CFType GetValue(int index)
        {            
            if (index >= GetCount)
                return new CFType(IntPtr.Zero);

            return new CFType(CFLibrary.CFArrayGetValueAtIndex(typeRef, index));

        }
    }
}

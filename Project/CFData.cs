// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreFoundation
{
    public class CFData :  CFType 
    {      
        public CFData(){}
        public CFData(IntPtr Data)
            : base(Data)
        {
        }
        unsafe public CFData(byte[] Data)
        {            
            byte[] buffer = Data;            
            int len = buffer.Length;            
            fixed (byte* bytePtr = buffer)
                
                base.typeRef = CFLibrary.CFDataCreate(IntPtr.Zero, (IntPtr)bytePtr,len);            
        }
        /// <summary>
        /// Returns the number of bytes contained by the CFData object
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return CFLibrary.CFDataGetLength(typeRef);
        }
        /// <summary>
        /// Checks if the object is a valid CFData object
        /// </summary>
        /// <returns></returns>
        public bool isData()
        {
            return CFLibrary.CFGetTypeID(typeRef) == _CFData;
        }
        /// <summary>
        /// Returns the CFData object as a byte array
        /// </summary>
        /// <returns></returns>
        unsafe public byte[] ToByteArray()
        {            
            int len = Length();
            byte[] buffer = new byte[len];
            fixed (byte* bufPtr = buffer)
                CFLibrary.CFDataGetBytes(typeRef, new CFRange(0, len), (IntPtr)bufPtr);
            return buffer;            
        }

        public static implicit operator CFData(IntPtr value)
        {
            return new CFData(value);
        }

        public static implicit operator IntPtr(CFData value)
        {
            return value.typeRef;
        }       
    }
}

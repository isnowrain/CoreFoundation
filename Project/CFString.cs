// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFoundation
{
   
    public sealed class CFString : CFType
    {
        public CFString()
        {            
        }             
        /// <summary>
        /// Creates an immutable string from a constant compile-time string
        /// </summary>
        /// <param name="str"></param>
        public CFString(string str) 
        {
            base.typeRef = CFLibrary.__CFStringMakeConstantString(str);
        }
        public CFString(IntPtr myHandle) : base(myHandle)
        {    
        }
        /// <summary>
        /// Checks if the current object is a valid CFString object
        /// </summary>
        /// <returns></returns>
        public bool isString()
        {
            return CFLibrary.CFGetTypeID(typeRef) == _CFString;
        }
        public static implicit operator CFString(IntPtr value)
        {
            return new CFString(value);
        }

        public static implicit operator IntPtr(CFString value)
        {
            return value.typeRef;
        }

        public static implicit operator string(CFString value)
        {
            return value.ToString();
        }

        public static implicit operator CFString(string value)
        {            
            return new CFString(value);
        }            
    }         
}

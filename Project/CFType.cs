// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
namespace CoreFoundation
{
    public class CFType
    {
        internal const int _CFArray = 18;
        internal const int _CFBoolean = 21;
        internal const int _CFData = 19; 
        internal const int _CFNumber = 22;
        internal const int _CFDictionary = 17;
        internal const int _CFString=7;

        internal IntPtr typeRef;

        public CFType() { }
        
        public CFType(IntPtr handle){this.typeRef = handle;}
        
        /// <summary>
        /// Returns the unique identifier of an opaque type to which a CoreFoundation object belongs
        /// </summary>
        /// <returns></returns>
        public int GetTypeID()
        {
            return CFLibrary.CFGetTypeID(typeRef);
        }
        /// <summary>
        /// Returns a textual description of a CoreFoundation object
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return new CFString(CFLibrary.CFCopyDescription(typeRef)).ToString();
        }       
                
        private string CFString()
        {
            if (typeRef == IntPtr.Zero)
                return null;
            
                string str;
                int length = CFLibrary.CFStringGetLength(typeRef);        
                IntPtr u = CFLibrary.CFStringGetCharactersPtr(typeRef);
                IntPtr buffer = IntPtr.Zero;
                if (u == IntPtr.Zero)
                {
                    CFRange range = new CFRange(0, length);
                    buffer = Marshal.AllocCoTaskMem(length * 2);
                    CFLibrary.CFStringGetCharacters(typeRef, range, buffer);
                    u = buffer;
                }
                unsafe
                {
                    str = new string((char*)u, 0, length);
                }
                if (buffer != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(buffer);
                return str;
        }       
        private string CFNumber()
        {
            IntPtr buffer = Marshal.AllocCoTaskMem(CFLibrary.CFNumberGetByteSize(typeRef));
            bool scs = CFLibrary.CFNumberGetValue(typeRef, CFLibrary.CFNumberGetType(typeRef), buffer);
            if (scs != true)
            {
                return string.Empty;
            }
            int type = (int)CFLibrary.CFNumberGetType(typeRef);
            switch (type)
            {
                case 1:
                    return Marshal.ReadInt16(buffer).ToString();
                case 2:
                    return Marshal.ReadInt16(buffer).ToString();
                case 3:
                    return Marshal.ReadInt32(buffer).ToString();
                case 4:
                    return Marshal.ReadInt64(buffer).ToString();
                default:
                    return Enum.GetName(typeof(CFNumber.CFNumberType), type) + " is not supported yet!";
            }
        }
        private string CFBoolean()
        {
            return CFLibrary.CFBooleanGetValue(typeRef).ToString();
        }
        private string CFData()
        {
            CFData typeArray = new CFData(typeRef);
            return Convert.ToBase64String(typeArray.ToByteArray());
        }
        private string CFPropertyList()
        {
            return Encoding.UTF8.GetString(new CFData(CFLibrary.CFPropertyListCreateXMLData(IntPtr.Zero, typeRef)).ToByteArray());
        }
        public override string ToString()
        {
            switch (CFLibrary.CFGetTypeID(typeRef))
            {
                case _CFString:                                
                    return CFString();                
                case _CFDictionary:
                    return CFPropertyList();
                case _CFArray:
                    return CFPropertyList();
                case _CFData:
                    return CFData();
                case _CFBoolean:
                    return CFBoolean();
                case _CFNumber:
                    return CFNumber();                
            }
            return null;
        }
        public static implicit operator IntPtr(CFType value)
        {
            return value.typeRef;
        }
        public static implicit operator CFType(IntPtr value)
        {
            return new CFType(value);
        }
    }
}

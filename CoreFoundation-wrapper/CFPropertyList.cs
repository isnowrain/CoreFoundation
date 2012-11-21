// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFoundation
{
    public class CFPropertyList : CFType 
    {
        public CFPropertyList() { }
        public CFPropertyList(IntPtr PropertyList)
            : base(PropertyList)
        {
        }
        public CFPropertyList(string plistlocation) 
        {            
            IntPtr inputfilename;
            inputfilename = new CFString(plistlocation);

            IntPtr ifile_IntPtr = CFLibrary.CFURLCreateWithFileSystemPath(IntPtr.Zero, inputfilename, 2, false);
            IntPtr ifile_CFReadStreamRef = CFLibrary.CFReadStreamCreateWithFile(IntPtr.Zero, ifile_IntPtr);
            if ((CFLibrary.CFReadStreamOpen(ifile_CFReadStreamRef)) == false)
            {
                typeRef = IntPtr.Zero;
            }
            IntPtr PlistRef = CFLibrary.CFPropertyListCreateFromStream(IntPtr.Zero, ifile_CFReadStreamRef, 0, 2, 0, IntPtr.Zero);
            CFLibrary.CFReadStreamClose(ifile_CFReadStreamRef);
            typeRef = PlistRef;
        }

        public static implicit operator CFPropertyList(IntPtr value)
        {
            return new CFPropertyList(value);
        }

        public static implicit operator IntPtr(CFPropertyList value)
        {
            return value.typeRef;
        }

        public static implicit operator string(CFPropertyList value)
        {
            return value.ToString();
        }

        public static implicit operator CFPropertyList(string value)
        {
            return new CFPropertyList(value);
        }               
    }
}

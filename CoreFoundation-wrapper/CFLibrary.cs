// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;

namespace CoreFoundation
{
    public class CFLibrary
    {
        #region CFArray

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CFArrayCreate(IntPtr allocator, IntPtr[] keys , int numValues, IntPtr callbacks);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CFArrayGetCount(IntPtr theArray);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CFArrayGetValueAtIndex(IntPtr theArray, int index);
        #endregion
        #region CFBoolean

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CFBooleanGetValue(IntPtr theBoolean);
        #endregion
        #region CFData

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern int CFDataGetLength(IntPtr theData);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern IntPtr CFDataGetBytePtr(IntPtr theData);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern void CFDataGetBytes(IntPtr theData, CFRange range, IntPtr buffer);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern IntPtr CFDataCreate(IntPtr theAllocator, IntPtr bytes, int bytelength);
        #endregion
        #region CFDictionary

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern IntPtr CFDictionaryGetValue(IntPtr theDict, IntPtr key);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern int CFDictionaryGetCount(IntPtr theDict);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern IntPtr CFDictionaryGetKeysAndValues(IntPtr theDict, IntPtr[] keys, IntPtr[] values);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static   extern IntPtr CFDictionaryCreate(IntPtr allocator, IntPtr[] keys, IntPtr[] values, int numValues, ref CFDictionary.CFDictionaryKeyCallBacks kcall, ref CFDictionary.CFDictionaryValueCallBacks vcall);
        #endregion
        #region CFNumber

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern IntPtr CFNumberCreate(IntPtr theAllocator, CFNumber.CFNumberType theType, int* valuePtr);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern bool CFNumberGetValue(IntPtr theNumber, IntPtr pint, IntPtr valuePtr);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFNumberGetType(IntPtr theNumber);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern int CFNumberGetByteSize(IntPtr theNumber);
        #endregion
        #region CFPropertyList

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern bool CFPropertyListIsValid(IntPtr theList, IntPtr theFormat);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFPropertyListCreateXMLData(IntPtr theAllocator, IntPtr theList);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFPropertyListCreateWithData(IntPtr theAllocator, IntPtr theData, int options, int format,IntPtr errorString);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFPropertyListCreateFromStream(IntPtr allocator,IntPtr stream, int length,int options,int format,IntPtr errorString);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern int CFPropertyListWriteToStream(IntPtr propertyList, IntPtr stream, int format,IntPtr errorString);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern bool CFPropertyListIsValid(IntPtr plist,int format);
        #endregion
        #region CFString

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr __CFStringMakeConstantString(string cstring);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern int CFStringGetLength(IntPtr handle);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFStringGetCharactersPtr(IntPtr handle);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFStringGetCharacters(IntPtr handle, CFRange range, IntPtr buffer);
        #endregion
        #region CFReadStream
        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFReadStreamCreateWithFile(IntPtr alloc, IntPtr fileURL);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern bool CFReadStreamOpen(IntPtr stream);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern void CFReadStreamClose(IntPtr stream);
        #endregion
        #region CFType
        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern int CFGetTypeID(IntPtr typeRef);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]        
        public static  extern IntPtr CFCopyDescription(IntPtr typeRef);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFCopyTypeIDDescription(int typeID);
        #endregion        
        #region CFURL
        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFURLCreateWithFileSystemPath(IntPtr allocator, IntPtr filePath, int pathStyle, bool isDirectory);
        #endregion
        #region CFWriteStream
        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern IntPtr CFWriteStreamCreateWithFile(IntPtr allocator, IntPtr fileURL);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern bool CFWriteStreamOpen(IntPtr stream);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        public static  extern void CFWriteStreamClose(IntPtr stream);
        #endregion
    }
}

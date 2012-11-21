// By iSn0wra1n <isn0wra1ne@gmail.com>

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreFoundation
{
    public class CFNumber : CFType 
    {
        public CFNumber() { }
        public CFNumber(IntPtr Number)
            : base(Number)
        {
        }
        unsafe public CFNumber(int Number) 
        {
            int* pNumber=&Number;
            base.typeRef = CFLibrary.CFNumberCreate(IntPtr.Zero, CFNumberType.kCFNumberIntType, pNumber);
        }       
        public enum CFNumberType 
        { 
            kCFNumberSInt8Type = 1, 
            kCFNumberSInt16Type = 2, 
            kCFNumberSInt32Type = 3, 
            kCFNumberSInt64Type = 4, 
            kCFNumberFloat32Type = 5, 
            kCFNumberFloat64Type = 6, 
            kCFNumberCharType = 7, 
            kCFNumberShortType = 8, 
            kCFNumberIntType = 9, 
            kCFNumberLongType = 10, 
            kCFNumberLongLongType = 11, 
            kCFNumberFloatType = 12, 
            kCFNumberDoubleType = 13, 
            kCFNumberCFIndexType = 14, 
            kCFNumberNSIntegerType = 15,            
            kCFNumberCGFloatType = 16, 
            kCFNumberMaxType = 16 
        };        
           
        }
    }


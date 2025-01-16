using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canon_13_12_10_90D
{
    public enum ISO:uint
    {
        i100=0x48,
        i200=0x50,
        i400=0x58,
        i800=0x60,
        i1600=0x68
    }

    public enum AV : uint
    {
        a2_5=0x1C,
        a3_2 =0x23,
        a4_0=0x28,
        a5=0x2D,
        a5_6=0x30,
        a6_3=0x33,
        a7_1=0x35,
        a8_0=0x38,
        a9_0=0x3B,
        a10=0x3D,
        a13=0x44,
        a16=0x48,
        a18=0x4B,
        a20=0x4D,
        a25=0x53,
        a29=0x55,
        a32=0x58
    }

    public enum TV : uint
    {
        ts30=0x10,
        ts25=0x13,
        ts20=0x14,
        ts15=0x18,
        ts10=0x1c,
        ts8=0x20,
        ts6=0x24,
        ts4=0x28,
        ts3_2=0x2b,
        ts2_5=0x2d,
        ts2=0x30,
        ts1_6=0x33,
        ts1=0x38,
        ts0_8=0x3b,
        ts0_6=0x3d,
        ts0_4=0x43,
        
        t1_4=0x48,
        t1_8=0x50,
        t1_10=0x53,
        t1_25=0x5d,
        t1_30=0x60,
        t1_40=0x63,
        t1_50=0x65,
        t1_60=0x68,
        t1_80=0x6b,
        t1_100=0x6d,
        t1_125=0x70,
        t1_160=0x73,
        t1_200=0x75,
        t1_250=0x78,
        t1_320=0x7b,
        t1_400=0x7d,
        t1_500=0x80,
        t1_640=0x83,
        t1_800=0x85
    }
}

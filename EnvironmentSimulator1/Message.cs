using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSimulator1
{
    public class Message
    {

        [Serializable]//指示可以序列化
        [StructLayout(LayoutKind.Sequential, Pack = 1)]//按1字节对齐
        public struct VOBCtoESStruct  //ES收到VOBC的信息
        {
            public byte START1;//高位
            public byte START2;//地位
            public byte UPDOWN;
            public byte type;

            public int Train_ID;
            public byte Train_Dir;
            public int Train_X;
            public int Train_Y;


            public byte end1;//高位
            public byte end2;//地位

        }//struct


        [Serializable]//指示可以序列化
        [StructLayout(LayoutKind.Sequential, Pack = 1)]//按1字节对齐
        public struct OCtoESStruct  //ES收到OC的信息
        {
            public byte START1;//高位
            public byte START2;//地位
            public byte UPDOWN;
            public byte type;

            public byte Source_Type;
            public byte Source_ID12;
            public byte Source_ID34;
            public byte Source_ID56;
            public byte Source_Ctrl;


            public byte end1;//高位
            public byte end2;//地位

        }//struct

        [Serializable]//指示可以序列化
        [StructLayout(LayoutKind.Sequential, Pack = 1)]//按1字节对齐
        public struct EStoOCStruct  //ES回执给OC的信息
        {
            public byte START1;//高位
            public byte START2;//地位
            public byte UPDOWN;
            public byte type;//0xF7发状态,0xF8发控制结果

            public byte Source_Type;
            public byte Source_ID12;
            public byte Source_ID34;
            public byte Source_ID56;
            public byte Source_Ctrl;


            public byte end1;//高位
            public byte end2;//地位

        }//struct
        public byte[] ETOStacmd(byte Rtype, byte[] n12, byte Rcontrol)
        {
            EStoOCStruct ETO = new EStoOCStruct();
            ETO.START1 = 0xFF;
            ETO.START2 = 0xFF;
            ETO.UPDOWN = 0xFF;
            ETO.type = 0xF7;
            ETO.Source_Type = Rtype;
            ETO.Source_ID12 = n12[0];
            ETO.Source_ID34 = n12[1];
            ETO.Source_ID56 = n12[2];
            ETO.Source_Ctrl = Rcontrol;
            ETO.end1 = 0xFF;
            ETO.end2 = 0xFF;
            byte[] bytes = structANDbyte.StructToBytes(ETO);
            return bytes;
        }

        public byte[] ETORescmd(byte Rtype, byte[] n12, byte Rcontrol)
        {
            EStoOCStruct ETO = new EStoOCStruct();
            ETO.START1 = 0xFF;
            ETO.START2 = 0xFF;
            ETO.UPDOWN = 0xFF;
            ETO.type = 0xF8;
            ETO.Source_Type = Rtype;
            ETO.Source_ID12 = n12[0];
            ETO.Source_ID34 = n12[1];
            ETO.Source_ID56 = n12[2];
            ETO.Source_Ctrl = Rcontrol;
            ETO.end1 = 0xFF;
            ETO.end2 = 0xFF;
            byte[] bytes = structANDbyte.StructToBytes(ETO);
            return bytes;
        }

        [Serializable]//指示可以序列化
        [StructLayout(LayoutKind.Sequential, Pack = 1)]//按1字节对齐
        public struct EStoATSStruct  //ES回执给OC的信息
        {
            public byte START1;//高位
            public byte START2;//地位
            public byte UPDOWN;
            public byte type;//0xF7

            public byte Source_Type;
            public byte Source_ID12;
            public byte Source_ID34;
            public byte Source_ID56;
            public byte Source_Ctrl;

            public byte end1;//高位
            public byte end2;//地位

        }//struct
        public byte[] ETAcmd(byte Rtype, byte[] n12, byte Rcontrol)
        {
            EStoOCStruct ETO = new EStoOCStruct();
            ETO.START1 = 0xFF;
            ETO.START2 = 0xFF;
            ETO.UPDOWN = 0xFF;
            ETO.type = 0xF5;
            ETO.Source_Type = Rtype;
            ETO.Source_ID12 = n12[0];
            ETO.Source_ID34 = n12[1];
            ETO.Source_ID56 = n12[2];
            ETO.Source_Ctrl = Rcontrol;
            ETO.end1 = 0xFF;
            ETO.end2 = 0xFF;
            byte[] bytes = structANDbyte.StructToBytes(ETO);
            return bytes;
        }
       
    }
}

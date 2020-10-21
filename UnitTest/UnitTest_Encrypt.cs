using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mir.Commons.Encrypt;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class UnitTest_Encrypt
    {
        [TestMethod]
        public void TestBase64()
        {
            //默认Base64加密
            string s1 = Base64Helper.Encode("12345");

            //自定义编码Base64加密
            string s2 = Base64Helper.EncodeBase64("12345", Encoding.Unicode);

            //默认Base64解密
            string d1 = Base64Helper.Decode(s1);

            //自定义编码Base解密
            string d2 = Base64Helper.DecodeBase64(s2, Encoding.Unicode);
        }

        [TestMethod]
        public void TestMd5()
        {
            string s1 = MD5Helper.MD5("123456");
            string s2 = MD5Helper.FileMD5Buffer("D:\\report_data2.txt");
        }

        [TestMethod]
        public void TestAscii()
        {
            string str = "你hello";
            byte[] array = new byte[1];
            array = System.Text.Encoding.Default.GetBytes(str); //把str的每个字符转换成ascii码
            string textAscii = string.Empty;//用来存储转换过后的ASCII码

            for (int i = 0; i < array.Length; i++)
            {
                textAscii += array[i].ToString("X") + " ";
            }
        }
    }
}

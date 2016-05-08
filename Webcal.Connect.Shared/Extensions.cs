namespace Connect.Shared
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public static class Extensions
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T) attributes[0] : null;
        }

        public static byte[] ToByteArray(this Image imageIn)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    imageIn.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {
                //Generic GDI+ error ... no point in logging as the error is meaningless
            }

            return null;
        }

        public static Image ToImage(this byte[] rawData)
        {
            using (var ms = new MemoryStream(rawData))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
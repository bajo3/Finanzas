namespace Finanzas.Infrastructure
{
    public static class ExtensionsMethods
    {
        public static string ToEnumText<T>(this T tipoEnum) where T : struct
        {
            return tipoEnum.ToString();
        }
    }
}

//using NUlid;
//using System.ComponentModel;

//namespace Softtek.Webapi.Converters
//{
//    public class UlidTypeConverter : TypeConverter
//    {
//        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
//            => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

//        public override object? ConvertFrom(ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value)
//        {
//            if (value is string s && Ulid.TryParse(s, out var result))
//                return result;

//            throw new FormatException("Código Ulid inválido.");
//        }
//    }

//    [TypeConverter(typeof(UlidTypeConverter))]
//    public readonly struct UlidBindable
//    {
//        public Ulid Value { get; }

//        public UlidBindable(Ulid value)
//        {
//            Value = value;
//        }

//        public static implicit operator Ulid(UlidBindable u) => u.Value;
//        public static implicit operator UlidBindable(Ulid u) => new UlidBindable(u);

//        public override string ToString() => Value.ToString();
//    }
//}

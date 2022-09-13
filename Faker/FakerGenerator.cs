using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class FakerGenerator
    {
        // public method for usege
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        // private method for proceeding
        private object Create(Type t)
        {
            var instance = CreateInstance(t);


            Type doubleType = typeof(double);
            Type intType = typeof(int);
            Type boolType = typeof(bool);
            Type longType = typeof(long);
            Type floatType = typeof(float);
            Type byteType = typeof(byte);
            Type charType = typeof(char);
            Type shortType = typeof(short);
            Type decimalType = typeof(decimal);
            Type stringType = typeof(string);








            StringBuilder sb = new StringBuilder("");

            return null;
        }








        private object CreateInstance(Type t)
        {
            if (t.IsValueType)
                // Для типов-значений вызов конструктора по умолчанию даст default(T).
                return Activator.CreateInstance(t);
            else
                // Для ссылочных типов значение по умолчанию всегда null.
                return null;
        }






        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            var sb = new StringBuilder(string.Empty);

            for (int i = 0; i < length; i++)
            {
                sb.Append(Convert.ToChar(random.Next(97, 123)));
            }

            return sb.ToString();
        }

        private int GenerateRandomIntegerNumber()
        {
            Random random = new Random();
            return random.Next(0, int.MaxValue);
        }

        private double GenerateRandomDoubleNumber()
        {
            Random random = new Random();
            return random.NextDouble() + random.Next(0, int.MaxValue);
        }

        private bool GenerateRandomBoolValue()
        {
            Random random = new Random();
            int intBool = random.Next(0,2);

            if (intBool == 1)
                return true;
            else
                return false;
        }

        private long GenerateRandomLongNumber()
        {
            return GenerateRandomIntegerNumber();
        }

        private float GenerateRandomFloatNumber()
        {
            Random random = new Random();
            return (float)(random.NextDouble() + random.Next(0, int.MaxValue));
        }

        private byte GenerateRandomByteNumber()
        {
            Random random = new Random();
            return (byte)random.Next(0, 256);
        }

        private char GenerateRandomCharValue()
        {
            Random random = new Random();
            char result = Convert.ToChar(random.Next(97, 123));

            bool append = GenerateRandomBoolValue();

            if (append)
                return Convert.ToChar(result.ToString().ToUpper());
            else
                return result;
        }

        private short GenerateRandomShortNumber()
        {
            Random random = new Random();
            return (short)random.Next(0, short.MaxValue);
        }

        private decimal GenerateRandomDecimalNumber()
        {
            Random random = new Random();
            return (decimal)GenerateRandomDoubleNumber();
        }
    }
}

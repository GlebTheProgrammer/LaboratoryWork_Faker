using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Faker
{
    public class FakerGenerator
    {
        // public method for usege
        public T Create<T>()
        {
            Thread.Sleep(1);
            return (T)Create(typeof(T));
        }

        // private method for proceeding
        private object Create(Type t)
        {
            if (t.IsValueType)
            {
                return GenerateInstanceWithValueTypeVariable(t);
            }
            else
            {
                // If our reference type is a string - return a randomly generated string
                if (t.IsSerializable && t.IsSecurityTransparent && t.IsSealed && !t.IsSecurityCritical)
                    return GenerateInstanceWithAStringValue(t,10);

                // If our reference type is a generic type - create a generic variable
                if (t.IsGenericType)
                    return GenerateInstanceWithAGenericTypeVariable(t);

                return GenerateInstanceWithAClassTypeVariable(t);
            }
        }







        // Method wich will generate a value type variable
        private object GenerateInstanceWithValueTypeVariable(Type t)
        {
            Thread.Sleep(1);
            var instance = CreateInstance(t);

            var valueTypeGeneratorMethods = GetAllValueTypesGeneratorMethodsName();
            foreach (var item in valueTypeGeneratorMethods)
            {
                var temp = GetType().GetMethod(item, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, new object[] { });

                if (t != temp.GetType())
                    continue;
                else
                {
                    instance = temp;
                    return instance;
                }

            }
            throw new Exception("Error. Value type was not created.");
        }

        // Method wich will generate a string variable
        private object GenerateInstanceWithAStringValue(Type t, byte strLength)
        {
            Thread.Sleep(1);
            var instance = CreateInstance(t);

            try
            {
                instance = GenerateRandomString(strLength);
                return instance;
            }
            catch (Exception)
            {
                throw new Exception("Error. String type was not created.");
            }
            
        }

        // Method wich will generate a generic variable
        private object GenerateInstanceWithAGenericTypeVariable(Type t)
        {
            Thread.Sleep(1);

            var instance = (IList)Activator.CreateInstance(t);

            var genericTypeInsideVariable = t.GenericTypeArguments.FirstOrDefault();

            instance = GenerateRandomList(genericTypeInsideVariable, instance, 5);

            return instance;
        }

        // Method wich will generate a class variable
        private object GenerateInstanceWithAClassTypeVariable(Type t)
        {
            var maxParamConstructor = FindAConstructorWithMaxParametersNumber(t);
            var parameters = GenerateParamsForAClassTypeVariables(t);

            // Generating an object with a random data 
            var randomlyGeneratedObject = maxParamConstructor.Invoke(parameters);

            var propertyInfos = randomlyGeneratedObject.GetType().GetProperties().Where(p => !p.SetMethod.IsPrivate).ToList();

            for (int i = 0; i < propertyInfos.Count; i++)
            {
                var generatedObjectType = randomlyGeneratedObject.GetType();
                var objectPropertyTakenByName = generatedObjectType.GetProperty(propertyInfos[i].Name);

                var objectPropertyType = objectPropertyTakenByName.GetValue(randomlyGeneratedObject).GetType();
                var generatedProperty = this.Create(objectPropertyType);

                objectPropertyTakenByName.SetValue(randomlyGeneratedObject,
                generatedProperty, null);

            }

            // Return created object
            return randomlyGeneratedObject;
        }
        private object[] GenerateParamsForAClassTypeVariables(Type t)
        {
            ConstructorInfo maxParamConstructor = FindAConstructorWithMaxParametersNumber(t);

            // Getting its parameters information
            ParameterInfo[] parametersInfo = maxParamConstructor.GetParameters();

            // Generating an array wich will have random generated parameters to create a new object Type t
            object[] parameters = new object[parametersInfo.Length];

            // Filling array of object with a random data using the recursion
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = this.Create(parametersInfo[i].ParameterType);
            }

            return parameters;
        }
        private ConstructorInfo FindAConstructorWithMaxParametersNumber(Type t)
        {
            // Getting all class constructors
            var constructorInfoObjects = t.GetConstructors();

            // Looking for constructor with the biggest number of parameters
            int ctorParametersLength = 0;
            byte ctorIndex = 0;
            byte counter = 0;
            foreach (var constructor in constructorInfoObjects)
            {
                if (constructor.GetParameters().Length > ctorParametersLength)
                {
                    ctorIndex = counter;
                    ctorParametersLength = constructor.GetParameters().Length;
                }
                counter++;
            }

            // Getting constructor with the biggest number of parameters
            var maxParamConstructor = constructorInfoObjects.Where(c => c.GetParameters().Length == ctorParametersLength).First();

            return maxParamConstructor;
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


        // Methods wich generate random value type variables
        private int GenerateRandomIntegerNumber()
        {
            Random random = new Random();
            return random.Next(int.MinValue, int.MaxValue);
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
            Random random = new Random();
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }
        private float GenerateRandomFloatNumber()
        {
            Random random = new Random();

            var array = new byte[4];
            random.NextBytes(array);

            return BitConverter.ToSingle(array, 0);
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
            return (short)random.Next(short.MinValue, short.MaxValue);
        }
        private decimal GenerateRandomDecimalNumber()
        {
            Random random = new Random();
            return (decimal)GenerateRandomDoubleNumber();
        }

        // Methods wich will generate random data with a generic variables

        private IList GenerateRandomList(Type t, IList emptyList, int countOfTheVariablesInside)
        {
            for (int i = 0; i < countOfTheVariablesInside; i++)
            {
                object variable;
                var sortedCtors = t.GetConstructors().ToList();
                sortedCtors.Sort((x, y) => x.GetParameters().Length.CompareTo(y.GetParameters().Length));
                var ctor = sortedCtors.FirstOrDefault();

                if (ctor == null || ctor.GetParameters().Length == 0)
                {
                    variable = Activator.CreateInstance(t);
                }
                else
                {
                    variable = Activator.CreateInstance(t, GenerateParamsForAClassTypeVariables(t));
                }
               

                
              

                var createdItem = Convert.ChangeType(this.Create(t), t);

                emptyList.Add(createdItem);
            }    
            return emptyList;
        }

        // Making a list of all methods wich output is a value type variable
        private List<string> GetAllValueTypesGeneratorMethodsName()
        {
            List<string> result = new List<string>();

            result.Add(nameof(GenerateRandomDoubleNumber));
            result.Add(nameof(GenerateRandomDecimalNumber));
            result.Add(nameof(GenerateRandomFloatNumber));
            result.Add(nameof(GenerateRandomLongNumber));
            result.Add(nameof(GenerateRandomIntegerNumber));
            result.Add(nameof(GenerateRandomShortNumber));
            result.Add(nameof(GenerateRandomCharValue));
            result.Add(nameof(GenerateRandomByteNumber));
            result.Add(nameof(GenerateRandomBoolValue));

            return result;
        }

    }
}

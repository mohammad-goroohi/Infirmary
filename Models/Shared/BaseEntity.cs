using System.Reflection.Emit;
using System.Reflection;

namespace Infirmary.Models.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }




        public static object CreateDynamicEntity(string typeName, Dictionary<string, Type> properties)
        {
            var assemblyName = new AssemblyName(typeof(Program).Assembly.FullName);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            // تعریف کلاسی که از BaseEntity ارث می‌برد
            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public, typeof(BaseEntity));

            foreach (var prop in properties)
            {
                CreateProperty(typeBuilder, prop.Key, prop.Value);
            }

            var dynamicType = typeBuilder.CreateType();
            return Activator.CreateInstance(dynamicType);
        }

        private static void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
        {
            var fieldBuilder = typeBuilder.DefineField("_" + propertyName.ToLower(), propertyType, FieldAttributes.Private);
            var propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            // تعریف متد Getter
            var getMethodBuilder = typeBuilder.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            var getIl = getMethodBuilder.GetILGenerator();
            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            // تعریف متد Setter
            var setMethodBuilder = typeBuilder.DefineMethod("set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { propertyType });
            var setIl = setMethodBuilder.GetILGenerator();
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);
        }
    }
}

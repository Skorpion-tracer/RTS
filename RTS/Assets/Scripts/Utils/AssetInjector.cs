using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assets.Scripts.Utils
{
    public static class AssetInjector
    {
        private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);
        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();
            var baseType = targetType.BaseType;

            if (baseType != typeof(object))
            {
                var allFieldsBase = baseType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                
                for (int i = 0; i < allFieldsBase.Length; i++)
                {
                    var fieldInfo = allFieldsBase[i];
                    var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
                    if (injectAssetAttribute == null)
                    {
                        continue;
                    }

                    var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                    fieldInfo.SetValue(target, objectToInject);
                }

                return target;
            }

            var allFields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < allFields.Length; i++)
            {
                var fieldInfo = allFields[i];
                var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
                if (injectAssetAttribute == null)
                {
                    continue;
                }

                var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                fieldInfo.SetValue(target, objectToInject);
            }

            return target;
        }
    }
}

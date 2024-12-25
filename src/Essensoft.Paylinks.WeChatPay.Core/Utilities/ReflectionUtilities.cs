using System.Collections;
using System.Reflection;

namespace Essensoft.Paylinks.WeChatPay.Core.Utilities;

public static class ReflectionUtilities
{
    public delegate (bool IsModified, string NewString) ReplaceStringDelegate(PropertyInfo? currentProperty, string currentString);

    public static void ReplaceObjectString<T>(T currentObject, ReplaceStringDelegate replaceDelegate) where T : class
    {
        InternalReplaceObjectString(ref currentObject, null, replaceDelegate);
    }

    private static void InternalReplaceObjectString<T>(ref T currentObject, PropertyInfo? currentProperty, ReplaceStringDelegate replaceDelegate) where T : class
    {
        var type = currentObject.GetType();
        if (!type.IsClass)
        {
            return;
        }

        if (type.IsArray)
        {
            if (currentObject is Array currentArrayObject)
            {
                for (var i = 0; i < currentArrayObject.Length; i++)
                {
                    var currentArrayItem = currentArrayObject.GetValue(i);
                    if (currentArrayItem is string currentStr)
                    {
                        if (currentArrayObject.IsReadOnly || string.IsNullOrEmpty(currentStr))
                        {
                            continue;
                        }

                        var result = replaceDelegate(currentProperty, currentStr);
                        if (result.IsModified)
                        {
                            currentArrayObject.SetValue(result.NewString, i);
                        }
                    }
                    else if (currentArrayItem is not null)
                    {
                        InternalReplaceObjectString(ref currentArrayItem, currentProperty, replaceDelegate);
                    }
                }
            }

            return;
        }

        if (type.IsGenericType)
        {
            if (currentObject is IList currentListObject)
            {
                for (var i = 0; i < currentListObject.Count; i++)
                {
                    var currentListItem = currentListObject[i];
                    if (currentListItem is string currentStr)
                    {
                        if (currentListObject.IsReadOnly || string.IsNullOrEmpty(currentStr))
                        {
                            continue;
                        }

                        var result = replaceDelegate(currentProperty, currentStr);
                        if (result.IsModified)
                        {
                            currentListObject[i] = result.NewString;
                        }
                    }
                    else if (currentListItem is not null)
                    {
                        InternalReplaceObjectString(ref currentListItem, currentProperty, replaceDelegate);
                    }
                }
            }

            return;
        }

        foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p is { CanRead: true, CanWrite: true }).ToArray())
        {
            var propertyType = property.PropertyType;
            if (propertyType == typeof(string))
            {
                if (property.GetValue(currentObject) is string currentStr)
                {
                    if (string.IsNullOrEmpty(currentStr))
                    {
                        continue;
                    }

                    var result = replaceDelegate(property, currentStr);
                    if (result.IsModified)
                    {
                        property.SetValue(currentObject, result.NewString);
                    }
                }
            }
            else
            {
                var subObj = property.GetValue(currentObject);
                if (subObj is not null)
                {
                    InternalReplaceObjectString(ref subObj, property, replaceDelegate);
                }
            }
        }
    }
}

using System.Reflection;
namespace RMC.Core.Utilities
{
    /// <summary>
    /// Helper Methods
    /// </summary>
    public static class ReflectionUtility
    {

        // Fields -----------------------------------------


        // General Methods --------------------------------

        /// <summary>
        /// Set a value on an instance field. Works even for private fields
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <param name="bindingFlags"></param>
        /// <typeparam name="T"></typeparam>
        public static void SetFieldValue<T>(T instance, string fieldName, object fieldValue, BindingFlags bindingFlags)
        {
            var field = typeof(T).GetField(fieldName, bindingFlags);
            field.SetValue(instance, fieldValue);
        }
    }
}
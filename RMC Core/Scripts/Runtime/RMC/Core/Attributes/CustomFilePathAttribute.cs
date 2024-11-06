using System;
using RMC.Core.Exceptions;
using UnityEngine;

namespace RMC.Core.Components.Attributes
{
    /// <summary>
    /// Determines root of relative pathing 
    /// </summary>
    public enum CustomFilePathLocation
    {
        PersistentDataPath,
        StreamingAssetsPath
    }

    /// <summary>
    /// Used to add relative paths to objects. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomFilePathAttribute : Attribute
    {
        // Properties ------------------------------------
        public string Filepath => filepath;
        public CustomFilePathLocation Location => m_Location;

        private string filepath
        {
            get
            {
                if (m_FilePath == null && m_RelativePath != null)
                {
                    m_FilePath = CombineFilePath(m_RelativePath, m_Location);
                    m_RelativePath = null;
                }

                return m_FilePath;
            }
        }

        // Fields ----------------------------------------
        private string m_FilePath;
        private string m_RelativePath;
        private CustomFilePathLocation m_Location;

        // Initialization Methods -------------------------
        public CustomFilePathAttribute(string relativePath, CustomFilePathLocation location)
        {
            m_RelativePath = !string.IsNullOrEmpty(relativePath)
                ? relativePath
                : throw new ArgumentException("Invalid relative path (it is empty)");
            m_Location = location;
        }

        // General Methods --------------------------------

        private static string CombineFilePath(string relativePath, CustomFilePathLocation location)
        {
            if (relativePath[0] == '/')
                relativePath = relativePath.Substring(1);

            return location switch
            {
                CustomFilePathLocation.PersistentDataPath => Application.persistentDataPath + "/" + relativePath,
                CustomFilePathLocation.StreamingAssetsPath => Application.streamingAssetsPath + "/" + relativePath,
                _ => throw new SwitchDefaultException(location)
            };
        }

        // GetCustomFilePathAttribute with generic type
        public static CustomFilePathAttribute GetCustomFilePathAttribute<T>()
        {
            return GetCustomFilePathAttribute(typeof(T));
        }

        // GetCustomFilePathAttribute with non-generic type
        public static CustomFilePathAttribute GetCustomFilePathAttribute(Type type)
        {
            while (type != null && type != typeof(object))
            {
                object[] attributes = type.GetCustomAttributes(true);
                foreach (object attribute in attributes)
                {
                    if (attribute is CustomFilePathAttribute customFilePathAttribute)
                    {
                        return customFilePathAttribute;
                    }
                }

                // Traverse up the class hierarchy, but ignore interfaces for attribute lookup
                type = type.BaseType;
            }

            return null;
        }
    }
}

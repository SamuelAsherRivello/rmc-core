using System;
using System.IO;
using RMC.Core.Components.Attributes;
using RMC.Core.DesignPatterns.Creational.Singletons;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif //UNITY_EDITOR

#pragma warning disable CS0414
namespace RMC.Core.Data.Types.Storage   
{
    public sealed class LocalDiskStorage : Singleton<LocalDiskStorage>, ISingletonParent
    {
        // Properties ------------------------------------
        public const string Title = "LocalDiskStorage";

        public static readonly string NotSupportedWarning =
            "LocalDiskStorage is supported in Unity Editor but not in a WebGL Build. (File system restrictions)";

        private static bool HasWarnedOnce = false; //once per runtime session

        // Initialization Methods -------------------------
        public LocalDiskStorage()
        {
            // Avoid using constructor for initialization
        }

        void ISingletonParent.OnInstantiatedChild()
        {
            // Use this for initialization
        }

        public bool IsSupportedOnCurrentPlatform()
        {
#if UNITY_WEBGL
#if UNITY_EDITOR
#endif
            return false;
#else
    return true;
#endif
            
        }

        private void RequireIsSupportedOnCurrentPlatform()
        {
            if (!IsSupportedOnCurrentPlatform())
            {
                if (!LocalDiskStorage.HasWarnedOnce)
                {
                    Debug.LogWarning(LocalDiskStorage.NotSupportedWarning);
                    LocalDiskStorage.HasWarnedOnce = true;
                }
               
     
            }
        }
        
        // General Methods --------------------------------

        // Save with generic type
        public bool Save<T>(T obj)
        {
            return Save(obj, true);
        }

        public bool Save<T>(T obj, bool willOverwrite)
        {
            return Save(typeof(T), obj, willOverwrite);
        }

        // Save with non-generic type
        public bool Save(Type type, object obj, bool willOverwrite = true)
        {
            RequireIsSupportedOnCurrentPlatform();
            
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe(type);

            CreateDirectorySafe(customFilePathAttribute.Filepath);
            string json = JsonUtility.ToJson(obj, true);

            bool isSuccess = false;
            if (!willOverwrite && File.Exists(customFilePathAttribute.Filepath))
            {
                Debug.LogWarning($"LocalDiskStorage.Save() failed. File already exists and willOverwrite = {willOverwrite}.");
            }
            else
            {
                File.WriteAllText(customFilePathAttribute.Filepath, json);
                isSuccess = !string.IsNullOrEmpty(json);

#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif
            }

            return isSuccess;
        }

        // Delete with generic type
        public bool Delete<T>()
        {
            return Delete(typeof(T));
        }

        // Delete with non-generic type
        public bool Delete(Type type)
        {
            RequireIsSupportedOnCurrentPlatform();
            
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe(type);

            if (customFilePathAttribute == null)
            {
                Debug.LogWarning($"LocalDiskStorage.Delete() failed. Path must be NOT null. Type = {type.Name}");
                return false;
            }

            if (!Has(type))
            {
                Debug.LogWarning($"LocalDiskStorage.Delete() failed. Has<{type.Name}>() must be true. Path={customFilePathAttribute.Filepath}");
                return false;
            }

            bool isSuccess = false;
            const string MetaExtension = ".meta";
            string[] paths = new[]
            {
                customFilePathAttribute.Filepath,
                customFilePathAttribute.Filepath + MetaExtension
            };

            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    isSuccess = true;
                }
                else if (!path.ToLower().Contains(MetaExtension))
                {
                    Debug.LogWarning($"LocalDiskStorage.Delete() failed. File must already exist. Path={path}");
                }
            }

            if (isSuccess)
            {
#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif //UNITY_EDITOR
            }

            return isSuccess;
        }

        // Has with generic type
        public bool Has<T>()
        {
            return Has(typeof(T));
        }

        // Has with non-generic type
        public bool Has(Type type)
        {
            RequireIsSupportedOnCurrentPlatform();
            return LoadWithoutValidation(type) != null;
        }

        // Load with generic type
        public T Load<T>()
        {
            return (T)Load(typeof(T));
        }

        // Load with non-generic type
        public object Load(Type type)
        {
            RequireIsSupportedOnCurrentPlatform();
            
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe(type);

            if (string.IsNullOrEmpty(customFilePathAttribute.Filepath))
            {
                throw new Exception($"LocalDiskStorage.Load() failed. [CustomFilePathAttribute (Filepath = {customFilePathAttribute.Filepath})] is invalid for {type.Name}.");
            }

            if (!File.Exists(customFilePathAttribute.Filepath))
            {
                throw new Exception($"LocalDiskStorage.Load() failed. Call LocalDiskStorage.Has<{type.Name}>() beforehand.");
            }

            string json = File.ReadAllText(customFilePathAttribute.Filepath);
            return JsonUtility.FromJson(json, type);
        }
        
        
        // LoadWithoutValidation with generic type
        private T LoadWithoutValidation<T>()
        {
            return (T)LoadWithoutValidation(typeof(T));
        }

        // LoadWithoutValidation with non-generic type
        private object LoadWithoutValidation(Type type)
        {
            CustomFilePathAttribute customFilePathAttribute = GetCustomFilePathAttributeSafe(type);
            if (!File.Exists(customFilePathAttribute.Filepath))
            {
                return null;
            }
            string json = File.ReadAllText(customFilePathAttribute.Filepath);
            return JsonUtility.FromJson(json, type);
        }

        // GetCustomFilePathAttributeSafe with generic type
        private CustomFilePathAttribute GetCustomFilePathAttributeSafe<T>()
        {
            return GetCustomFilePathAttributeSafe(typeof(T));
        }

        // GetCustomFilePathAttributeSafe with non-generic type
        private CustomFilePathAttribute GetCustomFilePathAttributeSafe(Type type)
        {
            CustomFilePathAttribute customFilePathAttribute = CustomFilePathAttribute.GetCustomFilePathAttribute(type);
            if (customFilePathAttribute == null)
            {
                throw new Exception($"LocalDiskStorage method failed. Add [CustomFilePathAttribute] to {type.Name}.");
            }

            return customFilePathAttribute;
        }


        private void CreateDirectorySafe(string filepath)
        {
            string directoryPath = Path.GetDirectoryName(filepath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}

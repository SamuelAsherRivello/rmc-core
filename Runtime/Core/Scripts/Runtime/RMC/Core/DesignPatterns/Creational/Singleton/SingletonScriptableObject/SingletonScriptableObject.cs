using RMC.Core.Components.Attributes;
using UnityEngine;

namespace RMC.Core.DesignPatterns.Creational.Singleton.SingletonScriptableObject
{

    //TODO: Add to Moralis Web3 Unity SDK - srivello
    /// <summary>
    /// Unity offers https://docs.unity3d.com/2020.1/Documentation/ScriptReference/ScriptableSingleton_1.html
    /// but it was throwing "ScriptableSingleton already exists. Did you query the singleton in a constructor?"
    /// So here is a custom implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Instance must be manually created by developer via [MenuItem] and put any /Resources/ folder.
                    T[] results = Resources.FindObjectsOfTypeAll<T>();
                    
                    if (results.Length > 1)
                    {
                        //Fix the code if this happens
                        Debug.LogError("SingletonScriptableObject: Results length is greater than 1 of " +
                                                    typeof(T).ToString() + " too many in project. Delete all but 1.");
                        return null;
                    }
                    
                    if (results.Length == 1)
                    {
                        _instance = results[0];
                    }
                    
                    if (results.Length == 0)
                    {
                        _instance = Instantiate();
                    }

                    _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                }

                return _instance;
            }
        }
        
        protected static T Instantiate()
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(typeof(T));
            string guid = string.Empty;
            for (int i = 0; i < attrs.Length; i++)
            {
                ReferenceByGuidAttribute filePathAttribute = attrs[i] as ReferenceByGuidAttribute;
                if (filePathAttribute != null)
                {
                    guid = filePathAttribute.Guid;
                }
            }
        
            if (string.IsNullOrEmpty(guid))
            {
                Debug.LogError("Add [ReferenceByGuidAttribute] to child object and include accurate Guid value.");
            }


            T[] instances = Resources.LoadAll<T>("");
            return instances[0];
        }
    }
}
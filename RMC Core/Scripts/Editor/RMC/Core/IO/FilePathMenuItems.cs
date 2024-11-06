using System.IO;
using RMC.Core.Data.Types;
using UnityEditor;
using UnityEngine;

namespace RMC.Core.IO
{
    public static class FilePathMenuItems
    {
        private const string FilePath = "FilePaths";

        [MenuItem(CoreConstants.PathCoreWindowMenu + FilePath + "/Open Folder: StreamingAssets", priority = CoreConstants.PriorityTools_Primary)]
        public static void OpenFolderStreamingAssets()
        {
            Debug.Log($"OpenFolderStreamingAssets() {Application.streamingAssetsPath}");
            Application.OpenURL(Application.streamingAssetsPath);
        }

        [MenuItem(CoreConstants.PathCoreWindowMenu + FilePath + "/Open Folder: PersistentDataPath", priority = CoreConstants.PriorityTools_Primary + 1)]
        public static void OpenFolderPersistentDataPath()
        {
            Debug.Log($"OpenFolderPersistentDataPath() {Application.persistentDataPath}");
            Application.OpenURL(Application.persistentDataPath);
        }

        [MenuItem(CoreConstants.PathCoreWindowMenu + FilePath + "/Open Folder: DataPath", priority = CoreConstants.PriorityTools_Primary + 2)]
        public static void OpenFolderDataPath()
        {
            Debug.Log($"OpenFolderDataPath() {Application.dataPath}");
            Application.OpenURL(Application.dataPath);
        }

        [MenuItem(CoreConstants.PathCoreWindowMenu + FilePath + "/Open Folder: TemporaryCachePath", priority = CoreConstants.PriorityTools_Primary + 3)]
        public static void OpenFolderTemporaryCachePath()
        {
            Debug.Log($"OpenFolderTemporaryCachePath() {Application.temporaryCachePath}");
            Application.OpenURL(Application.temporaryCachePath);
        }

        // Open PlayerPrefs folder
        [MenuItem(CoreConstants.PathCoreWindowMenu + FilePath + "/Open Folder: PlayerPrefs", priority = CoreConstants.PriorityTools_Primary + 4)]
        public static void OpenFolderPlayerPrefs()
        {
            string prefsPath = "";
            
            #if UNITY_EDITOR_WIN
                prefsPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Unity");
            #elif UNITY_EDITOR_OSX
                prefsPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Library", "Preferences", "unity." + Application.companyName + "." + Application.productName + ".plist");
            #else
                Debug.LogWarning("PlayerPrefs folder not accessible on this platform through Unity.");
                return;
            #endif

            if (Directory.Exists(prefsPath))
            {
                Debug.Log($"OpenFolderPlayerPrefs() {prefsPath}");
                Application.OpenURL(prefsPath);
            }
            else
            {
                Debug.LogWarning($"PlayerPrefs folder does not exist at path: {prefsPath}");
            }
        }
        
        // Manage PlayerPrefs
        [MenuItem(CoreConstants.PathCoreWindowMenu + FilePath + "/PlayerPrefs: Clear All", priority = CoreConstants.PriorityTools_Primary + 50)]
        public static void ClearAllPlayerPrefs()
        {
            Debug.Log("Clearing all PlayerPrefs.");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}

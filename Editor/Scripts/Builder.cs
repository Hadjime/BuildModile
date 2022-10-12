using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace GRV.BuildModule.Editor.Scripts
{
    public static class Builder
    {
        [MenuItem("Build/BuildAndroidProject")]
        public static void BuildAndroidProject()
        {
            var folderName = "BuildAndroid";
            DeleteFolder (folderName);
            CreateFolder (folderName);
            BuildReport error = BuildPipeline.BuildPlayer(GetScenes(), folderName, BuildTarget.Android, BuildOptions.None);
            if (error != null)
            {
                throw new Exception("Build failed: " + error);
            }
        }

        private static void CreateFolder(string name)
        {
            if (!Directory.Exists(name))
            {
                Directory.CreateDirectory(name);
            }
        }

        private static void DeleteFolder(string name)
        {
            if (Directory.Exists(name))
            {
                Directory.Delete(name, true);
            }
        }

        private static string[] GetScenes()
        {
            string[] scenes = new string[EditorBuildSettings.scenes.Length];
            for(int i = 0; i < scenes.Length; i++)
            {
                scenes[i] = EditorBuildSettings.scenes[i].path;
            }
            return scenes;
        }
    }
}
using UnityEngine;
using UnityEditor;

namespace Compiles
{
    public class CompileFactory : MonoBehaviour
    {
        [MenuItem("CompileFactory/Compile")]
        public static void Compile()
        {
            new ManyCompileFactory(
                new ExtentionFolderCompileFactory(
                    new SimpleCompileFactory(BuildTarget.StandaloneWindows64),
                    ".exe"
                    ),
                new ExtentionFolderCompileFactory(
                    new APKCompileFactory(),
                    ".apk"
                    ),
                 new ExtentionFolderCompileFactory(
                    new AABCompileFactory(),
                    ".aab"
                    )
                    ).Compile(
                    EditorUtility.OpenFolderPanel(
                        "Choose Folder", "Assets", "Build"
                        ), BuildOptions()
                );
        }

        public static BuildOptions BuildOptions()
        {
            return GetBuildPlayerOptions().options;
        }

        private static BuildPlayerOptions GetBuildPlayerOptions(BuildPlayerOptions defaultOptions = new())
        {
            return BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(defaultOptions);
        }

    }
}
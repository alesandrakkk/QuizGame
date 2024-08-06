using System.IO;
using UnityEditor;
using UnityEngine;

namespace Compiles
{
    public class ExtentionFolderCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory origin;
        private readonly string extension;

        public ExtentionFolderCompileFactory(ICompileFactory origin, string extension)
        {
            this.origin = origin;
            this.extension = extension;
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            if (Directory.Exists(path))
            {
                path = Path.ChangeExtension(path, extension);
            }

            origin.Compile(path, buildOptions);
        }
    }
}

using UnityEditor;

namespace Compiles
{
    public interface ICompileFactory
    {
        public void Compile(string path, BuildOptions buildOptions);
    }
}

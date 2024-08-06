using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Compiles
{
    public class WebGlCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory _factory;

        public WebGlCompileFactory() 
        { 
          _factory = new SimpleCompileFactory(BuildTarget.WebGL);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;
            PlayerSettings.WebGL.decompressionFallback = true;
            _factory.Compile(path, buildOptions);
        }


    }

}

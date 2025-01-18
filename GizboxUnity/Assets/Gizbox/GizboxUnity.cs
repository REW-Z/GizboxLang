using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gizbox;

# if UNITY_EDITOR
using UnityEditor;
#endif



public class GizboxUnity
{
    private static Gizbox.Compiler compiler = null;

    public static string baseDirectory = Application.streamingAssetsPath;

    public static string warpFileName = "gizbox_u3d_wrapper";

    public static Type[] includeTypes => new Type[]{
        typeof(GizboxUnityExampleInterop),

        typeof(UnityEngine.Input),

        typeof(UnityEngine.Object),
        typeof(UnityEngine.GameObject),
        typeof(UnityEngine.Component),
        typeof(UnityEngine.Transform),
        };



    public static Gizbox.Compiler Compiler 
    { 
        get
        { 
            if(compiler == null)
            {
                compiler = new Compiler();
                InitCompiler();
            }
            return compiler;
        } 
    }

    private static void InitCompiler()
    {
        compiler.AddLibPath(GizboxUnity.baseDirectory);
        compiler.ConfigParserDataSource(hardcode:true);
        Debug.Log("Gizbox Compiler Inited...");
    }

    public static Gizbox.IL.ILUnit Compile(string source)
    {
        Gizbox.IL.ILUnit unit = null;
        try
        {
            unit = Compiler.Compile(source);
        }
        catch(Exception exc)
        {
            Debug.LogError("Compile Err:" + exc.ToString());
        }
        return unit;
    }
}

public class GizboxUnityExampleInterop
{
    public static void Console__Log(string txt)
    {
        Debug.Log($"Gizbox:{txt}");
    }

    public static UnityEngine.Object FindObjectOfType(string typename)
    {
        var t = Type.GetType(typename);
        if(t != null)
        {
            return UnityEngine.Object.FindObjectOfType(t);
        }
        return null;
    }
}



# if UNITY_EDITOR
public class GizboxUnityEditor
{
    [MenuItem("Gizbox/测试")]
    public static void Test()
    {
        Uri uobj = new Uri("file:///d:/Workspace/ZQJTest/Assets/Gizbox/StreamingAssets");
        Debug.Log("local3:" + uobj.LocalPath);
        Debug.Log("global3:" + uobj.AbsolutePath);
    }


    [MenuItem("Gizbox/生成Wrap代码")]
    public static void GenerateWrapCode()
    {
        InteropWrapGenerator generator = new InteropWrapGenerator();

        generator.IncludeTypes(GizboxUnity.includeTypes);

        foreach(var t in generator.closure)
        {
            Debug.Log("闭包中的类型：" + t.Name);
        }
        generator.StartGenerate(GizboxUnity.warpFileName, Application.dataPath + "/Gizbox", Application.streamingAssetsPath);
    }


    [MenuItem("Gizbox/编译Wrap代码")]
    public static void CompileWrapCode()
    {
        string path = GizboxUnity.baseDirectory + "/" + GizboxUnity.warpFileName + ".gix";
        if(System.IO.File.Exists(path))
        {
            var wrapSource = System.IO.File.ReadAllText(path);
            try
            {
                GizboxUnity.Compiler.CompileToLib(wrapSource, GizboxUnity.warpFileName, GizboxUnity.baseDirectory + "\\" + GizboxUnity.warpFileName + ".gixlib");
            }
            catch(Exception exc)
            {
                Debug.LogError("编译Warp代码出错:" + exc?.Message ?? "unknown err");
            }
        }
        
    }
}
#endif
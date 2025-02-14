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
    private static Dictionary<string, string> config = null;

    private static Gizbox.Compiler compiler = null;

    private static string gizboxLibDirectory;
    private static string gizboxAssetDirectory;

    private static string warpFileName = "gizbox_u3d_wrapper";

    public static string WarpFileName => warpFileName;
    public static string GizboxLibDirectory
    {
        get
        {
            if(string.IsNullOrEmpty(gizboxLibDirectory))
            {
                gizboxLibDirectory = System.IO.Path.GetDirectoryName(Application.dataPath) + "\\GizboxLibs";
            }
            
            return gizboxLibDirectory;
        }
    }
    public static string GizboxAssetDirectory
    {
        get
        {
            if(string.IsNullOrEmpty(gizboxAssetDirectory))
            {
                if(config == null) InitConfig();
                gizboxAssetDirectory = Application.dataPath + "/" + config["assetPath"];
                Debug.Log("gizx asset path:" + gizboxAssetDirectory);
            }

            return gizboxAssetDirectory;
        }
    }


    public static void InitConfig()
    {
        if(config != null) return;

        config = new Dictionary<string, string>();
        string configpath = GizboxLibDirectory + "\\config.txt";
        var lines = System.IO.File.ReadAllLines(configpath);
        foreach(var line in lines)
        {
            var splitIdx = line.IndexOf('=');
            if(splitIdx < 0) continue;

            string key = line.Substring(0, splitIdx);
            string val = line.Substring(splitIdx + 1);
            config[key] = val;
        }
    }

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
        compiler.AddLibPath(GizboxUnity.GizboxLibDirectory);
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
    [MenuItem("Gizbox/测试test.gix")]
    public static void Test()
    {
        GizboxUnity.InitConfig();
        var ir = GizboxUnity.Compiler.Compile(System.IO.File.ReadAllText(GizboxUnity.GizboxLibDirectory + "\\test.gix"));
        Gizbox.ScriptEngine.ScriptEngine engine = new Gizbox.ScriptEngine.ScriptEngine();
        engine.AddLibSearchDirectory(GizboxUnity.GizboxLibDirectory);
        engine.csharpInteropContext.ConfigExternCallClasses(new System.Type[] {
            typeof(GizboxUnityExampleInterop),
            typeof(gizbox_u3d_wrapper),
            });
        engine.Load(ir);
        engine.Call("Test");
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
        generator.StartGenerate(GizboxUnity.WarpFileName, GizboxUnity.GizboxAssetDirectory, GizboxUnity.GizboxLibDirectory);
    }


    [MenuItem("Gizbox/编译Wrap代码")]
    public static void CompileWrapCode()
    {
        string path = GizboxUnity.GizboxLibDirectory + "/" + GizboxUnity.WarpFileName + ".gix";
        if(System.IO.File.Exists(path))
        {
            var wrapSource = System.IO.File.ReadAllText(path);
            try
            {
                GizboxUnity.Compiler.CompileToLib(wrapSource, GizboxUnity.WarpFileName, GizboxUnity.GizboxLibDirectory + "\\" + GizboxUnity.WarpFileName + ".gixlib");
            }
            catch(Exception exc)
            {
                Debug.LogError("编译Warp代码出错:" + exc?.Message ?? "unknown err");
            }
        }
        
    }
}
#endif
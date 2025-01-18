using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gizbox;


public class GizboxBehaviour : MonoBehaviour
{
    public string gizboxScriptName;

    private Gizbox.ScriptEngine.ScriptEngine engine;

    private bool inited = false;

    private void Awake()
    {
        engine = new Gizbox.ScriptEngine.ScriptEngine();
        engine.AddLibSearchDirectory(GizboxUnity.baseDirectory);
        engine.csharpInteropContext.ConfigExternCallClasses(new System.Type[] {
            typeof(GizboxUnityExampleInterop),
            typeof(gizbox_u3d_wrapper),
            });


        string scriptPath = GizboxUnity.baseDirectory + "/" + gizboxScriptName;

        if(System.IO.File.Exists(scriptPath))
        {
            string source = System.IO.File.ReadAllText(scriptPath);
            var il = GizboxUnity.Compile(source);
            if(il != null)
            {
                engine.AddLibSearchDirectory(GizboxUnity.baseDirectory);
                engine.Execute(il);
                engine.Call("Init", this.gameObject);


                inited = true;
            }
        }
        else
        {
            Debug.Log($"Script {scriptPath} not exist!");
        }
    }
    void Start()
    {
        if(inited)
            engine.Call("Start");
    }
    void Update()
    {
        if(inited)
            engine.Call("Update");
    }
    private void OnDestroy()
    {
        if(inited)
            engine.Call("OnDestroy");
    }
}

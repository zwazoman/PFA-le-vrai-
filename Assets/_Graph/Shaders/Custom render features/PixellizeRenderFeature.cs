using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEngine.ParticleSystem;

//https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@12.1/manual/renderer-features/create-custom-renderer-feature.html

public class PixellizeRenderFeature : ScriptableRendererFeature
{
    private PixellizePass _pixellizePass;

    // Unity calls this method on the following events:
    // - When the Renderer Feature loads the first time.
    // - When you enable or disable the Renderer Feature.
    // - When you change a property in the inspector of the Renderer Feature.
    public override void Create()
    {
        _pixellizePass = new PixellizePass();
    }

    //Unity calls this method every frame, once for each Camera.
    //This method lets you inject ScriptableRenderPass instances into the scriptable Renderer.
    public override void AddRenderPasses(ScriptableRenderer renderer,
    ref RenderingData renderingData)
    {
        renderer.EnqueuePass(_pixellizePass);
    }


    class PixellizePass : ScriptableRenderPass
    {
        //Unity runs the Execute method every frame. In this method, you can implement your custom rendering functionality.
        public override void Execute(ScriptableRenderContext context,
        ref RenderingData renderingData)
        { 
        
        }
    }

}

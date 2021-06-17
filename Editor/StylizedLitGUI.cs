using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.Rendering.Universal.ShaderGUI
{
    [MovedFrom("UnityEditor.Rendering.LWRP.ShaderGUI")] public static class StylizedLitGUI
    {
        public enum WorkflowMode
        {
            Specular = 0,
            Metallic
        }

        public enum SmoothnessMapChannel
        {
            SpecularMetallicAlpha,
            AlbedoAlpha,
        }

        public static class Styles
        {
            public static GUIContent workflowModeText = new GUIContent("Workflow Mode",
                "Select a workflow that fits your textures. Choose between Metallic or Specular.");

            public static GUIContent specularMapText =
                new GUIContent("Specular Map", "Sets and configures the map and color for the Specular workflow.");

            public static GUIContent metallicMapText =
                new GUIContent("Metallic Map", "Sets and configures the map for the Metallic workflow.");

            public static GUIContent smoothnessText = new GUIContent("Smoothness",
                "Controls the spread of highlights and reflections on the surface.");

            public static GUIContent smoothnessMapChannelText =
                new GUIContent("Source",
                    "Specifies where to sample a smoothness map from. By default, uses the alpha channel for your map.");

            public static GUIContent highlightsText = new GUIContent("Specular Highlights",
                "When enabled, the Material reflects the shine from direct lighting.");

            public static GUIContent reflectionsText =
                new GUIContent("Environment Reflections",
                    "When enabled, the Material samples reflections from the nearest Reflection Probes or Lighting Probe.");

            public static GUIContent occlusionText = new GUIContent("Occlusion Map",
                "Sets an occlusion map to simulate shadowing from ambient lighting.");

            public static readonly string[] metallicSmoothnessChannelNames = {"Metallic Alpha", "Albedo Alpha"};
            public static readonly string[] specularSmoothnessChannelNames = {"Specular Alpha", "Albedo Alpha"};
        }

        public struct LitProperties
        {
            // Surface Option Props
            public MaterialProperty workflowMode;

            // Surface Input Props
            public MaterialProperty metallic;
            public MaterialProperty specColor;
            public MaterialProperty metallicGlossMap;
            public MaterialProperty specGlossMap;
            public MaterialProperty smoothness;
            public MaterialProperty smoothnessMapChannel;
            public MaterialProperty bumpMapProp;
            public MaterialProperty bumpScaleProp;
            public MaterialProperty occlusionStrength;
            public MaterialProperty occlusionMap;

            //StylizedLit
            public MaterialProperty useBrushTex;
            public MaterialProperty brushTex;
            public MaterialProperty medColor;
            public MaterialProperty medThreshold;
            public MaterialProperty medSmooth;
            public MaterialProperty medBrushStrength;
            public MaterialProperty shadowColor;
            public MaterialProperty shadowThreshold;
            public MaterialProperty shadowSmooth;
            public MaterialProperty shadowBrushStrength;

            public MaterialProperty giIntensity;
            public MaterialProperty reflColor;
            public MaterialProperty reflThreshold;
            public MaterialProperty reflSmooth;
            public MaterialProperty reflBrushStrength;
            public MaterialProperty ggxSpecular;
            public MaterialProperty specularLightOffset;
            public MaterialProperty specularThreshold;
            public MaterialProperty specularSmooth;
            public MaterialProperty specularIntensity;
            public MaterialProperty directionalFresnel;
            public MaterialProperty fresnelThreshold;
            public MaterialProperty fresnelSmooth;
            public MaterialProperty fresnelIntensity;
            public MaterialProperty reflProbeIntensity;
            public MaterialProperty metalReflProbeIntensity;
            public MaterialProperty reflProbeRotation;



            // Advanced Props
            public MaterialProperty highlights;
            public MaterialProperty reflections;

            public LitProperties(MaterialProperty[] properties)
            {
                // Surface Option Props
                workflowMode = BaseShaderGUI.FindProperty("_WorkflowMode", properties, false);
                // Surface Input Props
                metallic = BaseShaderGUI.FindProperty("_Metallic", properties);
                specColor = BaseShaderGUI.FindProperty("_SpecColor", properties, false);
                metallicGlossMap = BaseShaderGUI.FindProperty("_MetallicGlossMap", properties);
                specGlossMap = BaseShaderGUI.FindProperty("_SpecGlossMap", properties, false);
                smoothness = BaseShaderGUI.FindProperty("_Smoothness", properties, false);
                smoothnessMapChannel = BaseShaderGUI.FindProperty("_SmoothnessTextureChannel", properties, false);
                bumpMapProp = BaseShaderGUI.FindProperty("_BumpMap", properties, false);
                bumpScaleProp = BaseShaderGUI.FindProperty("_BumpScale", properties, false);
                occlusionStrength = BaseShaderGUI.FindProperty("_OcclusionStrength", properties, false);
                occlusionMap = BaseShaderGUI.FindProperty("_OcclusionMap", properties, false);
                // Advanced Props
                highlights = BaseShaderGUI.FindProperty("_SpecularHighlights", properties, false);
                reflections = BaseShaderGUI.FindProperty("_EnvironmentReflections", properties, false);

                //stylized Lit
                useBrushTex = BaseShaderGUI.FindProperty("_UseBrushTex", properties, false);
                brushTex = BaseShaderGUI.FindProperty("_BrushTex", properties, false);
                medColor = BaseShaderGUI.FindProperty("_MedColor", properties, false);
                medThreshold = BaseShaderGUI.FindProperty("_MedThreshold", properties, false);
                medSmooth = BaseShaderGUI.FindProperty("_MedSmooth", properties, false);
                medBrushStrength = BaseShaderGUI.FindProperty("_MedBrushStrength", properties, false);
                shadowColor = BaseShaderGUI.FindProperty("_ShadowColor", properties, false);
                shadowThreshold = BaseShaderGUI.FindProperty("_ShadowThreshold", properties, false);
                shadowSmooth = BaseShaderGUI.FindProperty("_ShadowSmooth", properties, false);
                shadowBrushStrength = BaseShaderGUI.FindProperty("_ShadowBrushStrength", properties, false);
                reflColor = BaseShaderGUI.FindProperty("_ReflectColor", properties, false);
                reflThreshold = BaseShaderGUI.FindProperty("_ReflectThreshold", properties, false);
                reflSmooth = BaseShaderGUI.FindProperty("_ReflectSmooth", properties, false);
                reflBrushStrength = BaseShaderGUI.FindProperty("_ReflBrushStrength", properties, false);
                giIntensity = BaseShaderGUI.FindProperty("_GIIntensity", properties, false);
                ggxSpecular = BaseShaderGUI.FindProperty("_GGXSpecular", properties, false);
                specularLightOffset = BaseShaderGUI.FindProperty("_SpecularLightOffset", properties, false);
                specularThreshold = BaseShaderGUI.FindProperty("_SpecularThreshold", properties, false);
                specularSmooth = BaseShaderGUI.FindProperty("_SpecularSmooth", properties, false);
                specularIntensity = BaseShaderGUI.FindProperty("_SpecularIntensity", properties, false);
                directionalFresnel = BaseShaderGUI.FindProperty("_DirectionalFresnel", properties, false);
                fresnelThreshold = BaseShaderGUI.FindProperty("_FresnelThreshold", properties, false);
                fresnelSmooth  = BaseShaderGUI.FindProperty("_FresnelSmooth", properties, false);
                fresnelIntensity = BaseShaderGUI.FindProperty("_FresnelIntensity", properties, false);
                reflProbeIntensity = BaseShaderGUI.FindProperty("_ReflProbeIntensity", properties, false);
                metalReflProbeIntensity = BaseShaderGUI.FindProperty("_MetalReflProbeIntensity", properties, false);
                reflProbeRotation = BaseShaderGUI.FindProperty("_ReflProbeRotation", properties, false);
            }
        }

        public static void Inputs(LitProperties properties, MaterialEditor materialEditor, Material material)
        {
            DoMetallicSpecularArea(properties, materialEditor, material);
            BaseShaderGUI.DrawNormalArea(materialEditor, properties.bumpMapProp, properties.bumpScaleProp);

            if (properties.occlusionMap != null)
            {
                materialEditor.TexturePropertySingleLine(Styles.occlusionText, properties.occlusionMap,
                    properties.occlusionMap.textureValue != null ? properties.occlusionStrength : null);
            }
        }

        public static void DoMetallicSpecularArea(LitProperties properties, MaterialEditor materialEditor, Material material)
        {
            string[] smoothnessChannelNames;
            bool hasGlossMap = false;
            if (properties.workflowMode == null ||
                (WorkflowMode) properties.workflowMode.floatValue == WorkflowMode.Metallic)
            {
                hasGlossMap = properties.metallicGlossMap.textureValue != null;
                smoothnessChannelNames = Styles.metallicSmoothnessChannelNames;
                materialEditor.TexturePropertySingleLine(Styles.metallicMapText, properties.metallicGlossMap,
                    hasGlossMap ? null : properties.metallic);
            }
            else
            {
                hasGlossMap = properties.specGlossMap.textureValue != null;
                smoothnessChannelNames = Styles.specularSmoothnessChannelNames;
                BaseShaderGUI.TextureColorProps(materialEditor, Styles.specularMapText, properties.specGlossMap,
                    hasGlossMap ? null : properties.specColor);
            }
            EditorGUI.indentLevel++;
            DoSmoothness(properties, material, smoothnessChannelNames);
            EditorGUI.indentLevel--;
        }

        public static void DoSmoothness(LitProperties properties, Material material, string[] smoothnessChannelNames)
        {
            var opaque = ((BaseShaderGUI.SurfaceType) material.GetFloat("_Surface") ==
                          BaseShaderGUI.SurfaceType.Opaque);
            EditorGUI.indentLevel++;
            EditorGUI.BeginChangeCheck();
            EditorGUI.showMixedValue = properties.smoothness.hasMixedValue;
            var smoothness = EditorGUILayout.Slider(Styles.smoothnessText, properties.smoothness.floatValue, 0f, 1f);
            if (EditorGUI.EndChangeCheck())
                properties.smoothness.floatValue = smoothness;
            EditorGUI.showMixedValue = false;

            if (properties.smoothnessMapChannel != null) // smoothness channel
            {
                EditorGUI.indentLevel++;
                EditorGUI.BeginDisabledGroup(!opaque);
                EditorGUI.BeginChangeCheck();
                EditorGUI.showMixedValue = properties.smoothnessMapChannel.hasMixedValue;
                var smoothnessSource = (int) properties.smoothnessMapChannel.floatValue;
                if (opaque)
                    smoothnessSource = EditorGUILayout.Popup(Styles.smoothnessMapChannelText, smoothnessSource,
                        smoothnessChannelNames);
                else
                    EditorGUILayout.Popup(Styles.smoothnessMapChannelText, 0, smoothnessChannelNames);
                if (EditorGUI.EndChangeCheck())
                    properties.smoothnessMapChannel.floatValue = smoothnessSource;
                EditorGUI.showMixedValue = false;
                EditorGUI.EndDisabledGroup();
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        public static SmoothnessMapChannel GetSmoothnessMapChannel(Material material)
        {
            int ch = (int) material.GetFloat("_SmoothnessTextureChannel");
            if (ch == (int) SmoothnessMapChannel.AlbedoAlpha)
                return SmoothnessMapChannel.AlbedoAlpha;

            return SmoothnessMapChannel.SpecularMetallicAlpha;
        }

        public static void SetMaterialKeywords(Material material)
        {
            // Note: keywords must be based on Material value not on MaterialProperty due to multi-edit & material animation
            // (MaterialProperty value might come from renderer material property block)
            
            var hasGlossMap = false;
            
            var isSpecularWorkFlow = false;
            var opaque = ((BaseShaderGUI.SurfaceType) material.GetFloat("_Surface") ==
                          BaseShaderGUI.SurfaceType.Opaque);
            if (material.HasProperty("_WorkflowMode"))
            {
                isSpecularWorkFlow = (WorkflowMode) material.GetFloat("_WorkflowMode") == WorkflowMode.Specular;
                if (isSpecularWorkFlow)
                    hasGlossMap = material.GetTexture("_SpecGlossMap") != null;
                else
                    hasGlossMap = material.GetTexture("_MetallicGlossMap") != null;
            }
            else
            {
                hasGlossMap = material.GetTexture("_MetallicGlossMap") != null;
            }

            //stylizedLit---------------------
            var hasBrushTex = false;
            if (material.HasProperty("_BrushTex"))
            {
                hasBrushTex = material.GetTexture("_BrushTex") != null;
            }

            CoreUtils.SetKeyword(material, "_USEBRUSHTEX_ON", hasBrushTex);

            //stylizedLit---------------------

            CoreUtils.SetKeyword(material, "_SPECULAR_SETUP", isSpecularWorkFlow);

            CoreUtils.SetKeyword(material, "_METALLICSPECGLOSSMAP", hasGlossMap);

            if (material.HasProperty("_SpecularHighlights"))
                CoreUtils.SetKeyword(material, "_SPECULARHIGHLIGHTS_OFF",
                    material.GetFloat("_SpecularHighlights") == 0.0f);
            if (material.HasProperty("_EnvironmentReflections"))
                CoreUtils.SetKeyword(material, "_ENVIRONMENTREFLECTIONS_OFF",
                    material.GetFloat("_EnvironmentReflections") == 0.0f);
            if (material.HasProperty("_OcclusionMap"))
                CoreUtils.SetKeyword(material, "_OCCLUSIONMAP", material.GetTexture("_OcclusionMap"));

            if (material.HasProperty("_SmoothnessTextureChannel"))
            {
                CoreUtils.SetKeyword(material, "_SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A",
                    GetSmoothnessMapChannel(material) == SmoothnessMapChannel.AlbedoAlpha && opaque);
            }
        }
    }
}

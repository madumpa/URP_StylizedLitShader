using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor.Rendering.Universal;

namespace UnityEditor.Rendering.Universal.ShaderGUI
{
    internal class StylizedLitShader : BaseShaderGUI
    {
        // Properties
        private StylizedLitGUI.LitProperties litProperties; 


        protected class StStyles       
        {
            public static readonly GUIContent stylizedDiffuseGUI = new GUIContent("Stylized Diffuse",
                "These settings describe the look and feel of the surface itself.");

            // Catergories
            public static readonly GUIContent brushTexGUI = new GUIContent ("Brush Texture ",
                "(R:Medium, G:Shadow, B:Reflect)");

            public static readonly GUIContent medColorGUI = new GUIContent("Medium Color",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent medThresholdGUI = new GUIContent("Medium Threshold",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent medSmoothGUI = new GUIContent("Medium Smooth",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent medBrushStrengthGUI = new GUIContent("Medium Brush Strength",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent shadowColorGUI = new GUIContent("Shadow Color",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent shadowThresholdGUI = new GUIContent("Shadow Threshold",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent shadowSmoothGUI = new GUIContent("Shadow Smooth",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent shadowBrushStrengthGUI = new GUIContent("Shadow Brush Strength",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent reflColorGUI = new GUIContent("Reflect Color",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent reflThresholdGUI = new GUIContent("Reflect Threshold",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent reflSmoothGUI = new GUIContent("Reflect Smooth",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent reflBrushStrengthGUI = new GUIContent("Reflect Brush Strength",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent giIntensityGUI = new GUIContent("GI (indirect Diffuse) Intensity",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent ggxSpecularGUI = new GUIContent("GGX Specular",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent specularLightOffsetGUI = new GUIContent("Specular Light Offset",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent specularThresholdGUI = new GUIContent("Specular Threshold",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent specularSmoothGUI = new GUIContent("Specular Smooth",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent specularIntensityGUI = new GUIContent("Specular Intensity",
                "These settings describe the look and feel of the surface itself.");
            public static readonly GUIContent directionalFresnelGUI = new GUIContent("Directional Fresnel",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent fresnelThresholdGUI = new GUIContent("Fresnel Threshold",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent fresnelSmoothGUI = new GUIContent("Fresnel Smooth",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent fresnelIntensityGUI = new GUIContent("Fresnel Intensity",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent reflProbeIntensityGUI = new GUIContent("Non Metal Reflection Probe Intensity",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent metalReflProbeIntensityGUI = new GUIContent("Metal Reflection Probe Intensity",
                "These settings describe the look and feel of the surface itself.");

            


            // collect properties from the material properties
        }
            public override void FindProperties(MaterialProperty[] properties)
        {
            base.FindProperties(properties);
            litProperties = new StylizedLitGUI.LitProperties(properties);
        }

        // material changed check
        public override void MaterialChanged(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            SetMaterialKeywords(material, StylizedLitGUI.SetMaterialKeywords);
        }

        // material main surface options
        public override void DrawSurfaceOptions(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            // Use default labelWidth
            EditorGUIUtility.labelWidth = 0f;

            // Detect any changes to the material
            EditorGUI.BeginChangeCheck();
            if (litProperties.workflowMode != null)
            {
                DoPopup(StylizedLitGUI.Styles.workflowModeText, litProperties.workflowMode, Enum.GetNames(typeof(StylizedLitGUI.WorkflowMode)));
            }
            if (EditorGUI.EndChangeCheck())
            {
                foreach (var obj in blendModeProp.targets)
                    MaterialChanged((Material)obj);
            }
            base.DrawSurfaceOptions(material);
        }

        public void DrawStylizedInputs(Material material)       //여기서 추가한 프로퍼티들을 그려주고 Set 해줍니다 
        {
            
            if (litProperties.brushTex != null ) // Draw the baseMap, most shader will have at least a baseMap
            {
                EditorGUILayout.HelpBox("Brush Texture", MessageType.None);
                EditorGUILayout.Space();
                materialEditor.TexturePropertySingleLine(StStyles.brushTexGUI, litProperties.brushTex); 
                // TODO Temporary fix for lightmapping, to be replaced with attribute tag.
                if (material.HasProperty("_BrushTex"))
                {
                    material.SetTexture("_BrushTex", litProperties.brushTex.textureValue);
                    
                    var brushTexTiling = litProperties.brushTex.textureScaleAndOffset;
                    material.SetTextureScale("_BrushTex", new Vector2(brushTexTiling.x, brushTexTiling.y));
                    material.SetTextureOffset("_BrushTex", new Vector2(brushTexTiling.z, brushTexTiling.w));
                }
                if (material.GetTexture("_BrushTex") != null)
                {
                    materialEditor.TextureScaleOffsetProperty(litProperties.brushTex);
                    materialEditor.ShaderProperty(litProperties.medBrushStrength, StStyles.medBrushStrengthGUI, 2);
                    materialEditor.ShaderProperty(litProperties.shadowBrushStrength, StStyles.shadowBrushStrengthGUI, 2);
                    materialEditor.ShaderProperty(litProperties.reflBrushStrength, StStyles.reflBrushStrengthGUI, 2);
                    
                }
                EditorGUILayout.Space();

                EditorGUILayout.HelpBox("Stylized Diffuse", MessageType.None);

                materialEditor.ShaderProperty(litProperties.medColor, StStyles.medColorGUI, 1);
                materialEditor.ShaderProperty(litProperties.medThreshold, StStyles.medThresholdGUI, 1);
                materialEditor.ShaderProperty(litProperties.medSmooth, StStyles.medSmoothGUI, 1);
                

                materialEditor.ShaderProperty(litProperties.shadowColor, StStyles.shadowColorGUI, 1);
                materialEditor.ShaderProperty(litProperties.shadowThreshold, StStyles.shadowThresholdGUI, 1);
                materialEditor.ShaderProperty(litProperties.shadowSmooth, StStyles.shadowSmoothGUI, 1);

                materialEditor.ShaderProperty(litProperties.reflColor, StStyles.reflColorGUI, 1);
                materialEditor.ShaderProperty(litProperties.reflThreshold, StStyles.reflThresholdGUI, 1);
                materialEditor.ShaderProperty(litProperties.reflSmooth, StStyles.reflSmoothGUI, 1);

                EditorGUILayout.Space();
                materialEditor.ShaderProperty(litProperties.giIntensity, StStyles.giIntensityGUI, 1);

                EditorGUILayout.Space();
                EditorGUILayout.HelpBox("Stylized Reflection", MessageType.None);

                materialEditor.ShaderProperty(litProperties.ggxSpecular, StStyles.ggxSpecularGUI, 1);
                materialEditor.ShaderProperty(litProperties.specularLightOffset, StStyles.specularLightOffsetGUI, 1);
                if (material.GetFloat("_GGXSpecular") == 0)
                {
                    materialEditor.ShaderProperty(litProperties.specularThreshold, StStyles.specularThresholdGUI, 1);
                    materialEditor.ShaderProperty(litProperties.specularSmooth, StStyles.specularSmoothGUI, 1);
                }
                materialEditor.ShaderProperty(litProperties.specularIntensity, StStyles.specularIntensityGUI, 1);

                materialEditor.ShaderProperty(litProperties.directionalFresnel, StStyles.directionalFresnelGUI, 1);
                materialEditor.ShaderProperty(litProperties.fresnelThreshold, StStyles.fresnelThresholdGUI, 1);
                materialEditor.ShaderProperty(litProperties.fresnelSmooth, StStyles.fresnelSmoothGUI, 1);
                materialEditor.ShaderProperty(litProperties.fresnelIntensity, StStyles.fresnelIntensityGUI, 1);

                EditorGUILayout.Space(10);

                materialEditor.ShaderProperty(litProperties.reflProbeIntensity, StStyles.reflProbeIntensityGUI, 1);
                materialEditor.ShaderProperty(litProperties.metalReflProbeIntensity, StStyles.metalReflProbeIntensityGUI, 1);


            }
        }

        // material main surface inputs
        public override void DrawSurfaceInputs(Material material)
        {
            base.DrawSurfaceInputs(material);
            StylizedLitGUI.Inputs(litProperties, materialEditor, material);
           
            DrawEmissionProperties(material, true);
            DrawTileOffset(materialEditor, baseMapProp);
        }

        // material main advanced options
        public override void DrawAdvancedOptions(Material material)
        {

            //Stylized Lit
            EditorGUILayout.Space();
            DrawStylizedInputs(material);
            EditorGUILayout.Space();

            EditorGUILayout.HelpBox("Other Option", MessageType.None);
            if (litProperties.reflections != null && litProperties.highlights != null)
            {
                EditorGUI.BeginChangeCheck();
                materialEditor.ShaderProperty(litProperties.highlights, StylizedLitGUI.Styles.highlightsText);
                materialEditor.ShaderProperty(litProperties.reflections, StylizedLitGUI.Styles.reflectionsText);
                if(EditorGUI.EndChangeCheck())
                {
                    MaterialChanged(material);
                }
            }
            
            base.DrawAdvancedOptions(material);
        }

        public override void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            // _Emission property is lost after assigning Standard shader to the material
            // thus transfer it before assigning the new shader
            if (material.HasProperty("_Emission"))
            {
                material.SetColor("_EmissionColor", material.GetColor("_Emission"));
            }

            base.AssignNewShaderToMaterial(material, oldShader, newShader);

            if (oldShader == null || !oldShader.name.Contains("Legacy Shaders/"))
            {
                SetupMaterialBlendMode(material);
                return;
            }

            SurfaceType surfaceType = SurfaceType.Opaque;
            BlendMode blendMode = BlendMode.Alpha;
            if (oldShader.name.Contains("/Transparent/Cutout/"))
            {
                surfaceType = SurfaceType.Opaque;
                material.SetFloat("_AlphaClip", 1);
            }
            else if (oldShader.name.Contains("/Transparent/"))
            {
                // NOTE: legacy shaders did not provide physically based transparency
                // therefore Fade mode
                surfaceType = SurfaceType.Transparent;
                blendMode = BlendMode.Alpha;
            }
            material.SetFloat("_Surface", (float)surfaceType);
            material.SetFloat("_Blend", (float)blendMode);

            if (oldShader.name.Equals("Standard (Specular setup)"))
            {
                material.SetFloat("_WorkflowMode", (float)StylizedLitGUI.WorkflowMode.Specular);
                Texture texture = material.GetTexture("_SpecGlossMap");
                if (texture != null)
                    material.SetTexture("_MetallicSpecGlossMap", texture);
            }
            else
            {
                material.SetFloat("_WorkflowMode", (float)StylizedLitGUI.WorkflowMode.Metallic);
                Texture texture = material.GetTexture("_MetallicGlossMap");
                if (texture != null)
                    material.SetTexture("_MetallicSpecGlossMap", texture);
            }

            MaterialChanged(material);
        }
    }
}

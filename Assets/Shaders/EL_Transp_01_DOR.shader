// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,gpui:True,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:2,spmd:0,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:False,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:3,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.6391106,fgcg:0.8026343,fgcb:0.8996344,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:1,x:34263,y:33208,varname:node_1,prsc:2|diff-227-OUT,spec-7657-OUT,gloss-8602-OUT,alpha-2-A;n:type:ShaderForge.SFN_VertexColor,id:2,x:33010,y:33110,varname:node_2,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5,x:32328,y:32667,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:8602,x:33750,y:33387,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:7657,x:33766,y:33298,ptovrint:False,ptlb:Spec,ptin:_Spec,varname:_Spec,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Cubemap,id:2741,x:32071,y:33764,ptovrint:False,ptlb:NoiseCubemap,ptin:_NoiseCubemap,varname:_NoiseCubemap,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0;n:type:ShaderForge.SFN_RemapRange,id:8126,x:32271,y:33782,varname:node_8126,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2741-RGB;n:type:ShaderForge.SFN_NormalVector,id:8283,x:31940,y:34048,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:4519,x:32055,y:33949,varname:node_4519,prsc:2,v1:1;n:type:ShaderForge.SFN_Fresnel,id:5662,x:32314,y:33984,varname:node_5662,prsc:2|NRM-8283-OUT,EXP-4519-OUT;n:type:ShaderForge.SFN_Clamp01,id:2131,x:32419,y:33782,varname:node_2131,prsc:2|IN-8126-OUT;n:type:ShaderForge.SFN_AmbientLight,id:8423,x:32288,y:33564,varname:node_8423,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:227,x:33572,y:33098,varname:node_227,prsc:2|IN-3066-OUT;n:type:ShaderForge.SFN_Multiply,id:6776,x:32585,y:33782,varname:node_6776,prsc:2|A-2131-OUT,B-5662-OUT,C-8423-RGB;n:type:ShaderForge.SFN_Multiply,id:3066,x:33334,y:33147,varname:node_3066,prsc:2|A-2-RGB,B-349-OUT;n:type:ShaderForge.SFN_Multiply,id:8023,x:32938,y:33551,varname:node_8023,prsc:2|A-6776-OUT,B-2484-OUT;n:type:ShaderForge.SFN_Vector1,id:2484,x:32741,y:33567,varname:node_2484,prsc:2,v1:3;n:type:ShaderForge.SFN_Add,id:349,x:33100,y:33375,varname:node_349,prsc:2|A-1558-OUT,B-8023-OUT;n:type:ShaderForge.SFN_Vector1,id:1558,x:32871,y:33364,varname:node_1558,prsc:2,v1:0.7;proporder:8602-7657-2741;pass:END;sub:END;*/

Shader "EverythingLibrary/Transp_01_DOR" {
    Properties {
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Spec ("Spec", Range(0, 1)) = 0
        _NoiseCubemap ("NoiseCubemap", Cube) = "_Skybox" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma multi_compile_instancing
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 ps4 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _Gloss;
            uniform float _Spec;
            uniform samplerCUBE _NoiseCubemap;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID(i);
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 1.0 - _Gloss; // Convert roughness to gloss
                float specPow = gloss;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Spec,_Spec,_Spec);
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = saturate((i.vertexColor.rgb*(0.7+((saturate((texCUBE(_NoiseCubemap,viewReflectDirection).rgb*2.0+-1.0))*pow(1.0-max(0,dot(i.normalDir, viewDirection)),1.0)*UNITY_LIGHTMODEL_AMBIENT.rgb)*3.0))));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,i.vertexColor.a);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma multi_compile_instancing
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 ps4 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _Gloss;
            uniform float _Spec;
            uniform samplerCUBE _NoiseCubemap;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID(i);
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 1.0 - _Gloss; // Convert roughness to gloss
                float specPow = gloss;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Spec,_Spec,_Spec);
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = saturate((i.vertexColor.rgb*(0.7+((saturate((texCUBE(_NoiseCubemap,viewReflectDirection).rgb*2.0+-1.0))*pow(1.0-max(0,dot(i.normalDir, viewDirection)),1.0)*UNITY_LIGHTMODEL_AMBIENT.rgb)*3.0))));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * i.vertexColor.a,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}

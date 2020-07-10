// Upgrade NOTE: upgraded instancing buffer 'Properties' to new syntax.

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,gpui:True,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:3,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.556935,fgcg:0.6154646,fgcb:0.5862229,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1,x:34557,y:33118,varname:node_1,prsc:2|diff-2967-RGB,emission-2457-OUT,transm-1889-OUT,lwrap-1889-OUT,voffset-8337-OUT;n:type:ShaderForge.SFN_NormalVector,id:5,x:32921,y:32764,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:1889,x:34166,y:33219,varname:node_1889,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Multiply,id:2457,x:33768,y:33090,varname:node_2457,prsc:2|A-4380-OUT,B-3366-OUT;n:type:ShaderForge.SFN_Fresnel,id:4380,x:33307,y:32873,varname:node_4380,prsc:2|NRM-5-OUT,EXP-4530-OUT;n:type:ShaderForge.SFN_Slider,id:4530,x:32816,y:32944,ptovrint:False,ptlb:fresnelPower,ptin:_fresnelPower,varname:_fresnelPower,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4,max:5;n:type:ShaderForge.SFN_Multiply,id:3705,x:34153,y:33606,varname:node_3705,prsc:2|A-2054-OUT,B-2216-OUT,C-616-OUT;n:type:ShaderForge.SFN_Vector3,id:2216,x:33940,y:33849,varname:node_2216,prsc:2,v1:1,v2:0,v3:0;n:type:ShaderForge.SFN_TexCoord,id:5235,x:33160,y:33737,varname:node_5235,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:2451,x:33595,y:33622,varname:node_2451,prsc:2|A-4333-OUT,B-4579-OUT;n:type:ShaderForge.SFN_Time,id:9993,x:32576,y:33197,varname:node_9993,prsc:2;n:type:ShaderForge.SFN_Sin,id:2054,x:33940,y:33577,varname:node_2054,prsc:2|IN-357-OUT;n:type:ShaderForge.SFN_Multiply,id:357,x:33781,y:33577,varname:node_357,prsc:2|A-7284-OUT,B-2451-OUT,C-3077-OUT;n:type:ShaderForge.SFN_Pi,id:7284,x:33602,y:33334,varname:node_7284,prsc:2;n:type:ShaderForge.SFN_Slider,id:3077,x:33438,y:33462,ptovrint:False,ptlb:SwimFreq,ptin:_SwimFreq,varname:_SwimFreq,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5020168,max:5;n:type:ShaderForge.SFN_Slider,id:616,x:33488,y:33803,ptovrint:False,ptlb:SwimAmplitude,ptin:_SwimAmplitude,varname:_SwimAmplitude,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5435123,max:2;n:type:ShaderForge.SFN_Negate,id:4579,x:33319,y:33661,varname:node_4579,prsc:2|IN-5235-U;n:type:ShaderForge.SFN_Add,id:327,x:32886,y:33330,varname:node_327,prsc:2|A-9993-T,B-3720-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3720,x:32530,y:33406,ptovrint:False,ptlb:FlapOffset,ptin:_FlapOffset,varname:_FlapOffset,prsc:2,glob:False,inst:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:8337,x:34352,y:33606,varname:node_8337,prsc:2|A-3705-OUT,B-5235-U;n:type:ShaderForge.SFN_Vector1,id:3366,x:33477,y:33127,varname:node_3366,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:4333,x:33426,y:33518,varname:node_4333,prsc:2|A-1307-OUT,B-4631-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1307,x:33225,y:33399,ptovrint:False,ptlb:TimeMult,ptin:_TimeMult,varname:_TimeMult,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Sin,id:9628,x:32613,y:33564,varname:node_9628,prsc:2|IN-2836-OUT;n:type:ShaderForge.SFN_Multiply,id:2836,x:32426,y:33564,varname:node_2836,prsc:2|A-9993-T,B-8570-OUT,C-3720-OUT;n:type:ShaderForge.SFN_RemapRange,id:5305,x:32785,y:33564,varname:node_5305,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:0.6|IN-9628-OUT;n:type:ShaderForge.SFN_Add,id:4631,x:33201,y:33518,varname:node_4631,prsc:2|A-327-OUT,B-5305-OUT;n:type:ShaderForge.SFN_Vector1,id:8570,x:32110,y:33652,varname:node_8570,prsc:2,v1:1.2;n:type:ShaderForge.SFN_VertexColor,id:2967,x:33768,y:32860,varname:node_2967,prsc:2;proporder:4530-3077-616-3720-1307;pass:END;sub:END;*/

Shader "EverythingLibrary/Swim_01_DOR" {
    Properties {
        _fresnelPower ("fresnelPower", Range(0, 5)) = 4
        _SwimFreq ("SwimFreq", Range(0, 5)) = 0.5020168
        _SwimAmplitude ("SwimAmplitude", Range(0, 2)) = 0.5435123
        _FlapOffset ("FlapOffset", Float ) = 1
        _TimeMult ("TimeMult", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma multi_compile_instancing
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 ps4 
            #pragma target 3.0
            uniform float _fresnelPower;
            uniform float _SwimFreq;
            uniform float _SwimAmplitude;
            uniform float _TimeMult;
            UNITY_INSTANCING_BUFFER_START(Properties)
                UNITY_DEFINE_INSTANCED_PROP(float, _FlapOffset)
#define _FlapOffset_arr Properties
            UNITY_INSTANCING_BUFFER_END(Properties)
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_9993 = _Time;
                v.vertex.xyz += ((sin((3.141592654*((_TimeMult*((node_9993.g+UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset))+(sin((node_9993.g*1.2*UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset)))*0.3+0.3)))+(-1*o.uv0.r))*_SwimFreq))*float3(1,0,0)*_SwimAmplitude)*o.uv0.r);
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
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - 0;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float node_1889 = 0.25;
                float3 w = float3(node_1889,node_1889,node_1889)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_1889,node_1889,node_1889);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = i.vertexColor.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_2457 = (pow(1.0-max(0,dot(i.normalDir, viewDirection)),_fresnelPower)*0.2);
                float3 emissive = float3(node_2457,node_2457,node_2457);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma multi_compile_instancing
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 ps4 
            #pragma target 3.0
            uniform float _fresnelPower;
            uniform float _SwimFreq;
            uniform float _SwimAmplitude;
            uniform float _TimeMult;
            UNITY_INSTANCING_BUFFER_START(Properties)
                UNITY_DEFINE_INSTANCED_PROP(float, _FlapOffset)
#define _FlapOffset_arr Properties
            UNITY_INSTANCING_BUFFER_END(Properties)
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_9993 = _Time;
                v.vertex.xyz += ((sin((3.141592654*((_TimeMult*((node_9993.g+UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset))+(sin((node_9993.g*1.2*UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset)))*0.3+0.3)))+(-1*o.uv0.r))*_SwimFreq))*float3(1,0,0)*_SwimAmplitude)*o.uv0.r);
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
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float node_1889 = 0.25;
                float3 w = float3(node_1889,node_1889,node_1889)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_1889,node_1889,node_1889);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 diffuseColor = i.vertexColor.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

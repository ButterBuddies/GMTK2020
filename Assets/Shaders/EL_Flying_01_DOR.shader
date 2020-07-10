// Upgrade NOTE: upgraded instancing buffer 'Properties' to new syntax.

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,gpui:True,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:3,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.8096477,fgcg:0.8488148,fgcb:0.7709095,fgca:1,fgde:0.01,fgrn:50,fgrf:1000,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1,x:34798,y:33205,varname:node_1,prsc:2|diff-974-RGB,spec-7499-OUT,lwrap-1889-OUT,voffset-7008-OUT;n:type:ShaderForge.SFN_Vector1,id:1889,x:34587,y:33343,varname:node_1889,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Panner,id:3479,x:33585,y:34318,varname:node_3479,prsc:2,spu:1,spv:0|UVIN-7541-UVOUT,DIST-8927-OUT;n:type:ShaderForge.SFN_Multiply,id:3705,x:33892,y:33557,varname:node_3705,prsc:2|A-6201-OUT,B-2216-OUT;n:type:ShaderForge.SFN_Time,id:1595,x:32644,y:33647,varname:node_1595,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6122,x:33207,y:33612,varname:node_6122,prsc:2|A-8927-OUT,B-2296-OUT;n:type:ShaderForge.SFN_Vector3,id:2216,x:33740,y:33692,varname:node_2216,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Multiply,id:6201,x:33714,y:33557,varname:node_6201,prsc:2|A-1665-G,B-506-OUT,C-3311-OUT;n:type:ShaderForge.SFN_Slider,id:506,x:33274,y:33544,ptovrint:False,ptlb:BobAmplitude,ptin:_BobAmplitude,varname:_BobAmplitude,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1307692,max:0.2;n:type:ShaderForge.SFN_Panner,id:3616,x:33585,y:34156,varname:node_3616,prsc:2,spu:-1,spv:0|UVIN-7541-UVOUT,DIST-8927-OUT;n:type:ShaderForge.SFN_Multiply,id:7782,x:34505,y:34196,varname:node_7782,prsc:2|A-8386-G,B-3952-OUT,C-2035-OUT,D-5478-OUT;n:type:ShaderForge.SFN_Tex2d,id:8386,x:34141,y:34189,varname:_node_8386,prsc:2,ntxv:3,isnm:True|UVIN-9584-OUT,TEX-2224-TEX;n:type:ShaderForge.SFN_Tex2d,id:980,x:34159,y:34324,varname:_node_980,prsc:2,ntxv:3,isnm:True|UVIN-1840-OUT,TEX-2224-TEX;n:type:ShaderForge.SFN_Slider,id:3952,x:33968,y:34535,ptovrint:False,ptlb:FlapAmplitude,ptin:_FlapAmplitude,varname:_FlapAmplitude,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_ComponentMask,id:6104,x:33590,y:33992,varname:node_6104,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7541-UVOUT;n:type:ShaderForge.SFN_Round,id:2035,x:33754,y:33992,varname:node_2035,prsc:2|IN-6104-OUT;n:type:ShaderForge.SFN_OneMinus,id:6204,x:33956,y:33992,varname:node_6204,prsc:2|IN-2035-OUT;n:type:ShaderForge.SFN_Multiply,id:4406,x:34516,y:34343,varname:node_4406,prsc:2|A-980-G,B-6204-OUT,C-3952-OUT,D-5478-OUT;n:type:ShaderForge.SFN_Add,id:8483,x:34505,y:34004,varname:node_8483,prsc:2|A-7782-OUT,B-4406-OUT;n:type:ShaderForge.SFN_Tex2d,id:410,x:34215,y:33745,varname:_FalloffGrad_copy,prsc:2,ntxv:3,isnm:False|TEX-2314-TEX;n:type:ShaderForge.SFN_Multiply,id:1974,x:34505,y:33760,cmnt:Add Falloff to flapping masks the middle,varname:node_1974,prsc:2|A-410-R,B-8483-OUT;n:type:ShaderForge.SFN_Add,id:7008,x:34396,y:33571,cmnt:Add Bob to Flap,varname:node_7008,prsc:2|A-3705-OUT,B-1974-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2314,x:34005,y:33771,ptovrint:False,ptlb:BirdFlapGradient,ptin:_BirdFlapGradient,varname:_BirdFlapGradient,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1665,x:33494,y:33356,varname:node_1665,prsc:2,ntxv:3,isnm:True|TEX-2224-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2224,x:33242,y:34474,ptovrint:False,ptlb:BirdFlapNormal,ptin:_BirdFlapNormal,varname:_BirdFlapNormal,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:3176,x:32559,y:34221,ptovrint:False,ptlb:FlapSpeed,ptin:_FlapSpeed,varname:_FlapSpeed,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.282051,max:3;n:type:ShaderForge.SFN_Multiply,id:1840,x:33901,y:34320,varname:node_1840,prsc:2|A-3479-UVOUT,B-3176-OUT;n:type:ShaderForge.SFN_Multiply,id:2296,x:33058,y:34034,varname:node_2296,prsc:2|A-8432-OUT,B-3176-OUT;n:type:ShaderForge.SFN_Cos,id:3311,x:33415,y:33641,varname:node_3311,prsc:2|IN-6122-OUT;n:type:ShaderForge.SFN_Tau,id:8432,x:32885,y:34089,varname:node_8432,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:7541,x:33342,y:33777,varname:node_7541,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector3,id:5478,x:34135,y:34658,varname:node_5478,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Multiply,id:9584,x:33938,y:34156,varname:node_9584,prsc:2|A-9690-OUT,B-3176-OUT;n:type:ShaderForge.SFN_OneMinus,id:9690,x:33754,y:34156,varname:node_9690,prsc:2|IN-3616-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:9915,x:32273,y:33694,ptovrint:False,ptlb:ControllerPressure,ptin:_ControllerPressure,varname:node_9915,prsc:2,glob:True,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1569,x:31454,y:33072,ptovrint:False,ptlb:FlapOffset,ptin:_FlapOffset,varname:_FlapOffset,prsc:2,glob:False,inst:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_RemapRange,id:9519,x:32455,y:33728,varname:node_9519,prsc:2,frmn:0,frmx:1,tomn:0,tomx:20|IN-9915-OUT;n:type:ShaderForge.SFN_Add,id:8927,x:32457,y:33205,varname:node_8927,prsc:2|A-3706-OUT,B-838-OUT;n:type:ShaderForge.SFN_Time,id:6348,x:31840,y:32894,varname:node_6348,prsc:2;n:type:ShaderForge.SFN_Add,id:3706,x:32226,y:33102,varname:node_3706,prsc:2|A-6348-T,B-1569-OUT;n:type:ShaderForge.SFN_Sin,id:9706,x:31861,y:33251,varname:node_9706,prsc:2|IN-6610-OUT;n:type:ShaderForge.SFN_Multiply,id:6610,x:31682,y:33251,varname:node_6610,prsc:2|A-6348-T,B-5460-OUT,C-1569-OUT;n:type:ShaderForge.SFN_RemapRange,id:838,x:32060,y:33251,varname:node_838,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-9706-OUT;n:type:ShaderForge.SFN_Vector1,id:5460,x:31430,y:33271,varname:node_5460,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:7499,x:34512,y:33259,varname:node_7499,prsc:2,v1:0;n:type:ShaderForge.SFN_VertexColor,id:974,x:34194,y:33185,varname:node_974,prsc:2;proporder:506-3176-3952-2314-2224-1569;pass:END;sub:END;*/

Shader "EverythingLibrary/Flying_01_DOR" {
    Properties {
        _BobAmplitude ("BobAmplitude", Range(0, 0.2)) = 0.1307692
        _FlapSpeed ("FlapSpeed", Range(0, 3)) = 1.282051
        _FlapAmplitude ("FlapAmplitude", Range(0, 3)) = 0
        _BirdFlapGradient ("BirdFlapGradient", 2D) = "black" {}
        _BirdFlapNormal ("BirdFlapNormal", 2D) = "bump" {}
        _FlapOffset ("FlapOffset", Float ) = 1
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
            Cull Off
            
            
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
            uniform float _BobAmplitude;
            uniform float _FlapAmplitude;
            uniform sampler2D _BirdFlapGradient; uniform float4 _BirdFlapGradient_ST;
            uniform sampler2D _BirdFlapNormal; uniform float4 _BirdFlapNormal_ST;
            uniform float _FlapSpeed;
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
                float3 node_1665 = UnpackNormal(tex2Dlod(_BirdFlapNormal,float4(TRANSFORM_TEX(o.uv0, _BirdFlapNormal),0.0,0)));
                float4 node_6348 = _Time;
                float node_8927 = ((node_6348.g+UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset))+(sin((node_6348.g*1.0*UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset)))*0.5+0.5));
                float4 _FalloffGrad_copy = tex2Dlod(_BirdFlapGradient,float4(TRANSFORM_TEX(o.uv0, _BirdFlapGradient),0.0,0));
                float2 node_9584 = ((1.0 - (o.uv0+node_8927*float2(-1,0)))*_FlapSpeed);
                float3 _node_8386 = UnpackNormal(tex2Dlod(_BirdFlapNormal,float4(TRANSFORM_TEX(node_9584, _BirdFlapNormal),0.0,0)));
                float node_2035 = round(o.uv0.r);
                float3 node_5478 = float3(0,1,0);
                float2 node_1840 = ((o.uv0+node_8927*float2(1,0))*_FlapSpeed);
                float3 _node_980 = UnpackNormal(tex2Dlod(_BirdFlapNormal,float4(TRANSFORM_TEX(node_1840, _BirdFlapNormal),0.0,0)));
                v.vertex.xyz += (((node_1665.g*_BobAmplitude*cos((node_8927*(6.28318530718*_FlapSpeed))))*float3(0,1,0))+(_FalloffGrad_copy.r*((_node_8386.g*_FlapAmplitude*node_2035*node_5478)+(_node_980.g*(1.0 - node_2035)*_FlapAmplitude*node_5478))));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID(i);
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
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
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_7499 = 0.0;
                float3 specularColor = float3(node_7499,node_7499,node_7499);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 indirectSpecular = (gi.indirect.specular)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float node_1889 = 0.25;
                float3 w = float3(node_1889,node_1889,node_1889)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = i.vertexColor.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            Cull Off
            
            
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
            uniform float _BobAmplitude;
            uniform float _FlapAmplitude;
            uniform sampler2D _BirdFlapGradient; uniform float4 _BirdFlapGradient_ST;
            uniform sampler2D _BirdFlapNormal; uniform float4 _BirdFlapNormal_ST;
            uniform float _FlapSpeed;
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
                float3 node_1665 = UnpackNormal(tex2Dlod(_BirdFlapNormal,float4(TRANSFORM_TEX(o.uv0, _BirdFlapNormal),0.0,0)));
                float4 node_6348 = _Time;
                float node_8927 = ((node_6348.g+UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset))+(sin((node_6348.g*1.0*UNITY_ACCESS_INSTANCED_PROP(_FlapOffset_arr, _FlapOffset)))*0.5+0.5));
                float4 _FalloffGrad_copy = tex2Dlod(_BirdFlapGradient,float4(TRANSFORM_TEX(o.uv0, _BirdFlapGradient),0.0,0));
                float2 node_9584 = ((1.0 - (o.uv0+node_8927*float2(-1,0)))*_FlapSpeed);
                float3 _node_8386 = UnpackNormal(tex2Dlod(_BirdFlapNormal,float4(TRANSFORM_TEX(node_9584, _BirdFlapNormal),0.0,0)));
                float node_2035 = round(o.uv0.r);
                float3 node_5478 = float3(0,1,0);
                float2 node_1840 = ((o.uv0+node_8927*float2(1,0))*_FlapSpeed);
                float3 _node_980 = UnpackNormal(tex2Dlod(_BirdFlapNormal,float4(TRANSFORM_TEX(node_1840, _BirdFlapNormal),0.0,0)));
                v.vertex.xyz += (((node_1665.g*_BobAmplitude*cos((node_8927*(6.28318530718*_FlapSpeed))))*float3(0,1,0))+(_FalloffGrad_copy.r*((_node_8386.g*_FlapAmplitude*node_2035*node_5478)+(_node_980.g*(1.0 - node_2035)*_FlapAmplitude*node_5478))));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID(i);
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_7499 = 0.0;
                float3 specularColor = float3(node_7499,node_7499,node_7499);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float node_1889 = 0.25;
                float3 w = float3(node_1889,node_1889,node_1889)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 diffuseColor = i.vertexColor.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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

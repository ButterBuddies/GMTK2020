// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,gpui:True,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:3,atcv:False,rfrpo:False,rfrpn:Refraction2,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.7090255,fgcg:0.8409815,fgcb:0.9084502,fgca:1,fgde:0.01,fgrn:50,fgrf:1000,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1,x:34806,y:33155,varname:node_1,prsc:2|emission-6287-OUT,alpha-6077-OUT,refract-109-OUT;n:type:ShaderForge.SFN_Multiply,id:2457,x:34135,y:32978,varname:node_2457,prsc:2|A-2300-RGB,B-9399-OUT;n:type:ShaderForge.SFN_Fresnel,id:4380,x:33687,y:33148,varname:node_4380,prsc:2|NRM-752-OUT,EXP-431-OUT;n:type:ShaderForge.SFN_LightColor,id:9303,x:34116,y:33119,varname:node_9303,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:502,x:32968,y:33332,prsc:2,pt:False;n:type:ShaderForge.SFN_FragmentPosition,id:5442,x:32547,y:33687,varname:node_5442,prsc:2;n:type:ShaderForge.SFN_ViewPosition,id:5515,x:32547,y:33513,varname:node_5515,prsc:2;n:type:ShaderForge.SFN_Vector1,id:559,x:33694,y:33621,varname:node_559,prsc:2,v1:2;n:type:ShaderForge.SFN_Transform,id:3786,x:33458,y:33311,varname:node_3786,prsc:2,tffrom:0,tfto:3|IN-502-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1347,x:33645,y:33311,varname:node_1347,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3786-XYZ;n:type:ShaderForge.SFN_Multiply,id:291,x:33832,y:33387,varname:node_291,prsc:2|A-1347-OUT,B-4059-OUT;n:type:ShaderForge.SFN_Slider,id:4059,x:33440,y:33485,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:_Refraction,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.08,max:1;n:type:ShaderForge.SFN_Multiply,id:109,x:34205,y:33466,varname:node_109,prsc:2|A-291-OUT,B-4914-OUT;n:type:ShaderForge.SFN_Subtract,id:4401,x:32985,y:33562,varname:node_4401,prsc:2|A-5515-XYZ,B-5442-XYZ;n:type:ShaderForge.SFN_Normalize,id:1078,x:33175,y:33562,varname:node_1078,prsc:2|IN-4401-OUT;n:type:ShaderForge.SFN_Dot,id:9177,x:33382,y:33552,varname:node_9177,prsc:2,dt:0|A-502-OUT,B-1078-OUT;n:type:ShaderForge.SFN_Power,id:4914,x:33872,y:33545,varname:node_4914,prsc:2|VAL-8505-OUT,EXP-559-OUT;n:type:ShaderForge.SFN_RemapRange,id:8505,x:33547,y:33552,varname:node_8505,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-9177-OUT;n:type:ShaderForge.SFN_Add,id:9343,x:34369,y:33185,varname:node_9343,prsc:2|A-2457-OUT,B-9303-RGB;n:type:ShaderForge.SFN_Slider,id:431,x:33281,y:33173,ptovrint:False,ptlb:FresnelExp,ptin:_FresnelExp,varname:_FresnelExp,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:3,max:5;n:type:ShaderForge.SFN_Clamp01,id:6077,x:34168,y:33345,varname:node_6077,prsc:2|IN-4380-OUT;n:type:ShaderForge.SFN_Clamp01,id:6287,x:34545,y:33230,varname:node_6287,prsc:2|IN-9343-OUT;n:type:ShaderForge.SFN_VertexColor,id:2300,x:33698,y:32513,varname:node_2300,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:752,x:33404,y:32973,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9399,x:32987,y:33006,varname:node_9399,prsc:2|A-4380-OUT,B-3771-OUT;n:type:ShaderForge.SFN_Vector1,id:3771,x:32804,y:33073,varname:node_3771,prsc:2,v1:0.5;proporder:4059-431;pass:END;sub:END;*/

Shader "EverythingLibrary/ParticleTransp_01_DOR" {
    Properties {
        _Refraction ("Refraction", Range(-1, 1)) = 0.08
        _FresnelExp ("FresnelExp", Range(-5, 5)) = 3
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ "Refraction2" }
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_instancing
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 ps4 
            #pragma target 3.0
            uniform sampler2D Refraction2;
            uniform float _Refraction;
            uniform float _FresnelExp;
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
                float4 projPos : TEXCOORD2;
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
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID(i);
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + ((mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*_Refraction)*pow((dot(i.normalDir,normalize((_WorldSpaceCameraPos-i.posWorld.rgb)))*-1.0+1.0),2.0));
                float4 sceneColor = tex2D(Refraction2, sceneUVs);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
////// Emissive:
                float node_4380 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelExp);
                float3 emissive = saturate(((i.vertexColor.rgb*(node_4380*0.5))+_LightColor0.rgb));
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,saturate(node_4380)),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

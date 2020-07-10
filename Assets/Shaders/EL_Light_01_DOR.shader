// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,gpui:True,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:3,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.6391106,fgcg:0.8026343,fgcb:0.8996344,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32692,varname:node_4795,prsc:2|emission-3249-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31622,y:32589,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Multiply,id:55,x:32287,y:32688,varname:node_55,prsc:2|A-2053-RGB,B-396-OUT,C-6978-OUT;n:type:ShaderForge.SFN_Slider,id:6978,x:31845,y:33033,ptovrint:False,ptlb:Strength,ptin:_Strength,varname:_Strength,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:2;n:type:ShaderForge.SFN_Smoothstep,id:9703,x:31874,y:32800,varname:node_9703,prsc:2|A-554-OUT,B-6173-OUT,V-2053-A;n:type:ShaderForge.SFN_Vector1,id:554,x:31537,y:32793,varname:node_554,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:6173,x:31582,y:32978,varname:node_6173,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:8666,x:31899,y:32351,ptovrint:False,ptlb:node_8666,ptin:_node_8666,varname:node_8666,prsc:2,glob:False,inst:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:3249,x:32526,y:32763,varname:node_3249,prsc:2|A-55-OUT,B-9703-OUT;n:type:ShaderForge.SFN_Vector1,id:396,x:31566,y:32199,varname:node_396,prsc:2,v1:0.5;proporder:6978;pass:END;sub:END;*/

Shader "EverythingLibrary/Light_01_DOR" {
    Properties {
        _Strength ("Strength", Range(0, 2)) = 0.5
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
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_instancing
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 ps4 
            #pragma target 3.0
            uniform float _Strength;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 vertexColor : COLOR;
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID(i);
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float node_396 = 0.5;
                float3 emissive = ((i.vertexColor.rgb*node_396*_Strength)*smoothstep( 0.0, 1.0, i.vertexColor.a ));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

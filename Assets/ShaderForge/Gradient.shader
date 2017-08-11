// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33811,y:32648,varname:node_3138,prsc:2|emission-7789-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32457,y:32802,ptovrint:False,ptlb:Gradient 1 Color 1,ptin:_Gradient1Color1,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6617647,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:6627,x:32457,y:32622,ptovrint:False,ptlb:Gradient 1 Color 2,ptin:_Gradient1Color2,varname:node_6627,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9673428,c3:0.8308824,c4:1;n:type:ShaderForge.SFN_Lerp,id:3839,x:32945,y:32755,varname:node_3839,prsc:2|A-6627-RGB,B-7241-RGB,T-7082-OUT;n:type:ShaderForge.SFN_TexCoord,id:4490,x:32261,y:32969,varname:node_4490,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:7082,x:32468,y:32969,varname:node_7082,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-4490-UVOUT;n:type:ShaderForge.SFN_Lerp,id:7789,x:33392,y:32569,varname:node_7789,prsc:2|A-3839-OUT,B-6566-OUT,T-783-OUT;n:type:ShaderForge.SFN_Slider,id:783,x:33037,y:33017,ptovrint:False,ptlb:Progression,ptin:_Progression,varname:node_783,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:2600,x:32467,y:32067,ptovrint:False,ptlb:Gradient 2 Color 1,ptin:_Gradient2Color1,varname:node_2600,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3439031,c2:0.3016869,c3:0.6617647,c4:1;n:type:ShaderForge.SFN_Color,id:6754,x:32467,y:32261,ptovrint:False,ptlb:Gradient 2 Color 2,ptin:_Gradient2Color2,varname:node_6754,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.02413793,c2:0,c3:0.2058824,c4:1;n:type:ShaderForge.SFN_Lerp,id:6566,x:32984,y:32347,varname:node_6566,prsc:2|A-2600-RGB,B-6754-RGB,T-1434-OUT;n:type:ShaderForge.SFN_TexCoord,id:3924,x:32267,y:32441,varname:node_3924,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:1434,x:32467,y:32441,varname:node_1434,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3924-UVOUT;proporder:7241-6627-2600-6754-783;pass:END;sub:END;*/

Shader "Shader Forge/Gradient" {
    Properties {
        _Gradient1Color1 ("Gradient 1 Color 1", Color) = (0.6617647,1,1,1)
        _Gradient1Color2 ("Gradient 1 Color 2", Color) = (1,0.9673428,0.8308824,1)
        _Gradient2Color1 ("Gradient 2 Color 1", Color) = (0.3439031,0.3016869,0.6617647,1)
        _Gradient2Color2 ("Gradient 2 Color 2", Color) = (0.02413793,0,0.2058824,1)
        _Progression ("Progression", Range(0, 1)) = 1
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Gradient1Color1;
            uniform float4 _Gradient1Color2;
            uniform float _Progression;
            uniform float4 _Gradient2Color1;
            uniform float4 _Gradient2Color2;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float3 emissive = lerp(lerp(_Gradient1Color2.rgb,_Gradient1Color1.rgb,i.uv0.g),lerp(_Gradient2Color1.rgb,_Gradient2Color2.rgb,i.uv0.g),_Progression);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32568,y:32316,varname:node_4795,prsc:2|emission-5968-OUT;n:type:ShaderForge.SFN_Tex2d,id:1872,x:31261,y:32232,ptovrint:False,ptlb:MaskNoice,ptin:_MaskNoice,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-6768-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5968,x:32048,y:32371,varname:node_5968,prsc:2|A-9155-OUT,B-475-RGB,C-5171-RGB,D-6860-OUT;n:type:ShaderForge.SFN_VertexColor,id:475,x:31739,y:32365,varname:node_475,prsc:2;n:type:ShaderForge.SFN_Color,id:5171,x:31739,y:32521,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:6860,x:31739,y:32674,varname:node_6860,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:3984,x:31337,y:31659,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_node_4769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:21672833b40585546bbe38821c1a67de,ntxv:0,isnm:False|UVIN-4930-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3578,x:31675,y:32079,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:_node_8466,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:55dc59ed2ddca9f4f89077b8e7028f3f,ntxv:0,isnm:False|UVIN-1628-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9155,x:31920,y:32136,varname:node_9155,prsc:2|A-4008-OUT,B-3578-RGB,C-1660-A;n:type:ShaderForge.SFN_Multiply,id:4008,x:31647,y:31770,varname:node_4008,prsc:2|A-3984-RGB,B-7546-OUT;n:type:ShaderForge.SFN_Slider,id:7546,x:31233,y:31866,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:_node_803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.692308,max:6;n:type:ShaderForge.SFN_TexCoord,id:1261,x:31261,y:32074,varname:node_1261,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1628,x:31491,y:32232,varname:node_1628,prsc:2,spu:0,spv:0.1|UVIN-1261-UVOUT,DIST-1872-R;n:type:ShaderForge.SFN_Panner,id:6768,x:31097,y:32232,varname:node_6768,prsc:2,spu:-0.5,spv:-0.6|UVIN-5070-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5070,x:30931,y:32232,varname:node_5070,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4930,x:31171,y:31659,varname:node_4930,prsc:2,spu:0,spv:0.4|UVIN-6974-UVOUT,DIST-9276-R;n:type:ShaderForge.SFN_TexCoord,id:207,x:30747,y:31490,varname:node_207,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:9276,x:30924,y:31659,ptovrint:False,ptlb:Noice,ptin:_Noice,varname:_MainTex_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5566d690d0bdb454c885259313b76333,ntxv:2,isnm:False|UVIN-4167-UVOUT;n:type:ShaderForge.SFN_Panner,id:4167,x:30760,y:31659,varname:node_4167,prsc:2,spu:-0.8,spv:-0.8|UVIN-2623-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2623,x:30594,y:31659,varname:node_2623,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6974,x:30924,y:31490,varname:node_6974,prsc:2,spu:-0.3,spv:-0.3|UVIN-207-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1660,x:31517,y:32442,ptovrint:False,ptlb:Reflective,ptin:_Reflective,varname:_node_1660,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4366a62ce0a96624c888482db714a1a8,ntxv:0,isnm:False|UVIN-2128-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4833,x:31135,y:32449,varname:node_4833,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2128,x:31301,y:32449,varname:node_2128,prsc:2,spu:-0.7,spv:0|UVIN-4833-UVOUT;n:type:ShaderForge.SFN_Slider,id:5885,x:34028,y:33200,ptovrint:False,ptlb:Refraction Intensity_copy_copy,ptin:_RefractionIntensity_copy_copy,varname:_RefractionIntensity_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4347,x:34593,y:33172,varname:node_4347,prsc:2|A-3476-OUT,B-6007-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3476,x:34423,y:33099,varname:node_3476,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1077-RGB;n:type:ShaderForge.SFN_Vector1,id:6523,x:34593,y:33099,varname:node_6523,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Tex2d,id:1077,x:34185,y:33014,ptovrint:False,ptlb:Refraction_copy_copy,ptin:_Refraction_copy_copy,varname:_Refraction_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_TexCoord,id:5962,x:33827,y:32953,varname:node_5962,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:2028,x:33998,y:33014,varname:node_2028,prsc:2|A-5962-UVOUT,B-7257-OUT;n:type:ShaderForge.SFN_Vector1,id:7257,x:33827,y:33110,varname:node_7257,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4081,x:34593,y:33025,varname:node_4081,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6983,x:34593,y:32878,varname:node_6983,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5051,x:34593,y:32934,varname:node_5051,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Lerp,id:3865,x:34423,y:32972,varname:node_3865,prsc:2|A-4421-OUT,B-1077-RGB,T-5885-OUT;n:type:ShaderForge.SFN_Vector3,id:4421,x:34185,y:32893,varname:node_4421,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Multiply,id:6007,x:34423,y:33251,varname:node_6007,prsc:2|A-5885-OUT,B-7330-OUT;n:type:ShaderForge.SFN_Vector1,id:7330,x:34185,y:33279,varname:node_7330,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:9303,x:34593,y:32814,varname:node_9303,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Slider,id:1649,x:34092,y:33264,ptovrint:False,ptlb:Refraction Intensity_copy_copy_copy,ptin:_RefractionIntensity_copy_copy_copy,varname:_RefractionIntensity_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4781,x:34657,y:33236,varname:node_4781,prsc:2|A-5737-OUT,B-3925-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5737,x:34487,y:33163,varname:node_5737,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2666-RGB;n:type:ShaderForge.SFN_Vector1,id:6765,x:34657,y:33163,varname:node_6765,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Tex2d,id:2666,x:34249,y:33078,ptovrint:False,ptlb:Refraction_copy_copy_copy,ptin:_Refraction_copy_copy_copy,varname:_Refraction_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_TexCoord,id:5106,x:33891,y:33017,varname:node_5106,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3798,x:34062,y:33078,varname:node_3798,prsc:2|A-5106-UVOUT,B-3346-OUT;n:type:ShaderForge.SFN_Vector1,id:3346,x:33891,y:33174,varname:node_3346,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2932,x:34657,y:33089,varname:node_2932,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:7409,x:34657,y:32942,varname:node_7409,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7858,x:34657,y:32998,varname:node_7858,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Lerp,id:8291,x:34487,y:33036,varname:node_8291,prsc:2|A-1936-OUT,B-2666-RGB,T-1649-OUT;n:type:ShaderForge.SFN_Vector3,id:1936,x:34249,y:32957,varname:node_1936,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Multiply,id:3925,x:34487,y:33315,varname:node_3925,prsc:2|A-1649-OUT,B-8487-OUT;n:type:ShaderForge.SFN_Vector1,id:8487,x:34249,y:33343,varname:node_8487,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:155,x:34657,y:32878,varname:node_155,prsc:2,v1:0.2;proporder:3984-5171-3578-1872-7546-9276-1660;pass:END;sub:END;*/

Shader "FireWing/Wing_Sub" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _Mask ("Mask", 2D) = "white" {}
        _MaskNoice ("MaskNoice", 2D) = "black" {}
        _Transparency ("Transparency", Range(0, 6)) = 3.692308
        _Noice ("Noice", 2D) = "black" {}
        _Reflective ("Reflective", 2D) = "white" {}
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
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _MaskNoice; uniform float4 _MaskNoice_ST;
            uniform float4 _TintColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Transparency;
            uniform sampler2D _Noice; uniform float4 _Noice_ST;
            uniform sampler2D _Reflective; uniform float4 _Reflective_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_3497 = _Time;
                float2 node_4167 = (i.uv0+node_3497.g*float2(-0.8,-0.8));
                float4 _Noice_var = tex2D(_Noice,TRANSFORM_TEX(node_4167, _Noice));
                float2 node_4930 = ((i.uv0+node_3497.g*float2(-0.3,-0.3))+_Noice_var.r*float2(0,0.4));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4930, _MainTex));
                float2 node_6768 = (i.uv0+node_3497.g*float2(-0.5,-0.6));
                float4 _MaskNoice_var = tex2D(_MaskNoice,TRANSFORM_TEX(node_6768, _MaskNoice));
                float2 node_1628 = (i.uv0+_MaskNoice_var.r*float2(0,0.1));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_1628, _Mask));
                float2 node_2128 = (i.uv0+node_3497.g*float2(-0.7,0));
                float4 _Reflective_var = tex2D(_Reflective,TRANSFORM_TEX(node_2128, _Reflective));
                float3 emissive = (((_MainTex_var.rgb*_Transparency)*_Mask_var.rgb*_Reflective_var.a)*i.vertexColor.rgb*_TintColor.rgb*2.0);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}

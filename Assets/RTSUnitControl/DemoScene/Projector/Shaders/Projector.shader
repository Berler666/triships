// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'

Shader "RTSUnitControl/Projector"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _ShadowTex ("Cookie", 2D) = "" {}
    }
    
    Subshader
    {
        Tags {"Queue"="Transparent"}

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
    
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment

            struct V2F
            {
                float4 uvShadow : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            float4x4 unity_Projector;
            V2F Vertex (float4 vertex : POSITION)
            {
                V2F o;
                o.pos = mul(UNITY_MATRIX_MVP, vertex);
                o.uvShadow = mul(unity_Projector, vertex);
                return o;
            }

            fixed4 _Color;
            sampler2D _ShadowTex;
            fixed4 Fragment (V2F i) : SV_Target
            {
                return tex2Dproj (_ShadowTex, UNITY_PROJ_COORD(i.uvShadow)) * _Color;
            }
            ENDCG
        }
    }
}
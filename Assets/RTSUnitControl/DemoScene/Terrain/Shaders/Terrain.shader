Shader "RTSUnitControl/Terrain"
{
    Properties
    {
        [HideInInspector] _Control ("Control (RGBA)", 2D) = "red" {}
        [HideInInspector] _Splat3 ("Layer 3 (A)", 2D) = "white" {}
        [HideInInspector] _Splat2 ("Layer 2 (B)", 2D) = "white" {}
        [HideInInspector] _Splat1 ("Layer 1 (G)", 2D) = "white" {}
        [HideInInspector] _Splat0 ("Layer 0 (R)", 2D) = "white" {}
        [HideInInspector] _Normal3 ("Normal 3 (A)", 2D) = "bump" {}
        [HideInInspector] _Normal2 ("Normal 2 (B)", 2D) = "bump" {}
        [HideInInspector] _Normal1 ("Normal 1 (G)", 2D) = "bump" {}
        [HideInInspector] _Normal0 ("Normal 0 (R)", 2D) = "bump" {}
        // used in fallback on old cards & base map
        [HideInInspector] _MainTex ("BaseMap (RGB)", 2D) = "white" {}
        [HideInInspector] _Color ("Main Color", Color) = (1,1,1,1)

        _SideBrightness("Side Brightness", Range(0.05, 0.5)) = 0.3
        _SideScale ("Side Scale", float) = 15
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Geometry-100"
            "RenderType" = "Opaque"
        }

        CGPROGRAM
        #pragma surface Surface Lambert vertex:Vertex
        #pragma target 3.0

        sampler2D _Control;
        sampler2D _Splat0, _Splat1, _Splat2, _Splat3;
        sampler2D _Normal0, _Normal1, _Normal2, _Normal3;
        half _SideBrightness;
        half _SideScale;

        struct Input
        {
            float2 uv_Control;
            float2 uv_Splat0;
            float3 worldPos;
            float3 worldNorm;
        };

        void Vertex(inout appdata_full v, out Input data)
        {
            UNITY_INITIALIZE_OUTPUT(Input, data);
            data.worldNorm = abs(v.normal);
            v.tangent.xyz = cross(v.normal, float3(0, 0, 1));
            v.tangent.w = -1;
        }

        void Surface(Input i, inout SurfaceOutput o)
        {
            float3 projNorm = pow(saturate(i.worldNorm * 1.1), i.worldNorm.y / _SideBrightness);
            fixed4 control = tex2D(_Control, i.uv_Control);

            o.Albedo = control.r * tex2D(_Splat0, i.uv_Splat0).rgb;
            o.Albedo += control.g * tex2D(_Splat1, i.uv_Splat0).rgb;
            o.Albedo += control.b * tex2D(_Splat2, i.uv_Splat0).rgb;
            o.Albedo += control.a * tex2D(_Splat3, i.uv_Splat0).rgb;
            o.Albedo = lerp(o.Albedo, tex2D(_Splat1, i.worldPos.zy / _SideScale), projNorm.x);
            o.Albedo = lerp(o.Albedo, tex2D(_Splat1, i.worldPos.xy / _SideScale), projNorm.z);

            fixed4 normal = control.r * tex2D(_Normal0, i.uv_Splat0);
            normal += control.g * tex2D(_Normal1, i.uv_Splat0);
            normal += control.b * tex2D(_Normal2, i.uv_Splat0);
            normal += control.a * tex2D(_Normal3, i.uv_Splat0);
            normal = lerp(normal, tex2D(_Normal1, i.worldPos.zy / _SideScale), projNorm.x);
            normal = lerp(normal, tex2D(_Normal1, i.worldPos.xy / _SideScale), projNorm.z);
            o.Normal = UnpackNormal(normal);
        }

        ENDCG
    }

    Dependency "AddPassShader" = "Hidden/RTSUnitControl/AddPass"
    Fallback "Diffuse"
}      
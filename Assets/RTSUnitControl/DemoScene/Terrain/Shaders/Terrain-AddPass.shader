Shader "Hidden/RTSUnitControl/AddPass"
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
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Geometry-99"
            "RenderType" = "Opaque"
        }

        CGPROGRAM
        #pragma surface Surface Lambert vertex:Vertex decal:add
        #pragma target 3.0

        sampler2D _Control;
        sampler2D _Splat0, _Splat1, _Splat2, _Splat3;
        sampler2D _Normal0, _Normal1, _Normal2, _Normal3;
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
            float3 projNorm = pow(saturate(i.worldNorm * 1.1), i.worldNorm.y * 8);
            fixed4 control = tex2D(_Control, i.uv_Control);
            control = lerp(control, fixed4(0, 0, 0, 0), projNorm.x);
            control = lerp(control, fixed4(0, 0, 0, 0), projNorm.z);

            o.Albedo = control.r * tex2D(_Splat0, i.uv_Splat0).rgb;
            o.Albedo += control.g * tex2D(_Splat1, i.uv_Splat0).rgb;
            o.Albedo += control.b * tex2D(_Splat2, i.uv_Splat0).rgb;
            o.Albedo += control.a * tex2D(_Splat3, i.uv_Splat0).rgb;

            fixed4 normal = control.r * tex2D(_Normal0, i.uv_Splat0);
            normal += control.g * tex2D(_Normal1, i.uv_Splat0);
            normal += control.b * tex2D(_Normal2, i.uv_Splat0);
            normal += control.a * tex2D(_Normal3, i.uv_Splat0);
            o.Normal = UnpackNormal(normal);
        }

        ENDCG
    }

    Dependency "AddPassShader" = "Hidden/RTSUnitControl/AddPass"
    Fallback "Diffuse"
}        
Shader "UI/GrayColor"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _GrayScale ("GrayScale", Range(0,1)) = 1
    }
 
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
       
        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
           
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float2 texcoord : TEXCOORD0;
            };
 
            struct v2f
            {
                float4 vertex   : SV_POSITION;
                half2 texcoord  : TEXCOORD0;
            };
           
            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
                OUT.texcoord = IN.texcoord;
                return OUT;
            }
           
            sampler2D _MainTex;
            fixed _GrayScale;
 
            fixed4 frag(v2f IN) : SV_Target
            {
                half4 c = tex2D(_MainTex, IN.texcoord);
                fixed grayscale = Luminance(c.rgb);
                c.rgb = grayscale.xxx * _GrayScale;
                return c;
            }
            ENDCG
        }
    }
}
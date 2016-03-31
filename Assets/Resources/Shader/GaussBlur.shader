Shader "custom/image/GaussBlur" {
    Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _TextureSize ("_TextureSize",Float) = 256
        _BlurRadius ("_BlurRadius",Range(1,15) ) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

 Pass {
 		//alpha混合模式
		Blend SrcAlpha OneMinusSrcAlpha
        CGPROGRAM

          #pragma vertex vert
          #pragma fragment frag
        #include "UnityCG.cginc"


        sampler2D _MainTex;
        int _BlurRadius;
        float _TextureSize;

        struct v2f {
            float4 pos : SV_POSITION;
            float2 uv : TEXCOORD0;
        };


        v2f vert( appdata_img v ) 
        {
            v2f o;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            o.uv = v.texcoord.xy;
            return o;
        } 

		//计算权重
		float GetGaussianDistribution( float x, float y, float rho ) 
		{
			float g = 1.0f / sqrt( 2.0f * 3.141592654f * rho * rho );
			return g * exp( -(x * x + y * y) / (2 * rho * rho) );
		}

		float4 GetGaussBlurColor( float2 uv )
		{
			//算出一个像素的空间
			float space = 1.0/_TextureSize; 
			//参考正态分布曲线图，可以知道 3σ 距离以外的点，权重已经微不足道了。
			//反推即可知道当模糊半径为r时，取σ为 r/3 是一个比较合适的取值。
			float rho = (float)_BlurRadius * space / 3.0;

			//---权重总和
			float weightTotal = 0;
			for( int x = -_BlurRadius ; x <= _BlurRadius ; x++ )
			{
				for( int y = -_BlurRadius ; y <= _BlurRadius ; y++ )
				{
					weightTotal += GetGaussianDistribution(x * space, y * space, rho );
				}
			}
			//--------
			float4 colorTmp = float4(0,0,0,0);
			for( int x = -_BlurRadius ; x <= _BlurRadius ; x++ )
			{
				for( int y = -_BlurRadius ; y <= _BlurRadius ; y++ )
				{
					float weight = GetGaussianDistribution( x * space, y * space, rho )/weightTotal;

					float4 color = tex2D(_MainTex,uv + float2(x * space,y * space));
					color = color * weight;
					colorTmp += color;
				}
			}
			return colorTmp;
		}

        /*
        将上面的函数拷贝进来
        */
        half4 frag(v2f i) : SV_Target 
        {
            //调用普通模糊
            //return GetBlurColor(i.uv);
            //调用高斯模糊  
            return GetGaussBlurColor(i.uv);
            //return tex2D(_MainTex,i.uv);
        }

        ENDCG
        }
    }
    FallBack "Diffuse"
}
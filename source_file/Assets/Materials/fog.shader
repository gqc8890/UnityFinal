Shader "lsc/test_post_fog"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _CameraDepthTexture;
			float4x4 _mtx_view_inv;
			float4x4 _mtx_proj_inv;
			float4x4 _mtx_clip_to_world;


			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;

				float4 screen_pos : TEXCOORD1;
				float2 ndc_pos : TEXCOORD2;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				o.screen_pos = ComputeScreenPos(o.vertex);
				o.ndc_pos = (v.uv) * 2.0 - 1.0;

				return o;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				float4 view_pos;
				float3 world_pos;

				float depth01 = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
				//lsc 取出线性深度,即摄影机空间的z坐标
				float linearDepthZ = LinearEyeDepth(depth01);

				//lsc 纹理映射转换到标准空间
				float4 screen_pos = float4(i.ndc_pos.x, i.ndc_pos.y, depth01, 1);
				//lsc 转成齐次坐标
				screen_pos = screen_pos * linearDepthZ;
				//lsc 还原摄影机空间坐标
				view_pos = mul(_mtx_proj_inv, screen_pos);
				//lsc 世界
				world_pos = mul(_mtx_view_inv, fixed4(view_pos.xyz, 1));

				//高度
				float h_percent = saturate(((world_pos.y - 0.0f) / 20.0f));
				float fac_h = exp(-h_percent * h_percent);

				//距离
				float dis = length(world_pos.xyz - _WorldSpaceCameraPos.xyz);
				float d_percent = 1 - ((dis - 100.0) / 100.0f);
				d_percent = saturate(d_percent);
				float fac_d = exp(-d_percent * d_percent);


				fixed4 final_col;
				final_col.w = 1.0;

				fixed4 col = tex2D(_MainTex, i.uv);
				final_col.rgb = lerp(col.rgb, fixed3(0.0, 0.0, 0.0), fac_d * fac_h);

				return final_col;
			}
			ENDCG
		}
	}
}
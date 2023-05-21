Shader "Examples/Stencil"
{
    Properties
    {
		[IntRange] _StencilID ("Stencil ID", Range(0, 255)) = 0
		_Fade("Fade", Range(0,1)) = 1
    }
	SubShader
    {
        Tags 
		{ 
			"RenderType" = "Transparent"
			"Queue" = "Geometry"
			"RenderPipeline" = "UniversalPipeline"
		}

        Pass
        {
			Blend Zero One
			ZWrite Off

			Stencil
			{
				Ref [_StencilID]
				Comp Always
				Pass Replace
				Fail Keep
			}
        }
    }
}

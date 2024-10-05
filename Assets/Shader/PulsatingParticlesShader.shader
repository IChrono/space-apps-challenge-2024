Shader "Custom/PulsatingParticles"
{
    Properties
    {
        _MainTex ("Particle Texture", 2D) = "white" {}  // La texture della particella
        _PulseSpeed ("Pulse Speed", Float) = 1.0        // Velocità della pulsazione
        _PulseScale ("Pulse Intensity", Float) = 0.5    // Intensità della pulsazione
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            Lighting Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _PulseSpeed;
            float _PulseScale;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float randomOffset : TEXCOORD1; // Offset random per ogni particella
            };

            // Funzione per generare un valore pseudo-casuale
            float random(float2 co)
            {
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            // Vertex shader
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                // Genera un offset casuale basato sulla posizione della particella
                o.randomOffset = random(v.vertex.xy);
                return o;
            }

            // Fragment shader
            fixed4 frag (v2f i) : SV_Target
            {
                // Aggiungi un offset randomico alla pulsazione per renderla unica per ogni particella
                float pulsation = 1 + sin((_Time.y + i.randomOffset) * _PulseSpeed) * _PulseScale;

                // Prende il colore dalla texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Modifica la trasparenza (componente alpha) in base alla pulsazione
                col.a *= pulsation;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}

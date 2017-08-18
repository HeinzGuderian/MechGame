using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CustomImageEffects : MonoBehaviour {

	public Material EffectMaterial;

	// Use this for initialization
	void OnRenderImage (RenderTexture src, RenderTexture dst) {
		if(EffectMaterial != null){
			Graphics.Blit(src, dst, EffectMaterial);
		}
	}

}

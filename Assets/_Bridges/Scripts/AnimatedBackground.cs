using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBackground : MonoBehaviour
{
    public float timeSpan;
    private Material mat;
    public AnimationType animationType;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        
        switch (animationType)
        {
            case AnimationType.AnimatedGradient:
                StartCoroutine(GradientAnimationCO(timeSpan));
                break;

            case AnimationType.AnimatedTexture:
                StartCoroutine(TextureAnimationCO(timeSpan));
                break;
            default:
                break;
        }
    }

    private IEnumerator GradientAnimationCO(float _timeSpan)
    {
        float timer = 0;
        float pingPongVal;
        while (true)
        {
            timer += Time.deltaTime;
            pingPongVal = Mathf.PingPong(timer, _timeSpan);
            mat.SetFloat("_Progression", Mathf.InverseLerp(0, _timeSpan, pingPongVal));
            yield return null;
        }
    }

    private IEnumerator TextureAnimationCO(float _timeSpan)
    {
        float timer = 0;
        float progression = -1.2f;

        while (true)
        {
            progression = -1.2f;
            timer = 0;

            while (timer < 1)
            {
                timer += Time.deltaTime / timeSpan;
                progression = Mathf.Lerp(-1.2f, 1, timer);
                mat.SetTextureOffset("_MainTex", new Vector2(progression, 0));
                yield return null;
            }
            
            yield return null;
        }
    }
}

public enum AnimationType
{
    AnimatedGradient,
    AnimatedTexture
}

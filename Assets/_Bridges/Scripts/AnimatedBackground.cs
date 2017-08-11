using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBackground : MonoBehaviour
{
    public float timeSpan;
    private Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        StartCoroutine(BackgroundAnimationCO(timeSpan));
    }

    private IEnumerator BackgroundAnimationCO(float _timeSpan)
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
}

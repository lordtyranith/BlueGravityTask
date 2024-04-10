using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    public float shineIntensity = 1.5f;
    public float shineDuration = 1f;
    public float minScale = 0.9f;
    public float maxScale = 1.1f;
    public float scaleDuration = 1.0f;
    private Vector3 initialScale;


    public void CallScaleEffect()
    {
        initialScale = transform.localScale;
        StartCoroutine(SmoothScale());
    }

    IEnumerator SmoothScale()
    {
        while (true)
        {
            transform.localScale = initialScale;

            float elapsedTime = 0.0f;
            while (elapsedTime < scaleDuration)
            {
                float proportion = elapsedTime / scaleDuration;
                transform.localScale = Vector3.Lerp(initialScale * minScale, initialScale * maxScale, proportion);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0.0f;
            while (elapsedTime < scaleDuration)
            {
                float proportion = elapsedTime / scaleDuration;
                transform.localScale = Vector3.Lerp(initialScale * maxScale, initialScale * minScale, proportion);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}

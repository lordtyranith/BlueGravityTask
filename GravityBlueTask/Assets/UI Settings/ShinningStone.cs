using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinningStone : MonoBehaviour
{
    public float shineIntensity = 1.5f; 
    public float shineDuration = 1f; 
    public float minScale = 0.9f; 
    public float maxScale = 1.1f; 
    public float scaleDuration = 1.0f;

    private Vector3 initialScale; 

    void Start()
    {
        initialScale = transform.localScale;

       // StartCoroutine(IntermittentShine());
        StartCoroutine(SmoothScale());
    }

    IEnumerator IntermittentShine()
    {
        while (true)
        {
            GetComponent<Renderer>().material.SetFloat("_EmissionScaleUI", shineIntensity);
            yield return new WaitForSeconds(shineDuration);
            GetComponent<Renderer>().material.SetFloat("_EmissionScaleUI", 0.0f);
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        }
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

using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class FlickerLight : MonoBehaviour
{
    Light2D light2d;
    public float duration = 0.3f;
    public float maxIntensity = 3f;

    void Start()
    {
        light2d = GetComponent<Light2D>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            light2d.intensity = Random.Range(maxIntensity * 0.5f, maxIntensity);
            yield return new WaitForSeconds(0.03f);
        }
        light2d.intensity = 0;
    }
}
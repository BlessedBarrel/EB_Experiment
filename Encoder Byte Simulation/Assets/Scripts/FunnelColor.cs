using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelColor : MonoBehaviour
{
    public float duration = 4f; // duration of color change
    public Renderer render; // reference to object's render component
    
    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        StartCoroutine(LerpColor(Color.white));
        
    }

    private IEnumerator LerpColor(Color targetColor)
    {
        Color startColor = render.material.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            render.material.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
    }
}

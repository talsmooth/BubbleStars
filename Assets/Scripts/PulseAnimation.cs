using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PulseAnimation : MonoBehaviour
{
    public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1); // Animation curve for controlling the animation
    public float duration = 1f; // Duration of the animation in seconds

    private RectTransform rectTransform;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private float startTime;

    void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        initialScale = Vector3.zero;
        targetScale = Vector3.one;
        
        // Start the scaling animation
        StartCoroutine(AnimateScale());
    }

    IEnumerator AnimateScale()
    {
        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            // Evaluate the animation curve to get the interpolation value
            float curveValue = animationCurve.Evaluate(t);

            // Interpolate scale between initialScale and targetScale using the animation curve
            rectTransform.localScale = Vector3.Lerp(initialScale, targetScale, curveValue);

            yield return null;
        }

        // Ensure final scale is exactly the target scale
        rectTransform.localScale = targetScale;
    }
}


using UnityEngine;

public class Tweener : MonoBehaviour
{
    [SerializeField] float delay = 0f;

    private void OnEnable()
    {
        gameObject.transform.localScale = Vector3.one * 0.3f;

        LeanTween.scale(gameObject, Vector3.one, 0.5f)
            .setDelay(delay)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();
    }
}

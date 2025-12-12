using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration = 0.5f;
    public void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        OnStart();
    }
    async void OnStart()
    {
        await FadeIn();
    }
    async Task Fade(float targetTransparancy)
    {
        float start = canvasGroup.alpha, t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, targetTransparancy, t/fadeDuration);
            await Task.Yield();
        }
        canvasGroup.alpha = targetTransparancy;
    }
    public async Task FadeOut()
    {
        await Fade(1); //Fades to black
    }
    public async Task FadeIn()
    {
        await Fade(0); //Fades to Transparent
    }
}

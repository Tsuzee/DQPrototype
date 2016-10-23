using UnityEngine;

public class OverlayUI : MonoBehaviour
{
    [SerializeField]
    private Material uiMaterial;
    [SerializeField]
    private float transitDuration = 1.0f;

    private Color backupColor = Color.white;
    private Color tintColor = Color.white;

    private enum State
    {
        Hidden,
        FadeIn,
        Shown,
        FadeOut,
    }

    private State state;
    
    void Update()
    {
        switch (state)
        {
            case State.FadeIn:
                {
                    float delta = 1.0f / transitDuration * Time.deltaTime;
                    tintColor.a = Mathf.Clamp01(tintColor.a + delta);
                    uiMaterial.color = tintColor;
                    if (tintColor.a >= 1 - float.Epsilon)
                    {
                        state = State.Shown;
                    }
                }
                break;
            case State.FadeOut:
                {
                    float delta = 1.0f / transitDuration * Time.deltaTime;
                    tintColor.a = Mathf.Clamp01(tintColor.a - delta);
                    uiMaterial.color = tintColor;
                    if (tintColor.a <= float.Epsilon)
                    {
                        state = State.Hidden;
                        gameObject.SetActive(false);
                    }
                }
                break;
            default:
                break;
        }
    }

    void OnDestroy()
    {
        uiMaterial.color = backupColor;
    }

    public void Init()
    {
        backupColor = uiMaterial.color;
        tintColor.a = 0.0f;
        uiMaterial.color = tintColor;
        state = State.Hidden;
        gameObject.SetActive(false);
    }

    public void Toggle()
    {
        if (state == State.Hidden)
        {
            gameObject.SetActive(true);
            state = State.FadeIn;
        }
        else if (state == State.Shown)
        {
            state = State.FadeOut;
            SendMessageUpwards("CancelDragItem");
        }
    }
}

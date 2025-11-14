using UnityEngine;

public class MenuOpenerAndCloser : MonoBehaviour
{

    public GameObject DesiredCanvas;

    public void MenuClose()
    {
        DesiredCanvas.SetActive(false);
    }

    public void MenuOpen()
    {
        DesiredCanvas.SetActive(true);
    }
}

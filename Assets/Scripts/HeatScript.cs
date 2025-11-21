using UnityEngine;
using UnityEngine.UI;

public class HeatScript : MonoBehaviour
{
    private NewP2ShootScript shootScript;
    public Canvas canvas;
    private float heat;
    private Slider slider;
    public Image fill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootScript = FindAnyObjectByType<NewP2ShootScript>();
        slider = GetComponent<Slider>();
        canvas.transform.position = shootScript.gameObject.transform.position+new Vector3(0,1.2f,0);
    }

    // Update is called once per frame
    void Update()
    {

        canvas.transform.position = shootScript.gameObject.transform.position + new Vector3(0, 1.2f, 0);
        heat = shootScript.heat;
        slider.value = heat/100;
        if (heat >= 80) fill.color = Color.red;
        else if (heat >= 50) fill.color = Color.orange;
        else if (heat >= 20) fill.color = Color.yellow;
        else fill.color = Color.white;
    }
}

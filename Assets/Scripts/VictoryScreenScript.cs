using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

public class VictoryScreenScript : MonoBehaviour
{
    [SerializeField] UIDocument uiDoc;
    Label victoryLabel;
    float opacityFloat = 0f;
    float opacityIncrement = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victoryLabel = uiDoc.rootVisualElement.Q<Label>("Victory");
        victoryLabel.style.opacity = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (opacityFloat >= 130f)
        {
            opacityIncrement *= -1;
        }
        else if (opacityFloat < 0) Destroy(gameObject);
            opacityFloat += opacityIncrement;
        StyleFloat opacity = opacityFloat/100;
        victoryLabel.style.opacity = opacity;
    }
}

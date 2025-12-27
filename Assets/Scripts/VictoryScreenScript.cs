using UnityEngine;
using UnityEngine.UIElements;

public class VictoryScreenScript : MonoBehaviour
{
    [SerializeField] UIDocument uiDoc;
    Label victoryLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victoryLabel = uiDoc.rootVisualElement.Q<Label>("Victory");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StyleFloat opacity = 1;
        victoryLabel.style.opacity = 1;
    }
}

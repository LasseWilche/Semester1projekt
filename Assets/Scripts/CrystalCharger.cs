using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrystalCharger : MonoBehaviour
{
    //Crystal Charge Variables
    public int maxSoulCharge;
    public int currentSoulCharge { get; set; }

    //Crystal interaction
    public GameObject teleportCircle1;
    public GameObject teleportCircle2;
    public Slider souldCharge;
    Scene currentScene;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSoulCharge = 0;
        teleportCircle2.SetActive(false);
        teleportCircle1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CrystalCharged()
    {
        if (currentSoulCharge >= maxSoulCharge)
        {
            teleportCircle1.SetActive(true);
            teleportCircle2.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (teleportCircle1.activeSelf && teleportCircle2.activeSelf)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
}

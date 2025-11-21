using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrystalCharger : MonoBehaviour
{
    [Header("Charge")]
    [Tooltip("Amount of souls required to activate the crystal")]
    public int maxSoulCharge;
    public int currentSoulCharge;

    [Header("UI")]
    public Slider soulCharge;
    public GameObject interactPrompt;        // small UI hint like "Press E to enter"
    

    [Tooltip("Key the player presses to interact")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private Scene currentScene;
    private bool playerInRange;
    private bool IsCharged => currentSoulCharge >= maxSoulCharge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSoulCharge = 0;

        if(interactPrompt) interactPrompt.SetActive(false);

        if (soulCharge)
        {
            soulCharge.maxValue = Mathf.Max(1, maxSoulCharge);
            soulCharge.value = currentSoulCharge;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange) return;
        if (!IsCharged) return;
        
        if (Input.GetKeyDown(interactKey))
        {
            int nextIndex = currentScene.buildIndex + 1;
            if (nextIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextIndex);
            }
            else
            {
                Debug.LogWarning($"CrystalCharger: No next scene in build settings (current index {currentScene.buildIndex})");
            }
        }
    }

    public void AddCharge(int amount = 1)
    {
        currentSoulCharge = Mathf.Clamp(currentSoulCharge + amount, 0, maxSoulCharge);

        if (soulCharge) soulCharge.value = currentSoulCharge;
        if (IsCharged) OnCrystalActivated();
    }

    public void CrystalCharged()
    {
        if (IsCharged) OnCrystalActivated();
    }

    private void OnCrystalActivated()
    {
        if (playerInRange && interactPrompt) interactPrompt.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Require the player to have the "Player" tag
        if (!collision.CompareTag("Player")) return;

        playerInRange = true;

        if (IsCharged && interactPrompt != null)
            interactPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        playerInRange = false;

        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }
}

using UnityEngine;

public class CrystalCharger : MonoBehaviour, IInteractable
{
    //Crystal Charge Variables
    public int maxSoulCharge;
    public int currentSoulCharge;

    //Crystal interaction
    public bool isCharged { get; private set; }
    public string crystalID { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Creates private ID for SoulCrystalCharger
        crystalID ??= GlobalCrystalHelper.GenerateUniqueID(gameObject);
        currentSoulCharge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if current soul charge is equal or higher to max and sets isCharged bool to true.
        if (currentSoulCharge >= maxSoulCharge)
        {
            isCharged = true;
        }
    }

    public bool CanInteract()
    {
        return !isCharged;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
    }
}

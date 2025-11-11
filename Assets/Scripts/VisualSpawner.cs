using UnityEngine;

public class VisualSpawner : MonoBehaviour
{
    float deactivationTime = 0;
    // Update is called once per frame
    void Update()
    {
        deactivationTime -= Time.deltaTime;
        if (deactivationTime <= 0)          //when deactivationTime = 0 we activate this
        {
            deactivationTime = 2;           //reset deactivation time for future use
            gameObject.SetActive(false);    //set gameObject as inactive
        }
    }
}

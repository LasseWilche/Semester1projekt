using UnityEngine;

public class DashScript : MonoBehaviour
{
    public KeyCode dashKey;
    public float dashSpeed;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    P1Controller p1;
    P2ControllerWithRotationThatDidntWorkLol p2;


    private void Start()
    {
        p1 = GetComponent<P1Controller>();
        p2 = GetComponent<P2ControllerWithRotationThatDidntWorkLol>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                if (p1 != null) p1.moveSpeed *= dashSpeed;
                else p2.activeMoveSpeed *= dashSpeed;
                dashCounter = dashDuration;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                if (p1 != null) p1.moveSpeed = p1.originalSpeed;
                else p2.activeMoveSpeed = p2.moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}

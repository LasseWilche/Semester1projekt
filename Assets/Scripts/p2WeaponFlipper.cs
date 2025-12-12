using UnityEngine;

public class p2WeaponFlipper : MonoBehaviour
{
    [SerializeField] GameObject Player;
    float angle;
    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Atan2(Player.transform.right.y,Player.transform.right.x) * Mathf.Rad2Deg;
        if (angle >= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}

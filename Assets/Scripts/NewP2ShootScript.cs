using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class NewP2ShootScript : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Public class through which you can assign a spawn point with an empty gameObject
    public GameObject bulletPrefab; // Public class through which you can assign a gameObject to be the bullet
    public float bulletSpeed = 10; // Public value for the speed of the bullets
    private int direction;
    public float heat = 0;
    private bool overheating = false;

    public AudioClip ShotSound1;
    public AudioClip ShotSound2;
    public AudioClip OverheatShotSound1;
    public AudioClip OverheatShotSound2;
    public AudioClip VeryOverheatShotSound1;
    public AudioClip VeryOverheatShotSound2;
    public AudioClip OverheatingSound;
    public AudioSource audioSource;
    

    void Update()
    {
        if (overheating == false) //if we overheating is true, we dont need any of this code, since our coroutine solves it
        {
            if (heat > 80)
            {
                //change heat bar to red
                heat -= Time.deltaTime * 30; //if heat is above 80 we cool down by 30/s
            }
            else if (heat > 50)
            {
                //change heat bar to orange
                heat -= Time.deltaTime * 25; //if heat is between 50 and 80 we cool down by 25/s
            }
            else if (heat > 0)                          //if heat is below 50 we cool down by 20/s
            {
                //change heat bar to yellow
                heat -= Time.deltaTime * 20;
                Mathf.Max(0, heat);                     //if heat is below 0 we set it to 0
            }
            if (Input.GetKeyDown(KeyCode.R))        //we fire the frame we press r, if we arent overheated
            {
                heat += 20;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.up * bulletSpeed;
                AudioClip randomClip = (Random.Range(0, 2) == 0) ? ShotSound1 : ShotSound2;
                audioSource.PlayOneShot(randomClip);

                if (heat >= 100)
                {
                    Mathf.Max(100, heat);
                    StartCoroutine(Overheating());  //if overheat is 100 or above our weapon overheats
                }
                else if (heat >= 80)                            //if overheat is above 79 we fire lots of steam
                {
                    AudioClip steamSound = (Random.Range(0, 2) == 0) ? VeryOverheatShotSound1 : VeryOverheatShotSound2;
                    audioSource.PlayOneShot(steamSound);
                }
                else if (heat >= 50)                            //if overheat is above 49 we fire steam
                {
                    AudioClip steamSound = (Random.Range(0, 2) == 0) ? OverheatShotSound1 : OverheatShotSound2;
                    audioSource.PlayOneShot(steamSound);
                }
            }
        }
        else     //if we are overheating, we reduce heat by 50/s (makes the heat-bar go to 0 while overheated)
        {                   
            heat -= Time.deltaTime * 50;
        }
    }
    IEnumerator Overheating()
    {
        overheating = true;
        AudioClip overheatingSound = OverheatingSound;
        audioSource.PlayOneShot(overheatingSound);
        yield return new WaitForSeconds(2f);
        heat = 0;
        overheating = false;
    }

    void Start()
    {
        audioSource = FindFirstObjectByType<AudioSource>();
    }
}
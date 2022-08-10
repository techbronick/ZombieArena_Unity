using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    float pickupRange = 2f;

    public Camera cam;

    public WeaponSwitching wSwitch;

    bool gotKey = false;



    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange))
            {

                if (hit.collider.tag == "Key")
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Key collected");
                    gotKey = true;
                }

                if (hit.collider.tag == "Panel" && gotKey)
                {
                    Destroy(hit.transform.parent.gameObject);
                    Debug.Log("Door opened");
                    gotKey = false;
                }

                if (hit.collider.tag == "Ammo" && wSwitch.weaponsPicked > 0)
                {
                    Destroy(hit.collider.gameObject);
                    foreach (Transform child in GameObject.Find("WeaponHolder").transform)
                        if (child.gameObject.activeSelf)
                            child.gameObject.GetComponent<WeaponScript>().AmmoIn();

                }


                if (hit.collider.tag == "Pistol")
                {
                    Destroy(hit.collider.gameObject);

                    wSwitch.weaponsPicked++;
                    wSwitch.SelectWeapon();

                }

                if (hit.collider.tag == "Carabine")
                {
                    Destroy(hit.collider.gameObject);

                    wSwitch.weaponsPicked++;
                    wSwitch.SelectWeapon();

                }

                if (hit.collider.tag == "Rifle")
                {
                    Destroy(hit.collider.gameObject);

                    wSwitch.weaponsPicked++;
                    wSwitch.SelectWeapon();

                }

                if (hit.collider.tag == "MedKit" && this.GetComponent<PlayerStats>().currentHealth < 100)
                {
                    Destroy(hit.collider.gameObject);
                    this.GetComponent<PlayerStats>().HealthIn();

                }


            }
        }

    }
}

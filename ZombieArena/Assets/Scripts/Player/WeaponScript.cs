//This script was created using Brackeys tutorials
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    public int damage = 10;
    public float range = 100;
    public float fireRate = 15;

    public int maxAmmo = 10;
    public int clipAmmo;
    private int currentAmmo;
    public float reloadTime = 1;



    private bool isReloading;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Animator animator;
    public Text ammoCount;

    private float nextTimeToFire = 0;


    void Start()
    {
        currentAmmo = maxAmmo;
        clipAmmo = 50;
        gameObject.SetActive(false);
    }

    void OnEnable()
    {

        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;



        if (clipAmmo > 0 && (currentAmmo == 0 || (Input.GetKey(KeyCode.R) && currentAmmo != maxAmmo)))
        {
            StartCoroutine(Reload());
            return;
        }

        if (currentAmmo > 0 && Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }



        ammoCount.text = currentAmmo + " / " + clipAmmo;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .5f);
        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.5f);

        if (clipAmmo >= maxAmmo)
        {
            clipAmmo -= maxAmmo - currentAmmo; ;
            currentAmmo = maxAmmo;
        }
        else if (clipAmmo < maxAmmo)
        {
            if (clipAmmo + currentAmmo > maxAmmo)
            {
                clipAmmo -= maxAmmo - currentAmmo;
                currentAmmo = maxAmmo;
            }
            else
            {
                currentAmmo += clipAmmo;
                clipAmmo = 0;
            }

        }

        isReloading = false;
    }



    void Shoot()
    {
        currentAmmo--;

        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForceAtPosition(fpsCam.transform.forward * 2000, hit.point, ForceMode.Impulse);
            }


            HitBox target = hit.collider.GetComponent<HitBox>();

            if (target != null)
            {
                target.health.TakeDamage(damage);
            }



            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);

        }
    }

    public void AmmoIn()
    {


        Debug.Log("Ammo picked");
        clipAmmo += 20;


    }

}

using System.Collections;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public PlayerStats playerStats;
    public Camera fpsCam;
    public Animator swordAnimator;
    bool isAtacking;

    public float attackRange;
    public float swordDamage;


    void OnEnable()
    {
        isAtacking = false;
        swordAnimator.SetBool("Atack", false);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAtacking)
            return;

        if (Input.GetKey(KeyCode.Q) && isAtacking == false && playerStats.currentStamina >= 20)
        {
            StartCoroutine(Atack());
            playerStats.currentStamina -= 20;
            return;
        }
    }

    IEnumerator Atack()
    {

        isAtacking = true;

        swordAnimator.SetBool("Atack", true);

        yield return new WaitForSeconds(0.5f);
        swordAnimator.SetBool("Atack", false);

        isAtacking = false;
    }

    public void Slash()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, attackRange))
        {

            HitBox target = hit.collider.GetComponent<HitBox>();

            if (target != null)
            {
                target.health.TakeDamage(swordDamage);
            }
        }
    }

}

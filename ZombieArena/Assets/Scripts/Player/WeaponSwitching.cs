//This script was created using Brackeys tutorials
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon;
    public int weaponsPicked = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponsPicked >= 1)
        {
            selectedWeapon = 0;
            SelectWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && weaponsPicked >= 2)
        {
            selectedWeapon = 1;
            SelectWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && weaponsPicked == 3)
        {
            selectedWeapon = 2;
            SelectWeapon();
        }

    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}

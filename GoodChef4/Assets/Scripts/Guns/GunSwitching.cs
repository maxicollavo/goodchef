using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    public int selectedGun = 0;
    private int previousSelectedGun;

    [SerializeField] private AudioSource knife;
    [SerializeField] private AudioSource spoon;

    void Update()
    {
        if (previousSelectedGun != selectedGun)
            previousSelectedGun = selectedGun;

        if (GameManager.Instance.canAttack)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha1)))
            {
                selectedGun = 0;
                if (previousSelectedGun != selectedGun)
                    knife.Play();
            }
            if ((Input.GetKeyDown(KeyCode.Alpha2)) && transform.childCount >= 2)
            {
                selectedGun = 1;
                if (previousSelectedGun != selectedGun)
                    spoon.Play();
            }

            if (previousSelectedGun != selectedGun)
                SelectGun();
        }
    }

    public void SelectGun()
    {
        int i = 0;

        foreach (Transform gun in transform)
        {
            if (i == selectedGun)
                gun.gameObject.SetActive(true);
            else
                gun.gameObject.SetActive(false);
            i++;
        }
    }
}
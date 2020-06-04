using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWeapon : MonoBehaviour
{
    //Id de l'arme Actuelle 
    private int weapondID;
    //partie du corp de port d'arme
    public GameObject bodyPart;
    //liste de nos armes
    public List<GameObject> weaponList = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount>0)
        {
            weapondID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        
        //Copier coller ça pour chaque armes
        //WeaponId correspond a l'id de l'arme dans la BDD
        // i - x correspond a l'index de l'arme dans la liste
        if (weapondID == 1 && transform.childCount > 0)
        {
            for (int i = 0; i < weaponList.Count; i++)
            {
                if (i != 0)
                {
                    weaponList[i].SetActive(false);
                }
                else
                {
                    weaponList[i].SetActive(true);
                }
            }
            //changement d'arme
            if (bodyPart.transform.childCount > 1)
            {
                for (int i = 0; i < weaponList.Count ; i++)
                {
                    weaponList[i].SetActive(false);
                }
            }
        }
        
    }
}

using UnityEngine;
using System.Collections;
 
public class test : MonoBehaviour 
{
    //drag prefab here in editor
    public Transform InstantiateMe;

    public Vector3 ellos;
    public Vector3 posObj; 
    void Start()
    {
        Vector3 ellos = new Vector3(10f, 0f, 10f);
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Vector3 posObj = new Vector3(transform.position + ellos); 
            //you don't have to instantiate at the transform's positio nand rotation, swap these for what suits your needs
            var go = Instantiate(InstantiateMe, new Vector3(0f,0f,0f), transform.rotation);
        }
    }
}
using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public GameObject allGO;
    public GameObject layerGO;
    public GameObject nameGO;
    public GameObject tagGO;


    // Use this for initialization
    void Start()
    {
        this.allGO = U.Find("*");
        this.layerGO = U.Find(".Default");
        this.nameGO = U.Find("Main Camera");
        this.tagGO = U.Find("#MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

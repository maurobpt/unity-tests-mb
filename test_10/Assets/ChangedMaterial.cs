using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedMaterial : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Box")
            rend.sharedMaterial = material[1];
        else
            rend.sharedMaterial = material[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

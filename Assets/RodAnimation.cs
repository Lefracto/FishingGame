using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("Posechka", true);
        }     
    }

    public void BackPosechka()
    {
        GetComponent<Animator>().SetBool("Posechka", false);

    }
}

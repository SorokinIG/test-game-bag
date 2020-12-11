using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{

   // public Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Thing")
        {
            //  score = new Score();
            //   score.resTrigger = true;
            StaticTriggerMessage.MyText = true;
            Debug.Log("Задел");
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Hum : MonoBehaviour
{
    public Animator animator;
    public GameObject hum;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 endPostwo;

    public float speed;
    public int go;
    public static string text;

    // Start is called before the first frame update
    void Start()
    {

        go = 0;
        hum.transform.position = Staticscript.positions;
        endPos = new Vector3(0, -0.15f, 1);
        endPostwo = new Vector3(3, -0.15f, 2);
        text = Staticscript.MyText;
    }

    void next()
    {
       // go = 1;
    }
    // Update is called once per frame
    void FixedUpdate()
    {


    
    
            if (hum.transform.position != endPos)
            {
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            
            }

            hum.transform.position = Vector3.MoveTowards(hum.transform.position, endPos, speed);

            Staticscript.positions = hum.transform.position;

    
        
        if (Staticscript.SkipOr == "Skip")
        {

        }

        if (text == "Win")
        {
          //  go = 1;
           
        }

        

        if(go == 1)
        {
            for (int i = 0; i < 1; i++)
            {
                animator.SetBool("Jump", true);

            }

            animator.SetFloat("Speed", 1);

        /*    while (hum.transform.position != endPostwo)
            {
                hum.transform.position = Vector3.MoveTowards(endPos, endPostwo, 0.05f);

            } */
           //  text = "Stop";
          //  go = 0;
        }
        
        
    }
}

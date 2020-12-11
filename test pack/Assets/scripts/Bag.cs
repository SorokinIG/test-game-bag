using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bag : MonoBehaviour
{

    public Vector3 bagPositionStart;  //точка начала для передвижения чемодана
    public Vector3 bagPositionEnd;  //конечная точка для передвижения чемодана
    public float speed = 0.0005f; //скорость чемодана
    private float proggress;  

    private static GameObject obj;  //чемодан
    public GameObject endMovement;  //точка появления чемодана
    public GameObject centerMovement; //центральная точка остановки чемодана 
    public GameObject[] objects; //виды чемоданов

    private static bool dosmth;  //логика для движения
    private static int logic; //логика для создания удаления чемоданов



    public Text textForResult;  //принимает значения Win/Lose
    public Text scoretext; //куда выводить
  
    public int scoreValue = 5;  //кол-во очков которое будет прибавляться



    
    void Start()
    {
        int rand = Random.Range(0, objects.Length );
        obj =  Instantiate(objects[rand], centerMovement.transform.position, centerMovement.transform.rotation = Quaternion.Euler(- 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        
        bagPositionStart = centerMovement.transform.position;

        bagPositionEnd = endMovement.transform.position ;

        dosmth = false;
        logic = 0;


        textForResult.text = Staticscript.MyText;
       // score = 0;
        UpdateScore();


        if (textForResult.text == "Win")
        {
            Win();
        }

    }

    public void createObject()
    {
        
            int rand = Random.Range(0, objects.Length );
            obj = Instantiate(objects[rand], endMovement.transform.position, endMovement.transform.rotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
            logic = 0;
            proggress = 0;
    }

    public void deleteObject()
    {
        
        Destroy(obj, 2f);
  
       
    }

   
    void FixedUpdate()
    {
        
       
       
       if (dosmth == true)
        {
            if (obj != null)
            {
                
                obj.transform.position = Vector3.Lerp(obj.transform.position, bagPositionEnd, proggress);   //с центра в край экрана
                proggress += speed;
            }
        }
       
       if(dosmth == false)
        {
            if (obj != null)
            {
                
                obj.transform.position = Vector3.Lerp(obj.transform.position, bagPositionStart, proggress);   // с края экрана в центр
                proggress += speed;
            }
        }

       if (obj == null)
        {
            dosmth = false;
            createObject();
            
        }
      
       if(logic == 2)
        {
            
            if (obj != null)
            {
                deleteObject();
            }
            
        }

        

    }

    public void skip()
    {

        logic = 2;
        dosmth = true;

    }

    public void ok()
    {
        SceneManager.LoadScene("2");
       
    }

    public void AddScore(int newScoreValue)
    {
        StaticScore.score += newScoreValue;
        UpdateScore();
    }


    void UpdateScore()
    {
        scoretext.text = "" + StaticScore.score;

    }

    public void Win()
    {

            AddScore(scoreValue);
     
    }
}

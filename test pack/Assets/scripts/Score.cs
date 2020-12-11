using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject Box;  //ячейки пустые
    public GameObject things;  //вещи

    public Text text;    //для передачи результата
    public InputField field;  //для передачи результата

    public static int col = 2, row = 2;   //кол-во столбцов и рядов
    public GameObject[,] cellsRight;    //массив левых кубиков
    public GameObject[,] cellsLeft;    //массив правых кубиков
    public GameObject[] tmpR;         //левые вещи
    public GameObject[] tmpL;           //правые вещи
    public GameObject[] leftCubes;     //правые кубики
    public GameObject[] rightCubes;   //левые кубики

    public static bool resTrigger = false;  //для результата задел или нет

    public static int go;  //логика запуска упаковки
    Transform parent;   //для объединения
    public float rotationSpeed = 1;  //скорость поворота
    public float speed = 5f;   //скорость передвижение объекта
   // public float proggress;
    public GameObject endPos;  //объект который объединяет кубики и вещи в один
    public GameObject endPosition; //для конца маневра

    void CreateGamePoleLeft()
    {
       

        float Dx = 1.2f, Dy = 1.2f;
        Vector3 Poz = new Vector3(0, 0, 0);

        rightCubes = new GameObject[4];
        int count = 0;

        cellsRight = new GameObject[col, row];

        for (int YY = 0; YY < row; YY++)
        {
            for (int XX = 0; XX < col; XX++)
            {

                rightCubes[count] =  Instantiate(Box, Poz, Quaternion.identity) ;

                Poz.x += Dx;

                cellsRight[XX, YY] = rightCubes[count];

                rightCubes[count].transform.SetParent(parent);

                count++;
            }
           
            Poz.x = 0;
            Poz.y += Dy;
        }
    }  //для создания левой части

    void CreateGamePoleRight()
    {
       

        float Dx = 1.2f, Dy = 1.2f;
        Vector3 Poz = new Vector3(5, 0, 0);

        leftCubes = new GameObject[4];
        int count = 0;

        cellsLeft = new GameObject[col, row] ;

        for (int YY = 0; YY < row; YY++)
        {
            for (int XX = 0; XX < col; XX++)
            {

                

               leftCubes[count] = Instantiate(Box, Poz, Quaternion.identity)  ;
                Poz.x += Dx;

             

                    cellsLeft[XX, YY] = leftCubes[count];

                count++;
            }

            Poz.x = 5;
            Poz.y += Dy;

            
        }
    }  //для создания правой части ячеек

    void CreateGamePoleRandomFig()
    {
        int countright = 0;
        int countleft = 0;


        int i = 1;
        int j = 1; 

        

        tmpL = new GameObject[i];
        tmpR = new GameObject[j];

        int c = Random.Range(0, col );  //ячейка колонна
        int r = Random.Range(0, row);  //ячейка строка

       // int cR = Random.Range(0, col);
      //  int rR = Random.Range(0, row);

        while (countright < i && countleft < j)
        {

            

            

     /*       if (cellsLeft[c, r].trnsform.position == tmpL[countleft].trnsform.position)
            {

            }

       */    

            if (countright != i)
            {
                tmpR[countright] = Instantiate(things, cellsRight[c, r].transform.position + new Vector3(0, 0, -1), Quaternion.identity) as GameObject;

                tmpR[countright].transform.SetParent(parent);

                countright++;
            }

            if (countleft != j)
            {
                tmpL[countleft] = Instantiate(things, cellsLeft[c, r].transform.position + new Vector3(0, 0, -1), Quaternion.identity) as GameObject;

          

                countleft++;
            }
        }
    }  //заполнение ячеек вещами

   

    void Start()
    {
        text.text = Staticscript.MyText;

        GameObject oneFile = new GameObject();

        parent = oneFile.transform;

        endPos = oneFile;
        endPosition.transform.position = oneFile.transform.position;

        go = 0;

        CreateGamePoleLeft(); //рисуем левую часть ячеек
        CreateGamePoleRight(); //рисуем правую часть ячеек
        CreateGamePoleRandomFig(); //заполняем ячейки предметами

    }


    void FixedUpdate()
    {


        if (go == 1)
        {
            
            endPos.transform.position = Vector3.MoveTowards(endPos.transform.position, endPosition.transform.position + new Vector3(6, 0, -2), speed);   //
           
           // endPos.transform.rotation = Quaternion.Euler(0, -180, 0);

            Quaternion rightRot = Quaternion.Euler(0, 180, 0);

            endPos.transform.rotation = Quaternion.Lerp(endPos.transform.rotation, rightRot,  rotationSpeed);


            if (endPos.transform.position == endPosition.transform.position + new Vector3(6, 0, -2))
            {
                go = 2;
            }
                                                                                                                                                 // proggress += speed;
        }

        if(go == 2)
        {
            //выключить кубы 
        }
        
    }

    public void ResultCheck()  //функция для закрытия левой части чемодана
    {

        


        go = 1;

        Debug.Log("сделано");
        

        //  leftCubes 
        //    tmpL
    }

    public void LoadText()  //функция для передачи результата 
    {
        resTrigger = StaticTriggerMessage.MyText;

        if (resTrigger == true)
        {
            field.text = "Lose";
        }
        else
        {
            field.text = "Win";
        }
            
        Staticscript.MyText = field.text;

        

        StaticTriggerMessage.MyText = false;

        SceneManager.LoadScene("SampleScene");
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
  
    int levelNo;
    public Button[] allBtns;
    public Sprite tickSign;
    int max=0;
    
    void Start()
    {
        levelNo = PlayerPrefs.GetInt("levelno", 1);
        max = PlayerPrefs.GetInt("Max", 0);
        for (int i = 0; i <= max; i++)
        {
            allBtns[i].interactable = true;

            allBtns[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            if (i < max)
            {
                    allBtns[i].GetComponent<Image>().sprite = tickSign; 
            }
            else
            {
                allBtns[i].GetComponent<Image>().sprite = null;

            }
        }

    }
    public void levelBtnClick(int no)
    {
       
        PlayerPrefs.SetInt("levelno", no);

        SceneManager.LoadScene("Play");
        
    }
     
}

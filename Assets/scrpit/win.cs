using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    
    // Start is called before the first frame update
    int levelno,coain;
    void Start()
    {
        levelno = PlayerPrefs.GetInt("levelno", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnWards()
    {
        
        SceneManager.LoadScene("Play");
   }
}

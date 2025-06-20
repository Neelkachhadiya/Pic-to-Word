using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public Sprite[] puzzelImg1, puzzelImg2;

    public  Image Image1,Image2;

    public GameObject btnprefab,upperhoder,dowmhoder, WinHolder;

    public Text no,canno,hintno;

    public GameObject Playobj, Winobj,hintobj;

    string[] trueans = {"START", "FOOTBALL", "SANDWICH", "HOTDOG", "EARRING" , "HORSESHOE", "KEYBOARD", "CUPCAKE", "JUMPROPE", "ICEBOX", "HANDSHAKE", "JELLYFISH", "SUITCASE", "LIPSTICK", "CHECKBOOK", "WEBMAIL", "LADYBUG", "MOUTHWASH", "BEANBAG", "LAYOFF", "MOUSETRAP", "CANDYCANE", "MANHOLE", "JIGSAW", };
    
    string[] Hint = {"_T__T", "F___B__L", "S___W__H", "H____G", "EARRING" , "HORSESHOE", "KEYBOARD", "CUPCAKE", "JUMPROPE", "ICEBOX", "HANDSHAKE", "JELLYFISH", "SUITCASE", "LIPSTICK", "CHECKBOOK", "WEBMAIL", "LADYBUG", "MOUTHWASH", "BEANBAG", "LAYOFF", "MOUSETRAP", "CANDYCANE", "MANHOLE", "JIGSAW", };
    
    string[] mixedans = {"BSFSTFGAHFRGHT", "SFGOFOYTUBIALL", "SAFNGDRWWIDCKH", "HODSTFDEOJGKGR", "EAARSRFIGNHGJK" , "HOFRSXEESHNOGE", "KAEYSBDOFAGRHD", "CUSPCADFGKHJEK", "JUDDMPMEROTPYE", "ISCEDEBBCOVDXD", "HAANWDSEHARKTE", "JEXLJLYVFITSHY", "SAUTITUCHANSFE", "LUIKPTSTFIXCKZ", "CHVEJCKKBHOOIK", "WVENBMRLMAYILU   ", "LBADDWYEBDUFGG", "QMOWUTFHWDASGH", "MBENABNBCVADGS", "BLCAFYTOYFUFI", "MSOUDSEFTGRNAP", "HCADNDYECAWNSE", "MFAHNKHFORLYEK", "BJVICXGLSKAJWG", };
    
    string curans = "", curmixedans = "",curhint="";
   
    int levelno,max;

    int [] btnpos = new int [100];
   
    int coain;
    void Start()
    {
        coain=PlayerPrefs.GetInt("Coain", 300);
        canno.text =coain.ToString();   

        levelno = PlayerPrefs.GetInt("levelno", 1);
        max = PlayerPrefs.GetInt("Max", 1);
        no.text = levelno + "";


        curans = trueans[levelno - 1];
        curmixedans = mixedans[levelno - 1];
        curhint = Hint[levelno - 1];    

        Image1.sprite = puzzelImg1[levelno - 1];
        Image2.sprite = puzzelImg2[levelno - 1];


        for (int i = 0; i < curans.Length; i++)
        {

            GameObject g = Instantiate(btnprefab, upperhoder.transform);
            g.tag = "upper-btn";
            int tempno = i;

            g.GetComponent<Button>().onClick.AddListener(() => upperbtnClick(tempno));
        }

        for (int i = 0; i < curmixedans.Length; i++)
        {
            string c = curmixedans[i] + "";
            int tempno = i;
            GameObject g = Instantiate(btnprefab, dowmhoder.transform);
            g.tag = "down-btn";
            
            g.GetComponentInChildren<Text>().text = c;

            g.GetComponent<Button>().onClick.AddListener(() => downbtnClick(c, tempno));
        }

    }

    void downbtnClick(string str,int No)
    {
        GameObject[] upperBtns = GameObject.FindGameObjectsWithTag("upper-btn");
        GameObject[] downBtns = GameObject.FindGameObjectsWithTag("down-btn");
        
        for(int i=0;i<upperBtns.Length;i++)
        {
            if (upperBtns[i].GetComponentInChildren<Text>().text=="")
            {
                btnpos[i] = No;
                upperBtns[i].GetComponentInChildren<Text>().text = str;
                downBtns[No].GetComponentInChildren<Text>().text = "";
                downBtns[No].GetComponent<Button>().interactable = false;
                upperBtns[i].GetComponent<Button>().interactable = true;
                break;
            }
        }
        submit(); 
        
    }
    void submit()
    {
        GameObject[] upperBtns = GameObject.FindGameObjectsWithTag("upper-btn");
        string userans = "";
        for (int i = 0; i < upperBtns.Length; i++)
        {
            userans += upperBtns[i].GetComponentInChildren<Text>().text;
        }
        if (curans.Length == userans.Length)
        {
            if (curans == userans)
            {
                PlayerPrefs.SetInt("levelno", levelno + 1);
                PlayerPrefs.SetInt("Coain", coain + 50);
                canno.text = coain.ToString();
                if (max<=levelno)
                {
                    PlayerPrefs.SetInt("Max", levelno);
                }
                Win();
                Playobj.SetActive(false);
                Winobj.SetActive(true);
            }
        }
    }
    void upperbtnClick(int upNo)
    {
        GameObject[] upperBtns = GameObject.FindGameObjectsWithTag("upper-btn");
        GameObject[] downBtns = GameObject.FindGameObjectsWithTag("down-btn");

        int downno = btnpos[upNo];
        
        downBtns[downno].GetComponent<Button>().interactable = true;
        downBtns[downno].GetComponentInChildren<Text>().text = upperBtns[upNo].GetComponentInChildren<Text>().text;
        upperBtns[upNo].GetComponentInChildren<Text>().text = "";

    }
    void Win()
    {
       
        for (int i = 0; i < curans.Length; i++)
        {
            char c = curans[i];
            int tempno = i;
            GameObject g = Instantiate(btnprefab, WinHolder.transform);
            g.GetComponentInChildren<Text>().text = c + "";

        }
    }

    public void hint()
    {
        
        if (coain > 100)
        {
            hintobj.SetActive(true);
            PlayerPrefs.SetInt("Coain", coain - 50);
            canno.text = coain.ToString();
            hintno.text = curhint;
        }
       
    }
    public void ok()
    {
        hintobj.SetActive(false);
    }
}
   


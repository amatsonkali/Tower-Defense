using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scoreSceneManager : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform contentWindow;
    GameObject loadingText;
    void Start()
    {
        contentWindow = this.transform.Find("Scroll View").Find("Viewport").Find("Content");
        loadingText = instantiateText("Loading...");
        webHelper.instance.GetData(this.gameObject);
    }

    GameObject instantiateText(string s){
        GameObject g = Instantiate(textPrefab,contentWindow);
        g.GetComponent<Text>().text=s;
        return g;
    }

    void receiveResponse(string s){
        Destroy(loadingText);
        Debug.Log(s);
        List<ScoreTuple> l = JsonConvert.DeserializeObject<List<ScoreTuple>>(s);
        foreach (ScoreTuple item in l)
        {
            instantiateText(item.ToString());          
        }
    }
    public void toMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}

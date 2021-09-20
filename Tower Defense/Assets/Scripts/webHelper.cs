using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class webHelper : MonoBehaviour
{
    public static webHelper instance;

    public string uri = "https://614810d365467e0017384cb9.mockapi.io/scores";
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }
     
    public void GetData(GameObject instance) => StartCoroutine(GetData_Coroutine(instance));
 
    IEnumerator GetData_Coroutine(GameObject instance)
    {   
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            string msj;
            if ( request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                msj = request.error;
            else
                msj = request.downloadHandler.text;

            instance.SendMessage("receiveResponse",msj,SendMessageOptions.DontRequireReceiver);
        }
    }

    public void PostData(ScoreTuple st) => StartCoroutine(PostData_Coroutine(st));
 
    IEnumerator PostData_Coroutine(ScoreTuple st)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", st.score);
        form.AddField("date", st.date.ToString("MM/dd/yyyy HH:mm"));
        form.AddField("wonRound", st.wonRound.ToString() );
        using(UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                Debug.Log( request.error);
            else
                Debug.Log( request.downloadHandler.text );
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetManager : MonoBehaviour
{
    public Text checkInternet;

    private string urlData = "http://tadeolabhack.com:8081/test/Datos/CocinAR/isConectionAR.php";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_checkInternet());
        
    }

    public IEnumerator _checkInternet()
    {
        WWW getData = new WWW(urlData);
        yield return getData;

        print(getData.text);

        if (getData.text == "ConexionEstablecida")
        {
            checkInternet.text = "El usuario se conectó";
        }
        else
        {
            checkInternet.text = "El usuario no se conectó";
        }
    }
}

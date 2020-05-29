using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registro : MonoBehaviour
{

    public InputField txtUsuario;
    public InputField txtEmail;
    public InputField txtApellido;
    public InputField txtContraseña;
    public GameObject Panel3;
    //public GameObject Panel4;
    public GameObject PanelError;
    public Text nombrePersonal;


    public string nombreUsuario;
    public string apellidoUsuario;
    public string emailUsuario;
    public bool sesionIniciada = false;

    public void registrarUsuario()
    {
        StartCoroutine(registrar());
    }

    /*public void Iniciar()
    {
        StartCoroutine(inicioSesion());
    }*/

    IEnumerator registrar()
    {
        WWW conexion = new WWW("http://tadeolabhack.com:8081/test/Datos/CocinAR/escribir.php?Name_Cocinar=" + txtUsuario.text + "&LastName_Cocinar=" + txtApellido.text +
            "&Email_Cocinar=" + txtEmail.text + "&Password_Cocinar=" + txtContraseña.text);
        yield return (conexion);
        Debug.Log(conexion.text);
        if (conexion.text == "300[]")
        {
            Debug.LogError("el usuario ya existe");
            PanelError.SetActive(true);
        }
        else if (conexion.text == "100[]")
        {
            nombreUsuario = txtUsuario.text;
            apellidoUsuario = txtApellido.text;
            emailUsuario = txtEmail.text;
            sesionIniciada = true;
            Panel3.SetActive(true);
            nombrePersonal.text = nombreUsuario;
        }
        else
        {
            print(conexion.text);
            Debug.LogError("error en la conexion a la base de datos");
        }

   


    }
/*
    IEnumerator inicioSesion()
    {
        WWW conexion = new WWW("" + txtEmail.text + "&password=" + txtContraseña);
        yield return (conexion);
        Debug.Log(conexion.text);
        if (conexion.text == "100[]")
        {
            print("el usuario si existe");
            Panel3.SetActive(true);
        }
        else if (conexion.text == "200[]")
        {
            print("el usuario o email incorrecto");
            PanelError.SetActive(true);
        }
        else
        {
            print("error en el servidor");
        }

    }*/

}

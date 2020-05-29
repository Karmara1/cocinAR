using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    private string urlDataEscribir = "http://www.camila-rueda.co/escribir.php?";

    public int IDUser = 300;
    private string nombre = "";
    private string apellido = "";
    private string email = "";
    private string contraseña = "";

    public InputField campoNombre;
    public InputField campoApellido;
    public InputField campoEmail;
    public InputField campoContraseña;

    public void SenData()
    {
        StartCoroutine(enviarDatosUsuario());
    }

    private IEnumerator enviarDatosUsuario()
    {
        nombre = campoNombre.text;
        apellido = campoApellido.text;
        email = campoEmail.text;
        contraseña = campoContraseña.text;

        print(IDUser + " " + nombre + " " + apellido + " " + email + " " + contraseña + " ");

        if (nombre == "" || apellido == "" || email == "" || contraseña == "")
        {
            print("Los campos deben ser llenados");
        }

        else
        {
            WWWForm form = new WWWForm();
            form.AddField("IDUser", IDUser);
            form.AddField("Name", nombre);
            form.AddField("LastName", apellido);
            form.AddField("Email", email);
            form.AddField("Password", contraseña);

            WWW retroalimentacion = new WWW(urlDataEscribir, form);
            yield return retroalimentacion;

            print(retroalimentacion.text);
        }
    }
}
 
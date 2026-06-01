using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usuarioInput;
    public TMP_InputField passwordInput;
    public TMP_Text mensajeError;

    public void Login()
    {
        string usuario = usuarioInput.text;
        string password = passwordInput.text;

        if (usuario == "admin" && password == "1234")
        {
            SceneManager.LoadScene("01-Menu");
        }
        else
        {
            mensajeError.text = "Usuario o contraseña incorrectos";
        }
    }
}
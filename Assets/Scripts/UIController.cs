using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject imagen;

    public void OcultarImagen()
    {
        imagen.SetActive(false);
    }

    public void MostrarImagen()
    {
        imagen.SetActive(true);
    }
}
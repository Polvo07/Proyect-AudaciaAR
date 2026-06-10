using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTrabajos : MonoBehaviour
{
    public void IrAROV()
    {
        SceneManager.LoadScene("03-Rov");
    }

    public void IrACalvin()
    {
        SceneManager.LoadScene("04-Calvin");
    }

    public void IrASFerreo()
    {
        SceneManager.LoadScene("05-SMFerreo");
    }

    public void IrARobot()
    {
        SceneManager.LoadScene("06-Robot");
    }

    public void IrAVart()
    {
        SceneManager.LoadScene("07-Vart");
    }
}
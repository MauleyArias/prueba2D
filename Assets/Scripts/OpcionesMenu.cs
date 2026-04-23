using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpcionesMenu : MonoBehaviour
{
public void vamosAjugar()
    {
        SceneManager.LoadScene(1);
    }
public void Salir()
    {
        //para la consola en Unity
        
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        // Hacer que el cursor sea visible y bloquear su movimiento
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        // Restaurar la configuración del cursor a lo que estaba antes
        Cursor.visible = false; // Esto asume que antes estaba configurado como invisible
        Cursor.lockState = CursorLockMode.Locked; // Esto asume que antes estaba bloqueado para el movimiento del ratón
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}



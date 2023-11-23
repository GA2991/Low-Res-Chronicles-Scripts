using UnityEngine;

public class MensajeInicial : MonoBehaviour
{
    public GameObject mensajeInicial;

    void Start()
    {
        // Invocar el método MostrarMensajeInicial después de 2 segundos
        Invoke(nameof(MostrarMensajeInicial), 1f);

        // Desactivar el mensaje después de 7 segundos (2 segundos para mostrar + 5 segundos de duración)
        Invoke(nameof(OcultarMensajeInicial), 6f);
    }

    // Método para activar el mensaje inicial
    public void MostrarMensajeInicial()
    {
        mensajeInicial.SetActive(true);
    }

    // Método para ocultar el mensaje inicial
    public void OcultarMensajeInicial()
    {
        mensajeInicial.SetActive(false);
    }
}

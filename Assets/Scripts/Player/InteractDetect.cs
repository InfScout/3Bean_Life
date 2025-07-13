using UnityEngine;
using UnityEngine.InputSystem;



public class InteractDetect : MonoBehaviour
{
    private IInteratable interactableInRange = null;
    public GameObject InteracIcon;
    [SerializeField] private AudioClip InteractSound;

    void Start()
    {
        InteracIcon.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteratable interactable) && interactable.IsInteractable())
        {
            interactableInRange = interactable;
            InteracIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteratable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            InteracIcon.SetActive(false);
        }
    }

    /*public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableInRange.Interact();
            AudioMan.instance.PlaySound(InteractSound, transform, 1f);
        }
    }*/

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            interactableInRange.Interact();
            AudioMan.instance.PlaySound(InteractSound, transform, 1f);
        }
    }

}






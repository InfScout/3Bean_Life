using UnityEngine;
using UnityEngine.InputSystem;



public class InteractDetect : MonoBehaviour
{
    private IInteratable interactableInRange = null;
    public GameObject interacIcon;
    [SerializeField] private AudioClip interactSound;
    
    
    
    void Start()
    {
        interacIcon.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteratable interactable) && interactable.IsInteractable())
        {
            interactableInRange = interactable;
            interacIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteratable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interacIcon.SetActive(false);
        }
    }
    
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            interactableInRange.Interact();
            AudioMan.instance.PlaySound(interactSound, transform, 10f, Random.Range(.5f, 10f));
        }
    }
    
}






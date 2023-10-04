using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    protected GameObject interactIndicator;

    public abstract void Interact();

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            interactIndicator.SetActive(true);
            col.GetComponentInParent<PlayerController>().SetInteractable(this);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            interactIndicator.SetActive(false);
            col.GetComponentInParent<PlayerController>().ClearInteractable();
        }
    }

    void Start()
    {
        interactIndicator.SetActive(false);
    }
}
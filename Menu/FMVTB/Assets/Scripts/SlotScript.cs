using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// cette classe code un "slot" d'inventaire, son comportement. elle doit être liée a la prefab "slot"
public class SlotScript : MonoBehaviour, IPointerDownHandler , IPointerEnterHandler
{
    public int index;
    public ItemClass item;
    Image image;
    Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        image = gameObject.transform.GetChild(0).GetComponent<Image>();
    }
    
    void Update()
    {
        if (index < inventory.inventory.Count)
        {
            if (inventory.inventory[index].name != null )
            {
                image.enabled = true;
                image.sprite = inventory.inventory[index].sprite;
            }
        }
        

    }
// cette fonction agit quand l'eventsystem de unity detecte un clic sur l'objet auquel le script est lié
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
//cette fonction agit quand l'eventsystem de unity detecte un passage du pointeur sur l'objet auquel le script est lié
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hovered");
    }
}

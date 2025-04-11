using UnityEngine;

public class EggCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("player")) return;
        Debug.Log(collision.tag);
        InventoryManager.instance.AddEgg();
        InventoryManager.instance.SaveGame();
        gameObject.SetActive(false);
        //TODO trigger animation
    }
}

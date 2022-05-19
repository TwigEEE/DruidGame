using UnityEngine;

public class SlotChooser : MonoBehaviour
{



    public SpriteRenderer scimitar;


    void Start()
    {
        
        string slot1 = "", slot2 = "", slot3 = "", slot4 = "", slot5 = "", slot6 = "", slot7 = "", slot8 = "", slot9 = "";
        string[] slots = new string[9] {slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9};

        slots[0] = "Scimitar";
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey("1")) 
        {
            //scimitar.GetComponent<SpriteRenderer>().enabled = false;
            //Debug.Log(slots[0]);
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomResult : MonoBehaviour
{
    public List<Sprite> bloodGrpSprites;
    public Image imageCompo;

    private void OnEnable()
    {
        int rand = Random.Range(0,bloodGrpSprites.Count);
        imageCompo.sprite = bloodGrpSprites[rand];

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

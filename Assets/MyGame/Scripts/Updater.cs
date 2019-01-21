using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Updater : MonoBehaviour {

    public Text text;
    public string inputtext;
    public GameObject circleColor;
    // removed unnecessary variable color - it was never used
    public GameObject[] shuffleCircles;

    [SerializeField] GameObject circlePosition;

    private List<Color> colorList;
    private System.Random rnd = new System.Random();
    
    private void Start()
    {
       // removed overriding the input text

        colorList = new List<Color> {
            Color.red,
            Color.blue,
            Color.green, // forgot to add comma
            Color.magenta
        };
    }

    public void UpdateTextWithInspectorInput()
    {
        text.text = inputtext; //the "text" variable was written with a capital T, resulting in the interpreter to see it as the Class
    }

    public void UpdateCircleColor()
    {
        SpriteRenderer circRenderer = circleColor.GetComponent<SpriteRenderer>();
        byte r = (byte)rnd.Next(0, 255);
        byte g = (byte)rnd.Next(0, 255);
        byte b = (byte)rnd.Next(0, 255);
        byte a = (byte)rnd.Next(0, 255); // dont if the circle in the apha channel is intentional or by mistake

        circRenderer.color = new Color32(r, g, b, a);
    }
	
    public void UpdateObjectPosition()
    {
        Transform circleTransform = circlePosition.GetComponent<Transform>(); // renamed the Transfrom from circTransfrom, not sure if this is considered a mistake (only a var name)
        
        float randomPosX = UnityEngine.Random.Range(5, 433); // When using Unity's Random class use .Range instead of .Next (method of the System.Random class)
        circleTransform.localPosition = new Vector3(randomPosX, circleTransform.localPosition.y, circleTransform.localPosition.z);
    }

    public void ShuffleColorsInCircles()
    {
        List<SpriteRenderer> objectList = new List<SpriteRenderer>();
        
        foreach(GameObject item in shuffleCircles)
        {
            objectList.Add(item.GetComponent<SpriteRenderer>());
        }

        colorList.Shuffle();

        for(int i = 0; i < objectList.Count; i++)
        {
            objectList[i].color = colorList[i];
        }
    }
}

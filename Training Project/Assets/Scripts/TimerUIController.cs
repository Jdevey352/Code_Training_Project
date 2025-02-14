using TMPro;
using UnityEngine;

// Require that a TMP_Text component is on the same object as this script
//   Attributes like RequireComponent cause the Unity editor to make changes
//   In this case, the Unity editor will check and see if there is a TMP_Text component on the same game object.
//   If there is no component, it will actually add the component to the game object for us!

[RequireComponent(typeof(TMP_Text))]

public class TimerUIController : MonoBehaviour
{
    //public instance fields (variables): visible and "serialized" in inspector

    // Add a header in the inspector
    //   Attributes like Header cause the Unity editor to make changes
    //   In this case, the Unity editor will add a boldface header using the string you pass it

    [Header("Timer Settings")]

    // Add a tooltip to explain details about the speed field in the inspector
    //   Attributs like Tooltip cause the Unity editor to make changes
    //   In this case, a tooltip will now appear if someone hovers the mouse within the name of the next field

    [Tooltip("1 will increase the timer by 1 every second, .5 is 50% speed, etc.")]
    public float speed = 1;

    [Tooltip("a string of text to show to the right of the number")]
    public string label;

    //private instance fields (variables)
    //    We can access these across multiple separate instance methods, like Start() and Update()

    TMP_Text textUI;
    float timeCurrent;

    // Start is called before the first frame update

    void Start()
    {
        // Keep a reference to the TextMeshPro Text (TMP_Text) component and change its text field.
        //    We can get access to another component on this game object (the game object this script is on) using
        //    GetComponent<>(); The angle brackets allow us to select the type of component we want to access. Then,
        //    any public instance members are available through the member operator (a dot/period). So, we could
        //    call a method, or change a variable that is a member of that component. (Helpfully, a good IDE can
        //    show us all the available members after we type the period.)

        textUI = GetComponent<TMP_Text>();
        textUI.text = "Starting...";

        // assign a value of zero to our timeCurrent variable ( our own instance variable we declared above )

        timeCurrent = 0;
    }

    // Update is called once per frame (every split second of play)

    void Update()
    {
        // Make small increases to the value of our timeCurrent variable and update the text to show them
        // Time.deltaTime has the amount of time, in seconds, that has passed since the last frame update
        //   which is almost always a small fraction of a second. We multiply by speed to allow a change
        //   in how fast the timer increases (or decreases) from the inspector in the Unity Editor.

        timeCurrent = timeCurrent + Time.deltaTime * speed;
        textUI.text = timeCurrent.ToString("N0") + " " + label;

        // See standard numeric format strings in C# 
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings


        // Change to below will show the fraction of a second passed between each frame update:
        // textUI.text = "Time.deltaTime is " + Time.deltaTime.ToString("N7") + " seconds";
    }
}
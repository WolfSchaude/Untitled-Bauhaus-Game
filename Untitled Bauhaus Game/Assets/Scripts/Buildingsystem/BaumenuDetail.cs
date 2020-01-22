using UnityEngine;
using UnityEngine.UI;

public class BaumenuDetail : MonoBehaviour
{
    public GameObject detailWindow;

    public GameObject Playervariables;

    public GameObject BuildDropDown;

    public AnimationStarter AnimStarter;

    public Text buildingNameText;
    public Text buildingPriceText;
    public Text buildingTeacherText;
    public Text buildingStudentText;
    public Text buildingStilText;
    public Text buildingQualityText;
    public Text buildingTimeTotalText;
    public Text buildingTimeLeftText;

    public Image buildingImage;

    public enum Type { Undefiniert, Architekturwerkstatt, Ausstellungsgestaltung, Malerei, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };

    [SerializeField] private int MainBuildType;
    [SerializeField] private int BuildType;

    void Start()
    {
    }

    void Update()
    {
    }

    public void UpdateContent() //Updates detail windows content depending on which button was pressed
    {
        MainBuildType = Playervariables.GetComponent<Bausystem>().MainTypeToBuild;
        BuildType = Playervariables.GetComponent<Bausystem>().TypeToBuild;
        buildingNameText.text = ((Type)BuildType).ToString();
        buildingPriceText.text = "Preis: " + Playervariables.GetComponent<Bausystem>().ActualCosts + " RM";
        buildingQualityText.text = "Zu erwartende Qualität: " + "100%";
        buildingTimeTotalText.text = "Bauzeit: " + Playervariables.GetComponent<Bausystem>().ActualBuildTime + " Tage";
        buildingTeacherText.text = "Dozentenkapazität: ";
        buildingStudentText.text = "Studentenkapazität: " + Playervariables.GetComponent<Bausystem>().ActualCapacity + " Studenten";

        if (MainBuildType == 1)
        {
            BuildDropDown.SetActive(true);
        }
        else
        {
            BuildDropDown.SetActive(false);
        }

        if (!AnimStarter.Collapsed)
        {
            Kamera.LockCameraMovement.Invoke();
            QuickAccesskeys.IOpenedAWindow.Invoke();
        }
        else
        {
            Kamera.FreeCameraMovement.Invoke();
            QuickAccesskeys.IClosedAWindow.Invoke();
        }
    }
}
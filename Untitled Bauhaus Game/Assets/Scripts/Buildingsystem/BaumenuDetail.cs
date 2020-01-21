using UnityEngine;
using UnityEngine.UI;

public class BaumenuDetail : MonoBehaviour
{
    public GameObject detailWindow;

    public GameObject Playervariables;

    public GameObject BuildDropDown;

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

    private int BuildType;

    void Start()
    {
    }

    void Update()
    {
        UpdateContent(); //Updates detail windows content depending on which button was pressed
    }

    public void ShowWindow(int Baum) //Sets detail window active
    {
        if (!detailWindow.activeSelf)
        {
            Kamera.LockCameraMovement.Invoke();
            detailWindow.SetActive(true);
            
            if (Baum == 1)
            {
                BuildDropDown.SetActive(true);
            }
            else
            {
                BuildDropDown.SetActive(false);
            }
        }
        else
        {
            Kamera.FreeCameraMovement.Invoke();
            detailWindow.SetActive(false);
        }
    }

    public void UpdateContent() //Updates detail windows content depending on which button was pressed
    {
        BuildType = Playervariables.GetComponent<Bausystem>().TypeToBuild;
        buildingNameText.text = ((Type)BuildType).ToString();
        buildingPriceText.text = "Preis: " + Playervariables.GetComponent<Bausystem>().ActualCosts + " RM";
        buildingQualityText.text = "Zu erwartende Qualität: " + "100%";
        buildingTimeTotalText.text = "Bauzeit: " + Playervariables.GetComponent<Bausystem>().ActualBuildTime + " Tage";
        buildingTeacherText.text = "Dozentenkapazität: ";
        buildingStudentText.text = "Studentenkapazität: " + Playervariables.GetComponent<Bausystem>().ActualCapacity + " Studenten";
    }
}
using UnityEngine;
using UnityEngine.UI;

public class BaumenuDetail : MonoBehaviour
{
    public GameObject detailWindow;

    public GameObject overviewWindow;

    public GameObject Playervariables;

    public GameObject StartBuild;

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

    bool archwerkstattDetailOpen = false;
    bool malereiDetailOpen = false;
    bool ausstellungDetailOpen = false;
    bool metallwerkstattDetailOpen = false;
    bool tischlereiDetailOpen = false;
    bool lehrsaalDetailOpen = false;
    bool wohnheimDetailOpen = false;

    private int BuildType;

    void Start()
    {
    }

    void Update()
    {
        updateContent(); //Updates detail windows content depending on which button was pressed
        checkCloseButton(); //Checks if the Close Button was pressed
    }

    public void showWindow() //Sets detail window active
    {
        if (!detailWindow.activeSelf)
        {
            detailWindow.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().bewerbungGameObject.SetActive(false);
            GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zuweisenGameObject.SetActive(false);
            //GameObject.Find("EventSystem").GetComponent<ExpoInventory>().showWindow();

        }
        else
        {
            detailWindow.SetActive(false);
        }
    }

    public void toggleArchitekturwerkstatt()
    {
        archwerkstattDetailOpen = !archwerkstattDetailOpen;
    }
    public void toggleMalerei()
    {
        malereiDetailOpen = !malereiDetailOpen;
    }
    public void toggleAusstellungsgestaltung()
    {
        ausstellungDetailOpen = !ausstellungDetailOpen;
    }
    public void toggleMetallwerkstatt()
    {
        metallwerkstattDetailOpen = !metallwerkstattDetailOpen;
    }
    public void toggleTischlerei()
    {
        tischlereiDetailOpen = !tischlereiDetailOpen;
    }
    public void toggleLehrsaal()
    {
        lehrsaalDetailOpen = !lehrsaalDetailOpen;
    }
    public void toggleWohnheim()
    {
        wohnheimDetailOpen = !wohnheimDetailOpen;
    }

    public void updateContent() //Updates detail windows content depending on which button was pressed
    {
        BuildType = Playervariables.GetComponent<Bausystem>().TypeToBuild;
        buildingNameText.text = ((Type)BuildType).ToString();
        buildingPriceText.text = "Preis: " + Playervariables.GetComponent<Bausystem>().ActualCosts + " RM";
        buildingQualityText.text = "Zu erwartende Qualität: " + "100%";
        buildingTimeTotalText.text = "Bauzeit: " + Playervariables.GetComponent<Bausystem>().ActualBuildTime + " Tage";
        buildingTimeLeftText.text = "Bauzeit übrig: Lol, noch nicht drin";
        buildingTeacherText.text = "Dozentenkapazität: ";
        buildingStudentText.text = "Studentenkapazität: " + Playervariables.GetComponent<Bausystem>().ActualCapacity + " Studenten";
        buildingTimeLeftText.gameObject.SetActive(false);
    }

    public void checkCloseButton()  //Checks if the Close Button was pressed
    {
        archwerkstattDetailOpen = false;
        malereiDetailOpen = false;
        ausstellungDetailOpen = false;
        metallwerkstattDetailOpen = false;
        tischlereiDetailOpen = false;
        lehrsaalDetailOpen = false;
        wohnheimDetailOpen = false;
    }
}
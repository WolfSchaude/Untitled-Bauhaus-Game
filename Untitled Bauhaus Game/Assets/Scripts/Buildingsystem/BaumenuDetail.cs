using UnityEngine;
using UnityEngine.UI;

public class BaumenuDetail : MonoBehaviour
{
    public GameObject Playervariables;

    public Text buildingNameText;
    public Text buildingPriceText;
    //public Text buildingTeacherText;
    public Text buildingStudentText;
    public Text buildingQualityText;
    public Text buildingTimeTotalText;

    public enum Type { Undefiniert, Architekturwerkstatt, Ausstellungsgestaltung, Malerei, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };

    [SerializeField] private int MainBuildType;
    [SerializeField] private int BuildType;

    public void UpdateContent() //Updates detail windows content depending on which button was pressed
    {
        MainBuildType = Playervariables.GetComponent<Bausystem>().MainTypeToBuild;
        BuildType = Playervariables.GetComponent<Bausystem>().TypeToBuild;
        buildingNameText.text = ((Type)BuildType).ToString();
        buildingPriceText.text = Playervariables.GetComponent<Bausystem>().ActualCosts + " RM";
        buildingQualityText.text = "100%";
        buildingTimeTotalText.text = Playervariables.GetComponent<Bausystem>().ActualBuildTime;
        //buildingTeacherText.text = "Dozentenkapazität: ";
        buildingStudentText.text = Playervariables.GetComponent<Bausystem>().ActualCapacity;
    }
}
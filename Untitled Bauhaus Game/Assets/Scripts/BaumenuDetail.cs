using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaumenuDetail : MonoBehaviour
{
    public GameObject detailWindow;

    public GameObject dropdownContainerB; //Bau Dropdown
    public GameObject dropdownContainerD; //Dozenten Dropdown

    public GameObject overviewWindow;

    public GameObject archButton;
	public GameObject malButton;
	public GameObject ausButton;
	public GameObject metallButton;
	public GameObject tischbutton;
	public GameObject lehrButton;
    public GameObject wohnButton;

    public Text buildingNameText;
    public Text buildingPriceText;
    public Text buildingTeacherText;
    public Text buildingStudentText;
    public Text buildingStilText;
    public Text buildingQualityText;
    public Text buildingTimeTotalText;
    public Text buildingTimeLeftText;

    public Image buildingImage;

    bool archwerkstattDetailOpen = false;
    bool malereiDetailOpen = false;
    bool ausstellungDetailOpen = false;
    bool metallwerkstattDetailOpen = false;
    bool tischlereiDetailOpen = false;
    bool lehrsaalDetailOpen = false;
    bool wohnheimDetailOpen = false;

    public int buttonCount = 0;

    void Start()
    {
        detailWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main_Menu");
        }

        if (!detailWindow.activeSelf/* && !GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().bewerbungGameObject.activeSelf && !GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zuweisenGameObject.activeSelf*/) //Disables all dropdown menus when window is open
        {
            dropdownContainerB.SetActive(true);
            //dropdownContainerD.SetActive(true);
        }
        else
        {
            dropdownContainerB.SetActive(false);
            //dropdownContainerD.SetActive(false);

            overviewWindow.SetActive(false);
        }

        checkWindow(); //Checks if detail window is open
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
			//GameObject.Find("Event_Overview").GetComponent<EventScript>().ToggleEvent(); //fickt das script
        }
        else
        {
            detailWindow.SetActive(false);
        }
    }

    public void checkWindow()   //Checks if detail window is open
    {
        if (archwerkstattDetailOpen)
        {
            buttonCount = 1;
        }
        if (malereiDetailOpen)
        {
            buttonCount = 2;
        }
        if (ausstellungDetailOpen)
        {
            buttonCount = 3;
        }
        if (metallwerkstattDetailOpen)
        {
            buttonCount = 4;
        }
        if (tischlereiDetailOpen)
        {
            buttonCount = 5;
        }
        if (lehrsaalDetailOpen)
        {
            buttonCount = 6;
        }
        if (wohnheimDetailOpen)
        {
            buttonCount = 7;
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
        switch (buttonCount)
        {
            case 1:
                buildingNameText.text = "Archtekturwerkstatt";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AktPreis.ToString() + " RM";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().archBuildTimeInMonths + " Monat(e)";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().studKapazitätArch.ToString();

                //buildingImage.sprite

                if (GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().buildInProgress)
                {
                    archButton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    archButton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
				malButton.SetActive(false);
				ausButton.SetActive(false);
				metallButton.SetActive(false);
				tischbutton.SetActive(false);
                lehrButton.SetActive(false);
                wohnButton.SetActive(false);
                break;
            case 2:
                buildingNameText.text = "Malerei";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueMalerei>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueMalerei>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueMalerei>().malBuildTimeInMonths + " Monat(e)";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueMalerei>().AktPreis.ToString() + " RM";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueMalerei>().studKapazitätMal.ToString();

                //buildingImage.sprite

                if (GameObject.Find("UI").GetComponent<BaueMalerei>().buildInProgress)
                {
                    malButton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    malButton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
				archButton.SetActive(false);
				ausButton.SetActive(false);
				metallButton.SetActive(false);
				tischbutton.SetActive(false);
				lehrButton.SetActive(false);
				wohnButton.SetActive(false);
				break;
            case 3:
                buildingNameText.text = "Ausstellungsgestaltung";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().ausBuildTimeInMonths + " Monat(e)";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().AktPreis.ToString() + " RM";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().studKapazitätAus.ToString();

                //buildingImage.sprite

                if (GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().buildInProgress)
                {
                    ausButton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    ausButton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
				archButton.SetActive(false);
				malButton.SetActive(false);
				metallButton.SetActive(false);
				tischbutton.SetActive(false);
				lehrButton.SetActive(false);
				wohnButton.SetActive(false);
				break;
            case 4:
                buildingNameText.text = "Metallwerkstatt";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().metallBuildTimeInMonths + " Monat(e)";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().AktPreis.ToString() + " RM";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().studKapazitätMetall.ToString();

                //buildingImage.sprite

                if (GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().buildInProgress)
                {
                    metallButton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    metallButton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
				archButton.SetActive(false);
				malButton.SetActive(false);
				ausButton.SetActive(false);
				tischbutton.SetActive(false);
				lehrButton.SetActive(false);
				wohnButton.SetActive(false);
				break;
            case 5:
                buildingNameText.text = "Tischlerei";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueTischlerei>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueTischlerei>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueTischlerei>().tischBuildTimeInMonths + " Monat(e)";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueTischlerei>().AktPreis.ToString() + " RM";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueTischlerei>().studKapazitätTisch.ToString();

                //buildingImage.sprite

                if (GameObject.Find("UI").GetComponent<BaueTischlerei>().buildInProgress)
                {
                    tischbutton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    tischbutton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
				archButton.SetActive(false);
				malButton.SetActive(false);
				ausButton.SetActive(false);
				metallButton.SetActive(false);
				lehrButton.SetActive(false);
				wohnButton.SetActive(false);
				break;
            case 6:
                buildingNameText.text = "Lehrsaal";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueLehrsaal>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueLehrsaal>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehrBuildTimeInMonths + " Monat(e)";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueLehrsaal>().AktPreisL.ToString() + " RM";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueLehrsaal>().studKapazitätLehr.ToString();

                //buildingImage.sprite

                archButton.SetActive(false);
                if (GameObject.Find("UI").GetComponent<BaueLehrsaal>().buildInProgress)
                {
                    lehrButton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    lehrButton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
				archButton.SetActive(false);
				malButton.SetActive(false);
				ausButton.SetActive(false);
				metallButton.SetActive(false);
				tischbutton.SetActive(false);
				wohnButton.SetActive(false);
				break;
            case 7:
                buildingNameText.text = "Wohnheim";
                buildingQualityText.text = "Zu erwartende Qualität: " + GameObject.Find("UI").GetComponent<BaueWohnheim>().MinQualität.ToString() + " - " + GameObject.Find("UI").GetComponent<BaueWohnheim>().MaxQualitaet.ToString();
                buildingTimeTotalText.text = "Bauzeit: 2 Monate";
                buildingTimeLeftText.text = "Bauzeit übrig: " + GameObject.Find("UI").GetComponent<BaueWohnheim>().wohnBuildTimeInMonths + " Monat(e)";
                buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueWohnheim>().AktPreisW.ToString() + " RM";
                buildingTeacherText.text = "Dozentenkapazität: ";
                buildingStudentText.text = "Studentenkapazität: " + GameObject.Find("UI").GetComponent<BaueWohnheim>().studKapazitätWohn.ToString();

				//buildingImage.sprite

				archButton.SetActive(false);
				malButton.SetActive(false);
				ausButton.SetActive(false);
				metallButton.SetActive(false);
				tischbutton.SetActive(false);
				lehrButton.SetActive(false);
				if (GameObject.Find("UI").GetComponent<BaueWohnheim>().buildInProgress)
                {
                    wohnButton.SetActive(false);
                    buildingTimeLeftText.enabled = true;
                }
                else
                {
                    wohnButton.SetActive(true);
                    buildingTimeLeftText.enabled = false;
                }
                break;
        }
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

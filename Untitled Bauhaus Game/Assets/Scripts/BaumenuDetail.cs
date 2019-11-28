using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaumenuDetail : MonoBehaviour
{
	public GameObject detailWindow;

	public GameObject dropdownContainerB; //Bau Dropdown
    public GameObject dropdownContainerD; //Dozenten Dropdown

    public GameObject werkButton;
	public GameObject lehrButton;
	public GameObject wohnButton;

	public Text buildingNameText;
	public Text buildingPriceText;
	public Text buildingTeacherText;
	public Text buildingStudentText;

	public Image buildingImage;

	bool werkstattDetailOpen = false;
	bool lehrsaalDetailOpen = false;
	bool wohnheimDetailOpen = false;

	int buttonCount = 0;

	void Start()
	{
		detailWindow.SetActive(false);
	}

	void Update()
	{
        if (!detailWindow.activeSelf) //Disables all dropdown menus when detail window is open
		{
			dropdownContainerB.SetActive(true);
            dropdownContainerD.SetActive(true);
        }
		else
		{
			dropdownContainerB.SetActive(false);
            dropdownContainerD.SetActive(false);
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
		}
		else
		{
			detailWindow.SetActive(false);
		}
	}

    public void checkWindow()
    {
        if (werkstattDetailOpen)
        {
            buttonCount = 1;
        }

        if (lehrsaalDetailOpen)
        {
            buttonCount = 2;
        }

        if (wohnheimDetailOpen)
        {
            buttonCount = 3;
        }
    }
	public void toggleWerkstatt()
	{
		werkstattDetailOpen = !werkstattDetailOpen;
	}
	public void toggleLehrsaal()
	{
		lehrsaalDetailOpen = !lehrsaalDetailOpen;
	}
	public void toggleWohnheim()
	{
		wohnheimDetailOpen = !wohnheimDetailOpen;
	}

	public void updateContent()
	{
		switch (buttonCount)
		{
			case 1:
				buildingNameText.text = "Werkstatt";
				buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueWerkstatt>().AktPreis.ToString() + " RM";
				buildingTeacherText.text = "Dozentenkapazität: ";
				buildingStudentText.text = "Studentenkapazität: ";

				//buildingImage.sprite

				werkButton.SetActive(true);
				lehrButton.SetActive(false);
				wohnButton.SetActive(false);
				break;
			case 2:
				buildingNameText.text = "Lehrsaal";
				buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueLehrsaal>().AktPreisL.ToString() + " RM";
				buildingTeacherText.text = "Dozentenkapazität: ";
				buildingStudentText.text = "Studentenkapazität: ";

				//buildingImage.sprite

				werkButton.SetActive(false);
				lehrButton.SetActive(true);
				wohnButton.SetActive(false);
				break;
			case 3:
				buildingNameText.text = "Wohnheim";
				buildingPriceText.text = "Preis: " + GameObject.Find("UI").GetComponent<BaueWohnheim>().AktPreisW.ToString() + " RM";
				buildingTeacherText.text = "Dozentenkapazität: ";
				buildingStudentText.text = "Studentenkapazität: ";

				//buildingImage.sprite

				werkButton.SetActive(false);
				lehrButton.SetActive(false);
				wohnButton.SetActive(true);
				break;
		}
	}

    public void checkCloseButton()
    {
        werkstattDetailOpen = false;
        lehrsaalDetailOpen = false;
        wohnheimDetailOpen = false;
    }
}

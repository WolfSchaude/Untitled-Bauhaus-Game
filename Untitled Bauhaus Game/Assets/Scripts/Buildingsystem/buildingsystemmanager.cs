using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledBauhausGame
{
    public class buildingsystemmanager : MonoBehaviour
    {

        public GameObject[] Werkstätte;
        public GameObject bauhaushaupt;
        public GameObject ModulParent;
        public GameObject[] Baum;

        public Module[] Scripts;
        public bauhausmain Center;

        public int ArrayPointer;

        public bool ConNotCenter;
        public bool ConCenter;
        public int ConForPoint;
        public bool ConBreakOut;
        public Vector3 ConAttachedNode;

        public bool[] FreeTiles; //Übergangssystem
        public Vector3[] TilePositions; //Übergangssystem

        void Start()
        {
            Werkstätte = new GameObject[256];

            Scripts = new Module[256];

            Baum = new GameObject[256];

            for (int i = 0; i <= 255; i++)
            {
                Werkstätte[i] = Instantiate(GameObject.Find("Module"),ModulParent.transform);
                Scripts[i] = Werkstätte[i].GetComponent<Module>();
            }

            //ArrayPointer = 0;
            //bauhaushaupt = GameObject.Find("bauhausmain");
            //Center = bauhaushaupt.GetComponent<bauhausmain>();

            ConNotCenter = false;
            ConCenter = false;
            ConBreakOut = false;

            //Übergangssystem; Notiz: bauhausmain node2 module pos: x: -1, y: 1, z: -0.25
            FreeTiles = new bool[256];
            
            for (int i = 0; i <= 255; i++)
            {
                FreeTiles[i] = false;
            }

            TilePositions = new Vector3[256];
            TilePositions[0] = new Vector3();
        }

        void Update()
        {

        }

        public void DestroyWorkshop(int WorkShopType)
        {

        }

        public void PlaceWorkshop(int WorkShopType)
        {
            if (ArrayPointer >= 0 && ArrayPointer <= 255)
            {
                LoopBreakOut = false;

                //if (Center.Node2Used == true)
                //{
                //    ConAttachedNode = Scripts[0].Node1;
                //}

                //Werkstätte[ArrayPointer] = Instantiate(GameObject.Find("Module"));
                //Scripts[ArrayPointer] = Werkstätte[ArrayPointer].GetComponent<Module>();


                //ConAttachedNode = Scripts[0].Node1;//debug

                Scripts[ArrayPointer].WerkstattTyp = WorkShopType;

                if (Center.Node2Used == false)
                {
                    //ConNotCenter = false;//Debug
                    //ConCenter = true;//debug

                    Scripts[ArrayPointer].PlaceModule(Center.Node2, 4);
                    Scripts[ArrayPointer].ModuleSet = true;
                    Scripts[ArrayPointer].Node4Used = true;
                    //GameObject Modul1 = GameObject.Find("Module");
                    //Module Hallol = Modul1.GetComponent<Module>();
                    //Hallol.PlaceModule(Center.Node2, 4);
                    Center.Node2Used = true;

                    //ConAttachedNode = Scripts[0].Node1;//debug
                }
                else
                {
                    //ConNotCenter = true;//debug
                    //ConCenter = false;//debug


                    for (int i = 0; i <= ArrayPointer; i++)
                    {
                        //ConForPoint = i; //debug

                        if (Scripts[i].Node1Used == false)
                        {
                            ConAttachedNode = Scripts[0].Node1;//debug

                            Scripts[ArrayPointer].PlaceModule(Scripts[i].Node1, 3);
                            Scripts[i].Node1Used = true;
                            //Scripts[ArrayPointer].Node3Used = true;
                            //Scripts[ArrayPointer].ModuleSet = true;
                            break;
                            //ConAttachedNode = Scripts[0].Node1;//debug
                        }

                        if (Scripts[i].Node2Used == false)
                        {
                            Scripts[ArrayPointer].PlaceModule(Scripts[i].Node2, 4);
                            Scripts[i].Node2Used = true;
                            //Scripts[ArrayPointer].Node4Used = true;
                            //Scripts[ArrayPointer].ModuleSet = true;
                            break;
                        }

                        if (Scripts[i].Node3Used == false)
                        {
                            Scripts[ArrayPointer].PlaceModule(Scripts[i].Node3, 1);
                            Scripts[i].Node3Used = true;
                            //Scripts[ArrayPointer].Node1Used = true;
                            //Scripts[ArrayPointer].ModuleSet = true;
                            break;
                        }

                        if (Scripts[i].Node4Used == false)
                        {
                            Scripts[ArrayPointer].PlaceModule(Scripts[i].Node4, 2);
                            Scripts[i].Node4Used = true;
                            //Scripts[ArrayPointer].Node2Used = true;
                            //Scripts[ArrayPointer].ModuleSet = true;
                            break;
                        }
                    }
                }

                for (int i = 0; i <= 255; i++)
                {
                    if (i != ArrayPointer && Scripts[i].ModuleSet == true)
                    {
                        float Distance = Vector3.Distance(Scripts[ArrayPointer].transform.position, Scripts[i].transform.position);

                        if (Distance <= 1.1f)
                        {
                            //Distance = Vector3.Distance()
                        }
                    }
                }

                ArrayPointer = ArrayPointer + 1;
            }
        }
    }
}
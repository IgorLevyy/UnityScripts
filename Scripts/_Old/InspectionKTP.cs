using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class InspectionKTP : MonoBehaviour {

    public GameObject PI1;
    public GameObject PI2;
    public GameObject PI3;

    public GameObject Pred1;
    public GameObject Pred2;
    public GameObject Pred3;

    public GameObject Soed1;
    public GameObject Soed2;
    public GameObject Soed3;

    public GameObject Trans1;
    public GameObject Trans2;

    public GameObject PI4;
    public GameObject PI5;
    public GameObject PI6;

    public GameObject OPN1;
    public GameObject OPN2;
    public GameObject OPN3;

    public GameObject Soed4;
    public GameObject Soed5;
    public GameObject Soed6;
    public GameObject Soed7;

    public GameObject Table1;
    public GameObject Table2;
    public GameObject Table3;
    public GameObject Table4;

    public GameObject AV1;
    public GameObject AV2;
    public GameObject AV3;

    public GameObject automat1;
    public GameObject automat2;
    public GameObject automat3;
    public GameObject automat4;
    public GameObject automat5;
    public GameObject automat6;
    public GameObject klemnik;
    public GameObject schetchik;

    public GameObject zero1;
    public GameObject zero2;
    public GameObject zero3;
    public GameObject zero4;
    public GameObject zero5;

    public GameObject razryadnik1;
    public GameObject razryadnik2;
    public GameObject razryadnik3;

    public GameObject razmykatel;

    public GameObject transform1;
    public GameObject transform2;
    public GameObject transform3;

    private int CurrentStep = 0;
    private float deltaTime = 0;
    private bool visibleOutline = true;


    [DllImport("__Internal")]
    private static extern void Altr();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurrentStep < 16)
            {
                CurrentStep++;
                GameObject.Find("Camera").GetComponent<Animator>().Play("fly" + CurrentStep);
                //GameObject.Find("Camera").GetComponent<Animator>().transform.position();
                //GameObject.Find("Camera").GetComponent<Animator>()
                if (CurrentStep == 1)
                {
                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Camera").transform.position.ToString(); /*"РУВН";*/
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Распределительное устройство высшего напряжения служит для приема электрического напряжения 10 кВ";
                    Application.ExternalEval("alert('button');"); 
                    //Application.ExternalCall("Altr");
                    // Altr();
                }
                if (CurrentStep == 2)
                {
                    PI1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Изоляторы";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "На верхнем основании расположены проходные изоляторы к верхней части которых крепятся провода ВЛ";
                }
                if (CurrentStep == 3)
                {
                    PI1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    OPN1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    OPN2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    OPN3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Разрядники ОПН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Разрядники предназначены для защиты от перенпряжений при атмосферных явлениях (гроза) и неправильных оперативных переключениях персонала. Разрядники 6 кВ расположены на верхнем основании КТП.";
                }
                if (CurrentStep == 4)
                {
                    GameObject.Find("Сборка со столбом-3823|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4835|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 3").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("EDD04BB399166A977E70E24FAA9896D283ABBDDD|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;

                    OPN1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    OPN2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    OPN3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Soed1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Cоединение";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Из нижней части проходных изоляторов посредством шин происходит соединение питающей  ВЛ с предохранителями";
                }

                if (CurrentStep == 5)
                {
                    Soed1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Pred1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Pred2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Pred3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Предохранители";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Предохранители, которые защищают трансформатор от коротких замыканий";
                }

                if (CurrentStep == 6)
                {
                    Pred1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Pred2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Pred3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    GameObject.Find("Сборка со столбом-3823|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4835|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 3").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("EDD04BB399166A977E70E24FAA9896D283ABBDDD|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;

                    GameObject.Find("Сборка со столбом-3579|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20739|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;

                    Trans1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Trans2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Трансформатор";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "ТМГ (трехфазный трансформатор герметичный) предназначен для преобразования электроэнергии в сетях энергосистем";
                }

                if (CurrentStep ==  7)
                {
                    Trans1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Trans2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Soed4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed7.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Низкая сторона";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Низкая сторона трансформатора соединена  с шинами  РУНН";
                }

                if (CurrentStep == 8)
                {
                    Soed4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed7.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    PI4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Крепление шин";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "От нижней части крепления предохранителей, переход  к изоляторам высокой обмотки трансформатора выполнен через проходной изолятор";
                }

                if (CurrentStep == 9)
                {
                    GameObject.Find("Сборка со столбом-3579|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20739|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;

                    PI4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Table1.GetComponent<Renderer>().materials[1].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "РУНН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Распределительное устройство низкого напряжения. На шкаф РУНН нанесены знаки «Осторожно! Электрическое напряжение!» и заземление, надпись отображающая  принадлежность КТП и телефон диспетчера, наименование и номер КТП. Двери имеют блокировку, отключающие напряжение в случае их открытия.";
                }

                if (CurrentStep == 10)
                {
                    Table1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Table1.GetComponent<Renderer>().enabled = false;
                    Table2.GetComponent<Renderer>().enabled = false;
                    Table3.GetComponent<Renderer>().enabled = false;
                    Table4.GetComponent<Renderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-9944|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20676|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-9881|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-9818|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;

                    razmykatel.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Размыкатель РУНН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "От низкой стороны трансформатора шины приходят на Размыкатель РУНН. Размыкатель имеет предохранители защищающие от токов КЗ";
                }

                if (CurrentStep == 11)
                {
                    razmykatel.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    transform1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    transform2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    transform3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Трансформаторы тока";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "На выходе размыкателя установлены трансформаторы тока";
                }

                if (CurrentStep == 12)
                {
                    transform1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    transform2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    transform3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    AV1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    AV2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    AV3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Автоматические выключатели";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Автоматические выключатели соединены с шинами РУНН и от них отходят жгуты к потребителям. ";
                }

                if (CurrentStep == 13)
                {
                    AV1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    AV2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    AV3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    automat1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    klemnik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    schetchik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    schetchik.GetComponent<Renderer>().materials[1].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Вспомогательные цепи";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Кроме этого в РУНН расположены низковольтные автоматы вспомогательных цепей а также учет электроэнергии.";

                }

                if (CurrentStep == 14)
                {
                    automat1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    klemnik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    schetchik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    schetchik.GetComponent<Renderer>().materials[1].shader = Shader.Find("Standard");

                    zero1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Нулевой провод";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Нулевая шина трансворматора подключена через токовое реле РЭ13, ограничивающие ток в нулевом проводе. Выходная нулевая шина изолирована, что позволяет реализовать 4-х и 5-ти проводную схему.";
                }

                if (CurrentStep == 15)
                {
                    zero1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    razryadnik1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    razryadnik2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    razryadnik3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Разрядники ОПН-0,4";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Разрядники предназначены для защиты от перенапряжений при атмосферных явлениях (гроза) и неправильных оперативных переключениях персонала";
                }
                if (CurrentStep == 16)
                {
                    razryadnik1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    razryadnik2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    razryadnik3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Table1.GetComponent<Renderer>().enabled = true;
                    Table2.GetComponent<Renderer>().enabled = true;
                    Table3.GetComponent<Renderer>().enabled = true;
                    Table4.GetComponent<Renderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-9944|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20676|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-9881|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-9818|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Наименование КТП";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Наименование или номер КТП с указанием класса напряжения РУ или если это отсек трансформатора – номер трансформатора и его мощность";
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CurrentStep != 0)
            {
                GameObject.Find("Camera").GetComponent<Animator>().Play("fly" + CurrentStep + "Back");
                CurrentStep--;

                if (CurrentStep == 0)
                {
                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "КТП";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Комплектная трансформаторная подстанция 10 / 0,4 кВ и прилегающая территория";
                }
                if (CurrentStep == 1)
                {
                    PI1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "РУВН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Распределительное устройство высшего напряжения служит для приема электрического напряжения 10 кВ";
                }
                if (CurrentStep == 2)
                {
                    OPN1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    OPN2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    OPN3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    PI1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Изоляторы";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "На верхнем основании расположены проходные изоляторы к верхней части которых крепятся провода ВЛ";
                }
                if (CurrentStep == 3)
                {
                    Soed1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    GameObject.Find("Сборка со столбом-3823|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4835|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 3").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("EDD04BB399166A977E70E24FAA9896D283ABBDDD|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;

                    OPN1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    OPN2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    OPN3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Разрядники ОПН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Разрядники предназначены для защиты от перенапряжений при атмосферных явлениях (гроза) и неправильных оперативных переключениях персонала.";
                }
                if (CurrentStep == 4)
                {
                    Pred1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Pred2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Pred3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Soed1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Cоединение";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Из нижней части проходных изоляторов посредством шин происходит соединение питающей  ВЛ с разъединителем (ВН) 6 кВ, конструктивно исполнено совместно с  заземляющими ножами";
                }
                
                if (CurrentStep == 5)
                {
                    Trans1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Trans2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    GameObject.Find("Сборка со столбом-3579|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20739|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = true;

                    GameObject.Find("Сборка со столбом-3823|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4835|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4657|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-4746|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 3").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("EDD04BB399166A977E70E24FAA9896D283ABBDDD|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;

                    Pred1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Pred2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Pred3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Предохранители";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Предохранители, которые защищают трансформатор от коротких замыканий";
                }

                if (CurrentStep == 6)
                {
                    Soed4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed7.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Trans1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Trans2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Трансформатор";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "ТМГ (трехфазный трансформатор герметичный) предназначен для преобразования электроэнергии в сетях энергосистем";
                }

                if (CurrentStep == 7)
                {
                    PI4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Soed4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed7.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Низкая сторона";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Низкая сторона трансформатора соединена  с шинами  РУНН";
                }

                if (CurrentStep == 8)
                {
                    Table1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    GameObject.Find("Сборка со столбом-3579|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20409|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20739|:|B8A4396250C5687B1D31E70758B30729E1AC4426 1").GetComponent<MeshRenderer>().enabled = false;

                    PI4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Крепление шин";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "От нижней части крепления предохранителей, переход  к изоляторам высокой обмотки трансформатора выполнен через проходной изолятор";
                }

                if (CurrentStep == 9)
                {
                    razmykatel.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    Table1.GetComponent<Renderer>().enabled = true;
                    Table2.GetComponent<Renderer>().enabled = true;
                    Table3.GetComponent<Renderer>().enabled = true;
                    Table4.GetComponent<Renderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-9944|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-20676|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-9881|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.Find("Сборка со столбом-9818|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = true;

                    Table1.GetComponent<Renderer>().materials[1].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "РУНН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Распределительное устройство низкого напряжения. На шкаф РУНН нанесены знаки «Осторожно! Электрическое напряжение!» и заземление, надпись отображающая  принадлежность КТП и телефон диспетчера, наименование и номер КТП. Двери имеют блокировку, отключающие напряжение в случае их открытия.";
                }

                if (CurrentStep == 10)
                {
                    transform1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    transform2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    transform3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    razmykatel.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Размыкатель РУНН";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "От низкой стороны трансформатора шины приходят на Размыкатель РУНН. Размыкатель имеет предохранители защищающие от токов КЗ";
                }

                if (CurrentStep == 11)
                {
                    AV1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    AV2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    AV3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    transform1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    transform2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    transform3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Трансформаторы тока";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "На выходе размыкателя установлены трансформаторы тока";
                }

                if (CurrentStep == 12)
                {
                    automat1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    klemnik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    schetchik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    schetchik.GetComponent<Renderer>().materials[1].shader = Shader.Find("Standard");


                    AV1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    AV2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    AV3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Автоматические выключатели";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Автоматические выключатели соединены с шинами РУНН и от них отходят жгуты к потребителям. ";
                }

                if (CurrentStep == 13)
                {
                    zero1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    automat1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    klemnik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    schetchik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    schetchik.GetComponent<Renderer>().materials[1].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Вспомогательные цепи";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Кроме этого в РУНН расположены низковольтные автоматы вспомогательных цепей а также учет электроэнергии.";


                }

                if (CurrentStep == 14)
                {
                    razryadnik1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    razryadnik2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    razryadnik3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");

                    zero1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Нулевой провод";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Нулевая шина трансворматора подключена через токовое реле РЭ13, ограничивающие ток в нулевом проводе. Выходная нулевая шина изолирована, что позволяет реализовать 4-х и 5-ти проводную схему.";


                }

                if (CurrentStep == 15)
                {


                    Table1.GetComponent<Renderer>().enabled = false;
                    Table2.GetComponent<Renderer>().enabled = false;
                    Table3.GetComponent<Renderer>().enabled = false;
                    Table4.GetComponent<Renderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-9944|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-20676|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-9881|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Сборка со столбом-9818|:|B8A4396250C5687B1D31E70758B30729E1AC4426").GetComponent<MeshRenderer>().enabled = false;

                    razryadnik1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    razryadnik2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    razryadnik3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");

                    GameObject.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "Разрядники ОПН-0,4";
                    GameObject.Find("Description").GetComponent<UnityEngine.UI.Text>().text = "Разрядники предназначены для защиты от перенапряжений при атмосферных явлениях (гроза) и неправильных оперативных переключениях персонала";
                }

            }
        }

        deltaTime++;

        if (deltaTime == 30)
        {
            if (CurrentStep == 2)
            {
                if (visibleOutline)
                {
                    PI1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = false;
                }
                else
                {
                    PI1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = true;
                }
            }
            if (CurrentStep == 3)
            {
                if (visibleOutline)
                {
                    OPN1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    OPN2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    OPN3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = false;
                }
                else
                {
                    OPN1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    OPN2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    OPN3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = true;
                }
            }
            if (CurrentStep == 4)
            {
                if (visibleOutline)
                {
                    Soed1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = false;
                }
                else
                {
                    Soed1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = true;
                }
            }
            if (CurrentStep == 5)
            {
                if (visibleOutline)
                {
                    Pred1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Pred2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Pred3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    Pred1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Pred2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Pred3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 6)
            {
                if (visibleOutline)
                {
                    Trans1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Trans2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    Trans1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Trans2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 7)
            {
                if (visibleOutline)
                {
                    Soed4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Soed7.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    Soed4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Soed7.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 8)
            {
                if (visibleOutline)
                {
                    PI4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    PI6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    PI4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    PI6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 9)
            {
                if (visibleOutline)
                {
                    Table1.GetComponent<Renderer>().materials[1].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    Table4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    Table1.GetComponent<Renderer>().materials[1].shader = Shader.Find("Standard");
                    Table2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    Table4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 10)
            {
                if (visibleOutline)
                {
                    razmykatel.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    razmykatel.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 11)
            {
                if (visibleOutline)
                {
                    transform1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    transform2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    transform3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    transform1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    transform2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    transform3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 12)
            {
                if (visibleOutline)
                {
                    AV1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    AV2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    AV3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    AV1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    AV2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    AV3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 13)
            {
                if (visibleOutline)
                {
                    automat1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    automat6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    klemnik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    schetchik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    schetchik.GetComponent<Renderer>().materials[1].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    automat1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat5.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    automat6.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    klemnik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    schetchik.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    schetchik.GetComponent<Renderer>().materials[1].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 14)
            {
                if (visibleOutline)
                {
                    zero1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    zero4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    zero1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    zero4.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            if (CurrentStep == 15)
            {
                if (visibleOutline)
                {
                    razryadnik1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    razryadnik2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    razryadnik3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Custom/NewSurfaceShader");
                    visibleOutline = false;
                }
                else
                {
                    razryadnik1.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    razryadnik2.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    razryadnik3.GetComponent<Renderer>().materials[0].shader = Shader.Find("Standard");
                    visibleOutline = true;
                }
            }

            deltaTime = 0;
        }
    }
}

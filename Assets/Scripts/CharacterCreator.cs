using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{
    public DynamicCharacterAvatar avatar;
    public Slider height;
    public Slider weight;
    public Slider muscle;
    private Dictionary<string, DnaSetter> dna;
    public List<string> menHairstyles = new List<string>();
    public List<string> womenHairstyles = new List<string>();
    private int currentHair;

    private void OnEnable()
    {
        avatar.CharacterUpdated.AddListener(Updated);
        height.onValueChanged.AddListener(HeightChange);
        weight.onValueChanged.AddListener(WeightChange);
        muscle.onValueChanged.AddListener(MuscleChange);
    }
    private void OnDisable()
    {
        avatar.CharacterUpdated.RemoveListener(Updated);
        height.onValueChanged.RemoveListener(HeightChange);
        weight.onValueChanged.RemoveListener(WeightChange);
        muscle.onValueChanged.RemoveListener(MuscleChange);
    }
    public void SwitchGender(bool male)
    {
        if (male && avatar.activeRace.name != "HumanMaleDCS")
        {
            avatar.ChangeRace("HumanMaleDCS");
        }
        if (!male && avatar.activeRace.name != "HumanFemaleDCS")
        {
            avatar.ChangeRace("HumanFemaleDCS");
        }
       
    }
    void Updated(UMAData data)
    {
        dna = avatar.GetDNA();
        /*
        foreach (string key in dna.Keys)
        {
            Debug.Log(key);
        }*/
    }
    void HeightChange(float val)
    {
        dna["height"].Set(val);
        avatar.BuildCharacter();
    }
    void WeightChange(float val)
    {
        dna["belly"].Set(val);
        dna["waist"].Set(val);
        dna["upperWeight"].Set(val);
        dna["lowerWeight"].Set(val);
        avatar.BuildCharacter();
    }
    void MuscleChange(float val)
    {
        dna["upperMuscle"].Set(val);
        dna["armWidth"].Set(val);
        dna["forearmWidth"].Set(val);
        avatar.BuildCharacter();
    }

    public void ChangeSkinColor(Color col)
    {
        avatar.SetColor("Skin", col);
        avatar.UpdateColors(true);
    }

    public void ChangeHair(bool plus)
    {
        if (plus)
        {
            currentHair++;
        }
        else
            currentHair--;

        if (avatar.activeRace.name == "HumanMaleDCS")
        {
            currentHair = Mathf.Clamp(currentHair, 0, menHairstyles.Count - 1);

            if (menHairstyles[currentHair] == "None")
            {
                avatar.ClearSlot("Hair");
            }
            else
                avatar.SetSlot("Hair", menHairstyles[currentHair]);
        }
        else if (avatar.activeRace.name == "HumanFemaleDCS")
        {
            currentHair = Mathf.Clamp(currentHair, 0, womenHairstyles.Count - 1);

            if (womenHairstyles[currentHair] == "None")
            {
                avatar.ClearSlot("Hair");
            }
            else
                avatar.SetSlot("Hair", womenHairstyles[currentHair]);
        }

        avatar.BuildCharacter();
    }
}

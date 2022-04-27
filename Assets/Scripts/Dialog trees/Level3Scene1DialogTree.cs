using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Scene1DialogTree : AbstractDialogTree
{
    public override int OnDialogOptionPicked(int optionIndex, int dialogLineIndex)
    {
        // Regardless the poem, let the dialog continue
        return 6;
    }

    public override DialogLineInfo GetDialogLine(int dialogLineIndex)
    {
        switch(dialogLineIndex)
        {
            case 0:
            {
                return new DialogLineInfo("Salutari tinere calator. Bine ai venit la locul meu de veci,  domeniul intelectualitatii eterne unde creativitatea si inteligenta umana prospera in eternitate", "Eminescu", new List<string>());
            }

            case 1:
            {
                return new DialogLineInfo(".... aolo asta e Eminescu... nici la facultate nu scap de el", "Tu", null);
            }

            case 2:
            {
                return new DialogLineInfo("Tinere drag, ce te aduce pe aceste meleaguri? Putin cuteaza sa se aventureze prin asemenea locuri dezolante fiindu-le friica de dominanta simbolului mortii de peste acest spatiu restrans", "Eminescu", null);
            }

            case 3:
            {
                return new DialiogLineInfo("Ahm... buna ziua domnule Eminescu... condoleante... Mergeam la facultate, dar nu pot cobora la metrou", "Tu", null);
            }
            case 4:
            {
                return new DialogLineInfo("Ah! In drumul tau catre cultivarea sinelui intelectual. Apreciez dorinta de cunoastere. Stiu de ce ai nevoie in calatoria ta. Dar mai intai, te voi supune la un test pentru a vedea daca esti vrednic pentru calea cunoasterii.", "Eminescu", null);
            }
            case 5:
            {
                var poems = new List<string>();
                poems.Add("Luceafarul");
                poems.Add("Ce te legeni?");
                poems.Add("Dorinta");
                poems.Add("Scrisoarea III");

                return new DialogLineInfo("Alege una din aceste opere celebre scrise de geniul meu pe care sa o reciti pentru a-mi demonstra nivelul tau de cultura", "Eminescu", poems);
            }
            case 6:
            {
                return new DialiogLineInfo("Pff... da cine mai stie poezia asta..", "Tu", null);
            }
            case 7:
            {
                return new DialiogLineInfo("Si asa…am mai picat pe unu", "Eminescu", null);
            }
            default:
            {
                return null;
            }
        }
        
    }
}
